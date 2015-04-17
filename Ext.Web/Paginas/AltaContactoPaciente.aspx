<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="AltaContactoPaciente.aspx.cs" Inherits="Ext.Web.Paginas.AltaContactoPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    $(document).ready(function () {
        $(".FormatoB").hide();
        $(".FormatoA").show();

        $(".paciente").hide();
        $("#divwarning").hide();
        $("#divdanger").hide();
        $("#divsuccess").hide();

        $(".close").on('click', function () {
            $("#divwarning").hide();
            $("#divdanger").hide();
            $("#divsuccess").hide();

        });

        $("#<%= ddFormatoDir.ClientID %>").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });
        $("#ContentPrincipal_ddEstados").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });

        $("#<%= txtClavePaciente.ClientID %>").keyup(function (e) {
            if ($(this).val() != '') {
                if (e.keyCode == 13) {
                    __doPostBack(this.name, $("#<%= txtClavePaciente.ClientID %>").val());
                }
            } else {
                MsjOtro('INGRESA LA CLAVE DE PACIENTE');
            }
        });

    });
    function FormatoDireccion(formato) {
        $(document).ready(function () {

            if (formato == '1') {
                $(".FormatoB").hide();
                $(".FormatoA").show();
            }
            else {
                $(".FormatoA").hide();
                $(".FormatoB").show();
            }
        });
    }

    function MostrarNombrePaciente(nombre) {
    $(document).ready(function () {
        $(".paciente").show();
        $(".nombrePaciente").text(nombre);
    });
    }

    function Delegacion(valor) {
        $(document).ready(function () {
            if (valor == 9)
                $(".distrito").text('Delegación');
            else
                $(".distrito").text('Ciudad');
        });
    }
    function LimpiarControles() {
        $(document).ready(function () {
            $('input[type=text]').each(function () {
                $(this).val('');
            });
        });
    }
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
<div class="container" align="center">
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
    <div class="paciente"><label>Nombre Paciente:</label><span class="nombrePaciente"></span></div>
    <table class="tab-content">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td><label>Número Paciente:</label></td>
            <td><asp:TextBox ID="txtClavePaciente" runat="server"></asp:TextBox></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="style2">
                <label>Nombre(s):</label></td>
              
            <td>
               <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
                
        </tr>
        <tr>
            <td class="style2">
                <label>Apellido Paterno: </label></td>
            <td>
                <%--<input type="text" id="txtApePat" />--%>
                <asp:TextBox ID="txtApePat" runat="server"/></td>
                  <td>
                &nbsp;</td>
            <td>
               <label>Apellido Materno: </label></td>
            <td>
              <%-- <input type="text" id="txtApeMat" />--%>
               <asp:TextBox ID="txtApeMat" runat="server"/></td>
            <td>
                &nbsp;</td>
        </tr>
     
      
        <%--<tr>
            <td>
            <label>Dias Visita:</label>
               </td>
            <td>
               <asp:DropDownList ID="dd_diasvisita" runat="server"></asp:DropDownList></td>
            <td>
                &nbsp;</td>
            <td>
                <label>Frecuencia Visita: </label></td>
            <td>
               <asp:DropDownList ID="ddFrecuenciaVisita" runat="server">
                   <asp:ListItem Value="0">SELECCIONA FRECUENCIA</asp:ListItem>
                   <asp:ListItem Value="1">SEMANAL</asp:ListItem>
                   <asp:ListItem Value="2">QUINCENAL</asp:ListItem>
                   <asp:ListItem Value="3">MENSUAL</asp:ListItem>
                </asp:DropDownList></td>
        </tr>--%>
        <tr>
            <td >
                <label>Entidad Federativa:</label></td>
            <td>
               <asp:DropDownList ID="ddEstados" runat ="server" ></asp:DropDownList></td>
            <td>
                &nbsp;</td>
            <td>
                <label class="distrito">Ciudad:</label></td>
            <td>
                <asp:DropDownList ID="ddCiudad" runat="server"></asp:DropDownList></td>
        </tr>
           <tr>
            <td >
                <label>Formato Direccion:</label></td>
            <td>
                <%--<input  type="text" id="txtColonia"/>--%>
                <asp:DropDownList ID="ddFormatoDir" runat ="server">
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
        
        <tr>
            <td >    &nbsp;
            </td>
            <td>
                &nbsp;</td>
                  <td>
                &nbsp;</td>
            <td>
               </td>
            <td>
                <asp:Button ID="btnNuevoContacto" runat="server" Text="Agrega Contacto" 
                    onclick="btnNuevoContacto_Click" /></td>
            <td>
                </td>
        </tr>
    </table>
    </div>

</div>
</asp:Content>
