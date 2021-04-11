using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL.Roles
{
    public class S_Roles : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spMostrarRoles";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_Roles obj = new M_Roles();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Roll = mSDR[2].ToString();
                    lista.Add(obj);
                }
                coman.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Message);
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

            return lista;
        }
        public List<Object> mostrarTabla(String buscar)
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spBuscarRoll";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@cod", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_Roles obj = new M_Roles();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Roll = mSDR[2].ToString();
                    lista.Add(obj);
                }
                coman.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Message);
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

            return lista;
        }
        public bool agregar(M_Roles obj)
        {
            Con = base.conexion();

            SQL = "spInsertarRoles";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", obj.Codigo);
                coman.Parameters.AddWithValue("@roll", obj.Roll);

                coman.ExecuteNonQuery();
                coman.Parameters.Clear();
                return true;
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
        public bool actualizar(M_Roles obj)
        {
            Con = base.conexion();
            SQL = "spActualizarRoles";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", obj.Codigo);
                coman.Parameters.AddWithValue("@roll", obj.Roll);
                coman.Parameters.AddWithValue("@idR", obj.Id);

                coman.ExecuteNonQuery();
                coman.Parameters.Clear();
                return true;
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
        public bool eliminar(int id)
        {
            Con = base.conexion();
            SQL = "spEliminarRoll";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@idT", id);

                coman.ExecuteNonQuery();
                coman.Parameters.Clear();
                return true;
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
        public M_Roles editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIDRoll";
            M_Roles obj = new M_Roles();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Roll = mSDR[2].ToString();
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

            return obj;
        }
    }
}
