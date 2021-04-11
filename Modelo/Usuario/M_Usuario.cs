using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Usuario
{
    public class M_Usuario
    {
        private int id;
        private String dni;
        private String pass;
        private String nombre;
        private String apellidos;
        private String telefono;
        private String mail;
        private String fecha;
        private int roll;

        public int Id { get => id; set => id = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Roll { get => roll; set => roll = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
