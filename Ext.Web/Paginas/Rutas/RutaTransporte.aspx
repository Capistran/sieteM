<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="RutaTransporte.aspx.cs" Inherits="Ext.Web.Paginas.Rutas.RutaTransporte" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {           
            //<!--/^-?[0-9]+([,\.][0-9]*)?$/-->
          
           $("#divwarning").hide();
           $("#divdanger").hide();
           $("#divsuccess").hide();


        $(".close").on('click', function () {
           $("#divwarning").hide();
           $("#divdanger").hide();
           $("#divsuccess").hide();          
    
        });

            $("#<%= ddTransporte.ClientID %>").change(function (event) {
                __doPostBack(this.name, $(this).val());
            });
        });

        function LimpiarControles() {
            $(document).ready(function () {
                $("#<%= txtClaveRuta.ClientID%>").val("");
                $("#<%= txtFechaEmbarque.ClientID%>").val("");
                        });
        }


        
        
        function MsjRutaGenerada() {
            $(document).ready(function () {
                $("#divsuccess").show();
                $(".msjalert").html('');
                $(".msjalert").html('La Ruta se ha generado Exitosamente');
            });
             }

          function MsjRutaExistente(ruta) {
              $(document).ready(function () {
                  $("#divwarning").show();
                  $(".msjalert").html('');
                  $(".msjalert").html('La Ruta <strong>' + ruta + '</strong> ya existe');
              });
              }


          function MsjError(error) {
              $(document).ready(function () {
                  $("#divdanger").show();
                  $(".msjalert").html('');
                  $(".msjalert").html('<strong>' + error + '</strong>');
              });
                                }

        function __doPostBack(eventTarget, eventArgument) {
            document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
            document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
            document.forms.form1.submit();
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
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Clave de Ruta:</label></td>
            <td>
               <asp:TextBox ID="txtClaveRuta" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Linea de Transporte:</label></td>
            <td>
                <asp:DropDownList ID="ddTransporte" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>CEDIS:</label></td>
            <td>
                <asp:DropDownList ID="ddCedis" runat="server"></asp:DropDownList></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Mes:</label></td>
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
        </tr>
         <tr>
            <td>
                &nbsp;</td>
            <td>
                <label>Fecha Embarque:</label></td>
            <td>
               <cc1:CalendarExtender ID="calendar1" runat="server" TargetControlID="txtFechaEmbarque" Format="dd/MM/yyyy"/><asp:TextBox ID="txtFechaEmbarque" runat="server"></asp:TextBox></td>
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
                <asp:Button  ID="btnGenerarRuta" runat="server" Text="Generar" UseSubmitBehavior="false"
                    onclick="btnGenerarRuta_Click"/></td>
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
        </tr>
    </table>
    <div></div>
    <table>
        <tr>
<td>
               </td>
                <td>
                &nbsp;</td>
            <td>
               </td>
           
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            
        </tr>
    </table>
</div>
</asp:Content>
