using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;
namespace Ext.Web.Vistas
{
    public class vistaRutas
    {
        ProcesosRutas prcRutas = new ProcesosRutas();
        public List<EntRuta> vistaRegresaRutasporTransportista(int idTransportista)
        {
            return prcRutas.RegresaRutasPorTransportista(idTransportista);
        }

        public List<EntPacientes> vistaRegresaPacientesPorRuta(int pidRuta, int pidTransportista)
        {
            return prcRutas.RegresaPacientesRuta(pidRuta, pidTransportista);
        }

        public int NuevaRuta(EntRuta pRuta)
        {
            return prcRutas.AgregarRutaNueva(pRuta);
        }

        public EntRuta RegresaDetalleRuta(int idRuta)
        {
            return prcRutas.RegresaDetalleRuta(idRuta);
        }

        public bool ExsteRutaMes(int idTransp,string cveRuta, string mes)
        {
            return prcRutas.BuscaRutaMes(idTransp,cveRuta, mes);
        }

        public List<EntRuta> RegresaRutasPorClave(string cveRuta, int idTransp)
        {
            return prcRutas.RegresaRutasPorClave(cveRuta, idTransp);
        }

        public List<EntRuta> RegresaDetalleRutaClave(int IdTransp, string cve_ruta, string mes)
        {
            return prcRutas.RegresaDetalleRutaCve(IdTransp, cve_ruta, mes);
        }

        public List<EntRuta> RegresaCatalogoRutas(int idTransp)
        {
            return prcRutas.RegresaCatalogosRutas(idTransp);
        }
    }
}