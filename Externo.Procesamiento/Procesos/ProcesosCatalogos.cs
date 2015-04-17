using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.AccesoDatos.LinqToSql;
using Externo.AccesoDatos.Configuracion;
using Externo.Procesamiento.Entidades;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosCatalogos
    {
        List<EntEstado> _listaEstados;
        List<EntCiudad> _listaCiudad;
        List<EntDias> _lsitadias;
        List<EntCamion> _listaCamion;
        List<EntTransportista> _listaTransportista;
        List<EntCedis> _listaCedis;
        List<EntRuta> _listaRuta;
        EntEstado _estado;
        EntCiudad _ciudad=null;
        EntDias _dias=null;
        EntCamion _entCamion=null;
        EntTransportista _entTransportista=null;
        EntTratamiento _enttratamiento = null;
        EntRuta _entRuta = null;

        ModelExternoDataContext dc;
        public ProcesosCatalogos()
        {
        
        }

        public List<EntTratamiento> ListaTratamiento()
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _enttratamiento = new EntTratamiento();
            List<EntTratamiento> listaTratamiento = new List<EntTratamiento>();
            try 
            {
                var listatrat = (from tr in dc.CAT_TRATAMIENTO
                                 select tr).ToList();
                if (listatrat.Count > 0)
                {
                    foreach (var l in listatrat)
                    {
                        _enttratamiento.IdTratamiento = l.ID_TRAT;
                        _enttratamiento.DescTratamiento = l.DESC_TRAT;
                        listaTratamiento.Add(_enttratamiento);
                        _enttratamiento = new EntTratamiento();
                    }
                }
            }
            catch
            { }
            finally
            {
                dc.Connection.Close();
            }

            return listaTratamiento;
        }

        public List<EntEstado> RegresaEstados()
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _estado = new EntEstado();
            _listaEstados = new List<EntEstado>();
            try
            {
                var estados = (from est in dc.ESTADOS select est).ToList();
                if (estados.Count>0)
                { 
                    foreach(var e in estados)
                    {
                        _estado.Id = e.ID;
                        _estado.DesEstado = e.ESTADO;
                        _listaEstados.Add(_estado);
                        _estado = new EntEstado();

                    }
                }
            }
            catch
            { }
            finally
            {
                dc.Connection.Close();
            }
            return _listaEstados;
        }

        public List<EntCiudad> RegresaCiudadPorEstado(int pIdEstado)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaCiudad = new List<EntCiudad>();
            _ciudad = new EntCiudad();
            try
            {
                var ciudades = (from ciu in dc.CIUDAD
                                where ciu.ID_ESTADO == pIdEstado
                                select ciu).ToList();
                if (ciudades.Count > 0)
                {
                    foreach (var c in ciudades)
                    {
                        _ciudad.IdCiudad = c.ID_CIUDAD;
                        _ciudad.DescCiudad = c.DESC_CIUDAD;
                        _listaCiudad.Add(_ciudad);
                        _ciudad = new EntCiudad();
                    }
                }
            }
            catch
            { }
            finally
            {

                dc.Connection.Close();
            }
            return _listaCiudad;

        }

        public List<EntDias> RegresaDiaVisita()
        {
            _dias=new EntDias();
            _lsitadias = new List<EntDias>();
            try
            {
                var diassemana = (from dia in dc.DIAS
                                  select dia).ToList();
                if (diassemana.Count > 0)
                {
                    foreach (var d in diassemana)
                    {
                        _dias.Id = d.ID;
                        _dias.DiaSemana = d.DIA;
                        _lsitadias.Add(_dias);
                        _dias = new EntDias();
                    }
                }
            }
            catch
            {
                
            }
            finally
            {
                dc.Connection.Close();
            }

            return _lsitadias;
        }

        public List<EntCamion> RegresaCamionesPorTransportista(int idTransportista)
        {
            _entCamion = new EntCamion();
            _listaCamion = new List<EntCamion>();
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                var camiones = (from cam in dc.CAT_CAMION
                                where cam.ID_TRANSP==idTransportista
                                select cam ).ToList();

                if (camiones.Count > 0)
                {
                    foreach (var c in camiones)
                    {
                        _entCamion.IdCamion = c.ID_CAMION;
                        _entCamion.Modelo = c.MARCA + "-" + c.MODELO;
                        _listaCamion.Add(_entCamion);
                        _entCamion = new EntCamion();
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

            return _listaCamion;

        }

        public List<EntCedis> RegresaCedis()
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntCedis entcedis = new EntCedis();
            _listaCedis = new List<EntCedis>();
            try
            { 
                var lstCedis=(from cedis in dc.CAT_CEDIS
                                  where cedis.ESTATUS=="VIGENTE"
                                  select cedis).ToList();
                if (lstCedis.Count > 0)
                {
                    foreach(var c in lstCedis)
                    {
                        entcedis.IdCedis = c.ID_CEDIS;
                        entcedis.NombreCedis = c.NOMBRE;
                        _listaCedis.Add(entcedis);
                        entcedis = new EntCedis();
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
            return _listaCedis;
        }

        public List<EntRuta> RegresaRutaVigente(int idTransportista)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaRuta = new List<EntRuta>();
            _entRuta = new EntRuta();
            try
            {
                var rutasvigentes = (from rutas in dc.CAT_RUTA
                                     where rutas.ID_TRANSP == idTransportista && rutas.ESTATUS == "VIGENTE"
                                     select rutas).ToList();
                if (rutasvigentes.Count > 0)
                {
                    foreach (var r in rutasvigentes)
                    {
                        _entRuta.IdRuta = r.ID_RUTA;
                        _entRuta.CveRuta = r.CVE_RUTA;
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
    }
}
