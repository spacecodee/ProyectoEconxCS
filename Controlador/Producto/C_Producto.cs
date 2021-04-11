using ProyectoEconx.Modelo.Producto;
using ProyectoEconx.SQL.Producto;
using ProyectoEconx.Vista.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Producto
{
    public class C_Producto
    {
        S_Producto sProducto = new S_Producto();
        M_MProducto mMProducto = new M_MProducto();
        M_Producto mProducto = new M_Producto();
        M_ComboCategoria mComboCategoria = new M_ComboCategoria();
        V_AgregarProd vAgregarP;

        public void abrirAgregar(DataGridView dt)
        {
            vAgregarP = new V_AgregarProd(dt);
            vAgregarP.Show();
        }
        public void cargarTabla(DataGridView dt)
        {
            dt.DataSource = sProducto.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sProducto.mostrarTabla();
            }
            else
            {
                dt.DataSource = sProducto.mostrarTabla(txtBuscar.Text.Trim());
            }

        }
        public void listarCategoria(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();

            //cbxCategoria.Text = "Selecciona";
            cbx.DisplayMember = "Categoria";
            cbx.ValueMember = "IDCategoria";
            cbx.DataSource = sProducto.comboRoles();
        }
        private bool verificarText(TextBox txtCod, TextBox txtNom, TextBox txtPrecio,
            TextBox txtStock, Label lbl)
        {
            Boolean ver;

            ver = txtCod.Text.Trim().Equals("") || txtNom.Text.Trim().Equals("")
                || txtPrecio.Text.Trim().Equals("") || txtStock.Text.Trim().Equals("");
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
        public void agregar(TextBox txtCod, TextBox txtNom, TextBox txtPrecio,
            TextBox txtStock, Label lbl, ComboBox cbx, DataGridView dt)
        {
            if (!verificarText(txtCod, txtNom, txtPrecio, txtStock, lbl))
            {
                mProducto.Codigo = txtCod.Text.Trim();
                mProducto.Nombre = txtNom.Text.Trim();
                mProducto.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
                mProducto.Stock1 = Convert.ToInt32(txtStock.Text.Trim());
                mProducto.Categoria = Convert.ToInt32(cbx.SelectedValue);

                if (sProducto.agregar(mProducto))
                {
                    cargarTabla(dt);
                    limpiar(txtCod, txtNom, txtPrecio, txtStock, lbl, cbx);
                    MessageBox.Show("Registro agregado");
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }
        }
        public bool actualizar(TextBox txtCod, TextBox txtNom, TextBox txtPrecio,
            TextBox txtStock, Label lbl, ComboBox cbx, DataGridView dt)
        {
            if (!verificarText(txtCod, txtNom, txtPrecio, txtStock, lbl))
            {
                int id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

                mProducto.Id = id;
                mProducto.Codigo = txtCod.Text.Trim();
                mProducto.Nombre = txtNom.Text.Trim();
                mProducto.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
                mProducto.Stock1 = Convert.ToInt32(txtStock.Text.Trim());
                mProducto.Categoria = Convert.ToInt32(cbx.SelectedValue);

                if (sProducto.actualizar(mProducto))
                {
                    cargarTabla(dt);
                    limpiar(txtCod, txtNom, txtPrecio, txtStock, lbl, cbx);
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
                    if (sProducto.eliminar(id))
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
            V_ActualizarProd vActualizarP = new V_ActualizarProd(dt);
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());
            mProducto = sProducto.editar(id);

            vActualizarP.id = id;
            vActualizarP.txtCodigo.Text = mProducto.Codigo;
            vActualizarP.txtNombre.Text = mProducto.Nombre;
            vActualizarP.txtPrecio.Text = mProducto.Precio.ToString();
            vActualizarP.txtStock.Text = mProducto.Stock1.ToString();
            vActualizarP.cbxCategoria.SelectedValue = mProducto.Categoria;

            vActualizarP.ShowDialog();
        }
        public void limpiar(TextBox txtCod, TextBox txtNom, TextBox txtPrecio,
            TextBox txtStock, Label lbl, ComboBox cbx)
        {
            txtCod.Text = null;
            txtNom.Text = null;
            txtPrecio.Text = null;
            txtStock.Text = null;
            lbl.Text = null;
            listarCategoria(cbx);
        }
    }
}
