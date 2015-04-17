using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Paginas.Pedidos
{


    public partial class Pedidos : System.Web.UI.Page
    {

        private List<EntProducto> _listaProductos = new List<EntProducto>();      
        
        vistaProducto vProducto = new vistaProducto();
        vistaPaciente vPaciente = new vistaPaciente();
        vistaRutas vRutas = new vistaRutas();
        vistaPedido vPedido = new vistaPedido();
        EntPedido _entPedido = new EntPedido();
        List<EntPedido> _listaPedido = new List<EntPedido>();
        EntProducto _entProducto = null;
        
        protected int _idProducto = 0;
        protected int _idPaciente = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["lproductos"] = new List<EntProducto>();
                iniciaGridProducto();
                iniciaGridPacientes();
                CargaGridProductos();
                CargaGridPacientes();
                CargaControles();
                if (Request.QueryString["TipoAplic"] != "" || Request.QueryString["TipoAplic"] != null)
                {
                    ViewState["TipoAplicacion"] = Request.QueryString["TipoAplic"];
                    cargaGridPedidoManual(ViewState["TipoAplicacion"].ToString());
                }
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:Oculta();", true);
            }

            if (Request.Form["ctl00$ContentPrincipal$__EVENTTARGET"] == "ctl00$ContentPrincipal$ddRutas")
            {
                if (Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"] != null)
                {
                    ViewState["idRuta"] = Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"];
                }
            }
            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddRutas")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["idRuta"] = Request.Form["__EVENTARGUMENT"];
                }
            }

            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$txtCvePaciente")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    var infoPaciente = vPaciente.RegresaPacientePorClave(Convert.ToDecimal(ViewState["cvePaciente"].ToString() == "" ? "0" : ViewState["cvePaciente"]));
                    informacionPacienteDetalle(infoPaciente);
                }
            }
            if (Request.Form["__EVENTTARGET"] == txtCvePaciente.ClientID)
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    ViewState["cvePaciente"] = Request.Form["__EVENTARGUMENT"];
                    var infoPaciente=vPaciente.RegresaPacientePorClave(Convert.ToDecimal(ViewState["cvePaciente"].ToString()==""?"0":ViewState["cvePaciente"]));
                }
            }
           
        }      

        private void CargaGridProductos()
        {
           /* gvProductos.DataSource = null;
            gvProductos.DataSource = vProducto.RegresaTodosProductos();
           gvProductos.DataBind();+*/
        }

        private void cargaGridPedidoManual(string tipoAplicacion)
        {
            switch (tipoAplicacion)
            {
                case "1":    var listaPedidoManual = vPedido.RegresaListaPedidoManual();
            if (listaPedidoManual.Count > 0)
            {
                gvDetallePedido.DataSource = listaPedidoManual;
                gvDetallePedido.DataBind();
            }
            break;
                case "2":
                     var listaPedidoMaquina = vPedido.RegresaListaPedidoMaquina();
                     if (listaPedidoMaquina.Count > 0)
            {
                gvDetallePedido.DataSource = listaPedidoMaquina;
                gvDetallePedido.DataBind();
            }
            break;
        }
        }

        private void CargaGridPacientes()
        {
           /* gvPacientes.DataSource = vPaciente.RegresaTodosPacientes(true);
            gvPacientes.DataBind();*/
        }

        private void iniciaGridPacientes()
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Nombre";
            bfield.DataField = "Nombre";
            gvPacientes.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "NSS";
            bfield.DataField = "NSS";
            gvPacientes.Columns.Add(bfield);
        }

        private void iniciaGridProducto()
        {        

            BoundField bfield = new BoundField();
            bfield.HeaderText = "Código";
            bfield.DataField = "Clave";
            gvProductos.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Marca";
            bfield.DataField = "Marca";
            gvProductos.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Descripcion";
            bfield.DataField = "Descripcion";
            gvProductos.Columns.Add(bfield);
            
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                
                _idProducto =Convert.ToInt32(gvProductos.DataKeys[row.RowIndex].Value);
                var detalle=vProducto.DetalleProducto(_idProducto);
                //_listaProductos.Add(detalle);
               
                (ViewState["lproductos"] as List<EntProducto>).Add(detalle);
                cargaGridDetallePedido();
            }
        }

        private void informacionPacienteDetalle(EntPacientes pPaciente)
        {
            ViewState["IdPaciente"] = pPaciente.IdPaciente;
            ViewState["CvePaciente"] = pPaciente.CvePaciente;
            lblClave.Text = pPaciente.CvePaciente.ToString();
            lblNombrePaciente.Text = pPaciente.Nombre.ToUpper() + " " + pPaciente.Ape_Pat.ToUpper() + " " + pPaciente.Ape_Mat.ToUpper();

        }
       
        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            _idProducto = Convert.ToInt32(gvProductos.DataKeys[e.NewSelectedIndex].Value);
            ViewState["idProducto"] = _idProducto;
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            CargaGridPacientes();
        }

        protected void gvPacientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int idPaciente = Convert.ToInt32(gvPacientes.DataKeys[e.NewSelectedIndex].Values["IdPaciente"].ToString());
            ViewState["IdPaciente"] = idPaciente;
            EntPacientes entpaciente = new EntPacientes();
            entpaciente = vPaciente.RegresaPaciente(idPaciente)[0];
            if (entpaciente != null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:Mostrar();", true);
                informacionPacienteDetalle(entpaciente);
                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "oculta", "javascript:OcultarGrid();", true);
                

            }
        }

        void CargaControles()
        {
            //se carga por variable de Session
            cargaRutasporTransportista((Session["UsrInfo"] as EntUsuarios).IdTransp);
        }

        void cargaRutasporTransportista(int pIdTransportista)
        {
            ddRutas.DataSource = vRutas.vistaRegresaRutasporTransportista(pIdTransportista);
            ddRutas.DataTextField = "CveRuta";
            ddRutas.DataValueField = "IdRuta";
            ddRutas.DataBind();
            ViewState["idRuta"] = ddRutas.SelectedValue;
        }

        private void cargaGridDetallePedido()
        {
            List<EntProducto> listap = new List<EntProducto>();
            List<EntProducto> listaaux = new List<EntProducto>();
            listap = (ViewState["lproductos"] as List<EntProducto>);
            foreach (var l in listap)
            {
                if (!listaaux.Exists(p => p.IdProducto == l.IdProducto))
                {
                    listaaux.Add(l);
                }
            }
            gvDetallePedido.DataSource = listaaux;
            gvDetallePedido.DataBind();
        }

        private void InformacionDetalleProducto()
        {
            _entProducto = new EntProducto();
            _listaProductos = new List<EntProducto>();
            for (int i = 0; i < gvDetallePedido.Rows.Count; i++)
            {
                int idProd = Convert.ToInt32(gvDetallePedido.DataKeys[i].Value);
                TextBox Nocajas = (TextBox)gvDetallePedido.Rows[i].FindControl("txtCantidadCajas");
                int CantidadCajas = Convert.ToInt32(Nocajas.Text == "" ? "0" : Nocajas.Text);

                TextBox paquetesCajas=(TextBox)gvDetallePedido.Rows[i].FindControl("txtCantidadPaquetes");
                int CantidadPaquetes = Convert.ToInt32(paquetesCajas.Text == "" ? "0" : paquetesCajas.Text);
                
                TextBox piezaPaquete = (TextBox)gvDetallePedido.Rows[i].FindControl("txtCantidadPieza");
                int CantidadPieza = Convert.ToInt32(piezaPaquete.Text == "" ? "0" : piezaPaquete.Text);

                TextBox lote = (TextBox)gvDetallePedido.Rows[i].FindControl("txtLote");
                string strlote = lote.Text;
                
                //txtLote
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

        private void InformacionDetallePedido()
        {
            InformacionDetalleProducto();
            _entPedido.ProductosPedido = _listaProductos;
            _entPedido.EPaciente.IdPaciente =Convert.ToInt32(ViewState["IdPaciente"]);
            _entPedido.Eruta.IdRuta = Convert.ToInt32(ViewState["idRuta"].ToString() == "" ? "0" : ViewState["idRuta"].ToString());
            _entPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            _entPedido.Eusuario.IdUsuario = (Session["UsrInfo"] as EntUsuarios).IdUsuario;
            _entPedido.EPaciente.CvePaciente = Convert.ToDecimal(txtCvePaciente.Text == "" ? "0" : txtCvePaciente.Text);
        }

        protected void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                
                //if (gvDetallePedido.Rows.Count > 0)
               // {
                    InformacionDetallePedido();
                if(!vPedido.ExistePacienteEnRutaPedido(_entPedido.EPaciente.IdPaciente,_entPedido.Eruta.IdRuta))
                {
                    if (vPedido.GenerarPedido(_entPedido) == 0)
                    {
                        if (validaTipoAplicacion())
                        {
                            if (!vPaciente.ActualizaTratamientoPaciente(_entPedido.EPaciente.CvePaciente, Convert.ToInt32(ViewState["TipoAplicacion"].ToString())))
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "tratamiento", "javascript:alert('Tratamiento no aplicado');", true);
                            }
                        }
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Generado", "javascript:AgregaPedido();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NoGenerado", "javascript:MjsExiste('Pedido No Generado');", true);
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Generado", "javascript:MjsExiste('El Paciente ya esta asignado a la ruta');", true);
               // }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Exception", "javascript:MsjError('" + ex.Message + "');", true);
            }

        }

        bool validaTipoAplicacion()
        {
            try
            {
                if (ViewState["TipoAplicacion"] != null || ViewState["TipoAplicacion"].ToString() != "")
                {
                    if (Convert.ToInt32(ViewState["TipoAplicacion"].ToString()) > 0)
                    {
                        
                        return true;
                    }

                }
            }
            catch
            { }
            return false;
        }

    }
}