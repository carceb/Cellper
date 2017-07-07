using System;
using System.Data;



namespace Admin
{
    public partial class Autocomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["query"] != "")
            {

                if (Request.QueryString["identifier"] == "Clientes")
                {
                    DataSet ds = Autocomplete.ObtenerClientes(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["DatosCliente"].ToString();
                            item.id = dr["CedulaCliente"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreCliente"].ToString() + "_" + dr["CedulaCliente"].ToString() + "_" + dr["TelefonoCliente"].ToString() + "_" + dr["DireccionCliente"].ToString() + "_" + dr["EMailCliente"].ToString() + "_" + dr["ClienteID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Marcas")
                {
                    DataSet ds = Autocomplete.ObtenerTipoCelular(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoCelular"].ToString();
                            item.id = dr["TipoCelularID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoCelular"].ToString() + "_" + dr["TipoCelularID"].ToString() + "_" + dr["TipoEquipoID"].ToString()  + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Modelos")
                {
                    DataSet ds = Autocomplete.ObtenerModeloCelular(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreModeloCelular"].ToString();
                            item.id = dr["ModeloCelularID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreModeloCelular"].ToString() + "_" + dr["ModeloCelularID"].ToString() + "_" + dr["TipoCelularID"].ToString() + "_" + dr["TipoEquipoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Fallas")
                {
                    DataSet ds = Autocomplete.ObtenerFallaCelular(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreFallaCelular"].ToString();
                            item.id = dr["FallaCelularID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreFallaCelular"].ToString() + "_" + dr["FallaCelularID"].ToString()  + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
            }
        }
    }
}