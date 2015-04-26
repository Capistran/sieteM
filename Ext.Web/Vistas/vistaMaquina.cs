using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;
namespace Ext.Web.Vistas
{
    public class vistaMaquina
    {
        ProcesosMaquina prcMaquina = new ProcesosMaquina();
        public int AgregaNuevoHomeChoice(int idPaciente, decimal noserie)
        {
            return prcMaquina.AgregarMaquina(idPaciente, noserie);
        }

        public EntMaquina RegresaInformacionHC(int idPaciente)
        {
            return prcMaquina.RegresaMaquina(idPaciente);
        }

        public bool ActualizaHC(int idPaciente, decimal noserie)
        {
            return prcMaquina.ActualizarSerieHomeChoice(idPaciente, noserie);
        }

        public bool ExisteMaquina(int idPaciente)
        {
            return prcMaquina.TieneMaquinaRegistrada(idPaciente);
        }

        public List<EntMaquina> HistorialMaquina(int idPaciente)
        {
            return prcMaquina.RegresaHistorialMaquina(idPaciente);
        }
    }
}