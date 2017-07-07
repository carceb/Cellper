﻿using Database.Classes;
using System.Data;
using System.Data.SqlClient;


namespace Admin
{
    public partial class Autocomplete
    {


        public static DataSet ObtenerClientes(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerClientes", dbParams);
        }
        public static DataSet ObtenerTipoCelular(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerTipoCelular", dbParams);
        }
        public static DataSet ObtenerModeloCelular(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerModeloCelular", dbParams);
        }
        public static DataSet ObtenerFallaCelular(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerFallaCelular", dbParams);
        }
    }
}