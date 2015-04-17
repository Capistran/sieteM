<%@ Page Title="" Language="C#" MasterPageFile="~/MasterExterno.Master" AutoEventWireup="true" CodeBehind="ModificarPacientes.aspx.cs" Inherits="Ext.Web.Paginas.ModificarPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    $(document).ready(function () {
        $("#ContentPrincipal_ddEstado").change(function (event) {
            __doPostBack(this.name, $(this).val());
        });

        $("#<%= txtClavePaciente.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                __doPostBack(this.name, $("#<%= txtClavePaciente.ClientID %>").val());
            }
        });

        $("#MensajeNoEncontrado").hide();
        $("#Agregado").hide();


        $(".close").on('click', function () {
            $("#MensajeNoEncontrado").hide();
            $("#Agregado").hide();
    
        });

    });

    function Delegacion(valor) {
        $(document).ready(function () {
            if (valor == 9)
                $(".distrito").text('Delegación');
            else
                $(".distrito").text('Ciudad');
        });
    }

    function MsjPacienteEncontrado() {
        $.ready(function () {

        });
    }

    function MsjPacienteNoEncontrado(numpaciente) {
        $(document).ready(function () {
            $("#MensajeNoEncontrado").show();
            $(".msjpaciente").html('El paciente <strong>'+numpaciente+'</strong> no se encuentra registrado!');
        });
    }

    function OcultarGrid() {
        $.ready(function () {
            $("#gridcontainer").hide();
        });
    }

    function limpiarControles() {
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
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
<div class="container">
<div id="gridcontainer">
<asp:GridView ID="gvModificar" runat="server"  CssClass="table-hover" Visible="false"
        onrowediting="gvModificar_RowEditing"  AutoGenerateColumns="False"
         DataKeyNames="IdPaciente"
        onselectedindexchanged="gvModificar_SelectedIndexChanged" 
        onrowupdating="gvModificar_RowUpdating" 
        onrowcancelingedit="gvModificar_RowCancelingEdit" 
        onrowcommand="gvModificar_RowCommand" 
        onrowdeleting="gvModificar_RowDeleting" BorderStyle="None" 
        onselectedindexchanging="gvModificar_SelectedIndexChanging">
    <Columns>       
        <asp:CommandField ShowSelectButton="True" />
        
    <asp:TemplateField HeaderText="ID" Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%#Eval("IdPaciente") %>' ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Clave Paciente"  >
        <ItemTemplate>
        <asp:Label ID="lblClavePaciente" runat="server" Text='<%#Eval("CvePaciente") %>'></asp:Label>
            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtClavepaciente" runat="server" Text='<%#Eval("CvePaciente") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Nombre">
        <ItemTemplate>
        <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre") %>' ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtNombre" runat="server" Text='<%#Eval("Nombre") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
     
      <asp:TemplateField HeaderText="NSS">
        <ItemTemplate>
        <asp:Label ID="lblNSS" runat="server" Text='<%#Eval("NSS") %>' ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtNSS" runat="server" Text='<%#Eval("NSS") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="Estado" Visible="true">
        <ItemTemplate>
        <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("DesEstado") %>' ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:DropDownList ID="ddEstado" runat="server"></asp:DropDownList>            
        </EditItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="IdEstado" Visible="false">
        <ItemTemplate>
        <asp:Label ID="lblIdEstado" runat="server" Text='<%#Eval("IdEstado") %>' ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Label ID="lblIdEstadoEditable" runat="server" Text='<%#Eval("IdEstado") %>' ></asp:Label>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:CommandField ShowDeleteButton="true"  />
    </Columns>

    </asp:GridView>

    </div>   
    </div>
    <div id="infoPaciente">
    <asp:Panel ID="PanelPersonales" runat ="server">
        <div>
        <div id="MensajeNoEncontrado" class="alert alert-warning">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjpaciente"></span>
        </div>
        <div id="Agregado" class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert">&times;</a>
        <span class="msjpaciente"></span>
        </div>
<table>
    <tr><td></td> </tr>
    <tr><td><div>
    <table class="tab-content">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td><label>Clave del Paciente:</label></td>
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
               &nbsp; </td>
                
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
        <tr>
            <td class="style2">
                <label>NSS</label></td>
            <td>
               <%-- <input type="text" id="txtNSS" />--%>
                <asp:TextBox ID="txtNSS" runat="server"/>
                </td>
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
            <td class="style2">
                <label>Latitud:</label></td>
            <td>
                <%--<input type="text" id="txtLatitud" />--%>
                  <asp:TextBox ID="txtLatitud" runat="server" CssClass="decimales"/></td>
                  <td>
                &nbsp;</td>
            <td>
               <label>Longitud:</label></td>
            <td>
                <%--<input type="text" id="txtLongitud" />--%>
                <asp:TextBox ID="txtLongitud" runat="server"/>
                </td>
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
           
                
            <td><asp:Button  ID="btnActualizar" runat="server" Text="Guardar Cambios" UseSubmitBehavior="false"
                    onclick="btnActualizar_Click"/>
                </td>
        </tr>
    </table>



    </div></td> </tr>
    <tr><td></td> </tr>

</table>

    </div>
    </asp:Panel>
    </div>
</asp:Content>
