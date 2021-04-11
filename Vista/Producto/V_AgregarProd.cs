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
    public partial class V_AgregarProd : Form
    {
        DataGridView dt;
        C_Producto cProducto = new C_Producto();
        public V_AgregarProd()
        {
            InitializeComponent();
        }

        public V_AgregarProd(DataGridView dt)
        {
            InitializeComponent();
            this.dt = dt;
            cProducto.listarCategoria(cbxCategoria);
            lblSms.Text = null;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cProducto.agregar(txtCodigo, txtNombre, txtPrecio, txtStock, lblSms,
                cbxCategoria, dt);
        }
    }
}
