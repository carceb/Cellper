using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial  class CellperConsulta
    {
        public static SqlDataReader ObtenerDatosEquipoParaConsulta(int cedulaCliente, int recepcionEquipoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {   
                    DBHelper.MakeParam("@CedulaCliente", SqlDbType.Int, 0, cedulaCliente),
                    DBHelper.MakeParam("@RecepcionEquipoID", SqlDbType.Int, 0, recepcionEquipoID)
                };
            return DBHelper.ExecuteDataReader("usp_CellperConsulta_ObtenerDatosEquipoParaConsulta", dbParams);
        }
    }
}