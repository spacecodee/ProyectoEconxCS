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
    public partial class V_ActualizarBoleta : Form
    {
        public int id;
        DataGridView dt;
        C_Boleta cBoleta = new C_Boleta();
        public V_ActualizarBoleta()
        {
            InitializeComponent();
        }
        public V_ActualizarBoleta(DataGridView dt)
        {
            InitializeComponent();
            this.dt = dt;
            cBoleta.listarInter(cbxIntermedia);
            cBoleta.listarComp(cbxComprador);
            lblSms.Text = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cBoleta.actualizar(cbxIntermedia, cbxComprador, txtCodigo, txtPrecio,
                txtStock, txtEmpresa, lblSms, dt);
            this.Dispose();
        }
    }
}
