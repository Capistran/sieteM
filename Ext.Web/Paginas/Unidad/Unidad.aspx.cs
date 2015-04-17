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
    public partial class Unidad : System.Web.UI.Page
    {
        vistaChofer vChofer = new vistaChofer();
        EntCamion _entcamion = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaListaChoferTransportista();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionTransporte();
                if (vChofer.AgregarCamion(_entcamion) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "asignado", "javascript:alert('Asignado correctamente');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "no asignado", "javascript:alert('No Asignado ');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "excepcion", "javascript:alert('" + ex.Message + "');", true);
            }
        }

        private void CargaListaChoferTransportista()
        {/*
            try
            {
                int idTransp = (Session["UsrInfo"] as EntUsuarios).IdTransp;
                ddChoferes.DataSource = vChofer.RegresaChoferTransporte(idTransp);
                ddChoferes.DataTextField = "NombreChofer";
                ddChoferes.DataValueField = "IdUsuario";
                ddChoferes.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ERROR", "javascript:alert('" + ex.Message + "')", true);
            }*/
        }

        private void InformacionTransporte()
        {
            _entcamion = new EntCamion();
            _entcamion.IdTransp = (Session["UsrInfo"] as EntUsuarios).IdTransp;
            //_entcamion.IdUsuario = Convert.ToInt32(ddChoferes.SelectedValue);
            _entcamion.Placas = txtPlacas.Text;
            _entcamion.NumEconomico = txtNumEconomico.Text;
            _entcamion.Marca = txtMarca.Text;
            _entcamion.Modelo = txtModelo.Text;
            _entcamion.CapacidadCarga = Convert.ToDecimal(txtCapacidad.Text);
            _entcamion.NoPoliza = txtPoliza.Text;
            _entcamion.CompañiaSeguro = txtSeguro.Text;
            _entcamion.VigenciaPoliza = Convert.ToDateTime(txtVigenciaPoliza.Text==""?(new DateTime(2000,1,1,0,0,0).ToShortDateString()):txtVigenciaPoliza.Text);
            _entcamion.CodBarras = Convert.ToDecimal(txtCodBarras.Text==""?"0":txtCodBarras.Text);

        }
    }
}