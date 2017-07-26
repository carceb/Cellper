using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Cellper
{
    public partial class AsignarEstatus : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Material"), new DataColumn("Cantidad"), new DataColumn("Observacion") });
                ViewState["Materiales"] = dt;
                this.BindGrid();

                CargarEquipo();
                CargarItemsInventario();
                CargarEstatus();
            }

        }
        protected void BindGrid()
        {
            grdMateriales.DataSource = (DataTable)ViewState["Materiales"];
            grdMateriales.DataBind();
        }

        protected void Insert(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Materiales"];
            dt.Rows.Add(ddlItemInventario.SelectedItem, txtCantidad.Text.Trim(),txtObservacionesReparacion.Text.Trim());
            ViewState["Materiales"] = dt;
            this.BindGrid();
            txtCantidad.Text = string.Empty;
            txtObservacionesReparacion.Text = string.Empty;
        }


        private void CargarEquipo()
        {
            int recepcionEquipoID = Convert.ToInt32(Request.QueryString["RecepcionEquipoID"]);
            SqlDataReader dr = AsignarEstatus.ObtenerDatosEquipo(recepcionEquipoID);
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

            strQuery = "SELECT * FROM Inventario ORDER BY InventarioID";
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
                TodoInvisible();
            }
            else if (ddlEstatus.SelectedItem.Value == "4" || ddlEstatus.SelectedItem.Value == "6" && ddlEstatus.SelectedItem.Value != "")
            {
                TodoInvisible();
                ddlItemInventario.Visible = false;
                txtObservaciones.Visible = true;
                btnGuardar.Visible = true;
            }
        }

        protected void ddlItemInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemInventario.SelectedItem.Value == "1")
            {
                txtCantidad.Visible = false;
                txtObservacionesReparacion.Visible = true;
                btnGuardar.Visible = true;
                btnLista.Visible = false;
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
            grdMateriales.Visible = false;
            grdMateriales.DataSource = null;
            grdMateriales.DataBind();
        }
        private void TodoVisible()
        {
            txtCantidad.Visible = true;
            txtObservacionesReparacion.Visible = true;
            btnGuardar.Visible = true;
            btnLista.Visible = true;
            lblDetalle.Visible = true;
            grdMateriales.Visible = true;
        }
    }
}