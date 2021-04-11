using ProyectoEconx.Controlador.Intermedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Intermedia
{
    public partial class V_Intermedia : Form
    {
        C_Intermedia cIntermedia = new C_Intermedia();
        String validar = "Agregar";
        public int id;
        public V_Intermedia()
        {
            InitializeComponent();
            cIntermedia.cargarTabla(dtIntermedia);
            cIntermedia.listarProve(cbxProveedor);
            cIntermedia.listarProd(cbxProducto);
            lblMensaje.Text = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar.Equals("Agregar"))
            {
                cIntermedia.agregar(txtCod, cbxProveedor, cbxProducto, 
                    lblMensaje, dtIntermedia, dtFecha);
            }
            else if (validar.Equals("Actualizar"))
            {
                cIntermedia.actualizar(txtCod, cbxProveedor, cbxProducto,
                    lblMensaje, dtIntermedia, dtFecha);
            }

            validar = "Agregar";
        }

        private void dtIntermedia_Click(object sender, EventArgs e)
        {
            cIntermedia.editar(txtCod, cbxProveedor, cbxProducto,
                    lblMensaje, dtIntermedia, dtFecha);
            validar = "Actualizar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cIntermedia.eliminar(dtIntermedia);
            cIntermedia.limpiar(txtCod, cbxProveedor, cbxProducto,
                    lblMensaje);
            validar = "Agregar";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cIntermedia.buscar(dtIntermedia, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
