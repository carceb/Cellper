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

        }

        private void ProcesoInsertar()
        {
            CInventario objetoInventario = new CInventario();

            objetoInventario.InventarioID = Convert.ToInt32(hdnInventarioID.Value);
            objetoInventario.NombreItem = txtNombre.Text.ToUpper();
            objetoInventario.CantidadItem = Convert.ToInt32(txtCantidad.Text);
            var z = txtCosto.Text.Replace(".", "");
            var a = z.Replace(",", ".");
            objetoInventario.CostoItem = Convert.ToDouble(a);
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