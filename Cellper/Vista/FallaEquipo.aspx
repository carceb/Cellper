<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FallaEquipo.aspx.cs" Inherits="Cellper.FallaEquipo" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Fallas Equipos</title>
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
                identifier: 'Fallas'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnFallaCelularID").value = par[0];
            document.getElementById("txtNombre").value = par[1];
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
									<a class="logo"><strong>Falla Equipos</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
                             <form runat ="server" id ="principal">
								<section>
                                        <p></p>
                                        <div class="row uniform">
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtNombre" MaxLength="200" onkeypress="return event.keyCode!=13;" placeholder ="Nombre de la falla"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnFallaCelularID"  Value="0"/>
                                                <ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre de la falla" controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
									        </div>
										    <div class="12u$">
											    <ul class="actions">
                                                    <li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click" /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo" CausesValidation="False" OnClick="btnNuevo_Click" /></li>
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
                                <uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>

							<!-- Section -->


							<!-- Section -->


						</div>
					</div>

			</div>
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>
