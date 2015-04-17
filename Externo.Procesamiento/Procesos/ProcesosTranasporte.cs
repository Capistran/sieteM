using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.Procesamiento.Entidades;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosTranasporte
    {

        ModelExternoDataContext dc=null;
        public ProcesosTranasporte()
        { }

        protected int AgregaLineaTransporte(EntTransportista pTransporte)
        {
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            int success=-1;
            try
            { 
            
                success=(dc.spIns_AltaTransportista(pTransporte.RazonSocial
                    ,pTransporte.RFC_Transportista
                    ,pTransporte.IdEstado
                    ,pTransporte.IdCiudad
                    ,pTransporte.Colonia
                    ,pTransporte.Calle
                    ,pTransporte.NumExt
                    ,pTransporte.NumInt
                    ,0
                    ,pTransporte.CP
                    ,pTransporte.ClaveTransporte));  
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
    }
}
