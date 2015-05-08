<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="DetalleOperadores.aspx.cs" Inherits="Ext.Web.Paginas.Choferes.DetalleOperadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server" >
<div class="container">
<div><asp:GridView ID="gvInfoOperador" runat="server" DataKeyNames="IdUsuario" 
        AutoGenerateColumns="false" onrowdeleting="gvInfoOperador_RowDeleting" 
        onrowediting="gvInfoOperador_RowEditing" CssClass="table table-striped table-bordered table-condensed">
<Columns>
<asp:TemplateField HeaderText="ID" Visible="false">
<ItemTemplate>
    <asp:Label ID="lblIdChofer" runat="server" Text='<%#Eval("IdUsuario") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="true" EditText="BAJA" />
</Columns>
</asp:GridView> </div>
</div>
</asp:Content>
