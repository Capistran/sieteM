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
    public partial class ConsultaRutas : System.Web.UI.Page
    {

        vistaRutas vRutas = new vistaRutas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IniciaGridRutas();
                LlenaGridRutas();
            }

        }
        /*
          _entRuta = new EntRuta();
                        _entRuta.CveRuta = r.CVE_RUTA;
                        _entRuta.Entcedis.NombreCedis = r.CEDIS;
                        _entRuta.Mes = r.MES;
                        _listaRuta.Add(_entRuta);
         */

        private void IniciaGridRutas()
        {
            BoundField bfield = new BoundField();
            bfield.DataField = "CveRuta";
            bfield.HeaderText = "CLAVE RUTA";
            gvRutas.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "CedisOrigen";
            bfield.HeaderText = "CEDIS";
            gvRutas.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Mes";
            bfield.HeaderText = "MES";
            gvRutas.Columns.Add(bfield);
            
        }

        private void LlenaGridRutas()
        { 
            if(Session["UsrInfo"]!=null)
            {
                if((Session["UsrInfo"] as EntUsuarios).IdTransp>0)
                {
                    var listaRutas=vRutas.RegresaCatalogoRutas((Session["UsrInfo"] as EntUsuarios).IdTransp);
                    gvRutas.DataSource=listaRutas;
                    gvRutas.DataBind();
                }            
            }
        }
    }
}