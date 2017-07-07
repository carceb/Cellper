using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class FallaCelular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInsertar();
        }
        private void ProcesoInsertar()
        {
            CFallaCelular objetoFallaCelular = new CFallaCelular();

            objetoFallaCelular.FallaCelularID = Convert.ToInt32(hdnFallaCelularID.Value);
            objetoFallaCelular.NombreFallaCelular = txtNombre.Text.ToUpper();

            if (FallaCelular.InserFallaCelular(objetoFallaCelular) > 0)
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
            hdnFallaCelularID.Value = "0";
            txtNombre.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }
    }
}