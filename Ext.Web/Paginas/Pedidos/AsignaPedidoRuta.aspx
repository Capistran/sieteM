<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="AsignaPedidoRuta.aspx.cs" Inherits="Ext.Web.Paginas.Pedidos.AsignaPedidoRuta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 90%;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $("#<%= txtNumPaciente.ClientID %>").keyup(function (e) {
                if (e.keyCode == 13) {
                    __doPostBack(this.name, $("#<%= txtNumPaciente.ClientID %>").val());
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

            $("#ContentPrincipal_ddRuta").change(function (event) {
                __doPostBack(this.name, $("#ContentPrincipal_ddRuta").val());
            });

        });
        function __doPostBack(eventTarget, eventArgument) {
            document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
            document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
            document.forms.form1.submit();
        }

        function MsjError(msjerr) {
            $(document).ready(function () {
                $("#divdanger").show();
                $(".msjalert").html('');
                $(".msjalert").html('<strong>' + msjerr + '</strong>');
            });
        }
        
        function MsjSuccess(msjsucc) {
            $("#divsuccess").show();
            $(".msjalert").html('');
            $(".msjalert").html(msjsucc);
        }

        function MsjOtro(msj) {
            $(document).ready(function () {
                $("#divwarning").show();
                $(".msjalert").html('');
                $(".msjalert").html('<strong>' + msj + '</strong>');

            });
        }
        
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

    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Número Paciente:</label></td>
            <td>
              <asp:TextBox ID="txtNumPaciente" runat="server"></asp:TextBox></td>
            <td>
                <label>Ruta:</label></td>
            <td>
                <label><asp:DropDownList ID="ddRuta" runat="server"></asp:DropDownList></label></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Fecha Entrega:</label></td>
            <td>
               <cc1:CalendarExtender ID="clnr" runat="server" TargetControlID="txtFechaEntrega" Format="dd/MM/yyyy" /> <asp:TextBox ID="txtFechaEntrega" runat="server"></asp:TextBox></td>
            <td>
               <label>Mes: </label></td>
            <td>
                <asp:DropDownList ID="ddMes" runat="server">
                    <asp:ListItem Selected="True">ENERO</asp:ListItem>
                    <asp:ListItem>FEBRERO</asp:ListItem>
                    <asp:ListItem>MARZO</asp:ListItem>
                    <asp:ListItem>ABRIL</asp:ListItem>
                    <asp:ListItem>MAYO</asp:ListItem>
                    <asp:ListItem>JUNIO</asp:ListItem>
                    <asp:ListItem>JULIO</asp:ListItem>
                    <asp:ListItem>AGOSTO</asp:ListItem>
                    <asp:ListItem>SEPTIEMBRE</asp:ListItem>
                    <asp:ListItem>OCTUBRE</asp:ListItem>
                    <asp:ListItem>NOVIEMBRE</asp:ListItem>
                    <asp:ListItem>DICIEMBRE</asp:ListItem>
                </asp:DropDownList></td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td><td>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div class="infoDetallePedido">
    <asp:GridView ID="gvDetallePedido" runat="server" AutoGenerateColumns="false" Visible="false">
    <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate >
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("IdProducto") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activar Producto" >
                    <ItemTemplate >
                    <asp:CheckBox ID="chkHabilitado" runat="server" />                        
                    </ItemTemplate>                    
                </asp:TemplateField>              
                  <asp:TemplateField HeaderText="Código" >
                    <ItemTemplate >
                        <asp:Label ID="lblClave" runat="server" Text='<%#Eval("Clave") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate >
                        <asp:Label ID="lblMarca" runat="server" Text='<%#Eval("Marca") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Cajas" ControlStyle-Width="40%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                        <asp:TextBox ID="txtCantidadCajas" runat="server"></asp:TextBox>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Paquetes" ControlStyle-Width="40%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                        <asp:TextBox ID="txtCantidadPaquetes" runat="server"></asp:TextBox>
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="No. Piezas" ControlStyle-Width="40%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                        <asp:TextBox ID="txtCantidadPieza" runat="server"></asp:TextBox>
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate >
                        <asp:Label ID="lblDescripcion" runat="server" Text='<%#Eval("Descripcion") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
    
    </div>
    <div aling="center">
    
                <asp:Button id="btnAsignar" runat="server" Text="Asignar" UseSubmitBehavior="false"
                    onclick="btnAsignar_Click"/>
    </div>
</div>
</asp:Content>
