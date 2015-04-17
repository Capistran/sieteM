using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.Procesamiento.Entidades;
using Externo.AccesoDatos.LinqToSql;
using Externo.AccesoDatos.Configuracion;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosPacientes
    {
        ModelExternoDataContext dc;
        List<EntPacientes> _listaPacientes = new List<EntPacientes>();
        EntPacientes _contacto = null;
        int _success = -1;

        public ProcesosPacientes()
        { 
        
        }

        protected int InsertarNuevoPaciente(EntPacientes pPaciente)
        {
            int insertar=-1;
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                insertar = (dc.spIns_AltaPaciente(pPaciente.Nombre,
                                                      pPaciente.Ape_Pat,
                                                      pPaciente.Ape_Mat,
                                                      pPaciente.NumRecepcion,
                                                      pPaciente.NSS,
                                                      pPaciente.Latitud,
                                                      pPaciente.Longitud,
                                                      pPaciente.FrecVisita,
                                                      (int)pPaciente.DiaVisita,
                                                      pPaciente.Calle,
                                                      pPaciente.NumInt,
                                                      pPaciente.NumExt,
                                                      pPaciente.Colonia,
                                                      pPaciente.CP,
                                                      (int)pPaciente.IdCiudad,
                                                      (int)pPaciente.IdEstado,
                                                      pPaciente.TelFijo,
                                                      pPaciente.Tel_Cel,
                                                      pPaciente.CveINE,
                                                      "VIGENTE",
                                                      pPaciente.CvePaciente,
                                                      pPaciente.Institucion,
                                                      pPaciente.SuperManzana,
                                                      pPaciente.Manzana,
                                                      pPaciente.Lote
                                                     ) );
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }

            return insertar;
        }

        protected List<EntPacientes> RegresaPacientesEditable(int pIdPaciente)
        {        
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try
            {

                _listaPacientes = (from pac in dc.vListaPacientes where pac.ID_PACIENTE==pIdPaciente
                                   select new EntPacientes { 
                                   CvePaciente=(decimal)((decimal?)pac.CVE_PACIENTE==null?0M:(decimal?)pac.CVE_PACIENTE),
                                   Nombre = pac.NOMBRE,
                                   Ape_Pat=pac.APE_PAT,
                                   Ape_Mat=pac.APE_MAT,
                                   NSS=pac.NSS,
                                   Latitud=(float)pac.LATITUD,
                                   Longitud=(float)pac.LONGITUD,
                                   IdEstado=(int)pac.ESTADO,
                                   IdCiudad=(int)pac.CIUDAD,
                                   DesEstado=pac.DESCESTADO,
                                   DescCiudad=pac.DESCCIUDAD,
                                   Calle=pac.CALLE,
                                   Colonia=pac.COLONIA,
                                   NumExt=pac.NUM_EXT,
                                   NumInt=pac.NUM_INT,
                                   CP=pac.CP,
                                   Tel_Cel=pac.TEL_CELULAR,
                                   TelFijo=pac.TEL_FIJO,
                                   IdPaciente=pac.ID_PACIENTE
                                   }).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return _listaPacientes;
        }

        protected List<EntPacientes> RegresaPacientes()
        {
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try
            {

                _listaPacientes = (from pac in dc.vListaPacientes where pac.ESTATUS!="ELIMINADO"
                                   select new EntPacientes { 
                                   CvePaciente=(decimal)((decimal?)pac.CVE_PACIENTE==null?0M:(decimal?)pac.CVE_PACIENTE),
                                   Nombre = pac.NOMBRE + " " + pac.APE_PAT + " " + pac.APE_MAT,
                                   //Ape_Pat=pac.APE_PAT,
                                   //Ape_Mat=pac.APE_MAT,
                                   NSS=pac.NSS,
                                   Latitud=(float)pac.LATITUD,
                                   Longitud=(float)pac.LONGITUD,
                                   DesEstado=pac.DESCESTADO,
                                   DescCiudad=pac.DESCCIUDAD,
                                   Calle=pac.CALLE,
                                   Colonia=pac.COLONIA,
                                   NumExt=pac.NUM_EXT,
                                   NumInt=pac.NUM_INT,
                                   Tel_Cel=pac.TEL_CELULAR,
                                   TelFijo=pac.TEL_FIJO,
                                   IdPaciente=pac.ID_PACIENTE
                                   }).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }
            return _listaPacientes;
        }

        protected bool ActualizaPaciente(EntPacientes pPaciente)
        {
            bool actualizo = false;
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try 
            {
                var act = (dc.spUpd_Paciente(pPaciente.IdPaciente,pPaciente.Nombre,pPaciente.Ape_Pat,
                    pPaciente.Ape_Mat,pPaciente.NumRecepcion,pPaciente.NSS,pPaciente.Latitud,pPaciente.Longitud
                    ,pPaciente.FrecVisita,pPaciente.DiaVisita,pPaciente.Calle,pPaciente.NumInt,pPaciente.NumExt,
                    pPaciente.Colonia,pPaciente.CP, pPaciente.IdCiudad,pPaciente.IdEstado,pPaciente.TelFijo
                    ,pPaciente.Tel_Cel,pPaciente.CveINE,
                    pPaciente.CvePaciente));
                if (act == 0)
                    actualizo = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }

            return actualizo;
        }

        protected bool EstatusEliminado(int piIdPaciente, decimal pCvePaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            { 
                var eliminado=(dc.spUpd_EstatusEliminadoPaciente(piIdPaciente,pCvePaciente));
                if(eliminado==0)
                    success=true;
            }
            catch (Exception ex)
            {             
                throw ex;
            }
            finally
            { 
                dc.Connection.Close();
            }
            return success;
        }

        protected EntPacientes RegresaDetallePacienteClave(decimal cvePaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntPacientes entPaciente = new EntPacientes();
            try
            {

                var paciente = (from pac in dc.PACIENTE
                                where pac.ESTATUS != "ELIMINADO"
                                && pac.CVE_PACIENTE==cvePaciente
                                select pac).SingleOrDefault();
                if (paciente != null)
                {
                    entPaciente.Nombre = paciente.NOMBRE;
                    entPaciente.Ape_Pat = paciente.APE_PAT;
                    entPaciente.Ape_Mat = paciente.APE_MAT;
                    entPaciente.IdEstado = (int)paciente.ESTADO;
                    entPaciente.IdCiudad = (int)paciente.CIUDAD;
                    entPaciente.IdPaciente = paciente.ID_PACIENTE;
                    entPaciente.Calle = paciente.CALLE;
                    entPaciente.Colonia = paciente.COLONIA;
                    entPaciente.NumExt=paciente.NUM_EXT;
                    entPaciente.NumInt = paciente.NUM_INT;
                    entPaciente.NSS = paciente.NSS;
                    entPaciente.Latitud = (float)paciente.LATITUD;
                    entPaciente.Longitud = (float)paciente.LONGITUD;
                    entPaciente.Manzana = paciente.MANZANA;
                    entPaciente.SuperManzana = paciente.SUPER_MAN;
                    entPaciente.Lote = paciente.LOTE;
                    entPaciente.Institucion = paciente.INSTITUCION;
                    entPaciente.Tel_Cel = paciente.TEL_CELULAR;
                    entPaciente.TelFijo = paciente.TEL_FIJO;
                    entPaciente.CP = paciente.CP;
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
            return entPaciente;
        
        }

        protected EntPacientes RegresaPacientesPorclave(decimal clavePaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            EntPacientes epaciente = new EntPacientes();
            try {
                var pacientes = (from pac in dc.PACIENTE
                                 where pac.CVE_PACIENTE==clavePaciente
                                 select pac).ToList();

                if (pacientes.Count > 0)
                {
                    foreach (var p in pacientes)
                    {
                        epaciente.IdPaciente = p.ID_PACIENTE;
                        epaciente.Nombre=p.NOMBRE.ToUpper()+" "+p.APE_PAT.ToUpper()+" "+p.APE_MAT.ToUpper();
                        epaciente.CvePaciente = (decimal)p.CVE_PACIENTE;
                        epaciente.IdTratamiento =(int) p.TRATAMIENTO;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }

            return epaciente;
        }

        protected bool ActualizaTratamiento(decimal cvePaciente,int tratamiento)
        {
            bool success = false;
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                int actua = -1;
                actua = (dc.spUpd_ActualizaTratamiento(cvePaciente, tratamiento));
                if (actua == 0)
                    success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }

            return success;
        }

        protected bool ExistePacienteClave(decimal cvePaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                var paciente = (from pac in dc.PACIENTE
                                where pac.CVE_PACIENTE == cvePaciente
                                && pac.ESTATUS!="ELIMINADO"
                                select pac).SingleOrDefault();

                if (paciente != null)
                    success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return success;
        }

        protected int OntieneIdPaciente(decimal cvePaciente)
        {
            int idpac = -1;
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                idpac = (from pac in dc.PACIENTE
                         where pac.CVE_PACIENTE == cvePaciente
                         select pac.ID_PACIENTE).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return idpac;
        }

        protected int InsertarNuevoContacto(EntPacientes entcontacto)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                _success = (dc.spIns_Contacto(entcontacto.IdPaciente
                    , entcontacto.Nombre
                    , entcontacto.Ape_Pat
                    , entcontacto.Ape_Mat
                    , entcontacto.FrecVisita
                    , entcontacto.Calle
                    , entcontacto.NumInt
                    , entcontacto.NumExt
                    , entcontacto.Colonia
                    , entcontacto.CP
                    , entcontacto.IdCiudad
                    , entcontacto.IdEstado
                    , entcontacto.TelFijo
                    , entcontacto.Tel_Cel
                    , entcontacto.CveINE
                    , entcontacto.SuperManzana
                    , entcontacto.Manzana
                    , entcontacto.Lote
                    , entcontacto.CvePaciente));
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return _success;            
        }

        protected int ModificarContacto(EntPacientes entcontacto)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                _success = (dc.spUpd_Contacto(entcontacto.IdPaciente
                    , entcontacto.CvePaciente,
                    entcontacto.Nombre, entcontacto.Ape_Pat, entcontacto.Ape_Mat
                    , entcontacto.FrecVisita, entcontacto.Calle, entcontacto.NumInt
                    , entcontacto.NumExt, entcontacto.Colonia, entcontacto.CP
                    , entcontacto.IdCiudad, entcontacto.IdEstado, entcontacto.TelFijo
                    , entcontacto.Tel_Cel, entcontacto.CveINE, entcontacto.SuperManzana,
                    entcontacto.Manzana, entcontacto.Lote));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally {
                dc.Connection.Close();
                dc.Dispose();
            }
            return _success;
        }

        protected EntPacientes RegresaInformacionContactoPaciente(decimal cve_paciente, int idPaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _contacto = new EntPacientes();
            try
            {

                var cont = (from con in dc.CONTACTO_PACIENTE
                            where con.CVE_PACIENTE == cve_paciente
                            && con.ID_PACIENTE==idPaciente
                            select con).SingleOrDefault();
                if (cont != null)
                {
                    _contacto.Nombre=cont.NOMBRE ;
                     _contacto.Ape_Pat=cont.APE_PAT ;
                     _contacto.Ape_Mat=cont.APE_MAT ;
                     _contacto.Calle=cont.CALLE ;
                    _contacto.Colonia=cont.COLONIA  ;
                    _contacto.IdEstado=(int)cont.ESTADO ;
                    _contacto.IdCiudad=(int)cont.CIUDAD  ;
                     _contacto.CP=cont.CP ;
                     _contacto.Manzana = cont.MANZANA;
                     _contacto.SuperManzana = cont.SUPER_MAN;
                     _contacto.Lote = cont.LOTE;
                     _contacto.NumExt = cont.NUM_EXT;
                     _contacto.NumInt = cont.NUM_INT;
                     _contacto.Tel_Cel = cont.TEL_CELULAR;
                     _contacto.TelFijo = cont.TEL_FIJO;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return _contacto;
        }

        protected bool ExisteContactoPaciente(decimal cvePaciente)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                var existe = (from datos in dc.CONTACTO_PACIENTE
                              where datos.CVE_PACIENTE == cvePaciente
                              select datos).SingleOrDefault();

                if (existe != null)
                    success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return success;
        }
    }
        
}
