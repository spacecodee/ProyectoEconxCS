using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL.Menu
{
    public class S_Menu : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;
        int resultado;
        public int totalEmpleados()
        {
            Con = base.conexion();
            SQL = "spSeleccionarTotalEmpleados";
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    resultado = int.Parse(mSDR[0].ToString());
                }
                coman.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
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

            return resultado;
        }
        public int totalProveedores()
        {
            Con = base.conexion();
            SQL = "spSeleccionarTotalProveedores";
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    resultado = int.Parse(mSDR[0].ToString());
                }
                coman.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
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

            return resultado;
        }
        public int totalProductos()
        {
            Con = base.conexion();
            SQL = "spSeleccionarTotalProductos";
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    resultado = int.Parse(mSDR[0].ToString());
                }
                coman.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
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

            return resultado;
        }
    }
}
