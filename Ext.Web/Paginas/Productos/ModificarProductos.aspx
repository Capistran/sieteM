<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarProductos.aspx.cs" Inherits="Ext.Web.Paginas.Productos.ModificarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" >
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

    function MsjModificado() {
        $(document).ready(function () {
            $("#divsuccess").show();
            $(".msjalert").html('');
            $(".msjalert").html('Producto Modificado Exitosamente');
        });
    }

    function MsjError(msjerr) {
        $(document).ready(function () {
            $("#divdanger").show();
            $(".msjalert").html('');
            $(".msjalert").html('<strong>' + msjerr + '</strong>');
        });
    }
$(document).ready(function () { 

 $("#<%= txtClaveProducto.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtClaveProducto.ClientID %>").val());
            }
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
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
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
<div class="container">

    <div class="ActProductos">
        <asp:GridView ID="gvModProductos" runat="server" AllowPaging="true" PageSize="10" Visible="false"
        AutoGenerateColumns="false" DataKeyNames="idProducto"
            CssClass="table table-striped table-bordered table-condensed" 
            onpageindexchanging="gvModProductos_PageIndexChanging" 
            onselectedindexchanging="gvModProductos_SelectedIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIdProducto" runat="server" Text="<%# Eval('IdProducto')%>>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:CommandField  ShowSelectButton="true"/> 
            </Columns>
            
        </asp:GridView>
    
    </div>

    <div class="detalleProducto">
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
               <asp:TextBox ID="txtPiezaPorCaja" runat ="server" CssClass=""></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
               <label>Paquetes por Caja:</label></td>
               <td><asp:TextBox ID="txtPaquetesCaja" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Piezas por Paquete:</label></td>
            <td>
               <asp:TextBox ID="txtPiezasPaquete" runat ="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Código de Barras:</label></td>
               <td><asp:TextBox ID="txtCodBarras" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
               &nbsp;</td>
            <td>
             &nbsp;  </td>
            <td>
                &nbsp;</td>
            <td>
               &nbsp;</td>
               <td>&nbsp;</td>
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
                 <asp:Button id="btnGuardar" runat="server" CssClass="btn-block" UseSubmitBehavior="false" 
                         Text="Guardar Cambios" onclick="btnGuardar_Click"/>
                </td>
        </tr>
        </table>
    </div>

</div>
</asp:Content>
