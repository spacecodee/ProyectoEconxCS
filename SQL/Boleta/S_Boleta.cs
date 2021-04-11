using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using ProyectoEconx.Modelo.Boleta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.SQL
{
    public class S_Boleta : S_Conexion
    {
        private MySqlDataReader mSDR = null;
        private MySqlConnection Con = null;
        private MySqlCommand coman;
        private String SQL;
        M_MBoleta mMBoleta = new M_MBoleta();

        public List<Object> mostrarTabla()
        {
            List<object> lista = new List<object>();
            Con = base.conexion();

            SQL = "spMostrarBoleta";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MBoleta mMBoleta = new M_MBoleta();
                    mMBoleta.Id = int.Parse(mSDR[0].ToString());
                    mMBoleta.CodigoIntermedia = mSDR[1].ToString();
                    mMBoleta.NombrePoveedor = mSDR[2].ToString();
                    mMBoleta.NombreProducto = mSDR[3].ToString();
                    mMBoleta.DniUsuario = mSDR[4].ToString();
                    mMBoleta.NombreUsuario = mSDR[5].ToString();
                    mMBoleta.CodigoBoleta = mSDR[6].ToString();
                    mMBoleta.PrecioBoleta = mSDR[7].ToString();
                    mMBoleta.CantidadBoleta = mSDR[8].ToString();
                    mMBoleta.Empresa = mSDR[9].ToString();
                    lista.Add(mMBoleta);
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

            SQL = "spBuscarBoleta";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@cod", buscar);
                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    M_MBoleta mMBoleta = new M_MBoleta();
                    mMBoleta.Id = int.Parse(mSDR[0].ToString());
                    mMBoleta.CodigoIntermedia = mSDR[1].ToString();
                    mMBoleta.NombrePoveedor = mSDR[2].ToString();
                    mMBoleta.NombreProducto = mSDR[3].ToString();
                    mMBoleta.DniUsuario = mSDR[4].ToString();
                    mMBoleta.NombreUsuario = mSDR[5].ToString();
                    mMBoleta.CodigoBoleta = mSDR[6].ToString();
                    mMBoleta.PrecioBoleta = mSDR[7].ToString();
                    mMBoleta.CantidadBoleta = mSDR[8].ToString();
                    mMBoleta.Empresa = mSDR[9].ToString();
                    lista.Add(mMBoleta);
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
        public DataTable comboInter()
        {
            Con = base.conexion();
            DataTable tabla = new DataTable();
            SQL = "spComboTraeProd";

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
        public DataTable comboComp()
        {
            Con = base.conexion();
            DataTable tabla = new DataTable();
            SQL = "spComboComprador";

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
        public bool agregar(M_Boleta mBoleta)
        {
            Con = base.conexion();

            SQL = "spInsertarBoleta";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@idT", mBoleta.IdTrae);
                coman.Parameters.AddWithValue("@idC", mBoleta.UsuarioComprador);
                coman.Parameters.AddWithValue("@cod", mBoleta.Codigo);
                coman.Parameters.AddWithValue("@prec", mBoleta.Precio);
                coman.Parameters.AddWithValue("@can", mBoleta.Cantidad);
                coman.Parameters.AddWithValue("@emp", mBoleta.Empresa);

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
        public bool actualizar(M_Boleta mBoleta)
        {
            Con = base.conexion();
            SQL = "spActualizarBoleta";

            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;

                coman.Parameters.AddWithValue("@idT", mBoleta.IdTrae);
                coman.Parameters.AddWithValue("@idC", mBoleta.UsuarioComprador);
                coman.Parameters.AddWithValue("@cod", mBoleta.Codigo);
                coman.Parameters.AddWithValue("@pre", mBoleta.Precio);
                coman.Parameters.AddWithValue("@can", mBoleta.Cantidad);
                coman.Parameters.AddWithValue("@emp", mBoleta.Empresa);
                coman.Parameters.AddWithValue("@id", mBoleta.Id);

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
            SQL = "spEliminarBoleta";

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
        public M_Boleta editar(int id)
        {
            Con = base.conexion();
            SQL = "spListarIdBoleta";
            M_Boleta mBoleta = new M_Boleta();
            try
            {
                Con.Open();
                coman = new MySqlCommand(SQL, Con);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@i", id);

                mSDR = coman.ExecuteReader();

                while (mSDR.Read())
                {
                    mBoleta.Id = int.Parse(mSDR[0].ToString());
                    mBoleta.IdTrae = int.Parse(mSDR[1].ToString());
                    mBoleta.UsuarioComprador = int.Parse(mSDR[2].ToString());
                    mBoleta.Codigo = mSDR[3].ToString();
                    mBoleta.Precio = Double.Parse(mSDR[4].ToString());
                    mBoleta.Cantidad = int.Parse(mSDR[5].ToString());
                    mBoleta.Empresa = mSDR[6].ToString();
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

            return mBoleta;
        }
        public void crearPDF(String dni, String fecha, String nombre)
        {
            Table tabla;
            Con = base.conexion();
            SQL = "spBuscarParaBoleta";
            Con.Open();

            PdfWriter pdW = new PdfWriter("Reporte.pdf");
            PdfDocument pdf = new PdfDocument(pdW);
            PageSize tama = new PageSize(729, 612);
            Document documento = new Document(pdf, tama);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA);

            String[] columnas = {
                "Código", "Proveedor", "Producto", "Comprador", "Precio de compra",
                "Cantidad", "Empresa", "Fecha de Compra"
                };
            float[] taman = {
                2, 4, 4, 4, 2, 2, 4, 4
                };
            tabla = new Table(UnitValue.CreatePercentArray(taman));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (String columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).
                    SetFont(fontColumnas)));
            }

            coman = new MySqlCommand(SQL, Con);
            coman.CommandType = CommandType.StoredProcedure;
            coman.Parameters.AddWithValue("@dn", dni);
            DateTime dt = Convert.ToDateTime(fecha);
            coman.Parameters.AddWithValue("@fe", dt);

            mSDR = coman.ExecuteReader();

            while (mSDR.Read())
            {
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[0].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[1].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[2].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[3].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[4].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[5].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[6].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[7].ToString()).SetFont(fontContenido)));
            }
            Con.Close();
            documento.Add(tabla);
            documento.Close();

            var logo = new Image(ImageDataFactory.Create(
                "C:/Users/devro/source/repos/ProyectoEconx/img/logoeconx.png")).
                SetWidth(50);
            var pLogo = new Paragraph("").Add(logo);
            var titulos = new Paragraph("Reporte de boleta");
            titulos.SetTextAlignment(TextAlignment.CENTER);
            titulos.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fechaHecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);
            fechaHecha.SetFontSize(12);

            PdfDocument pdfDoc = new PdfDocument(new PdfReader("Reporte.pdf"), new
                PdfWriter(nombre + ".pdf"));
            Document doc = new Document(pdfDoc);

            int numeros = pdfDoc.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDoc.GetPage(i);
                float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
                doc.ShowTextAligned(pLogo, 40, y, i, TextAlignment.CENTER,
                    VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulos, 150, y - 15, i, TextAlignment.CENTER,
                    VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fechaHecha, 520, y - 15, i, TextAlignment.CENTER,
                                    VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(new Paragraph(String.Format("Página {0} de {1}",
                    i, numeros)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2,
                    pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30,
                    i, TextAlignment.CENTER,
                    VerticalAlignment.TOP, 0);
            }
            doc.Close();
        }
        public void crearPDF(String nombre)
        {
            Table tabla;
            Con = base.conexion();
            SQL = "spFacturaBoleta";
            Con.Open();

            PdfWriter pdW = new PdfWriter("Reporte.pdf");
            PdfDocument pdf = new PdfDocument(pdW);
            PageSize tama = new PageSize(729, 612);
            Document documento = new Document(pdf, tama);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(
                StandardFonts.HELVETICA);

            String[] columnas = {
                "Código", "Proveedor", "Producto", "Comprador", "Precio de compra",
                "Cantidad", "Empresa", "Fecha de Compra"
                };
            float[] taman = {
                2, 4, 4, 4, 2, 2, 4, 4
                };
            tabla = new Table(UnitValue.CreatePercentArray(taman));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (String columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).
                    SetFont(fontColumnas)));
            }

            coman = new MySqlCommand(SQL, Con);
            coman.CommandType = CommandType.StoredProcedure;

            mSDR = coman.ExecuteReader();

            while (mSDR.Read())
            {
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[0].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[1].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[2].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[3].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[4].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[5].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[6].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(
                    new Paragraph(mSDR[7].ToString()).SetFont(fontContenido)));
            }
            Con.Close();
            documento.Add(tabla);
            documento.Close();

            var logo = new Image(ImageDataFactory.Create(
                "C:/Users/devro/source/repos/ProyectoEconx/img/logoeconx.png")).
                SetWidth(50);
            var pLogo = new Paragraph("").Add(logo);
            var titulos = new Paragraph("Reporte de boleta");
            titulos.SetTextAlignment(TextAlignment.CENTER);
            titulos.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fechaHecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);
            fechaHecha.SetFontSize(12);

            PdfDocument pdfDoc = new PdfDocument(new PdfReader("Reporte.pdf"), new
                PdfWriter(nombre + ".pdf"));
            Document doc = new Document(pdfDoc);

            int numeros = pdfDoc.GetNumberOfPages();

            for (int i = 1; i <= numeros; i++)
            {
                PdfPage pagina = pdfDoc.GetPage(i);
                float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
                doc.ShowTextAligned(pLogo, 40, y, i, TextAlignment.CENTER,
                    VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulos, 150, y - 15, i, TextAlignment.CENTER,
                    VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fechaHecha, 520, y - 15, i, TextAlignment.CENTER,
                                    VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(new Paragraph(String.Format("Página {0} de {1}",
                    i, numeros)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2,
                    pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30,
                    i, TextAlignment.CENTER,
                    VerticalAlignment.TOP, 0);
            }
            doc.Close();
        }
    }
}