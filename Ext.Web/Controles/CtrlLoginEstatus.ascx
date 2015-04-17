<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLoginEstatus.ascx.cs" Inherits="Ext.Web.Controles.CtrlLoginEstatus" %>
<table>
    <tr>
        <td>
            <asp:Label ID="lbltitulo" runat="server" Text="Bienvenido(a): " 
                Font-Bold="True" Font-Names="Calibri" Font-Size="Small" ForeColor="#E12A0B"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblnombreCompleto" runat="server" Font-Names="Calibri" 
                Font-Size="Small" ForeColor="#E12A0B"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Label ID="lbleMail" runat="server" Font-Names="Calibri" Font-Size="Small" 
                ForeColor="#E12A0B"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button UseSubmitBehavior="false" ID="btnCerrar" runat="server" Text="Cerrar Sesión" BorderStyle="None" 
                OnClick="btnCerrar_Click" Font-Names="Calibri" ForeColor="#E12A0B" />
        </td>
    </tr>
</table>