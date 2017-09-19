﻿using Seguridad.Clases;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace Seguridad
{
    public partial class SeguridadUsuario : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrupos();
                CargarEmpresas();
                EstablecerObjetos();
            }
        }
        private void EstablecerObjetos()
        {
            CSeguridad objetoSeguridad = new CSeguridad();
            objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);
            if (objetoSeguridad.EsUsuarioAdministrador() == true)
            {
                ddlEmpresa.Enabled = true;
                ddlEmpresa.Items.Insert(0, new ListItem("--Seleccione la Empresa--", "0"));
            }
            else
            {
                ddlEmpresa.Enabled = false;
                CargarSucursal(Convert.ToInt32(Session["CodigoEmpresa"]));
            }
        }
        private void CargarGrupos()
        {
            ddlGrupo.Items.Clear();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from SeguridadGrupo";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlGrupo.DataSource = cmd.ExecuteReader();
                ddlGrupo.DataTextField = "NombreGrupo";
                ddlGrupo.DataValueField = "SeguridadGrupoID";
                ddlGrupo.DataBind();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        private void CargarEmpresas()
        {
            CSeguridad objetoSeguridad = new CSeguridad();
            objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);

            String strQuery;
            String strConnString = ConfigurationManager

            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            if (objetoSeguridad.EsUsuarioAdministrador() == true)
            {
                strQuery = "select * from Empresa Order By NombreEmpresa";
            }
            else
            {
                strQuery = "select * from Empresa Where EmpresaID =" + Convert.ToInt32(Session["CodigoEmpresa"]);
            }
           
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlEmpresa.DataSource = cmd.ExecuteReader();
                ddlEmpresa.DataTextField = "NombreEmpresa";
                ddlEmpresa.DataValueField = "EmpresaID";
                ddlEmpresa.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        private void CargarSucursal(int sucursalID)
        {
            ddlSucursal.Items.Clear();
            ddlSucursal.Items.Add(new ListItem("--Seleccione la sucursal--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            if (sucursalID != 0)
            {
                strQuery = "select * From EmpresaSucursal  WHERE EmpresaID   = " + sucursalID + "  ORDER BY EmpresaID";
            }
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlSucursal.DataSource = cmd.ExecuteReader();
                    ddlSucursal.DataTextField = "NombreSucursal";
                    ddlSucursal.DataValueField = "EmpresaSucursalID";
                    ddlSucursal.DataBind();
                    con.Close();
                }
            }
        }
        private void ActualizarRegistros()
        {
            if (EsTodoCorrecto()== true)
            {

                try
                {
                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(hdnSeguridadUsuarioDatosID.Value);
                    objetoSeguridad.NombreCompleto = this.txtNombre.Text.ToUpper();
                    objetoSeguridad.LoginUsuario = this.txtLogin.Text;
                    objetoSeguridad.ClaveUsuario = this.txtClave.Text;
                    objetoSeguridad.DescripcionUsuario = this.txtDescripion.Text.ToUpper();
                    objetoSeguridad.SeguridadGrupoID = Convert.ToInt32(ddlGrupo.SelectedValue);
                    objetoSeguridad.UsuarioTecnico = Convert.ToInt32(this.chkTecnico.Checked);
                    objetoSeguridad.EstatusUsuario = this.chkEstatus.Checked ? "Activo" : "Inactivo";
                    objetoSeguridad.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
                    if (SeguridadUsuario.InsertarUsuario(objetoSeguridad) > 0)
                    {
                        messageBox.ShowMessage("El usuario se ingresó correctamente");
                        LimpiarPantalla();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private void LimpiarPantalla()
        {
            this.txtNombre.Text = "";
            this.txtLogin.Text = "";
            this.txtDescripion.Text = "";
            this.txtClave.Text = "";
            this.hdnEstatus.Value = "";
            this.hdnSeguridadUsuarioDatosID.Value = "0";
            this.hdnTecnico.Value = "";
            this.chkTecnico.Checked = false;
            this.chkEstatus.Checked = true;
            ddlSucursal.Items.Clear();
            CargarGrupos();
            CargarEmpresas();
            EstablecerObjetos();

        }

        private bool EsTodoCorrecto()
        {
            bool esCorrecto = true;
            if (Convert.ToInt32(ddlGrupo.SelectedValue) < 1)
            {
                esCorrecto = false;
                messageBox.ShowMessage("Debe seleccionar el grupo");
            }
            if (Convert.ToInt32(hdnSeguridadUsuarioDatosID.Value) < 1)
            {
                if (EsLoginRegistrado() == true)
                {
                    esCorrecto = false;
                    messageBox.ShowMessage("El nombre de usuario o login que está colocando ya lo tiene otro usuario");
                }
            }

            return esCorrecto;
        }
        private bool EsLoginRegistrado()
        {
            DataSet ds = SeguridadUsuario.ObtenerLogin(this.txtLogin.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //this.ddlGrupo.SelectedValue = "10";
            ActualizarRegistros();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmpresa.SelectedValue != "0")
            {
                CargarSucursal(Convert.ToInt32(ddlEmpresa.SelectedItem.Value));
            }
            else
            {
                ddlSucursal.Items.Clear();
            }
        }
    }
}