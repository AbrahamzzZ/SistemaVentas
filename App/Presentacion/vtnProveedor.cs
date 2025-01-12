
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
    /// <summary>
    /// Clase que representa la ventana de proveedor.
    /// </summary>
    public partial class VtnProveedor : Form
    {
        /// <summary>
        /// Constructor de la clase VtnProveedor.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnProveedor()
        {
            InitializeComponent();
        }

        private void VtnProveedor_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaProveedores.Columns)
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
            List<Proveedor> mostrarProveedor = new CN_Proveedor().ListarProveedores();
            foreach (Proveedor proveedor in mostrarProveedor)
            {
                tablaProveedores.Rows.Add(new object[] { "", proveedor.IdProveedor, proveedor.Codigo, proveedor.Nombres, proveedor.Apellidos, proveedor.Cedula, proveedor.Telefono, proveedor.CorreoElectronico, proveedor.Estado == true ? 1 : 0, proveedor.Estado == true ? "Activo" : "No Activo" });
            }
            TxtNombres.Select();
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaProveedores.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaProveedores.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in tablaProveedores.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[9].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Lista_Proveedores.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Proveedores");
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
            dynamic selectedItemCmb2 = CmbBuscar.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
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
            // Verificar si hay filas visibles y mostrar un mensaje si no hay
            if (filasVisibles == 0)
            {
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaProveedores.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            string mensaje = string.Empty;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Estado del Proveedor.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto Usuario
            Proveedor agregarProveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(TxtId.Text),
                    Codigo = TxtCodigo.Text,
                    Nombres = TxtNombres.Text,
                    Apellidos = TxtApellidos.Text,
                    Cedula = TextCedula.Text,
                    Telefono = TxtTelefono.Text,
                    CorreoElectronico = TxtCorreoElectronico.Text,
                    Estado = selectedItemCmb1.Valor == 1
            };

            // Delegar la validación y registro a la lógica de negocio
            int idProveedorIngresado = new CN_Proveedor().Registrar(agregarProveedor, out mensaje);
            if (idProveedorIngresado != 0)
            {
                // Agregar a la tabla y mostrar mensaje de éxito
                tablaProveedores.Rows.Add(new object[] { "", idProveedorIngresado, TxtCodigo.Text, TxtNombres.Text, TxtApellidos.Text, TextCedula.Text, TxtTelefono.Text, TxtCorreoElectronico.Text, selectedItemCmb1.Valor, selectedItemCmb1.Texto });
                MessageBox.Show("El proveedor fue registrado correctamente.", "Registrar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                // Mostrar mensaje de error proveniente de la capa de negocio
                MessageBox.Show($"No se pudo registrar al proveedor: {mensaje}", "Error al Registrar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            string mensaje;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Estado del Proveedor.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto Proveedor
            Proveedor proveedorModificado = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Nombres = TxtNombres.Text,
                Apellidos = TxtApellidos.Text,
                Cedula = TextCedula.Text,
                Telefono = TxtTelefono.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
                Estado = selectedItemCmb1.Valor == 1
            };

            // Delegar la validación y edición a la lógica de negocio
            bool modificar = new CN_Proveedor().Editar(proveedorModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La información del proveedor fue modificado correctamente.", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla con los datos modificados
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaProveedores.Rows[indice].Cells["ID"].Value = proveedorModificado.IdProveedor;
                tablaProveedores.Rows[indice].Cells["Codigo"].Value = proveedorModificado.Codigo;
                tablaProveedores.Rows[indice].Cells["Nombres"].Value = proveedorModificado.Nombres;
                tablaProveedores.Rows[indice].Cells["Apellidos"].Value = proveedorModificado.Apellidos;
                tablaProveedores.Rows[indice].Cells["Cedula"].Value = proveedorModificado.Cedula;
                tablaProveedores.Rows[indice].Cells["Telefono"].Value = proveedorModificado.Telefono;
                tablaProveedores.Rows[indice].Cells["CorreoElectronico"].Value = proveedorModificado.CorreoElectronico;
                tablaProveedores.Rows[indice].Cells["EstadoValor"].Value = proveedorModificado.Estado ? 1 : 0;
                tablaProveedores.Rows[indice].Cells["Estado"].Value = proveedorModificado.Estado ? "Activo" : "No Activo";

                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo modificar la información del proveedor: {mensaje}", "Error al Modificar el proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla un proveedor seleccionado
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar un Proveedor en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea eliminar este proveedor?", "Eliminar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                Proveedor proveedorEliminado = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(TxtId.Text),
                };
                bool respuesta = new CN_Proveedor().Eliminar(proveedorEliminado, out mensaje);
                if (respuesta)
                {
                    tablaProveedores.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                    MessageBox.Show("El proveedor fue eliminado correctamente.", "Eliminar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Eliminar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TablaProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaProveedores.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaProveedores.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void TablaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaProveedores.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaProveedores.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaProveedores.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombres.Text = tablaProveedores.Rows[indice].Cells["Nombres"].Value.ToString();
                    TxtApellidos.Text = tablaProveedores.Rows[indice].Cells["Apellidos"].Value.ToString();
                    TextCedula.Text = tablaProveedores.Rows[indice].Cells["Cedula"].Value.ToString();
                    TxtTelefono.Text = tablaProveedores.Rows[indice].Cells["Telefono"].Value.ToString();
                    TxtCorreoElectronico.Text = tablaProveedores.Rows[indice].Cells["CorreoElectronico"].Value.ToString();

                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaProveedores.Rows[indice].Cells["EstadoValor"].Value))
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
            TxtNombres.Clear();
            TxtApellidos.Clear();
            TextCedula.Clear();
            TxtTelefono.Clear();
            TxtCorreoElectronico.Clear();
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
