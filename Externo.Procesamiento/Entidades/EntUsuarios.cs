using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntUsuarios:EntTransportista
    {
        private int _idUsuario = 0;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        private string _nombre = string.Empty;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apePat = string.Empty;

        public string ApePat
        {
            get { return _apePat; }
            set { _apePat = value; }
        }
        private string _apeMat = string.Empty;

        public string ApeMat
        {
            get { return _apeMat; }
            set { _apeMat = value; }
        }
        private string _contraseña = string.Empty;

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        private string _email = string.Empty;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private int _grupo = 0;

        public int Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
        private int _idTransp = 0;

        public int IdTransp
        {
            get { return _idTransp; }
            set { _idTransp = value; }
        }

        private string _rFC = string.Empty;

        public string RFC
        {
            get { return _rFC; }
            set { _rFC = value; }
        }
        private string _cve_INE = string.Empty;

        public string Cve_INE
        {
            get { return _cve_INE; }
            set { _cve_INE = value; }
        }
        private int _estado = 0;

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private int _ciudad = 0;

        public int Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }
        private string _descEstado = string.Empty;

        public string DescEstado
        {
            get { return _descEstado; }
            set { _descEstado = value; }
        }
        private string _descCiudad = string.Empty;

        public string DescCiudad
        {
            get { return _descCiudad; }
            set { _descCiudad = value; }
        }
        private string _colonia = string.Empty;

        public string Colonia
        {
            get { return _colonia; }
            set { _colonia = value; }
        }
        private string _cP = string.Empty;

        public string CP
        {
            get { return _cP; }
            set { _cP = value; }
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
        private string _telCasa = string.Empty;

        public string TelCasa
        {
            get { return _telCasa; }
            set { _telCasa = value; }
        }
        private string _tel_cel = string.Empty;

        public string Tel_cel
        {
            get { return _tel_cel; }
            set { _tel_cel = value; }
        }

        private string _licencia = string.Empty;

        public string LicenciaManejo
        {
            get { return _licencia; }
            set { _licencia = value; }
        }

        private string _nSS = string.Empty;

        public string NSS
        {
            get { return _nSS; }
            set { _nSS = value; }
        }

        
    }
}
