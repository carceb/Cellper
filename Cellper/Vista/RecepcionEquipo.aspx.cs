﻿using Seguridad;
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
    public partial class RecepcionEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session,9) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!IsPostBack)
            {
                CargarTecnico();
                CargarFalla();
                CargarTipoEquipo();
                CargarCondicionEquipo();
                ddlTipoCelular.Items.Add(new ListItem("--Seleccione la marca del equipo--", ""));
                ddlModeloCelular.Items.Add(new ListItem("--Seleccione el modelo del equipo--", ""));
            }
   

        }
        private void CargarTipoEquipo()
        {
            ddlTipoEquipo.Items.Clear();
            ddlTipoEquipo.Items.Add(new ListItem("--Seleccione el tipo de equipo--", ""));
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
            ddlTipoCelular.Items.Add(new ListItem("--Seleccione la marca del equipo--", ""));
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
        private void CargarModeloCelular(int tipoCelularID)
        {
            ddlModeloCelular.Items.Clear();
            ddlModeloCelular.Items.Add(new ListItem("--Seleccione el modelo del equipo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From ModeloCelular Where TipoCelularID = " + tipoCelularID;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlModeloCelular.DataSource = cmd.ExecuteReader();
                    ddlModeloCelular.DataTextField = "NombreModeloCelular";
                    ddlModeloCelular.DataValueField = "ModeloCelularID";
                    ddlModeloCelular.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarFalla()
        {
            ddlFalla.Items.Clear();
            ddlFalla.Items.Add(new ListItem("--Seleccione el tipo de falla--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From FallaCelular ORDER BY NombreFallaCelular";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlFalla.DataSource = cmd.ExecuteReader();
                    ddlFalla.DataTextField = "NombreFallaCelular";
                    ddlFalla.DataValueField = "FallaCelularID";
                    ddlFalla.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTecnico()
        {
            ddlTecnico.Items.Clear();
            ddlTecnico.Items.Add(new ListItem("--Seleccione el técnico--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM DetalleUsuarioTecnico WHERE EmpresaSucursalID =" + Session["CodigoSucursalEmpresa"];

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTecnico.DataSource = cmd.ExecuteReader();
                    ddlTecnico.DataTextField = "NombreCompleto";
                    ddlTecnico.DataValueField = "SeguridadUsuarioDatosID";
                    ddlTecnico.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarCondicionEquipo()
        {
            ddlCondicionEquipo.Items.Clear();
            ddlCondicionEquipo.Items.Add(new ListItem("--Seleccione condición equipo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From CondicionEquipo ORDER BY CondicionEquipoID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlCondicionEquipo.DataSource = cmd.ExecuteReader();
                    ddlCondicionEquipo.DataTextField = "NombreCondicionEquipo";
                    ddlCondicionEquipo.DataValueField = "CondicionEquipoID";
                    ddlCondicionEquipo.DataBind();
                    con.Close();
                }
            }
        }
        public void CargarDetalleServicio(bool esTodoEstatus)
        {
            int codigoEstatus;
            if (esTodoEstatus == true)
            {
                codigoEstatus = 0;
            }
            else
            {
                codigoEstatus = 1;
            }
            try
            {
                DataSet ds = Recepcion.ObtenerServiciosCliente(Convert.ToInt32(txtCedula.Text), codigoEstatus, Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void ddlTipoEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoEquipo.SelectedValue != "")
            {
                CargarTipoCelular(Convert.ToInt32(ddlTipoEquipo.SelectedItem.Value));
                if (ddlTipoCelular.SelectedIndex >= 0)
                {
                    if(ddlTipoCelular.SelectedValue != "")
                    {
                        CargarModeloCelular(Convert.ToInt32(ddlTipoCelular.SelectedItem.Value));
                    }else
                    {
                        ddlModeloCelular.Items.Clear();
                        ddlModeloCelular.Items.Add(new ListItem("--Seleccione el modelo del equipo--", ""));
                    }

                }
                else
                {
                    CargarModeloCelular(0);
                }
            }
            else
            {
                ddlTipoCelular.Items.Clear();
                ddlModeloCelular.Items.Clear();
            }
        }

        protected void ddlTipoCelular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTipoCelular.SelectedIndex >= 0)
            {
                CargarModeloCelular(Convert.ToInt32(ddlTipoCelular.SelectedItem.Value));
            }
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    CRecepcion objetoRecepcion = new CRecepcion();
                    objetoRecepcion.RecepcionEquipoID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (Recepcion.EliminarRecepcion(Convert.ToInt32(e.CommandArgument.ToString())) > 0)
                    {
                        messageBox.ShowMessage("Equipo eliminado.");
                        CargarDetalleServicio(true);
                    }
                    else
                    {
                        messageBox.ShowMessage("No se pudo eliminar el detalle. Intente nuevamente.");
                    }
                }
                else if (e.CommandName == "ImprimirRecibo")
                {
                    string urlLlamado = "Recibo.aspx?numeroRecibo=" + Convert.ToInt32(e.CommandArgument.ToString());
                    string scriptJava = "<script language =javascript> ";
                    scriptJava += "window.open('" + urlLlamado + "',null,'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=430,height=630,left=100,top=100');";
                    scriptJava += "</script> ";
                    Response.Write(scriptJava);
                }
                else if (e.CommandName == "Garantia")
                {
                    hdnEquipoRecepcionGarantiaID.Value = e.CommandArgument.ToString();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if(EsTodoCorrecto() == true)
            {
                EnviarRecepcion();
            }
        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            if (ddlTipoEquipo.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar el tipo de equipo.");
            }
            if (ddlTipoCelular.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar la marca.");
            }
            if (ddlModeloCelular.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar el modelo.");
            }
            if (ddlCondicionEquipo.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar la condición del equipo.");
            }
            if (ddlFalla.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar la falla.");
            }
            if (ddlTecnico.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar el nombre del técnico.");
            }
            return resultado;
        }
        private void EnviarRecepcion()
        {
            CCliente objetoCliente = new CCliente();
            if (Convert.ToInt32(hdnCedula.Value) == 0)
            {
                objetoCliente.CedulaCliente = Convert.ToInt32(txtCedula.Text);
            }
            else
            {
                objetoCliente.CedulaCliente = Convert.ToInt32(hdnCedula.Value);
            }

            objetoCliente.NombreCliente = txtNombre.Text.ToUpper();
            objetoCliente.TelefonoCliente = txtTelefono.Text;
            objetoCliente.DireccionCliente = txtDireccion.Text.ToUpper();

            CRecepcion objetoRecepcion = new CRecepcion();
            objetoRecepcion.ClienteID = Convert.ToInt32(hdnClienteID.Value);
            objetoRecepcion.ModeloCelularID = Convert.ToInt32(ddlModeloCelular.SelectedValue);
            objetoRecepcion.TipoEquipoID = Convert.ToInt32(ddlTipoEquipo.SelectedValue);
            objetoRecepcion.Imei = txtIMEI.Text.ToUpper();
            objetoRecepcion.FallaCelularID = Convert.ToInt32(ddlFalla.SelectedValue);
            objetoRecepcion.Observaciones = txtObservaciones.Text.ToUpper();
            objetoRecepcion.TecnicoID = Convert.ToInt32(ddlTecnico.SelectedValue);
            objetoRecepcion.EstatusEquipoID = 1;
            objetoRecepcion.CondicionEquipoID = Convert.ToInt32(ddlCondicionEquipo.SelectedValue);
            objetoRecepcion.DescripcionAccesorios = txtAccesorios.Text.ToUpper();
            objetoRecepcion.CostoPresupuesto = Convert.ToDouble(txtCostoRevision.Text);
            objetoRecepcion.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
            if (Recepcion.InsertarRecepcion(objetoRecepcion, objetoCliente) > 0)
            {
                messageBox.ShowMessage("Registro actualizado.");
                CargarDetalleServicio(false);
            }
            else
            {
                messageBox.ShowMessage("Ocurrió un error, no se pudieron actualizar los registros");
            }
        }
        private void NuevoRegistro()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtIMEI.Text = "";
            txtObservaciones.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            hdnCedula.Value = "0";
            hdnClienteID.Value = "0";
            hdnCodigoModelo.Value = "0";
            hdnEquipoRecepcionGarantiaID.Value = "0";
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
            CargarTipoEquipo();
            CargarTecnico();
            CargarFalla();
            ddlTipoCelular.Items.Clear();
            ddlModeloCelular.Items.Clear();
            ddlTipoCelular.Items.Add(new ListItem("--Seleccione la marca del equipo--", ""));
            ddlModeloCelular.Items.Add(new ListItem("--Seleccione el modelo del equipo--", ""));
            txtCedula.Focus();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            CargarDetalleServicio(true);
        }

        protected void btnEnviarGarantia_Click(object sender, EventArgs e)
        {
            if (Recepcion.EsEquipoEntregado(Convert.ToInt32(hdnEquipoRecepcionGarantiaID.Value)) == true)
            {
                if ((Convert.ToInt32(hdnEquipoRecepcionGarantiaID.Value) != 0))
                {
                    if (txtObservacionesGarantia.Text != "")
                    {

                        if (Recepcion.EnviarEquipoGarantia(Convert.ToInt32(hdnEquipoRecepcionGarantiaID.Value), txtObservacionesGarantia.Text.ToUpper()) > 0)
                        {
                            messageBox.ShowMessage("Equipo enviado a garantía.");
                            NuevoRegistro();
                        }
                    }
                    else
                    {
                        messageBox.ShowMessage("Debe colocar las observaciones");
                    }
                }
            }
            else
            {
                messageBox.ShowMessage("No puede enviar a garantía un equipo no entregado");
            }
        }
    }
}