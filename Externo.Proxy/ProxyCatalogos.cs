using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.Proxy.ServCatalogos;


namespace Externo.Proxy
{
    public class ProxyCatalogos
    {
        
        
        SieteMariasClient siete = new SieteMariasClient();
        public ProxyCatalogos()
        { }

        //public List<EntGrupos> RegresaGruposServicio()
        //{
        //    return proxycat.RegresaGrupos();
        //}

        public List<SEntPaciente> Pacientes(int idruta,int idtransp)
        {
            return siete.RegresaPacientesPorRuta(idruta, idtransp);
        }
    }
}
