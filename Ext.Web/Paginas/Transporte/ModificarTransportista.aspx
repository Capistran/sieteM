<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarTransportista.aspx.cs" Inherits="Ext.Web.Paginas.Transporte.ModificarTransportista"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {

        $(".FormatoB").hide();
        $(".FormatoA").show();

        $("#divwarning").hide();
        $("#divdanger").hide();
        $("#divsuccess").hide();

        $(".close").on('click', function () {
            $("#divwarning").hide();
            $("#divdanger").hide();
            $("#divsuccess").hide();

        });

        $("#<%= txtClaveTransporte.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtClaveTransporte.ClientID %>").val());
            }
        });

        $("#<%= ddFormatoDir.ClientID %>").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });
        $("#ContentPrincipal_ddEstados").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });


        //$(".distrito").val('Delegacion');

    });


    function Delegacion(valor) {
        $(document).ready(function () {
            if (valor == 9)
                $(".distrito").text('Delegación');
            else
                $(".distrito").text('Ciudad');
        });
    }

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

    function MsjActualizado() {
        $(document).ready(function () {
            $("#divsuccess").show();
            $(".msjalert").html('');
            $(".msjalert").html('CEDIS Agregado Exitosamente');
        });
    }

    function MsjError(msjerr) {
        $(document).ready(function () {
            $("#divdanger").show();
            $(".msjalert").html('');
            $(".msjalert").html('<strong>' + msjerr + '</strong>');
        });
    }

    function __doPostBack(eventTarget, eventArgument) {
        document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
        document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
        document.forms.form1.submit();
    }
</script>
<style type="text/css">
    .style1
    {
        width: 90%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<div class="container">
 <div id="divwarning" class="alert alert-warning">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjalert"></span>
        </div>
    <div id="divdanger" class="alert alert-danger">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjalert"></span>
        </div>
        <div id="divsuccess" class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjalert"></span>
        </div>
<table class="style1">
<tr>
<td><label>Clave Transporte:</label></td>
<td><asp:TextBox ID="txtClaveTransporte" runat="server"></asp:TextBox></td>
<td>&nbsp;</td>
<td><label>Nombre Comercial:</label></td>
<td><asp:TextBox ID="txtNombreComercial" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td><label>Razon Social:</label></td>
<td><asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox></td>
<td>&nbsp;</td>
<td><label>RFC:</label></td>
<td><asp:TextBox ID="txtRFC" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td><label>Usuario:</label></td>
<td><asp:TextBox ID="txtUsuarioWeb" runat="server"></asp:TextBox></td>
<td>&nbsp;</td>
<td><label>Password:</label></td>
<td><asp:TextBox ID="txtPasswordWeb" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td><label>Web GPS:</label></td>
<td><asp:TextBox ID="txtUrlGPS" runat="server"></asp:TextBox></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
</table>
 <table class="style1">
       <tr>
            <td >
                <label>Entidad Federativa:</label></td>
            <td>
               <asp:DropDownList ID="ddEstados" runat ="server" ></asp:DropDownList></td>
            <td>
                &nbsp;</td>
            <td>
                <label class="distrito">Ciudad:</label></td>
            <td>
                <asp:DropDownList ID="ddCiudad" runat="server"></asp:DropDownList></td>
        </tr>
           <tr>
            <td >
                <label>Formato Direccion:</label></td>
            <td>
                <%--<input  type="text" id="txtColonia"/>--%>
                <asp:DropDownList ID="ddFormatoDir" runat ="server" AutoPostBack="false">
                    <asp:ListItem Value="1">Formato A</asp:ListItem>
                    <asp:ListItem Value="2">Formato B</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
            <td>
                </td>
            <td>
               <%-- <input  type="text" id="txtCalle"/>--%>
                
                </td>
        </tr>
        <tr class="FormatoA">
            <td >
                <label>Colonia:</label></td>
            <td>
                <%--<input  type="text" id="txtColonia"/>--%>
                <asp:TextBox ID="txtColonia" runat="server"/>                
                </td>
            <td>
                &nbsp;</td>
            <td>
                <label>Calle:</label></td>
            <td>
               <%-- <input  type="text" id="txtCalle"/>--%>
                <asp:TextBox ID="txtCalle" runat="server"/>
                </td>
        </tr>
         <tr class="FormatoB">
            <td >
                <label>Super Manzana:</label></td>
            <td>
                <%--<input  type="text" id="txtColonia"/>--%>
                <asp:TextBox ID="txtSuperManzana" runat="server"/>                
                </td>
            <td>
                &nbsp;</td>
            <td>
                <label>Manzana:</label></td>
            <td>
               <%-- <input  type="text" id="txtCalle"/>--%>
                <asp:TextBox ID="txtManzana" runat="server"/>
                </td>
        </tr>
         <tr class="FormatoB">
            <td >
                <label>Lote:</label></td>
            <td>
                <%--<input  type="text" id="txtColonia"/>--%>
                <asp:TextBox ID="txtLote" runat="server"/>                
                </td>
            <td>
                &nbsp;</td>
            <td>
                </td>
            <td>
               <%-- <input  type="text" id="txtCalle"/>--%>
                
                </td>
        </tr>
        <tr>
            <td >
                <label>Codigo Postal:</label></td>
            <td>
                <%--<input  type="text" id="txtColonia"/>--%>
                <asp:TextBox ID="txtCP" runat="server"/>                
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
               <%-- <input  type="text" id="txtCalle"/>--%>
               &nbsp;
                </td>
        </tr>
        <tr>
            <td>
               <label>Número Exterior:</label></td>
            <td>
               <%--<input  type="text" id="txtNumExt"/>--%>
               <asp:TextBox ID="txtNumExt" runat="server"/>
               </td>
            <td>
                &nbsp;</td>
            <td>
               <label>Número Interior:</label></td>
            <td>
                <%--<input  type="text" id="txtNumInt"/>--%>
                <asp:TextBox ID="txtNumInt" runat="server"/>
                </td>
                  <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <label>Telefono Fijo:</label></td>
            <td>
               <%-- <input  type="text" id="txtTelFijo"/>--%>
                <asp:TextBox ID="txtTelFijo" runat="server"/>
                </td>
                  <td>
                &nbsp;</td>
            <td>
               <label>Telefono Celular:</label></td>
            <td>
                <%--<input  type="text" id="txtTelCel"/>--%>
                <asp:TextBox ID="txtTelCel" runat="server"/>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        
    </table>
<div>
<asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" 
        UseSubmitBehavior="false" onclick="btnGuardar_Click"/>
</div>
</div>

</asp:Content>
