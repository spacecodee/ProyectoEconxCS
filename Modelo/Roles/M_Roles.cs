using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Roles
{
    public class M_Roles
    {
        private int id;
        private String codigo;
        private String roll;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Roll { get => roll; set => roll = value; }
    }
}
