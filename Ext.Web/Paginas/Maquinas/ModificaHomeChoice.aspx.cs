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
                IniciaGridHistorial();
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumPaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    decimal numpaciente = Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"].ToString());
                    var datosPac = vPaciente.RegresaPacientePorClave(numpaciente);
                    if (datosPac.IdPaciente <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('No existe la Informacion de paciente');", true);
                        return;
                    }
                    ViewState["IdPaciente"] = datosPac.IdPaciente;
                    lblNombre.Text = datosPac.Nombre;
                    var datosHC = vMaquina.RegresaInformacionHC(datosPac.IdPaciente);
                    txtNoSerie.Text = datosHC.NoSerie.ToString();                    
                    LlenaGridHistorial(datosPac.IdPaciente);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IdPaciente"] == null || ViewState["IdPaciente"].ToString() == string.Empty)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('No ha seleccionado Paciente');", true);
                    return;
                }
                decimal noserie=0M;
                decimal.TryParse(txtNoSerie.Text,out noserie);
                if (vMaquina.ActualizaHC(Convert.ToInt32(ViewState["IdPaciente"]), noserie))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('Se ha actualizado el número de serie');", true);
                    LlenaGridHistorial(Convert.ToInt32(ViewState["IdPaciente"]));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('"+ex.Message+"');", true);
            }
        }

        private void LlenaGridHistorial(int idPaciente)
        {
            var listaHistorial = vMaquina.HistorialMaquina(idPaciente);
            if (listaHistorial.Count > 0)
            {
                gvHistorial.DataSource = listaHistorial;
                gvHistorial.DataBind();
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "agregado", "javascript:alert('No se encontro Historial de Información del paciente');", true);
        }

        private void IniciaGridHistorial()
        {
            /*
              maquina = new EntMaquina();
                        maquina.SerieActual=(decimal)(h.NO_SERIE_ACTUAL==null?0:h.NO_SERIE_ACTUAL);
                        maquina.SerieAnterior=(decimal)(h.NO_SERIE_ANTERIOR==null?0:h.NO_SERIE_ANTERIOR);
                        maquina.TipoMovimiento = h.TIPO_MOVIMIENTO;
                        maquina.FechaEntrega =(DateTime)
             */
            BoundField bfield = new BoundField();
            //bfield.DataField = "SerieActual";
            //bfield.HeaderText = "No. Serie Actual";
            //gvHistorial.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "SerieAnterior";
            bfield.HeaderText = "No. Serie Anterior";
            gvHistorial.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "TipoMovimiento";
            bfield.HeaderText = "Movimiento";
            gvHistorial.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "FechaEntrega";
            bfield.HeaderText = "Fecha Entrega";
            gvHistorial.Columns.Add(bfield);

        }
    }
}