using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class Inventario
    {
        public static int ActualizarInventario(CInventario objetoInventario)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@InventarioID", SqlDbType.Int, 0, objetoInventario.InventarioID),
                    DBHelper.MakeParam("@NombreItem", SqlDbType.VarChar, 0, objetoInventario.NombreItem),
                    DBHelper.MakeParam("@CantidadItem", SqlDbType.Int, 0, objetoInventario.CantidadItem),
                    DBHelper.MakeParam("@CostoItem", SqlDbType.Money, 0, objetoInventario.CostoItem),
                    DBHelper.MakeParam("@SerialItem", SqlDbType.VarChar, 0, objetoInventario.SerialItem),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, objetoInventario.EmpresaSucursalID)

                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Inventario_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
    }
}