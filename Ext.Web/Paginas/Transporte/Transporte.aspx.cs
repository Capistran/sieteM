using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;


namespace Ext.Web.Paginas.Transporte
{
    public partial class Transporte : System.Web.UI.Page
    {
        vistaTransporte vTransporte = new vistaTransporte();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        EntTransportista _transporte = new EntTransportista();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreaGrid();
                CargaGridTransporte();
                CargaEstados();
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int idestado = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idestado + ");", true);
                    CargaCiudades(idestado);
                }
            }

          
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddFormatoDir")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var formato = Request.Form["__EVENTARGUMENT"].ToString();          
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + formato + "');", true);
                }
            }
        }

        protected void btnGuardarTransporte_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionTransporte();
                if (!vTransporte.ExisteTransportistaPorClave(_transporte.ClaveTransporte))
                {
                    if (vTransporte.AgregaNuevoTransporte(_transporte) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "asignado", "javascript:MsjAgregado();", true);
                        CargaGridTransporte();
                    }
                }else
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "asignado", "javascript:MsjExistente('"+txtClaveTransporte.Text.ToUpper()+"');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "asignado", "javascript:MsjError('" + ex.Message + "');", true);
                
            }
        }

        private void InformacionTransporte()
        {
            _transporte = new EntTransportista();
            _transporte.RazonSocial = txtRazonSocial.Text;
            _transporte.RFC_Transportista = txtRFC.Text;
            _transporte.IdEstado = Convert.ToInt32(ddEstados.SelectedValue);
            _transporte.IdCiudad = Convert.ToInt32(ddCiudad.SelectedValue);
            _transporte.Colonia = txtColonia.Text;
            _transporte.Calle = txtCalle.Text;
            _transporte.NumExt = txtNumExt.Text;
            _transporte.NumInt = txtNumInt.Text;
            _transporte.CP = txtCP.Text;
            _transporte.ClaveTransporte = txtClaveTransporte.Text;
            _transporte.Usuarioweb = txtUsuarioweb.Text;
            _transporte.Passwordweb = txtUsuarioweb.Text;
            _transporte.Gpsweb = txtGpsWeb.Text;
            _transporte.NombreComercial = txtNombreComercial.Text;
        }

        private void CargaGridTransporte()
        {
            gvTransporte.DataSource = vTransporte.RegresaLineasTransporte();
            gvTransporte.DataBind();
        }

        private void CreaGrid()
        {
            BoundField bfield = new BoundField();
            
            bfield.HeaderText = "CLAVE";
            bfield.DataField = "ClaveTransporte";
            gvTransporte.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "RazonSocial";
            bfield.HeaderText = "RAZON SOCIAL";
            gvTransporte.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "RFC";
            bfield.DataField = "RFC_Transportista";
            gvTransporte.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "ENTIDAD FEDERATIVA";
            bfield.DataField = "DesEstado";
            gvTransporte.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "CIUDAD";
            bfield.DataField = "DescCiudad";
            gvTransporte.Columns.Add(bfield);
            

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
                   

    }
}