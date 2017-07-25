<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecepcionEquipo.aspx.cs" Inherits="Cellper.RecepcionEquipo" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Recepción de Equipos</title>
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
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
					<div id="main">
						<div class="inner">

							<!-- Header -->
								<header id="header">
									<a class="logo"><strong>Recepción de Equipos</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
								<section>
                                    <form runat ="server" id ="principal">
                                        <div class="row uniform">
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtCedula"   onkeypress="return event.keyCode!=13;" MaxLength="12" placeholder="Cedula" />
                                                <ASP:RequiredFieldValidator id="rqrvalidaCedula" runat="server" errormessage="Debe colocar la cedula" controltovalidate="txtCedula" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                <asp:HiddenField runat ="server" ID ="hdnCedula"  Value="0"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnClienteID"  Value="0"/> 
									        </div>
									        <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtNombre"  MaxLength="80"  placeholder="Nombre Cliente" />
                                                <ASP:RequiredFieldValidator id="rqrvalidaNombreVisitante" runat="server" errormessage="Debe colocar el nombre"  controltovalidate="txtNombre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
									        </div>
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtTelefono"  MaxLength="100" placeholder ="Teléfono"/>
									        </div>
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtDireccion"  MaxLength="100" placeholder ="Dirección"/>
									        </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    
                                                    <asp:DropDownList ID="ddlTipoEquipo" runat="server"   AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoEquipo_SelectedIndexChanged" >
                                                        
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlTipoCelular" runat="server"  AutoPostBack = "true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlTipoCelular_SelectedIndexChanged" ></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlModeloCelular" runat="server" AppendDataBoundItems="True"  ></asp:DropDownList>
                                                </div>
                                                <asp:HiddenField runat ="server" ID ="hdnCodigoModelo"  Value="0"/>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtIMEI" MaxLength="15" placeholder ="IMEI"/>
                                                <ASP:RequiredFieldValidator id="rqrvalidaIMEI" runat="server" errormessage="Debe colocar IMEI/Serial"  controltovalidate="txtIMEI" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                     <asp:DropDownList ID="ddlFalla" runat="server"  AppendDataBoundItems="True" ></asp:DropDownList> 
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="1" MaxLength="300"  placeholder="Observaciones"/> 
                                                <ASP:RequiredFieldValidator id="rqrvalidaObservaciones" runat="server" errormessage="Debe colocar las observaciones"  controltovalidate="txtObservaciones" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlTecnico" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
                                                </div>
                                            </div>
										    <div class="12u$">
											    <ul class="actions">
                                                    <li><asp:Button Text="Enviar a servicio" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click" /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnLimpiar"   CausesValidation="False" OnClick="btnLimpiar_Click"  /></li>
                                                    <li><asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none"  CausesValidation="False" OnClick="ButtonTest_Click" /></li>
											    </ul>
										    </div>
                                            <div class="table-wrapper">
                                                  <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
                                                      GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand"  >
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
                                                           <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
                                                              <ItemTemplate>
                                                                  <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>
                                                              </ItemTemplate>
                                                          </asp:TemplateField>
                                                      </Columns>
                                                  </asp:GridView>
                                            </div>
                                        </div>
                                    </form>
								</section>

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
												<li><a href="ColaDeEquipos.aspx">Cola de equipos</a></li>
											</ul>
										</li>

										<li>
											<span class="opener">Consultas</span>
											<ul>
												<li><a href="#">Clientes atendidos</a></li>
											</ul>
										</li>
										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
                                                <li><a href="Inventario">Inventario</a></li>
												<li><a href="MarcaEquipo.aspx">Marca equipo</a></li>
                                                <li><a href="ModeloEquipo">Modelo equipo</a></li>
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