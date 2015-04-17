<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Ext.Web.Paginas.Productos.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<div class="container">

    <div class="infoProducto">
    <asp:GridView ID="gvDetalleProducto" runat="server"  DataKeyNames="IdProducto"
            CssClass="table table-striped table-bordered table-condensed" 
            AutoGenerateColumns="false" onrowdeleting="gvDetalleProducto_RowDeleting" 
            onselectedindexchanging="gvDetalleProducto_SelectedIndexChanging" >
    <Columns>
        <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate >
                <asp:Label ID="lblID" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField  ShowDeleteButton="true" DeleteText="Eliminar"  ItemStyle-CssClass="eliminar"  />
    </Columns>
    
    </asp:GridView>
    </div>
</div>
</asp:Content>
