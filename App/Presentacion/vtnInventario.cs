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
using ClosedXML.Excel;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class VtnInventario : Form
    {
        private Producto producto;
        public VtnInventario()
        {
            InitializeComponent();
        }

        private void VtnInventario_Load(object sender, EventArgs e)
        {
            List<Producto> listaProducto = new CN_Producto().ListarProducto();
            foreach (Producto productos in listaProducto)
            {
                CmbProducto.Items.Add(new { Valor = productos.IdProducto, Texto = productos.Nombre });
            }
            CmbProducto.DisplayMember = "Texto";
            CmbProducto.ValueMember = "Valor";
            if (CmbProducto.Items.Count > 0)
            {
                CmbProducto.SelectedIndex = 0;
            }
            else
            {
                CmbProducto.Enabled = false;
            }

            List<Zona_Almacen> listaZona = new CN_Zona_Almacen().ListarZonaAlmacen();
            foreach (Zona_Almacen zonas in listaZona)
            {
                CmbZonaAlmacen.Items.Add(new { Valor = zonas.IdZona, Texto = zonas.NombreZona });
            }
            CmbZonaAlmacen.DisplayMember = "Texto";
            CmbZonaAlmacen.ValueMember = "Valor";
            if (CmbZonaAlmacen.Items.Count > 0)
            {
                CmbZonaAlmacen.SelectedIndex = 0;
            }
            else
            {
                CmbZonaAlmacen.Enabled = false;
            }

            foreach (DataGridViewColumn columna in tablaInventario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            List<Inventario> mostrarInventario = new CN_Inventario().ListarProductoInventario();
            foreach (Inventario productosInventario in mostrarInventario)
            {
                tablaInventario.Rows.Add(new object[] { "", productosInventario.IdInventario, productosInventario.oProducto.IdProducto, productosInventario.oProducto.Codigo, productosInventario.oProducto.Nombre, productosInventario.Cantidad });
            }
            TxtCantidad.Select();
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaInventario.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaInventario.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in tablaInventario.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[7].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Lista_Inventario.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Inventario");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(guardar.FileName);
                        MessageBox.Show("Excel generado correctamente.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el Excel.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb4 = CmbBuscar.SelectedItem;
            string valorCmb4 = selectedItemCmb4.Valor;
            string columnaFiltro = valorCmb4.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaInventario.Rows)
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
            // Verificar si hay filas visibles y mostrar un mensaje si no hay
            if (filasVisibles == 0)
            {
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaInventario.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = CmbProducto.SelectedItem;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(TxtCantidad.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(TxtCantidad.Text)) mensajeError += "- Cantidad del producto\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                /*int cantidadComprada = new CN_Compra().CantidadProductoComprado(valorCmb1);
                int cantidadIngresada = Convert.ToInt32(txt4.Text);
                if (cantidadIngresada > cantidadComprada)
                {
                    MessageBox.Show("No se puede ingresar un producto más de lo que se compró.", "Agregar producto al inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                Inventario agregarProductoInventario = new Inventario()
                {
                    /*IdInventario = Convert.ToInt32(TxtId.Text),
                    oProducto = new Producto { IdProducto = valorCmb1, Codigo = textoCmb1.ToString(), Nombre = textoCmb2.ToString() },
                    Cantidad = Convert.ToInt32(TxtCantidad.Text),
                    UbicacionAlmacen = txt5.Text,
                    Estado = valorCmb3 == 1*/
                };
                /*List<Producto> listaProducto = new CN_Producto().ListarProducto();
                Producto productoSeleccionado = listaProducto.FirstOrDefault(c => c.IdProducto == valorCmb1);
                if (productoSeleccionado != null && !productoSeleccionado.Estado)
                {
                    MessageBox.Show("El producto seleccionado no está habilitado. Por favor, seleccione un producto activo.", "Producto no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    return;
                }
                else {
                    int idInventarioIngresado = new CN_Inventario().Registrar(agregarProductoInventario, out mensaje);
                    if (idInventarioIngresado != 0)
                    {
                        // Verificar si los elementos seleccionados no son nulos
                        if (selectedItemCmb1 != null && selectedItemCmb2 != null)
                        {
                            tablaInventario.Rows.Add(new object[] { "", idInventarioIngresado, valorCmb1, textoCmb1, textoCmb2, TxtCantidad.Text, txt5.Text, valorCmb3, textoCmb3 });
                            MessageBox.Show("El producto fue agregado correctamente en el inventario.", "Agregar productos al inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla inventario");
                        }
                    }
                }*/
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbZonaAlmacen.SelectedItem;
            dynamic selectedItemCmb2 = CmbProducto.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            string mensaje;

            Inventario editarProductoInventario = new Inventario()
            {
                IdInventario = Convert.ToInt32(TxtId.Text),
                oProducto = new Producto { IdProducto = valorCmb1, Nombre = textoCmb2.ToString() },
                Cantidad = Convert.ToInt32(TxtCantidad.Text),
                //UbicacionAlmacen = txt.Text,
            };
            bool modificar = new CN_Inventario().Editar(editarProductoInventario, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El producto fue modificado correctamente en el inventario.", "Modificar producto en el inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaInventario.Rows[indice].Cells["IDPRODUCTO"].Value = editarProductoInventario.oProducto.IdProducto;
                tablaInventario.Rows[indice].Cells["NombreProductos"].Value = editarProductoInventario.oProducto.Nombre;
                tablaInventario.Rows[indice].Cells["Cantidad"].Value = editarProductoInventario.Cantidad;
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar el producto: " + mensaje, "Modificar producto en el inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCantidad.Text))
            {
                MessageBox.Show("Primero debe selecionar un producto en la tabla para poder eliminarlo del inventario.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(TxtId.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este producto del inventario?", "Eliminar producto del inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Inventario productoEliminadoInventario = new Inventario()
                        {
                            IdInventario = Convert.ToInt32(TxtId.Text),
                        };
                        bool respuesta = new CN_Inventario().Eliminar(productoEliminadoInventario, out mensaje);
                        if (respuesta)
                        {
                            tablaInventario.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                            MessageBox.Show("El producto fue eliminado correctamente del inventario.", "Eliminar producto del inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar producto del inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void TablaInventario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var p = Properties.Resources.visto.Width;
                var q = Properties.Resources.visto.Height;
                var r = e.CellBounds.Left + (e.CellBounds.Width - p) / 2;
                var s = e.CellBounds.Top + (e.CellBounds.Height - q) / 2;
                e.Graphics.DrawImage(Properties.Resources.visto, new Rectangle(r, s, p, q));
                e.Handled = true;
            }
        }

        private void TablaInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaInventario.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaInventario.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void TablaInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaInventario.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaInventario.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCantidad.Text = tablaInventario.Rows[indice].Cells["Cantidad"].Value.ToString();

                    foreach (dynamic item in CmbZonaAlmacen.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (tablaInventario.Rows[indice].Cells["UbicacionAlmacen"].Value.ToString() == item.Texto)
                        {
                            int indice_cmb = CmbZonaAlmacen.Items.IndexOf(item);
                            CmbZonaAlmacen.SelectedIndex = indice_cmb;
                            break;
                        }
                    }

                    foreach (dynamic item in CmbProducto.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (tablaInventario.Rows[indice].Cells["NombreProductos"].Value.ToString() == item.Texto)
                        {
                            int indice_cmb = CmbProducto.Items.IndexOf(item);
                            CmbProducto.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }
        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            CmbZonaAlmacen.SelectedIndex = 0;
            CmbProducto.SelectedIndex = 0;
            TxtCantidad.Text = "";
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
