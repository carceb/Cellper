<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarcaEquipo.aspx.cs" Inherits="Cellper.MarcaEquipo" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Marca de Equipo</title>
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
                identifier: 'Marcas'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnTipoCelularID").value = par[0];
            document.getElementById("hdnTipoEquipoID").value = par[3];
            document.getElementById("txtNombre").value = par[1];
            $("#ddlTipoEquipo").val(par[3]);
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
									<a class="logo"><strong>Marca de Equipo</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
                            <form runat ="server" id ="principal">
								<section>
                                        <p></p>
                                        <div class="row uniform">
									        <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlTipoEquipo" runat="server" AppendDataBoundItems="True" ></asp:DropDownList> 
                                                    <asp:HiddenField runat ="server" ID ="hdnTipoEquipoID"  Value="0"/>
                                                </div>

									        </div>
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtNombre" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder="Marca equipo"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnTipoCelularID"  Value="0"/>
                                                <ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre de la marca" width="132px" controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
									        </div>
										    <div class="12u$">
											    <ul class="actions">
                                                    <li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"  /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo"  CssClass ="boton_formulario" OnClick="btnNuevo_Click" CausesValidation="False" /></li>
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
												<li><a href="ColaDeEquipos.aspx">Cola de equipos Pendientes</a></li>
											</ul>
										</li>

										<li>
											<span class="opener">Consultas</span>
											<ul>
                                                <li><a href="ColaReparacionEquipo.aspx">Cola de Equipos por Entregar</a></li>
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
