using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Usuario;
using System.Windows.Forms;

namespace ProyectoEconx.SQL.Usuarios
{
    public class S_Usuarios : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spCargarTablaUsuarios";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MUsuario obj = new M_MUsuario();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Dni = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
                    obj.Apellidos = mSDR[3].ToString();
                    obj.Telefono = mSDR[4].ToString();
                    obj.Roll = mSDR[5].ToString();
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

            SQL = "spBuscarUsuario";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@dn", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MUsuario obj = new M_MUsuario();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Dni = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
                    obj.Apellidos = mSDR[3].ToString();
                    obj.Telefono = mSDR[4].ToString();
                    obj.Roll = mSDR[5].ToString();
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

        public DataTable comboRoles()
        {
            Con = base.conexion();
            DataTable tabla = new DataTable();
            SQL = "spSeleccionarRoll";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter data = new MySqlDataAdapter(coman);
                data.Fill(tabla);
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

            return tabla;
        }

        public bool insertarRegistros(M_Usuario mUsuario)
        {
            Con = base.conexion();
            SQL = "spInsertarUsuarios";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@dn", mUsuario.Dni);
                coman.Parameters.AddWithValue("@pass", mUsuario.Pass);
                coman.Parameters.AddWithValue("@nom", mUsuario.Nombre);
                coman.Parameters.AddWithValue("@ape", mUsuario.Apellidos);
                coman.Parameters.AddWithValue("@telefo", mUsuario.Telefono);
                coman.Parameters.AddWithValue("@correo", mUsuario.Mail);
                DateTime dt = Convert.ToDateTime(mUsuario.Fecha);
                coman.Parameters.AddWithValue("@fechaN", dt);
                coman.Parameters.AddWithValue("@roll", mUsuario.Roll);

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

        public bool actualizar(M_Usuario mUsuario)
        {
            Con = base.conexion();
            SQL = "spActualizarUsuarios";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@dn", mUsuario.Dni);
                coman.Parameters.AddWithValue("@nom", mUsuario.Nombre);
                coman.Parameters.AddWithValue("@ape", mUsuario.Apellidos);
                coman.Parameters.AddWithValue("@telef", mUsuario.Telefono);
                coman.Parameters.AddWithValue("@roll", mUsuario.Roll);
                coman.Parameters.AddWithValue("@idU", mUsuario.Id);

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
            SQL = "spEliminarUsuarios";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@idUs", id);

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

        public M_Usuario editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIDUsuario";
            M_Usuario mUsuario = new M_Usuario();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    mUsuario.Id = int.Parse(mSDR[0].ToString());
                    mUsuario.Dni = mSDR[1].ToString();
                    mUsuario.Nombre = mSDR[3].ToString();
                    mUsuario.Apellidos = mSDR[4].ToString();
                    mUsuario.Telefono = mSDR[5].ToString();
                    mUsuario.Roll = int.Parse(mSDR[8].ToString());
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

            return mUsuario;
        }
    }
}
