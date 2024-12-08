using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Modales
{
    public partial class vtnModalesClientes : Form
    {
        public Cliente Cliente { get; set; }
        public vtnModalesClientes()
        {
            InitializeComponent();
            tablaClientes.CellFormatting += tablaClientes_CellFormatting;
        }

        private void vtnModalesClientes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaClientes.Columns)
            {
                if (columna.Visible == true)
                {
                    cmb1.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;
            List<Cliente> mostrarCliente = new CN_Cliente().ListarCliente();
            foreach (Cliente clientes in mostrarCliente)
            {
                tablaClientes.Rows.Add(new object[] { clientes.IdCliente, clientes.Codigo, clientes.Nombres, clientes.Estado });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();

            int filasVisibles = 0;
            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt1.Text.Trim().ToUpper()))
                {
                    row.Visible = true;
                    filasVisibles++;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void tablaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                Cliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(tablaClientes.Rows[iRow].Cells["IdCliente"].Value.ToString()),
                    Codigo = tablaClientes.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombres = tablaClientes.Rows[iRow].Cells["Nombres"].Value.ToString(),
                    Estado = Convert.ToBoolean(tablaClientes.Rows[iRow].Cells["Estado"].Value.ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tablaClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaClientes.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(tablaClientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Activo" : "No Activo";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }
        }
    }
}
