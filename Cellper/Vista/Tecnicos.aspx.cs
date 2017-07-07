using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ProcesoInsertar()
        {
            CTecnicos objetoTecnicos = new CTecnicos();

            objetoTecnicos.TecnicoID = Convert.ToInt32(hdnTecnicoID.Value);
            objetoTecnicos.NombreTecnico = txtNombre.Text.ToUpper();
            objetoTecnicos.CedulaTecnico = Convert.ToInt32(txtCedula.Text);

            if (Tecnicos.InserTecnico(objetoTecnicos) > 0)
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
            hdnTecnicoID.Value = "0";
            txtNombre.Text = "";
            txtCedula.Text = "";
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