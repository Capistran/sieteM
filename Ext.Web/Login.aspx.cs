using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Ext.Web.Vistas;

namespace Ext.Web
{
    public partial class Login : System.Web.UI.Page
    {
        vistaUsuarios vUsuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUser.Attributes.Add("onkeypress", "return isNumberKey(event);");
            }
        }

        //protected void ctLogin_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    vUsuarios = new vistaUsuarios();
        //   // Response.Redirect("Default.aspx", false);
        //    if (vUsuarios.ValidaLogin(Convert.ToInt32(ctLogin.UserName), ctLogin.Password))
        //    {
        //        Session["IDUsuario"] = ctLogin.UserName;
        //        InformacionUsuario();
        //        Response.Redirect("Default.aspx", false);
        //    }
        //    else
        //    {
        //        //this.Page.RegisterStartupScript("valida", "javascript:alert('Usuario No Valido');");
        //    }
        //}

        protected void InformacionUsuario()
        {
            Session["UsrInfo"]=vUsuarios.InformacionUsuario(Convert.ToInt32(txtUser.Text));
        
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            vUsuarios = new vistaUsuarios();
            try
            {
                // Response.Redirect("Default.aspx", false);
                if (txtPwd.Text.Length <= 0 || txtUser.Text.Length <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginValida", "javascript:ValidaInicioSesion(" + txtUser.Text.Length + "," + txtPwd.Text.Length + ");", true);
                }
                else
                {
                    if (vUsuarios.ValidaLogin(Convert.ToInt32(txtUser.Text), txtPwd.Text))
                    {
                        FormsAuthentication.SetAuthCookie(txtUser.Text, true);                //Session["IDUsuario"] = txtUser.Text;
                        InformacionUsuario();
                        Response.Redirect("Default.aspx", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "login", "javascript:alert('" + ex.Message + "');", true);
            }
        }
    }
}