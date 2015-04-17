using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;
namespace Ext.Web.Paginas.Maquinas
{
    public partial class ModificaHomeChoice : System.Web.UI.Page
    {

        vistaPaciente vPaciente = new vistaPaciente();
        vistaMaquina vMaquina = new vistaMaquina();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumPaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    decimal numpaciente = Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"].ToString());
                    var datosPac = vPaciente.RegresaPacientePorClave(numpaciente);
                    ViewState["IdPaciente"] = datosPac.IdPaciente;
                    lblNombre.Text = datosPac.Nombre;
                    var datosHC = vMaquina.RegresaInformacionHC(datosPac.IdPaciente);
                    txtNoSerie.Text = datosHC.NoSerie.ToString();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            { 
                decimal noserie=0M;
                decimal.TryParse(txtNoSerie.Text,out noserie);
                if (vMaquina.ActualizaHC(Convert.ToInt32(ViewState["IdPaciente"]), noserie))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('Se ha actualizado el número de serie');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('"+ex.Message+"');", true);
            }
        }
    }
}