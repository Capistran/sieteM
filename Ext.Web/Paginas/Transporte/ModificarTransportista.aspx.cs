using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;
using Ext.Web.Controles;

namespace Ext.Web.Paginas.Transporte
{
    public partial class ModificarTransportista : System.Web.UI.Page
    {

        vistaTransporte vTransporte = new vistaTransporte();
        EntTransportista _entTransportista = new EntTransportista();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MostrarInformacionTransportista(null);
                CargaEstados();
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtClaveTransporte")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var tra = vTransporte.ObtieneTransportistaporClave(Request.Form["__EVENTARGUMENT"].ToString());
                    MostrarInformacionTransportista(tra);
                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var idEstado = Request.Form["__EVENTARGUMENT"].ToString();
                    CargaCiudades(Convert.ToInt32(idEstado));
                    //FormatoDireccion

                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddFormatoDir")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var formato = Request.Form["__EVENTARGUMENT"].ToString();
                    //CargaCiudades(idestado);
                    //FormatoDireccion
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + formato + "');", true);
                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var idEstado = Request.Form["__EVENTARGUMENT"].ToString();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idEstado + ");", true);
                    CargaCiudades(Convert.ToInt32(idEstado));
                    //FormatoDireccion

                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddFormatoDir")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var formato = Request.Form["__EVENTARGUMENT"].ToString();
                    //CargaCiudades(idestado);
                    //FormatoDireccion
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + formato + "');", true);
                }
            }
            //MostrarInformacionTransportista(null);
        }


        private void InformacionTransportistaModificada()
        {
            _entTransportista = new EntTransportista();
            _entTransportista.NombreComercial = txtNombreComercial.Text;
            _entTransportista.RazonSocial = txtRazonSocial.Text;
            _entTransportista.RFC_Transportista = txtRFC.Text;
            _entTransportista.Usuarioweb = txtUsuarioWeb.Text;
            _entTransportista.Passwordweb = txtPasswordWeb.Text;
            _entTransportista.Gpsweb = txtUrlGPS.Text;
            _entTransportista.Colonia = txtColonia.Text;
            _entTransportista.SuperManzana = txtSuperManzana.Text;
            _entTransportista.Manzana = txtManzana.Text;
            _entTransportista.Lote = txtLote.Text;
            _entTransportista.Calle = txtCalle.Text;
            _entTransportista.NumExt = txtNumExt.Text;
            _entTransportista.NumInt = txtNumInt.Text;
            _entTransportista.Tel_Cel = txtTelCel.Text;
            _entTransportista.TelFijo = txtTelFijo.Text;
            _entTransportista.IdTransportista = (Session["UsrInfo"] as EntUsuarios).IdTransp;
            
        }
        
        private void MostrarInformacionTransportista(EntTransportista entTransportista)
        {
            txtNombreComercial.Text = entTransportista.NombreComercial;
            txtRazonSocial.Text=entTransportista.RazonSocial;
            txtRFC.Text = entTransportista.RFC_Transportista;
            txtUsuarioWeb.Text = entTransportista.Usuarioweb;
            txtPasswordWeb.Text = entTransportista.Passwordweb;
            txtUrlGPS.Text = entTransportista.Gpsweb;
            txtColonia.Text = entTransportista.Colonia;
            txtSuperManzana.Text = entTransportista.SuperManzana;
            txtManzana.Text = entTransportista.Manzana;
            txtLote.Text = entTransportista.Lote;
            txtCalle.Text= entTransportista.Calle;
            txtNumExt.Text = entTransportista.NumExt;
            txtNumInt.Text = entTransportista.NumInt;
            txtTelCel.Text = entTransportista.Tel_Cel;
            txtTelFijo.Text = entTransportista.TelFijo;
            

        }

        private void CargaEstados()
        {

            ddEstados.DataSource = vcatalogos.RegresaEstados();
            ddEstados.DataTextField = "DesEstado";
            ddEstados.DataValueField = "Id";
            ddEstados.DataBind();

            ddEstados.Items.Insert(0, "SELECCIONA ESTADO");
            ddEstados.SelectedIndex = 0;

            ddCiudad.Items.Insert(0, "SELECCIONA CIUDAD");
            ddCiudad.SelectedIndex = 0;

        }

        private void CargaCiudades(int idEstado)
        {
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idEstado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionTransportistaModificada();
                if (vTransporte.ActualizaTrans(_entTransportista) == 0)
                {
                    //MsjActualizado
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "error", "javascript:MsjActualizado();", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "error", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }

    }
}