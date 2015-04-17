using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Externo.Procesamiento.Entidades;

namespace Ext.Web
{
    public partial class MasterExterno : System.Web.UI.MasterPage
    {

        //Create a new SubMenu
        public MenuItem mnSubmenu { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaMenu(this.MenuPrincipal);
            }
        }


        protected void CargaMenu(Menu menu)
        {
            if (Session["UsrInfo"] != null)
            {
                var usrGrupo = (Session["UsrInfo"] as EntUsuarios).Grupo;
                if (usrGrupo == 1 || usrGrupo == 2)
                {
                    MenuItem Nivel1;
                    MenuItem Nivel2;
                    MenuItem Nivel3;
                    MenuItem Nivel4;
                    Nivel1 = CreaOpcionMenu("Principal", "~/Default.aspx", "Principal");
                    menu.Items.Add(Nivel1);

                    Nivel1 = CreaOpcionMenu("Catalogos", "", "Catalogos");
                    Nivel2 = CreaOpcionMenu("Configurar Ruta", "~/Paginas/Rutas/RutaTransporte.aspx", "Configurar Ruta");
                    Nivel1.ChildItems.Add(Nivel2);
                    Nivel2 = CreaOpcionMenu("Detalle Ruta", "~/Paginas/Rutas/DetalleRuta.aspx", "Configurar Ruta");
                    Nivel1.ChildItems.Add(Nivel2);
                    Nivel2 = CreaOpcionMenu("CEDIS", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Cedis/Cedis.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/Cedis/ModificarCedis.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    menu.Items.Add(Nivel1);

                    Nivel1 = CreaOpcionMenu("Linea de Transporte", "", "Transportista");
                    Nivel2 = CreaOpcionMenu("Transportista", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Transporte/Transporte.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/Transporte/ModificarTransportista.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    Nivel2 = CreaOpcionMenu("Empleado", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Choferes/Choferes.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/Choferes/ModificarOperador.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Operadores", "~/Paginas/Choferes/DetalleOperadores.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    
                    Nivel2 = CreaOpcionMenu("Unidad", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Unidad/Unidad.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/Unidad/ModificarUnidad.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    menu.Items.Add(Nivel1);
                    //PACIENTES
                    Nivel1 = CreaOpcionMenu("Pacientes", "", "Paciente");                  
                    Nivel2 = CreaOpcionMenu("Paciente", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Pacientes.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/ModificarPacientes.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    Nivel2 = CreaOpcionMenu("Contacto", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/AltaContactoPaciente.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/ModificaContactoPaciente.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    menu.Items.Add(Nivel1);

                    //PRODUCTOS
                    Nivel1 = CreaOpcionMenu("Productos", "", "Producto");
                    Nivel2 = CreaOpcionMenu("Producto", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Productos/Producto.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Consultar", "~/Paginas/Productos/DetalleProducto.aspx", "");
                        Nivel2.ChildItems.Add(Nivel3);
                        Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/Productos/ModificarProductos.aspx", "");
                        Nivel2.ChildItems.Add(Nivel3);
                        Nivel1.ChildItems.Add(Nivel2);
                       //menu.Items.Add(Nivel1);
                        Nivel2 = CreaOpcionMenu("Maquina HOME CHOICE", "", "");
                        Nivel3 = CreaOpcionMenu("Nuevo", "~/Paginas/Maquinas/HomeChoice.aspx", "");
                        //Nivel2.ChildItems.Add(Nivel3);
                        //Nivel3 = CreaOpcionMenu("Consultar", "~/Paginas/Pedidos/Pedidos.aspx", "");
                        Nivel2.ChildItems.Add(Nivel3);
                        Nivel3 = CreaOpcionMenu("Reemplazo", "~/Paginas/Maquinas/ModificaHomeChoice.aspx", "");
                        Nivel2.ChildItems.Add(Nivel3);
                   // Nivel2.ChildItems.Add(Nivel3);
                    Nivel1.ChildItems.Add(Nivel2);
                    menu.Items.Add(Nivel1);
                    //PEDIDOS

                    //AGREGAR PEDIDO A RUTA --IDPACIENTE,RUTA,FECHA_ENTREGA
                    Nivel1 = CreaOpcionMenu("Pedidos", "", "Pedidos");
                    Nivel2 = CreaOpcionMenu("Pedido", "", "");
                    Nivel3 = CreaOpcionMenu("Nuevo", "", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel4 = CreaOpcionMenu("Manual", "~/Paginas/Pedidos/Pedidos.aspx?TipoAplic=1", "");
                    Nivel3.ChildItems.Add(Nivel4);
                    Nivel4 = CreaOpcionMenu("HOME CHOICE", "~/Paginas/Pedidos/Pedidos.aspx?TipoAplic=2", "");
                    Nivel3.ChildItems.Add(Nivel4);
                    //Nivel3 = CreaOpcionMenu("Consultar", "~/Paginas/Pedidos/Pedidos.aspx", "");
                    //Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Modificar", "~/Paginas/Pedidos/ModificarPedido.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);
                    Nivel3 = CreaOpcionMenu("Asignar Ruta", "~/Paginas/Pedidos/AsignaPedidoRuta.aspx", "");
                    Nivel2.ChildItems.Add(Nivel3);

                    Nivel1.ChildItems.Add(Nivel2);
                    menu.Items.Add(Nivel1);


                   

                    Nivel1 = CreaOpcionMenu("Hospitalario", "", "Hospitalario");
                    menu.Items.Add(Nivel1);

                    Nivel1 = CreaOpcionMenu("Delegacional", "", "Delegacional");
                    menu.Items.Add(Nivel1);
                    //MenuItem menuPrincipal = CreaOpcionMenu("Principal", "~/Default.aspx", "Principal");
                    //menu.Items.Add(menuPrincipal);

                    //menuPrincipal = CreaOpcionMenu("Catalogos", "", "Catalogos");
                   
                    //    MenuItem sbmenuPrincipal = CreaOpcionMenu("Nuevo Operador", "~/Paginas/Choferes/Choferes.aspx", "Operadores");
                    //    menuPrincipal.ChildItems.Add(sbmenuPrincipal);
                    //    sbmenuPrincipal = CreaOpcionMenu("Operadores", "", "Operadores");
                    //    menuPrincipal.ChildItems.Add(sbmenuPrincipal);

                    //    sbmenuPrincipal = CreaOpcionMenu("Linea Transporte", "~/Paginas/Transporte/Transporte.aspx", "");
                    //    menuPrincipal.ChildItems.Add(sbmenuPrincipal);

                    //    sbmenuPrincipal = CreaOpcionMenu("Configuracion de Rutas", "~/Paginas/Rutas/RutaTransporte.aspx", "");
                    //    menuPrincipal.ChildItems.Add(sbmenuPrincipal);

                    //    sbmenuPrincipal = CreaOpcionMenu("Productos", "", "Productos");
                    //    MenuItem subsubmenu = CreaOpcionMenu("Registrar Productos", "~/Paginas/Productos/Producto.aspx", "");
                    //    sbmenuPrincipal.ChildItems.Add(subsubmenu);
                    //    menuPrincipal.ChildItems.Add(sbmenuPrincipal);
                    

                    
                    //menu.Items.Add(menuPrincipal);

                    //MenuItem menuPacientes = CreaOpcionMenu("Pacientes", "", "Pacientes");
                    //MenuItem subAltaPacientes = CreaOpcionMenu("Agregar Paciente", "~/Paginas/Pacientes.aspx", "Agregar Pacientes");
                    //menuPacientes.ChildItems.Add(subAltaPacientes);
                    //MenuItem subAltaContactosPacientes = CreaOpcionMenu("Agregar Contacto Paciente", "~/Paginas/AltaContactoPaciente.aspx", "Contactos Pacientes");
                    //menuPacientes.ChildItems.Add(subAltaContactosPacientes);

                    //subAltaContactosPacientes = CreaOpcionMenu("Modificar Registros", "~/Paginas/ModificarPacientes.aspx", "Modificar Pacientes");
                    //menuPacientes.ChildItems.Add(subAltaContactosPacientes);

                    //MenuItem subConsultaPacientes = CreaOpcionMenu("Ver Pacientes", "~/Paginas/AltaContactoPaciente.aspx", "Lista de Pacientes");
                    //menuPacientes.ChildItems.Add(subConsultaPacientes);
                    //menu.Items.Add(menuPacientes);

                    //MenuItem mnCabecero = CreaOpcionMenu("Pedidos", "", "Pedidos");
                    //menu.Items.Add(mnCabecero);
                    //MenuItem subMenu = CreaOpcionMenu("Nuevo Pedido", "~/Paginas/Pedidos/Pedidos.aspx", "Nuevo Pedido");
                    //mnCabecero.ChildItems.Add(subMenu);
                    //subMenu = CreaOpcionMenu("Consulta Pedidos", "", "Consulta Pedidos");
                    //mnCabecero.ChildItems.Add(subMenu);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "error", "javascript:alert('ERROR DE SESSION');", true);
            }
        }

        MenuItem CreaOpcionMenu(string text, string url, string toolTip)
        {            
            MenuItem menuItem = new MenuItem();            
            menuItem.Text = text;
            menuItem.NavigateUrl = url;
            menuItem.ToolTip = toolTip;
            return menuItem;

        }
       


    }
}