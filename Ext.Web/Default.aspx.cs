using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Web.Vistas;
using Externo.Procesamiento.Entidades;
using System.Web.Services;
using System.Text;
namespace Ext.Web
{
    public partial class Default : System.Web.UI.Page
    {

        static vistaRutas vRutas = new vistaRutas();
        protected List<EntPacientes> pacientes { get; set; }
        private int _idTransportisa = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {                
                CargaControles();
                int tmpRuta = Convert.ToInt32(ddRutas.SelectedValue == "" ? "0" : ddRutas.SelectedValue);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "marcas", "javascript:" + scritpMapaGoogle(tmpRuta).ToString(), true);
            }


            if (Request.Form["__EVENTTARGET"] == "ctl00$ContentPrincipal$ddRutas")
            {
                if (Request.Form["__EVENTARGUMENT"] != null)
                {
                    int tempRuta = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["__EVENTARGUMENT"].ToString());
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "marcas", "javascript:" + scritpMapaGoogle(tempRuta).ToString(), true);
                }
            }

            if (Request.Form["ctl00$ContentPrincipal$__EVENTTARGET"] == "ctl00$ContentPrincipal$ddRutas")
            {
                if (Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"] != null)
                {
                    if(Session["InfoUsr"]!=null)
                        _idTransportisa = (Session["InfoUsr"] as EntUsuarios).IdTransp;

                    int tempRuta = Convert.ToInt32(Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"].ToString() == "" ? "0" : Request.Form["ctl00$ContentPrincipal$__EVENTARGUMENT"].ToString());
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "marcas", "javascript:" + scritpMapaGoogle(tempRuta).ToString(), true);
                }
            }
        }

        void CargaControles()
        {
            //se carga por variable de Session
            cargaRutasporTransportista((Session["UsrInfo"] as EntUsuarios).IdTransp);
        }

        void cargaRutasporTransportista(int pIdTransportista)
        {
          
            ddRutas.DataSource = vRutas.vistaRegresaRutasporTransportista(pIdTransportista);
            ddRutas.DataTextField = "CveRuta";
            ddRutas.DataValueField = "IdRuta";
            ddRutas.DataBind();

            ViewState["IdRuta"] = ddRutas.SelectedValue;
        }


        private void cargaInformacionRutaDetalle(int pIdRuta)
        {
            var rutas = vRutas.RegresaDetalleRuta(pIdRuta);
            if (rutas.IdRuta > 0)
            {
                lblChofer.Text = rutas.Nombre;
                lblTransporte.Text = rutas.Marca.ToUpper() + "-" + rutas.Modelo.ToUpper();
                lblAuxiliar.Text = rutas.NombreAuxiliar;
            }
            else
            {
                lblChofer.Text = "NO ASIGNADO";
                lblTransporte.Text = "NO ASIGNADO";
                lblAuxiliar.Text = "NO ASIGNADO";

            }
            //lblMes.Text = rutas.Mes.ToUpper();
        }
        protected void ddRutas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       

        private StringBuilder _sbMapaGoogle = new StringBuilder();

        private StringBuilder _spMapaInicial = new StringBuilder();

        private StringBuilder scritpInicializaMapaDefault()
        {
            _spMapaInicial.Append(" var map; var infowindow;var ltlng = [];  ");
            _spMapaInicial.Append("function InitializeMap() { ");
            _spMapaInicial.Append("var latlng = new google.maps.LatLng(25.551933, -103.4365556);");
            _spMapaInicial.Append("var myOptions = {");
            _spMapaInicial.Append("zoom: 14, center: latlng, mapTypeId: google.maps.MapTypeId.ROADMAP }; ");

            _spMapaInicial.Append("map = new google.maps.Map(document.getElementById('mapa'), myOptions); } window.onload=InitializeMap;");
            return _spMapaInicial;
        }

        private StringBuilder scritpInicializaMapa()
        {
            _sbMapaGoogle.Append("var map; var infowindow;var ltlng = []; ");
            _sbMapaGoogle.Append("function InitializeMap() { ");
            _sbMapaGoogle.Append("var latlng = new google.maps.LatLng(25.551933, -103.4365556);");
            _sbMapaGoogle.Append("var myOptions = {");
            _sbMapaGoogle.Append("zoom: 7, center: latlng, mapTypeId: google.maps.MapTypeId.ROADMAP }; ");
            
            _sbMapaGoogle.Append("map = new google.maps.Map(document.getElementById('mapa'), myOptions); }");
            return _sbMapaGoogle;
        }
        /*
         var map; var infowindow;var ltlng = [];
    function InitializeMap() {
        var latlng = new google.maps.LatLng(40.756, -73.986);
        var myOptions =
        {
            zoom: 8,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById("map"), myOptions);
    }
         */

        
        public StringBuilder scritpMapaGoogle(int idRuta)
        {
            cargaInformacionRutaDetalle(idRuta);
            scritpInicializaMapa();
            _sbMapaGoogle.Append("function markicons() { ");
            _sbMapaGoogle.Append("InitializeMap(); ");
            int transp = (Session["UsrInfo"] as EntUsuarios).IdTransp;
            pacientes = vRutas.vistaRegresaPacientesPorRuta(idRuta, transp);
            int variables = 1;
            //if (pacientes.Count > 1)
            //    _sbMapaGoogle.Append(" map.setCenter(ltlng[0]); " );
            foreach (var p in pacientes)
            {
                //InformacionPaciente(p);
                //if(variables==1)
                //    _sbMapaGoogle.Append(" map.setCenter(ltlng[0]); ");
                //_sbMapaGoogle.Append("    ltlng.push(new google.maps.LatLng("+p.Latitud+","+p.Longitud+"));  ");
                _sbMapaGoogle.Append("var marker" + variables.ToString() + " = new google.maps.Marker({ ");
                _sbMapaGoogle.Append("position: new google.maps.LatLng(" + p.Latitud.ToString("##.########") + "," + p.Longitud.ToString("##.########") + "), ");
                _sbMapaGoogle.Append(" map: map, ");
                _sbMapaGoogle.Append(" icon: '"+EstatusEntregaColores(p.Estatus_entrega)+"', ");
                _sbMapaGoogle.Append(" title: 'Click me'}); ");
                _sbMapaGoogle.Append("var infowindow" + variables.ToString() + " = new google.maps.InfoWindow({ ");
                _sbMapaGoogle.Append("content: 'Paciente:<span class=\"Paciente\">"+p.Nombre+"</span> <br>ESTATUS: "+p.Estatus_entrega+"</br>");
                if(p.HoraLlegada.Year>2000)
                    _sbMapaGoogle.Append("<br>Hora de Llegada: "+p.HoraLlegada.ToShortTimeString()+"<br>");
                else
                    _sbMapaGoogle.Append("<br>Hora de Llegada: 00:00:00 <br> ");

                if (p.HoraSalida.Year > 2000)
                    _sbMapaGoogle.Append("<br>Hora de Salida: " + p.HoraSalida.ToShortTimeString() + "<br>");
                else
                    _sbMapaGoogle.Append("<br>Hora de Salida: 00:00:00 <br> ");
                if(p.Estatus_entrega=="CANCELADO")
                    _sbMapaGoogle.Append("<br>Motivo de Cancelación:"+p.MotCancelacion+"<br> ");

                _sbMapaGoogle.Append("' }); ");
                _sbMapaGoogle.Append("google.maps.event.addListener(marker" + variables.ToString() + ", 'click', function () { ");
                _sbMapaGoogle.Append(" infowindow" + variables.ToString() + ".open(map, marker" + variables.ToString() + "); ");
                //_sbMapaGoogle.Append(" map.setCenter(marker.getPosition()); ");
                _sbMapaGoogle.Append("}); ");
                variables++;

            }
            

            //_sbMapaGoogle.Append("map.setCenter(ltlng[0]); ");
            //_sbMapaGoogle.Append("for (var i = 0; i <= ltlng.length; i++) { ");
            //_sbMapaGoogle.Append("marker = new google.maps.Marker({ ");
            //_sbMapaGoogle.Append("map: map, ");
            //_sbMapaGoogle.Append("position: ltlng[i] ");
            //_sbMapaGoogle.Append("}); ");
            //_sbMapaGoogle.Append("(function (i, marker) { ");
            //_sbMapaGoogle.Append("google.maps.event.addListener(marker, 'click', function () { ");
            //_sbMapaGoogle.Append("if (!infowindow) { ");
            //_sbMapaGoogle.Append(" infowindow = new google.maps.InfoWindow(); } ");
            //_sbMapaGoogle.Append("infowindow.setContent('Message' + i); ");
            //_sbMapaGoogle.Append("infowindow.open(map, marker); ");
            //_sbMapaGoogle.Append("}); ");
            //_sbMapaGoogle.Append(" })(i, marker); }}");
            _sbMapaGoogle.Append("}   window.onload = markicons; ");
            
            pacientes = new List<EntPacientes>();
            return _sbMapaGoogle;
        }
        /*
         var marker = new google.maps.Marker
        (
            {
                position: new google.maps.LatLng(-34.397, 150.644),
                map: map,
                title: 'Click me'
            }
        );
        var infowindow = new google.maps.InfoWindow({
            content: 'Location info:<br/>Country Name:<br/>LatLng:'
        });
        google.maps.event.addListener(marker, 'click', function () {
            // Calling the open method of the infoWindow 
            infowindow.open(map, marker);
        });
	});
         * 
         * 
         * 
         * 
         * 
          function markicons() {

        InitializeMap();

        var ltlng = [];

        ltlng.push(new google.maps.LatLng(17.22, 78.28));
        ltlng.push(new google.maps.LatLng(13.5, 79.2));
        ltlng.push(new google.maps.LatLng(15.24, 77.16));

        map.setCenter(ltlng[0]);
        for (var i = 0; i <= ltlng.length; i++) {
            marker = new google.maps.Marker({
                map: map,
                position: ltlng[i]
            });

            (function (i, marker) {

                google.maps.event.addListener(marker, 'click', function () {

                    if (!infowindow) {
                        infowindow = new google.maps.InfoWindow();
                    }

                    infowindow.setContent("Message" + i);

                    infowindow.open(map, marker);

                });

            })(i, marker);

        }

    }
         */


        private string EstatusEntregaColores(string estatus)
        { 
            string marca=string.Empty;
            switch (estatus)
            { 
                case "PENDIENTE":
                    marca="Imagenes/gray-dot.png";
                    break;
                case "ENTREGADO":
                    marca = "http://maps.google.com/mapfiles/ms/icons/green-dot.png";
                    break;
                case "CANCELADO":
                    marca = "http://maps.google.com/mapfiles/ms/icons/red-dot.png";
                    break;
                case "PROCESO":                    
                    marca = "http://maps.google.com/mapfiles/ms/icons/yellow-dot.png";
                    break;
            }
            return marca;
        }

        private void InformacionPaciente(EntPacientes epaciente)
        {
            //lblChofer.Text = epaciente.Nombre;
        }

    }
}