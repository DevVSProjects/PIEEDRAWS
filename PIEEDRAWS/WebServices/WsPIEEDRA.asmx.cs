
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using Conexion;

namespace PIEEDRAWS.WebServices
{
    /// <summary>
    /// Summary description for WsPIEEDRA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsPIEEDRA : System.Web.Services.WebService
    {
        /// <summary>
        /// Web Method para autenticar usuario en la aplicación
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <param name="_resultado"></param>
        /// <param name="_mensaje"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet AutenticaUser(string usuario, string password, ref int _resultado, ref string _mensaje)
        {
            DataSet result =  new DataSet();
            SqlParameter[] parametros = new SqlParameter[4];

            parametros[0] = SqlHelper.CreateParameter("@Usuario", usuario, SqlDbType.VarChar, ParameterDirection.Input,
                20);
            parametros[1] = SqlHelper.CreateParameter("@Contraseña", password, SqlDbType.VarChar, ParameterDirection.Input,
                300);
            parametros[2] = SqlHelper.CreateParameter("@Resultado", SqlDbType.Int, ParameterDirection.Output,
                8);
            parametros[3] = SqlHelper.CreateParameter("@Mensaje", SqlDbType.VarChar, ParameterDirection.Output,
                100);

            SqlConnection con = new SqlConnection();
            string strincon = System.Configuration.ConfigurationManager.ConnectionStrings["PIEEDRAConnectionString"].ConnectionString;
            con.ConnectionString = strincon;
            SqlCommand cmd = null;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    result = SqlHelperPlus.ExecuteDatasetPlus(con, CommandType.StoredProcedure, "ValidaUsuario",
                        parametros);
                    _resultado = Convert.ToInt32(parametros[2].Value);
                    _mensaje = parametros[3].Value.ToString();

                }
            }
            catch (Exception e)
            {
                _resultado = 0;
                _mensaje = "Error al procesar la solicitud, favor de contactar al Administrador";
            }
                return result;
        }


        /// <summary>
        /// Web Method para registrar un usuario y para asignarle un token
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="ciudad"></param>
        /// <param name="genero"></param>
        /// <param name="atencion"></param>
        /// <param name="ambito"></param>
        /// <param name="_resultado"></param>
        /// <param name="_mensaje"></param>
        /// <returns></returns>
        [WebMethod]
        public bool RegistraUser(string usuario, string password, string email, string nombre, string apellidos, string ciudad,
                                    string genero, string atencion, string ambito, ref int _resultado, ref string _mensaje)
        {
            bool resReg = false;
            DataSet result = new DataSet();
            SqlParameter[] parametros = new SqlParameter[11];

            parametros[0] = SqlHelper.CreateParameter("@Usuario", usuario, SqlDbType.VarChar, ParameterDirection.Input,
                20);
            parametros[1] = SqlHelper.CreateParameter("@Contraseña", password, SqlDbType.VarChar, ParameterDirection.Input,
                300);
            //parametros[2] = SqlHelper.CreateParameter("@ConfContraseña", conpassword, SqlDbType.VarChar, ParameterDirection.Input,
            //20);
            parametros[2] = SqlHelper.CreateParameter("@EMail", email, SqlDbType.VarChar, ParameterDirection.Input,
                50);
            parametros[3] = SqlHelper.CreateParameter("@Nombre", nombre, SqlDbType.VarChar, ParameterDirection.Input,
                80);
            parametros[4] = SqlHelper.CreateParameter("@Apellidos", apellidos, SqlDbType.VarChar, ParameterDirection.Input,
                80);
            parametros[5] = SqlHelper.CreateParameter("@Ciudad", ciudad, SqlDbType.VarChar, ParameterDirection.Input,
                100);
            parametros[6] = SqlHelper.CreateParameter("@Genero", genero, SqlDbType.VarChar, ParameterDirection.Input,
                10);
            parametros[7] = SqlHelper.CreateParameter("@AtnUsuario", atencion, SqlDbType.VarChar, ParameterDirection.Input,
                10);
            parametros[8] = SqlHelper.CreateParameter("@Ambito", ambito, SqlDbType.VarChar, ParameterDirection.Input,
                50);
            parametros[9] = SqlHelper.CreateParameter("@Resultado", SqlDbType.Int, ParameterDirection.Output,
                8);
            parametros[10] = SqlHelper.CreateParameter("@Mensaje", SqlDbType.VarChar, ParameterDirection.Output,
                100);

            SqlConnection con = new SqlConnection();
            string strincon = System.Configuration.ConfigurationManager.ConnectionStrings["PIEEDRAConnectionString"].ConnectionString;
            con.ConnectionString = strincon;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    result = SqlHelperPlus.ExecuteDatasetPlus(con, CommandType.StoredProcedure, "RegistraUsuario",
                        parametros);
                    _resultado = Convert.ToInt32(parametros[9].Value);
                    _mensaje = parametros[10].Value.ToString();

                }
            }
            catch (Exception e)
            {
                _resultado = 0;
                _mensaje = "Error al procesar la solicitud, favor de contactar al Administrador";
            }
            if (_resultado == 1)
            {
                resReg = true;
            }
            else if (_resultado == 0)
            {
                resReg = false;
            }
            return resReg;
        }

        [WebMethod]
        public bool RegistraHistorico(string usuario, string usuariored, string ip, string estacion, string accion, ref int _resultado, ref string _mensaje)
        {
            bool resRegH = false;
            DataSet result = new DataSet();
            SqlParameter[] parametros = new SqlParameter[7];

            parametros[0] = SqlHelper.CreateParameter("@Usuario", usuario, SqlDbType.VarChar, ParameterDirection.Input,
                20);
            parametros[1] = SqlHelper.CreateParameter("@UsuarioRed", usuariored, SqlDbType.VarChar, ParameterDirection.Input,
                300);
            parametros[2] = SqlHelper.CreateParameter("@Ip", ip, SqlDbType.VarChar, ParameterDirection.Input,
                50);
            parametros[3] = SqlHelper.CreateParameter("@Estacion", estacion, SqlDbType.VarChar, ParameterDirection.Input,
                80);
            parametros[4] = SqlHelper.CreateParameter("@Accion", accion, SqlDbType.VarChar, ParameterDirection.Input,
                80);
            parametros[5] = SqlHelper.CreateParameter("@Resultado", SqlDbType.Int, ParameterDirection.Output,
                8);
            parametros[6] = SqlHelper.CreateParameter("@Mensaje", SqlDbType.VarChar, ParameterDirection.Output,
                100);

            SqlConnection con = new SqlConnection();
            string strincon = System.Configuration.ConfigurationManager.ConnectionStrings["PIEEDRAConnectionString"].ConnectionString;
            con.ConnectionString = strincon;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    result = SqlHelperPlus.ExecuteDatasetPlus(con, CommandType.StoredProcedure, "RegistraHistoricoIngreso",
                        parametros);
                    _resultado = Convert.ToInt32(parametros[5].Value);
                    _mensaje = parametros[6].Value.ToString();

                }
            }
            catch (Exception e)
            {
                _resultado = 0;
                _mensaje = "Error al procesar la solicitud, favor de contactar al Administrador";
            }
            if (_resultado == 1)
            {
                resRegH = true;
            }
            else if (_resultado == 0)
            {
                resRegH = false;
            }
            return resRegH;
        }

        [WebMethod]
        public bool AutenticaToken(string usuario, string token, string bandera, string modulo, ref int _resultado, ref string _mensaje)
        {
            bool res = false;
            DataSet result =  new DataSet();
            SqlParameter[] parametros = new SqlParameter[6];

            parametros[0] = SqlHelper.CreateParameter("@Usuario", usuario, SqlDbType.VarChar, ParameterDirection.Input,
                20);
            parametros[1] = SqlHelper.CreateParameter("@Token", token, SqlDbType.VarChar, ParameterDirection.Input,
                300);
            parametros[2] = SqlHelper.CreateParameter("@Bandera", bandera, SqlDbType.VarChar, ParameterDirection.Input,
                300);
            parametros[3] = SqlHelper.CreateParameter("@Modulo", modulo, SqlDbType.VarChar, ParameterDirection.Input,
                300);          
            parametros[4] = SqlHelper.CreateParameter("@Resultado", SqlDbType.Int, ParameterDirection.Output,
                8);
            parametros[5] = SqlHelper.CreateParameter("@Mensaje", SqlDbType.VarChar, ParameterDirection.Output,
                100);

            SqlConnection con = new SqlConnection();
            string strincon = System.Configuration.ConfigurationManager.ConnectionStrings["PIEEDRAConnectionString"].ConnectionString;
            con.ConnectionString = strincon;
            SqlCommand cmd = null;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    result = SqlHelperPlus.ExecuteDatasetPlus(con, CommandType.StoredProcedure, "ValidaToken",
                        parametros);
                    _resultado = Convert.ToInt32(parametros[4].Value);
                    _mensaje = parametros[5].Value.ToString();

                }
            }

            catch (Exception e)
            {
                _resultado = 0;
                _mensaje = "Error al procesar la solicitud, favor de contactar al Administrador";
            }

            if (_resultado == 1)
            {
                res = true;
            }
            else if (_resultado == 0)
            {
                res = false;
            }
            return res;
        }

        [WebMethod]
        public bool CambContr(int accion, string email, string usuario, string password, ref int _resultado, ref string _mensaje)
        {
            bool res = false;
            DataSet result = new DataSet();
            SqlParameter[] parametros = new SqlParameter[6];

            parametros[0] = SqlHelper.CreateParameter("@Accion", accion, SqlDbType.Int, ParameterDirection.Input,
                8);
            parametros[1] = SqlHelper.CreateParameter("@Email", email, SqlDbType.VarChar, ParameterDirection.Input,
                40);
            parametros[2] = SqlHelper.CreateParameter("@Usuario", usuario, SqlDbType.VarChar, ParameterDirection.Input,
                30);
            parametros[3] = SqlHelper.CreateParameter("@Contrasena", password, SqlDbType.VarChar, ParameterDirection.Input,
                300);
            parametros[4] = SqlHelper.CreateParameter("@Resultado", SqlDbType.Int, ParameterDirection.Output,
                8);
            parametros[5] = SqlHelper.CreateParameter("@Mensaje", SqlDbType.VarChar, ParameterDirection.Output,
                100);

            SqlConnection con = new SqlConnection();
            string strincon = System.Configuration.ConfigurationManager.ConnectionStrings["PIEEDRAConnectionString"].ConnectionString;
            con.ConnectionString = strincon;
            SqlCommand cmd = null;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    result = SqlHelperPlus.ExecuteDatasetPlus(con, CommandType.StoredProcedure, "CombiaPass",
                        parametros);
                    _resultado = Convert.ToInt32(parametros[4].Value);
                    _mensaje = parametros[5].Value.ToString();

                }
            }
            catch (Exception e)
            {
                _resultado = 0;
                _mensaje = "Error al procesar la solicitud, favor de contactar al Administrador";
            }

            if (_resultado == 1)
            {
                res = true;
            }
            else if (_resultado == 0)
            {
                res = false;
            }
            return res;
        }
    }
}

