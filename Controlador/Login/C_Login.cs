using ProyectoEconx.Modelo.Login;
using ProyectoEconx.SQL.S_Login;
using ProyectoEconx.Vista;
using ProyectoEconx.Vista.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Login
{
    public class C_Login
    {
        M_Login mLogin = new M_Login();
        S_Login sLogin = new S_Login();

        public void placeHolder(TextBox pws)
        {
            if (pws.Text == "CONTRASEÑA")
            {
                pws.Text = "";
                pws.UseSystemPasswordChar = true;
            }
        }

        public void placeHolderQuitar(TextBox pws)
        {
            if (pws.Text == "")
            {
                pws.Text = "CONTRASEÑA";
                pws.UseSystemPasswordChar = false;
            }
        }

        public void placeHolder1(TextBox txt)
        {
            if (txt.Text == "USUARIO")
            {
                txt.Text = "";
            }
        }

        public void placeHolderQuitar1(TextBox txt)
        {
            if (txt.Text == "")
            {
                txt.Text = "USUARIO";
            }
        }

        private bool verificar(TextBox txt, TextBox pws, Label lbl)
        {
            Boolean ve = txt.Text.Equals("USUARIO") || pws.Text.Equals("CONTRASEÑA");
            if (ve)
            {
                lbl.Text = "Todos los campos son necesarios".ToUpper();
                return true;
            }
            else
            {
                lbl.Text = "".ToUpper();
                return false;
            }
        }

        public void login(V_Login vLogin, TextBox txtDni, TextBox txtPass,
            Label lbl)
        {
            mLogin.Dni = txtDni.Text.Trim();
            mLogin.Password = txtPass.Text.Trim();

            if (!verificar(txtDni, txtPass, lbl))
            {
                if (sLogin.login(mLogin))
                {
                    MessageBox.Show("Hola: " + mLogin.Nombre
                        + " " + mLogin.Apellidos);

                    V_Menu vMenuL = new V_Menu(mLogin);
                    vLogin.Hide();
                    vMenuL.ShowDialog();
                    vLogin.Close();
                }
                else
                {
                    lbl.Text = "Datos incorrectos";
                }
            }
        }
    }
}
