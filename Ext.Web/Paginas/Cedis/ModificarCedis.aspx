<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarCedis.aspx.cs" Inherits="Ext.Web.Paginas.Cedis.ModificarCedis" %>

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

        $("#<%= txtClaveCedis.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtClaveCedis.ClientID %>").val());
            }
        });

        $("#<%= ddFormatoDir.ClientID %>").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });
        $("#ContentPrincipal_ddEstados").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });

        $("#<%= txtClaveCedis.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtClaveCedis.ClientID %>").val());
            }
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

    function MsjActualizado() {
        $(document).ready(function () {
            $("#divsuccess").show();
            $(".msjalert").html('');
            $(".msjalert").html('CEDIS Modificado Exitosamente');
        });
    }

    function MsjNoEncontrado() {
        $(document).ready(function () {
            $("#divwarning").show();
            $(".msjalert").html('');
            $(".msjalert").html('CEDIS No encontrado');
        });
    }

    function MsjError(msjerr) {
        $(document).ready(function () {
            $("#divdanger").show();
            $(".msjalert").html('');
            $(".msjalert").html('<strong>' + msjerr + '</strong>');
        });
    }
    function limpiarControles() {
        $(document).ready(function () {
            $('input[type=text]').each(function () {
                $(this).val('');
            });
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

    function __doPostBack(eventTarget, eventArgument) {
        document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
        document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
        document.forms.form1.submit();
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
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
            <td >
                <label>Clave Cedis:</label></td>
            <td>
            <asp:TextBox ID="txtClaveCedis" runat="server"></asp:TextBox> 
               </td>
            <td>
                &nbsp;</td>
            <td>
                <label>Nombre CEDIS:</label></td>
            <td><asp:TextBox ID="txtNombreCedis" runat="server"></asp:TextBox>
               </td>
        </tr>
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
        
        
    </table>
<div><asp:Button id="btnGuardar" Text="Guardar Cambios" runat="server"  UseSubmitBehavior="false"
        onclick="btnGuardar_Click"/></div>
</div>
</asp:Content>
