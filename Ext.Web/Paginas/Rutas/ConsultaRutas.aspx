<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ConsultaRutas.aspx.cs" Inherits="Ext.Web.Paginas.Rutas.ConsultaRutas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<div class="container">
<asp:GridView ID="gvRutas" runat="server" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false"></asp:GridView>
</div>
</asp:Content>
