using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class ReparacionEquipo
    {
        public static SqlDataReader ObtenerDatosEquipo(int recepcionEquipoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@RecepcionEquipoID", SqlDbType.Int, 0, recepcionEquipoID)
                };
             return DBHelper.ExecuteDataReader("usp_AsignarEstatus_ObtenerDatosEquipo", dbParams);
        }
        public static int InsertarReparacionEquipo(CReparacionEquipo objetoReparacionEquipo)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@ReparacionEquipoID", SqlDbType.Int, 0, objetoReparacionEquipo.ReparacionEquipoID),
                    DBHelper.MakeParam("@RecepcionEquipoID", SqlDbType.Int, 0, objetoReparacionEquipo.RecepcionEquipoID),
                    DBHelper.MakeParam("@InventarioID", SqlDbType.Int, 0, objetoReparacionEquipo.InventarioID),
                    DBHelper.MakeParam("@CantidadItem", SqlDbType.Int, 0, objetoReparacionEquipo.CantidadItem),
                    DBHelper.MakeParam("@TecnicoID", SqlDbType.Int, 0, objetoReparacionEquipo.TecnicoID),
                    DBHelper.MakeParam("@EstatusEquipoID", SqlDbType.Int, 0, objetoReparacionEquipo.EstatusEquipoID),
                    DBHelper.MakeParam("@ObservacionReparacionEquipo", SqlDbType.VarChar, 0, objetoReparacionEquipo.ObservacionReparacionEquipo)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_ReparacionEquipo_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        public static DataSet ObtenerEquipoReparado(int RecepcionEquipoID)
        {

                SqlParameter[] dbParams = new SqlParameter[]
                    {
                        DBHelper.MakeParam("@RecepcionEquipoID", SqlDbType.Int, 0, RecepcionEquipoID)

                    };
                return DBHelper.ExecuteDataSet("usp_ReparacionEquipo_ObtenerEquipos", dbParams);
        }
        public static int EliminarMaterialReparacion(int reparacionEquipoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@ReparacionEquipoID", SqlDbType.Int, 0, reparacionEquipoID),
                };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_ReparacionEquipo_EliminarMaterialReparacion", dbParams));
        }
    }
}