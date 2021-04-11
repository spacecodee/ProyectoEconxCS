using ProyectoEconx.Controlador.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Roles
{
    public partial class V_Roles : Form
    {
        C_Roles cRol = new C_Roles();
        String validar = "Agregar";
        public V_Roles()
        {
            InitializeComponent();
            cRol.cargarTabla(dtRol);
            lblMensaje.Text = null;
        }

        private void dtRol_Click(object sender, EventArgs e)
        {
            cRol.editar(dtRol, txtCodigo, txtRoll);
            validar = "Actualizar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar.Equals("Agregar"))
            {
                cRol.agregar(txtCodigo, txtRoll, lblMensaje, dtRol);
            }
            else if (validar.Equals("Actualizar"))
            {
                cRol.actualizar(txtCodigo, txtRoll, lblMensaje, dtRol);
            }
            validar = "Agregar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!cRol.eliminarRol(dtRol))
            {
                cRol.eliminar(dtRol);
                txtCodigo.Text = null;
                txtRoll.Text = null;
            }
            
            validar = "Agregar";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cRol.buscar(dtRol, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
