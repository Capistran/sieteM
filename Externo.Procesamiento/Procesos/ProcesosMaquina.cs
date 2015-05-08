using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.Procesamiento.Entidades;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosMaquina
    {
        ModelExternoDataContext dc;

        public int AgregarMaquina(int idPaciente,decimal noserie)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            int _success = -1;
            try
            { 
                _success=(dc.spIns_AltaHomeChoice(idPaciente,noserie,true,true));
                //var reemplazo = (dc.spEntregarMaquina(idPaciente,noserie));
                //if (reemplazo != 0)
                //    return -1;
            }
            catch(Exception ex)
            { 
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

        public EntMaquina RegresaMaquina(int idPaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntMaquina entMaquina = new EntMaquina();
            try
            {
                var maqHC = (from hc in dc.HOME_CHOICE
                             where hc.ID_PACIENTE == idPaciente
                             select hc).SingleOrDefault();
                if (maqHC != null)
                {
                    entMaquina.IdMaquina = maqHC.ID;
                    entMaquina.NoSerie = (decimal)maqHC.NO_SERIE;
                    entMaquina.SerieActual = (decimal)maqHC.NO_SERIE_REEMPLAZO;
                }
            }
            catch (Exception ex)
            {
                dc.Connection.Close();
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return entMaquina;
        }

        public bool ActualizarSerieHomeChoice(int idPaciente, decimal noserie)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                //var noserieAnt = (from hca in dc.HOME_CHOICE
                //                  where hca.ID_PACIENTE == idPaciente
                //                  select hca.NO_SERIE).SingleOrDefault();

                //if (noserieAnt < 0 || noserieAnt == null)
                //    return false;


                //var reemplazo =(dc.spReemplazarMaquina(idPaciente,noserieAnt,noserie));
                //if(reemplazo!=0)
                //    return false;

                //success=true;
                var HC = (from hc in dc.HOME_CHOICE
                          where hc.ID_PACIENTE == idPaciente
                          select hc).SingleOrDefault();
                if (HC != null)
                {
                    HC.NO_SERIE_REEMPLAZO = noserie;
                    dc.SubmitChanges();
                    success = true;
                }
                
            }
            catch(Exception ex)
            {
                dc.Connection.Close();
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return success;
        }

        public bool TieneMaquinaRegistrada(int idPaciente)
        {
            bool succes = false;
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                var existe = (from hc in dc.HOME_CHOICE
                              where hc.ID_PACIENTE == idPaciente
                              select hc).SingleOrDefault();

                if (existe != null)
                {
                    succes = true;
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
            return succes;
        }

        public List<EntMaquina> RegresaHistorialMaquina(int idPaciente)
        {
            List<EntMaquina> listaMaquina = new List<EntMaquina>();
            EntMaquina maquina = new EntMaquina();
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {

                var historial = (from hist in dc.HISTORIAL_HOME_CHOICE
                                 where hist.ID_PACIENTE == idPaciente
                                 select hist).ToList();

                if (historial.Count > 0)
                {
                    foreach (var h in historial)
                    {
                        maquina = new EntMaquina();
                        maquina.SerieActual = (decimal)(h.NO_SERIE_ACTUAL == null ? 0 : h.NO_SERIE_ACTUAL);
                        maquina.SerieAnterior = (decimal)(h.NO_SERIE_ANTERIOR == null ? 0 : h.NO_SERIE_ANTERIOR);
                        maquina.TipoMovimiento = h.TIPO_MOVIMIENTO;
                        maquina.FechaEntrega = (DateTime)h.FECHA_ENTREGA;
                        listaMaquina.Add(maquina);
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
            return listaMaquina;
        }
    }
}
