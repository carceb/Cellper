<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recepcion.aspx.cs" Inherits="Cellper.Recepcion" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="~/Vista/UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Cellper | Recepción de equipos|</title>
	
	<link rel="stylesheet" href="../Styles/estilo.css" type="text/css"/>
    <link rel="stylesheet" href="../Styles/estilos.css" type="text/css"/>
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
	BACKGROUND-IMAGE: url(../Images/fondo_3.png); BACKGROUND-COLOR: #ffffff
}
        .auto-style2 {
            height: 21px;
        }
        .auto-style3 {
            height: 43px;
        }
                                                                              .auto-style5 {
                                                                                  width: 770px;
                                                                              }
                                                                              .auto-style6 {
                                                                                  height: 160px;
                                                                              }
                                                                              </style>
    <script>

        $(function () {
            $('#txtCedula').simpleAutoComplete('Autocomplete.aspx', {
                autoCompleteClassName: 'autocomplete',
                selectedClassName: 'sel',
                attrCallBack: 'rel',
                identifier: 'Clientes'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnCedula").value = par[0]; 
            document.getElementById("txtCedula").value = par[0]; 
            document.getElementById("txtNombre").value = par[1];
            document.getElementById("txtTelefono").value = par[3];
            document.getElementById("txtDireccion").value = par[4]; 
            document.getElementById("hdnClienteID").value = par[6];

            var bt = document.getElementById("ButtonTest");
            bt.click();
        }

        function Confirmacion() {

            return confirm("¿Realmente desea eliminar este registro?, no podrá deshacer");
        }
        function LimpiarTextos() {
            document.getElementById("hdnCedula").value = "0";
            document.getElementById("txtCedula").value = "";
            document.getElementById("txtNombre").value = "";
            document.getElementById("txtTelefono").value = "";
        }

    </script>
        
 <script type="text/javascript">
        $(function () {
        $('#txtCedula').keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey) {
        e.preventDefault();
        } else {
        var key = e.keyCode;
        if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
        e.preventDefault();
        }
        }
        });
    });
</script>
 <script type="text/javascript">
        $(function () {
        $('#txtTelefono').keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey) {
        e.preventDefault();
        } else {
        var key = e.keyCode;
        if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
        e.preventDefault();
        }
        }
        });
    });
</script>
</head>
  
  <body>
 <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
  <form id="form1" runat="server">
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
    <tr>
      <td colspan="4" class="auto-style6"><img src="../Images/top_helper_3.png" width="1000" height="160"></td>
    </tr>
    <tr>
      <td width="200" rowspan="2" align="left" valign="top" bgcolor="#24496f">
        <uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation>
      </td>
	  <td colspan="2" valign="top" class="auto-style2"  >&nbsp; <h2> Recepción de Equipos</h2></td>
        
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
                        <asp:TextBox runat="server" ID="txtCedula"   onkeypress="return event.keyCode!=13;" MaxLength="12" Width="200"/>
                        <asp:HiddenField runat ="server" ID ="hdnCedula"  Value="0"/> 
                        <asp:HiddenField runat ="server" ID ="hdnClienteID"  Value="0"/> 
                        <ASP:RequiredFieldValidator id="rqrvalidaCedula" runat="server" errormessage="Debe colocar la cedula" width="132px" controltovalidate="txtCedula" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Nombre" ID="Nombre" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtNombre"  MaxLength="50" Width="520"/>
                        <ASP:RequiredFieldValidator id="rqrvalidaNombreVisitante" runat="server" errormessage="Debe colocar el nombre" width="132px" controltovalidate="txtNombre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Teléfono" ID="Label2" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtTelefono"  MaxLength="100" Width="520"  />
                        <ASP:RequiredFieldValidator id="rqrvalidaTelefono" runat="server" errormessage="Debe colocar el telefono" width="132px" controltovalidate="txtTelefono" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Dirección" ID="Label5" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtDireccion"  MaxLength="100" Width="520"  />
                        <ASP:RequiredFieldValidator id="rqrvalidaDireccion" runat="server" errormessage="Debe colocar la dirección" width="132px" controltovalidate="txtDireccion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Tipo equipo" ID="Label6" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlTipoEquipo" runat="server"  Width="520" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoEquipo_SelectedIndexChanged"   >
                        </asp:DropDownList> 
                    </td>
                </tr>
                    <td class="auto-style2">
                        <asp:Label Text="Marca equipo" ID="Label7" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlTipoCelular" runat="server"  Width="520" AutoPostBack = "true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlTipoCelular_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Modelo" ID="Label3" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlModeloCelular" runat="server"  Width="520" AppendDataBoundItems="True"  >
                        </asp:DropDownList>
                        <asp:HiddenField runat ="server" ID ="hdnCodigoModelo"  Value="0"/>      
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        IMEI/Serial</td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtIMEI" MaxLength="15" Width="520px"/> 
                        <ASP:RequiredFieldValidator id="rqrvalidaIMEI" runat="server" errormessage="Debe colocar IMEI/Serial" width="132px" controltovalidate="txtIMEI" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Falla" ID="Label4" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlFalla" runat="server"  Width="520"   >
                        </asp:DropDownList> 
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Observaciones</td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="2" MaxLength="200" Width="520px"/> 
                        <ASP:RequiredFieldValidator id="rqrvalidaObservaciones" runat="server" errormessage="Debe colocar las observaciones" width="132px" controltovalidate="txtObservaciones" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Técnico</td>
                    <td class="auto-style2">
                          <asp:DropDownList ID="ddlTecnico" runat="server"  Width="520px">
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                      <td></td>
                      <td class="auto-style3" align ="center" >
                          <asp:Button Text="Enviar a servicio" runat="server" ID ="btnGuardar"  CssClass ="boton_formulario" OnClick="btnGuardar_Click" />
                          <asp:Button Text="Nuevo registro" runat="server" ID ="btnLimpiar"  CssClass ="boton_formulario" OnClick="btnLimpiar_Click" CausesValidation="False"  />
                          <asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none" CssClass ="boton_formulario" OnClick="ButtonTest_Click" CausesValidation="False" />
<%--                          <asp:Button Text="TEST2" runat="server" ID ="ButtonTest2"   style="display:none" CssClass ="boton_formulario" CausesValidation="False" OnClick="ButtonTest2_Click" />--%>
                      </td>
                  </tr>
                    
          </table>

          <h2>Detalle</h2>
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="CodV" HeaderStyle-Width="0" Visible="false">
                      <ItemTemplate>
                          <asp:TextBox runat="server" ID="txtCodVisita" Visible ="false"   Width="0" ForeColor ="Red" Text='<%# Eval("RecepcionEquipoID") %>' ></asp:TextBox>
                      </ItemTemplate>
				<HeaderStyle Width="0px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Fecha Recepción" HeaderStyle-Width="100    ">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaRecepcion" Text='<%# Eval("FechaRecepcion") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Cédula" HeaderStyle-Width="80">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblCedulaVisitante" Text='<%# Eval("CedulaCliente") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="150">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblNombreVisitante" Text='<%# Eval("NombreCliente") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tipo equipo" HeaderStyle-Width="100">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblAsunto" Text='<%# Eval("NombreTipoEquipo") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Marca" HeaderStyle-Width="150">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblObservacion" Text='<%# Eval("NombreTipoCelular") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Modelo " HeaderStyle-Width="200">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblVisitado" Text='<%# Eval("NombreModeloCelular") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="IMEI/Serial" HeaderStyle-Width="200">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblIMEI" Text='<%# Eval("IMEI") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Falla" HeaderStyle-Width="200">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFalla" Text='<%# Eval("NombreFallaCelular") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>



      </td>

    </tr>
    <tr>
      <td width="200" height="30" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="10" bgcolor="#d2d2c6">&nbsp;</td>
      <td bgcolor="#d2d2c6" align="center" style="font-size: medium" class="auto-style5" >Sistema Atención al Visitante Usuario: al Visitante Usuario: <%:Session["NombreCompletoUsuario"]%>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>

