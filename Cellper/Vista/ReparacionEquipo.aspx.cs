using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Seguridad;

namespace Cellper
{
    public partial class ReparacionEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session,10) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!IsPostBack)
            {
                CargarEquipo();
                CargarItemsInventario();
                CargarEstatus();
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
        private void CargarEstatus()
        {
            ddlEstatus.Items.Clear();
            ddlEstatus.Items.Add(new ListItem("--Seleccione el estatus--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM EstatusEquipo WHERE (EstatusEquipoID = 3 OR EstatusEquipoID = 4 OR EstatusEquipoID = 6)";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEstatus.DataSource = cmd.ExecuteReader();
                    ddlEstatus.DataTextField = "NombreEstatusEquipo";
                    ddlEstatus.DataValueField = "EstatusEquipoID";
                    ddlEstatus.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarItemsInventario()
        {
            ddlItemInventario.Items.Clear();
            ddlItemInventario.Items.Add(new ListItem("--Seleccione el material utilizado--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM Inventario WHERE EmpresaSucursalID = " + Session["CodigoSucursalEmpresa"] + "  ORDER BY NombreItem";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlItemInventario.DataSource = cmd.ExecuteReader();
                    ddlItemInventario.DataTextField = "NombreItem";
                    ddlItemInventario.DataValueField = "InventarioID";
                    ddlItemInventario.DataBind();
                    con.Close();
                }
            }
        }
        protected void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlEstatus.SelectedItem.Value=="3")
            {
                CargarItemsInventario();
                ddlItemInventario.Visible = true;
                txtObservaciones.Visible = false;
                btnGuardar.Visible = false;
            }
            else if (ddlEstatus.SelectedItem.Value == "")
            {
                if (gridDetalle.Rows.Count == 0)
                {
                    TodoInvisible();
                }
                else
                {
                    ddlEstatus.SelectedValue = "3";
                    messageBox.ShowMessage("Debe eliminar todos los materiales cargados para poder cambiar el estatus.");
                }

            }
            else if (ddlEstatus.SelectedItem.Value == "4" || ddlEstatus.SelectedItem.Value == "6" && ddlEstatus.SelectedItem.Value != "")
            {
                if(gridDetalle.Rows.Count == 0)
                {
                    TodoInvisible();
                    ddlItemInventario.Visible = false;
                    txtObservaciones.Visible = true;
                    btnGuardar.Visible = true;
                }
                else
                {
                    ddlEstatus.SelectedValue = "3";
                    messageBox.ShowMessage("Debe eliminar todos los materiales cargados para poder cambiar el estatus.");
                }
            }
        }

        protected void ddlItemInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemInventario.SelectedItem.Value == "1")
            {
                if (gridDetalle.Rows.Count == 0)
                {
                    TodoInvisible();
                    txtCantidad.Visible = false;
                    txtObservacionesReparacion.Visible = true;
                    btnGuardar.Visible = true;
                    btnLista.Visible = false;
                }
                else
                {
                    ddlItemInventario.SelectedValue = "2";
                    messageBox.ShowMessage("Debe eliminar todos los materiales seleccionar la opición NINGUN MATERIAL.");
                }


            }
            else if (ddlItemInventario.SelectedItem.Value == "")
            {
                TodoInvisible();

            }
            else if (ddlItemInventario.SelectedItem.Value != "1" && ddlItemInventario.SelectedItem.Value != "")
            {
                TodoVisible();
            }
        }
        private void TodoInvisible()
        {
            txtObservacionesReparacion.Visible = false;
            txtCantidad.Visible = false;
            txtObservaciones.Visible = false;
            btnGuardar.Visible = false;
            btnLista.Visible = false;
            gridDetalle.Visible = false;
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
            lblDetalle.Visible = false;
        }
        private void TodoVisible()
        {
            txtCantidad.Visible = true;
            txtObservacionesReparacion.Visible = true;
            btnGuardar.Visible = true;
            btnLista.Visible = true;
            lblDetalle.Visible = true;
            gridDetalle.Visible = true;
        }


        private void CargarEquipoReparado()
        {
            try
            {
                DataSet ds = ReparacionEquipo.ObtenerEquipoReparado(Convert.ToInt32(Request.QueryString["RecepcionEquipoID"]));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlEstatus.SelectedValue) == 3)
            {
                if (Convert.ToInt32(ddlItemInventario.SelectedValue) > 1)
                {
                    if (gridDetalle.Rows.Count > 0)
                    {
                        Response.Redirect("ColaDeEquipos.aspx");
                    }
                    else
                    {
                        messageBox.ShowMessage("Debe agregar un material a la lista.");
                    }
                }
                else
                {
                    ProcesoActualizar();
                }
            }
            else
            {
                ProcesoActualizar();
            }

        }
                
        protected void btnLista_Click(object sender, EventArgs e)
        {
            ProcesoActualizar();
        }
        private void ProcesoActualizar()
        {
            if (Convert.ToInt32(ddlEstatus.SelectedValue) == 3)
            {
                CReparacionEquipo objetoReparacionEquipo = new CReparacionEquipo();
                objetoReparacionEquipo.RecepcionEquipoID = Convert.ToInt32(Request.QueryString["RecepcionEquipoID"]);
                objetoReparacionEquipo.InventarioID = Convert.ToInt32(ddlItemInventario.SelectedValue);
                if(txtCantidad.Text != "")
                {
                    objetoReparacionEquipo.CantidadItem = Convert.ToInt32(txtCantidad.Text);
                }
                else
                {
                    objetoReparacionEquipo.CantidadItem = 0;
                }
                
                objetoReparacionEquipo.TecnicoID = Convert.ToInt32(hdnCodigoTecnico.Value);
                objetoReparacionEquipo.EstatusEquipoID = Convert.ToInt32(ddlEstatus.SelectedValue);
                objetoReparacionEquipo.ObservacionReparacionEquipo = txtObservacionesReparacion.Text.ToUpper();

                if (ReparacionEquipo.InsertarReparacionEquipo(objetoReparacionEquipo) > 0)
                {
                    if(ddlItemInventario.SelectedValue != "1")
                    {
                        CargarEquipoReparado();
                    }
                    else
                    {
                        Response.Redirect("ColaDeEquipos.aspx");
                    }
                    
                }
            }
            else
            {
                CReparacionEquipo objetoReparacionEquipo = new CReparacionEquipo();
                objetoReparacionEquipo.RecepcionEquipoID = Convert.ToInt32(Request.QueryString["RecepcionEquipoID"]);
                objetoReparacionEquipo.InventarioID = 1;
                objetoReparacionEquipo.CantidadItem = 0;
                objetoReparacionEquipo.TecnicoID = Convert.ToInt32(hdnCodigoTecnico.Value);
                objetoReparacionEquipo.EstatusEquipoID = Convert.ToInt32(ddlEstatus.SelectedValue);
                objetoReparacionEquipo.ObservacionReparacionEquipo = txtObservaciones.Text.ToUpper();

                if(ReparacionEquipo.InsertarReparacionEquipo(objetoReparacionEquipo)> 0)
                {
                    Response.Redirect("ColaDeEquipos.aspx");
                }
            }

        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "EliminarDetalle")
            {

                if (ReparacionEquipo.EliminarMaterialReparacion(Convert.ToInt32(e.CommandArgument.ToString())) > 0)
                {
                    messageBox.ShowMessage("Material eliminado.");
                    CargarEquipoReparado();
                }
                else
                {
                    messageBox.ShowMessage("No se pudo eliminar el detalle. Intente nuevamente.");
                }
            }
        }
    }
}