using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;
namespace Ext.Web.Paginas
{
    public partial class ModificarPacientes : System.Web.UI.Page
    {


        Vistas.vistaPaciente vpaciente = new Vistas.vistaPaciente();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        EntPacientes _epaciente = new EntPacientes();
        protected int _idPaciente=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargaInformacionGrid();
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstados")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int idestado = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idestado + ");", true);
                    CargaCiudades(0,idestado);
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtClavePaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    decimal numpaciente = Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"].ToString());
                    var datosPac = vpaciente.RegresaDetallePaciente(numpaciente);
                    if (datosPac.Nombre != string.Empty)
                    {
                        CargaInformacionPaciente(datosPac);
                        ViewState["IdPaciente"] = datosPac.IdPaciente;
                    }
                    else
                    {//MsjPacienteNoEncontrado 
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "elimina", "javascript:MsjPacienteNoEncontrado("+txtClavePaciente.Text+");", true);
                    }
                }
            }

            txtClavePaciente.Attributes.Add("onkeypress", "return isNumberKey(event);");
        }

        protected void gvModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvModificar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvModificar.EditIndex = e.NewEditIndex;
            Label lblIdEstado = (Label)gvModificar.Rows[e.NewEditIndex].FindControl("lblIdEstado");          
            gvModificar.DataSource = vpaciente.RegresaTodosPacientes(true);
            gvModificar.DataBind();

            DropDownList ddestados = (DropDownList)gvModificar.Rows[e.NewEditIndex].FindControl("ddEstado");
            CargaControlEstadosGrid(ddestados, Convert.ToInt32(lblIdEstado.Text));
        }

        protected void gvModificar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            int idPaciente = Convert.ToInt32(gvModificar.DataKeys[e.RowIndex].Values["IdPaciente"].ToString());            
            TextBox txtCvePaciente = (TextBox)gvModificar.Rows[e.RowIndex].FindControl("txtClavepaciente");
            Label lblIdEstado = (Label)gvModificar.Rows[e.RowIndex].FindControl("lblIdEstado");
            DropDownList ddestado = (DropDownList)gvModificar.Rows[e.RowIndex].FindControl("ddEstado");
            _epaciente.IdEstado = Convert.ToInt32(ddestado.SelectedValue);
            _epaciente.CvePaciente = Convert.ToDecimal(txtCvePaciente.Text == "" ? "0" : txtCvePaciente.Text);
            _epaciente.IdPaciente = idPaciente;
            
            vpaciente.ActualizarPaciente(_epaciente);

            gvModificar.EditIndex = -1;
            CargaInformacionGrid();
        }        

        private void  CargaInformacionGrid()
        {
            gvModificar.DataSource = vpaciente.RegresaTodosPacientes(true);
            gvModificar.DataBind();
        }

        protected void gvModificar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvModificar.EditIndex = -1;
            CargaInformacionGrid();
        }

        protected void gvModificar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "")
            { 
            
            }
        }

        protected void gvModificar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            int idPaciente = Convert.ToInt32(gvModificar.DataKeys[e.RowIndex].Values["IdPaciente"].ToString());
            Label txtCvePaciente = (Label)gvModificar.Rows[e.RowIndex].FindControl("lblClavePaciente");
            decimal clavepaciente=Convert.ToDecimal(txtClavePaciente.Text);
            if (vpaciente.EstatusEliminadoPaciente(idPaciente, clavepaciente))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "elimina", "javascript:alert('Dado de baja satisfactoriamente');", true);
                CargaInformacionGrid();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "elimina", "javascript:alert('Proceso no exisoso');", true);
            }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "elimina", "javascript:alert('"+ex.Message+"');", true);   
            }
        }

        private void CargaControlEstadosGrid(DropDownList pddestados,int idEstado)
        {
            pddestados.DataSource = vcatalogos.RegresaEstados();
            pddestados.DataTextField = "DesEstado";
            pddestados.DataValueField = "Id";
            pddestados.DataBind();
            pddestados.SelectedIndex = idEstado;
        }

        protected void gvModificar_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvModificar.Rows[e.NewSelectedIndex];
            int idPaciente = Convert.ToInt32(gvModificar.DataKeys[e.NewSelectedIndex].Values["IdPaciente"].ToString());
            ViewState["IdPaciente"] = idPaciente;
            List<EntPacientes> lista = new List<EntPacientes>();
            lista = vpaciente.RegresaPaciente(idPaciente);
            if (lista.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:OcultarGrid();", true);
                CargaInformacionPaciente(lista[0]);
            }
        }
        
        private void CargaInformacionPaciente(EntPacientes pPaciente)
        {
            //txtClavePaciente.Text = pPaciente.CvePaciente.ToString();
            txtNombres.Text = pPaciente.Nombre;
            txtApePat.Text = pPaciente.Ape_Pat;
            txtApeMat.Text = pPaciente.Ape_Mat;
            txtNSS.Text = pPaciente.NSS;
            txtLatitud.Text = pPaciente.Latitud.ToString("##.#######");
            txtLongitud.Text = pPaciente.Longitud.ToString("###.#######");
            int idestado = pPaciente.IdEstado;
            int idciudad = pPaciente.IdCiudad;
            CargaEstados(idestado);
            CargaCiudades(idciudad, idestado);
            txtColonia.Text = pPaciente.Colonia;
            txtCP.Text = pPaciente.CP;
            txtNumExt.Text = pPaciente.NumExt;
            txtNumInt.Text = pPaciente.NumInt;
            txtTelFijo.Text = pPaciente.TelFijo;
            txtTelCel.Text = pPaciente.Tel_Cel;
            txtCalle.Text = pPaciente.Calle;
        }

        private void InformacionActualizadaPaciente()
        {
            _epaciente = new EntPacientes();
            _epaciente.IdPaciente = Convert.ToInt32((ViewState["IdPaciente"].ToString()==""?"0":ViewState["IdPaciente"].ToString()));
            _epaciente.CvePaciente = Convert.ToDecimal(txtClavePaciente.Text);
            _epaciente.Nombre = txtNombres.Text;
            _epaciente.Ape_Pat = txtApePat.Text;
            _epaciente.Ape_Mat = txtApeMat.Text;
            _epaciente.NSS= txtNSS.Text  ;
            _epaciente.Latitud= Convert.ToSingle(txtLatitud.Text );
            _epaciente.Longitud= Convert.ToSingle(txtLongitud.Text);
            _epaciente.IdEstado = Convert.ToInt32(ddEstados.SelectedValue);
            _epaciente.IdCiudad = Convert.ToInt32(ddCiudad.SelectedValue);
            _epaciente.Colonia = txtColonia.Text;
            _epaciente.CP = txtCP.Text;
            _epaciente.NumExt = txtNumExt.Text;
            _epaciente.NumInt= txtNumInt.Text;
            _epaciente.TelFijo = txtTelFijo.Text;
            _epaciente.Tel_Cel = txtTelCel.Text;
            _epaciente.Calle = txtCalle.Text;
        }

        private void CargaEstados(int index)
        {
            ddEstados.DataSource = vcatalogos.RegresaEstados();
            ddEstados.DataTextField = "DesEstado";
            ddEstados.DataValueField = "Id";
            ddEstados.DataBind();
            ddEstados.SelectedIndex = index - 1;
            
        }

        private void CargaCiudades(int idx,int idestado)
        {
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idestado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();

            ddCiudad.SelectedIndex = idx - 1;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            { 
                InformacionActualizadaPaciente();
                if (vpaciente.ActualizarPaciente(_epaciente))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "actualiza", "javascript:alert('Registro Actualizado');", true);
                    CargaInformacionGrid();//limpiarControles
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "limpiar", "javascript:limpiarControles();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "noactualiza", "javascript:alert('No se pudo actualizar el registro');", true);   
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "excepcion", "javascript:alert('" + ex.Message + "');", true);   
            }
        }
    }
}