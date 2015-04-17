<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarOperador.aspx.cs" Inherits="Ext.Web.Paginas.Choferes.ModificarOperador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" >
$(document).ready(function () { 

 $("#<%= txtNumEmpleado.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtNumEmpleado.ClientID %>").val());
            }
        });


        $("#ContentPrincipal_ddEstados").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });


        $("#MensajeNoEncontrado").hide();
        $("#Agregado").hide();


        $(".close").on('click', function () {
            $("#MensajeNoEncontrado").hide();
            $("#Agregado").hide();

        });

    });

    function Delegacion(valor) {
        $(document).ready(function () {
            if (valor == 9)
                $(".distrito").text('Delegación');
            else
                $(".distrito").text('Ciudad');
        });
    }

    function OperadorNoEncontrado(numpaciente) {
        $(document).ready(function () {
            $("#MensajeNoEncontrado").show();
            $(".msjpaciente").html('El Operador con el Número de Empleado <strong>' + numpaciente + '</strong> no se encuentra registrado!');
        });
    }

    function __doPostBack(eventTarget, eventArgument) {
        document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
        document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
        document.forms.form1.submit();
    }

    function LimpiarControles() {
        $(document).ready(function () {
            $('input[type=text]').each(function () {
                $(this).val('');
            });
        });
    }
</script>
<style type="text/css">

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<asp:ScriptManager ID="sManager" runat="server"></asp:ScriptManager>
<div class="container">
 <div id="MensajeNoEncontrado" class="alert alert-warning">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjpaciente"></span>
        </div>
        <div id="Agregado" class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjpaciente"></span>
        </div>
<div align="center">
    <div class="form-group">
    <table>
    <tr>
    <td><label for="NumEmpleado">Num. Empleado:</label> </td>
    <td></td>
    <td>
    <asp:TextBox ID="txtNumEmpleado" runat="server" CssClass="form-control"></asp:TextBox></td>
    </tr>
    <tr>
            <td><label>Empleado:</label></td><td></td>
            <td><asp:DropDownList ID="ddTipoOperador" runat="server">
                <asp:ListItem Selected="True" Value="1">Operador</asp:ListItem>
                <asp:ListItem Value="2">Auxiliar</asp:ListItem>
                </asp:DropDownList></td>
        </tr>       
        <tr>
            <td><label>Nombre(s):</label></td><td></td>
            <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Apellido Paterno:</label></td><td></td>
            <td><asp:TextBox id="txtApePat" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Apellido Materno:</label></td><td></td>
            <td><asp:TextBox id="txtApeMat" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>RFC:</label></td><td></td>
            <td><asp:TextBox id="txtRFC" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Clave INE - IFE:</label></td><td></td>
            <td><asp:TextBox id="txtINE" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Estado:</label></td><td></td>
            <td><asp:DropDownList ID="ddEstado" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><label class="distrito">Ciudad:</label></td><td></td>
            <td><asp:DropDownList ID="ddCiudad" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><label>Colonia:</label></td><td></td>
            <td><asp:TextBox id="txtColonia" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>CP:</label></td><td></td>
            <td><asp:TextBox id="txtCP" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Calle:</label></td><td></td>
            <td><asp:TextBox id="txtCalle" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Num. Exterior:</label></td><td></td>
            <td><asp:TextBox id="txtNumExt" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Num. Interior:</label></td><td></td>
            <td><asp:TextBox id="txtNumInt" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Telefono Fijo:</label></td><td></td>
            <td><asp:TextBox id="txtTelFijo" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Telefono Móvil:</label></td><td></td>
            <td><asp:TextBox id="txtTel_cel" runat ="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td><label>Licencia de Manejo:</label></td><td></td>
            <td> <asp:TextBox id="txtLicencia" runat ="server"></asp:TextBox></td>
        </tr>
                 <tr>
            <td><label>Vigencia de Licencia:</label></td><td></td>
            <td>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="txtVigenciaLic" Format="dd/MM/yyyy" />
                <asp:TextBox id="txtVigenciaLic" runat ="server"></asp:TextBox></td>
        </tr>  
        <tr>
        <td></td>
        <td></td>
        <td><asp:Button id="btnGuardar" runat="server" Text="Guardar Cambios" UseSubmitBehavior="false"
                CssClass="btn btn-block" onclick="btnGuardar_Click"/></td>
        </tr>    
       
    </table>
    </div>
</div>
</div>

</asp:Content>
