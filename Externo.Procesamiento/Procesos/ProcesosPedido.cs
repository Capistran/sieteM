using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;
using Externo.Procesamiento.Entidades;
using System.Transactions;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosPedido
    {
        ModelExternoDataContext dc;
        EntPedido _entPedido = null;
        EntProducto _entProducto=null;
        int _success = -1;
        public ProcesosPedido()
        { }

        private int RegresaMaximoPedido( ModelExternoDataContext data)
        {
            int maximoPedido = -1;
            try
            {
                var dpedido = (from pedido in data.PEDIDO select pedido.ID_PEDIDO).FirstOrDefault();
                if(dpedido!=null||dpedido!=0)
                    maximoPedido = (from ped in data.PEDIDO select ped.ID_PEDIDO).Max();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return maximoPedido;
        }
       
        public int AgregaPedido(EntPedido pPedidos)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            dc.Connection.Open();
            int _success1 = -1;            
            try
            {
                dc.Transaction = dc.Connection.BeginTransaction();
                _success = (dc.spIns_GenerarPedido(pPedidos.Eruta.IdRuta,
                    pPedidos.EPaciente.IdPaciente,
                    pPedidos.Observacion,                    
                    pPedidos.FechaEntrega,
                    pPedidos.Eusuario.IdUsuario));
                int max=RegresaMaximoPedido(dc);
                if(max>0)
                {
                    if(pPedidos.ProductosPedido.Count>0)
                    {
                        foreach(var p in pPedidos.ProductosPedido)
                        {
                            _success1 = (dc.spIns_DetallePedido(max, p.IdProducto, p.PiezaPaq, p.NumCajas, p.PaqCaja,p.HabPedido,p.Lote));
                            if (_success1 != 0)
                                break;
                        }
                    }
                }
                if (_success == 0 && _success == _success1)
                    dc.Transaction.Commit();
                else
                    dc.Transaction.Rollback();
                    
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return _success;
        }

        public List<EntProducto> RegresaPedidoManual()
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entProducto = new EntProducto();
            
            List<EntProducto> listaProducto = new List<EntProducto>();
            try 
            {                
                var lstProducto = (from pro in dc.vPedidoManual
                                   select pro).ToList();

                if (lstProducto.Count > 0)
                {
                    foreach (var l in lstProducto)
                    {
                        _entProducto.IdProducto = l.ID_PRODUCTO;
                        _entProducto.Clave = l.CLAVE;
                        _entProducto.Marca = l.MARCA;
                        _entProducto.Descripcion = l.DESCRIPCION;
                        listaProducto.Add(_entProducto);
                        _entProducto = new EntProducto();
                    }
                }
            
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return listaProducto;
        }

        public List<EntProducto> RegresaPedidoMaquina()
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entProducto = new EntProducto();
         
            List<EntProducto> listaProducto = new List<EntProducto>();
            try
            {
                var lstProducto = (from pro in dc.vPedidoMaquina
                                   select pro).ToList();

                if (lstProducto.Count > 0)
                {
                    foreach (var l in lstProducto)
                    {
                        _entProducto.IdProducto = l.ID_PRODUCTO;
                        _entProducto.Clave = l.CLAVE;
                        _entProducto.Marca = l.MARCA;
                        _entProducto.Descripcion = l.DESCRIPCION;
                        listaProducto.Add(_entProducto);
                        _entProducto = new EntProducto();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return listaProducto;
        }

        public List<string> RegresaMesesPedidoPaciente(decimal cvePaciente, int idTratamiento)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntPedido _entPedido = new EntPedido();
            List<string> meses = new List<string>();
            string mes = string.Empty;
            try
            {
                var pediTrat = dc.spSel_MesPedidoTratamiento(cvePaciente, idTratamiento).ToList();

                if (pediTrat.Count() > 0)
                {
                    foreach (var p in pediTrat)
                    {
                        
                        mes = (p.MES == null ? "" : p.MES);
                        meses.Add(mes);
                        mes = "";
                        
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dc.Connection.Close();
            }
            return meses;
        }

        public List<EntPedido> RegresaPedidoPorTratamiento(decimal cvePaciente, int idTratamiento)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntPedido _entPedido = new EntPedido();
            List<EntPedido> listaPedido = new List<EntPedido>();
            try 
            {
                var pediTrat=dc.spSel_PedidoTratamiento(cvePaciente, idTratamiento).ToList();

                if (pediTrat.Count() > 0)
                {
                    foreach (var p in pediTrat)
                    {
                        _entPedido.EPaciente.CvePaciente =(decimal) p.CVE_PACIENTE;
                        _entPedido.EProducto.Clave = p.CLAVE;
                        _entPedido.EProducto.Marca = p.MARCA;
                        _entPedido.EProducto.Descripcion = p.DESCRIPCION;
                        _entPedido.Habilitado = (bool)p.HABILITADO;
                        _entPedido.IdPedido = p.ID_PEDIDO;
                        _entPedido.EProducto.IdProducto = p.ID_PRODUCTO;
                        _entPedido.EPaciente.Nombre = p.NOMBRE;
                        _entPedido.CantidadPaqutes =(int) p.CANTIDAD_PAQ;
                        _entPedido.CantidadCaja = (int)p.CANTIDAD_CAJA;
                        _entPedido.CantidadSuelto = (int)p.CANTIDAD_SUELTO;
                        _entPedido.MesPedido = (p.MES == null ? "" : p.MES);
                        listaPedido.Add(_entPedido);
                        _entPedido = new EntPedido();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dc.Connection.Close();
            }
            return listaPedido;
        }

        public List<EntPedido> RegresaPedidoPorTratamientoMes(decimal cvePaciente, int idTratamiento,string mes,int idruta)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntPedido _entPedido = new EntPedido();
            List<EntPedido> listaPedido = new List<EntPedido>();
            try
            {
                var pediTrat = dc.spSel_PedidoTratamientoMes(cvePaciente, idTratamiento,mes,idruta).ToList();

                if (pediTrat.Count() > 0)
                {
                    foreach (var p in pediTrat)
                    {
                        _entPedido.EPaciente.CvePaciente = (decimal)p.CVE_PACIENTE;
                        _entPedido.EProducto.Clave = p.CLAVE;
                        _entPedido.EProducto.Marca = p.MARCA;
                        _entPedido.EProducto.Descripcion = p.DESCRIPCION;
                        _entPedido.Habilitado = (bool)p.HABILITADO;
                        _entPedido.IdPedido = p.ID_PEDIDO;
                        _entPedido.EProducto.IdProducto = p.ID_PRODUCTO;
                        _entPedido.EPaciente.Nombre = p.NOMBRE;
                        _entPedido.CantidadPaqutes = (int)p.CANTIDAD_PAQ;
                        _entPedido.CantidadCaja = (int)p.CANTIDAD_CAJA;
                        _entPedido.CantidadSuelto = (int)p.CANTIDAD_SUELTO;
                        _entPedido.Eruta.IdRuta = (int)p.ID_RUTA;
                        _entPedido.MesPedido = p.MES;
                        _entPedido.EProducto.Lote = p.LOTE == null ? "NA" : p.LOTE;
                        listaPedido.Add(_entPedido);
                        _entPedido = new EntPedido();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dc.Connection.Close();
            }
            return listaPedido;
        }


        public bool ActualizarPedido(int IdPedido,int IdRuta,int IdPaciente,EntPedido entPedido)
        {
            bool success=false;
            dc = new ModelExternoDataContext(Configuracion.strConexion);

            
            //dc.Connection.Open();
           // dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                using (var tran = new TransactionScope())
                {
                    dc.spUpd_EntregaPedido(IdPedido,IdPaciente,entPedido.Eruta.IdRuta);
                    dc.spUpd_DetalleRuta(IdPedido,IdPaciente,entPedido.Eruta.IdRuta);
                    
               
                foreach (var p in entPedido.ProductosPedido)
                {
                    
                    success=ActualizaDetallePedido(ref dc, IdPedido,p);
                }
                if (success)
                {
                    dc.SubmitChanges();
                  //  dc.Transaction.Commit();
                }
              //  else
                   // dc.Transaction.Rollback();
                         tran.Complete();
                }
            }
            catch (Exception ex)
            {
              //  dc.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return success;
        }

        public bool ActualizaDetallePedido(ref ModelExternoDataContext dc, int idPedido, EntProducto entProducto)
        {
            //dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                /*var dtPedido = (from dt in dc.DETALLE_PEDIDO
                                where dt.ID_PEDIDO == idPedido
                                && dt.ID_PRODUCTO==entProducto.IdProducto
                                select dt).SingleOrDefault();

                if (dtPedido != null)
                {
                    dtPedido.CANTIDAD_CAJA =entProducto.NumCajas;
                    dtPedido.CANTIDAD_PAQ =entProducto.PaqCaja;
                    dtPedido.CANTIDAD_SUELTO = entProducto.PiezaPaq;
                    //dc.SubmitChanges();
                    success = true;
                }*/

                dc.spUpd_DetallePedido(idPedido, entProducto.IdProducto, entProducto.PiezaPaq, entProducto.NumCajas, entProducto.PaqCaja, entProducto.HabPedido);
                success = true;
            }
            catch (Exception ex)
            {
                //dc.Connection.Close();
                throw ex;
            }
            finally
            {
              //  dc.Connection.Close();
               // dc.Dispose();
            }
            return success;
        }

        public EntPedido ObtienePedidoPaciente(string cvePaciente)
        {

            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entPedido = new EntPedido();
            try
            {

                var pedido = (dc.spSel_ObtienePedidoPaciente(cvePaciente)).SingleOrDefault();
                if (pedido != null)
                {
                    _entPedido.IdPedido = pedido.id_pedido;
                    _entPedido.EPaciente.IdPaciente = pedido.id_Paciente;
                    _entPedido.Eruta.IdRuta = pedido.id_ruta;
                    _entPedido.MesPedido = pedido.mes;
                    _entPedido.EPaciente.IdTratamiento =(int) pedido.tratamiento;
                    _entPedido.FechaEntrega = (DateTime)pedido.fecha_entrega;
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return _entPedido;
        }

        public bool ExistePacienteRuta(int idPaciente, int IdRuta)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                var entregapedido = (from ped in dc.ENTREGA_PEDIDO
                                     where ped.ID_PACIENTE == idPaciente
                                     && ped.ID_RUTA == IdRuta
                                     && ped.ESTATUS_ENTREGA=="PENDIENTE"
                                     select ped).SingleOrDefault();
                if (entregapedido != null)
                    success = true;
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return success;
        }

        public bool CancelarPedidoCambioTratamiento(int idPedido)
        {
            bool success = false;
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            int continua = -1;            
            try
            {
                using (var tran = new TransactionScope())
                {
                    continua=dc.spUpd_CancelarEntregaPedidoCambio(idPedido);
                    if (continua == 0)
                        continua = dc.spUpd_CancelarPedidoCambio(idPedido);

                    if (continua == 0)
                    {
                        tran.Complete();
                        success = true;
                    }
                }            
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return success;
        }

        public List<EntProducto> ObtienePedidoAnteriorPaciente(int idPaciente,int idPedido)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entProducto = new EntProducto();
            List<EntProducto> lstProducto = new List<EntProducto>();
            try
            {
                var pedidoAnterior = (from pant in dc.vAsignarPedido
                                      where pant.ID_PACIENTE == idPaciente
                                      && pant.ID_PEDIDO == idPedido
                                      //&& pant.MES == mes
                                      select pant).ToList();

                if (pedidoAnterior.Count > 0)
                {
                    foreach (var pa in pedidoAnterior)
                    {
                        _entProducto.IdProducto = pa.ID_PRODUCTO;
                        _entProducto.HabPedido = (bool)pa.HABILITADO;
                        _entProducto.NumCajas =  (int) pa.CANTIDAD_CAJA;
                        _entProducto.PaqCaja =  (int) pa.CANTIDAD_PAQ;
                        _entProducto.PiezaPaq = (int)pa.CANTIDAD_SUELTO;
                        lstProducto.Add(_entProducto);
                        _entProducto = new EntProducto();
                    }
                
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return lstProducto;
        }

        public int MaxPedidoPaciente(int idPaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            int max = -1;
            try
            {
                max = (from maxped in dc.PEDIDO
                       where maxped.ID_PACIENTE == idPaciente
                       select maxped.ID_PEDIDO).Max();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return max;

        }
    }
}
