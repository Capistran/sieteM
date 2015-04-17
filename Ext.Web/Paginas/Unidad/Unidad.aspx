<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="Unidad.aspx.cs" Inherits="Ext.Web.Paginas.Unidad.Unidad" %>
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
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
<div>
    <table>
        
        <tr>
            <td><label>Marca:</label></td>
            <td><asp:TextBox ID="txtMarca" runat="server"></asp:TextBox></td>
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
                    <td><label>Num. Economico:</label></td>
                    <td><asp:TextBox ID="txtNumEconomico" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
                    <td><label>Codigo Barras:</label></td>
                    <td><asp:TextBox ID="txtCodBarras" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td><asp:Button id="btnAgregar" runat=server Text="Guardar" UseSubmitBehavior="false"
                    onclick="btnAgregar_Click"/></td>
        </tr>

    </table>
</div>
</asp:Content>
