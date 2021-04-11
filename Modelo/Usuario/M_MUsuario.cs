using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Usuario
{
    public class M_MUsuario
    {
        private int id;
        private String dni;
        private String nombre;
        private String apellidos;
        private String telefono;
        private String roll;

        public int Id { get => id; set => id = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Roll { get => roll; set => roll = value; }
    }
}
