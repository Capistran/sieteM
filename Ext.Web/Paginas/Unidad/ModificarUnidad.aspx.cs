using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;

namespace Ext.Web.Paginas.Unidad
{
    public partial class ModificarUnidad : System.Web.UI.Page
    {
        vistaCamion vCamion = new vistaCamion();
        EntCamion _entCamion = new EntCamion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["idTransp"] = (Session["UsrInfo"] as EntUsuarios).IdTransp;
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumEconomico")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    if (Request.Form["__EVENTARGUMENT"].ToString() == txtNumEconomico.Text)
                    {
                        var unidad = vCamion.InformacionCamionporNum(txtNumEconomico.Text, Convert.ToInt32(ViewState["idTransp"].ToString()));                        
                        if(unidad.CodBarras==0)
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "buscar", "javascript:UnidadNoEncontrado("+txtNumEconomico.Text+");", true);
                        else
                            informacionCamion(unidad);
                            
                    }
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                informacionCamionNuevo();
                if (vCamion.ActualizaUnidad(_entCamion) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "actualza", "javascript:alert('Unidad Actualizada');", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "actualza", "javascript:LimpiarControles();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "noactualiza", "javascript:alert('Unidad no se ha actualizado');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Error", "javascript:alert('" + ex.Message + "');", true);
            }

        }

        private void informacionCamion(EntCamion ecamion)
        {
            txtPlacas.Text = ecamion.Placas;
            txtMarca.Text = ecamion.Marca;
            txtModelo.Text = ecamion.Modelo;
            txtSeguro.Text = ecamion.CompañiaSeguro;
            txtPoliza.Text = ecamion.NoPoliza;
            txtVigenciaPoliza.Text = ecamion.VigenciaPoliza.ToShortDateString();
            txtCapacidad.Text = ecamion.CapacidadCarga.ToString();
            txtCodBarras.Text = ecamion.CodBarras.ToString();
        }

        private void informacionCamionNuevo()
        {
            _entCamion = new EntCamion();

            _entCamion.Placas = txtPlacas.Text;
            _entCamion.Marca = txtMarca.Text;
            _entCamion.Modelo = txtModelo.Text;
            _entCamion.CompañiaSeguro = txtSeguro.Text;
            _entCamion.NoPoliza = txtPoliza.Text;
            var fecha=Convert.ToDateTime(txtVigenciaPoliza.Text);
            if(fecha.Year==1)
                fecha=new DateTime(2000,1,1,0,0,0);
            _entCamion.VigenciaPoliza = fecha;
            _entCamion.CapacidadCarga = Convert.ToDecimal(txtCapacidad.Text);
            _entCamion.CodBarras = Convert.ToDecimal(txtCodBarras.Text == "" ? "0" : txtCodBarras.Text);
            _entCamion.IdTransp = Convert.ToInt32(ViewState["idTransp"].ToString()==""?"0":ViewState["idTransp"].ToString());
            _entCamion.NumEconomico = txtNumEconomico.Text;
        }
    }
}