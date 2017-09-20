using Seguridad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguridad
{
    public partial class Seguridad : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 17) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            EstablecerObjetos();
        }
        private void EstablecerObjetos()
        {
            CSeguridad objetoSeguridad = new CSeguridad();
            objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);
            if (objetoSeguridad.EsUsuarioAdministrador() == true)
            {
                btnAgregarGrupo.Visible = true;
                btnAgregarObjeto.Visible = true;
                btmAgregarGrupoObjeto.Visible = true;
            }
            else
            {
                btnAgregarGrupo.Visible = false;
                btnAgregarObjeto.Visible = false;
                btmAgregarGrupoObjeto.Visible = false;
            }
        }
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadUsuario.aspx");
        }

        protected void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadGrupo.aspx");
        }

        protected void btnAgregarObjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadObjeto.aspx");
        }

        protected void btmAgregarGrupoObjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadObjetoGrupo.aspx");
        }
    }
}