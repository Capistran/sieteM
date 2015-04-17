using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;

namespace Ext.Web.Paginas.Choferes
{
    public partial class DetalleOperadores : System.Web.UI.Page
    {
        vistaChofer vChofer = new vistaChofer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicaGridOperador();
                CargaGridOperador();
            }
        }

        protected void gvInfoOperador_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvInfoOperador_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (gvInfoOperador.Rows.Count > 0)
                {
                    int idOperador = Convert.ToInt32(gvInfoOperador.DataKeys[e.RowIndex].Value);
                    if (vChofer.EliminaOperador(idOperador, (Session["UsrInfo"] as EntUsuarios).IdTransp))
                    {
                        CargaGridOperador();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "EliminaError", "javascript:alert('" + ex.Message + "');", true);
            }
        }

        private void CargaGridOperador()
        { 
            int idTransp=(Session["UsrInfo"] as EntUsuarios).IdTransp;
            gvInfoOperador.DataSource = vChofer.RegresaChoferTransporte(idTransp);
            gvInfoOperador.DataBind();

        }

        private void InicaGridOperador()
        {
            BoundField bfield = new BoundField();
            bfield.DataField = "NumEmpleado";
            bfield.HeaderText = "NUM. EMPLEADO";
            
            gvInfoOperador.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Nombre";
            bfield.HeaderText = "NOMBRE";
            gvInfoOperador.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Auxiliar";
            bfield.HeaderText = "PUESTO";
            gvInfoOperador.Columns.Add(bfield);
        }
    }
}