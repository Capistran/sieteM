using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.Procesamiento.Entidades;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosTransporte
    {

        ModelExternoDataContext dc=null;
        bool _success = false;
        
        public ProcesosTransporte()
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
                    ,pTransporte.ClaveTransporte,
                    "ACTIVO"
                    ,pTransporte.Usuarioweb
                    ,pTransporte.Passwordweb
                    ,pTransporte.Gpsweb
                    ,pTransporte.NombreComercial));  
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

        public List<EntTransportista> RegresaTransporteActivo()
        {
            List<EntTransportista> listaTransporte = new List<EntTransportista>();
            EntTransportista transporte = new EntTransportista();
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                var listat = (from tra in dc.vTransportistaActivo select tra).ToList();
                if (listat.Count > 0)
                {
                    foreach (var l in listat)
                    {
                        transporte.IdTransportista = l.ID_TRANSP;
                        transporte.ClaveTransporte=l.CVE_TRANSP;
                        transporte.RazonSocial=l.RAZON_SOCIAL;
                        transporte.RFC_Transportista = l.RFC;
                        transporte.DesEstado = l.ESTADO;
                        transporte.DescCiudad = l.DESC_CIUDAD;
                        listaTransporte.Add(transporte);
                        transporte = new EntTransportista();

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
            return listaTransporte;
        }

        protected bool ExisteTransportista(string cveTransporte)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            
            try
            {
                var transportista = (from trans in dc.CAT_TRANSPORTISTA
                                     where trans.CVE_TRANSP == cveTransporte
                                     select trans).SingleOrDefault();
                if (transportista != null)
                    _success = true;
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

        protected int ActualizaTransportista(EntTransportista _entTransporte)
        {
            int actualiza =-1;
            try
            {
                actualiza = (dc.spUpd_ActualizaTransportista(_entTransporte.IdTransportista,
                    _entTransporte.ClaveTransporte,
                    _entTransporte.RazonSocial,
                    _entTransporte.RFC_Transportista,
                    _entTransporte.IdEstado,
                    _entTransporte.IdCiudad,
                    _entTransporte.Colonia,
                    _entTransporte.Calle,
                    _entTransporte.NumExt,
                    _entTransporte.NumInt,
                    0,
                    _entTransporte.CP,
                    "",
                    _entTransporte.Usuarioweb,
                    _entTransporte.Passwordweb, 
                    _entTransporte.Gpsweb,
                    _entTransporte.SuperManzana,
                    _entTransporte.Manzana,
                    _entTransporte.Lote
                    ,_entTransporte.NombreComercial));
                    
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
            return actualiza;
        }

        protected EntTransportista RegresaTransportistaClave(string cveTransporte)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntTransportista entTransporte = new EntTransportista();
            try
            {
                var transporte = (from tra in dc.CAT_TRANSPORTISTA
                                  where tra.CVE_TRANSP==cveTransporte
                                  && tra.ESTATUS=="ACTIVO"
                                  select tra).SingleOrDefault();
                if (transporte != null)
                {
                    entTransporte.IdTransportista = transporte.ID_TRANSP;
                    entTransporte.RazonSocial = transporte.RAZON_SOCIAL;
                    entTransporte.RFC_Transportista = transporte.RFC;
                    entTransporte.IdEstado = (int)transporte.ESTADO;
                    entTransporte.IdCiudad = (int)transporte.CIUDAD;                    
                    entTransporte.Colonia = transporte.COLONIA;
                    entTransporte.Calle = transporte.CALLE;
                    entTransporte.NumInt = transporte.NUM_INT;
                    entTransporte.NumExt = transporte.NUM_EXT;
                    entTransporte.CP = transporte.cp;
                    entTransporte.Usuarioweb = transporte.USUARIOWEB;
                    entTransporte.Passwordweb = transporte.PASSWORDWEB;
                    entTransporte.Gpsweb = transporte.GPSWEB;
                    entTransporte.Manzana = transporte.MANZANA;
                    entTransporte.SuperManzana = transporte.SUPER_MAN;
                    entTransporte.Lote = transporte.LOTE;
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
            return entTransporte;
        }

        ~ProcesosTransporte()
        { }
    }
}
