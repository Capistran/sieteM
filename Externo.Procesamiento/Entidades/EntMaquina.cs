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
    }
}
