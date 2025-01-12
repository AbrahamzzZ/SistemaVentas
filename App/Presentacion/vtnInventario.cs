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
    /// <summary>
    /// Clase que representa la ventana de inventario.
    /// </summary>
    public partial class VtnInventario : Form
    {
        private Producto producto;

        private Dictionary<int, Color> zonaColors = new Dictionary<int, Color>() { 
            {1, Color.LightBlue},   // Zona Norte
            {2, Color.LightGreen},   // Zona Sur
            {3, Color.Yellow},       // Zona Central
            {4, Color.Orange},       // Zona Oeste
            {5, Color.Pink}          // Zona Este
        };

        /// <summary>
        /// Constructor de la clase VtnInventario.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnInventario()
        {
            InitializeComponent();
        }

        private void VtnInventario_Load(object sender, EventArgs e)
        {
            List<Producto> listaProductosConStock = new CN_Producto().ListarProductosConStock();

            foreach (var producto in listaProductosConStock)
            {
                CmbProducto.Items.Add(producto);
            }

            CmbProducto.DisplayMember = "Nombre";
            CmbProducto.ValueMember = "IdProducto";
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

            foreach (DataGridViewColumn columna in TablaInventario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            TxtCantidad.Text = "0";
            List<Inventario> mostrarInventario = new CN_Inventario().ListarProductoInventario();
            foreach (Inventario productosInventario in mostrarInventario)
            {
                TablaInventario.Rows.Add(new object[] { "", productosInventario.IdInventario, productosInventario.oProducto.IdProducto, productosInventario.oProducto.Nombre,  productosInventario.Cantidad, productosInventario.oZonaAlmacen.IdZona, productosInventario.oZonaAlmacen.NombreZona });
            }
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (TablaInventario.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in TablaInventario.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in TablaInventario.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[6].Value.ToString()
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

            foreach (DataGridViewRow row in TablaInventario.Rows)
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
                foreach (DataGridViewRow row in TablaInventario.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbProducto.SelectedItem;
            dynamic selectedItemCmb2 = CmbZonaAlmacen.SelectedItem;
            string mensaje = string.Empty;

            if (selectedItemCmb1 == null || selectedItemCmb2 == null)
            {
                string mensajeError = "Por favor, debe seleccionar una opción:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Nombre Producto.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Zona almacén.\n";

                MessageBox.Show(mensajeError, "Error en el ComboBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Inventario agregarProductoInventario = new Inventario()
            {
                oProducto = new Producto { IdProducto = selectedItemCmb1.IdProducto, Nombre = selectedItemCmb1.Nombre.ToString() },
                Cantidad = Convert.ToInt32(TxtCantidad.Text),
                oZonaAlmacen = new Zona_Almacen { IdZona = selectedItemCmb2.Valor, NombreZona = selectedItemCmb2.Texto.ToString() }
            };

            List<Producto> listaProducto = new CN_Producto().ListarProducto();
            Producto productoSeleccionado = listaProducto.FirstOrDefault(c => c.IdProducto == selectedItemCmb1.IdProducto);
            if (productoSeleccionado != null && !productoSeleccionado.Estado)
            {
                MessageBox.Show("El producto seleccionado no está habilitado. Por favor, seleccione un producto activo.", "Producto no habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                return;
            }

            int idInventarioIngresado = new CN_Inventario().Registrar(agregarProductoInventario, out mensaje);
            if (idInventarioIngresado != 0)
            {
                TablaInventario.Rows.Add(new object[] { "", idInventarioIngresado, selectedItemCmb1.IdProducto, selectedItemCmb1.Nombre, TxtCantidad.Text, selectedItemCmb2.Valor, selectedItemCmb2.Texto });

                MessageBox.Show("El producto fue registrado correctamente en el inventario.", "Registrar productos al inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo registrar el producto en el Inventario: {mensaje}", "Error al registrar el producto al inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbProducto.SelectedItem;
            dynamic selectedItemCmb2 = CmbZonaAlmacen.SelectedItem;
            string mensaje;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null)
            {
                string mensajeError = "Por favor, debe seleccionar una opción:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Nombre Producto.\n";
                if (selectedItemCmb1 == null) mensajeError += "- Ubicación almacén.\n";

                MessageBox.Show(mensajeError, "Error en el ComboBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si hay errores
            }


            // Crear el objeto Inventario
            Inventario editarProductoInventario = new Inventario()
            {
                IdInventario = Convert.ToInt32(TxtId.Text),
                oProducto = new Producto { IdProducto = selectedItemCmb1.IdProducto, Nombre = selectedItemCmb1.Nombre.ToString() },
                Cantidad = Convert.ToInt32(TxtCantidad.Text),
                oZonaAlmacen = new Zona_Almacen {IdZona = selectedItemCmb2.Valor, NombreZona = selectedItemCmb2.Texto.ToString() }
            };

            // Delegar la validación y edición a la lógica de negocio
            bool modificar = new CN_Inventario().Editar(editarProductoInventario, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El producto fue modificado correctamente en el inventario.", "Modificar producto en el inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(TxtIndice.Text);
                TablaInventario.Rows[indice].Cells["IDPRODUCTO"].Value = editarProductoInventario.oProducto.IdProducto;
                TablaInventario.Rows[indice].Cells["NombreProductos"].Value = editarProductoInventario.oProducto.Nombre;
                TablaInventario.Rows[indice].Cells["Cantidad"].Value = editarProductoInventario.Cantidad;
                TablaInventario.Rows[indice].Cells["IDZONA"].Value = editarProductoInventario.oZonaAlmacen.IdZona;
                TablaInventario.Rows[indice].Cells["ZonaAlmacen"].Value= editarProductoInventario.oZonaAlmacen.NombreZona;
                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo modificar el producto en el inventario: {mensaje}", "Modificar producto en el inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla una categoría seleccionada
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar un Producto qu esta en el Inventario en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    TablaInventario.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                    MessageBox.Show("El producto fue eliminado correctamente del inventario.", "Eliminar producto del inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Eliminar producto del inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.RowIndex >= 0 && e.ColumnIndex == TablaInventario.Columns["ZonaAlmacen"].Index)
            {
                int zonaId = Convert.ToInt32(TablaInventario.Rows[e.RowIndex].Cells["IDZONA"].Value);

                if (zonaColors.ContainsKey(zonaId))
                {
                    e.CellStyle.BackColor = zonaColors[zonaId];
                }
            }
        }

        private void TablaInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaInventario.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = TablaInventario.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCantidad.Text = TablaInventario.Rows[indice].Cells["Cantidad"].Value.ToString();

                    foreach (dynamic item in CmbZonaAlmacen.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (TablaInventario.Rows[indice].Cells["ZonaAlmacen"].Value.ToString() == item.Texto)
                        {
                            int indice_cmb = CmbZonaAlmacen.Items.IndexOf(item);
                            CmbZonaAlmacen.SelectedIndex = indice_cmb;
                            break;
                        }
                    }

                    foreach (dynamic item in CmbProducto.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.IdProducto;
                        string texto = item.Nombre;

                        if (TablaInventario.Rows[indice].Cells["NombreProductos"].Value.ToString() == item.Nombre)
                        {
                            int indice_cmb = CmbProducto.Items.IndexOf(item);
                            CmbProducto.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método que limpia los campos del formulario.
        /// </summary>
        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            CmbProducto.SelectedIndex = 0;
            TxtCantidad.Text = "0";
            TbBarraCantidadProducto.Value = 0;
            CmbZonaAlmacen.SelectedIndex = 0;
        }

        private void CmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProducto.SelectedItem != null)
            {
                Producto productoSeleccionado = CmbProducto.SelectedItem as Producto;
                if (productoSeleccionado != null)
                {
                    int idProducto = productoSeleccionado.IdProducto;
                    int stockProducto = new CN_Producto().ObtenerStockId(idProducto);
                    lblCantidadProducto.Text = $"Stock disponible: {stockProducto}";

                    TbBarraCantidadProducto.Minimum = 0;
                    TbBarraCantidadProducto.Maximum = stockProducto;
                    TbBarraCantidadProducto.Value = 0; // Resetear el valor a 1
                }
            }
            else
            {
                lblCantidadProducto.Text = "Seleccione un producto";
                TbBarraCantidadProducto.Minimum = 0;
                TbBarraCantidadProducto.Maximum = 100;
                TbBarraCantidadProducto.Value = 0; // Resetear el valor a 1
            }
        }

        private void TbBarraCantidadProducto_Scroll(object sender, EventArgs e)
        {
            int valorActual = TbBarraCantidadProducto.Value;

            // Verificar si hay un producto seleccionado
            if (CmbProducto.SelectedItem != null)
            {
                Producto productoSeleccionado = CmbProducto.SelectedItem as Producto;
                if (productoSeleccionado != null)
                {
                    int idProducto = productoSeleccionado.IdProducto;
                    int stockProducto = new CN_Producto().ObtenerStockId(idProducto);

                    // Actualizar la etiqueta de stock
                    lblCantidadProducto.Text = $"Stock disponible: {stockProducto}";
                    TxtCantidad.Text = valorActual.ToString(); // Actualizar el TextBox con el valor de la barra
                }
            }
            else
            {
                lblCantidadProducto.Text = "Seleccione un producto";
                TbBarraCantidadProducto.Value = 0;
            }
        }
    }
}
