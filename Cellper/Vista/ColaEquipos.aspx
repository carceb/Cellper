<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColaEquipos.aspx.cs" Inherits="Cellper.ColaEquipos" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="~/Vista/UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Cellper | Cola de equipos|</title>
	
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
              <tr class="auto-style2" >
                  <td  width="1000" >
                      <asp:Button Text="Actualizar lista" runat="server" ID ="btnGuardaLista"  CssClass ="boton_formulario"  CausesValidation="False" OnClick="btnGuardaLista_Click"/>
                  </td>
              </tr>
          </table>
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Fecha Solicitud" HeaderStyle-Width="60">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaRecepcion" Text='<%# Eval("FechaRecepcion") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="N° Caso" HeaderStyle-Width="40">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblCaso" Text='<%# Eval("RecepcionEquipoID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Cliente" HeaderStyle-Width="130 ">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblSolicitante"  Text= '<%# Eval("NombreCliente") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Tipo equipo" HeaderStyle-Width="150px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblTipo" Text='<%# Eval("NombreTipoEquipo")  %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Marca" HeaderStyle-Width="100">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblMarca" Text='<%# Eval("NombreTipoCelular")  %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Modelo" HeaderStyle-Width="50">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblModelo"   Text='<%# Eval("NombreModeloCelular") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="IMEI" HeaderStyle-Width="60">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblIMEI" Text='<%# Eval("IMEI") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Falla" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFalla" Text='<%# Eval("NombreFallaCelular") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Observaciones" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblObservaciones" Text='<%# Eval("Observaciones") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tecnico" HeaderStyle-Width="60">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblTecnico" Text='<%# Eval("NombreTecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                 <asp:TemplateField HeaderText="Estatus" HeaderStyle-Width="100">
                      <ItemTemplate>
                          <asp:DropDownList runat="server" ID="ddlEstatus"
                                DataSourceID="SqlDataSource4" 
                                DataTextField ="NombreEstatusEquipo"
                                DataValueField ="EstatusEquipoID"
                                SelectedValue ='<%# Bind("EstatusEquipoID") %>'
                                Width="100px">
                          </asp:DropDownList>
                        <asp:SqlDataSource 
                            ID="SqlDataSource4" 
                            runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
                            SelectCommand="SELECT *  FROM [EstatusEquipo] WHERE EstatusEquipoID <> 4 AND EstatusEquipoID <> 5 ORDER BY EstatusEquipoID ">
                        </asp:SqlDataSource>
                      </ItemTemplate>
                  </asp:TemplateField>


                   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="60">
                      <ItemTemplate>
                          <asp:ImageButton runat="server" ID="btnEstatus" AlternateText="Asignar Estatus" ToolTip="Asignar Estatus" CssClass="cBotones" ImageUrl="~/Images/asignar_estatus_icono.png"  CommandName="AsignarEstatus" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>
                          <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Solicitud" OnClientClick="return Confirmacion();" ToolTip="Eliminar Solicitud" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarSolicitud" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>

      </td>

    </tr>
    <tr>
      <td width="200" height="30" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="10" bgcolor="#d2d2c6">&nbsp;</td>
      <td bgcolor="#d2d2c6" align="center" style="font-size: medium" class="auto-style5" >Seguimiento y control de equipos [Cellper] Usuario: <%:Session["NombreCompletoUsuario"]%>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>


