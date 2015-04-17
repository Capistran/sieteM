using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Procesos;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Vistas
{
    public class vistaChofer:ProcesosChofer
    {
        public vistaChofer()
        { }

        public int AgregarChofer(EntChofer pChofer)
        {
            return AltaChofer(pChofer);
        }

        public int AgregarCamion(EntCamion pCamion)
        {
            return AltaTransporte(pCamion);
        }

        public List<EntChofer> RegresaChoferTransporte(int pIdTrans)
        {
            return RegresaListaChofer(pIdTrans);
        }

        public EntChofer BuscaInformacionOperador(string numempleado)
        {
            return BuscaInforOperador(numempleado);
        }

        public bool ExisteOperador(string numEmpleado, int idTransp)
        {
            return ExisteOperadorporTransportista(numEmpleado, idTransp); ;
        }

        public int ActualizarOperador(EntChofer eOperador)
        {
            return ActualizaOperador(eOperador);
        }

        public bool EliminaOperador(int idOperador, int idTransp)
        {
            return BajaOperador(idOperador, idTransp);
        }
    }
}