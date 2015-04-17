using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntTratamiento
    {
        private int _idTratamiento = 0;

        public int IdTratamiento
        {
            get { return _idTratamiento; }
            set { _idTratamiento = value; }
        }
        private string _descTratamiento = string.Empty;

        public string DescTratamiento
        {
            get { return _descTratamiento; }
            set { _descTratamiento = value; }
        }
    }
}
