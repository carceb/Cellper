using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class TipoCelular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoEquipo();
            }
        }
        private void CargarTipoEquipo()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoEquipo ORDER BY TipoEquipoID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoEquipo.DataSource = cmd.ExecuteReader();
                    ddlTipoEquipo.DataTextField = "NombreTipoEquipo";
                    ddlTipoEquipo.DataValueField = "TipoEquipoID";
                    ddlTipoEquipo.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInsertar();
        }
        private void ProcesoInsertar()
        {
            CTipoCelular objetoTipoCelular = new CTipoCelular();

            objetoTipoCelular.TipoCelularID = Convert.ToInt32(hdnTipoCelularID.Value);
            objetoTipoCelular.NombreTipoCelular = txtNombre.Text.ToUpper();
            if(Convert.ToInt32(hdnTipoEquipoID.Value) ==0)
            {
                objetoTipoCelular.TipoEquipoID = Convert.ToInt32(ddlTipoEquipo.SelectedItem.Value);
            }
            else
            {
                objetoTipoCelular.TipoEquipoID = Convert.ToInt32(hdnTipoEquipoID.Value);
            }

            if(TipoCelular.InserTipoCelular(objetoTipoCelular) > 0)
            {
                messageBox.ShowMessage("Registro actualizado.");
                NuevoRegistro();
            }
            else
            {
                messageBox.ShowMessage("Ocurrió un error, no se actualzaron los registros");
            }
        }
        private void NuevoRegistro()
        {
            txtNombre.Text = "";
            CargarTipoEquipo();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }
    }
}