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
    public partial class vtnInventario : Form
    {
        private Producto producto;
        public vtnInventario()
        {
            InitializeComponent();
        }

        private void vtnInventario_Load(object sender, EventArgs e)
        {
            cmb3.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmb3.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmb3.DisplayMember = "Texto";
            cmb3.ValueMember = "Valor";
            cmb3.SelectedIndex = 0;
            List<Producto> listaProducto = new CN_Producto().ListarProducto();
            foreach (Producto productos in listaProducto)
            {
                cmb2.Items.Add(new { Valor = productos.IdProducto, Texto = productos.Nombre });
            }
            cmb2.DisplayMember = "Texto";
            cmb2.ValueMember = "Valor";
            if (cmb2.Items.Count > 0)
            {
                cmb2.SelectedIndex = 0;
            }
            else
            {
                cmb2.Enabled = false;
            }

            List<Producto> listaProductoCodigo = new CN_Producto().ListarProducto();
            foreach (Producto productos in listaProductoCodigo)
            {
                cmb1.Items.Add(new { Valor = productos.IdProducto, Texto = productos.Codigo });
            }
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            if (cmb1.Items.Count > 0)
            {
                cmb1.SelectedIndex = 0;
            }
            else
            {
                cmb1.Enabled = false;
            }

            foreach (DataGridViewColumn columna in tablaInventario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb4.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb4.DisplayMember = "Texto";
            cmb4.ValueMember = "Valor";
            cmb4.SelectedIndex = 0;
            List<Inventario> mostrarInventario = new CN_Inventario().ListarProductoInventario();
            foreach (Inventario productosInventario in mostrarInventario)
            {
                tablaInventario.Rows.Add(new object[] { "", productosInventario.IdInventario, productosInventario.oProducto.IdProducto, productosInventario.oProducto.Codigo, productosInventario.oProducto.Nombre, productosInventario.Cantidad, productosInventario.UbicacionAlmacen, productosInventario.Estado == true ? 1 : 0, productosInventario.Estado == true ? "Activo" : "No Activo" });
            }
            txt4.Select();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb4 = cmb4.SelectedItem;
            string valorCmb4 = selectedItemCmb4.Valor;
            string columnaFiltro = valorCmb4.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaInventario.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt6.Text.Trim().ToUpper()))
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
                txt6.Text = "";
                foreach (DataGridViewRow row in tablaInventario.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            dynamic selectedItemCmb3 = cmb3.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            int valorCmb3 = selectedItemCmb3.Valor;
            string textoCmb3 = selectedItemCmb3.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Cantidad del producto\n";
                if (string.IsNullOrWhiteSpace(txt5.Text)) mensajeError += "- Ubicacion en el almacen del producto\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int cantidadComprada = new CN_Compra().CantidadProductoComprado(valorCmb1);
                int cantidadIngresada = Convert.ToInt32(txt4.Text);
                if (cantidadIngresada > cantidadComprada)
                {
                    MessageBox.Show("No se puede ingresar un producto más de lo que se compró.", "Agregar producto al inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Inventario agregarProductoInventario = new Inventario()
                {
                    IdInventario = Convert.ToInt32(txt2.Text),
                    oProducto = new Producto { IdProducto = valorCmb1, Codigo = textoCmb1.ToString(), Nombre = textoCmb2.ToString() },
                    Cantidad = Convert.ToInt32(txt4.Text),
                    UbicacionAlmacen = txt5.Text,
                    Estado = valorCmb3 == 1
                };
                List<Producto> listaProducto = new CN_Producto().ListarProducto();
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
                            tablaInventario.Rows.Add(new object[] { "", idInventarioIngresado, valorCmb1, textoCmb1, textoCmb2, txt4.Text, txt5.Text, valorCmb3, textoCmb3 });
                            MessageBox.Show("El producto fue agregado correctamente en el inventario.", "Agregar productos al inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla inventario");
                        }
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            dynamic selectedItemCmb3 = cmb3.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            int valorCmb3 = selectedItemCmb3.Valor;
            string textoCmb3 = selectedItemCmb3.Texto;
            string mensaje;

            Inventario editarProductoInventario = new Inventario()
            {
                IdInventario = Convert.ToInt32(txt2.Text),
                oProducto = new Producto { IdProducto = valorCmb1, Codigo = textoCmb1.ToString(), Nombre = textoCmb2.ToString() },
                Cantidad = Convert.ToInt32(txt4.Text),
                UbicacionAlmacen = txt5.Text,
                Estado = valorCmb3 == 1
            };
            bool modificar = new CN_Inventario().Editar(editarProductoInventario, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El producto fue modificado correctamente en el inventario.", "Modificar producto en el inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(txt1.Text);
                tablaInventario.Rows[indice].Cells["IDPRODUCTO"].Value = editarProductoInventario.oProducto.IdProducto;
                tablaInventario.Rows[indice].Cells["CodigoProducto"].Value = editarProductoInventario.oProducto.Codigo;
                tablaInventario.Rows[indice].Cells["NombreProductos"].Value = editarProductoInventario.oProducto.Nombre;
                tablaInventario.Rows[indice].Cells["Cantidad"].Value = editarProductoInventario.Cantidad;
                tablaInventario.Rows[indice].Cells["UbicacionAlmacen"].Value = editarProductoInventario.UbicacionAlmacen;
                tablaInventario.Rows[indice].Cells["EstadoValor"].Value = editarProductoInventario.Estado ? 1 : 0;
                tablaInventario.Rows[indice].Cells["Estado"].Value = editarProductoInventario.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar el producto: " + mensaje, "Modificar producto en el inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text))
            {
                MessageBox.Show("Primero debe selecionar un producto en la tabla para poder eliminarlo del inventario.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txt2.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este producto del inventario?", "Eliminar producto del inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Inventario productoEliminadoInventario = new Inventario()
                        {
                            IdInventario = Convert.ToInt32(txt2.Text),
                        };
                        bool respuesta = new CN_Inventario().Eliminar(productoEliminadoInventario, out mensaje);
                        if (respuesta)
                        {
                            tablaInventario.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
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

        private void tablaInventario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void tablaInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaInventario.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaInventario.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaInventario.Rows[indice].Cells["IDPRODUCTO"].Value.ToString();
                    txt4.Text = tablaInventario.Rows[indice].Cells["Cantidad"].Value.ToString();
                    txt5.Text = tablaInventario.Rows[indice].Cells["UbicacionAlmacen"].Value.ToString();

                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if (tablaInventario.Rows[indice].Cells["CodigoProducto"].Value.ToString() == item.Texto)
                        {
                            int indice_cmb = cmb1.Items.IndexOf(item);
                            cmb1.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in cmb2.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (tablaInventario.Rows[indice].Cells["NombreProductos"].Value.ToString() == item.Texto)
                        {
                            int indice_cmb = cmb2.Items.IndexOf(item);
                            cmb2.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in cmb3.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaInventario.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = cmb3.Items.IndexOf(item);
                            cmb3.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }
        public void Limpiar()
        {
            txt1.Text = "-1";
            txt2.Text = "0";
            txt3.Text = "0";
            cmb1.SelectedIndex = 0;
            cmb2.SelectedIndex = 0;
            txt4.Text = "";
            txt5.Text = "";
            cmb3.SelectedIndex = 0;
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar !=' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Ubicación en el almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
