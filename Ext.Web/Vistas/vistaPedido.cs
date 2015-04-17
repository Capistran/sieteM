using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;

namespace Ext.Web.Vistas
{
    public class vistaPedido
    {

        ProcesosPedido prcPedido=new ProcesosPedido();
        //EntPedido _epedido = null;

        public int GenerarPedido(EntPedido pPedido)
        {
            return prcPedido.AgregaPedido(pPedido);
        }

        public List<EntProducto> RegresaListaPedidoManual()
        {
            return prcPedido.RegresaPedidoManual();
        }

        public List<EntProducto> RegresaListaPedidoMaquina()
        {
            return prcPedido.RegresaPedidoMaquina();
        }

        public List<EntPedido> RegresaPedidoTratamiento(decimal cvePaciente, int idtratamiento)
        {
            return prcPedido.RegresaPedidoPorTratamiento(cvePaciente,idtratamiento);
        }

        public List<EntPedido> RegresaPedidoTratamientoMes(decimal cvePaciente, int idtratamiento,string mes,int idRuta)
        {
            return prcPedido.RegresaPedidoPorTratamientoMes(cvePaciente, idtratamiento,mes,idRuta);
        }

        public bool ActualizaPedidoDetalle(int IdPedido)
        {
            return true;
        }

        public bool ActualizarPedido(int idpedido,int idruta,int idpaciente,EntPedido entPedido)
        {
            return prcPedido.ActualizarPedido(idpedido,idruta,idpaciente,entPedido);
        }

        public EntPedido ObtienePedidoPacienteClave(string cvePaciente)
        {
            return prcPedido.ObtienePedidoPaciente(cvePaciente);
        }

        public bool ExistePacienteEnRutaPedido(int idPaciente,int idruta)
        {
            return prcPedido.ExistePacienteRuta(idPaciente,idruta);
        }

        public bool CancelaPedidoCambio(int idPedido)
        {
            return prcPedido.CancelarPedidoCambioTratamiento(idPedido);
        }

        public List<EntProducto> RegresaProductosAsignarPedido(int idPaciente,int idPedido)
        {
            return prcPedido.ObtienePedidoAnteriorPaciente(idPaciente, idPedido);
        }

        public int RegresaUltimoPedidoPaciente(int idPaciente)
        {
            return prcPedido.MaxPedidoPaciente(idPaciente);
        }
    }
}