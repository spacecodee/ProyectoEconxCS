using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.CategoriaProd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL.CategoriaProd
{
    public class S_CategoriaP : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spMostrarTablaCategoria";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_CategoriaProd obj = new M_CategoriaProd();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
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

            SQL = "spBuscarCategoriaProductos";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@cod", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_CategoriaProd obj = new M_CategoriaProd();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Codigo = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
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
        public bool insertarRegistros(M_CategoriaProd mCategoriaP)
        {
            Con = base.conexion();

            SQL = "spInsertarCategoriaP";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                
                coman.Parameters.AddWithValue("@cod", mCategoriaP.Codigo);
                coman.Parameters.AddWithValue("@cate", mCategoriaP.Nombre);

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
        public bool actualizar(M_CategoriaProd mCategoriaP)
        {
            Con = base.conexion();
            SQL = "spActualizarCategorias";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@cod", mCategoriaP.Codigo);
                coman.Parameters.AddWithValue("@cate", mCategoriaP.Nombre);
                coman.Parameters.AddWithValue("@id", mCategoriaP.Id);

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
            SQL = "spEliminarCategoriaProd";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@id", id);

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
        public M_CategoriaProd editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIdCategoriaP";
            M_CategoriaProd mCategoriaP = new M_CategoriaProd();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    mCategoriaP.Id = int.Parse(mSDR[0].ToString());
                    mCategoriaP.Codigo = mSDR[1].ToString();
                    mCategoriaP.Nombre = mSDR[2].ToString();
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

            return mCategoriaP;
        }
    }
}
