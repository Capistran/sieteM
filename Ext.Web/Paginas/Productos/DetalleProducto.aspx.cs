using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;

namespace Ext.Web.Paginas.Productos
{
    public partial class DetalleProducto : System.Web.UI.Page
    {

        vistaProducto vProducto = new vistaProducto();        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iniciaGrid();
                CargaGridProductos();
            }
        }

        private void iniciaGrid()
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Código";
            bfield.DataField = "Clave";
            gvDetalleProducto.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Marca";
            bfield.DataField = "Marca";
            gvDetalleProducto.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Descripcion";
            bfield.DataField = "Descripcion";
            gvDetalleProducto.Columns.Add(bfield);

        }

        /*borrar columna*/
        private void CargaGridProductos()
        {
            gvDetalleProducto.DataSource = vProducto.RegresaTodosProductos();
            gvDetalleProducto.DataBind();
        }

        protected void gvDetalleProducto_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gvDetalleProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idProd = Convert.ToInt32(gvDetalleProducto.DataKeys[e.RowIndex].Value);
            try
            {
                vProducto.EliminaProducto(idProd);
                CargaGridProductos();
            }
            catch (Exception ex)
            {

            }


        }
    }
}