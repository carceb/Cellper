﻿using System;
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
    public partial class ModeloCelular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoEquipo();
                CargarTipoCelular(Convert.ToInt32(ddlTipoEquipo.SelectedItem.Value));
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

        private void CargarTipoCelular(int tipoEquipoID)
        {
            ddlTipoCelular.Items.Clear();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            if (tipoEquipoID != 0)
            {
                strQuery = "select * From TipoCelular  WHERE TipoEquipoID   = " + tipoEquipoID + "  ORDER BY TipoCelularID";
            }
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoCelular.DataSource = cmd.ExecuteReader();
                    ddlTipoCelular.DataTextField = "NombreTipoCelular";
                    ddlTipoCelular.DataValueField = "TipoCelularID";
                    ddlTipoCelular.DataBind();
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
            CModeloCelular objetoModeloCelular = new CModeloCelular();

            objetoModeloCelular.ModeloCelularID = Convert.ToInt32(hdnModeloCelularID.Value);

            if (hdnTipoCelularID.Value == "0")
            {
                objetoModeloCelular.TipoCelularID = Convert.ToInt32(ddlTipoCelular.SelectedItem.Value);
            }
            else
            {
                objetoModeloCelular.TipoCelularID = Convert.ToInt32(hdnTipoCelularID.Value);
            }
            objetoModeloCelular.NombreModeloCelular = txtNombre.Text.ToUpper();

           if( ModeloCelular.InserTipoCelular(objetoModeloCelular) > 0)
            {
                messageBox.ShowMessage("Registro actualzado.");
                NuevoRegistro();
            }
            else
            {
                messageBox.ShowMessage("Ocurrió un error, no se actualzaron los registros");
            }

        }
        private void NuevoRegistro()
        {
            hdnTipoEquipoID.Value = "0";
            hdnTipoCelularID.Value = "0";
            txtNombre.Text = "";
            CargarTipoEquipo();
            CargarTipoCelular(Convert.ToInt32(ddlTipoEquipo.SelectedItem.Value));
        }

        protected void ddlTipoEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTipoCelular(Convert.ToInt32(ddlTipoEquipo.SelectedItem.Value));
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }
    }
}