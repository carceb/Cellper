using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguridad
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
              DataSet ds=  Login.ValidarLogin(txtUserID.Text, txtPassword.Text);
              DataTable dt = ds.Tables[0];
              if (dt.Rows.Count == 0)
              {
                    messageBox.ShowMessage("El usuario y/o la contaseña son incorrectos");
              }
                else
              {
                  this.Session["UserId"] = dt.Rows[0]["SeguridadUsuarioDatosID"].ToString();
                  this.Session["UserName"] = dt.Rows[0]["LoginUsuario"].ToString();
                  this.Session["NombreCompletoUsuario"] = dt.Rows[0]["NombreCompleto"].ToString();
                  this.Session["ClaveUsuario"] = dt.Rows[0]["ClaveUsuario"].ToString();
                  Response.Redirect("Main.aspx");
              }

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }
        private void ProcesoLogin()
        {
            if (Convert.ToInt32(hdnCodigoUsuario.Value) == 0)
            {

                try
                {
                    DataSet ds = Login.ValidarLogin(txtUserID.Text, txtPassword.Text);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        messageBox.ShowMessage("El usuario y/o la contaseña son incorrectos");
                    }
                    else
                    {
                        this.Session["UserId"] = dt.Rows[0]["SeguridadUsuarioDatosID"].ToString();
                        this.Session["UserName"] = dt.Rows[0]["LoginUsuario"].ToString();
                        this.Session["NombreCompletoUsuario"] = dt.Rows[0]["NombreCompleto"].ToString();
                        this.Session["ClaveUsuario"] = dt.Rows[0]["ClaveUsuario"].ToString();
                        hdnCodigoUsuario.Value = dt.Rows[0]["SeguridadUsuarioDatosID"].ToString();
                        CargarEmpresa(Convert.ToInt32(dt.Rows[0]["SeguridadUsuarioDatosID"].ToString()));
                    }

                }
                catch (Exception ex)
                {
                    messageBox.ShowMessage(ex.Message);
                }
            }
            else
            {
                this.Session["CodigoEmpresa"] = ddlConsultorio.SelectedValue;
                this.Session["NombreEmpresa"] = ddlConsultorio.SelectedItem;
                Response.Redirect("/Vista/Main.aspx");
            }
        }
        private void CargarEmpresa(int codigoUsuario)
        {

            CSeguridad objetoSeguridad = new CSeguridad();
            try
            {
                objetoSeguridad.SeguridadUsuarioDatosID = codigoUsuario;
                if (objetoSeguridad.EsUsuarioAdministrador() == true)
                {
                    EstablecerObjetos(true);
                    CargarComboEmpresas(0);
                }
                else
                {
                    if (CantidadEmpresasPorUsuario(codigoUsuario, false) < 1)
                    {
                        RestablecerVariables();
                        messageBox.ShowMessage("Este usuario no está configurado en el sistema.");
                    }
                    else if (CantidadEmpresasPorUsuario(codigoUsuario, false) == 1)
                    {
                        CargarComboEmpresas(codigoUsuario);
                        this.Session["CodigoEmpresa"] = CantidadEmpresasPorUsuario(codigoUsuario, true);
                        this.Session["NombreEmpresa"] = ddlConsultorio.SelectedItem;
                        Response.Redirect("/Vista/Main.aspx");
                    }
                    else if (CantidadEmpresasPorUsuario(codigoUsuario, false) > 1)
                    {
                        EstablecerObjetos(true);
                        CargarComboEmpresas(codigoUsuario);
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private int CantidadEmpresasPorUsuario(int codigoUsuario, bool esRetornoCodigoEmpresa)
        {
            int totalEncontrado = 0;
            int codigoEmpresa = 0;
            SqlDataReader dr = SeguridadUsuario.ObtenerEmpresas(codigoUsuario);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    codigoEmpresa = dr.GetInt32(5);
                    totalEncontrado = totalEncontrado + 1;
                }
            }
            if (esRetornoCodigoEmpresa == false)
            {
                return totalEncontrado;
            }
            else
            {
                return codigoEmpresa;
            }

        }
    }
}