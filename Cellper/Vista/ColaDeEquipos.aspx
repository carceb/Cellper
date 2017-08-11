<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColaDeEquipos.aspx.cs" Inherits="Cellper.ColaDeEquipos" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Cola de equipos Pendientes Pendientes Pendientes</title>
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
									<a class="logo"><strong>Cola de equipos Pendientes</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
                             <form runat ="server" id ="principal">
								<section>
                                        <p></p>
                                        <div class="row uniform">
										    <div class="12u$">
											    <ul class="actions">
                                                    <li><asp:Button Text="Actualizar lista" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click" /></li>
											    </ul>
										    </div>
                                            <div class="table-wrapper">
                                                 <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
                                                      GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand"  >
                                                        <HeaderStyle Font-Size="10px" />
                                                        <AlternatingRowStyle  Font-Size="10px" />
                                                          <RowStyle  Font-Size="10px" />
                                                      <Columns>
                                                          <asp:TemplateField HeaderText="Fecha Solicitud">
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblFechaRecepcion" Text='<%# Eval("FechaRecepcion") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="N° Caso">
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblCaso" Text='<%# Eval("RecepcionEquipoID") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Tipo equipo" >
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblTipo" Text='<%# Eval("NombreTipoEquipo")  %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Marca" >
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblMarca" Text='<%# Eval("NombreTipoCelular")  %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Modelo    ">
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblModelo"   Text='<%# Eval("NombreModeloCelular") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>

                                                          <asp:TemplateField HeaderText="IMEI" >
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblIMEI" Text='<%# Eval("IMEI") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Falla">
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblFalla" Text='<%# Eval("NombreFallaCelular") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Observaciones" >
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblObservaciones" Text='<%# Eval("Observaciones") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Tecnico">
                                                              <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lblTecnico" Text='<%# Eval("NombreTecnico") %>'></asp:Label>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Estatus" HeaderStyle-Width="200 ">
                                                              <ItemTemplate>
                                                                  <div class="select-wrapper">
                                                                      <asp:DropDownList runat="server" ID="ddlEstatus"
                                                                            DataSourceID="SqlDataSource4" 
                                                                            DataTextField ="NombreEstatusEquipo"
                                                                            DataValueField ="EstatusEquipoID"
                                                                            SelectedValue ='<%# Bind("EstatusEquipoID") %>'
                                                                            >
                                                                      </asp:DropDownList>
                                                                  </div>
                                                                <asp:SqlDataSource 
                                                                    ID="SqlDataSource4" 
                                                                    runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
                                                                    SelectCommand="SELECT *  FROM [EstatusEquipo] WHERE EstatusEquipoID = 1 OR EstatusEquipoID = 2 OR EstatusEquipoID = 7 ORDER BY EstatusEquipoID ">
                                                                </asp:SqlDataSource>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
                                                              <ItemTemplate>
                                                                  <asp:ImageButton runat="server" ID="btnEstatus" AlternateText="Asignar Estatus" ToolTip="Asignar Estatus" CssClass="cBotones" ImageUrl="~/Images/asignar_estatus_icono.png"  CommandName="AsignarEstatus" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>
                                                                  <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Solicitud" OnClientClick="return Confirmacion();" ToolTip="Eliminar Solicitud" CssClass="cBotones" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarSolicitud" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>
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
					<div id="sidebar">
						<div class="inner">

							<!-- Menu -->
								<nav id="menu">
									<header class="major">
										<h2>Menu</h2>
									</header>
									<ul>
										<li><a href="Principal.aspx">Inicio</a></li>
										<li>
											<span class="opener">Servicio Técnico</span>
											<ul>
												<li><a href="RecepcionEquipo.aspx">Recepción de equipos</a></li>
												<li><a href="ColaDeEquipos.aspx">Cola de equipos Pendientes</a></li>
											</ul>
										</li>

										<li>
											<span class="opener">Consultas</span>
											<ul>
												<li><a href="ColaReparacionEquipo.aspx">Cola de Equipos Revisados</a></li>
                                                <li><a href="EquiposEntregados.aspx">Equipos Entregados</a></li>
											</ul>
										</li>
										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
                                                <li><a href="Inventario.aspx">Inventario</a></li>
												<li><a href="MarcaEquipo.aspx">Marca equipo</a></li>
                                                <li><a href="ModeloEquipo.aspx">Modelo equipo</a></li>
                                                <li><a href="FallaEquipo.aspx">Fallas</a></li>
                                                <li><a href="Tecnico.aspx">Técnicos</a></li>
											</ul>
										</li>
                                        <li><a href="Logout.aspx">Salir</a></li>
									</ul>
								</nav>

							<!-- Section -->


							<!-- Section -->
                                &nbsp;<!-- Footer --><footer id="footer">
									<p class="copyright">&copy; Cellper. Todos los derechos reservados.</p>
								</footer>

						</div>
					</div>

			</div>
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>