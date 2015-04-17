using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntCedis:EntDireccion
    {
        private int _idCedis = 0;

        public int IdCedis
        {
            get { return _idCedis; }
            set { _idCedis = value; }
        }
        private string _nombreCedis = string.Empty;

        public string NombreCedis
        {
            get { return _nombreCedis; }
            set { _nombreCedis = value; }
        }
        private string _descripcion = string.Empty;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _cveCedis = string.Empty;

        public string CveCedis
        {
            get { return _cveCedis; }
            set { _cveCedis = value; }
        }
    }
}
