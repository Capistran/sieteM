<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ext.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script  type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="js/fnMapa.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {


            $(".Paciente").on('click', function () {
               
            });
            function infoPaciente() {

                alert($(".Paciente").text());
            }


            $("#ContentPrincipal_ddRutas").change(function (event) {
                __doPostBack(this.name, $("#ContentPrincipal_ddRutas").val());
            });
        });

    function __doPostBack(eventTarget, eventArgument) {
        document.forms.form1.ctl00$ContentPrincipal$__EVENTTARGET.value = eventTarget;
        document.forms.form1.ctl00$ContentPrincipal$__EVENTARGUMENT.value = eventArgument;
        document.forms.form1.submit();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <div class ="container">   
     <div align="center" >
    <table>
    <tr>
    <td>
     <table >
                <tr>
                    <td class="danger"><label  >Ruta:</label></td>
                    <td><asp:DropDownList ID="ddRutas" runat="server" onselectedindexchanged="ddRutas_SelectedIndexChanged"></asp:DropDownList></td>
                    
                </tr>
              
                <tr>
                    <td>
                       <label> Operador: </label></td>
                       <td><asp:Label ID="lblChofer" runat="server"></asp:Label>
                    </td>
                    <tr>
                    <td>
                    <label>Unidad:</label></td>
                    <td><asp:Label ID="lblTransporte" runat="server"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td><label>Auxiliar:</label></td>
                    <td><asp:Label ID="lblAuxiliar" runat="server"></asp:Label></td>
                    </tr>
                </tr>
            </table>
    </td>
    </tr>
    </table>
    </div>
     <div align="center">
    <div id="mapa" style="width:800px; height:600px;"></div>
    </div>
    </div>

   
    <input type="hidden" id="hdprueba" value="" />
    <asp:HiddenField  ID="hdruta" runat="server"/>
    <asp:HiddenField ID="__EVENTTARGET" Value="" runat="server" />
    <asp:HiddenField ID="__EVENTARGUMENT" Value="" runat="server" />
</asp:Content>
