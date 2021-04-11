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
    public partial class V_ActualizarProd : Form
    {
        DataGridView dt;
        public int id;
        C_Producto cProducto = new C_Producto();

        public V_ActualizarProd()
        {
            InitializeComponent();
        }
        public V_ActualizarProd(DataGridView dt)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSms_Click(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cProducto.actualizar(txtCodigo, txtNombre, txtPrecio, txtStock,
                lblSms, cbxCategoria, dt);
            this.Dispose();
        }
    }
}
