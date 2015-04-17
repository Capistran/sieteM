<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Ext.Web.Paginas.Pedidos.Pedidos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="Stylesheet" href="../../Bootstrap/css/bootstrap.min.css" />

     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" src="../../Bootstrap/js/bootstrap.min.js" ></script>    
    <script type="text/javascript">

        $(document).ready(function () {


            $("#ContentPrincipal_ddRutas").change(function (event) {
                __doPostBack(this.name, $("#ContentPrincipal_ddRutas").val());
            });


            $("#<%= txtCvePaciente.ClientID %>").keyup(function (e) {
                if (e.keyCode == 13) {                   
                    __doPostBack(this.name, $("#<%= txtCvePaciente.ClientID %>").val());
                }
            });
            //<!--/^-?[0-9]+([,\.][0-9]*)?$/-->
            $("#divwarning").hide();
            $("#divdanger").hide();
            $("#divsuccess").hide();


            $(".close").on('click', function () {
                $("#divwarning").hide();
                $("#divdanger").hide();
                $("#divsuccess").hide();

            });

        });

        function Oculta() {
            $(document).ready(function () {
                $(".detallePaciente").hide();
                //$(".infoProductos").hide();
            });
        }

        function Mostrar() {
            $(document).ready(function () {
                $(".detallePaciente").show();
                $(".infoProductos").show();
                $(".infoPaciente").hide();
            });
        }

        function __doPostBack(eventTarget, eventArgument) {
            document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
            document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
            document.forms.form1.submit();
        }


        function AgregaPedido() {
            $(document).ready(function () {
                $("#divsuccess").show();
                $(".msjalert").html('');
                $(".msjalert").html('CEDIS Agregado Exitosamente');
            });
        }

        function MjsExiste(msj) {
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
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<asp:ScriptManager ID="sman" runat="server"></asp:ScriptManager>
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
    <div class="container-fluid">
        <div class="row detallePaciente">                  
                   <%-- <div class="col-md-2">
                        <label>Clave</label>                   
                    </div>
                    <div class="col-md-3">
                    <asp:Label ID="lblClave" runat="server"/>                  
                </div>
                    <div class="col-md-4">
                    <label>Nombre:</label><asp:Label ID="lblNombrePaciente" runat="server"></asp:Label>
                </div>  
                </div >--%>
             <table>
             <tr>
             <td><label>Número Paciente:</label></td>
             <td colspan="2"><asp:Label ID="lblClave" runat="server" CssClass="text-left"/> </td>
             </tr>
             <tr>
             <td><label>Nombre Paciente:</label></td>
             <td colspan="2"><asp:Label ID="lblNombrePaciente" runat="server" CssClass="text-left"/></td>
             </tr>
             </table>       
               
                
         </div>   
        <div>
        <div class="row infoPaciente">
        <asp:GridView ID="gvPacientes" Visible="false" runat="server" AutoGenerateColumns="false"  DataKeyNames="IdPaciente" CssClass="table table-striped table-bordered table-condensed"
                AllowPaging="True" onpageindexchanging="gvPacientes_PageIndexChanging" 
                PageSize="5" onselectedindexchanging="gvPacientes_SelectedIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:TemplateField HeaderText="ID" Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%#Eval("IdPaciente") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
            </Columns>
            <PagerSettings FirstPageText="Primero" LastPageText="Último" 
                Mode="NumericFirstLast" PageButtonCount="5" />
            </asp:GridView>
        </div>
        <div class="row infoProductos">
        <asp:GridView ID="gvProductos" Visible="false" runat="server" DataKeyNames="IdProducto" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="false"
                onrowcommand="gvProductos_RowCommand"                 
                onselectedindexchanging="gvProductos_SelectedIndexChanging" >
                <Columns>
                <asp:TemplateField HeaderStyle-Width="25px" >
                <ItemTemplate>
                    <asp:ImageButton id="imgagregar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Agregar" ImageUrl="~/Imagenes/add.ico" runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
        </div>
        <br />
        <br />
        <br />
        <div class="container">
             <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Número Paciente:</label></td>
            <td>
                <asp:TextBox id="txtCvePaciente" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
               
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Asigna Ruta:</label></td>
            <td>
                <asp:DropDownList ID="ddRutas" runat="server"></asp:DropDownList></td>
            <td>&nbsp;</td>
        </tr>
       <%-- <tr>
        <td></td>
        <td><label>Mes:</label></td>
        <td><asp:DropDownList ID="ddMes" runat="server">
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
        </tr>--%>
        <tr>
        <td>&nbsp;</td>
        <td><label>Fecha Entrega:</label></td>
        <td><cc1:CalendarExtender  ID="cld1" runat="server" TargetControlID="txtFechaEntrega"  Format="dd/MM/yyyy"/><asp:TextBox id="txtFechaEntrega" runat="server"></asp:TextBox></td>
        <td>&nbsp;</td>
        </tr>
        

    </table>
        </div>
    <div>
        <asp:GridView ID="gvDetallePedido" runat="server" AutoGenerateColumns="false" DataKeyNames="IdProducto" CssClass="table table-striped table-bordered table-condensed">
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
        <asp:Button  ID="btnGenerarPedido" runat="server" Text="Generar Pedido"  UseSubmitBehavior="false"
                CssClass="btn-navbar" onclick="btnGenerarPedido_Click"/>
        </div>
    </div>
    </div>
   
</div>
</asp:Content>
