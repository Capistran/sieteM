using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;


namespace Ext.Web.Paginas
{
    public partial class Grupos : System.Web.UI.Page
    {
//        ProxyCatalogos proxyCat = new ProxyCatalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iniciaGrid();
                llenaGrid();
            }
        }

        public void iniciaGrid()
        {
            BoundField bnfield = new BoundField();
            bnfield.DataField = "Descgpo";
            bnfield.HeaderText = "Descripcion";

            gvGrupos.Columns.Add(bnfield);
        }

        public void llenaGrid()
        {
            //gvGrupos.DataSource = proxyCat.RegresaGruposServicio();
            gvGrupos.DataBind();
        }
    }
}