using ProyectoEconx.Modelo.Login;
using ProyectoEconx.SQL.Menu;
using ProyectoEconx.Vista;
using ProyectoEconx.Vista.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Menu
{
    public class C_Menu
    {
        S_Menu sMenu = new S_Menu();
        public void cerrarSesion(V_Menu vMenu)
        {
            if (MessageBox.Show("¿Desea cerrar sesion?", "Cerrar sesion", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                V_Login vLogin = new V_Login();
                vMenu.Hide();
                vLogin.ShowDialog();
                vMenu.Close();
            }
            else
            {

            }
        }

        public void AbrirFormulario<MiForm>(Panel pnl) where MiForm : Form, new()
        {
            Form formulario;
            formulario = pnl.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                pnl.Controls.Add(formulario);
                pnl.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                //formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        public int totalEmpleados()
        {
            return sMenu.totalEmpleados();
        }
        public int totalProductos()
        {
            return sMenu.totalProductos();
        }
        public int totalProveedores()
        {
            return sMenu.totalProveedores();
        }
    }
}
