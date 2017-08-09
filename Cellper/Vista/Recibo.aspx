<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recibo.aspx.cs" Inherits="Cellper.Recibo" %>

<!DOCTYPE html>

<html>
	<head>
		<title>Cellper | Recibo</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />   

<%--------------------------%>

	    <style type="text/css">
            .auto-style3 {
                position: fixed;
                z-index: 100;
                margin-left: 2px;
                left: 37px;
                top: 161px;
            }
        </style>

	</head>

<body>
    <form id="form1" runat="server">
        <div>

            <img src="../images/ReciboMDT.png" />
        </div>
    
        <div class="auto-style3">
        <table>
            <tr>
                <td>
                    <asp:Label Text="Cliente" ID="Label6" runat="server" Width ="50" />
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtCliente"  Width ="270px" />      
                </td>
                </tr>
            <tr>
                <td >
                    <asp:Label Text="Cedula" ID="Label5" runat="server" />
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtCedulaCliente" Width ="100"/> 
                </td>
                <td >
                    <asp:Label Text="Telefono" ID="Label1" runat="server" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTelefonoCliente"  Width ="100"/> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Text="Imei/Serial" ID="Label2" runat="server" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtIMEISerial"  Width ="100"/> 
                </td>
                <td >
                    <asp:Label Text="Equipo" ID="Label3" runat="server" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTipoEquipo"  Width ="100"/> 
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label Text="Marca" ID="Label4" runat="server" />
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtMarca"  Width ="100"/> 
                </td>
                <td>
                    <asp:Label Text="Modelo" ID="Label7" runat="server" />
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtModelo"   Width ="100"/> 
                </td>
            </tr>
            <tr>
            <td >
                <asp:Label Text="Falla" ID="Label8" runat="server" />
            </td>
            <td colspan ="3">
                <asp:TextBox runat="server" ID="txtFalla"  Width ="270px"/> 
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
