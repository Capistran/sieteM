using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    [Serializable]
    public class EntProducto
    {
        private decimal _idProducto = 0.0M;

        public decimal IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }
        private string _clave = string.Empty;

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        private string _marca = string.Empty;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        private string _categoria = string.Empty;

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        private string _descripcion = string.Empty;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private int _pzaporcaja = 0;

        public int Pzaporcaja
        {
            get { return _pzaporcaja; }
            set { _pzaporcaja = value; }
        }
        private decimal _precio = 0.0M;

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private decimal _codBarras = 0.0M;

        public decimal CodBarras
        {
            get { return _codBarras; }
            set { _codBarras = value; }
        }

        private int _paqCaja = 0;

        public int PaqCaja
        {
            get { return _paqCaja; }
            set { _paqCaja = value; }
        }
        private int _piezaPaq = 0;

        public int PiezaPaq
        {
            get { return _piezaPaq; }
            set { _piezaPaq = value; }
        }
        private decimal _precioCaja = 0.0M;

        public decimal PrecioCaja
        {
            get { return _precioCaja; }
            set { _precioCaja = value; }
        }
        private decimal _precioPaquete = 0.0M;

        public decimal PrecioPaquete
        {
            get { return _precioPaquete; }
            set { _precioPaquete = value; }
        }
        private decimal _precioPieza = 0.0M;

        public decimal PrecioPieza
        {
            get { return _precioPieza; }
            set { _precioPieza = value; }
        }

        private int _numCajas = 0;

        public int NumCajas
        {
            get { return _numCajas; }
            set { _numCajas = value; }
        }

        private bool _habPedido = false;

        public bool HabPedido
        {
            get { return _habPedido; }
            set { _habPedido = value; }
        }

        private string _lote = string.Empty;

        public string Lote
        {
            get { return _lote; }
            set { _lote = value; }
        }
        public EntProducto()
        { }

    }
}
