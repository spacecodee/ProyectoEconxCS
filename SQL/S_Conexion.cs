using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL
{
    public class S_Conexion
    {
        private String Servidor = "localhost";
        private String bd = "econx";
        private String usuario = "scodee";
        private String password = "spacecodee";

        public MySqlConnection conexion()
        {
            String cadenaConexion = "Database=" + bd + "; Data Source=" + Servidor
                + "; User ID=" + usuario + "; Password=" + password + "";

            try
            {
                MySqlConnection Con = new MySqlConnection(cadenaConexion);
                return Con;
            }
            catch (MySqlException mSE)
            {
                Console.WriteLine("Error" + mSE.Message);
                return null;
            }
        }
    }
}
