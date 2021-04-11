using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Intermedia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL.Intermedia
{
    public class S_Intermedia : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spMostrarTablaIntermedia";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MIntermedia obj = new M_MIntermedia();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Proveedor = mSDR[2].ToString();
                    obj.Producto = mSDR[3].ToString();
                    obj.Fecha = mSDR[4].ToString();
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

            SQL = "spBuscarTablaIntermedia";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@cod", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MIntermedia obj = new M_MIntermedia();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Proveedor = mSDR[2].ToString();
                    obj.Producto = mSDR[3].ToString();
                    obj.Fecha = mSDR[4].ToString();
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
        public DataTable comboProvee()
        {
            Con = base.conexion();
            DataTable tabla = new DataTable();
            SQL = "spComboProveedor";

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
        public DataTable comboProduc()
        {
            Con = base.conexion();
            DataTable tabla = new DataTable();
            SQL = "spComboProductos";

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
        public bool agregar(M_Intermedia mIntermedia)
        {
            Con = base.conexion();

            SQL = "spInsertarTablaInermedia";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", mIntermedia.Codigo);
                coman.Parameters.AddWithValue("@idP", mIntermedia.IdProveedor);
                coman.Parameters.AddWithValue("@idPro", mIntermedia.IdProducto);
                DateTime dt = Convert.ToDateTime(mIntermedia.Fecha);
                coman.Parameters.AddWithValue("@fech", dt);

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
        public bool actualizar(M_Intermedia mIntermedia)
        {
            Con = base.conexion();
            SQL = "spActualizarTablaIntermedia";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", mIntermedia.Codigo);
                coman.Parameters.AddWithValue("@idP", mIntermedia.IdProveedor);
                coman.Parameters.AddWithValue("@idPro", mIntermedia.IdProducto);
                DateTime dt = Convert.ToDateTime(mIntermedia.Fecha);
                coman.Parameters.AddWithValue("@fech", dt);
                coman.Parameters.AddWithValue("@idTrae", mIntermedia.Id);

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
            SQL = "spEliminarTablaIntermedia";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@idTaba", id);

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
        public M_Intermedia editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIdIntermedia";
            M_Intermedia mIntermedia = new M_Intermedia();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    mIntermedia.Id = int.Parse(mSDR[0].ToString());
                    mIntermedia.Codigo = mSDR[1].ToString();
                    mIntermedia.IdProveedor = int.Parse(mSDR[2].ToString());
                    mIntermedia.IdProducto = int.Parse(mSDR[3].ToString());
                    mIntermedia.Fecha = mSDR[4].ToString();
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

            return mIntermedia;
        }
    }
}
