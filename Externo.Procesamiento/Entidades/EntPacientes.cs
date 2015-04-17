using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntPacientes: EntDireccion
    {

        public EntPacientes()
        {}

        private int _idTratamiento = 0;

        public int IdTratamiento
        {
            get { return _idTratamiento; }
            set { _idTratamiento = value; }
        }

        private int _idContacto = 0;

        public int IdContacto{
        
            get { return _idContacto; }
            set { _idContacto = value; }
        }
        private string _ape_Pat = string.Empty;

        public string Ape_Pat
        {
            get { return _ape_Pat; }
            set { _ape_Pat = value; }
        }
        private string _ape_Mat = string.Empty;

        public string Ape_Mat
        {
            get { return _ape_Mat; }
            set { _ape_Mat = value; }
        }
        private string _numRecepcion = string.Empty;

        public string NumRecepcion
        {
            get { return _numRecepcion; }
            set { _numRecepcion = value; }
        }
        private string _nSS = string.Empty;

        public string NSS
        {
            get { return _nSS; }
            set { _nSS = value; }
        }
        private string _frecVisita = string.Empty;

        public string FrecVisita
        {
            get { return _frecVisita; }
            set { _frecVisita = value; }
        }
        private int _diaVisita = 0;

        public int DiaVisita
        {
            get { return _diaVisita; }
            set { _diaVisita = value; }
        }

        /*
        private string _calle = string.Empty;

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }
        private string _numInt = string.Empty;

        public string NumInt
        {
            get { return _numInt; }
            set { _numInt = value; }
        }
        private string _numExt = string.Empty;

        public string NumExt
        {
            get { return _numExt; }
            set { _numExt = value; }
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
        private int _ciudad = 0;

        public int Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }
        private int _estado = 0;

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
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
          
         */
        private string _cveINE = string.Empty;

        public string CveINE
        {
            get { return _cveINE; }
            set { _cveINE = value; }
        }
        private string _estatus = string.Empty;

        public string Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        private int _idPaciente = 0;

        public int IdPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }
        private string _nombre = string.Empty;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private float _latitud = 0.0f;

        public float Latitud
        {
            get { return _latitud; }
            set { _latitud = value; }
        }
        private float _longitud = 0.0F;

        public float Longitud
        {
            get { return _longitud; }
            set { _longitud = value; }
        }

        private string _estatus_entrega = String.Empty;

        public string Estatus_entrega
        {
            get { return _estatus_entrega; }
            set { _estatus_entrega = value; }
        }

        private decimal _cvePaciente = 0M;

        public decimal CvePaciente
        {
            get { return _cvePaciente; }
            set { _cvePaciente = value; }
        }

        private string _motCancelacion = string.Empty;

        public string MotCancelacion
        {
            get { return _motCancelacion; }
            set { _motCancelacion = value; }
        }

        private string _institucion = string.Empty;

        public string Institucion
        {
            get { return _institucion; }
            set { _institucion = value; }
        }

        private DateTime _horaLlegada = new DateTime(2000,1,1);

        public DateTime HoraLlegada
        {
            get { return _horaLlegada; }
            set { _horaLlegada = value; }
        }
        private DateTime _horaSalida = new DateTime(2000,1,1);

        public DateTime HoraSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }
    }
}
