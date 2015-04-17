<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="DetalleRuta.aspx.cs" Inherits="Ext.Web.Paginas.Rutas.DetalleRuta" %>
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


            $("#<%= txtCveRuta.ClientID %>").keyup(function (e) {
                if (e.keyCode == 13) {
                    __doPostBack(this.name, $("#<%= txtCveRuta.ClientID %>").val());
                }
            });
          
        });

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
                $(".msjalert").html(' <strong>' + ruta + '</strong> ');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
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
    <div class="row">
        <div class="col-sm-4"></div>
        <div class="col-sm-2"><label>Clave Ruta:</label></div>
        <div class="col-sm-3"><asp:TextBox ID="txtCveRuta" runat="server"></asp:TextBox></div>
        <div class="col-sm-4"></div>
    </div>
    <div class="row">
        <div class="col-sm-4"></div>
        <div class="col-sm-2"><label>Mes:</label></div>
        <div class="col-sm-3"><asp:DropDownList ID="ddMes" runat="server">
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
                </asp:DropDownList></div>
        <div class="col-sm-4"></div>
    </div>

</div>
<div>
    <asp:GridView ID="gvDetalleRuta" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-condensed"> </asp:GridView>
</div>
</asp:Content>
