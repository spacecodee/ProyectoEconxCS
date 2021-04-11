using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Boleta
{
    public class M_Boleta
    {
        private int id;
        private int idTrae;
        private int usuarioComprador;
        private String codigo;
        private double precio;
        private int cantidad;
        private String empresa;

        public int Id { get => id; set => id = value; }
        public int IdTrae { get => idTrae; set => idTrae = value; }
        public int UsuarioComprador { get => usuarioComprador; set => usuarioComprador = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Empresa { get => empresa; set => empresa = value; }
    }
}
