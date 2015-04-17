<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Ext.Web.Paginas.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        $(document).ready(function () {

            $(".FormatoB").hide();
            $(".FormatoA").show();
            function ValidaDatos() {

            }
            //<!--/^-?[0-9]+([,\.][0-9]*)?$/-->
            $("#<%= txtNombres.ClientID %>").click(function () {

            });

            $("#<%= txtNombres.ClientID %>").keyup(function () {

            });

            $(".decimales").keyup(function (e) {

            });
            //ddFormatoDir

            $("#<%= ddFormatoDir.ClientID %>").change(function (event) {
                __doPostBack(this.name, $(this).val());
            });
            $("#ContentPrincipal_ddEstados").change(function (event) {
                __doPostBack(this.name, $(this).val());
            });
        });

        function FormatoDireccion(formato) {
            $(document).ready(function () {

                if (formato == '1') {
                    $(".FormatoB").hide();
                    $(".FormatoA").show();
                }
                else {
                    $(".FormatoA").hide();
                    $(".FormatoB").show();
                }
            });
        }


        function Delegacion(valor) {
            $(document).ready(function () {
                if (valor == 9)
                    $(".distrito").text('Delegación');
                else
                    $(".distrito").text('Ciudad');
            });
        }
        function LimpiarControles() {
            $(document).ready(function () {
                $('input[type=text]').each(function () {
                    $(this).val('');
                });
            });
        }
        function __doPostBack(eventTarget, eventArgument) {
            document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
            document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
            document.forms.form1.submit();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <div></div>
    <div>
    <div class="sombras">
    <div class="row separa">
        <div class="col-md-3  "><label>Número Paciente:</label></div>
        <div class="col-md-3   "><asp:TextBox ID="txtClavePaciente" runat="server"  ></asp:TextBox></div>
     
    </div>
    <div class="row ">
        <div class="col-md-3 separa "><label>Nombre(s):</label></div>
        <div class="col-md-3  separa"><asp:TextBox ID="txtNombres" runat="server"></asp:TextBox></div>
        
    </div>
    <div class="row separa">
        <div class="col-md-3  separa" ><label>Apellido Paterno: </label></div>
        <div class="col-md-3 separa"><asp:TextBox ID="txtApePat" runat="server"/></div>
        <div class="col-md-3 separa" ><label>Apellido Materno: </label></div>
        <div class="col-md-3 separa"><asp:TextBox ID="txtApeMat" runat="server"/></div>
    </div>
    <div class="row separa">
        <div class="col-md-3 separa"><label>No. Filiación:</label></div>
        <div class="col-md-3 separa"><asp:TextBox ID="txtNSS" runat="server"/></div>
        <div class="col-md-3 separa"><label>Institución:</label></div>
        <div class="col-md-3 separa"><asp:DropDownList ID="ddInstitucion" runat="server"><asp:ListItem Selected="True">
                
                IMSS</asp:ListItem>
                    <asp:ListItem>ISSTE</asp:ListItem>
                </asp:DropDownList></div>
    </div>
    <div class="row separa">
        <div class="col-md-3 separa"> <label>Latitud:</label></div>
        <div class="col-md-3 separa"> <asp:TextBox ID="txtLatitud" runat="server" CssClass="decimales"/></div>
        <div class="col-md-3 separa"> <label>Longitud:</label></div>
        <div class="col-md-3 separa"><asp:TextBox ID="txtLongitud" runat="server"/></div>
    </div>
    <div class="row  separa">
        <div class="col-md-3"><label>Entidad Federativa:</label></div>
        <div class="col-md-3"><asp:DropDownList ID="ddEstados" runat ="server" ></asp:DropDownList></div>
        <div class="col-md-3"><label class="distrito">Ciudad:</label></div>
        <div class="col-md-3"><asp:DropDownList ID="ddCiudad" runat="server"></asp:DropDownList></div>
    </div>
    <div class="row  separa">
        <div class="col-md-3"><label>Formato Direccion:</label></div>
        <div class="col-md-3"><asp:DropDownList ID="ddFormatoDir" runat ="server">
                    <asp:ListItem Value="1">Formato A</asp:ListItem>
                    <asp:ListItem Value="2">Formato B</asp:ListItem>
                </asp:DropDownList></div>        
    </div>
    <div class="row FormatoA  separa">
        <div class="col-md-3"><label>Colonia:</label></div>
        <div class="col-md-3"> <asp:TextBox ID="txtColonia" runat="server"/> </div>
        <div class="col-md-3"><label>Calle:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtCalle" runat="server"/></div>
    </div>
    <div class="row FormatoB  separa">
        <div class="col-md-3"><label>Super Manzana:</label></div>
        <div class="col-md-3"> <asp:TextBox ID="txtSuperManzana" runat="server"/></div>
        <div class="col-md-3"><label>Manzana:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtManzana" runat="server"/></div>
    </div>
    <div class="row FormatoB separa">
        <div class="col-md-3"><label>Lote:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtLote" runat="server"/> </div>       
    </div>
    <div class="row separa">
        <div class="col-md-3"> <label>Codigo Postal:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtCP" runat="server"/> </div>       
    </div>
    <div class="row separa">
        <div class="col-md-3"> <label>Número Exterior:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtNumExt" runat="server"/></div>
        <div class="col-md-3"> <label>Número Interior:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtNumInt" runat="server"/></div>
    </div>
    <div class="row separa">
        <div class="col-md-3"><label>Telefono Fijo:</label></div>
        <div class="col-md-3"><asp:TextBox ID="txtTelFijo" runat="server"/></div>
        <div class="col-md-3"> <label>Telefono Celular:</label></div>
        <div class="col-md-3"> <asp:TextBox ID="txtTelCel" runat="server"/></div>
    </div>
    <div align="center">
    <asp:Button id="btnNuevoPaciente" runat="server" Text="Nuevo Paciente"  CssClass="btn-default" 
                    onclick="btnNuevoPaciente_Click"/>
    </div>

    </div>
    </div>

    <br />
    <br />
    <div class="infopacientes">
    <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" ></asp:GridView>
    </div>
    <input type="hidden" id="hdApePat" value="" />
    <asp:HiddenField  ID="HDApePat" runat="server" Value=""/>
</asp:Content>
