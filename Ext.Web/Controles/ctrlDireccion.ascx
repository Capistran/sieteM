<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDireccion.ascx.cs" Inherits="Ext.Web.Controles.ctrlDireccion" %>

<script type="text/javascript" src="../../js/fnComun.js" ></script>

<style type="text/css">
    .style1
    {
        width: 90%;
    }
</style>

<div class="container"> 
    
    <table class="style1">
       <tr>
            <td >
                <label>Entidad Federativa:</label></td>
            <td>
               <asp:DropDownList ID="ddEstados" runat ="server" ></asp:DropDownList></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Ciudad:</label></td>
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
        <tr>
            <td >
                <label>Telefono Fijo:</label></td>
            <td>
               <%-- <input  type="text" id="txtTelFijo"/>--%>
                <asp:TextBox ID="txtTelFijo" runat="server"/>
                </td>
                  <td>
                &nbsp;</td>
            <td>
               <label>Telefono Celular:</label></td>
            <td>
                <%--<input  type="text" id="txtTelCel"/>--%>
                <asp:TextBox ID="txtTelCel" runat="server"/>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        
    </table>
    
</div>