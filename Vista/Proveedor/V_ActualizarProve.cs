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
    public partial class V_ActualizarProve : Form
    {
        public int id;
        C_Proveedor cProveedor = new C_Proveedor();
        DataGridView dt;

        public V_ActualizarProve()
        {
            InitializeComponent();
        }

        public V_ActualizarProve(DataGridView dt)
        {
            InitializeComponent();
            this.dt = dt;
            lblSms.Text = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cProveedor.actualizar(txtDNI, txtNombre, txtApellidos, txtMail, 
                txtTelefono, lblSms, dt);
            this.Dispose();
        }
    }
}
