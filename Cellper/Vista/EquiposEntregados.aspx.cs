using Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class EquiposEntregados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 12) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            CargarEquiposEntregados();
        }
        private void CargarEquiposEntregados()
        {
            try
            {
                DataSet ds = Consultas.ObtenerEquiposEntregados(Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}