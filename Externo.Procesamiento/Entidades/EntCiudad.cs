using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntCiudad:EntEstado
    {

        public EntCiudad()
        { }

        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _idCiudad = 0;

        public int IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }
        private int _idEstado = 0;

        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }
        private string _ciudad = string.Empty;

        public string DescCiudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }
    }
}
