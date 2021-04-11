using ProyectoEconx.Controlador.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Usuario
{
    public partial class V_AgregarUsuario : Form
    {
        C_Usuario cUsuario = new C_Usuario();
        DataGridView dt;
        public V_AgregarUsuario()
        {
            InitializeComponent();
            cUsuario.listarCategoria(cbxRoles);
            lblSms.Text = null;
        }

        public V_AgregarUsuario(DataGridView dt)
        {
            InitializeComponent();
            this.dt = dt;
            cUsuario.listarCategoria(cbxRoles);
            lblSms.Text = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           cUsuario.agregarUsuario(txtDNI, txtPass, txtNombre, txtApellidos, txtTelefono, 
                txtMail, lblSms, cbxRoles, dtFecha, dt);
        }
    }
}
