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
    public partial class vtnProducto : Form
    {
        public vtnProducto()
        {
            InitializeComponent();
        }

        private void vtnProducto_Load(object sender, EventArgs e)
        {
            cmb3.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmb3.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmb3.DisplayMember = "Texto";
            cmb3.ValueMember = "Valor";
            cmb3.SelectedIndex = 0;
            List<Categoria> listaCategoria = new CN_Categoria().ListarCategoria();
            foreach (Categoria categorias in listaCategoria)
            {
                cmb1.Items.Add(new { Valor = categorias.IdCategoria, Texto = categorias.Descripcion });
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

            List<Unidad_Medida> listaUnidadMedida = new CN_Unidad_Medida().ListarUnidadesMedida();
            foreach (Unidad_Medida unidades in listaUnidadMedida)
            {
                cmb2.Items.Add(new { Valor = unidades.IdUnidadMedida, Texto = unidades.Descripcion });
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

            foreach (DataGridViewColumn columna in tablaProducto.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb4.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb4.DisplayMember = "Texto";
            cmb4.ValueMember = "Valor";
            cmb4.SelectedIndex = 0;
            //Mostrar todos los productos existentes en la tabla
            List<Producto> mostrarProducto = new CN_Producto().ListarProducto();
            foreach (Producto productos in mostrarProducto)
            {
                tablaProducto.Rows.Add(new object[] { "", productos.IdProducto, productos.Codigo, productos.Nombre, productos.Descripcion, productos.oCategoria.IdCategoria, productos.oCategoria.Descripcion, productos.oUnidadMedida.IdUnidadMedida, productos.oUnidadMedida.Descripcion, productos.PaisOrigen, productos.Stock, productos.PrecioCompra, productos.PrecioVenta, productos.Estado == true ? 1 : 0, productos.Estado == true ? "Activo" : "No Activo" });
            }
            txt3.Select();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb4 = cmb4.SelectedItem;
            string valorCmb4 = selectedItemCmb4.Valor;
            string columnaFiltro = valorCmb4.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaProducto.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt7.Text.Trim().ToUpper()))
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
                txt7.Text = "";
                foreach (DataGridViewRow row in tablaProducto.Rows)
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

            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt6.Text) || string.IsNullOrWhiteSpace(txt5.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(txt3.Text)) mensajeError += "- Código del producto\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Nombre del producto\n";
                if (string.IsNullOrWhiteSpace(txt5.Text)) mensajeError += "- Descripción del producto\n";
                if (string.IsNullOrWhiteSpace(txt6.Text)) mensajeError += "- País de origen del producto\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Producto agregarProducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txt2.Text),
                    Codigo = txt3.Text,
                    Nombre = txt4.Text,
                    Descripcion = txt5.Text,
                    PaisOrigen = txt6.Text,
                    oCategoria = new Categoria { IdCategoria = valorCmb1 },
                    oUnidadMedida = new Unidad_Medida { IdUnidadMedida = valorCmb2},
                    Estado = valorCmb3 == 1
                };
                List<Categoria> listaCategoria = new CN_Categoria().ListarCategoria();
                Categoria categoriaSeleccionada = listaCategoria.FirstOrDefault(c => c.IdCategoria == valorCmb1);
                if (categoriaSeleccionada != null && !categoriaSeleccionada.Estado) 
                {
                    MessageBox.Show("La categoría seleccionada no está habilitada. Por favor, seleccione una categoría activa.", "Categoría no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    return; 
                }
                List<Unidad_Medida> listaUnidadMedida = new CN_Unidad_Medida().ListarUnidadesMedida();
                Unidad_Medida unidadMedidaSeleccionada = listaUnidadMedida.FirstOrDefault(c => c.IdUnidadMedida == valorCmb2);
                if (unidadMedidaSeleccionada != null && !unidadMedidaSeleccionada.Estado) 
                {
                    MessageBox.Show("La unidad de medida seleccionada no está habilitada. Por favor, seleccione una unidad de medida activa.", "Unidad de medida no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    return;
                }
                int idProductoIngresado = new CN_Producto().Registrar(agregarProducto, out mensaje);
                if (idProductoIngresado != 0)
                {
                // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null && selectedItemCmb3 != null)
                    {
                        tablaProducto.Rows.Add(new object[] { "", idProductoIngresado, txt3.Text, txt4.Text, txt5.Text, valorCmb1, textoCmb1, valorCmb2, textoCmb2, txt6.Text, "0", "0.00", "0.00", valorCmb3, textoCmb3 });
                        MessageBox.Show("El producto fue agregado correctamente.", "Agregar producto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Producto");
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

            Producto productoModificado = new Producto()
            {
                IdProducto = Convert.ToInt32(txt2.Text),
                Codigo = txt3.Text,
                Nombre = txt4.Text,
                Descripcion = txt5.Text,
                oCategoria = new Categoria { IdCategoria = valorCmb1 },
                oUnidadMedida = new Unidad_Medida { IdUnidadMedida = valorCmb2},
                PaisOrigen = txt6.Text,
                Estado = valorCmb3 == 1
            };
            bool modificar = new CN_Producto().Editar(productoModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El producto fue modificado correctamente.", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(txt1.Text);
                tablaProducto.Rows[indice].Cells["Codigo"].Value = productoModificado.Codigo;
                tablaProducto.Rows[indice].Cells["Producto"].Value = productoModificado.Nombre;
                tablaProducto.Rows[indice].Cells["Descripcion"].Value = productoModificado.Descripcion;
                tablaProducto.Rows[indice].Cells["IDCATEGORIA"].Value = productoModificado.oCategoria.IdCategoria;
                tablaProducto.Rows[indice].Cells["Categoria"].Value = textoCmb1;
                tablaProducto.Rows[indice].Cells["IDUNIDADMEDIDA"].Value = productoModificado.oUnidadMedida.IdUnidadMedida;
                tablaProducto.Rows[indice].Cells["UnidadMedida"].Value = textoCmb2;
                tablaProducto.Rows[indice].Cells["PaisOrigen"].Value = productoModificado.PaisOrigen;
                tablaProducto.Rows[indice].Cells["EstadoValor"].Value = productoModificado.Estado ? 1 : 0;
                tablaProducto.Rows[indice].Cells["Estado"].Value = productoModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar el producto: " + mensaje, "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt6.Text) || string.IsNullOrWhiteSpace(txt5.Text))
            {
                MessageBox.Show("Primero debe selecionar un producto en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (Convert.ToInt32(txt2.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este producto?", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Producto productoEliminado = new Producto()
                        {
                            IdProducto = Convert.ToInt32(txt2.Text),
                        };
                        bool respuesta = new CN_Producto().Eliminar(productoEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaProducto.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
                            MessageBox.Show("El producto fue eliminado correctamente.", "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void tablaProducto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void tablaProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaProducto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaProducto.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaProducto.Rows[indice].Cells["Codigo"].Value.ToString();
                    txt4.Text = tablaProducto.Rows[indice].Cells["Producto"].Value.ToString();
                    txt5.Text = tablaProducto.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txt6.Text = tablaProducto.Rows[indice].Cells["PaisOrigen"].Value.ToString();

                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaProducto.Rows[indice].Cells["IDCATEGORIA"].Value))
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

                        if (valor == Convert.ToInt32(tablaProducto.Rows[indice].Cells["IDUNIDADMEDIDA"].Value))
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

                        if (valor == Convert.ToInt32(tablaProducto.Rows[indice].Cells["EstadoValor"].Value))
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
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            txt6.Clear();
            cmb1.SelectedIndex = 0;
            cmb3.SelectedIndex = 0;
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Código", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombre del producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo País de origen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
