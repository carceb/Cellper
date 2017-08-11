<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReparacionEquipo.aspx.cs" Inherits="Cellper.ReparacionEquipo" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Asignar Estatus</title>
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
        $(function () {
            $('#txtNombre').simpleAutoComplete('Autocomplete.aspx', {
                autoCompleteClassName: 'autocomplete',
                selectedClassName: 'sel',
                attrCallBack: 'rel',
                identifier: 'Inventario'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnInventarioID").value = par[0];
            document.getElementById("txtCantidad").value = par[3];
            var number = par[4];
            document.getElementById("txtCosto").value = new Intl.NumberFormat("de-DE").format(number);
            document.getElementById("txtSerial").value = par[5];
        }

    </script>
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
									<a class="logo"><strong>Asignar Estatus Reparación</strong></a>
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
                                    <h4>Detalle de la revisión:</h4>
                                    <div class="row uniform">
                                        <div class="6u 12u$(xsmall)">
                                            <div class="select-wrapper">
                                            <asp:DropDownList ID="ddlEstatus" runat="server"  AppendDataBoundItems="True" OnSelectedIndexChanged="ddlEstatus_SelectedIndexChanged" AutoPostBack="True"  ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="6u 12u$(xsmall)">
                                            <div class="select-wrapper">
                                                <asp:DropDownList ID="ddlItemInventario" runat="server"  AppendDataBoundItems="True" Visible ="false" AutoPostBack="True"  OnSelectedIndexChanged="ddlItemInventario_SelectedIndexChanged" ></asp:DropDownList>
                                                <asp:TextBox runat="server" id ="txtObservaciones"  placeholder="Observaciones encontradas"   Visible="False" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="6u 12u$(xsmall)">
                                             <asp:TextBox runat="server" id ="txtCantidad"   placeholder="Cantidad" Visible="False" ></asp:TextBox>
                                        </div>
                                        <div class="6u 12u$(xsmall)">
                                             <asp:TextBox runat="server" id ="txtObservacionesReparacion"   placeholder="Observaciones reparación" Visible="False" ></asp:TextBox>
                                        </div>
                                        <div class="12u$">
                                            <ul class="actions">
                                                <li><asp:Button Text="Enviar a lista" runat="server" ID ="btnLista" Visible ="false" OnClick="btnLista_Click"  /></li>
                                                <li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" Visible ="false" OnClick="btnGuardar_Click"  /></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <hr />
                                    <h4><asp:Label runat="server" ID ="lblDetalle" Text ="Materiales utilizados" Visible ="false"></asp:Label></h4>
                                    <div class="row uniform">
                                        <div class="table-wrapper">
                                            <asp:GridView ID="gridDetalle" runat="server"  EmptyDataText="No existen Registros" 
                                                GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
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
                                                    <asp:TemplateField HeaderText="Nombre Material" HeaderStyle-Width="100">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblNombreEquipo" Text='<%# Eval("NombreItem") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad" HeaderStyle-Width="80">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCantidad" Text='<%# Eval("CantidadItem") %>' Font-Bold ="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Observacion" HeaderStyle-Width="150">
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


