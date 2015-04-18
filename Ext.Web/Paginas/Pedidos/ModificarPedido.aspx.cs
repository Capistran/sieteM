using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;
using Externo.Utilerias;

namespace Ext.Web.Paginas.Pedidos
{
    public partial class ModificarPedido : System.Web.UI.Page
    {

        vistaCatalogos vCatalogos = new vistaCatalogos();
        vistaPedido vPedidos = new vistaPedido();
        Utils utilierias = new Utils();
        vistaPaciente vPaciente = new vistaPaciente();
        vistaPedido vPedido = new vistaPedido();
        EntProducto _entProducto = new EntProducto();
        List<EntProducto> _listaProductos = new List<EntProducto>();
        EntPedido _entPedido = new EntPedido();
        vistaRutas vRutas = new vistaRutas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                
            }

            if (Request.Form["__EVENTTARGET"] == txtNumeroPaciente.ClientID)
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:OcultaRuta(1);", true);
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];                   
                    CargaGridPedido();
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumeroPaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:OcultaRuta(1);", true);                    
                    infoPaciente();
                    infoPedido();
                    CargaGridPedido();
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddTratamiento")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["ddval"] = Request.Form["__EVENTARGUMENT"];
                    
                    if (ViewState["ddval"].ToString() == ViewState["idTratamiento"].ToString())
                    {
                        gvActualiza.Visible = false;
                        gvDetallePedido.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:OcultaRuta(1);", true);
                        if (gvDetallePedido.Rows.Count > 0)
                        {
                            cargaGridPedidoCambio(ViewState["ddval"].ToString());
                        }
                    }
                    else                     
                    {
                        gvActualiza.Visible = true;
                        gvDetallePedido.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:OcultaRuta(2);", true);                        
                        CargaControles();
                        cargaGridPedidoCambio(ViewState["ddval"].ToString());
                    }                    
                }
            }

        }

        private void infoPedido()
        {
            try
            {
               // var infoPed = vPedido.ObtienePedidoPacienteClave(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"].ToString());
                var infoPed = vPedido.ObtienePedidoPacienteClave(ViewState["cvePaciente"].ToString() );
                if (infoPed.IdPedido > 0)
                {
                    ViewState["IdPedido"] = infoPed.IdPedido;
                    ViewState["IdRutaPedido"] = infoPed.Eruta.IdRuta;
                    ViewState["IdPaciente"] = infoPed.EPaciente.IdPaciente;

                    ddMes.DataSource = null;
                    ddMes.Items.Add(infoPed.MesPedido);
                    ddMes.DataBind();
                    ddMes.SelectedIndex = utilierias.RegresaNumeroMes(infoPed.MesPedido) - 1;
                    ddMes.Enabled = false;
                    cargaTratamiento(Convert.ToInt32(ViewState["idTratamiento"]));
                    txtFechaEntrega.Text = infoPed.FechaEntrega.ToShortDateString();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "existePedido", "javascript:MsjOtro('No se encontro información');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "errorInfoPedido", "javascript:MsjError('"+ex.Message+"');", true);
                ddMes.Enabled = true;
            }
        }

        void CargaControles()
        {
            //se carga por variable de Session
            cargaRutasporTransportista((Session["UsrInfo"] as EntUsuarios).IdTransp);
        }

        void cargaRutasporTransportista(int pIdTransportista)
        {            
            ddRuta.DataSource = vRutas.vistaRegresaRutasporTransportista(pIdTransportista);
            ddRuta.DataTextField = "CveRuta";
            ddRuta.DataValueField = "IdRuta";
            ddRuta.DataBind();
            ViewState["idRuta"] = ddRuta.SelectedValue;
        }
        private void infoPaciente()
        { 
          decimal cvePac = Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"].ToString());
          var paciente=  vPaciente.RegresaPacientePorClave(cvePac);
          ViewState["idTratamiento"] = paciente.IdTratamiento;
          //cargaTratamiento(paciente.IdTratamiento);
        }        

        private void cargaGridPedidoCambio(string tipoAplicacion)
        {            
            switch (tipoAplicacion)
            {
                case "1":
                    var listaPedidoManual = vPedido.RegresaListaPedidoManual();
                    if (listaPedidoManual.Count > 0)
                    {
                        gvActualiza.DataSource = listaPedidoManual;
                        gvActualiza.DataBind();
                    }
                    break;
                case "2":
                    var listaPedidoMaquina = vPedido.RegresaListaPedidoMaquina();
                    if (listaPedidoMaquina.Count > 0)
                    {
                        gvActualiza.DataSource = listaPedidoMaquina;
                        gvActualiza.DataBind();
                    }
                    break;
            }
        }

        private void CargaGridPedido()
        {
            try
            {
                int rutapedido=-1;
                decimal cvePac = Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"].ToString());
                int idtrat = Convert.ToInt32(ViewState["idTratamiento"].ToString() == "" ? "0" : ViewState["idTratamiento"].ToString());
                //var pedidos = vPedidos.RegresaPedidoTratamiento(cvePac, idtrat);
                var pedido = vPedido.ObtienePedidoPacienteClave(cvePac.ToString());
                if(ViewState["IdRutaPedido"]!=null)
                     rutapedido=Convert.ToInt32(ViewState["IdRutaPedido"].ToString()==""?"0":ViewState["IdRutaPedido"].ToString());
                if (rutapedido > 0)
                {
                    var pedidos = vPedidos.RegresaPedidoTratamientoMes(cvePac, idtrat, ddMes.SelectedValue.ToString(), rutapedido);
                    // ddMes.SelectedIndex = utilierias.RegresaNumeroMes(pedidos[0].MesPedido);
                    gvDetallePedido.DataSource = pedidos;
                    gvDetallePedido.DataBind();

                    if (pedidos.Count > 0)
                    {
                        ViewState["IdPedidoAnterior"] = pedidos[0].IdPedido;

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "errorCargaGridPedido", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }

        private void cargaTratamiento(int idx)
        {
            ddTratamiento.DataSource = vCatalogos.RegresaTratamientos();
            ddTratamiento.DataTextField = "DescTratamiento";
            ddTratamiento.DataValueField = "IdTratamiento";
            ddTratamiento.DataBind();
            ddTratamiento.SelectedIndex = idx-1;
        }
        
        private void InformacionDetalleProducto()
        {
            _entProducto = new EntProducto();
            _listaProductos = new List<EntProducto>();
            
            for (int i = 0; i < gvDetallePedido.Rows.Count; i++)
            {
                
                Label lblIdProducto = (Label)gvDetallePedido.Rows[i].FindControl("lblId");
                int idProd = Convert.ToInt32(lblIdProducto.Text);
                TextBox Nocajas = (TextBox)gvDetallePedido.Rows[i].FindControl("txtCantidadCajas");
                int CantidadCajas = Convert.ToInt32(Nocajas.Text == "" ? "0" : Nocajas.Text);

                TextBox paquetesCajas = (TextBox)gvDetallePedido.Rows[i].FindControl("txtCantidadPaquetes");
                int CantidadPaquetes = Convert.ToInt32(paquetesCajas.Text == "" ? "0" : paquetesCajas.Text);

                TextBox piezaPaquete = (TextBox)gvDetallePedido.Rows[i].FindControl("txtCantidadPieza");
                int CantidadPieza = Convert.ToInt32(piezaPaquete.Text == "" ? "0" : piezaPaquete.Text);


                TextBox lote = (TextBox)gvDetallePedido.Rows[i].FindControl("txtLote");
                string strlote = lote.Text;

                CheckBox chActivo = (CheckBox)gvDetallePedido.Rows[i].FindControl("chkHabilitado");
                if (chActivo.Checked)
                    _entProducto.HabPedido = true;
                else
                    _entProducto.HabPedido = false;

                _entProducto.IdProducto = idProd;
                _entProducto.PaqCaja = CantidadPaquetes;
                _entProducto.PiezaPaq = CantidadPieza;
                _entProducto.NumCajas = CantidadCajas;
                _entProducto.Lote = strlote;
                _listaProductos.Add(_entProducto);
                _entProducto = new EntProducto();
            }
        }


        private void InformacionDetalleProductoActualiza()
        {
            _entProducto = new EntProducto();
            _listaProductos = new List<EntProducto>();

            for (int i = 0; i < gvActualiza.Rows.Count; i++)
            {

                Label lblIdProducto = (Label)gvActualiza.Rows[i].FindControl("lblId");
                int idProd = Convert.ToInt32(lblIdProducto.Text);
                TextBox Nocajas = (TextBox)gvActualiza.Rows[i].FindControl("txtCantidadCajas");
                int CantidadCajas = Convert.ToInt32(Nocajas.Text == "" ? "0" : Nocajas.Text);

                TextBox paquetesCajas = (TextBox)gvActualiza.Rows[i].FindControl("txtCantidadPaquetes");
                int CantidadPaquetes = Convert.ToInt32(paquetesCajas.Text == "" ? "0" : paquetesCajas.Text);

                TextBox piezaPaquete = (TextBox)gvActualiza.Rows[i].FindControl("txtCantidadPieza");
                int CantidadPieza = Convert.ToInt32(piezaPaquete.Text == "" ? "0" : piezaPaquete.Text);


                TextBox lote = (TextBox)gvActualiza.Rows[i].FindControl("txtLote");
                string strlote = lote.Text;

                CheckBox chActivo = (CheckBox)gvActualiza.Rows[i].FindControl("chkHabilitado");
                if (chActivo.Checked)
                    _entProducto.HabPedido = true;
                else
                    _entProducto.HabPedido = false;

                _entProducto.IdProducto = idProd;
                _entProducto.PaqCaja = CantidadPaquetes;
                _entProducto.PiezaPaq = CantidadPieza;
                _entProducto.NumCajas = CantidadCajas;
                _entProducto.Lote = strlote;
                _listaProductos.Add(_entProducto);
                _entProducto = new EntProducto();
            }
        }
        private void InformacionDetallePedido()
        {
            
            _entPedido.IdPedido = Convert.ToInt32( ViewState["IdPedido"].ToString());
            _entPedido.ProductosPedido = _listaProductos;
            _entPedido.EPaciente.IdPaciente = Convert.ToInt32(ViewState["IdPaciente"]);
            _entPedido.Eruta.IdRuta = Convert.ToInt32(ViewState["IdRutaPedido"].ToString() == "" ? "0" : ViewState["IdRutaPedido"].ToString());
            _entPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            _entPedido.Eusuario.IdUsuario = (Session["UsrInfo"] as EntUsuarios).IdUsuario;
            _entPedido.EPaciente.CvePaciente = Convert.ToDecimal(txtNumeroPaciente.Text);
            if (ddTratamiento.SelectedValue.ToString() != ViewState["idTratamiento"].ToString())
            {
                _entPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                _entPedido.Eruta.IdRuta = Convert.ToInt32(ViewState["idRuta"].ToString() == "" ? "0" : ViewState["idRuta"].ToString());
            }
            else
            {
                _entPedido.Eruta.IdRuta = Convert.ToInt32(ViewState["IdRutaPedido"].ToString() == "" ? "0" : ViewState["IdRutaPedido"].ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido=Convert.ToInt32(ViewState["IdPedido"].ToString());
                int idPaciente=Convert.ToInt32(ViewState["IdPaciente"].ToString());
                int idRuta=Convert.ToInt32(ViewState["IdRutaPedido"].ToString());;

                
                //Actualizar pedido
                if (ddTratamiento.SelectedValue.ToString() == ViewState["idTratamiento"].ToString())
                {
                    InformacionDetalleProducto();
                    InformacionDetallePedido();
                    if (vPedido.ActualizarPedido(idPedido, idRuta, idPaciente, _entPedido))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "error", "javascript:MjsModificado('');", true);
                    }
                    //vPedido.GenerarPedido(
                }
                else
                {
                   
                    InformacionDetalleProductoActualiza();
                    InformacionDetallePedido();
                    if (vPedido.GenerarPedido(_entPedido) == 0)
                    {
                        if (vPaciente.ActualizaTratamientoPaciente(_entPedido.EPaciente.CvePaciente, Convert.ToInt32(ddTratamiento.SelectedValue.ToString())))
                            {
                                int pedidoAnterio = Convert.ToInt32(ViewState["IdPedido"].ToString());
                                if (pedidoAnterio > 0)
                                {
                                    vPedido.CancelaPedidoCambio(idPedido);
                                }                               
                            }
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Generado", "javascript:MjsModificado('');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NoGenerado", "javascript:MjsModificado('Pedido No Generado');", true);
                    }                
                }
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "error", "javascript:MsjError('" + ex.Message + "');", true);
            }
        }
    }
}