<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Cellper.Inventario" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Actualizar Inventario</title>
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
									<a class="logo"><strong>Actualizar Inventario</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
                                <section>
                                        <p></p>
                                        <div class="row uniform">
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtNombre" MaxLength="150" onkeypress="return event.keyCode!=13;" placeholder ="Nombre del producto"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnInventarioID"  Value="0"/>
                                                <ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre del producto"  controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
									        </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtCantidad" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Cantidad"/> 
                                                <ASP:RequiredFieldValidator id="rqrValidaCantidad" runat="server" errormessage="Debe colocar la cantidad"  controltovalidate="txtCantidad" display="Dynamic"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtCosto" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Costo"/> 
                                                <ASP:RequiredFieldValidator id="rqrValidaCosto" runat="server" errormessage="Debe colocar el costo"  controltovalidate="txtCosto" display="Dynamic"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtSerial" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Serial"/> 
                                            </div>
										    <div class="12u$">
											    <ul class="actions">
                                                    <li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"  /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo" CausesValidation="False" OnClick="btnNuevo_Click"  /></li>
											    </ul>
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
												<li><a href="ColaDeEquipos.aspx">Cola de equipos</a></li>
											</ul>
										</li>

										<li>
											<span class="opener">Consultas</span>
											<ul>
                                                <li><a href="ColaReparacionEquipo.aspx">Cola de Reparados</a></li>
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


