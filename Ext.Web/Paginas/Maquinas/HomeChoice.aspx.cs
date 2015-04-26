using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Paginas.Maquinas
{
    public partial class HomeChoice : System.Web.UI.Page
    {

        vistaPaciente vPaciente = new vistaPaciente();
        vistaMaquina vMaquina = new vistaMaquina();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumPaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"]; 
                    decimal numpaciente=Convert.ToDecimal(ViewState["cvePaciente"].ToString()==""?"0":ViewState["cvePaciente"].ToString());
                    var datosPac=vPaciente.RegresaPacientePorClave(numpaciente);
                    ViewState["IdPaciente"] = datosPac.IdPaciente;
                    if(vMaquina.ExisteMaquina(datosPac.IdPaciente))
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('El Paciente ya tiene una HOME CHOICE Agregada');", true);
                    lblNombre.Text = datosPac.Nombre;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            { 
                if(ViewState["IdPaciente"]==null||ViewState["IdPaciente"].ToString()==string.Empty)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('No ha seleccionado Paciente');", true);
                
                decimal noserie=0.0M;
                decimal.TryParse(txtNoSerie.Text,out noserie);
                if(vMaquina.AgregaNuevoHomeChoice(Convert.ToInt32(ViewState["IdPaciente"].ToString()),noserie)==0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('Maquina HOME CHOICE agregada');", true);
                }

            
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('"+ex.Message+"');", true);
            }
        }
    }
}