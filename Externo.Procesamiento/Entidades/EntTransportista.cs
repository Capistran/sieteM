using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntTransportista:EntDireccion
    {
        private EntCedis _entcedis = new EntCedis();

        public EntCedis Entcedis
        {
            get { return _entcedis; }
            set { _entcedis = value; }
        }

        private string _razonSocial = string.Empty;

        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }
        private string _RFC_Transportista = string.Empty;

        public string RFC_Transportista
        {
            get { return _RFC_Transportista; }
            set { _RFC_Transportista = value; }
        }

        private string _claveTransporte = string.Empty;

        public string ClaveTransporte
        {
            get { return _claveTransporte; }
            set { _claveTransporte = value; }
        }

        private string _usuarioweb = string.Empty;

        public string Usuarioweb
        {
            get { return _usuarioweb; }
            set { _usuarioweb = value; }
        }

        private string _passwordweb = string.Empty;

        public string Passwordweb
        {
            get { return _passwordweb; }
            set { _passwordweb = value; }
        }

        private string _gpsweb = string.Empty;

        public string Gpsweb
        {
            get { return _gpsweb; }
            set { _gpsweb = value; }
        }

        private int _idTransportista = 0;

        public int IdTransportista
        {
            get { return _idTransportista; }
            set { _idTransportista = value; }
        }

        private string _nombreComercial = string.Empty;

        public string NombreComercial
        {
            get { return _nombreComercial; }
            set { _nombreComercial = value; }
        }


    }
}
