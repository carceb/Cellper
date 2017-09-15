using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class Consultas
    {
        public static DataSet ObtenerEquiposEntregados(int codigoSucursal)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                        DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal)
                    };

                return DBHelper.ExecuteDataSet("usp_ColaReparacionEquipo_ObtenerEquiposEntregados", dbParams);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}