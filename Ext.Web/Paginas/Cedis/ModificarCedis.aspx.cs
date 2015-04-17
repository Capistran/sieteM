using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Paginas.Cedis
{
    public partial class ModificarCedis : System.Web.UI.Page
    {

        vistaCatalogos vcatalogos = new vistaCatalogos();
        vistaCedis vCedis = new vistaCedis();
        EntCedis _entCedis = new EntCedis();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaEstados();
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

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtClaveCedis")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var cveCedis = Request.Form["__EVENTARGUMENT"].ToString();
                    var cedis = vCedis.InformacionCedisClave(cveCedis);
                    if (cedis.IdCedis > 0)
                    {
                        ViewState["IdCedis"] = cedis.IdCedis;
                        informacionCedis(cedis);
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjNoEncontrado();", true);
                }
            }
        }

        private void informacionCedis(EntCedis entcedis)
        {
            txtNombreCedis.Text = entcedis.NombreCedis;            
            ddEstados.SelectedIndex = entcedis.IdEstado;
            CargaCiudades(entcedis.IdEstado);
            ddCiudad.SelectedIndex = entcedis.IdCiudad-1;
            txtColonia.Text = entcedis.Colonia;
            txtCP.Text = entcedis.CP;
            txtCalle.Text = entcedis.Calle;
            txtNumExt.Text = entcedis.NumExt;
            txtNumInt.Text = entcedis.NumInt;
            txtLote.Text = entcedis.Lote;
            txtSuperManzana.Text = entcedis.SuperManzana;
            txtManzana.Text = entcedis.Manzana;
        }

        private void InformacionNuevaCedis()
        {
            _entCedis = new EntCedis();
            _entCedis.NombreCedis = txtNombreCedis.Text;
            _entCedis.IdEstado =Convert.ToInt32( ddEstados.SelectedValue);
            _entCedis.IdCiudad = Convert.ToInt32( ddCiudad.SelectedValue);
            _entCedis.Colonia = txtColonia.Text;
            _entCedis.CP = txtCP.Text;
            _entCedis.Calle = txtCalle.Text;
            _entCedis.Manzana = txtManzana.Text;
            _entCedis.SuperManzana=txtSuperManzana.Text;
            _entCedis.Lote=txtLote.Text;
            _entCedis.NumExt=txtNumExt.Text;
            _entCedis.NumInt=txtNumInt.Text;
            _entCedis.CveCedis = txtClaveCedis.Text;
            _entCedis.IdCedis = Convert.ToInt32(ViewState["IdCedis"].ToString());
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionNuevaCedis();
                if (vCedis.ActualizaCedis(_entCedis) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjActualizado();", true);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "limpiar", "javascript:limpiarControles();", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:alert('Cedis no actualizado');", true);

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjError('" + ex.Message + "');", true);
            }

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