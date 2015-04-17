using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Externo.AccesoDatos.LinqToSql;
using Externo.AccesoDatos.Configuracion;
using Externo.Procesamiento.Entidades;
using System.Configuration;
using Externo.Utilerias;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosUsuarios:IDisposable
    {
        ModelExternoDataContext dc;
        EntUsuarios _entUsuarios = null;
        public ProcesosUsuarios()
        { }


        ~ProcesosUsuarios()
        { 
            _entUsuarios = null; 
        }

        public bool AccesoLogin(int pIdUsuario,string pContraseña)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            System.Nullable<bool> success=null;
            success = false;
            try
            {
                var acceso = (dc.spSel_UsuarioLogin((int)pIdUsuario,pContraseña,ref success));              

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return (bool)success;
        }


        public EntUsuarios RegresaInfoUsuario(int pIdUsuario)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entUsuarios = new EntUsuarios();
            try
            {

                var usuario = (from detusu in dc.USUARIOS
                               join infusu in dc.USR_DATPER
                               on detusu.ID_USUARIO equals infusu.ID_USUARIO
                               where detusu.ID_USUARIO==pIdUsuario
                               select new EntUsuarios { 
                                Nombre=infusu.NOMBRE.ToUpper() + " " + infusu.APE_PAT.ToUpper() + " " + infusu.APE_MAT.ToUpper(),
                                IdUsuario = pIdUsuario,
                                Email=detusu.EMAIL,
                                IdTransp=(int)detusu.ID_TRANSP,
                                Grupo = (int)detusu.GRUPO
                

                               }).SingleOrDefault();
                if (usuario != null)
                {
                    return usuario;   
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            { }

            return _entUsuarios;
        }

        public EntUsuarios RegresaInfoUsuarioActivo(int pIdUsuario,int ipdIdTransp)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entUsuarios = new EntUsuarios();
            try
            {

                var usuario = (dc.spSel_InformacionUsuario(pIdUsuario, ipdIdTransp)).SingleOrDefault();
                
                if (usuario != null)
                {

                    _entUsuarios.Nombre = usuario.NOMBRE.ToUpper();
                    _entUsuarios.Email = usuario.EMAIL;
                    _entUsuarios.RazonSocial = usuario.RAZON_SOCIAL;
                    _entUsuarios.Grupo = (int)usuario.GRUPO;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { }

            return _entUsuarios;
        }

        public int AgregarUsuariosConsulta(EntUsuarios pUsuario)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            int success = -1;
            try
            {

                success = (dc.spIns_Usuarios(pUsuario.Contraseña,
                    pUsuario.Email
                    ,(int)Enumeraciones.TipoUsuario.Consulta
                    ,pUsuario.IdTransp
                    ,pUsuario.Nombre
                    ,pUsuario.ApePat
                    ,pUsuario.ApeMat
                    ,pUsuario.RFC
                    ,pUsuario.Cve_INE
                    ,pUsuario.Estado
                    ,pUsuario.Ciudad
                    ,pUsuario.Colonia
                    ,pUsuario.CP
                    ,pUsuario.Calle
                    ,pUsuario.NumExt
                    ,pUsuario.NumInt
                    ,pUsuario.TelCasa
                    ,pUsuario.Tel_cel
                    ));
            }
            catch(Exception ex)
            {
                throw ex;
            }
                finally

            {}
            return success;
        }

        public int UltimoUsuarioConsulta()
        {
            int idUsuario = 0;
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                var usuario = (from usr in dc.USUARIOS select usr).FirstOrDefault();
                if (usuario != null)
                {
                    idUsuario = (from usuar in dc.USUARIOS 
                                 where usuar.GRUPO==(int)Enumeraciones.TipoUsuario.Consulta
                                 select usuar.ID_USUARIO).Max();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return idUsuario;
        }

        public void Dispose()
        {
            _entUsuarios = null;
        }
    }
}
