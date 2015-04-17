<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ext.Web.Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>  
   <title></title>
   
 <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<link rel="Stylesheet" href="css/MasterStyle.css" />
<link href="bootstrap-3.3.4-dist/css/bootstrap.min.css"  rel="Stylesheet" />
<link href="bootstrap-3.3.4-dist/css/bootstrap-theme.min.css" rel="Stylesheet" />
<script src="bootstrap-3.3.4-dist/js/bootstrap.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

    function ValidaInicioSesion(usr,pwd) {
        $(document).ready(function () {
            if (usr <= 0) {
                alert("Ingrese Usuario");
                return;
            }
            if (pw <= 0) {
                alert("Ingrese su Contraseña");
                return;
            }
        });
    }
</script>
</head>
<body >
    <form id="form1" runat="server" class="form-horizontal" role="form" >
    <div class="container" >
    <div >
    <div align="center" >
            <asp:Image ID="ImgPrincipal" runat="server" ImageUrl="~/Imagenes/SIETE MARIAS LOGO CURVAS.png"   />
            </div>
    </div>  
    
    </div> 
    <br />   
    <br />   
    <br />   
    <div align="center" class="container-fluid"> 
   <div class="form-group">
      <label class="control-label col-sm-5" for="email">Usuario:</label>
      <div class="col-sm-3">
        <asp:TextBox ID="txtUser" runat="server" CssClass="input-medium form-control"   placeholder="Usuario" ></asp:TextBox>
      </div>
    </div>
   <div class="form-group">
      <label class="control-label col-sm-5" for="pwd">Password:</label>
      <div class="col-sm-3">          
        <asp:TextBox ID="txtPwd" runat="server" CssClass="input-medium form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
      </div>
    </div>      
   
    <div>
    <asp:Button ID="btnLogin" runat="server" Text="Acceso"  onclick="btnLogin_Click"  CssClass="btn-default"  />
    </div>
                            
                  
       
    </div>   
   
   <br />
   <div id="footer">
      <div class="container">
      <div class="text-center">©Derechos Reservados 2015  Siete Marias Logistica</div>
      </div>
    </div>
    </form>
</body>
</html>
