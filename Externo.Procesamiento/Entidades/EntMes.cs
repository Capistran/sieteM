using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntMes
    {
        public EntMes()
        { }

        private int idMes = 0;

        public int IdMes
        {
            get { return idMes; }
            set { idMes = value; }
        }
        private string _nombreMes = string.Empty;

        public string NombreMes
        {
            get { return _nombreMes; }
            set { _nombreMes = value; }
        }
    }
}
