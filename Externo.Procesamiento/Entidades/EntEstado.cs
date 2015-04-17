using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntEstado
    {

        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _estado = string.Empty;

        public string DesEstado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public EntEstado()
        { }
    }
}
