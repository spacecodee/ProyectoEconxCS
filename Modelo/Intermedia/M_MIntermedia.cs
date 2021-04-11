using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Intermedia
{
    public class M_MIntermedia
    {
        private int id;
        private String codigo;
        private String proveedor;
        private String producto;
        private String fecha;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
