<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Seguridad.Index" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>




<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper Entrada al Sistema</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="stylesheet" href="loginassets/css/main.css" />


	    <script src="js/Util.js" type="text/javascript"></script>
        <script src="js/jquery.js"></script>

		<noscript><link rel="stylesheet" href="loginassets/css/noscript.css" /></noscript>

	</head>
	<body class="is-loading">
    <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
					<section id="main">
						<header>
							<span class="avatar"><img src="images/avatar.jpg" alt="" /></span>
							<h1>BIenvenido al sistema Cellper</h1>
							<p>Indique sus credenciales de acceso</p>
						</header>

						<footer>
                            <form id ="w" runat ="server">
							    <ul class="icons">
								    <li><asp:Label runat="server" ID ="lblLogin" Text ="Usuario" Width="80"></asp:Label></li>
								    <li><asp:TextBox runat="server" ID ="txtLogin" Text ="" Width="132px"></asp:TextBox></li>
                                    <ASP:RequiredFieldValidator id="chkUserID" runat="server" errormessage="* Debe colocar el nombre de usuario" width="132px" controltovalidate="txtLogin" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
								    <li><asp:Label runat="server" ID ="lblClave" Text ="Clave" Width="132px"></asp:Label></li>
                                    <li><asp:TextBox runat="server" ID ="txtClave" Text ="" Width="132px" textmode="Password" maxlength="25"></asp:TextBox></li>
                                    <ASP:RequiredFieldValidator id="chkClave" runat="server" errormessage="* Debe colocar la clave" width="132px" controltovalidate="txtClave" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
							    </ul>
                                <p><asp:Button runat="server" ID ="btnAceptar"   class="button big"  Text ="Aceptar" OnClick="btnAceptar_Click" ></asp:Button></p>
                            </form>
						</footer>
					</section>

				<!-- Footer -->
					<footer id="footer">
						<ul class="copyright">
							<li>&copy; Cellper</li>
						</ul>
					</footer>

			</div>

		<!-- Scripts -->

			<script>
				if ('addEventListener' in window) {
					window.addEventListener('load', function() { document.body.className = document.body.className.replace(/\bis-loading\b/, ''); });
					document.body.className += (navigator.userAgent.match(/(MSIE|rv:11\.0)/) ? ' is-ie' : '');
				}
			</script>

	</body>
</html>
