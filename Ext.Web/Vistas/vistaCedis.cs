using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;
namespace Ext.Web.Vistas
{
    public class vistaCedis
    {

        ProcesosCedis prcCedis= new ProcesosCedis();

        public vistaCedis()
        { }

        ~vistaCedis()
        { }


        public EntCedis InformacionCedisClave(string cveCedis)
        {
            return prcCedis.RegresaInfoCedisClave(cveCedis);
        }

        public int NuevoCedis(EntCedis entcedis)
        {
            return prcCedis.AltaCedis(entcedis);
        }

        public int ActualizaCedis(EntCedis entcedis)
        {
            return prcCedis.ActualizaCedis(entcedis);
        }
    }
}