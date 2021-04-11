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
    public partial class V_Usuario : Form
    {
        C_Usuario cUsuario = new C_Usuario();

        public V_Usuario()
        {
            InitializeComponent();
        }

        private void V_Usuario_Load(object sender, EventArgs e)
        {
            cUsuario.cargarTabla(dtUsuario);
        }
        public void loaddata()
        {
            //do what you do in load data in order to update data in datagrid 
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cUsuario.abrirAgregar(dtUsuario);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!cUsuario.editarVerificar(dtUsuario))
            {
                cUsuario.editar(dtUsuario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cUsuario.eliminar(dtUsuario);
            cUsuario.cargarTabla(dtUsuario);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cUsuario.buscar(dtUsuario, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
