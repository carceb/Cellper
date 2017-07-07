<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Cellper.Tecnicos" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="~/Vista/UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Cellper | Tecnicos|</title>
	
	<link rel="stylesheet" href="../Styles/estilo.css" type="text/css"/>
	<script src="../js/Util.js" type="text/javascript"></script>
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-ui-1.8rc3.custom.min.js"></script>
    <link href="../Styles/simpleAutoComplete.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui-1.8rc3.custom.css" rel="stylesheet" />


  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"><style type="text/css">BODY {
	FONT-SIZE: 8.5pt
}
TD {
	FONT-SIZE: 8.5pt
}
TH {
	FONT-SIZE: 8.5pt
}
BODY {
	BACKGROUND-IMAGE: url(../Images/fondo_3.jpg); BACKGROUND-COLOR: #ffffff
}
        .auto-style2 {
            height: 21px;
        }
        .auto-style3 {
            height: 43px;
        }
    </style>
    <script>

        $(function () {
            $('#txtNombre').simpleAutoComplete('Autocomplete.aspx', {
                autoCompleteClassName: 'autocomplete',
                selectedClassName: 'sel',
                attrCallBack: 'rel',
                identifier: 'Tecnicos'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnTecnicoID").value = par[0];
            document.getElementById("txtNombre").value = par[1];
            document.getElementById("txtCedula").value = par[3];
        }

    </script>

</head>
  
  <body>
 <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
  <form id="form1" runat="server">
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
    <tr>
      <td colspan="4"><img src="../Images/top_seguridad_1.jpg" width="1000" height="160"></td>
    </tr>
    <tr>
      <td width="200" rowspan="2" align="left" valign="top" bgcolor="#24496f"><uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation></td>
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Agregar/Modificar Tecnico</h2></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Cedula" ID="Label1" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtCedula" MaxLength="100" onkeypress="return event.keyCode!=13;" Width ="520"/> 
                        <ASP:RequiredFieldValidator id="rqrValidaCedula" runat="server" errormessage="Debe colocar la cedula del t�cnico" width="132px" controltovalidate="txtCedula" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Nombre" ID="Label6" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtNombre" MaxLength="100" onkeypress="return event.keyCode!=13;" Width ="520"/> 
                        <asp:HiddenField runat ="server" ID ="hdnTecnicoID"  Value="0"/>
                        <ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre del t�cnico" width="132px" controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
               <tr>
                    <td class="auto-style3">
                        <asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="boton_formulario" OnClick="btnGuardar_Click"  />
                    </td>
                    <td class="auto-style3">
                         <asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo"  CssClass ="boton_formulario" OnClick="btnNuevo_Click"  />
                    </td>
                </tr>
          </table>
      </td>

    </tr>
    <tr>
      <td width="200" height="30" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="10" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="770" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>
