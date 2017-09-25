<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CellperConsulta.aspx.cs" Inherits="Cellper.CellperConsulta" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper Consulta</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
		<link rel="stylesheet" href="../consultaassets/css/main.css" />

	</head>
	<body>

		<!-- Header -->
			<header id="header">
				<h1>Sistema de Consultas Cellper</h1>
				<p>La manera mas sencilla de consultar el estatus de su equipo.<br />
				Solo con su cédula y número de recibo.</p>
			</header>

		<!-- Signup Form -->
			<form runat ="server" id="principal" method="post" action="#">
				<div>
                    <asp:TextBox runat="server" ID ="txtCedula" placeholder="Número de cédula" width ="300" ></asp:TextBox>
                    <ASP:RequiredFieldValidator id="rqrValidaCedula" runat="server" errormessage="Debe colocar el número de cédula"  controltovalidate="txtCedula" display="Dynamic"></ASP:RequiredFieldValidator>
                    <asp:Label runat="server" ID ="lblEstatus"  Visible ="false" Text ="Equipo recibido el día 23/06/2017, entró a servicio técnico el dia 24/06/2017, se encuentra siendo revisado por el tecnico asignado" Font-Bold="True"  ></asp:Label>
                </div>
                <div>
                	<p></P>
                </div>
                <div>
                     <asp:TextBox runat="server" ID ="txtRecibo" placeholder="Número de recibo" width ="300" ></asp:TextBox>
                     <ASP:RequiredFieldValidator id="rqrValidaRecibo" runat="server" errormessage="Debe colocar el número de recibo"  controltovalidate="txtRecibo" display="Dynamic"></ASP:RequiredFieldValidator>	
                </div>
                <div>
                	<p></P>
                </div>
                <div>
                    <asp:Button  runat="server" ID ="btnConsultar" Text ="Consultar" OnClick="btnConsultar_Click" />
                </div>
                <div>
                	<p></P>
                </div>
                <div id ="respuesta" runat ="server" visible="false">
                     
                </div>
			</form>

		<!-- Footer -->
			<footer id="footer">
				<ul class="copyright">
					<li>&copy; Sistema Cellper.</li>
				</ul>
			</footer>

		<!-- Scripts -->
            <script src="../consultaassets/js/main.js"></script>
	</body>
</html>