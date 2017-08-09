using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class Recibo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarDatosRecibo();
            }
        }
        private void CargarDatosRecibo()
        {
            SqlDataReader dr = Recepcion.ObtenerDatosRecibo(Convert.ToInt32(Request.QueryString["numeroRecibo"])); 
            while(dr.Read())
            {
                txtCliente.Text = dr.GetString(7);
                txtCedulaCliente.Text = dr.GetInt32(17).ToString();
                txtTelefonoCliente.Text = dr.GetString(18);
                txtIMEISerial.Text = dr.GetString(4);
                txtTipoEquipo.Text = dr.GetString(1);
                txtMarca.Text = dr.GetString(2);
                txtModelo.Text = dr.GetString(3);
                txtFalla.Text = dr.GetString(5);
            }
            dr.Close();

        }
    }
}