
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

        [WebMethod]
        public bool AutenticaUser(string usuario, string password, ref int _resultado, ref string _mensaje)
        {
            DataSet result =  new DataSet();
            SqlParameter[] parametros = new SqlParameter[4];

            parametros[0] = SqlHelper.CreateParameter("@Usuario", usuario, SqlDbType.VarChar, ParameterDirection.Input,
                20);
            parametros[1] = SqlHelper.CreateParameter("@Contraseña", password, SqlDbType.VarChar, ParameterDirection.Input,
                20);
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
                return false;
            }

            if (_resultado != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
