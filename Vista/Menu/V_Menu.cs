using ProyectoEconx.Controlador.Menu;
using ProyectoEconx.Modelo.Login;
using ProyectoEconx.Vista.Boleta;
using ProyectoEconx.Vista.CategoriaPro;
using ProyectoEconx.Vista.Intermedia;
using ProyectoEconx.Vista.Producto;
using ProyectoEconx.Vista.Proveedor;
using ProyectoEconx.Vista.Roles;
using ProyectoEconx.Vista.Usuario;
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
    public partial class V_Menu : Form
    {
        M_Login mLogin;
        C_Menu cMenu = new C_Menu();

        public V_Menu()
        {
            InitializeComponent();
        }

        public V_Menu(M_Login mLogin)
        {
            InitializeComponent();
            this.mLogin = mLogin;
            cMenu.AbrirFormulario<V_PanelMenu>(pnlMenu);
            if (!mLogin.Roll.Equals("Administrador"))
            {
                btnUsuario.Enabled = false;
                btnRoll.Enabled = false;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_PanelMenu>(pnlMenu);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_Usuario>(pnlMenu);
        }

        private void btnCerrarS_Click(object sender, EventArgs e)
        {
            cMenu.cerrarSesion(this);
        }

        private void btnCategoriaP_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_CategoriaPro>(pnlMenu);
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_Roles>(pnlMenu);
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_Proveedor>(pnlMenu);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_Producto>(pnlMenu);
        }

        private void btnIntermedia_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_Intermedia>(pnlMenu);
        }

        private void btnBoletas_Click(object sender, EventArgs e)
        {
            cMenu.AbrirFormulario<V_Boleta>(pnlMenu);
        }
    }
}
