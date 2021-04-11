using ProyectoEconx.Controlador.CategoriaProd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.CategoriaPro
{
    public partial class V_CategoriaPro : Form
    {
        public int id;
        String validar = "Agregar";
        C_CategoriaP cCategoriaP = new C_CategoriaP();

        public V_CategoriaPro()
        {
            InitializeComponent();
            cCategoriaP.cargarTabla(dtCategoria);
            lblMensaje.Text = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar.Equals("Agregar"))
            {
                cCategoriaP.agregar(txtCodigo, txtNombre, lblMensaje, dtCategoria);
            }
            else if (validar.Equals("Actualizar"))
            {
                cCategoriaP.actualizar(txtCodigo, txtNombre, lblMensaje, dtCategoria);
            }

            validar = "Agregar";
        }

        private void dtCategoria_Click(object sender, EventArgs e)
        {
            cCategoriaP.editar(dtCategoria, txtCodigo, txtNombre);
            validar = "Actualizar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cCategoriaP.eliminar(dtCategoria);
            cCategoriaP.limpiar(txtCodigo, txtNombre, lblMensaje);
            validar = "Agregar";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cCategoriaP.buscar(dtCategoria, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
