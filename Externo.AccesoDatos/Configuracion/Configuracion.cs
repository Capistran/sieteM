using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Externo.AccesoDatos.Configuracion
{
    public static class Configuracion
    {
        public static string strConexion
        {
            get { return ConfigurationManager.AppSettings["pruebas7"]; }
        }
    }
}
