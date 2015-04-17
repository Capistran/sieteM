using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;

namespace Ext.Web.Controles
{
    public partial class CtrlLoginEstatus : System.Web.UI.UserControl
    {
        vistaUsuarios vUsuarios= new vistaUsuarios();
        EntUsuarios _usuarioActivo = new EntUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaInformacionUsuarioActivo();            
            }
                
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx",true);
        }

        void CargaInformacionUsuarioActivo()
        {
            var usuario = Session["UsrInfo"] as EntUsuarios;
            _usuarioActivo=vUsuarios.InformacionUsuarioSign(usuario.IdUsuario, usuario.IdTransp);

            lblnombreCompleto.Text = _usuarioActivo.Nombre;
            lbleMail.Text = _usuarioActivo.RazonSocial;
        
        }
    }
}