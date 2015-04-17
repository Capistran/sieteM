using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;

namespace Ext.Web.Paginas.Productos
{
    public partial class Producto : System.Web.UI.Page
    {

        EntProducto _entProducto = null;
        vistaProducto vProducto = new vistaProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            
            }
            txtCodBarras.Attributes.Add("onkeypress", "return isNumberKey(event);");
            txtPaquetesCaja.Attributes.Add("onkeypress", "return isNumberKey(event);");
            txtPiezaPorCaja.Attributes.Add("onkeypress", "return isNumberKey(event);");
            txtPiezasPaquete.Attributes.Add("onkeypress", "return isNumberKey(event);");
            
        }

        private void informacionProducto()
        {
            _entProducto = new EntProducto();
            _entProducto.Clave = txtClaveProducto.Text;
            _entProducto.Marca = txtMarca.Text;
            _entProducto.Categoria = txtCategoria.Text;
            _entProducto.Descripcion = txtDescripcion.Text;
            //_entProducto.PrecioCaja = Convert.ToDecimal(txtPrecioCaja.Text==""?"0":txtPrecioCaja.Text);
            _entProducto.Pzaporcaja = Convert.ToInt32(txtPiezaPorCaja.Text==""?"0":txtPiezaPorCaja.Text);
            _entProducto.PaqCaja = Convert.ToInt32(txtPaquetesCaja.Text==""?"0":txtPaquetesCaja.Text);
            _entProducto.PiezaPaq = Convert.ToInt32(txtPiezasPaquete.Text==""?"0":txtPiezasPaquete.Text);
            //_entProducto.PrecioPaquete = Convert.ToDecimal(txtPrecioPaquete.Text==""?"0":txtPrecioPaquete.Text);
            //_entProducto.PrecioPieza = Convert.ToDecimal(txtPrecioPieza.Text==""?"0":txtPrecioPieza.Text);
            _entProducto.CodBarras = Convert.ToDecimal(txtCodBarras.Text == "" ? "0" : txtCodBarras.Text);
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!vProducto.ExisteProducto(txtClaveProducto.Text))
                {
                    informacionProducto();
                    if (vProducto.NuevoProducto(_entProducto) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "success", "javascript:MsjAgregado();", true);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "success", "javascript:limpiarControles();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "success", "javascript:MsjExiste('" + txtClaveProducto.Text + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "success", "javascript:alert('"+ex.Message+"');", true);
            }
        }

        
    }
}