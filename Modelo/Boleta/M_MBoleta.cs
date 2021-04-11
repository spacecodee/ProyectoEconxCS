using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEconx.Modelo.Boleta
{
    public class M_MBoleta
    {
        private int id;
        private String codigoIntermedia;
        private String nombrePoveedor;
        private String nombreProducto;
        private String dniUsuario;
        private String nombreUsuario;
        private String codigoBoleta;
        private String precioBoleta;
        private String cantidadBoleta;
        private String empresa;

        public int Id { get => id; set => id = value; }
        public string CodigoIntermedia { get => codigoIntermedia; set => codigoIntermedia = value; }
        public string NombrePoveedor { get => nombrePoveedor; set => nombrePoveedor = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string DniUsuario { get => dniUsuario; set => dniUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string CodigoBoleta { get => codigoBoleta; set => codigoBoleta = value; }
        public string PrecioBoleta { get => precioBoleta; set => precioBoleta = value; }
        public string CantidadBoleta { get => cantidadBoleta; set => cantidadBoleta = value; }
        public string Empresa { get => empresa; set => empresa = value; }
    }
}
