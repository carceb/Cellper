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
    public partial class ColaReparacionEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 11) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    CargarCola();
                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
        }
        private void CargarCola()
        {
            try
            {
                DataSet ds = ColaReparacionEquipo.ObtenerColaEquiposReparacion(Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int recepcionEquipoID = 0;
            try
            {
                CRecepcion objetoRecepcion = new CRecepcion();
                recepcionEquipoID = Convert.ToInt32(e.CommandArgument.ToString());
                objetoRecepcion.RecepcionEquipoID = recepcionEquipoID;
                if (e.CommandName == "AsignarEstatus")
                {
                    Response.Redirect("FacturarEquipo.aspx?RecepcionEquipoID=" + recepcionEquipoID);
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}