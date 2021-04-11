using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Login;

namespace ProyectoEconx.SQL.S_Login
{
    public class S_Login : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public bool login(M_Login mLogin)
        {
            Con = base.conexion();
            SQL = "spLogin";
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@dn", mLogin.Dni);
                mSDR = coman.ExecuteReader();

                if (mSDR.Read())
                {
                    if (mLogin.Password.Equals(mSDR[2].ToString()))
                    {
                        mLogin.Id = int.Parse(mSDR[0].ToString());
                        mLogin.Dni = mSDR[1].ToString();
                        mLogin.Nombre = mSDR[3].ToString();
                        mLogin.Apellidos = mSDR[4].ToString();
                        mLogin.Telefono = mSDR[5].ToString();
                        mLogin.CorreoElectronico = mSDR[6].ToString();
                        mLogin.FechaNacimiento = mSDR[7].ToString();
                        mLogin.Roll = mSDR[8].ToString();
                        return true;
                    }
                }
                return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Message.ToString());
                return false;
            }
            finally
            {
                try
                {
                    Con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error " + ex.Message);
                }
            }
        }
    }
}
