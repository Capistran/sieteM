<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificaHomeChoice.aspx.cs" Inherits="Ext.Web.Paginas.Maquinas.ModificaHomeChoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>

<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $(".mostrarserie").hide();
        $(".gridHistorial").hide();
        $("#<%= txtNumPaciente.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtNumPaciente.ClientID %>").val());
            }
        });
    });

    
    function MostrarSerie(mostrar) {
        $(document).ready(function () {
            if (mostrar == 1) {
                $(".mostrarserie").show();
                $(".gridHistorial").show();
            }
            else {
                $(".mostrarserie").hide();
                $(".gridHistorial").hide();
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
<div class="container">
<div>
    <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-condensed gridHistorial"> </asp:GridView>
</div>
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Numero Paciente:</label></td>
            <td>
               <asp:TextBox ID="txtNumPaciente" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="mostrarserie">
            <td>
                </td>
            <td>
                <label>Número Serie Actual:</label></td>
            <td>
              <asp:Label ID="lblSerie" runat="server"></asp:Label></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="mostrarserie" >
            <td>
                </td>
            <td>
                <label>Número Serie:</label></td>
            <td>
              <asp:TextBox ID="txtNoSerie" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td>
                &nbsp;</td>
            <td>
                </td>
            <td>
               <asp:Label ID="lblNombre" runat="server"></asp:Label></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td >
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambio" UseSubmitBehavior="false"
                    onclick="btnGuardar_Click" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
