using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;
using Externo.Procesamiento.Entidades;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosCedis
    {
        ModelExternoDataContext dc;
        EntCedis _entcedis;
        List<EntCedis> _listaCedis;
        public ProcesosCedis()
        { 
        
        }

        ~ProcesosCedis()
        { }

        public EntCedis RegresaInfoCedisClave(string cveCedis)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _entcedis = new EntCedis();
            try
            {
                var infocedis = (from cedis in dc.CAT_CEDIS
                                 where cedis.CVE_CEDIS == cveCedis
                                 select cedis).SingleOrDefault();
                if (infocedis != null)
                {
                    _entcedis.NombreCedis = infocedis.NOMBRE;
                    _entcedis.IdEstado = (int)infocedis.ESTADO;
                    _entcedis.IdCiudad = (int)infocedis.CIUDAD;
                    _entcedis.Colonia = infocedis.COLONIA;
                    _entcedis.Calle = infocedis.CALLE;
                    _entcedis.NumExt = infocedis.NUM_EXT;
                    _entcedis.NumInt = infocedis.NUM_INT;
                    _entcedis.CP = infocedis.CP;
                    _entcedis.Manzana = infocedis.MANZANA;
                    _entcedis.SuperManzana = infocedis.SUPER_MAN;
                    _entcedis.Lote = infocedis.LOTE;
                    _entcedis.IdCedis = infocedis.ID_CEDIS;
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return _entcedis;
        }

        public int AltaCedis(EntCedis entcedis)
        {
            int success = -1;
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {

                success = (dc.spIns_AltaCedis(entcedis.NombreCedis,
                    entcedis.IdEstado,
                    entcedis.IdCiudad,
                    entcedis.Colonia,
                    entcedis.Calle,
                    entcedis.NumExt,
                    entcedis.NumInt,
                    entcedis.CP,
                    entcedis.Manzana,
                    entcedis.Lote,
                    entcedis.SuperManzana,
                    entcedis.CveCedis));

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

        public int ActualizaCedis(EntCedis entcedis)
        {
        int success=-1;
            dc= new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                success = (dc.spUpd_Cedis(entcedis.IdCedis,
                    entcedis.CveCedis,
                    entcedis.NombreCedis,
                        entcedis.IdEstado,
                        entcedis.IdCiudad,
                        entcedis.Colonia,
                        entcedis.Calle,
                        entcedis.NumExt,
                        entcedis.NumInt,
                        entcedis.CP,
                        entcedis.Manzana,
                            entcedis.Lote,
                                entcedis.SuperManzana));
            }
            catch(Exception ex)
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
