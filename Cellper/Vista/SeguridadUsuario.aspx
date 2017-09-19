<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguridadUsuario.aspx.cs" Inherits="Seguridad.SeguridadUsuario" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>



<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Usuarios</title>
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
                identifier: 'Usuarios'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("chkTecnico").checked = false;
            document.getElementById("chkEstatus").checked = false;
            document.getElementById("hdnSeguridadUsuarioDatosID").value = par[0]; //par[0] id
            document.getElementById("txtNombre").value = par[1];
            document.getElementById("txtLogin").value = par[2];
            document.getElementById("txtClave").value = par[3];
            document.getElementById("txtDescripion").value = par[4];
            document.getElementById("hdnTecnico").value = par[6];
            document.getElementById("hdnEstatus").value = par[7];

            if (document.getElementById("hdnTecnico").value == "True") {
                document.getElementById("chkTecnico").checked = true;
            }
            if (document.getElementById("hdnEstatus").value == "Activo") {
                document.getElementById("chkEstatus").checked = true;
            }
            $("#ddlGrupo").val(par[5]);
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
									<a class="logo"><strong>Usuarios</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
                                <section>
                                        <p></p>
                                        <div class="row uniform">
									        <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtNombre" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Nombre completo del usuario"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnSeguridadUsuarioDatosID"  Value="0"/>
                                                <ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre completo"  controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
									        </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtLogin"  MaxLength="50" placeholder ="Nombre Login"/> 
                                                <ASP:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" errormessage="Debe colocar el login"  controltovalidate="txtLogin" display="Dynamic"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtClave" MaxLength="50" placeholder ="Clave" /> 
                                                <ASP:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" errormessage="Debe colocar la clave"  controltovalidate="txtClave" display="Dynamic"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:TextBox runat="server" ID="txtDescripion" MaxLength="200" placeholder ="Descripción del usuario"/> 
                                                <ASP:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" errormessage="Debe colocar la descripción del usuario"  controltovalidate="txtDescripion" display="Dynamic"></ASP:RequiredFieldValidator>
                                            </div>
									        <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlGrupo" runat="server"  AppendDataBoundItems="True" ></asp:DropDownList>
                                                </div>
									        </div>
   
                                            <div class="6u 12u$(xsmall)"> 
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack = "true"  AppendDataBoundItems="True" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged" ></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlSucursal" runat="server" AutoPostBack = "true"  AppendDataBoundItems="True" ></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)"> 
                                                <asp:CheckBox runat="server" ID="chkTecnico" Text="Usuario técnico"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnTecnico"  Value=""/>
                                                <asp:CheckBox runat="server" ID="chkEstatus" Checked="True" Text ="Activo"/> 
                                                <asp:HiddenField runat ="server" ID ="hdnEstatus"  Value=""/>
                                            </div>
										    <div class="12u$">
											    <ul class="actions">
                                                    <asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"/>
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


