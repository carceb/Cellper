using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class TipoCelular
    {
        public static int InserTipoCelular(CTipoCelular objetoTipoCelular)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoCelularID", SqlDbType.Int, 0, objetoTipoCelular.TipoCelularID),
                    DBHelper.MakeParam("@NombreTipoCelular", SqlDbType.VarChar, 0, objetoTipoCelular.NombreTipoCelular),
                    DBHelper.MakeParam("@TipoEquipoID", SqlDbType.Int, 0, objetoTipoCelular.TipoEquipoID)

                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoCelular_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
    }
}