using ProyectoEconx.Modelo.CategoriaProd;
using ProyectoEconx.SQL.CategoriaProd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.CategoriaProd
{
    public class C_CategoriaP
    {
        S_CategoriaP sCategoriaP = new S_CategoriaP();
        M_CategoriaProd mCategoriaP = new M_CategoriaProd();

        public void cargarTabla(DataGridView dt)
        {
            List<M_CategoriaProd> lista = new List<M_CategoriaProd>();
            dt.DataSource = sCategoriaP.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sCategoriaP.mostrarTabla();
            }
            else
            {
                dt.DataSource = sCategoriaP.mostrarTabla(txtBuscar.Text.Trim());
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
                mCategoriaP.Codigo = txtCodigo.Text.Trim();
                mCategoriaP.Nombre = txtNom.Text.Trim();

                if (sCategoriaP.insertarRegistros(mCategoriaP))
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

                mCategoriaP.Id = id;
                mCategoriaP.Codigo = txtCodigo.Text;
                mCategoriaP.Nombre = txtNom.Text;

                if (sCategoriaP.actualizar(mCategoriaP))
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
                    if (sCategoriaP.eliminar(id))
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
        public void editar(DataGridView dt, TextBox txtC, TextBox txtNom)
        {
            int id;
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());
            mCategoriaP = sCategoriaP.editar(id);

            txtC.Text = mCategoriaP.Codigo;
            txtNom.Text = mCategoriaP.Nombre;
        }
        public void limpiar(TextBox txtCodigo, TextBox txtNom, Label lbl)
        {
            txtCodigo.Text = null;
            txtNom.Text = null;
            lbl.Text = null;
        }
    }
}
