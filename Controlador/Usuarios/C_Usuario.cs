using ProyectoEconx.Modelo.Usuario;
using ProyectoEconx.SQL.Usuarios;
using ProyectoEconx.Vista.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Usuarios
{
    public class C_Usuario
    {
        M_MUsuario mMusuario = new M_MUsuario();
        S_Usuarios sUsuario = new S_Usuarios();
        M_Usuario mUsuario = new M_Usuario();
        V_AgregarUsuario vAgregarU;
        V_ActualizarUsuario vActualizarUsuario;

        public void cargarTabla(DataGridView dt)
        {
            List<M_MUsuario> lista = new List<M_MUsuario>();
            dt.DataSource = sUsuario.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sUsuario.mostrarTabla();
            }
            else
            {
                dt.DataSource = sUsuario.mostrarTabla(txtBuscar.Text.Trim());
            }

        }
        public void listarCategoria(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();

            //cbxCategoria.Text = "Selecciona";
            cbx.DisplayMember = "Tipo";
            cbx.ValueMember = "ID";
            cbx.DataSource = sUsuario.comboRoles();
        }
        private bool verificarText(TextBox txtDni, TextBox txtPass, TextBox txtNom,
            TextBox txtApe, TextBox txtTelefono, TextBox txtMail,
            Label lbl)
        {
            Boolean ver;

            ver = txtDni.Text.Trim().Equals("") || txtPass.Text.Trim().Equals("")
                || txtNom.Text.Trim().Equals("") || txtApe.Text.Trim().Equals("")
                || txtTelefono.Text.Trim().Equals("")
                || txtMail.Text.Trim().Equals("");
            if (ver)
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
        public void agregarUsuario(TextBox txtDni, TextBox txtPass, TextBox txtNom,
            TextBox txtApe, TextBox txtTelefono, TextBox txtMail, Label lbl,
            ComboBox cbx, DateTimePicker dtFecha, DataGridView dt)
        {
            if (!verificarText(txtDni, txtPass, txtNom,
            txtApe, txtTelefono, txtMail, lbl))
            {
                DateTime fecha = Convert.ToDateTime(dtFecha.Text);
                mUsuario.Dni = txtDni.Text.Trim();
                mUsuario.Pass = txtPass.Text.Trim();
                mUsuario.Nombre = txtNom.Text.Trim();
                mUsuario.Apellidos = txtApe.Text.Trim();
                mUsuario.Telefono = txtTelefono.Text.Trim();
                mUsuario.Mail = txtMail.Text.Trim();
                mUsuario.Fecha = fecha.ToString("yyyy-MM-dd");
                mUsuario.Roll = Convert.ToInt32(cbx.SelectedValue);

                if (sUsuario.insertarRegistros(mUsuario))
                {
                    cargarTabla(dt);
                    MessageBox.Show("Registro agregado");
                    limpiar(txtDni, txtPass, txtNom,
                    txtApe, txtTelefono, txtMail, cbx);
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }
        }
        public void abrirAgregar(DataGridView dt)
        {
            vAgregarU = new V_AgregarUsuario(dt);
            vAgregarU.Show();
        }
        public bool actualizar(TextBox txtDni, TextBox txtNom,
            TextBox txtApe, TextBox txtTelefono, Label lbl,
            ComboBox cbx, int id, DataGridView dt)
        {
            if (!verificarText(txtDni, txtNom, txtApe, txtTelefono, lbl, id))
            {
                mUsuario.Id = id;
                mUsuario.Dni = txtDni.Text;
                mUsuario.Nombre = txtNom.Text;
                mUsuario.Apellidos = txtApe.Text;
                mUsuario.Telefono = txtTelefono.Text;
                mUsuario.Roll = Convert.ToInt32(cbx.SelectedValue);

                if (sUsuario.actualizar(mUsuario))
                {
                    cargarTabla(dt);
                    MessageBox.Show("Registro actualizado");
                    limpiar(txtDni, txtNom, txtApe, txtTelefono, cbx);
                    return true;
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void eliminar(DataGridView dt)
        {
            int id;
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (sUsuario.eliminar(id))
                {
                    MessageBox.Show("Registro eliminado");
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }


        }
        private bool verificarText(TextBox txtDni, TextBox txtNom,
            TextBox txtApe, TextBox txtTelefono, Label lbl, int id)
        {
            Boolean ver;

            ver = txtDni.Text.Trim().Equals("")
                || txtNom.Text.Trim().Equals("") || txtApe.Text.Trim().Equals("")
                || txtTelefono.Text.Trim().Equals("") || id == 0;
            if (ver)
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
        public bool editarVerificar(DataGridView dt)
        {
            int fill = dt.SelectedRows.Count;
            if (fill == -1)
            {
                MessageBox.Show("Selecciona la fila a editar");
                return true;
            }
            else
            {
                return false;
            }

        }
        public void editar(DataGridView dt)
        {
            int id;
            vActualizarUsuario = new V_ActualizarUsuario(dt);
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

            mUsuario = sUsuario.editar(id);

            vActualizarUsuario.id = id;
            vActualizarUsuario.txtDNI.Text = mUsuario.Dni;
            vActualizarUsuario.txtNombre.Text = mUsuario.Nombre;
            vActualizarUsuario.txtApellidos.Text = mUsuario.Apellidos;
            vActualizarUsuario.txtTelefono.Text = mUsuario.Telefono;
            vActualizarUsuario.cbxRoles.SelectedValue = mUsuario.Roll;

            vActualizarUsuario.ShowDialog();
        }
        public void limpiar(TextBox txtDni, TextBox txtPass, TextBox txtNom,
            TextBox txtApe, TextBox txtTelefono, TextBox txtMail, ComboBox cbx)
        {
            txtDni.Text = null;
            txtPass.Text = null;
            txtNom.Text = null;
            txtApe.Text = null;
            txtTelefono.Text = null;
            txtMail.Text = null;
            listarCategoria(cbx);
        }
        public void limpiar(TextBox txtDni, TextBox txtNom,
            TextBox txtApe, TextBox txtTelefono, ComboBox cbx)
        {
            txtDni.Text = null;
            txtNom.Text = null;
            txtApe.Text = null;
            txtTelefono.Text = null;
            listarCategoria(cbx);
        }
    }
}
