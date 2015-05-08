using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.AccesoDatos.LinqToSql;
using Externo.AccesoDatos.Configuracion;
using Externo.Procesamiento.Entidades;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosRutas
    {
        ModelExternoDataContext dc;
        List<EntPacientes> _lstPacientes = null;
        EntPacientes _pacientes = null;
        List<EntRuta> _listaRuta = null;
        EntRuta _entRuta = null;
        public ProcesosRutas()
        {
            _pacientes = new EntPacientes();
            _lstPacientes = new List<EntPacientes>();
        }

        ~ProcesosRutas()
        {
            _lstPacientes = null;
            _pacientes = null;
            _listaRuta = null;
            _entRuta = null;
            
            
        }

        public List<EntPacientes> RegresaPacientesRuta(int pIdRuta, int pIdTransportista)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try 
            {
                _lstPacientes = new List<EntPacientes>();
                var personas = (dc.spSel_RutaPacientes((int)pIdRuta, (int)pIdTransportista));
                foreach (var p in personas)
                {
                    //_pacientes.IdPaciente = p.ID_PACIENTE;
                    _pacientes.Nombre = p.NOMBRE.ToUpper()+" "+p.APE_PAT.ToUpper()+" "+p.APE_MAT.ToUpper();
                    _pacientes.Latitud = (float)p.LATITUD;
                    _pacientes.Longitud = (float)p.LONGITUD;
                    _pacientes.Estatus_entrega = p.ESTATUS_ENTREGA;
                    _pacientes.MotCancelacion = (p.MOT_CANCELACION == null ? "" : p.MOT_CANCELACION);
                    _pacientes.HoraLlegada = (DateTime)(p.FECHA_LLEGADA==null?new DateTime(2000,1,1):p.FECHA_LLEGADA);
                    _pacientes.HoraSalida = (DateTime)(p.FECHA_SALIDA == null ? new DateTime(2000, 1, 1) : p.FECHA_SALIDA);
                    
                    //_pacientes.NombreChofer = p.NOMBRE_CHOFER;
                    _lstPacientes.Add(_pacientes);
                    _pacientes = new EntPacientes();
                }
            }
            catch 
            { 
            }
            finally 
            {
                dc.Connection.Close();
            }
            return _lstPacientes;
        }

        public EntRuta RegresaDetalleRuta(int pIdRuta)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaRuta = new List<EntRuta>();
            _entRuta = new EntRuta();
            try
            {
                var rutas = (from rut in dc.vRutasTransportista
                             where rut.ID_RUTA == (int)pIdRuta
                             select rut).SingleOrDefault<vRutasTransportista>();
                if (rutas != null)
                {
                    _entRuta.IdRuta = rutas.ID_RUTA;
                    _entRuta.CveRuta = rutas.CVE_RUTA;
                    _entRuta.NumEconomico = rutas.NUM_ECONOMICO;
                    _entRuta.Nombre = rutas.NOMBRE == null ? "" : rutas.NOMBRE;
                    _entRuta.Marca = rutas.MARCA == null ? "" : rutas.MARCA;
                    _entRuta.Modelo = rutas.MODELO == null ? "" : rutas.MODELO;
                    //_entRuta.CapacidadCarga = (int)rutas.CAP_CARGA;
                    _entRuta.Mes = rutas.MES;

                }
            }
          
            catch 
            {
               // throw new Exception("No existen rutas para esta linea de Transporte");
            }
            finally
            {
                dc.Connection.Close();
            }
            return _entRuta;
        
        }

        public List<EntRuta> RegresaRutasPorTransportista(int idTransportista)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaRuta = new List<EntRuta>();
            _entRuta = new EntRuta();
            try
            {
                //var rutas = (from rut in dc.vRutasTransportista
                //             where rut.ID_TRANSP == idTransportista
                //             select rut).ToList();
                var rutas = (from rut in dc.CAT_RUTA
                             where rut.ID_TRANSP == idTransportista
                             && rut.MES!=null
                             && rut.ESTATUS=="VIGENTE"
                             select rut).ToList();
                if (rutas.Count > 0)
                {
                    foreach (var r in rutas)
                    {
                        _entRuta.IdRuta = r.ID_RUTA;
                        _entRuta.CveRuta = r.CVE_RUTA.ToUpper() + "/" + r.MES;
                        //_entRuta.Mes = r.MES;
                        _listaRuta.Add(_entRuta);
                        _entRuta = new EntRuta();
                    }
                }
            }
            catch
            {
                throw new Exception("No existen rutas para esta linea de Transporte");
            }
            finally
            {
                dc.Connection.Close();
            }
            return _listaRuta;
        }

        public int AgregarRutaNueva(EntRuta pEntRuta)
        {
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            int success = -1;
            try
            {
                success = (dc.spIns_GenerarRuta(pEntRuta.IdTransportista,
                    pEntRuta.Entcedis.IdCedis, 
                    pEntRuta.CveRuta, 
                    pEntRuta.IdCamion,
                    pEntRuta.Mes,
                    pEntRuta.FechaEmbarque));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }

            return success;
        }

        public bool BuscaRutaMes(int idTransp,string cveRuta, string mes)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool existe = false;
            try
            {
                var rutames = (from ruta in dc.CAT_RUTA
                               where ruta.CVE_RUTA == cveRuta
                                   && ruta.MES == mes
                                   && ruta.ID_TRANSP==idTransp
                               select ruta).SingleOrDefault();
                if (rutames != null)
                {
                    existe = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return existe;
        }

        public List<EntRuta> RegresaRutasPorClave(string cveRuta, int IdTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entRuta = new EntRuta();
            _listaRuta = new List<EntRuta>();
            try
            { 
            var rutas=(from r in dc.CAT_RUTA
                           where r.ID_TRANSP==IdTransp
                           && r.CVE_RUTA==cveRuta
                           && r.ESTATUS=="VIGENTE"
                           select r) .ToList();
            if (rutas.Count > 0)
            {
                foreach (var ru in rutas)
                {
                    _entRuta.CveRuta = ru.CVE_RUTA;
                    _entRuta.IdRuta = ru.ID_RUTA;
                    _entRuta.Mes = ru.MES;
                    _listaRuta.Add(_entRuta);
                    _entRuta = new EntRuta();
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
            return _listaRuta;
        }
        /// <summary>
        /// Algunos parametros de las propiedades  no son correctas por cuestiones de tiempo
        /// se creara una entidad para devolver los nombres por fleximibildad.
        /// </summary>
        /// <param name="idTransp"></param>
        /// <param name="cveRuta"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        public List<EntRuta> RegresaDetalleRutaCve(int idTransp,string cveRuta, string mes)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entRuta = new EntRuta();
            _listaRuta = new List<EntRuta>();
            try
            {
                var detRuta = (dc.spSel_DetalleRuta(idTransp, cveRuta, mes)).ToList();
                if (detRuta.Count > 0)
                {          
                    
                    foreach (var r in detRuta)
                    {
                        _entRuta.Nombre = r.NOMBRE.ToUpper() + " " + r.APE_PAT.ToUpper() + " " + r.APE_MAT.ToUpper();
                        _entRuta.LlegadaCedis =(DateTime) r.LLEGADACEDIS;
                        _entRuta.SalidaCedis = (DateTime)r.SALIDACEDIS;
                        _entRuta.Cve_INE = r.CVE_PACIENTE.ToString();
                        _entRuta.FechaEntrega = (DateTime)(r.FECHA_LLEGADA==null?new DateTime(2000,1,1):r.FECHA_LLEGADA);
                        _entRuta.FechaVencimiento = (DateTime)(r.FECHA_SALIDA == null ? new DateTime(2000, 1, 1) : r.FECHA_SALIDA); 
                        _entRuta.Gpsweb = r.ESTATUS_ENTREGA;
                        _entRuta.Usuarioweb = r.MOT_CANCELACION;
                        _listaRuta.Add(_entRuta);
                        _entRuta = new EntRuta();

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
            return _listaRuta;
        }

        public List<EntRuta> RegresaCatalogosRutas(int idTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaRuta = new List<EntRuta>();
            try
            {
                var rutas = (from lista in dc.vCatalogoRutas
                             where lista.ID_TRANSP == idTransp
                             select lista).ToList();
                if (rutas.Count > 0)
                {
                    foreach (var r in rutas)
                    {
                        _entRuta = new EntRuta();
                        _entRuta.CveRuta = r.CVE_RUTA;
                        _entRuta.CedisOrigen = r.CEDIS;
                        _entRuta.Mes = r.MES;
                        _listaRuta.Add(_entRuta);
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
            return _listaRuta;
        }

        
    }
}
