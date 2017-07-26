using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class AsignarEstatus
    {
        public static SqlDataReader ObtenerDatosEquipo(int recepcionEquipoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@RecepcionEquipoID", SqlDbType.Int, 0, recepcionEquipoID)
                };
             return DBHelper.ExecuteDataReader("usp_AsignarEstatus_ObtenerDatosEquipo", dbParams);
        }
    }
}