using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Paginas
{
    public partial class AltaContactoPaciente : System.Web.UI.Page
    {

        vistaPaciente vPaciente = new vistaPaciente();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        EntPacientes _Contacto = new EntPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaControles();
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int idestado = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    CargaCiudades(idestado);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idestado + ");", true);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + ddFormatoDir.SelectedValue + "');", true);
                    if (ViewState["NombrePaciente"] != null || ViewState["NombrePaciente"].ToString()!="")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MostrarNombrePaciente('" + ViewState["NombrePaciente"].ToString() + "');", true);
                    }
                }
            }          

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddFormatoDir")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var formato = Request.Form["__EVENTARGUMENT"].ToString();                    
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + formato + "');", true);
                    if (ViewState["NombrePaciente"] != null || ViewState["NombrePaciente"].ToString() != "")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MostrarNombrePaciente('" + ViewState["NombrePaciente"].ToString() + "');", true);
                    }
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtClavePaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    decimal cvePaciente = Convert.ToDecimal(txtClavePaciente.Text == "" ? "0" : txtClavePaciente.Text);
                    if (vPaciente.ExistePaciente(cvePaciente))
                    {
                        var paciente = vPaciente.RegresaDetallePaciente(cvePaciente);
                        if (paciente.IdPaciente > 0)
                        {
                            string nombrePaciente = paciente.Nombre.ToUpper() + " " + paciente.Ape_Pat.ToUpper() + " " + paciente.Ape_Mat.ToUpper();
                            ViewState["NombrePaciente"] = nombrePaciente;
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MostrarNombrePaciente('" + nombrePaciente + "');", true);
                        }
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjOtro('No existe el Paciente');", true);
                }
            }
            txtClavePaciente.Attributes.Add("onkeypress", "return isNumberKey(event);");
        }

        private void CargaCiudades(int idEstado)
        {
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idEstado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();

        }

        private void CargaControles()
        {            
            CargaEstados();            
        }

        private void CargaEstados()
        {

            ddEstados.DataSource = vcatalogos.RegresaEstados();
            ddEstados.DataTextField = "DesEstado";
            ddEstados.DataValueField = "Id";
            ddEstados.DataBind();

            ddEstados.Items.Insert(0, "SELECCIONA ESTADO");
            ddEstados.SelectedIndex = 0;

            ddCiudad.Items.Insert(0, "SELECCIONA CIUDAD");
            ddCiudad.SelectedIndex = 0;

        }

        private void InformacionContacto()
        {
            _Contacto = new EntPacientes();
            _Contacto.Nombre = txtNombres.Text;
            _Contacto.Ape_Pat = txtApePat.Text;
            _Contacto.Ape_Mat = txtApeMat.Text;
            //_Contacto.NSS = txtNSS.Text;
           // _Contacto.Latitud = Convert.ToSingle(txtLatitud.Text);
            //_Contacto.Longitud = Convert.ToSingle(txtLongitud.Text);
            _Contacto.DiaVisita = 0; //modificacion por solicitud de usuario
            _Contacto.FrecVisita = string.Empty; //modificacion por solicitud de usuario
            _Contacto.IdEstado = Convert.ToInt32(ddEstados.SelectedValue);
            _Contacto.IdCiudad = Convert.ToInt32(ddCiudad.SelectedValue);
            _Contacto.Colonia = txtColonia.Text;
            _Contacto.Calle = txtCalle.Text;
            _Contacto.NumExt = txtNumExt.Text;
            _Contacto.NumInt = txtNumInt.Text;
            _Contacto.TelFijo = txtTelFijo.Text;
            _Contacto.Tel_Cel = txtTelCel.Text;
            _Contacto.CP = txtCP.Text;
            _Contacto.CvePaciente = Convert.ToDecimal(txtClavePaciente.Text);
            //_Contacto.Institucion = ddInstitucion.SelectedValue.ToString();
            _Contacto.SuperManzana = txtSuperManzana.Text;
            _Contacto.Manzana = txtManzana.Text;
            _Contacto.Lote = txtLote.Text;
            //_Contacto.Institucion = ddInstitucion.SelectedValue.ToString();
        }

        protected void btnNuevoContacto_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionContacto();
                if (!vPaciente.ExisteContactoPorPaciente(Convert.ToDecimal(txtClavePaciente.Text == "" ? "0" : txtClavePaciente.Text)))
                {
                    if (vPaciente.InsertaNuevoContacto(_Contacto) == 0)
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "contacto", "javascript:MsjSuccess('Contacto Agregado Existosamente');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "contacto", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }
    }
}