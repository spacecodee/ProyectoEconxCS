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
    public partial class V_ActualizarUsuario : Form
    {
        C_Usuario cUsuario = new C_Usuario();
        public int id;
        DataGridView dt;
        public V_ActualizarUsuario()
        {
            InitializeComponent();
            cUsuario.listarCategoria(cbxRoles);
            lblSms.Text = null;
        }

        public V_ActualizarUsuario(DataGridView dt)
        {
            InitializeComponent();
            this.dt = dt;
            cUsuario.listarCategoria(cbxRoles);
            lblSms.Text = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cUsuario.actualizar(txtDNI, txtNombre, txtApellidos, txtTelefono, 
                lblSms, cbxRoles, id, dt);
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
