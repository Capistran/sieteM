<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarUnidad.aspx.cs" Inherits="Ext.Web.Paginas.Unidad.ModificarUnidad" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript">
    function LimpiarControles() {
        $(document).ready(function () {
            $('input[type=text]').each(function () {
                $(this).val('');
            });
        });
    }

    function UnidadNoEncontrado(numpaciente) {
        $(document).ready(function () {
            $("#MensajeNoEncontrado").show();
            $(".msjpaciente").html('La unidad con número economico <strong>' + numpaciente + '</strong> no se encuentra registrada!');
        });
    }

    $(document).ready(function () {

        $("#<%= txtNumEconomico.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtNumEconomico.ClientID %>").val());
            }
        });

        $("#MensajeNoEncontrado").hide();
        $("#Agregado").hide();


        $(".close").on('click', function () {
            $("#MensajeNoEncontrado").hide();
            $("#Agregado").hide();

        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<asp:ScriptManager runat="server" ID="sm"> </asp:ScriptManager>
<div id="MensajeNoEncontrado" class="alert alert-warning">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjpaciente"></span>
        </div>
        <div id="Agregado" class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjpaciente"></span>
        </div>
<div class="container">
<table>
       
        <tr>
        
            <td><label>Num. Economico:</label></td>
                    <td><asp:TextBox ID="txtNumEconomico" runat="server"></asp:TextBox></td>
            <td><label>Modelo:</label></td>
            <td><asp:TextBox ID="txtModelo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Capacidad&nbsp; Carga:</label></td>
            <td><asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox></td>
            <td><label>Compañia de Seguros:</label></td>
            <td><asp:TextBox ID="txtSeguro" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td><label>No. de Poliza:</label></td>
            <td><asp:TextBox ID="txtPoliza" runat ="server"></asp:TextBox></td>
            <td><label>Vigencia de Poliza:</label></td>
            <td><cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"  TargetControlID="txtVigenciaPoliza" /><asp:TextBox ID="txtVigenciaPoliza" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
                    <td><label>Placas:</label></td>
                    <td><asp:TextBox ID="txtPlacas" runat="server"></asp:TextBox></td>
                        <td><label>Marca:</label></td>
            <td><asp:TextBox ID="txtMarca" runat="server"></asp:TextBox></td>
                    
        </tr>
        <tr>
                    <td><label>Codigo barras:</label></td>
                    <td><asp:TextBox ID="txtCodBarras" runat="server"></asp:TextBox></td>
                        <td></td>
            <td></td>
                    
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td><asp:Button id="btnAgregar" runat="server" Text="Guardar Cambios" UseSubmitBehavior="false"
                    onclick="btnAgregar_Click"/></td>
        </tr>

    </table>
</div>
</asp:Content>
