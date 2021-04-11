using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Producto
{
    public class M_Producto
    {
        private int id;
        private String codigo;
        private String nombre;
        private double precio;
        private int Stock;
        private int categoria;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public int Categoria { get => categoria; set => categoria = value; }
    }
}
