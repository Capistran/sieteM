using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntMaquina
    {
        private int _idMaquina = 0;

        public int IdMaquina
        {
            get { return _idMaquina; }
            set { _idMaquina = value; }
        }
        private decimal _NoSerie =0.0M;

        public decimal NoSerie
        {
            get { return _NoSerie; }
            set { _NoSerie = value; }
        }

        private bool _manual = false;

        public bool Manual
        {
            get { return _manual; }
            set { _manual = value; }
        }
        private bool _pinzas = false;

        public bool Pinzas
        {
            get { return _pinzas; }
            set { _pinzas = value; }
        }

        private DateTime _FechaEntrega = new DateTime();

        public DateTime FechaEntrega
        {
            get { return _FechaEntrega; }
            set { _FechaEntrega = value; }
        }

        private string _tipoMovimiento = string.Empty;
        
        public string TipoMovimiento
        {
            get { return _tipoMovimiento; }
            set { _tipoMovimiento = value; }
        }

        private decimal _serieAnterior = 0.0M;
        
        public decimal SerieAnterior
        {
            get { return _serieAnterior; }
            set { _serieAnterior = value; }
        }

        private decimal _serieActual = 0.0M;

        public decimal SerieActual
        {
            get { return _serieActual; }
            set { _serieActual = value; }
        }


    }
}
