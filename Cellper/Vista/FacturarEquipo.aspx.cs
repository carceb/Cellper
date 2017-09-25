using Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class FacturarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 21) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    CargarEquipo();
                    CargarEquipoReparado();
                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
        }
        private void CargarEquipo()
        {
            int recepcionEquipoID = Convert.ToInt32(Request.QueryString["RecepcionEquipoID"]);
            SqlDataReader dr = ReparacionEquipo.ObtenerDatosEquipo(recepcionEquipoID);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblFecha.Text = "Fecha recepción: " + dr.GetDateTime(0).ToString();
                    lblTipoEquipo.Text = "Tipo de equipo: " + dr.GetString(1);
                    lblMarca.Text = "Marca: " + dr.GetString(2);
                    lblModelo.Text = "Modelo: " + dr.GetString(3);
                    lblImei.Text = "IMEI: " + dr.GetString(4);
                    lblFalla.Text = "Falla: " + dr.GetString(5);
                    lblObservaciones.Text = "Observaciones: " + dr.GetString(6);
                    lblCliente.Text = "Cliente: " + dr.GetString(7);
                    hdnCodigoTecnico.Value = dr.GetInt32(8).ToString();
                }
            }
            dr.Close();
        }
        private void CargarEquipoReparado()
        {
            try
            {
                DataSet ds = ReparacionEquipo.ObtenerEquipoReparado(Convert.ToInt32(Request.QueryString["RecepcionEquipoID"]), Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridDetalle.Visible = true;
                }
                gridDetalle.DataSource = ds.Tables[0];
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }

    }
}