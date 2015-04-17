using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;
using Externo.Procesamiento.Entidades;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosChofer
    {
        ModelExternoDataContext dc;
        int _success;
        List<EntChofer> _listaChofer;
        public ProcesosChofer()
        {
            _success = -1;
        }

        protected int AltaChofer(EntChofer pChofer)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                _success=(dc.spIns_AltaChofer(pChofer.IdUsuario
                    , pChofer.IdTransp
                    , pChofer.LicenciaManejo
                    ,pChofer.FechaVigenciaLic
                    ,pChofer.NumEmpleado
                    ,pChofer.Auxiliar));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return _success;
        }

        protected List<EntChofer> RegresaListaChofer(int pIdTransp)
        {
            _listaChofer = new List<EntChofer>();
            EntChofer echofer = new EntChofer();
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                var listach = (from lc in dc.CAT_CHOFER
                               join usr in dc.USR_DATPER
                               on lc.ID_CHOFER equals usr.ID_USUARIO
                               join usuario in dc.USUARIOS
                               on usr.ID_USUARIO equals usuario.ID_USUARIO
                               where lc.ID_TRANSP == pIdTransp
                               && usuario.ESTATUS=="ACTIVO"
                               select new EntChofer { 
                               Nombre=usr.NOMBRE.ToUpper()+" "+usr.APE_PAT.ToUpper()+" "+usr.APE_MAT.ToUpper(),
                               IdUsuario=lc.ID_CHOFER,
                               RFC=usr.RFC,
                               Auxiliar=lc.AUXILIAR,
                               NumEmpleado=lc.NUM_EMPLEADO

                               }).ToList();
                if (listach.Count > 0)
                {
                    foreach (var l in listach)
                    {
                        echofer.IdUsuario = l.IdUsuario;
                        echofer.Nombre = l.Nombre;
                        echofer.RFC = l.RFC;
                        if (l.Auxiliar == "N")
                            echofer.Auxiliar = "AUXILIAR";
                        else
                            echofer.Auxiliar = "OPERADOR";
                        echofer.NumEmpleado = l.NumEmpleado;
                        _listaChofer.Add(echofer);
                        echofer = new EntChofer();
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
            return _listaChofer;
        }

        protected int AltaTransporte(EntCamion pCamion)
        {
            _success = -1;
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                _success =(dc.spIns_AltaCamion(pCamion.IdTransp,pCamion.IdUsuario,pCamion.Placas
                    ,pCamion.NumEconomico
                    ,pCamion.Marca
                    ,pCamion.Modelo
                    ,pCamion.CapacidadCarga
                    ,pCamion.NoPoliza
                    ,pCamion.CompañiaSeguro
                    ,pCamion.VigenciaPoliza
                    ,pCamion.CodBarras));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                dc.Connection.Close();
            }
            return _success;
        }

        protected EntChofer BuscaInforOperador(string numempleado)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntChofer _operador = new EntChofer();
            try
            {
                var operadorinfo = (dc.spSel_BuscaInfoOperador(numempleado)).SingleOrDefault();
                if (operadorinfo != null)
                {
                    _operador.LicenciaManejo = operadorinfo.NUM_LIC_MAN;
                    _operador.FechaVigenciaLic = (DateTime)operadorinfo.VIGENCIA_LIC;
                    _operador.Auxiliar = operadorinfo.AUXILIAR;
                   _operador.NombreChofer=operadorinfo.NOMBRE;
                   _operador.ApePat = operadorinfo.APE_PAT;
                   _operador.ApeMat = operadorinfo.APE_MAT;
                   _operador.IdEstado = (int)operadorinfo.ESTADO;
                   _operador.IdCiudad = (int)operadorinfo.CIUDAD;
                   _operador.Colonia = operadorinfo.COLONIA;
                   _operador.CP = operadorinfo.CP;
                   _operador.Calle = operadorinfo.CALLE;
                   _operador.NumExt = operadorinfo.NUM_EXT;
                   _operador.NumInt = operadorinfo.NUM_INT;
                   _operador.TelFijo = operadorinfo.TEL_CASA;
                   _operador.Tel_Cel = operadorinfo.TEL_CEL;
                   _operador.NSS = operadorinfo.NSS;
                   _operador.Cve_INE = operadorinfo.CVE_INE;
                   _operador.RFC = operadorinfo.RFC;
                   //_operador.IdEstado = (int)operadorinfo.ESTADO;
                   //_operador.IdCiudad = (int)operadorinfo.CIUDAD;
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
            return _operador;
        }

        protected bool ExisteOperadorporTransportista(string numemplado, int idTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success=false;
            try             
            {
                var Operadores = (from oper in dc.CAT_CHOFER
                                  where oper.ID_TRANSP == idTransp
                                  && oper.NUM_EMPLEADO == numemplado
                                  select oper).SingleOrDefault();
                if (Operadores != null)
                    return true;
                
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

        protected int ActualizaOperador(EntChofer eChofer)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);

            try 
            {
                _success = (dc.spUpd_Operador(eChofer.IdTransp,
                    eChofer.NumEmpleado,
                    eChofer.LicenciaManejo,
                    eChofer.FechaVigenciaLic,
                    eChofer.Auxiliar,
                    eChofer.NombreChofer,
                    eChofer.ApePat,
                    eChofer.ApeMat,
                        eChofer.RFC,
                        eChofer.Cve_INE,
                        eChofer.IdEstado,
                        eChofer.IdCiudad,
                        eChofer.Colonia,
                        eChofer.CP,
                        eChofer.Calle,
                        eChofer.NumExt,
                        eChofer.NumInt,
                        eChofer.TelCasa,
                        eChofer.Tel_Cel,
                        eChofer.NSS,
                        eChofer.SuperManzana,
                        eChofer.Manzana,
                        eChofer.Lote));
                        
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

            return _success;
        }

        protected bool BajaOperador(int idOperador, int idTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                var operador = (from usuario in dc.USUARIOS
                                where usuario.ID_USUARIO == idOperador
                                && usuario.ID_TRANSP == idTransp
                                select usuario).SingleOrDefault();
                if (operador != null)
                {
                    operador.ESTATUS = "INACTIVO";
                    dc.SubmitChanges();
                    success = true;
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
    }
}
