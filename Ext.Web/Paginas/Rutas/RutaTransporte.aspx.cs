using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Paginas.Rutas
{
    public partial class RutaTransporte : System.Web.UI.Page
    {

        /*
         QUITAR TRANSPORTE 
         */
        vistaTransporte vTrasnporte = new vistaTransporte();
        vistaCatalogos vCatalogos = new vistaCatalogos();
        vistaRutas vRutas = new vistaRutas();
        EntRuta _entRuta = new EntRuta();
        private int _idTransp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaLineaTransporte();
                CargaTransportePorLinea();
                CargaConsultaTransporte();
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddTransporte")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["idTransp"] = Request.Form["__EVENTARGUMENT"];
                    CargaTransportePorLinea();
                    CargaConsultaTransporte();
                }
            }
        }


        private void CargaLineaTransporte()
        {
            ddTransporte.DataSource = vTrasnporte.RegresaLineasTransporte();
            ddTransporte.DataTextField = "RazonSocial";
            ddTransporte.DataValueField = "IdTransportista";
            ddTransporte.DataBind();

            ViewState["idTransp"] = ddTransporte.SelectedValue;
        }

        private void CargaTransportePorLinea()
        {
            try
            {
                _idTransp = Convert.ToInt32(ViewState["idTransp"]);
            }
            catch
            { 
            }


            ddCedis.DataSource = vCatalogos.RegresaListaCedis();
            ddCedis.DataTextField = "NombreCedis";
            ddCedis.DataValueField = "IdCedis";
            ddCedis.DataBind();
        }

        private void CargaConsultaTransporte()
        {
            /*ddConsultaTransporte.DataSource = vTrasnporte.RegresaLineasTransporte();
            ddConsultaTransporte.DataTextField = "RazonSocial";
            ddConsultaTransporte.DataValueField = "IdTransportista";
            ddConsultaTransporte.DataBind();*/
        
        }

        private void InformacionRuta()
        {
            //_entRuta.IdCamion = Convert.ToInt32(ddVehiculo.SelectedValue);
            _entRuta.CveRuta = txtClaveRuta.Text.ToUpper();
            _entRuta.IdTransportista = Convert.ToInt32(ddTransporte.SelectedValue);
            _entRuta.Entcedis.IdCedis = Convert.ToInt32(ddCedis.SelectedValue);
            var fecha=Convert.ToDateTime(txtFechaEmbarque.Text);
            //string formato = fecha.Day.ToString();
            _entRuta.FechaEmbarque = new DateTime(fecha.Year, fecha.Month, fecha.Day);
            _entRuta.Mes = ddMes.SelectedValue;
        }

        protected void btnGenerarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                _idTransp = Convert.ToInt32(ViewState["idTransp"]);
                InformacionRuta();
                if (!vRutas.ExsteRutaMes(_entRuta.IdTransportista, _entRuta.CveRuta, _entRuta.Mes.ToUpper()))
                {
                    if (vRutas.NuevaRuta(_entRuta) == 0)                    
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Exito", "javascript:MsjRutaGenerada();", true);                    
                    else                    
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Exitoe", "javascript:alert('Ruta No Agregada');", true);                    
                }
                else                
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "existente", "javascript:MsjRutaExistente('" + _entRuta.CveRuta.ToUpper() + "');", true);
                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Error", "javascript:MsjError('" + ex.Message + "');", true);
            }

        }
    }
}