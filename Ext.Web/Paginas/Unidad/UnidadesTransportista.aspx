<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="UnidadesTransportista.aspx.cs" Inherits="Ext.Web.Paginas.Unidad.UnidadesTransportista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">

<div>
<asp:GridView ID="gvUnidades" runat="server" AutoGenerateColumns="false"></asp:GridView>
</div>
</asp:Content>
