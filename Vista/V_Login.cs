using ProyectoEconx.Controlador.Login;
using ProyectoEconx.Vista.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Vista
{
    public partial class V_Login : Form
    {
        C_Login cLogin = new C_Login();

        public V_Login()
        {
            InitializeComponent();
            tztUsuario.Focus();
            lblMensaje.Text = null;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            cLogin.placeHolder(txtPass);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            cLogin.placeHolderQuitar(txtPass);
        }

        private void tztUsuario_Enter(object sender, EventArgs e)
        {
            cLogin.placeHolder1(tztUsuario);
        }

        private void tztUsuario_Leave(object sender, EventArgs e)
        {
            cLogin.placeHolderQuitar1(tztUsuario);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            cLogin.login(this, tztUsuario, txtPass, lblMensaje);
        }
    }
}
