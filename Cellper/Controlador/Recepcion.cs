﻿using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cellper
{
    public partial class Recepcion
    {
        public static int InsertarRecepcion(CRecepcion objetoRecepcion, CCliente objetoCliente)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@ClienteID", SqlDbType.Int, 0, objetoRecepcion.ClienteID),
                    DBHelper.MakeParam("@ModeloCelularID", SqlDbType.Int, 0, objetoRecepcion.ModeloCelularID),
                    DBHelper.MakeParam("@TipoEquipoID", SqlDbType.Int, 0, objetoRecepcion.TipoEquipoID),
                    DBHelper.MakeParam("@IMEI", SqlDbType.VarChar, 0, objetoRecepcion.Imei),
                    DBHelper.MakeParam("@FallaCelularID", SqlDbType.Int, 0, objetoRecepcion.FallaCelularID),
                    DBHelper.MakeParam("@Observaciones", SqlDbType.VarChar, 0, objetoRecepcion.Observaciones),
                    DBHelper.MakeParam("@TecnicoID", SqlDbType.Int, 0, objetoRecepcion.TecnicoID),
                    DBHelper.MakeParam("@CedulaCliente", SqlDbType.Int, 0, objetoCliente.CedulaCliente),
                    DBHelper.MakeParam("@NombreCliente", SqlDbType.VarChar, 0, objetoCliente.NombreCliente),
                    DBHelper.MakeParam("@TelefonoCliente", SqlDbType.VarChar, 0, objetoCliente.TelefonoCliente),
                    DBHelper.MakeParam("@DireccionCliente", SqlDbType.VarChar, 0, objetoCliente.DireccionCliente),
                    DBHelper.MakeParam("@EstatusEquipoID", SqlDbType.Int, 0, objetoRecepcion.EstatusEquipoID)
                };

                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Recepcion_Insertar", dbParams));
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        public static DataSet ObtenerServiciosCliente(int cedulaCliente, int estatusEquipo)
        {
            if(estatusEquipo > 0 )
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                        DBHelper.MakeParam("@CedulaCliente", SqlDbType.Int, 0, cedulaCliente),
                        DBHelper.MakeParam("@EstatusEquipoID", SqlDbType.Int, 0, estatusEquipo),
                    };
                return DBHelper.ExecuteDataSet("usp_Recepcion_ObtenerEquipoCliente", dbParams);
            }
            else
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                        DBHelper.MakeParam("@CedulaCliente", SqlDbType.Int, 0, cedulaCliente)
                    };
                return DBHelper.ExecuteDataSet("usp_Recepcion_ObtenerEquiposCliente", dbParams);
            }
        }
        public static int EliminarRecepcion(int recepcionID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@RecepcionEquipoID", SqlDbType.Int, 0, recepcionID),
                };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Recepcion_EliminarRecepcion", dbParams));
        }

    }
}