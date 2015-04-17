using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;

namespace Ext.Web.Paginas.Choferes
{
    public partial class ModificarOperador : System.Web.UI.Page
    {

        vistaChofer vOperador = new vistaChofer();
        vistaCatalogos vcatalogos = new vistaCatalogos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCombos();                
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumEmpleado")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    if(Request.Form["__EVENTARGUMENT"].ToString()==txtNumEmpleado.Text)
                    {
                        int idtransp = 0;
                        try
                        {
                            idtransp = (Session["UsrInfo"] as EntUsuarios).IdTransp;
                            if (idtransp != 0&&txtNumEmpleado.Text!="")
                            {
                                if (vOperador.ExisteOperador(txtNumEmpleado.Text, idtransp))
                                {
                                    var Operador = vOperador.BuscaInformacionOperador(txtNumEmpleado.Text);
                                    MostrarInformacionOperador(Operador);
                                }
                                else
                                { //OperadorNoEncontrado
                                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "actualizado", "javascript:OperadorNoEncontrado("+txtNumEmpleado.Text+");", true);
                                }
                            }
                        }
                        catch
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "actualizado", "javascript:alert('Error al cargar un parametro : idTransp');", true);
                        }
                    }
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddEstado")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int idestado = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "dele", "javascript:Delegacion(" + idestado + ");", true);
                    CargaCiudades(idestado,0);
                }
            }

        }


        private void CargaCombos()
        {
            //CargaEstados(0);
            
        }
        private void CargaEstados(int idEstado)
        {
            ddEstado.DataSource = vcatalogos.RegresaEstados();
            ddEstado.DataTextField = "DesEstado";
            ddEstado.DataValueField = "Id";
            ddEstado.DataBind();

            ddEstado.Items.Insert(0, "SELECCIONA ESTADO");
            ddEstado.SelectedIndex = idEstado-1;

            ddCiudad.Items.Insert(0, "SELECCIONA CIUDAD");
            
        }

        private void CargaCiudades(int idEstado,int idCiudad)
        {
            ddCiudad.DataSource = vcatalogos.RegresaCiudadesxEstado(idEstado);
            ddCiudad.DataTextField = "DescCiudad";
            ddCiudad.DataValueField = "IdCiudad";
            ddCiudad.DataBind();
            if(idCiudad!=0)
                ddCiudad.SelectedIndex = idCiudad-1;
            else
                ddCiudad.SelectedIndex = idCiudad ;
        }


        private void MostrarInformacionOperador(EntChofer operador)
        {            
             txtNombre.Text=operador.NombreChofer ;
             txtApePat.Text=operador.ApePat;
             txtApeMat.Text=operador.ApeMat;
             txtRFC.Text=operador.RFC;
             txtINE.Text=operador.Cve_INE;            
             txtColonia.Text=operador.Colonia;
             txtCP.Text=operador.CP;
             txtCalle.Text=operador.Calle;
             txtNumExt.Text=operador.NumExt ;
             txtNumInt.Text=operador.NumInt;
             txtTelFijo.Text=operador.TelFijo;
             txtTel_cel.Text=operador.Tel_Cel;
             CargaEstados(operador.IdEstado);
             ddEstado.SelectedIndex = operador.IdEstado ;
             CargaCiudades(ddEstado.SelectedIndex,0);
             ddCiudad.SelectedIndex = operador.IdCiudad -1;
             txtLicencia.Text = operador.LicenciaManejo;
             txtVigenciaLic.Text = operador.FechaVigenciaLic.ToShortDateString();
             if (operador.Auxiliar == "N")
                 ddTipoOperador.SelectedIndex = 1;
             else
                 ddTipoOperador.SelectedIndex = 0;
        }
        EntChofer _entChofer = new EntChofer();
        private void NuevaInformacionOperador()
        {
            _entChofer.NombreChofer = txtNombre.Text;
            _entChofer.ApePat = txtApePat.Text;
            _entChofer.ApeMat = txtApeMat.Text;
            _entChofer.RFC = txtRFC.Text;
            _entChofer.Cve_INE = txtINE.Text;
            _entChofer.IdEstado = Convert.ToInt32(ddEstado.SelectedValue);
            _entChofer.IdCiudad = Convert.ToInt32(ddCiudad.SelectedValue);
            _entChofer.Colonia = txtColonia.Text;
            _entChofer.CP = txtCP.Text;
            _entChofer.Calle = txtCalle.Text;
            _entChofer.NumExt = txtNumExt.Text;
            _entChofer.NumInt = txtNumInt.Text;
            _entChofer.TelCasa = txtTelFijo.Text;
            _entChofer.Tel_Cel = txtTel_cel.Text;
            _entChofer.IdTransp = (Session["UsrInfo"] as EntUsuarios).IdTransp; ;
            _entChofer.NumEmpleado = txtNumEmpleado.Text;
            _entChofer.LicenciaManejo = txtLicencia.Text;
            _entChofer.FechaVigenciaLic =Convert.ToDateTime(txtVigenciaLic.Text);
            if (ddTipoOperador.SelectedIndex == 0)
                _entChofer.Auxiliar = "S";
            else
                _entChofer.Auxiliar = "N";
        
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NuevaInformacionOperador();
                if (vOperador.ActualizarOperador(_entChofer)==0)
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "actualiza", "javascript:alert('Operador Actualizado');");
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "actualizado", "javascript:alert('Operador Actualizado');", true);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "limpiarControles", "javascript:LimpiarControles();", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "error", "javascript:alert('"+ex.Message+"');", true);
            }

        }

    }
}