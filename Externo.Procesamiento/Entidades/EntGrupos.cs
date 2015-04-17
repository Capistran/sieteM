using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Procesamiento.Entidades
{
    public class EntGrupos
    {
        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _descgpo = string.Empty;

        public string Descgpo
        {
            get { return _descgpo; }
            set { _descgpo = value; }
        }
        private bool _habilitado = false;

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        private bool _consulta = false;

        public bool Consulta
        {
            get { return _consulta; }
            set { _consulta = value; }
        }
        private bool _modificacion = false;

        public bool Modificacion
        {
            get { return _modificacion; }
            set { _modificacion = value; }
        }
        private bool ctrlTotal = false;

        public bool CtrlTotal
        {
            get { return ctrlTotal; }
            set { ctrlTotal = value; }
        }
    }
}
