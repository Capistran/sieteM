using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntPedido
    {
        public EntPedido()
        { 
        
        }

        private EntUsuarios _eusuario = new EntUsuarios();

        public EntUsuarios Eusuario
        {
            get { return _eusuario; }
            set { _eusuario = value; }
        }

        private EntRuta _eruta = new EntRuta();

        public EntRuta Eruta
        {
            get { return _eruta; }
            set { _eruta = value; }
        }

        private EntPacientes _ePaciente = new EntPacientes();

        public EntPacientes EPaciente
        {
            get { return _ePaciente; }
            set { _ePaciente = value; }
        }


        private EntProducto _eProducto = new EntProducto();

        public EntProducto EProducto
        {
            get { return _eProducto; }
            set { _eProducto = value; }
        }

        private string _observacion = string.Empty;

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        private DateTime _fechaEntrega = new DateTime();

        public DateTime FechaEntrega
        {
            get { return _fechaEntrega; }
            set { _fechaEntrega = value; }
        }

        private List<EntProducto> _ProductosPedido = new List<EntProducto>();

        public List<EntProducto> ProductosPedido
        {
            get { return _ProductosPedido; }
            set { _ProductosPedido = value; }
        }

        private bool _habilitado = false;

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        private int _idPedido = 0;

        public int IdPedido
        {
            get { return _idPedido; }
            set { _idPedido = value; }
        }

        private int _cantidadCaja = 0;

        public int CantidadCaja
        {
            get { return _cantidadCaja; }
            set { _cantidadCaja = value; }
        }
        private int _cantidadPaqutes = 0;

        public int CantidadPaqutes
        {
            get { return _cantidadPaqutes; }
            set { _cantidadPaqutes = value; }
        }
        private int _cantidadSuelto = 0;

        public int CantidadSuelto
        {
            get { return _cantidadSuelto; }
            set { _cantidadSuelto = value; }
        }

        private string _mesPedido = string.Empty;

        public string MesPedido
        {
            get { return _mesPedido; }
            set { _mesPedido = value; }
        }

        private string _lote = string.Empty;

        public string Lote
        {
            get { return _lote; }
            set { _lote = value; }
        }

    }
}
