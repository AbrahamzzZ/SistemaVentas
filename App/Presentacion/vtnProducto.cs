using ClosedXML.Excel;
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

namespace Presentacion
{
    public partial class VtnProducto : Form
    {
        public VtnProducto()
        {
            InitializeComponent();
        }

        private void VtnProducto_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;
            List<Categoria> listaCategoria = new CN_Categoria().ListarCategoria();
            foreach (Categoria categorias in listaCategoria)
            {
                CmbCategoria.Items.Add(new { Valor = categorias.IdCategoria, Texto = categorias.Descripcion });
            }
            CmbCategoria.DisplayMember = "Texto";
            CmbCategoria.ValueMember = "Valor";
            if (CmbCategoria.Items.Count > 0)
            {
                CmbCategoria.SelectedIndex = 0;
            }
            else
            {
                CmbCategoria.Enabled = false;
            }

            List<Unidad_Medida> listaUnidadMedida = new CN_Unidad_Medida().ListarUnidadesMedida();
            foreach (Unidad_Medida unidades in listaUnidadMedida)
            {
                CmbUnidadMedida.Items.Add(new { Valor = unidades.IdUnidadMedida, Texto = unidades.Descripcion });
            }
            CmbUnidadMedida.DisplayMember = "Texto";
            CmbUnidadMedida.ValueMember = "Valor";
            if (CmbUnidadMedida.Items.Count > 0)
            {
                CmbUnidadMedida.SelectedIndex = 0;
            }
            else
            {
                CmbUnidadMedida.Enabled = false;
            }

            foreach (DataGridViewColumn columna in tablaProducto.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            TxtCodigo.Text = GenerarCodigo(4);
            List<Producto> mostrarProducto = new CN_Producto().ListarProducto();
            foreach (Producto productos in mostrarProducto)
            {
                tablaProducto.Rows.Add(new object[] { "", productos.IdProducto, productos.Codigo, productos.Nombre, productos.Descripcion, productos.oCategoria.IdCategoria, productos.oCategoria.Descripcion, productos.oUnidadMedida.IdUnidadMedida, productos.oUnidadMedida.Descripcion, productos.PaisOrigen, productos.Stock, productos.PrecioCompra, productos.PrecioVenta, productos.Estado == true ? 1 : 0, productos.Estado == true ? "Activo" : "No Activo" });
            }
            TxtNombre.Select();
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaProducto.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaProducto.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaProducto.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(),  row.Cells[12].Value.ToString(), row.Cells[14].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Lista_Productos.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Productos");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(guardar.FileName);
                        MessageBox.Show("Excel generado correctamente", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            foreach (DataGridViewRow row in tablaProducto.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaProducto.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbCategoria.SelectedItem;
            dynamic selectedItemCmb2 = CmbUnidadMedida.SelectedItem;
            dynamic selectedItemCmb3 = CmbEstado.SelectedItem;
            string mensaje = string.Empty;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null || selectedItemCmb3 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Categoría del Producto.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Unidad de medida del Producto.\n";
                if (selectedItemCmb3 == null) mensajeError += "- Estado del Producto\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto Producto
            Producto agregarProducto = new Producto()
            {
                IdProducto = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Nombre = TxtNombre.Text,
                Descripcion = TxtDescripcion.Text,
                PaisOrigen = TxtPaisOrigen.Text,
                oCategoria = new Categoria { IdCategoria = selectedItemCmb1.Valor },
                oUnidadMedida = new Unidad_Medida { IdUnidadMedida = selectedItemCmb2.Valor },
                Estado = selectedItemCmb3.Valor == 1
            };

            List<Categoria> listaCategoria = new CN_Categoria().ListarCategoria();
            Categoria categoriaSeleccionada = listaCategoria.FirstOrDefault(c => c.IdCategoria == selectedItemCmb1.Valor);
            if (categoriaSeleccionada != null && !categoriaSeleccionada.Estado)
            {
                MessageBox.Show("La categoría seleccionada no está habilitada. Por favor, seleccione una categoría activa.", "Categoría no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                return;
            }

            List<Unidad_Medida> listaUnidadMedida = new CN_Unidad_Medida().ListarUnidadesMedida();
            Unidad_Medida unidadMedidaSeleccionada = listaUnidadMedida.FirstOrDefault(c => c.IdUnidadMedida == selectedItemCmb2.Valor);
            if (unidadMedidaSeleccionada != null && !unidadMedidaSeleccionada.Estado)
            {
                MessageBox.Show("La unidad de medida seleccionada no está habilitada. Por favor, seleccione una unidad de medida activa.", "Unidad de medida no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                return;
            }

            int idProductoIngresado = new CN_Producto().Registrar(agregarProducto, out mensaje);
            if (idProductoIngresado != 0)
            {

                tablaProducto.Rows.Add(new object[] { "", idProductoIngresado, TxtCodigo.Text, TxtNombre.Text, TxtDescripcion.Text, selectedItemCmb1.Valor, selectedItemCmb1.Texto, selectedItemCmb2.Valor, selectedItemCmb2.Texto, TxtPaisOrigen.Text, "0", "0.00", "0.00", selectedItemCmb3.Valor, selectedItemCmb3.Texto });
                MessageBox.Show("El producto fue registrado correctamente.", "Registrar producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();

            }
            else
            {
                MessageBox.Show($"No se pudo registrar el usuario: {mensaje}", "Error al Registrar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbCategoria.SelectedItem;
            dynamic selectedItemCmb2 = CmbUnidadMedida.SelectedItem;
            dynamic selectedItemCmb3 = CmbEstado.SelectedItem;
            string mensaje;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null || selectedItemCmb3 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Categoría del Producto.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Unidad de medida del Producto.\n";
                if (selectedItemCmb3 == null) mensajeError += "- Estado del Producto\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto Producto
            Producto productoModificado = new Producto()
            {
                IdProducto = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Nombre = TxtNombre.Text,
                Descripcion = TxtDescripcion.Text,
                oCategoria = new Categoria { IdCategoria = selectedItemCmb1.Valor },
                oUnidadMedida = new Unidad_Medida { IdUnidadMedida = selectedItemCmb2.Valor},
                PaisOrigen = TxtPaisOrigen.Text,
                Estado = selectedItemCmb3.Valor == 1
            };

            // Delegar la validación y edición a la lógica de negocio
            bool modificar = new CN_Producto().Editar(productoModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La información del producto fue modificado correctamente.", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla con los datos modificados
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaProducto.Rows[indice].Cells["Codigo"].Value = productoModificado.Codigo;
                tablaProducto.Rows[indice].Cells["Producto"].Value = productoModificado.Nombre;
                tablaProducto.Rows[indice].Cells["Descripcion"].Value = productoModificado.Descripcion;
                tablaProducto.Rows[indice].Cells["IDCATEGORIA"].Value = productoModificado.oCategoria.IdCategoria;
                tablaProducto.Rows[indice].Cells["Categoria"].Value = selectedItemCmb1.Texto;
                tablaProducto.Rows[indice].Cells["IDUNIDADMEDIDA"].Value = productoModificado.oUnidadMedida.IdUnidadMedida;
                tablaProducto.Rows[indice].Cells["UnidadMedida"].Value = selectedItemCmb2.Texto;
                tablaProducto.Rows[indice].Cells["PaisOrigen"].Value = productoModificado.PaisOrigen;
                tablaProducto.Rows[indice].Cells["EstadoValor"].Value = productoModificado.Estado ? 1 : 0;
                tablaProducto.Rows[indice].Cells["Estado"].Value = productoModificado.Estado ? "Activo" : "No Activo";

                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo modificar la información del usuario: {mensaje}", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla un usuario seleccionado
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar un Producto en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea eliminar este producto?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                Producto productoEliminado = new Producto()
                {
                    IdProducto = Convert.ToInt32(TxtId.Text),
                };
                bool respuesta = new CN_Producto().Eliminar(productoEliminado, out mensaje);
                if (respuesta)
                {
                    tablaProducto.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                    MessageBox.Show("El producto fue eliminado correctamente.", "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TablaProducto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaProducto.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaProducto.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void TablaProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaProducto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaProducto.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaProducto.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombre.Text = tablaProducto.Rows[indice].Cells["Producto"].Value.ToString();
                    TxtDescripcion.Text = tablaProducto.Rows[indice].Cells["Descripcion"].Value.ToString();
                    TxtPaisOrigen.Text = tablaProducto.Rows[indice].Cells["PaisOrigen"].Value.ToString();

                    foreach (dynamic item in CmbCategoria.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaProducto.Rows[indice].Cells["IDCATEGORIA"].Value))
                        {
                            int indice_cmb = CmbCategoria.Items.IndexOf(item);
                            CmbCategoria.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in CmbUnidadMedida.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaProducto.Rows[indice].Cells["IDUNIDADMEDIDA"].Value))
                        {
                            int indice_cmb = CmbUnidadMedida.Items.IndexOf(item);
                            CmbUnidadMedida.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaProducto.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = CmbEstado.Items.IndexOf(item);
                            CmbEstado.SelectedIndex = indice_cmb;
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
            TxtCodigo.Text = GenerarCodigo(4);
            TxtNombre.Clear();
            TxtDescripcion.Clear();
            TxtPaisOrigen.Clear();
            CmbCategoria.SelectedIndex = 0;
            CmbEstado.SelectedIndex = 0;
        }

        /// <summary>
        /// Método que genera un código aleatorio de una longitud específica.
        /// </summary>
        /// <param name="longitud">La longitud del código a generar.</param>
        /// <returns>Un string con el código generado.</returns>
        private string GenerarCodigo(int longitud)
        {
            const string caracteres = "0123456789";
            Random randon = new Random();
            char[] resultado = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                resultado[i] = caracteres[randon.Next(caracteres.Length)];
            }
            return new string(resultado);
        }
    }
}
