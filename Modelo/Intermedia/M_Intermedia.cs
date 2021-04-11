using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Intermedia
{
    public class M_Intermedia
    {
        private int id;
        private String codigo;
        private int idProveedor;
        private int idProducto;
        private String fecha;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
