using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Externo.Procesamiento.Entidades;
using Externo.Procesamiento.Procesos;

namespace Ext.Web.Vistas
{
    public class vistaCamion
    {

        ProcesosCamion prcCamion = null;
        public vistaCamion()
        {
            prcCamion = new ProcesosCamion();
        }

        public int ActualizaUnidad(EntCamion entcamion)
        {
            return prcCamion.ActualizarUnidad(entcamion);
        }

        public EntCamion InformacionCamionporNum(string numeco,int idTransp)
        {
            return prcCamion.ObtieneInformacionUnidad(numeco, idTransp);
        }

        public List<EntCamion> ObteneUnidades(int idTransp)
        {
            return prcCamion.RegresaUnidades(idTransp);
        }

        ~vistaCamion()
        {
            prcCamion = null;
        }
    }
}