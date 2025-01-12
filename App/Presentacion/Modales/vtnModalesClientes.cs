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
        /// <summary>
        /// Variable donde se va a guardar el cliente seleccionado.
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary> 
        /// Constructor de la clase vtnModalesClientes. 
        /// Inicializa una nueva instancia de vtnModalesClientes.
        /// </summary>
        public vtnModalesClientes()
        {
            InitializeComponent();
        }

        private void VtnModalesClientes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaClientes.Columns)
            {
                if (columna.Visible == true)
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            List<Cliente> mostrarCliente = new CN_Cliente().ListarCliente();
            foreach (Cliente clientes in mostrarCliente)
            {
                tablaClientes.Rows.Add(new object[] { clientes.IdCliente, clientes.Cedula, clientes.Nombres, clientes.Estado });
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbBuscar.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();

            int filasVisibles = 0;
            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TxtBuscar.Text.Trim().ToUpper()))
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

        private void TablaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                Cliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(tablaClientes.Rows[iRow].Cells["IdCliente"].Value.ToString()),
                    Cedula = tablaClientes.Rows[iRow].Cells["Cedula"].Value.ToString(),
                    Nombres = tablaClientes.Rows[iRow].Cells["Nombres"].Value.ToString(),
                    Estado = Convert.ToBoolean(tablaClientes.Rows[iRow].Cells["Estado"].Value.ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TablaClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
