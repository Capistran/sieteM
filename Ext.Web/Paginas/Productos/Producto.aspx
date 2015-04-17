<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Ext.Web.Paginas.Productos.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" >

    $(document).ready(function () {
        $("#divwarning").hide();
        $("#divdanger").hide();
        $("#divsuccess").hide();


        $(".close").on('click', function () {
            $("#divwarning").hide();
            $("#divdanger").hide();
            $("#divsuccess").hide();

        });
    
    });


    function MsjAgregado() {
        $(document).ready(function () {
            $("#divsuccess").show();
            $(".msjalert").html('');
            $(".msjalert").html('CEDIS Agregado Exitosamente');
        });
    }

    function MsjExiste(cveProd) {
        $(document).ready(function () {
            $("#divwarning").show();
            $(".msjalert").html('');
            $(".msjalert").html('¡El producto con la Clave <strong>'+cveProd+'</strong> ya existe!');
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

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }



    function __doPostBack(eventTarget, eventArgument) {
        document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
        document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
        document.forms.form1.submit();
    }
    $(document).ready(function () {

        $("#<%= txtClaveProducto.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtClaveProducto.ClientID %>").val());
            }
        });
    });
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
            <td>
                &nbsp;</td>
            <td>
               <label>Codigo de Producto:</label></td>
            <td>
                <asp:TextBox ID="txtClaveProducto" runat="server" CssClass="input-medium"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Marca:</label></td>
                <td>
                <asp:TextBox ID="txtMarca" runat="server"> </asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Categoria:</label></td>
            <td>
               <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Descripcion</label></td>
                <td>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Piezas por Caja:</label></td>
            <td>
               <asp:TextBox ID="txtPiezaPorCaja" runat ="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                Paquetes por Caja:</td>
               <td><asp:TextBox ID="txtPaquetesCaja" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Pieza por Paquete:</label></td>
            <td>
              <asp:TextBox ID="txtPiezasPaquete" runat ="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
               <label>Código de barras:</label>
               
               </td>
               <td><asp:TextBox ID="txtCodBarras" runat="server"></asp:TextBox></td>
        </tr>
        
        
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
                 <td>
                <asp:Button id="btnAgregarProducto" runat="server" Text="Guardar" UseSubmitBehavior="false"
                         onclick="btnAgregarProducto_Click"/></td>
        </tr>
    </table>
    
</div>
</asp:Content>
