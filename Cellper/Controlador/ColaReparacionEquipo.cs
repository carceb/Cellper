using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class ColaReparacionEquipo
    {
        public static DataSet ObtenerColaEquiposReparacion(int codigoSucursal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal)
                };

            return DBHelper.ExecuteDataSet("usp_ColaReparacionEquipo_ObtenerColaEquipos", dbParams);
        }
    }
}