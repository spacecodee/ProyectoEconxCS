using ProyectoEconx.Modelo.Proveedor;
using ProyectoEconx.SQL.Proveedor;
using ProyectoEconx.Vista.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Proveedor
{
    public class C_Proveedor
    {
        S_Proveedor sProveedor = new S_Proveedor();
        M_Proveedor mProveedor = new M_Proveedor();
        V_AgregarProve vAgregarProv;
        V_ActualizarProve vActualizarProv;

        public void cargarTabla(DataGridView dt)
        {
            dt.DataSource = sProveedor.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sProveedor.mostrarTabla();
            }
            else
            {
                dt.DataSource = sProveedor.mostrarTabla(txtBuscar.Text.Trim());
            }

        }
        public void abrirAgregar(DataGridView dt)
        {
            vAgregarProv = new V_AgregarProve(dt);
            vAgregarProv.Show();
        }
        public void abrirActualizar(DataGridView dt)
        {
            vActualizarProv = new V_ActualizarProve(dt);
            vActualizarProv.Show();
        }
        private bool verificarText(TextBox txtDni, TextBox txtNom, TextBox txtApe,
            TextBox txtMail, TextBox txtTelefono, Label lbl)
        {
            Boolean ver;

            ver = txtDni.Text.Trim().Equals("") || txtNom.Text.Trim().Equals("")
                || txtApe.Text.Trim().Equals("") || txtMail.Text.Trim().Equals("")
                || txtTelefono.Text.Trim().Equals("");
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
        public void agregar(TextBox txtDni, TextBox txtNom, TextBox txtApe,
            TextBox txtMail, TextBox txtTelefono, Label lbl, DataGridView dt)
        {
            if (!verificarText(txtDni, txtNom, txtApe, txtMail, txtTelefono, lbl))
            {
                mProveedor.Dni = txtDni.Text.Trim();
                mProveedor.Nombre = txtNom.Text.Trim();
                mProveedor.Apellidos = txtApe.Text.Trim();
                mProveedor.CorreoElectronico = txtMail.Text.Trim();
                mProveedor.Telefono = txtTelefono.Text.Trim();

                if (sProveedor.agregar(mProveedor))
                {
                    cargarTabla(dt);
                    limpiar(txtDni, txtNom, txtApe, txtMail, txtTelefono, lbl);
                    MessageBox.Show("Registro agregado");
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }
        }
        public bool actualizar(TextBox txtDni, TextBox txtNom, TextBox txtApe,
            TextBox txtMail, TextBox txtTelefono, Label lbl, DataGridView dt)
        {
            if (!verificarText(txtDni, txtNom, txtApe, txtMail, txtTelefono, lbl))
            {
                int id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

                mProveedor.Id = id;
                mProveedor.Dni = txtDni.Text.Trim();
                mProveedor.Nombre = txtNom.Text.Trim();
                mProveedor.Apellidos = txtApe.Text.Trim();
                mProveedor.CorreoElectronico = txtMail.Text.Trim();
                mProveedor.Telefono = txtTelefono.Text.Trim();

                if (sProveedor.actualizar(mProveedor))
                {
                    cargarTabla(dt);
                    limpiar(txtDni, txtNom, txtApe, txtMail, txtTelefono, lbl);
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
                    if (sProveedor.eliminar(id))
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
        public void editar(DataGridView dt)
        {
            int id;
            V_ActualizarProve vActualizarProv = new V_ActualizarProve(dt);
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());
            mProveedor = sProveedor.editar(id);

            vActualizarProv.id = mProveedor.Id;
            vActualizarProv.txtDNI.Text = mProveedor.Dni;
            vActualizarProv.txtNombre.Text = mProveedor.Nombre;
            vActualizarProv.txtApellidos.Text = mProveedor.Apellidos;
            vActualizarProv.txtMail.Text = mProveedor.CorreoElectronico;
            vActualizarProv.txtTelefono.Text = mProveedor.Telefono;

            vActualizarProv.ShowDialog();
        }
        public void limpiar(TextBox txtDni, TextBox txtNom, TextBox txtApe,
            TextBox txtMail, TextBox txtTelefono, Label lbl)
        {
            txtDni.Text = null;
            txtNom.Text = null;
            txtApe.Text = null;
            txtMail.Text = null;
            txtTelefono.Text = null;
            lbl.Text = null;
        }
    }
}
