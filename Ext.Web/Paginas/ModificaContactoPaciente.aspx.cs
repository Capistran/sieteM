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
    public partial class ModificaContactoPaciente : System.Web.UI.Page
    {

        vistaPaciente vPaciente = new vistaPaciente();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        EntPacientes _contacto = new EntPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaEstados();
            }
            buscarContactoPaciente();
        }

        private void buscarContactoPaciente()
        {
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
                            if (vPaciente.ExisteContactoPorPaciente(cvePaciente))
                            {
                                var contacto = vPaciente.RegresaInfoContacto(cvePaciente, paciente.IdPaciente);
                                if (contacto.IdContacto > 0)
                                {
                                    ViewState["IdPaciente"] = contacto.IdPaciente;
                                    InformacionContacto(contacto);
                                    string nombrePaciente = paciente.Nombre.ToUpper() + " " + paciente.Ape_Pat.ToUpper() + " " + paciente.Ape_Mat.ToUpper();
                                    ViewState["NombrePaciente"] = nombrePaciente;
                                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MostrarNombrePaciente('" + nombrePaciente + "');", true);
                                }
                                
                            }
                            else
                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjOtro('El paciente no tiene agregado un contacto');", true);
                        }
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjOtro('No existe el Paciente');", true);
                }
            }
        }

        private void CargaEstados()
        {
            ddEstados.DataSource = vcatalogos.RegresaEstados();
            ddEstados.DataTextField = "DesEstado";
            ddEstados.DataValueField = "Id";
            ddEstados.DataBind();            
        }

        private void CargaCiudades(int idEstado, int idCiudad)
        {
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idEstado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();
            ddCiudad.SelectedIndex = idCiudad;
        }

        private void InformacionContacto(EntPacientes contacto)
        {
            txtNombres.Text = contacto.Nombre;
            txtApeMat.Text = contacto.Ape_Mat;
            txtApePat.Text = contacto.Ape_Pat;
            txtCalle.Text = contacto.Calle;
            txtColonia.Text = contacto.Colonia;
            txtCP.Text = contacto.CP;
            txtManzana.Text = contacto.Manzana;
            txtSuperManzana.Text = contacto.SuperManzana;
            txtLote.Text = contacto.Lote;
            txtNumExt.Text = contacto.NumExt;
            txtNumInt.Text = contacto.NumInt;
            txtTelCel.Text = contacto.Tel_Cel;
            txtTelFijo.Text = contacto.TelFijo;
            if (ddEstados.Items.Count > 0)
            {
                ddEstados.SelectedIndex = contacto.IdEstado;
                CargaCiudades(contacto.IdEstado, contacto.IdCiudad);
            }
            
            
        }

        private void InformacionContactoNuevo()
        {
            try
            {
                _contacto = new EntPacientes();
                if (ViewState["IdPaciente"] != null || ViewState["IdPaciente"].ToString().Length > 0)
                {
                    _contacto.IdPaciente = Convert.ToInt32(ViewState["IdPaciente"].ToString());
                }
                _contacto.Nombre = txtNombres.Text;
                _contacto.Ape_Mat = txtApeMat.Text;
                _contacto.Ape_Pat = txtApePat.Text;
                _contacto.Calle = txtCalle.Text;
                _contacto.Colonia = txtColonia.Text;
                _contacto.CP = txtCP.Text;
                _contacto.Manzana = txtManzana.Text;
                _contacto.SuperManzana = txtSuperManzana.Text;
                _contacto.Lote = txtLote.Text;
                _contacto.NumExt = txtNumExt.Text;
                _contacto.NumInt = txtNumInt.Text;
                _contacto.Tel_Cel = txtTelCel.Text;
                _contacto.TelFijo = txtTelFijo.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionContactoNuevo();
                if (vPaciente.ActualizaContacto(_contacto) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjSuccess('Contacto Modificado Existosamente');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "nuevo", "javascript:MsjError('"+ex.Message+"');", true);
            }

        }
    }
}