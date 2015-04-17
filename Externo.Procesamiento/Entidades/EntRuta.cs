using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntRuta:EntCamion
    {
        public EntRuta()
        { }

        private string _cveRuta = string.Empty;

        public string CveRuta
        {
            get { return _cveRuta; }
            set { _cveRuta = value; }
        }

        private DateTime _fechaEntrega = new DateTime();

        public DateTime FechaEntrega
        {
            get { return _fechaEntrega; }
            set { _fechaEntrega = value; }
        }
        private DateTime _fechaVencimiento = new DateTime();

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        private int _idRuta = 0;

        public int IdRuta
        {
            get { return _idRuta; }
            set { _idRuta = value; }
        }

        private string _mes = string.Empty;

        public string Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }
        private DateTime _fechaEmbarque = new DateTime(2000, 1, 1);

        public DateTime FechaEmbarque
        {
            get { return _fechaEmbarque; }
            set { _fechaEmbarque = value; }
        }

        private DateTime _llegadaCedis = new DateTime(2000, 1, 1);

public DateTime LlegadaCedis
{
  get { return _llegadaCedis; }
  set { _llegadaCedis = value; }
}
        private DateTime _salidaCedis=new DateTime(2000,1,1);

public DateTime SalidaCedis
{
  get { return _salidaCedis; }
  set { _salidaCedis = value; }
}

    }
}
