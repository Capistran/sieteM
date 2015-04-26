using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.AccesoDatos.Configuracion;
using Externo.Procesamiento.Entidades;
using Externo.AccesoDatos.LinqToSql;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosCamion
    {
        ModelExternoDataContext dc;
        EntCamion _entCamion = null;
        List<EntCamion> _listaCamion = null;
        public ProcesosCamion()
        { }


        public EntCamion ObtenerInformacionCamion(string numeconomico)
        {
            return null;
        }

        public int ActualizarUnidad(EntCamion entCamion)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            int success = -1;
            try
            {
                success = (dc.spUpd_Camion(entCamion.IdTransp
                    , entCamion.NumEconomico
                    , entCamion.Placas
                      , entCamion.Marca
                      , entCamion.Modelo
                      , entCamion.CapacidadCarga
                      , entCamion.NoPoliza
                      , entCamion.CompañiaSeguro
                      , entCamion.VigenciaPoliza
                      , entCamion.CodBarras));
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

        public EntCamion ObtieneInformacionUnidad(string numEcon, int idTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entCamion = new EntCamion();
            try
            {
                var unidad = (from uni in dc.CAT_CAMION
                              where uni.NUM_ECONOMICO == numEcon
                              && uni.ID_TRANSP == idTransp
                              select uni).SingleOrDefault();
                if (unidad != null)
                {
                    _entCamion.Placas = unidad.PLACAS;
                    _entCamion.Modelo = unidad.MODELO;
                    _entCamion.CapacidadCarga = (decimal)unidad.CAP_CARGA;
                    _entCamion.Marca = unidad.MARCA;
                    _entCamion.NoPoliza = unidad.NO_POLIZA;
                    _entCamion.CompañiaSeguro = unidad.COMPAÑIA_SEGURO;
                    _entCamion.CodBarras = (decimal)unidad.COD_BARRAS;
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
            return _entCamion;
        }

        public List<EntCamion> RegresaUnidades(int idTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaCamion = new List<EntCamion>();
            try
            {
                var Unidades = (from unid in dc.CAT_CAMION
                                where unid.ID_TRANSP == idTransp
                                select unid).ToList();
                if (Unidades.Count > 0)
                {
                    foreach (var u in Unidades)
                    {
                        _entCamion = new EntCamion();
                        _entCamion.IdCamion = u.ID_CAMION;
                        _entCamion.Placas = u.PLACAS;
                        _entCamion.Marca = u.MARCA;
                        _entCamion.Modelo = u.MODELO;
                        _entCamion.NumEconomico = u.NUM_ECONOMICO;
                        _entCamion.CapacidadCarga = (decimal)u.CAP_CARGA;
                        _entCamion.NoPoliza = u.NO_POLIZA;
                        _entCamion.VigenciaPoliza = (DateTime)u.VIGENCIA_POLIZA;
                        _listaCamion.Add(_entCamion);
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

            return _listaCamion;
        }

    }
}
