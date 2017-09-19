using Database.Classes;
using Seguridad.Clases;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Seguridad
{
    public partial class SeguridadUsuario
    {
        public static int InsertarUsuario(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoSeguridad.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, objetoSeguridad.LoginUsuario),
                    DBHelper.MakeParam("@ClaveUsuario", SqlDbType.VarChar, 0, objetoSeguridad.ClaveUsuario),
                    DBHelper.MakeParam("@NombreCompleto", SqlDbType.VarChar, 0, objetoSeguridad.NombreCompleto),
                    DBHelper.MakeParam("@DescripcionUsuario", SqlDbType.VarChar, 0, objetoSeguridad.DescripcionUsuario),
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                    DBHelper.MakeParam("@UsuarioTecnico", SqlDbType.Bit, 0, objetoSeguridad.UsuarioTecnico),
                    DBHelper.MakeParam("@EstatusUsuario", SqlDbType.VarChar, 0,objetoSeguridad.EstatusUsuario),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,objetoSeguridad.EmpresaSucursalID)
            };
            if (objetoSeguridad.SeguridadUsuarioDatosID == 0)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadUsuario_Insertar]", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadUsuario_Actualizar]", dbParams));
            }
        }
        public static DataSet ObtenerLogin(string loginDeUsuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, loginDeUsuario),
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadUsuario_ObtenerLogin", dbParams);
        }
        public static SqlDataReader ObtenerEmpresas(int usuarioID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, usuarioID),
                };

            return DBHelper.ExecuteDataReader("usp_Login_ObtenerEmpresas", dbParams);
        }
        public static SqlDataReader ObtenerLogoEmpresa(int empresaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, empresaID),
                };

            return DBHelper.ExecuteDataReader("usp_Login_ObtenerLogoEmpresa", dbParams);
        }
        public static int ObtenerCodigoEmpresa(int codigoSucursal)
        {
            int codigoEmpresa = 0;
            SqlDataReader dr;
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal),
                };

            dr = DBHelper.ExecuteDataReader("usp_Login_ObtenerCodigoEmpresa", dbParams);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    codigoEmpresa = dr.GetInt32(1);
                }
            }
            dr.Close();
            return codigoEmpresa;
        }
    }
}