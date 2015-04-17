using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Externo.Procesamiento.Procesos;
using Externo.Procesamiento.Entidades;
using Externo.Utilerias;
using Ext.Web.Vistas;
using AjaxControlToolkit;

namespace Ext.Web.Paginas.Choferes
{
    public partial class Choferes : System.Web.UI.Page
    {

        vistaChofer vChofer = new vistaChofer();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        vistaUsuarios vUsuarios = new vistaUsuarios();
        //EntCamion _entcamion = null;
        EntChofer _entchofer = null;
        EntUsuarios _entUsuario = null;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaControles();
                //CargaListaChoferTransportista();
            }


            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$chkPassword")
            {
                if (chkPassword.Checked)
                {
                    lblpassauto.Text = Membership.GeneratePassword(8, 1);
                    txtContraseña.Visible = false;
                }
                else
                {
                    lblpassauto.Text = "";
                    txtContraseña.Visible = true;
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstado")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int idestado = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idestado + ");", true);
                    CargaCiudades(idestado);
                }
            }

            //if (Request.Form["__EVENTTARGET"] == chkTipoOperador.ClientID)
            //{
            //    if (Request.Form["__EVENTARGUMENT"] != null)
            //    {
                    
            //    }
            //}
        }


        private void CargaControles()
        {
            CargaEstados();
        }

        //private void CargaListaChoferTransportista()
        //{ 
        //    try
        //    {
        //    int idTransp=(Session["UsrInfo"] as EntUsuarios).IdTransp;
        //    ddChoferes.DataSource = vChofer.RegresaChoferTransporte(idTransp);
        //    ddChoferes.DataTextField = "NombreChofer";
        //    ddChoferes.DataValueField = "IdUsuario";
        //    ddChoferes.DataBind();
        //    }
        //    catch(Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ERROR", "javascript:alert('" + ex.Message + "')", true);
        //    }
        //}

        //private void InformacionTransporte()
        //{
        //    _entcamion = new EntCamion();
        //    _entcamion.IdTransp=(Session["UsrInfo"] as EntUsuarios).IdTransp;
        //    _entcamion.IdUsuario = Convert.ToInt32(ddChoferes.SelectedValue);
        //    _entcamion.Placas = txtPlacas.Text;
        //    _entcamion.NumEconomico = txtNumEconomico.Text;
        //    _entcamion.Marca = txtMarca.Text;
        //    _entcamion.Modelo = txtModelo.Text;
        //    _entcamion.CapacidadCarga = Convert.ToDecimal(txtCapacidad.Text);
        //    _entcamion.NoPoliza = txtPoliza.Text;
        //    _entcamion.CompañiaSeguro = txtSeguro.Text;
        //    _entcamion.VigenciaPoliza = Convert.ToDateTime(txtVigenciaPoliza.Text);

        //}

        private void InformacionUsuarioConsulta()
        {

            _entUsuario = new EntUsuarios();
            _entUsuario.IdTransp = (Session["UsrInfo"] as EntUsuarios).IdTransp;
            _entUsuario.Nombre = txtNombre.Text;
            _entUsuario.ApePat = txtApePat.Text;
            _entUsuario.ApeMat = txtApeMat.Text;
            _entUsuario.RFC = txtRFC.Text;
            _entUsuario.Cve_INE = txtINE.Text;
            _entUsuario.Estado = Convert.ToInt32(ddEstado.SelectedValue);
            _entUsuario.Ciudad = Convert.ToInt32(ddCiudad.SelectedValue);
            _entUsuario.Colonia = txtColonia.Text;
            _entUsuario.CP = txtCP.Text;
            _entUsuario.Calle = txtCalle.Text;
            _entUsuario.NumExt = txtNumExt.Text;
            _entUsuario.NumInt = txtNumInt.Text;
            _entUsuario.TelCasa = txtTelFijo.Text;
            _entUsuario.Tel_cel = txtTel_cel.Text;
            _entUsuario.Email = txtCorreo.Text;            
            
            if (chkPassword.Checked)
                _entUsuario.Contraseña = lblpassauto.Text;
            else
                _entUsuario.Contraseña = txtContraseña.Text;
        }

        private void InformacionChofer(int pIdUsuario)
        {
            _entchofer= new EntChofer();
            try
            {
            _entchofer.IdUsuario=pIdUsuario;
            int idTransp=(Session["UsrInfo"] as EntUsuarios).IdTransp;
            _entchofer.IdTransp=idTransp;
            _entchofer.LicenciaManejo=txtLicencia.Text;
            _entchofer.NumEmpleado = txtNumEmpleado.Text;
            if (txtVigenciaLic.Text == string.Empty)
                txtVigenciaLic.Text = (new DateTime(2000, 1, 1)).ToShortDateString();
            _entchofer.FechaVigenciaLic = Convert.ToDateTime(txtVigenciaLic.Text);
            if(ddTipoOperador.SelectedIndex==0)
                _entchofer.Auxiliar = "S";
            else
                _entchofer.Auxiliar = "N";
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ERROR", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }

        private void CargaEstados()
        {
            ddEstado.DataSource = vcatalogos.RegresaEstados();
            ddEstado.DataTextField = "DesEstado";
            ddEstado.DataValueField = "Id";
            ddEstado.DataBind();

            ddEstado.Items.Insert(0, "SELECCIONA ESTADO");
            ddEstado.SelectedIndex = 0;

            ddCiudad.Items.Insert(0, "SELECCIONA CIUDAD");
            ddCiudad.SelectedIndex = 0;
        }

        private void CargaCiudades(int idEstado)
        {
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idEstado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();
        }

        /// <summary>
        /// Alta de Chofer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionUsuarioConsulta();
                if (vUsuarios.AgregaNuevoUsuarioConsulta(_entUsuario) == 0)
                {
                    InformacionChofer(vUsuarios.RegresaUltimoUsuarioConsulta());
                    if (vChofer.AgregarChofer(_entchofer) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "notifica", "javascript:MsjAgregado('" + _entchofer.IdUsuario.ToString() + "');", true);
                    }
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ERROR", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }

       
        

    }
}