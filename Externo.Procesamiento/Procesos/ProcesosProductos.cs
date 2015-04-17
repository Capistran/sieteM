using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Externo.Procesamiento.Entidades;
using Externo.AccesoDatos.Configuracion;
using Externo.AccesoDatos.LinqToSql;

namespace Externo.Procesamiento.Procesos
{
    public class ProcesosProductos
    {

        ModelExternoDataContext dc;
        EntProducto eProducto = null;
        List<EntProducto> _listaProductos = null;
        public ProcesosProductos()
        { }

        ~ProcesosProductos()
        {
            eProducto = null;
            _listaProductos = null;
        }

        public int AgregarProductoNuevo(EntProducto pProducto)
        {
            int success = -1;
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            { 
                success=(dc.spIns_AltaProducto(pProducto.Clave,
                    pProducto.Marca,
                    pProducto.Categoria,
                    pProducto.Descripcion,
                    pProducto.Pzaporcaja,
                    pProducto.Precio,
                    pProducto.CodBarras,
                    pProducto.PaqCaja,
                    pProducto.PiezaPaq,
                    pProducto.PrecioCaja,
                    pProducto.PrecioPaquete,
                    pProducto.PrecioPieza));
            
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

        public List<EntProducto> RegresaProductos()
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            _listaProductos = new List<EntProducto>();
            eProducto = new EntProducto();
            try
            {

                var prod = (from pro in dc.PRODUCTO
                            where pro.HABILITADO=="S"
                            select pro).ToList();

                if (prod.Count > 0)
                {
                    foreach (var p in prod)
                    {
                        eProducto.IdProducto = p.ID_PRODUCTO;
                        eProducto.Clave = p.CLAVE;
                        eProducto.Marca = p.MARCA;
                        eProducto.Descripcion = p.DESCRIPCION;
                        _listaProductos.Add(eProducto);
                        eProducto = new EntProducto();
                    }
                }
            }
            catch
            { }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }

            return _listaProductos;
        }

        public EntProducto RegresaDetalleProducto(int pIdProducto)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            eProducto = new EntProducto();
            try             
            {
                var pro = (from producto in dc.PRODUCTO
                           where producto.ID_PRODUCTO == pIdProducto
                           select producto).SingleOrDefault();
                if (pro != null)
                {
                    eProducto.Marca=pro.MARCA;
                    eProducto.IdProducto = pro.ID_PRODUCTO;
                    eProducto.Clave = pro.CLAVE;
                    eProducto.Descripcion = pro.DESCRIPCION;
                    eProducto.Categoria = pro.CATEGORIA;
                    eProducto.PaqCaja = (int)pro.PAQ_CAJA;
                    eProducto.PiezaPaq = (int)pro.PZA_PAQ;
                    eProducto.PrecioCaja = (decimal)pro.PRECIO_CAJA;
                    eProducto.PrecioPaquete = (decimal)pro.PRECIO_PAQ;
                    eProducto.PrecioPieza = (decimal)pro.PRECIO_PZA;
                    eProducto.Pzaporcaja = (int)pro.PIEZA_POR_CAJA;
                    eProducto.Precio = (decimal)pro.PRECIO;
                }
            }
            catch
            { }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return eProducto;
        }

        public EntProducto RegresaDetalleProductoCodigo(string CveProducto)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            eProducto = new EntProducto();
            try
            {
                var pro = (from producto in dc.PRODUCTO
                           where producto.CLAVE == CveProducto
                           && producto.HABILITADO=="S"
                           select producto).SingleOrDefault();
                if (pro != null)
                {
                    eProducto.Marca = pro.MARCA;
                    eProducto.IdProducto = pro.ID_PRODUCTO;
                    eProducto.Clave = pro.CLAVE;
                    eProducto.Descripcion = pro.DESCRIPCION;
                    eProducto.Categoria = pro.CATEGORIA;
                    eProducto.PaqCaja = (int)pro.PAQ_CAJA;
                    eProducto.PiezaPaq = (int)pro.PZA_PAQ;
                    eProducto.PrecioCaja = (decimal)pro.PRECIO_CAJA;
                    eProducto.PrecioPaquete = (decimal)pro.PRECIO_PAQ;
                    eProducto.PrecioPieza = (decimal)pro.PRECIO_PZA;
                    eProducto.Pzaporcaja = (int)pro.PIEZA_POR_CAJA;
                    eProducto.Precio = (decimal)pro.PRECIO;
                    eProducto.CodBarras =(decimal) pro.COD_BARRAS;
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
            return eProducto;
        }
        public int ActualizarProducto(EntProducto eProducto)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            int success = -1;
            try
            {
                success = (dc.spUpd_Producto((long)eProducto.IdProducto,
                    eProducto.Clave,
                    eProducto.Marca,
                    eProducto.Categoria,
                    eProducto.Descripcion,
                    eProducto.Pzaporcaja,
                    eProducto.Precio,
                    eProducto.CodBarras,
                    eProducto.PaqCaja,
                    eProducto.PiezaPaq,
                    eProducto.PrecioCaja,
                    eProducto.PrecioPaquete,
                    eProducto.PrecioPieza
                    ));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dc.Connection.Close();
            }

            return success;
        }

        public bool ExisteProducto(string codigo)
        {

            dc = new ModelExternoDataContext(Configuracion.strConexion);
            try
            {
                var producto = (from pr in dc.PRODUCTO
                                where pr.CLAVE == codigo
                                && pr.HABILITADO=="S"
                                select pr).FirstOrDefault();

                if (producto != null)
                {
                    return true;
                }
            }
            catch
            { }
            finally
            {
                dc.Connection.Close();
                dc.Dispose();
            }
            return false;
        }

        public bool EliminaProducto(int idProducto)
        {
            dc = new ModelExternoDataContext(Configuracion.strConexion);
            bool success = false;
            try
            {
                var prod = (from producto in dc.PRODUCTO
                            where producto.ID_PRODUCTO == idProducto

                            select producto).SingleOrDefault();
                if (prod != null)
                {
                    prod.HABILITADO = "N";
                    dc.SubmitChanges();
                    success = true;
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

            return success;
        }


    }
}
