using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;

namespace Ext.Web.Paginas.Unidad
{
    public partial class UnidadesTransportista : System.Web.UI.Page
    {

        vistaCamion vUnidad = new vistaCamion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IniciaGridUnidades();
                LlenaGridUnidades();
            }

        }

        private void IniciaGridUnidades()
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Num. Economico";
            bfield.DataField = "NumEconomico";
            gvUnidades.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "MARCA";
            bfield.DataField = "Marca";
            gvUnidades.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "MODELO";
            bfield.DataField = "NumEconomico";
            gvUnidades.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "PLACAS";
            bfield.DataField = "Placas";
            gvUnidades.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "CAPACIDAD";
            bfield.DataField = "CapacidadCarga";
            gvUnidades.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "POLIZA";
            bfield.DataField = "NoPoliza";
            gvUnidades.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "VIGENCIA POLIZA";
            bfield.DataField = "VigenciaPoliza";
            gvUnidades.Columns.Add(bfield);

            
        }

        private void LlenaGridUnidades()
        {
            gvUnidades.DataSource = vUnidad.ObteneUnidades(1);
            gvUnidades.DataBind();
        }
        /*
                        _entCamion.IdCamion = u.ID_CAMION;
                        _entCamion.Placas = u.PLACAS;
                        _entCamion.Marca = u.MARCA;
                        _entCamion.Modelo = u.MODELO;
                        _entCamion.NumEconomico = u.NUM_ECONOMICO;
                        _entCamion.CapacidadCarga = (decimal)u.CAP_CARGA;
                        _entCamion.NoPoliza = u.NO_POLIZA;
                        _entCamion.VigenciaPoliza = (DateTime)u.VIGENCIA_POLIZA;
                        _listaCamion.Add(_entCamion);
         */
    }
}