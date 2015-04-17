using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;
using Ext.Web.Vistas;

namespace Ext.Web.Paginas.Pedidos
{
    public partial class AsignaPedidoRuta : System.Web.UI.Page
    {
        #region Variables
        private List<EntProducto> _listaProductos = new List<EntProducto>();      
        vistaPaciente vPaciente = new vistaPaciente();
        vistaPedido vPedido = new vistaPedido();
        EntPedido _entPedido = new EntPedido();
        List<EntPedido> _listaPedido = new List<EntPedido>();
        List<EntProducto> _listaProductosNuevo = new List<EntProducto>();   
        EntProducto _entProducto = null;
        vistaRutas vRutas = new vistaRutas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaControles();
            }

            if (Request.Form["ctl00$ContentPrincipal$__EVENTTARGET"] == "ctl00$ContentPrincipal$ddRutas")
            {
                if (Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"] != null)
                {
                    ViewState["idRuta"] = Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"];
                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddRuta")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["idRuta"] = Request.Form["__EVENTARGUMENT"];
                    var rutas = vRutas.RegresaRutasPorClave(ddRuta.SelectedItem.ToString().Trim(), (Session["UsrInfo"] as EntUsuarios).IdTransp);
                    if (rutas.Count > 0)
                    {
                        ddMes.Items.Clear();
                        foreach (var ru in rutas)
                        {
                            ddMes.Items.Add(ru.Mes);
                        }
                    }
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtNumPaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    var infoPaciente = vPaciente.RegresaPacientePorClave(Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"]));
                    if (infoPaciente.IdPaciente != 0)
                    {
                        ViewState["IdPaciente"] = infoPaciente.IdPaciente;
                        ViewState["TipoAplicacion"] = infoPaciente.IdTratamiento;
                        cargaGridPedidoManual(infoPaciente.IdTratamiento.ToString());
                    }
                }
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                InformacionDetallePedido();
                if (!vPedido.ExistePacienteEnRutaPedido(_entPedido.EPaciente.IdPaciente, _entPedido.Eruta.IdRuta))
                {
                    if (vPedido.GenerarPedido(_entPedido) == 0)
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Generado", "javascript:MsjSuccess('Pedido Generado');", true);
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NoGenerado", "javascript:MsjOtro('Pedido No Generado');", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Generado", "javascript:MsjOtro('El Paciente ya esta asignado a la ruta');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Exception", "javascript:alert('" + ex.Message + "');", true);
            }

        }
        #endregion

        #region Metodos Privados

        private void cargaGridPedidoManual(string tipoAplicacion)
        {
            switch (tipoAplicacion)
            {
                case "1": var listaPedidoManual = vPedido.RegresaListaPedidoManual();
                    if (listaPedidoManual.Count > 0)
                    {
                        gvDetallePedido.DataSource = listaPedidoManual;
                        gvDetallePedido.DataBind();
                        //gvDetallePedido.Visible = true;
                    }
                    break;
                case "2":
                    var listaPedidoMaquina = vPedido.RegresaListaPedidoMaquina();
                    if (listaPedidoMaquina.Count > 0)
                    {
                        gvDetallePedido.DataSource = listaPedidoMaquina;
                        gvDetallePedido.DataBind();
                        //gvDetallePedido.Visible = true;
                    }
                    break;
            }
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

                CheckBox chActivo = (CheckBox)gvDetallePedido.Rows[i].FindControl("chkHabilitado");
                if (chActivo.Checked)
                    _entProducto.HabPedido = true;
                else
                    _entProducto.HabPedido = false;
                _entProducto.IdProducto = idProd;
                _entProducto.PaqCaja = CantidadPaquetes;
                _entProducto.PiezaPaq = CantidadPieza;
                _entProducto.NumCajas = CantidadCajas;
                _listaProductos.Add(_entProducto);
                _entProducto = new EntProducto();
            }
        }

        private void InformacionPedidoActual()
        {
            try
            {
                _entProducto = new EntProducto();
                _listaProductos = new List<EntProducto>();
                int idPedidoUlt = vPedido.RegresaUltimoPedidoPaciente(Convert.ToInt32(ViewState["IdPaciente"]));
                _listaProductos = vPedido.RegresaProductosAsignarPedido(Convert.ToInt32(ViewState["IdPaciente"]), idPedidoUlt);
                if (_listaProductos.Count > 0)
                {
                    foreach (var prodnew in _listaProductos)
                    {
                        _entProducto.HabPedido = prodnew.HabPedido;
                        _entProducto.IdProducto = prodnew.IdProducto;
                        _entProducto.PaqCaja = prodnew.PaqCaja;
                        _entProducto.PiezaPaq = prodnew.PiezaPaq;
                        _entProducto.NumCajas = prodnew.NumCajas;
                        _listaProductosNuevo.Add(_entProducto);
                        _entProducto = new EntProducto();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void InformacionDetallePedido()
        {
            InformacionDetalleProducto();
            InformacionPedidoActual();
            _entPedido.ProductosPedido = _listaProductos;
            _entPedido.EPaciente.IdPaciente = Convert.ToInt32(ViewState["IdPaciente"]);
            _entPedido.Eruta.IdRuta = Convert.ToInt32(ViewState["idRuta"].ToString() == "" ? "0" : ViewState["idRuta"].ToString());
            _entPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            _entPedido.Eusuario.IdUsuario = (Session["UsrInfo"] as EntUsuarios).IdUsuario;
            _entPedido.EPaciente.CvePaciente = Convert.ToDecimal(txtNumPaciente.Text == "" ? "0" : txtNumPaciente.Text);
        }

        private void CargaControles()
        {
            cargaRutasporTransportista((Session["UsrInfo"] as EntUsuarios).IdTransp);
        }

        private void cargaRutasporTransportista(int pIdTransportista)
        {
            ddRuta.DataSource = vRutas.vistaRegresaRutasporTransportista(pIdTransportista);
            ddRuta.DataTextField = "CveRuta";
            ddRuta.DataValueField = "IdRuta";
            ddRuta.DataBind();
            ViewState["idRuta"] = ddRuta.SelectedValue;
        }

        #endregion

      
    }
}