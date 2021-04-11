using ProyectoEconx.Modelo.Intermedia;
using ProyectoEconx.SQL.Intermedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Intermedia
{
    public class C_Intermedia
    {
        S_Intermedia sIntermedia = new S_Intermedia();
        M_Intermedia mIntermedia = new M_Intermedia();

        public void cargarTabla(DataGridView dt)
        {
            dt.DataSource = sIntermedia.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sIntermedia.mostrarTabla();
            }
            else
            {
                dt.DataSource = sIntermedia.mostrarTabla(txtBuscar.Text.Trim());
            }

        }
        public void listarProve(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();

            //cbxCategoria.Text = "Selecciona";
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "ID";
            cbx.DataSource = sIntermedia.comboProvee();
        }
        public void listarProd(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();

            //cbxCategoria.Text = "Selecciona";
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "ID";
            cbx.DataSource = sIntermedia.comboProduc();
        }
        private bool verificarText(TextBox txtCod, Label lbl)
        {
            Boolean ver;

            ver = txtCod.Text.Trim().Equals("");
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
        public void agregar(TextBox txtCod, ComboBox cbxProv, ComboBox cbxProd,
           Label lbl, DataGridView dt, DateTimePicker dtF)
        {
            if (!verificarText(txtCod, lbl))
            {
                DateTime fecha = Convert.ToDateTime(dtF.Text);
                mIntermedia.Codigo = txtCod.Text.Trim();
                mIntermedia.IdProveedor = Convert.ToInt32(cbxProv.SelectedValue);
                mIntermedia.IdProducto = Convert.ToInt32(cbxProd.SelectedValue);
                mIntermedia.Fecha = fecha.ToString("yyyy-MM-dd");

                if (sIntermedia.agregar(mIntermedia))
                {
                    cargarTabla(dt);
                    limpiar(txtCod, cbxProv, cbxProd, lbl);
                    MessageBox.Show("Registro agregado");
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }
        }
        public bool actualizar(TextBox txtCod, ComboBox cbxProv, ComboBox cbxProd,
           Label lbl, DataGridView dt, DateTimePicker dtF)
        {
            if (!verificarText(txtCod, lbl))
            {
                int id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

                mIntermedia.Id = id;
                DateTime fecha = Convert.ToDateTime(dtF.Text);
                mIntermedia.Codigo = txtCod.Text.Trim();
                mIntermedia.IdProveedor = Convert.ToInt32(cbxProv.SelectedValue);
                mIntermedia.IdProducto = Convert.ToInt32(cbxProd.SelectedValue);
                mIntermedia.Fecha = fecha.ToString("yyyy-MM-dd");

                if (sIntermedia.actualizar(mIntermedia))
                {
                    cargarTabla(dt);
                    limpiar(txtCod, cbxProv, cbxProd, lbl);
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
                    if (sIntermedia.eliminar(id))
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
        public void editar(TextBox txtCod, ComboBox cbxProv, ComboBox cbxProd,
           Label lbl, DataGridView dt, DateTimePicker dtF)
        {
            int id;
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());
            mIntermedia = sIntermedia.editar(id);

            txtCod.Text = mIntermedia.Codigo;
            cbxProv.SelectedValue = mIntermedia.IdProveedor;
            cbxProd.SelectedValue = mIntermedia.IdProducto;
            dtF.Text = mIntermedia.Fecha;
        }
        public void limpiar(TextBox txt, ComboBox cbx1, ComboBox cbx2, Label lbl)
        {
            txt.Text = null;
            listarProve(cbx1);
            listarProd(cbx2);
            lbl.Text = null;
        }
    }
}
