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
    public partial class DetalleRuta : System.Web.UI.Page
    {
        vistaRutas vRuta = new vistaRutas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtCveRuta")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    pintaGrid();
                    cargaInfoGrid();
                }
            }
        }



        private void pintaGrid()
        {
            BoundField bfield = new BoundField();
            bfield.DataField = "Cve_INE";
            bfield.HeaderText = "NÚMERO PACIENTE";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Nombre";
            bfield.HeaderText = "NOMBRE";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "LlegadaCedis";
            bfield.HeaderText = "FECHA LLEGADA CEDIS";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "SalidaCedis";
            bfield.HeaderText = "FECHA SALIDA CEDIS";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "FechaEntrega";
            bfield.HeaderText = "FECHA/HORA LLEGADA PACIENTE";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "FechaVencimiento";
            bfield.HeaderText = "FECHA/HORA SALIDA PACIENTE";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Gpsweb";
            bfield.HeaderText = "ESTATUS";
            gvDetalleRuta.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Usuarioweb";
            bfield.HeaderText = "MOTIVO DE CANCELACIÓN";
            gvDetalleRuta.Columns.Add(bfield);
            
        }

        private void cargaInfoGrid()
        {
            vRuta = new vistaRutas();
            var rutainfo = vRuta.RegresaDetalleRutaClave((Session["UsrInfo"] as EntUsuarios).IdTransp, txtCveRuta.Text, ddMes.SelectedItem.ToString());
            if (rutainfo.Count > 0)
            {
                gvDetalleRuta.DataSource = rutainfo;
                gvDetalleRuta.DataBind();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "buscar", "javascript:MsjRutaExistente('')", true);
        }
    }
}