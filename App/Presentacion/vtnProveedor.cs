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
    public partial class VtnProveedor : Form
    {
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
            TxtNoDocumento.Text = GenerarCodigo(4);
            List<Proveedor> mostrarProveedor = new CN_Proveedor().ListarProveedores();
            foreach (Proveedor proveedor in mostrarProveedor)
            {
                tablaProveedores.Rows.Add(new object[] { "", proveedor.IdProveedor, proveedor.Documento, proveedor.Nombres, proveedor.Apellidos, proveedor.Cedula, proveedor.Telefono, proveedor.CorreoElectronico, proveedor.Estado == true ? 1 : 0, proveedor.Estado == true ? "Activo" : "No Activo" });
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
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(TxtNoDocumento.Text) || string.IsNullOrWhiteSpace(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text) || string.IsNullOrWhiteSpace(TextCedula.Text) || string.IsNullOrWhiteSpace(TxtTelefono.Text) || string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(TxtNoDocumento.Text)) mensajeError += "- Número del documento del proveedor.\n";
                if (string.IsNullOrWhiteSpace(TxtNombres.Text)) mensajeError += "- Nombres del proveedor.\n";
                if (string.IsNullOrWhiteSpace(TxtApellidos.Text)) mensajeError += "- Apellidos del proveedor.\n";
                if (string.IsNullOrWhiteSpace(TextCedula.Text)) mensajeError += "- Cedula del proveedor.\n";
                if (string.IsNullOrWhiteSpace(TxtTelefono.Text)) mensajeError += "- Telefono del proveedor.\n";
                if (string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text)) mensajeError += "- Correo electrónico del proveedor.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Proveedor agregarProveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(TxtId.Text),
                    Documento = TxtNoDocumento.Text,
                    Nombres = TxtNombres.Text,
                    Apellidos = TxtApellidos.Text,
                    Cedula = TextCedula.Text,
                    Telefono = TxtTelefono.Text,
                    CorreoElectronico = TxtCorreoElectronico.Text,
                    Estado = valorCmb1 == 1
                };
                int idProveedorIngresado = new CN_Proveedor().Registrar(agregarProveedor, out mensaje);
                if (idProveedorIngresado != 0)
                {
                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null)
                    {
                        tablaProveedores.Rows.Add(new object[] { "", idProveedorIngresado, TxtNoDocumento.Text, TxtNombres.Text, TxtApellidos.Text, TextCedula.Text, TxtTelefono.Text, TxtCorreoElectronico.Text, valorCmb1, textoCmb1 });
                        MessageBox.Show("El proveedor fue agregado correctamente.", "Agregar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Proveedor");
                    }
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje;

            Proveedor proveedorModificado = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(TxtId.Text),
                Documento = TxtNoDocumento.Text,
                Nombres = TxtNombres.Text,
                Apellidos = TxtApellidos.Text,
                Cedula = TextCedula.Text,
                Telefono = TxtTelefono.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
                Estado = valorCmb1 == 1
            };
            bool modificar = new CN_Proveedor().Editar(proveedorModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El proveedor fue modificado correctamente.", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaProveedores.Rows[indice].Cells["ID"].Value = proveedorModificado.IdProveedor;
                tablaProveedores.Rows[indice].Cells["Documento"].Value = proveedorModificado.Documento;
                tablaProveedores.Rows[indice].Cells["Nombres"].Value = proveedorModificado.Nombres;
                tablaProveedores.Rows[indice].Cells["Apellidos"].Value = proveedorModificado.Apellidos;
                tablaProveedores.Rows[indice].Cells["Cedula"].Value = proveedorModificado.Cedula;
                tablaProveedores.Rows[indice].Cells["Telefono"].Value = proveedorModificado.Telefono;
                tablaProveedores.Rows[indice].Cells["CorreoElectronico"].Value = proveedorModificado.CorreoElectronico;
                tablaProveedores.Rows[indice].Cells["EstadoValor"].Value = proveedorModificado.Estado ? 1 : 0;
                tablaProveedores.Rows[indice].Cells["Estado"].Value = proveedorModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNoDocumento.Text) || string.IsNullOrWhiteSpace(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text) || string.IsNullOrWhiteSpace(TextCedula.Text) || string.IsNullOrWhiteSpace(TxtTelefono.Text) || string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text))
            {
                MessageBox.Show("Primero debe selecionar un proveedor en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(TxtId.Text) != 0)
                {
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
                            MessageBox.Show(mensaje, "Eliminar proveedor");
                        }
                    }
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
                    TxtNoDocumento.Text = tablaProveedores.Rows[indice].Cells["Documento"].Value.ToString();
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

        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            TxtNoDocumento.Text = GenerarCodigo(4);
            TxtNombres.Clear();
            TxtApellidos.Clear();
            TextCedula.Clear();
            TxtTelefono.Clear();
            TxtCorreoElectronico.Clear();
            CmbEstado.SelectedIndex = 0;
        }

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

        private void TxtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void TxtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Apellidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void TextCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Cédula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
