using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntDias
    {
        public EntDias()
        { }

        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _diaSemana = string.Empty;

        public string DiaSemana
        {
            get { return _diaSemana; }
            set { _diaSemana = value; }
        }
    }
}
