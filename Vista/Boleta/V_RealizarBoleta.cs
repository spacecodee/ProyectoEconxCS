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
    public partial class V_RealizarBoleta : Form
    {
        C_Boleta cBoleta = new C_Boleta();
        public V_RealizarBoleta()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cBoleta.realizarBoleta(txtDni, dtf, txtNombre);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
