﻿using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class Inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 13) == false)
            {
                Response.Redirect("/Index.aspx");
            }
        }

        private void ProcesoInsertar()
        {
            CInventario objetoInventario = new CInventario();

            objetoInventario.InventarioID = Convert.ToInt32(hdnInventarioID.Value);
            objetoInventario.NombreItem = txtNombre.Text.ToUpper();
            objetoInventario.CantidadItem = Convert.ToInt32(txtCantidad.Text);
            objetoInventario.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
            objetoInventario.CostoItem = Convert.ToDouble(txtCosto.Text);
            objetoInventario.SerialItem = txtSerial.Text.ToUpper();

            if (Inventario.ActualizarInventario(objetoInventario) > 0)
            {
                messageBox.ShowMessage("Registro actualzado.");
                NuevoRegistro();
            }
            else
            {
                messageBox.ShowMessage("Ocurrió un error, no se actualzaron los registros");
            }
        }
        private void NuevoRegistro()
        {
            hdnInventarioID.Value = "0";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtCosto.Text = "";
            txtSerial.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInsertar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }
    }
}