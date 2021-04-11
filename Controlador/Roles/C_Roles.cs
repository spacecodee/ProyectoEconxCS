using ProyectoEconx.Modelo.Roles;
using ProyectoEconx.SQL.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Roles
{
    public class C_Roles
    {
        M_Roles mRoles = new M_Roles();
        S_Roles sRoles = new S_Roles();

        public void cargarTabla(DataGridView dt)
        {
            List<M_Roles> lista = new List<M_Roles>();
            dt.DataSource = sRoles.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sRoles.mostrarTabla();
            }
            else
            {
                dt.DataSource = sRoles.mostrarTabla(txtBuscar.Text.Trim());
            }

        }
        private bool verificarText(TextBox txtCod, TextBox txtNom, Label lbl)
        {
            Boolean ver;

            ver = txtCod.Text.Trim().Equals("") || txtNom.Text.Trim().Equals("");
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
        public void agregar(TextBox txtCodigo, TextBox txtNom,
            Label lbl, DataGridView dt)
        {
            if (!verificarText(txtCodigo, txtNom, lbl))
            {
                mRoles.Codigo = txtCodigo.Text.Trim();
                mRoles.Roll = txtNom.Text.Trim();

                if (sRoles.agregar(mRoles))
                {
                    cargarTabla(dt);
                    limpiar(txtCodigo, txtNom, lbl);
                    MessageBox.Show("Registro agregado");
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }
        }
        public bool actualizar(TextBox txtCodigo, TextBox txtNom, Label lbl,
            DataGridView dt)
        {
            if (!verificarText(txtCodigo, txtNom, lbl))
            {
                int id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

                mRoles.Id = id;
                mRoles.Codigo = txtCodigo.Text;
                mRoles.Roll = txtNom.Text;

                if (sRoles.actualizar(mRoles))
                {
                    cargarTabla(dt);
                    limpiar(txtCodigo, txtNom, lbl);
                    MessageBox.Show("Registro actualizado");
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

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Selecciona el registro que deseas eliminar");
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (sRoles.eliminar(id))
                    {
                        cargarTabla(dt);
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("Al parecer ocurrio un error");
                    }
                }
            }
        }
        public bool eliminarRol(DataGridView dt)
        {
            String roll;
            roll = dt.CurrentRow.Cells[2].Value.ToString();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Selecciona el registro que deseas eliminar");
                return true;
            }
            else
            {
                if (roll.Equals("Administrador"))
                {
                    MessageBox.Show("No puedes eliminar al roll de administrador");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void editar(DataGridView dt, TextBox txtC, TextBox txtNom)
        {
            int id;
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());
            mRoles = sRoles.editar(id);

            txtC.Text = mRoles.Codigo;
            txtNom.Text = mRoles.Roll;
        }
        public void limpiar(TextBox txtCodigo, TextBox txtNom, Label lbl)
        {
            txtCodigo.Text = null;
            txtNom.Text = null;
            lbl.Text = null;
        }
    }
}
