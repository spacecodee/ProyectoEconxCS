using ProyectoEconx.Controlador.Boleta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Boleta
{
    public partial class V_Boleta : Form
    {
        C_Boleta cBoleta = new C_Boleta();
        public V_Boleta()
        {
            InitializeComponent();
            cBoleta.cargarTabla(dtBoleta);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cBoleta.editar(dtBoleta);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cBoleta.abrirAgregar(dtBoleta);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cBoleta.eliminar(dtBoleta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cBoleta.buscar(dtBoleta, txtBuscar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            cBoleta.abrir();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            cBoleta.abrirTodo();
        }

        private void V_Boleta_Load(object sender, EventArgs e)
        {

        }
    }
}
