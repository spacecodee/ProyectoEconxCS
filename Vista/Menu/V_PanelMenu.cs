using ProyectoEconx.Controlador.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista.Menu
{
    public partial class V_PanelMenu : Form
    {
        C_Menu cMenu = new C_Menu();
        public V_PanelMenu()
        {
            InitializeComponent();
            lblEmpleados.Text = cMenu.totalEmpleados().ToString();
            lblProductos.Text = cMenu.totalProductos().ToString();
            lblProveedores.Text = cMenu.totalProveedores().ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
