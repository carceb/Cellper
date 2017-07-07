using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class FallaCelular
    {
        public static int InserFallaCelular(CFallaCelular objetoFallaCelular)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@FallaCelularID", SqlDbType.Int, 0, objetoFallaCelular.FallaCelularID),
                    DBHelper.MakeParam("@NombreFallaCelular", SqlDbType.VarChar, 0, objetoFallaCelular.NombreFallaCelular)

                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_FallaCelular_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
    }
}