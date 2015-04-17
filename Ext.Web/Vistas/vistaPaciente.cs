using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Procesos;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Vistas
{
    public class vistaPaciente:ProcesosPacientes
    {
        

        public vistaPaciente()
        { }

        public int AgregaNuevoPaciente(EntPacientes pPaciente)
        {
            return InsertarNuevoPaciente(pPaciente);
        }


        public List<EntPacientes> RegresaTodosPacientes(bool editable)
        {           
                return RegresaPacientes();
        }

        public List<EntPacientes> RegresaPaciente(int pIdPaciente)
        {
            return RegresaPacientesEditable(pIdPaciente);
        }

        public bool ActualizarPaciente(EntPacientes pPaciente)
        {
            return ActualizaPaciente(pPaciente);
        }

        public bool EstatusEliminadoPaciente(int idPaciente, decimal cvepaciente)
        {
            return EstatusEliminado(idPaciente, cvepaciente);
        }

        public EntPacientes RegresaPacientePorClave(decimal clavePaciente)
        {
            return RegresaPacientesPorclave(clavePaciente);
        }

        public bool ActualizaTratamientoPaciente(decimal clavepaciente, int idTratamiento)
        {
            return ActualizaTratamiento(clavepaciente, idTratamiento);
        }

        public bool ExistePaciente(decimal cvePaciente)
        {
            return ExistePacienteClave(cvePaciente);
        }

        public EntPacientes RegresaDetallePaciente(decimal cvePaciente)
        {
            return RegresaDetallePacienteClave(cvePaciente);
        }

        public int RegresaIdPaciente(decimal cvePaciente)
        {
            return OntieneIdPaciente(cvePaciente);
        }

        public int InsertaNuevoContacto(EntPacientes econtacto)
        {
            return InsertarNuevoContacto(econtacto);
        }

        public int ActualizaContacto(EntPacientes econtacto)
        {
            return ModificarContacto(econtacto);
        }

        public EntPacientes RegresaInfoContacto(decimal cvePaciente, int idPaciente)
        {
            return RegresaInformacionContactoPaciente(cvePaciente, idPaciente);
        }

        public bool ExisteContactoPorPaciente(decimal cvePaciente)
        {
            return ExisteContactoPaciente(cvePaciente);
        }
    }
}