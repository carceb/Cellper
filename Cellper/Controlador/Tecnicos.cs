using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class Tecnicos
    {
        public static int InserTecnico(CTecnicos objetoTecnico)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TecnicoID", SqlDbType.Int, 0, objetoTecnico.TecnicoID),
                    DBHelper.MakeParam("@NombreTecnico", SqlDbType.VarChar, 0, objetoTecnico.NombreTecnico),
                    DBHelper.MakeParam("@CedulaTecnico", SqlDbType.Decimal, 0, objetoTecnico.CedulaTecnico)

                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Tecnicos_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
    }
}