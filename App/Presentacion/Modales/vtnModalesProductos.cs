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
    public partial class vtnModalesProductos : Form
    {
        public Producto Producto { get; set; }
        public vtnModalesProductos()
        {
            InitializeComponent();
            TablaProductos.CellFormatting += TablaProductos_CellFormatting;
        }

        private void VtnModalesProductos_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in TablaProductos.Columns)
            {
                if (columna.Visible == true)
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            //Mostrar todos los productos existentes en la tabla
            List<Producto> mostrarProducto = new CN_Producto().ListarProducto();
            foreach (Producto productos in mostrarProducto)
            {
                TablaProductos.Rows.Add(new object[] { productos.IdProducto, productos.Codigo, productos.Nombre, productos.oCategoria.Descripcion, productos.Stock, productos.PrecioCompra, productos.PrecioVenta, productos.Estado });
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbBuscar.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in TablaProductos.Rows)
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

        private void TablaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(TablaProductos.Rows[iRow].Cells["IdProducto"].Value.ToString()),
                    Codigo = TablaProductos.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = TablaProductos.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(TablaProductos.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(TablaProductos.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(TablaProductos.Rows[iRow].Cells["PrecioVenta"].Value.ToString()),
                    Estado = Convert.ToBoolean(TablaProductos.Rows[iRow].Cells["Estado"].Value.ToString())
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TablaProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (TablaProductos.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(TablaProductos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Activo" : "No Activo";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }
        }
    }
}
