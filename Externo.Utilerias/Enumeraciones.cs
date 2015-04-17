using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Utilerias
{
    public class Enumeraciones
    {
        public enum TipoUsuario
        { 
            SuperAdmin=1,
            SubAdmini=2,
            Consulta=3
        }

        public enum TipoOperador
        { 
            Principal=1,
            Auxiliar=2
        }
    }
}
