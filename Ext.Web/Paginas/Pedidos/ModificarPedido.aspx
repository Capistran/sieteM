<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarPedido.aspx.cs" Inherits="Ext.Web.Paginas.Pedidos.ModificarPedido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" >

    $(document).ready(function () {

        $(".ruta").hide();
        $("#<%= txtNumeroPaciente.ClientID %>").keyup(function (e) {
            if ($(this).val() != '') {
                if (e.keyCode == 13) {
                    __doPostBack(this.name, $("#<%= txtNumeroPaciente.ClientID %>").val());
                }
            }
            else {
                MsjOtro("Debe Ingresar el Numero de Paciente");
                $(this).focus();
            }
        });


        $("#<%= ddTratamiento.ClientID %>").change(function (event) {
            __doPostBack(this.name, $("#<%= ddTratamiento.ClientID %>").val());
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


        function OcultaRuta(bandera) {        
            $(document).ready(function () { 
            if(bandera==1)
                       $(".ruta").hide();
                       else
                           $(".ruta").show();
                   });
               }
               function MjsModificado(msj) {
                   $(document).ready(function () {
                       $("#divsuccess").show();
                       $(".msjalert").html('');
                       if (msj != '')
                           $(".msjalert").html('Pedido Modificado Exitosamente');
                       else
                           $(".msjalert").html('Pedido Generado Exitosamente');

                   });
               }

               function MsjOtro(msj) {
                   $(document).ready(function () {
                       $("#divwarning").show();
                       $(".msjalert").html('');
                       $(".msjalert").html('<strong>'+msj+'</strong>');                     

                   });
               }

               function MsjError(msjerr) {
                   $(document).ready(function () {
                       $("#divdanger").show();
                       $(".msjalert").html('');
                       $(".msjalert").html('<strong>' + msjerr + '</strong>');
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
<div>
<table>
<tr>
<td><label>Número Paciente:</label></td>
<td><asp:TextBox id="txtNumeroPaciente" runat="server"></asp:TextBox></td>
</tr>
<tr class="pedido">
<td ><label>Tratamiento:</label></td>
<td><asp:DropDownList ID="ddTratamiento" runat="server"></asp:DropDownList></td>
</tr>
<tr class="pedido">
<td><label>Mes de Pedido:</label></td>
<td> <asp:DropDownList ID="ddMes" runat="server">
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
</tr>
</table>
</div>
<div class="ruta">
    <table>
    <tr>
    <td><label>Ruta:</label></td>
    <td><asp:DropDownList ID="ddRuta" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
       <td>Fecha Entrega:</td>
        <td><cc1:CalendarExtender  ID="cld1" runat="server" TargetControlID="txtFechaEntrega"  Format="dd/MM/yyyy"/><asp:TextBox id="txtFechaEntrega" runat="server"></asp:TextBox></td>
        
    </tr>
    </table>
</div>
<div class="nompaciente">
    <asp:Label ID="lblNombrePaciente" runat="server"></asp:Label>
</div>
<div class="gvTratamiento">
<asp:GridView ID="gvDetallePedido" runat="server" AutoGenerateColumns="false" DataKeyNames="IdPedido" CssClass="table table-striped table-bordered table-condensed"> 
<Columns>
<asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate >
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("EProducto.IdProducto") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Activar Producto" >
                    <ItemTemplate >
                    <asp:CheckBox ID="chkHabilitado" Checked='<%#Eval("Habilitado") %>' runat="server" />                        
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Código" >
                    <ItemTemplate >
                        <asp:Label ID="lblClave" runat="server" Text='<%#Eval("EProducto.Clave") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate >
                        <asp:Label ID="lblMarca" runat="server" Text='<%#Eval("EProducto.Marca") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Cajas" ControlStyle-Width="40%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                        <asp:TextBox ID="txtCantidadCajas" Text='<%#Eval("CantidadCaja") %>'  runat="server"></asp:TextBox>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Paquetes" ControlStyle-Width="40%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                        <asp:TextBox ID="txtCantidadPaquetes" Text='<%#Eval("CantidadPaqutes") %>'   runat="server"></asp:TextBox>
                    </ItemTemplate>                    
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="No. Piezas"   ControlStyle-Width="40%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                        <asp:TextBox ID="txtCantidadPieza" runat="server"  Text='<%#Eval("CantidadSuelto") %>'></asp:TextBox>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lote" ControlStyle-Width="80%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="txtLote" Text='<%#Eval("EProducto.Lote") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate >
                        <asp:Label ID="lblDescripcion" runat="server" Text='<%#Eval("EProducto.Descripcion") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
</Columns>
</asp:GridView>
</div>
</div>
<div class="gvActualiza container">
 <asp:GridView ID="gvActualiza" runat="server" AutoGenerateColumns="false" DataKeyNames="IdProducto" CssClass="table table-striped table-bordered table-condensed">
            <Columns>
              <asp:TemplateField HeaderText="Activar Producto" >
                    <ItemTemplate >
                    <asp:CheckBox ID="chkHabilitado" runat="server" />                        
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate >
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("IdProducto") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="Lote" ControlStyle-Width="80%" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="txtLote" runat="server"></asp:TextBox>
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
<div>
<asp:Button id="btnGuardar" runat="server" Text="Guardar"  UseSubmitBehavior="false"
        onclick="btnGuardar_Click"/>
</div>
</asp:Content>
