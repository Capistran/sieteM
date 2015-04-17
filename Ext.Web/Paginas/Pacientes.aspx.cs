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
    public partial class Pacientes : System.Web.UI.Page
    {
        vistaCatalogos vcatalogos = new vistaCatalogos();
        vistaPaciente vPaciente = new vistaPaciente();
        EntPacientes _paciente = new EntPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaControles();                
                btnNuevoPaciente.Attributes.Add("onclick", "ValidaDatos();");
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int idestado = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    CargaCiudades(idestado);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idestado + ");", true);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('" + ddFormatoDir.SelectedValue + "');", true);
                }
            }
            //

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddFormatoDir")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    var formato = Request.Form["__EVENTARGUMENT"].ToString();
                    //CargaCiudades(idestado);
                    //FormatoDireccion
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:FormatoDireccion('"+formato+"');", true);
                }
            }

            txtClavePaciente.Attributes.Add("onkeypress", "return isNumberKey(event);");
            
        }

        private void CargaControles()
        {
            //iniciaGridPacientes();
            //cargaGridPacientes();
            CargaEstados();
            CargaDias();
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

        private void CargaCiudades(int idEstado)
        {            
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idEstado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();
            
        }

        private void CargaDias()
        {
            //dd_diasvisita.DataSource = vcatalogos.RegresaDias();
            //dd_diasvisita.DataTextField = "DiaSemana";
            //dd_diasvisita.DataValueField = "Id";
            //dd_diasvisita.DataBind();
        }

        protected void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionPaciente();
                if (!vPaciente.ExistePaciente(_paciente.CvePaciente))
                {

                    if (vPaciente.AgregaNuevoPaciente(_paciente) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:alert('Agregado satisfactoriamente');", true);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:LimpiarControles();", true);                        
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:alert('No se Agrego el Paciente');", true);
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:alert('El paciente ya existe');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ERROR", "javascript:alert('"+ex.Message+"');", true);
            }
            
        }

        private void InformacionPaciente()
        {
            _paciente.Nombre = txtNombres.Text;
            _paciente.Ape_Pat = txtApePat.Text;
            _paciente.Ape_Mat = txtApeMat.Text;
            _paciente.NSS = txtNSS.Text;
            _paciente.Latitud =Convert.ToSingle(txtLatitud.Text);
            _paciente.Longitud = Convert.ToSingle(txtLongitud.Text);
            _paciente.DiaVisita = 0; //modificacion por solicitud de usuario
            _paciente.FrecVisita = string.Empty; //modificacion por solicitud de usuario
            _paciente.IdEstado =Convert.ToInt32(ddEstados.SelectedValue);
            _paciente.IdCiudad =Convert.ToInt32(ddCiudad.SelectedValue);            
            _paciente.Colonia = txtColonia.Text;
            _paciente.Calle = txtCalle.Text;
            _paciente.NumExt = txtNumExt.Text;
            _paciente.NumInt = txtNumInt.Text;
            _paciente.TelFijo = txtTelFijo.Text;
            _paciente.Tel_Cel = txtTelCel.Text;
            _paciente.CP = txtCP.Text;
            _paciente.CvePaciente = Convert.ToDecimal(txtClavePaciente.Text);
            _paciente.Institucion = ddInstitucion.SelectedValue.ToString();
            _paciente.SuperManzana = txtSuperManzana.Text;
            _paciente.Manzana = txtManzana.Text;
            _paciente.Lote = txtLote.Text;
            _paciente.Institucion = ddInstitucion.SelectedValue.ToString();
             
        }

        private void iniciaGridPacientes()
        {
            BoundField bfield = new BoundField();

            bfield.DataField = "CvePaciente";
            bfield.HeaderText = "CLAVE PACIENTE";
            gvPacientes.Columns.Add(bfield);


            bfield = new BoundField();
            bfield.DataField = "Nombre";
            bfield.HeaderText = "NOMBRE";
            gvPacientes.Columns.Add(bfield);
           

            bfield = new BoundField();
            bfield.DataField = "NSS";
            bfield.HeaderText = "NSS";
            gvPacientes.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Latitud";
            bfield.HeaderText = "LATITUD";
            gvPacientes.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.DataField = "Longitud";
            bfield.HeaderText = "LONGITUD";
            gvPacientes.Columns.Add(bfield);

        }

        private void cargaGridPacientes()
        {
            gvPacientes.DataSource = null;
            gvPacientes.DataSource = vPaciente.RegresaTodosPacientes(false);
            gvPacientes.DataBind();
        }
    }
}