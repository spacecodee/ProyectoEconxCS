using AxAcroPDFLib;
using ProyectoEconx.Modelo.Boleta;
using ProyectoEconx.SQL;
using ProyectoEconx.Vista.Boleta;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEconx.Controlador.Boleta
{
    public class C_Boleta
    {
        S_Boleta sBoleta = new S_Boleta();
        M_Boleta mBoleta = new M_Boleta();
        V_AgregarBoleta vAregarBoleta;
        V_RealizarBoleta vRealizarBol;
        V_Todo vTodo;
        Process p = new Process();
        public void abrirAgregar(DataGridView dt)
        {
            vAregarBoleta = new V_AgregarBoleta(dt);
            vAregarBoleta.Show();
        }
        public void cargarTabla(DataGridView dt)
        {
            dt.DataSource = sBoleta.mostrarTabla();
        }
        public void buscar(DataGridView dt, TextBox txtBuscar)
        {
            if (txtBuscar.Text.Trim().Equals(""))
            {
                dt.DataSource = sBoleta.mostrarTabla();
            }
            else
            {
                dt.DataSource = sBoleta.mostrarTabla(txtBuscar.Text.Trim());
            }

        }
        public void listarInter(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();

            //cbxCategoria.Text = "Selecciona";
            cbx.DisplayMember = "Codigo";
            cbx.ValueMember = "ID";
            cbx.DataSource = sBoleta.comboInter();
        }
        public void listarComp(ComboBox cbx)
        {
            cbx.DataSource = null;
            cbx.Items.Clear();

            //cbxCategoria.Text = "Selecciona";
            cbx.DisplayMember = "DNI";
            cbx.ValueMember = "id";
            cbx.DataSource = sBoleta.comboComp();
        }
        private bool verificarText(TextBox txtCod,
            TextBox txtPrecio, TextBox txtStock, TextBox txtEmpresa, Label lbl)
        {
            Boolean ver;

            ver = txtCod.Text.Trim().Equals("") || txtPrecio.Text.Trim().Equals("")
                || txtStock.Text.Trim().Equals("") || txtEmpresa.Text.Trim().Equals("");
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
        public void agregar(ComboBox cbxInter, ComboBox cbxCompr, TextBox txtCod,
            TextBox txtPrecio, TextBox txtStock, TextBox txtEmpresa,
            Label lbl, DataGridView dt)
        {
            if (!verificarText(txtCod, txtPrecio, txtStock, txtEmpresa, lbl))
            {
                mBoleta.IdTrae = Convert.ToInt32(cbxInter.SelectedValue);
                mBoleta.UsuarioComprador = Convert.ToInt32(cbxCompr.SelectedValue);
                mBoleta.Codigo = txtCod.Text.Trim();
                mBoleta.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
                mBoleta.Cantidad = Convert.ToInt32(txtStock.Text.Trim());
                mBoleta.Empresa = txtEmpresa.Text.Trim();

                if (sBoleta.agregar(mBoleta))
                {
                    cargarTabla(dt);
                    limpiar(cbxInter, cbxCompr, txtCod, txtPrecio, txtStock,
                        txtEmpresa, lbl);
                    MessageBox.Show("Registro agregado");
                }
                else
                {
                    MessageBox.Show("Al parecer ocurrio un error");
                }
            }
        }
        public bool actualizar(ComboBox cbxInter, ComboBox cbxCompr, TextBox txtCod,
            TextBox txtPrecio, TextBox txtStock, TextBox txtEmpresa,
            Label lbl, DataGridView dt)
        {
            if (!verificarText(txtCod, txtPrecio, txtStock, txtEmpresa, lbl))
            {
                int id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());

                mBoleta.Id = id;
                mBoleta.IdTrae = Convert.ToInt32(cbxInter.SelectedValue);
                mBoleta.UsuarioComprador = Convert.ToInt32(cbxCompr.SelectedValue);
                mBoleta.Codigo = txtCod.Text.Trim();
                mBoleta.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
                mBoleta.Cantidad = Convert.ToInt32(txtStock.Text.Trim());
                mBoleta.Empresa = txtEmpresa.Text.Trim();

                if (sBoleta.actualizar(mBoleta))
                {
                    cargarTabla(dt);
                    limpiar(cbxInter, cbxCompr, txtCod, txtPrecio, txtStock,
                        txtEmpresa, lbl);
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
                    if (sBoleta.eliminar(id))
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
            V_ActualizarBoleta vActualizarB = new V_ActualizarBoleta(dt);
            id = int.Parse(dt.CurrentRow.Cells[0].Value.ToString());
            mBoleta = sBoleta.editar(id);

            vActualizarB.id = id;
            vActualizarB.cbxIntermedia.SelectedValue = mBoleta.IdTrae;
            vActualizarB.cbxComprador.SelectedValue = mBoleta.UsuarioComprador;
            vActualizarB.txtCodigo.Text = mBoleta.Codigo;
            vActualizarB.txtPrecio.Text = mBoleta.Precio.ToString();
            vActualizarB.txtPrecio.Text = mBoleta.Precio.ToString();
            vActualizarB.txtStock.Text = mBoleta.Cantidad.ToString();
            vActualizarB.txtEmpresa.Text = mBoleta.Empresa.ToString();

            vActualizarB.ShowDialog();
        }
        public void limpiar(ComboBox cbxInter, ComboBox cbxCompr, TextBox txtCod,
            TextBox txtPrecio, TextBox txtStock, TextBox txtEmpresa,
            Label lbl)
        {
            listarInter(cbxInter);
            listarComp(cbxCompr);
            txtCod.Text = null;
            txtPrecio.Text = null;
            txtStock.Text = null;
            txtEmpresa.Text = null;
            lbl.Text = null;
        }
        public void abrir()
        {
            vRealizarBol = new V_RealizarBoleta();
            vRealizarBol.ShowDialog();
        }
        public void abrirTodo()
        {
            vTodo = new V_Todo();
            vTodo.ShowDialog();
        }
        public void realizarBoleta(TextBox txt, DateTimePicker dt, TextBox nombre)
        {
            String tx, f, nom;
            try
            {
                DateTime fecha = Convert.ToDateTime(dt.Text);
                tx = txt.Text.Trim();
                f = fecha.ToString();
                nom = nombre.Text.Trim();
                sBoleta.crearPDF(tx, f, nom);
                p.StartInfo.FileName =
                    @"C:/Users/devro/source/repos/ProyectoEconx/bin/Debug/" +
                    nom + ".pdf";
                MessageBox.Show("Factura realizada");
                p.Start();
                txt.Text = null;
                nombre.Text = null;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Al parecer ocurrio un error \n" + exc);
            }
        }
        public void realizarBoleta(TextBox nombre)
        {
            String nom;
            
            try
            {
                nom = nombre.Text.Trim();
                sBoleta.crearPDF(nom);
                p.StartInfo.FileName = 
                    @"C:/Users/devro/source/repos/ProyectoEconx/bin/Debug/" + 
                    nom + ".pdf";
                MessageBox.Show("Factura realizada");
                p.Start();
                nombre.Text = null;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Al parecer ocurrio un error \n" + exc);
            }
        }
    }
}
