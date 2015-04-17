<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" Inherits="Ext.Web.Paginas.Choferes.Choferes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {

        $("#<%= chkPassword.ClientID %>").on('click', function () {
            var checado = $("#<%= chkPassword.ClientID %>").prop('checked');
            if (checado) {
                $(".passauto").show(); // css('display', 'block');
                $(".passmanual").hide(); // css('display', 'none');
                $("#<%= txtContraseña.ClientID %>").hide(); //.css('display', 'none')
            }
            else {
                $(".passauto").css('display', 'none');
                $(".passmanual").css('display', 'block');
            }
        });

        $("#ContentPrincipal_ddEstado").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });


        $("#divwarning").hide();
        $("#divdanger").hide();
        $("#divsuccess").hide();


        $(".close").on('click', function () {
            $("#divwarning").hide();
            $("#divdanger").hide();
            $("#divsuccess").hide();

        });




    });


    function AgregadoNuevoC(usuario) {
        alert('Empleado dado de alta , ID:' + usuario);
        $(document).ready(function () {
            $("#<%= txtNombre.ClientID %>").val("");
            $("#<%= txtApePat.ClientID %>").val("");
            $("#<%= txtApeMat.ClientID %>").val("");
            $("#<%= txtRFC.ClientID %>").val("");
            $("#<%= txtINE.ClientID %>").val("");
            $("#<%= txtColonia.ClientID %>").val("");
            $("#<%= txtCP.ClientID %>").val("");
            $("#<%= txtNumExt.ClientID %>").val("");
            $("#<%= txtNumInt.ClientID %>").val("");
            $("#<%= txtTelFijo.ClientID %>").val("");
            $("#<%= txtTel_cel.ClientID %>").val("");
            $("#<%= txtLicencia.ClientID %>").val("");
            $("#<%= txtCorreo.ClientID %>").val("");
            $("#<%= txtContraseña.ClientID %>").val("");
            $("#<%= lblpassauto.ClientID %>").text("");
            $("#<%= txtCalle.ClientID %>").text("");
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
    function MsjAgregado(empleado) {

        $(document).ready(function () {
            $("#divsuccess").show();
            $(".msjalert").html('');
            $(".msjalert").html('Empleado Agregado Existosamente. ID:<strong>'+empleado+'</strong> ');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <div id="altaChoferes">
<div class="container-fluid">Alta de Operadores</div>
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
    <table> 
        <tr>
            <td><label>Empleado: </label></td>
            <td><asp:DropDownList ID="ddTipoOperador" runat="server">
                <asp:ListItem Selected="True" Value="1">Operador</asp:ListItem>
                <asp:ListItem Value="2">Auxiliar</asp:ListItem>
                </asp:DropDownList></td>
        </tr>       
        <tr>
            <td><label>Nombre(s):</label></td>
            <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Apellido Paterno:</label></td>
            <td><asp:TextBox id="txtApePat" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Apellido Materno:</label></td>
            <td><asp:TextBox id="txtApeMat" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>RFC:</label></td>
            <td><asp:TextBox id="txtRFC" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Clave INE - IFE:</label></td>
            <td><asp:TextBox id="txtINE" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Estado:</label></td>
            <td><asp:DropDownList ID="ddEstado" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><label class="distrito">Ciudad:</label></td>
            <td><asp:DropDownList ID="ddCiudad" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><label>Colonia:</label></td>
            <td><asp:TextBox id="txtColonia" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>CP:</label></td>
            <td><asp:TextBox id="txtCP" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Calle:</label></td>
            <td><asp:TextBox id="txtCalle" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Num. Exterior:</label></td>
            <td><asp:TextBox id="txtNumExt" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Num. Interior:</label></td>
            <td><asp:TextBox id="txtNumInt" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Telefono Fijo:</label></td>
            <td><asp:TextBox id="txtTelFijo" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label>Telefono Móvil:</label></td>
            <td><asp:TextBox id="txtTel_cel" runat ="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td><label>Licencia de Manejo:</label></td>
            <td> <asp:TextBox id="txtLicencia" runat ="server"></asp:TextBox></td>
        </tr>
                 <tr>
            <td><label>Vigencia de Licencia:</label></td>
            <td>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="txtVigenciaLic" Format="dd/MM/yyyy"  />
                <asp:TextBox id="txtVigenciaLic" runat ="server"></asp:TextBox></td>
        </tr>
                 <tr>
            <td><label>Num.Empleado:</label></td>
            <td><asp:TextBox id="txtNumEmpleado" runat ="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><label>Correo Electronico:</label></td>
            <td><asp:TextBox ID="txtCorreo" runat="server"/></td>
        </tr>
        <tr>
            <td>Generar Password: </td>
            <td><asp:CheckBox ID="chkPassword" runat="server" AutoPostBack="true" /></td>
        </tr>
        <tr>
            <td><label>Contraseña:</label></td>
            <td><span class="passauto"><asp:Label ID="lblpassauto" runat="server"></asp:Label></span><span class="passmanual"><asp:TextBox ID="txtContraseña" runat="server"/></span></td>
        </tr>
        
        <tr>
            <td></td>
            <td><asp:Button id="btnAgregar" runat="server" Text="Guardar Operador" CssClass="btn-block" UseSubmitBehavior="false"
                    onclick="btnAgregar_Click"/></td>
        </tr>
    </table>
</div>


<div id="consulta">

</div>
<asp:HiddenField ID="hdpassauto" Value="" runat="server" />
</asp:Content>
