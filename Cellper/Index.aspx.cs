﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguridad
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Login.ValidarLogin(txtLogin.Text, txtClave.Text);
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
                    Response.Redirect("/Vista/Principal.aspx");
                }

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }
    }
}