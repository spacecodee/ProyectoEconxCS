using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Producto
{
    public class M_MProducto
    {
        private int id;
        private String codigo;
        private String nombre;
        private String precio;
        private String Stock;
        private String categoria;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Stock1 { get => Stock; set => Stock = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
