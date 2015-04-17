using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;

namespace Ext.Web.Vistas
{
    public class vistaTransporte:ProcesosTransporte
    {
        public vistaTransporte()
        { 
        
        }
        ProcesosTransporte prcTransporte = new ProcesosTransporte();

        public int AgregaNuevoTransporte(EntTransportista pTransporte)
        {
            return AgregaLineaTransporte(pTransporte);
        }

        public List<EntTransportista> RegresaLineasTransporte()
        {
            return prcTransporte.RegresaTransporteActivo();
        }

        public bool ExisteTransportistaPorClave(string cveTransporte)
        {
            return ExisteTransportista(cveTransporte);
        }

        public EntTransportista ObtieneTransportistaporClave(string cveTransporte)
        {
            return RegresaTransportistaClave(cveTransporte);
            }

        public int ActualizaTrans(EntTransportista entTransp)
        {
            return ActualizaTransportista(entTransp);
        }
    }
}