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
                var HC = (from hc in dc.HOME_CHOICE
                          where hc.NO_SERIE == noserie 
                          select hc).SingleOrDefault();
                if (HC != null)
                {
                    HC.NO_SERIE = noserie;
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
    }
}
