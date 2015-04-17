using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Procesos;
using Externo.Procesamiento.Entidades;

namespace Ext.Web.Vistas
{
    public class vistaUsuarios
    {
        public vistaUsuarios()
        { }
        EntUsuarios usuarioInfo = null;
        ProcesosUsuarios prcUsuarios = new ProcesosUsuarios();

        public bool ValidaLogin(int idUsuario,string password)
        {
            bool valida = false;
            try
            {
                valida= prcUsuarios.AccesoLogin(idUsuario, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return valida;
        }


        public EntUsuarios InformacionUsuario(int pidUsuario)
        {
            
            try
            {
                usuarioInfo = prcUsuarios.RegresaInfoUsuario(pidUsuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return usuarioInfo;
        }


        public EntUsuarios InformacionUsuarioSign(int pidusuario, int pidTrans)
        {
            try
            {
                usuarioInfo = prcUsuarios.RegresaInfoUsuarioActivo(pidusuario, pidTrans);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarioInfo;
        }

        public int AgregaNuevoUsuarioConsulta(EntUsuarios pUsuario)
        {
            int agrega;
            try
            {
                agrega = prcUsuarios.AgregarUsuariosConsulta(pUsuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return agrega;
        }

        public int RegresaUltimoUsuarioConsulta()
        {
            return prcUsuarios.UltimoUsuarioConsulta();
        }
    }
}