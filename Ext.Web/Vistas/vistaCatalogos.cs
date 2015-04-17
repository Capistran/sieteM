using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Procesos;
using Externo.Procesamiento.Entidades;
namespace Ext.Web.Vistas
{
    public class vistaCatalogos
    {
        ProcesosCatalogos prcCatalogos;
        
        public vistaCatalogos()
        {
            prcCatalogos = new ProcesosCatalogos();
        }

        public List<EntTratamiento> RegresaTratamientos()
        {
            return prcCatalogos.ListaTratamiento();
        }

        public List<EntEstado> RegresaEstados()
        {
            return prcCatalogos.RegresaEstados();
        }

        public List<EntCiudad> RegresaCiudadesxEstado(int idEstado)
        {
            return prcCatalogos.RegresaCiudadPorEstado(idEstado);
        }

        public List<EntDias> RegresaDias()
        {
            return prcCatalogos.RegresaDiaVisita();
        }

        public List<EntCamion> RegresaTransportePorTransportista(int idTransportista)
        {
            return prcCatalogos.RegresaCamionesPorTransportista(idTransportista);
        }

        public List<EntCedis> RegresaListaCedis()
        {
            return prcCatalogos.RegresaCedis();
        }

        public List<EntRuta> RegresaRutasVigentes(int idTransportista)
        {
            return prcCatalogos.RegresaRutaVigente(idTransportista);
        }
    }
}