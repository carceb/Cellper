using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class ModeloCelular
    {
        public static int InserTipoCelular(CModeloCelular objetoModeloCelular)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@ModeloCelularID", SqlDbType.Int, 0, objetoModeloCelular.ModeloCelularID),
                    DBHelper.MakeParam("@TipoCelularID", SqlDbType.Int, 0, objetoModeloCelular.TipoCelularID),
                    DBHelper.MakeParam("@NombreModeloCelular", SqlDbType.VarChar, 0, objetoModeloCelular.NombreModeloCelular)

                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_ModeloCelular_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
    }
}