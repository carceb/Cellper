<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacturarEquipo.aspx.cs" Inherits="Cellper.FacturarEquipo" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Facturar Equipo</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>
        <link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
        <script src="../assets/js/jquery.min.js"></script>
		<link rel="stylesheet" href="../assets/css/main.css" />
        <link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
	    <script src="../js/Util.js" type="text/javascript"></script>
<%--        <script src="../js/jquery.js"></script>--%>
        <script  src="../js/jquery-ui-1.8rc3.custom.min.js"></script>
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <script src="../assets/js/main.js"></script>            

<%--------------------------%>


    <script type="text/javascript">


        function Confirmacion() {

            return confirm("¿Realmente desea eliminar este registro?, no podrá deshacer");
        }

    </script>
	</head>
	<body>
        <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
		<!-- Wrapper -->
			<div id="wrapper">
				<!-- Main -->
					<div id="main">
						<div class="inner">
							<!-- Header -->
								<header id="header">
									<a class="logo"><strong>Facturar Equipo</strong></a>
								</header>
							<!-- Content -->
                            <form runat ="server" id ="principal">
								<section>
                                    <p></p>
                                    <h4>Datos del equipo:</h4>
                                        <div class="row uniform">
									        <div class="6u 12u$(xsmall)">
                                                <asp:Label runat="server" ID="lblFecha"></asp:Label> 
									        </div>
                                             <asp:HiddenField runat ="server" ID ="hdnCodigoTecnico"  Value="0"/>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblTipoEquipo"></asp:Label> 
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblMarca"></asp:Label> 
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblModelo"></asp:Label> 
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblImei"></asp:Label> 
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblFalla"></asp:Label> 
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblObservaciones"></asp:Label> 
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:Label runat="server" ID="lblCliente"></asp:Label> 
                                            </div>
                                    </div>
                                    <hr />
                                    <h4><asp:Label runat="server" ID ="lblDetalle" Text ="Materiales utilizados"></asp:Label></h4>
                                    <div class="row uniform">
                                        <div class="table-wrapper">
                                            <asp:GridView ID="gridDetalle" runat="server"  EmptyDataText="No existen Registros" 
                                                GridLines="Horizontal" AutoGenerateColumns="False"   >
                                                <HeaderStyle  Font-Size="10px" />
                                                <AlternatingRowStyle  Font-Size="10px" />
                                                    <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="CodV" HeaderStyle-Width="0" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtReparacionEquipoID" Visible ="false"   Width="0" ForeColor ="Red" Text='<%# Eval("ReparacionEquipoID") %>' ></asp:TextBox>
                                                        </ItemTemplate>
				                                <HeaderStyle Width="0px"></HeaderStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombre Material" HeaderStyle-Width="200">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblNombreEquipo" Text='<%# Eval("NombreItem") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad" HeaderStyle-Width="80">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCantidad" Text='<%# Eval("CantidadItem") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Costo P/U" HeaderStyle-Width="150">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCostoItem" Text='<%# Eval("CostoItem") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Costo Item" HeaderStyle-Width="150">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCostoItem" Text='<%# Eval("TotalCosto") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observacion" HeaderStyle-Width="300">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblObservacion" Text='<%# Eval("ObservacionReparacionEquipo") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("ReparacionEquipoID") %>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </section>
                           </form>
						</div>
					</div>
				<!-- Sidebar -->
<%--					<div id="sidebar">
						<div class="inner">--%>
							<!-- Menu -->
                                <uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
<%--						</div>
					</div>--%>
			</div>
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>


