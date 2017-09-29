using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class CellperConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarEstatusEquipo();
        }
        private void ConsultarEstatusEquipo()
        {
            string mensajeEstatus = "";
            string fechaRecibido;
            string mensajeAlUsuario;
            SqlDataReader dr = CellperConsulta.ObtenerDatosEquipoParaConsulta(Convert.ToInt32(txtCedula.Text), Convert.ToInt32(txtRecibo.Text));
            EstablecerObjetos(false);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    fechaRecibido = dr.GetString(3);
                    switch (dr.GetInt32(2))
                    {
                        case 1:
                            mensajeEstatus = ", aun no ha sido revisado por nuestros técnicos.";
                            break;
                        case 2:
                            mensajeEstatus = ", fue entregado al técnico el día: " + dr.GetString(4) + " y lo está revisando.";
                            break;
                        case 3:
                            mensajeEstatus = ", ha sido reparado, por favor acuda a retirarlo.";
                            break;
                        case 4:
                            mensajeEstatus = ", fue revisado el día: " + dr.GetString(4) + " y se está a la espera de un repuesto.";
                            break;
                        case 5:
                            mensajeEstatus = ", fue entregado al cliente el dia: " + dr.GetString(5);
                            break;
                        case 6:
                            mensajeEstatus = ", fue revisado el día: " + dr.GetString(4) + " y lamentamos informarle que es irreparable, por favor pase a retirarlo.";
                            break;
                        case 7:
                            mensajeEstatus = " fue recibido por garantía nuestro local";
                            break;
                        default:
                            break;
                    }
                    mensajeAlUsuario = "Equipo recibido el día: " + fechaRecibido + mensajeEstatus;
                    lblEstatus.Text = mensajeAlUsuario;
                }
            }
            else
            {
                lblEstatus.Text = "El equipo que está consultando, con los datos de cédula y recibo colocados, no existe en nuestros registros.";
            }
            dr.Close();
        }
        private void EstablecerObjetos(bool EsVisible)
        {
            if(EsVisible == true)
            {
                lblEstatus.Visible = false;
            }
            else
            {
                lblEstatus.Visible = true;
            }
            txtRecibo.Visible = EsVisible;
            txtCedula.Visible = EsVisible;
            btnConsultar.Visible = EsVisible;
        }
    }
}