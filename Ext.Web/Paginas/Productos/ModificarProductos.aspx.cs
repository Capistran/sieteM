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
    public partial class ModificarProductos : System.Web.UI.Page
    {
        vistaProducto vProducto = new vistaProducto();
        EntProducto _entProducto = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaControles();
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtClaveProducto")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var detProducto = vProducto.DetalleProductoCodigo(txtClaveProducto.Text);
                    if (detProducto != null)
                    {
                        ViewState["idProducto"] = detProducto.IdProducto;
                        
                    }
                    mostrarDetalleProducto(detProducto);
                }
            }

            txtCodBarras.Attributes.Add("onkeypress", "return isNumberKey(event);");
                
        }

        private void CargaControles()
        {
            iniciaGridProducto();
            CargaGridProducto();
        }

        private void CargaGridProducto()
        {
            gvModProductos.DataSource= vProducto.RegresaTodosProductos();
            gvModProductos.DataBind();
        }

        private void iniciaGridProducto()
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Codigo";
            bfield.DataField = "Clave";
            gvModProductos.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Marca";
            bfield.DataField = "Marca";
            gvModProductos.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Descripcion";
            bfield.DataField = "Descripcion";
            gvModProductos.Columns.Add(bfield);
        }

        protected void gvModProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idproducto = Convert.ToInt32(gvModProductos.DataKeys[e.NewSelectedIndex].Value);
                ViewState["idProducto"] = idproducto;

                var producto = vProducto.DetalleProducto(idproducto);
                if (producto != null)
                {
                ViewState["idProducto"]= producto.IdProducto;
                    mostrarDetalleProducto(producto);
                }
                
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ERROR", "javascript:MsjError('error al cargar el ID de producto');", true);
            }

            
        }

        protected void gvModProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModProductos.PageIndex = e.NewPageIndex;
            CargaGridProducto();
        }

        private void mostrarDetalleProducto(EntProducto entProducto)
        {
            txtClaveProducto.Text = entProducto.Clave;
            txtDescripcion.Text = entProducto.Descripcion;
            txtMarca.Text = entProducto.Marca;
            txtCategoria.Text = entProducto.Categoria;
            txtPiezasPaquete.Text = entProducto.PiezaPaq.ToString();
            txtPiezaPorCaja.Text = entProducto.Pzaporcaja.ToString();
            //txt
            //txtPrecioPaquete.Text = entProducto.PrecioPaquete.ToString();
            txtCodBarras.Text = entProducto.CodBarras.ToString();
            txtPaquetesCaja.Text = entProducto.PaqCaja.ToString();
            //txtPrecioPaquete.Text = entProducto.PrecioPaquete.ToString();
            //txtPrecioPieza.Text = entProducto.PrecioPieza.ToString();
        }

        private void detalleProductoNuevo()
        {
            _entProducto = new EntProducto();
            _entProducto.IdProducto = Convert.ToInt32(ViewState["idProducto"].ToString() == "" ? "0" : ViewState["idProducto"]);
            _entProducto.Clave = txtClaveProducto.Text;
            _entProducto.Descripcion = txtDescripcion.Text;
            _entProducto.Marca = txtMarca.Text;
            _entProducto.Categoria = txtCategoria.Text;
            _entProducto.PiezaPaq = Convert.ToInt32(txtPiezasPaquete.Text);
           // _entProducto.PrecioPaquete =Convert.ToDecimal( txtPrecioPaquete.Text);
            _entProducto.CodBarras = Convert.ToDecimal(txtCodBarras.Text);
            _entProducto.PaqCaja = Convert.ToInt32(txtPaquetesCaja.Text);
            _entProducto.Pzaporcaja = Convert.ToInt32(txtPiezaPorCaja.Text);
            //_entProducto.PrecioPaquete = Convert.ToDecimal(txtPrecioPaquete.Text);
            //_entProducto.PrecioPieza = Convert.ToDecimal(txtPrecioPieza.Text);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try             
            {
                
                detalleProductoNuevo();
                if (vProducto.ActualizaProducto(_entProducto) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "success", "javascript:MsjModificado();", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "limpiar", "javascript:limpiarControles();", true);
                    CargaGridProducto();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "noactualizo", "javascript:alert('Producto No Actualizado');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "ERROR", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }
    }
}