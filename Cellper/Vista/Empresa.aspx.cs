using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEmpresa();
            }
        }
        public void CargarEmpresa()
        {
            try
            {
                DataSet ds = Empresa.ObtenerEmpresas(Convert.ToInt32(hdnEmpresaID.Value));
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}