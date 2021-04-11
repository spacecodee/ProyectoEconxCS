using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Proveedor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL.Proveedor
{
    public class S_Proveedor : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spMostrarProveedores";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_Proveedor obj = new M_Proveedor();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Dni = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
                    obj.Apellidos = mSDR[3].ToString();
                    obj.CorreoElectronico = mSDR[4].ToString();
                    obj.Telefono = mSDR[5].ToString();
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

            SQL = "spBuscarProveedores";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@dn", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_Proveedor obj = new M_Proveedor();
                    obj.Id = int.Parse(mSDR[0].ToString());
                    obj.Dni = mSDR[1].ToString();
                    obj.Nombre = mSDR[2].ToString();
                    obj.Apellidos = mSDR[3].ToString();
                    obj.CorreoElectronico = mSDR[4].ToString();
                    obj.Telefono = mSDR[5].ToString();
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
        public DataTable comboCategoria()
        {
            Con = base.conexion();
            DataTable tabla = new DataTable();
            SQL = "spMostrarCategoriaP";

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
        public bool agregar(M_Proveedor mProveedor)
        {
            Con = base.conexion();

            SQL = "spInsertarProveedores";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@dn", mProveedor.Dni);
                coman.Parameters.AddWithValue("@nom", mProveedor.Nombre);
                coman.Parameters.AddWithValue("@ape", mProveedor.Apellidos);
                coman.Parameters.AddWithValue("@mail", mProveedor.CorreoElectronico);
                coman.Parameters.AddWithValue("@tele", mProveedor.Telefono);

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
        public bool actualizar(M_Proveedor mProveedor)
        {
            Con = base.conexion();
            SQL = "spActualizarProveedor";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@dn", mProveedor.Dni);
                coman.Parameters.AddWithValue("@nom", mProveedor.Nombre);
                coman.Parameters.AddWithValue("@ape", mProveedor.Apellidos);
                coman.Parameters.AddWithValue("@mail", mProveedor.CorreoElectronico);
                coman.Parameters.AddWithValue("@tele", mProveedor.Telefono);
                coman.Parameters.AddWithValue("@idP", mProveedor.Id);

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
            SQL = "spEliminarProveedor";

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
        public M_Proveedor editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIdProveedor";
            M_Proveedor mProveedor = new M_Proveedor();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    mProveedor.Id = int.Parse(mSDR[0].ToString());
                    mProveedor.Dni = mSDR[1].ToString();
                    mProveedor.Nombre = mSDR[2].ToString();
                    mProveedor.Apellidos = mSDR[3].ToString();
                    mProveedor.CorreoElectronico = mSDR[4].ToString();
                    mProveedor.Telefono = mSDR[5].ToString();
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

            return mProveedor;
        }
    }
}
