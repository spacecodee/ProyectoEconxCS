using ProyectoEconx.Controlador.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Producto
{
    public partial class V_Producto : Form
    {
        C_Producto cProducto = new C_Producto();
        public V_Producto()
        {
            InitializeComponent();
            cProducto.cargarTabla(dtProducto);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cProducto.abrirAgregar(dtProducto);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cProducto.editar(dtProducto);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cProducto.eliminar(dtProducto);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cProducto.buscar(dtProducto, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
