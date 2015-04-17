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
    public partial class Cedis : System.Web.UI.Page
    {

        vistaCatalogos vcatalogos = new vistaCatalogos();
        EntCedis _entCedis = null;
        vistaCedis vCedis = new vistaCedis();
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
        private void InformacionNuevaCedis()
        {
            _entCedis = new EntCedis();
            _entCedis.NombreCedis = txtNombreCedis.Text;
            _entCedis.IdEstado = Convert.ToInt32(ddEstados.SelectedValue);
            _entCedis.IdCiudad = Convert.ToInt32(ddCiudad.SelectedValue);
            _entCedis.Colonia = txtColonia.Text;
            _entCedis.Calle = txtCalle.Text;
            _entCedis.CP = txtCP.Text;
            _entCedis.Manzana = txtManzana.Text;
            _entCedis.SuperManzana = txtSuperManzana.Text;
            _entCedis.Lote = txtLote.Text;
            _entCedis.NumExt = txtNumExt.Text;
            _entCedis.NumInt = txtNumInt.Text;
            _entCedis.CveCedis = txtClaveCedis.Text;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionNuevaCedis();
                if (vCedis.NuevoCedis(_entCedis) == 0)
                {
                    //MjsAgregado
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "insertar", "javascript:MjsAgregado();", true);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "limpiar", "javascript:limpiarControles();", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "noinsertar", "javascript:alert('Cedis no se pudo registrar');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "error", "javascript:MsjError('" + ex.Message + "');", true);
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