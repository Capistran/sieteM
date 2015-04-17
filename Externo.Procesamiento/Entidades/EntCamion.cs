using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntCamion:EntChofer
    {
        private string _placas = string.Empty;

        public string Placas
        {
            get { return _placas; }
            set { _placas = value; }
        }
        private string _numEconomico = string.Empty;

        public string NumEconomico
        {
            get { return _numEconomico; }
            set { _numEconomico = value; }
        }

        private string _marca = string.Empty;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private string _modelo = string.Empty;
        
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private decimal _capacidadCarga = 0M;

        public decimal CapacidadCarga
        {
            get { return _capacidadCarga; }
            set { _capacidadCarga = value; }
        }

        private string _noPoliza = string.Empty;

        public string NoPoliza
        {
            get { return _noPoliza; }
            set { _noPoliza = value; }
        }

        private string _compañiaSeguro = string.Empty;


        public string CompañiaSeguro
        {
            get { return _compañiaSeguro; }
            set { _compañiaSeguro = value; }
        }

        private DateTime _vigenciaPoliza = new DateTime();

        public DateTime VigenciaPoliza
        {
            get { return _vigenciaPoliza; }
            set { _vigenciaPoliza = value; }
        }

        private int _idCamion = 0;

        public int IdCamion
        {
            get { return _idCamion; }
            set { _idCamion = value; }
        }

        private decimal _codBarras = 0.0M;

        public decimal CodBarras
        {
            get { return _codBarras; }
            set { _codBarras = value; }
        }


    }
}
