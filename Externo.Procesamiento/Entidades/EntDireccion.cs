using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntDireccion:EntCiudad
    {
        private string _colonia = string.Empty;

        public string Colonia
        {
            get { return _colonia; }
            set { _colonia = value; }
        }
        private string _calle = string.Empty;

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }
        private string _numExt = string.Empty;

        public string NumExt
        {
            get { return _numExt; }
            set { _numExt = value; }
        }
        private string _numInt = string.Empty;

        public string NumInt
        {
            get { return _numInt; }
            set { _numInt = value; }
        }
        private string _cP = string.Empty;

        public string CP
        {
            get { return _cP; }
            set { _cP = value; }
        }
        private string _telFijo = string.Empty;

        public string TelFijo
        {
            get { return _telFijo; }
            set { _telFijo = value; }
        }
        private string _tel_Cel = string.Empty;

        public string Tel_Cel
        {
            get { return _tel_Cel; }
            set { _tel_Cel = value; }
        }

        private string _superManzana = string.Empty;

        public string SuperManzana
        {
            get { return _superManzana; }
            set { _superManzana = value; }
        }
        private string _manzana = string.Empty;

        public string Manzana
        {
            get { return _manzana; }
            set { _manzana = value; }
        }
        private string _lote = string.Empty;

        public string Lote
        {
            get { return _lote; }
            set { _lote = value; }
        }
        
    }
}
