using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL.Producto
{
    public class S_Producto : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spMostrarProductos";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MProducto obj = new M_MProducto();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
                    obj.Precio = mSDR[3].ToString();
                    obj.Stock1 = mSDR[4].ToString();
                    obj.Categoria = mSDR[5].ToString();
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

            SQL = "spBuscarProductos";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@cod", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MProducto obj = new M_MProducto();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
                    obj.Precio = mSDR[3].ToString();
                    obj.Stock1 = mSDR[4].ToString();
                    obj.Categoria = mSDR[5].ToString();
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
            SQL = "spMostrarCategoriaP";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = System.Data.CommandType.StoredProcedure;

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
        public bool agregar(M_Producto mProducto)
        {
            Con = base.conexion();

            SQL = "spInsertarProductos";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", mProducto.Codigo);
                coman.Parameters.AddWithValue("@nom", mProducto.Nombre);
                coman.Parameters.AddWithValue("@prec", mProducto.Precio);
                coman.Parameters.AddWithValue("@stc", mProducto.Stock1);
                coman.Parameters.AddWithValue("@idC", mProducto.Categoria);

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

        public bool actualizar(M_Producto mProducto)
        {
            Con = base.conexion();
            SQL = "spActualizarProducto";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", mProducto.Codigo);
                coman.Parameters.AddWithValue("@nom", mProducto.Nombre);
                coman.Parameters.AddWithValue("@pre", mProducto.Precio);
                coman.Parameters.AddWithValue("@stc", mProducto.Stock1);
                coman.Parameters.AddWithValue("@idC", mProducto.Categoria);
                coman.Parameters.AddWithValue("@idP", mProducto.Id);

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
            SQL = "spEliminarProducto";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@idP", id);

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

        public M_Producto editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIdProducto";
            M_Producto mProducto = new M_Producto();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    mProducto.Id = int.Parse(mSDR[0].ToString());
                    mProducto.Codigo = mSDR[1].ToString();
                    mProducto.Nombre = mSDR[2].ToString();
                    mProducto.Precio = Double.Parse(mSDR[3].ToString());
                    mProducto.Stock1 = int.Parse(mSDR[4].ToString());
                    mProducto.Categoria = int.Parse(mSDR[5].ToString());
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

            return mProducto;
        }
    }
}
