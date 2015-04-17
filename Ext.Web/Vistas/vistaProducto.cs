using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Web.Paginas.Productos;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;

namespace Ext.Web.Vistas
{
    public class vistaProducto
    {

        ProcesosProductos prcProductos = new ProcesosProductos();

        public vistaProducto()
        { }

        public int NuevoProducto(EntProducto pProducto)
        {
            return prcProductos.AgregarProductoNuevo(pProducto);
        }

        public List<EntProducto> RegresaTodosProductos()
        {
            return prcProductos.RegresaProductos();
        }

        public EntProducto DetalleProducto(int pProducto)
        {
            return prcProductos.RegresaDetalleProducto(pProducto);
        }

        public int ActualizaProducto(EntProducto eProducto)
        {
            return prcProductos.ActualizarProducto(eProducto);
        }

        public bool ExisteProducto(string clave)
        {
            return prcProductos.ExisteProducto(clave);
        }

        public EntProducto DetalleProductoCodigo(string cveProducto)
        {
            return prcProductos.RegresaDetalleProductoCodigo(cveProducto);
        }

        public bool EliminaProducto(int idProducto)
        {
            return prcProductos.EliminaProducto(idProducto);
        }
    }
}