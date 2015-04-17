using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntChofer:EntUsuarios
    {
        

        private string _nombreChofer = string.Empty;

        public string NombreChofer
        {
            get { return _nombreChofer; }
            set { _nombreChofer = value; }
        }

        private DateTime _fechaVigenciaLic = new DateTime();

        public DateTime FechaVigenciaLic
        {
            get { return _fechaVigenciaLic; }
            set { _fechaVigenciaLic = value; }
        }

        private string _numEmpleado = string.Empty;

        public string NumEmpleado
        {
            get { return _numEmpleado; }
            set { _numEmpleado = value; }
        }

        private string _auxiliar = string.Empty;

        public string Auxiliar
        {
            get { return _auxiliar; }
            set { _auxiliar = value; }
        }

        
    }
}
