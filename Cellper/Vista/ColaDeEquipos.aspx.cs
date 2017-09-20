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
    public partial class ColaDeEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 10) == false)
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

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int recepcionEquipoID = 0;
            try
            {
                CRecepcion objetoRecepcion = new CRecepcion();
                recepcionEquipoID= Convert.ToInt32(e.CommandArgument.ToString());
                objetoRecepcion.RecepcionEquipoID = recepcionEquipoID;
                if (e.CommandName == "AsignarEstatus")
                {
                    Response.Redirect("ReparacionEquipo.aspx?RecepcionEquipoID=" + recepcionEquipoID);
                }
                else if (e.CommandName == "EliminarDetalle")
                {

                    if (Recepcion.EliminarRecepcion(Convert.ToInt32(e.CommandArgument.ToString())) > 0)
                    {
                        messageBox.ShowMessage("Recepción de equipo eliminada.");
                        CargarCola();
                    }
                    else
                    {
                        messageBox.ShowMessage("No se pudo eliminar el detalle. Intente nuevamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarCola()
        {
            try
            {
                DataSet ds = Recepcion.ObtenerColaEquipos(Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void ActualizarLista()
        {
            try
            {
                int contadorRegistros = 0;
                List<CRecepcion> objetoLista = new List<CRecepcion>();
                string sResultado = ValidarDatos(ref objetoLista);
                foreach (CRecepcion prod in objetoLista)
                {
                    contadorRegistros = contadorRegistros + 1;
                    Recepcion.ActualizarLista(prod);
                    CargarCola();

                }
                if (contadorRegistros > 0)
                {
                    messageBox.ShowMessage("Lista actualizada.");
                }
                else
                {
                    messageBox.ShowMessage("No existen registros por actualizar");
                }

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private string ValidarDatos(ref List<CRecepcion> objetoAsignarEstatus)
        {
            try
            {
                string sResultado = "";
                CRecepcion objetoAsignaEstatus = null;
                int j = 1;
                foreach (GridViewRow dr in this.gridDetalle.Rows)
                {
                    objetoAsignaEstatus = new CRecepcion();
                    objetoAsignaEstatus.EstatusEquipoID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlEstatus")).SelectedValue);
                    objetoAsignaEstatus.RecepcionEquipoID = Utils.utils.ToInt(((Label)dr.FindControl("lblCaso")).Text);
                    objetoAsignaEstatus.FechaAsignacionEstatus = Convert.ToString(System.DateTime.Now);


                    if (objetoAsignaEstatus.EstatusEquipoID == 0)
                        sResultado = "Estatus <br>";
                    objetoAsignarEstatus.Add(objetoAsignaEstatus);

                    if (sResultado != "")
                    {
                        sResultado = "En la Fila " + j.ToString() + " faltan ingresar los siguientes datos:<br><br>" + sResultado;
                        break;
                    }
                    j++;
                }

                return sResultado;
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
                return "";
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
        }
    }
}