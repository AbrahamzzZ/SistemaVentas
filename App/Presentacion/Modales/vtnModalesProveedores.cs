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
    public partial class vtnModalesProveedores : Form
    {
        public Proveedor Proveedor { get; set; }
        public vtnModalesProveedores()
        {
            InitializeComponent();
            tablaProveedores.CellFormatting += TablaProveedores_CellFormatting;
        }

        private void VtnModalesProveedores_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaProveedores.Columns)
            {
                if (columna.Visible == true)
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            List<Proveedor> mostrarProveedor = new CN_Proveedor().ListarProveedores();
            foreach (Proveedor proveedor in mostrarProveedor)
            {
                tablaProveedores.Rows.Add(new object[] { proveedor.IdProveedor, proveedor.Cedula, proveedor.Nombres , proveedor.Estado});
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbBuscar.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();

            int filasVisibles = 0;
            foreach (DataGridViewRow row in tablaProveedores.Rows)
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

        private void TablaProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(tablaProveedores.Rows[iRow].Cells["IdProveedor"].Value.ToString()),
                    Cedula = tablaProveedores.Rows[iRow].Cells["Cedula"].Value.ToString(),
                    Nombres = tablaProveedores.Rows[iRow].Cells["Nombres"].Value.ToString(),
                    Estado = Convert.ToBoolean(tablaProveedores.Rows[iRow].Cells["Estado"].Value.ToString())
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TablaProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaProveedores.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(tablaProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Activo" : "No Activo";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }
        }
    }
}
