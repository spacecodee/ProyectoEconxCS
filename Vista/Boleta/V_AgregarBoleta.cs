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
    public partial class V_AgregarBoleta : Form
    {
        DataGridView dt;
        C_Boleta cBoleta = new C_Boleta();
        public V_AgregarBoleta()
        {
            InitializeComponent();
        }
        public V_AgregarBoleta(DataGridView dt)
        {
            InitializeComponent();
            this.dt = dt;
            cBoleta.listarInter(cbxIntermedia);
            cBoleta.listarComp(cbxComprador);
            lblSms.Text = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cBoleta.agregar(cbxIntermedia, cbxComprador, txtCodigo, txtPrecio,
                txtStock, txtEmpresa, lblSms, dt);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
