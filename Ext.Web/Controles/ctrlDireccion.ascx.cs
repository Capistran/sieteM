using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;
namespace Ext.Web.Controles
{
    public partial class ctrlDireccion : System.Web.UI.UserControl
    {
        #region Propiedades
        EntDireccion _entDireccionCtrl = new EntDireccion();

        public EntDireccion EntDireccionCtrl
        {
            get { return _entDireccionCtrl; }
            set { _entDireccionCtrl = value; }
        }             
        
        #endregion
        vistaCatalogos vcatalogos = new vistaCatalogos();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaEstados();
            }
            CtrlDireccion();
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ctrldir$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var idEstado = Request.Form["__EVENTARGUMENT"].ToString();
                    CargaCiudades(Convert.ToInt32(idEstado));
                    //FormatoDireccion
                    
                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ctrldir$ddFormatoDir")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var formato = Request.Form["__EVENTARGUMENT"].ToString();
                    //CargaCiudades(idestado);
                    //FormatoDireccion
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + formato + "');", true);
                }
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


        private void CtrlDireccion()
        {
            _entDireccionCtrl.Calle = txtCalle.Text;
            _entDireccionCtrl.Colonia = txtColonia.Text;
        }
    }
}