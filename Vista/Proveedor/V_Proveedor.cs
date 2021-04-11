using ProyectoEconx.Controlador.Proveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Proveedor
{
    public partial class V_Proveedor : Form
    {
        C_Proveedor cProveedor = new C_Proveedor();
        public V_Proveedor()
        {
            InitializeComponent();
            cProveedor.cargarTabla(dtProveedor);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cProveedor.abrirAgregar(dtProveedor);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cProveedor.eliminar(dtProveedor);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cProveedor.editar(dtProveedor);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cProveedor.buscar(dtProveedor, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
