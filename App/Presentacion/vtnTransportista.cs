using ClosedXML.Excel;
using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class VtnTransportista : Form
    {
        byte[] imagen = null;
        public VtnTransportista()
        {
            InitializeComponent();
        }

        private void VtnTransportista_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaTransportista.Columns)
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
            List<Transportista> mostrarTransportista = new CN_Transportista().ListarTransportista();
            foreach (Transportista transportista in mostrarTransportista)
            {
                tablaTransportista.Rows.Add(new object[] { "", transportista.IdTransportista, transportista.Codigo, transportista.Nombres, transportista.Apellidos, transportista.Cedula, transportista.Telefono, transportista.CorreoElectronico, transportista.Imagen, transportista.Estado == true ? 1 : 0, transportista.Estado == true ? "Activo" : "No Activo" });
            }
            TxtNombres.Select();
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.Jpg; *.png; *.Gif) |*.Jpg; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FotoTransportista.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                using (MemoryStream stream = new MemoryStream())
                {
                    FotoTransportista.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imagen = stream.ToArray();
                }
            }
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaTransportista.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();

                int columnIndex = 0;
                foreach (DataGridViewColumn columna in tablaTransportista.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible && columna.Index != 8)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                        columnIndex++;
                    }
                }

                foreach (DataGridViewRow row in tablaTransportista.Rows)
                {
                    if (row.Visible)
                    {
                        object[] rowData = new object[columnIndex];

                        int rowIndex = 0;
                        foreach (DataGridViewColumn columna in tablaTransportista.Columns)
                        {
                            if (columna.HeaderText != "" && columna.Visible && columna.Index != 8)
                            {
                                rowData[rowIndex++] = row.Cells[columna.Index].Value?.ToString();
                            }
                        }

                        dt.Rows.Add(rowData);
                    }
                }

                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Lista_Transportistas.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Transportistas");
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
            dynamic selectedItemCmb2 = CmbBuscar.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaTransportista.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaTransportista.Rows)
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
            if (string.IsNullOrWhiteSpace(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text) || string.IsNullOrWhiteSpace(TxtCedula.Text) || string.IsNullOrWhiteSpace(TxtTelefono.Text) || string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text) || FotoTransportista.Image == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(TxtNombres.Text)) mensajeError += "- Nombres del transportista.\n";
                if (string.IsNullOrWhiteSpace(TxtApellidos.Text)) mensajeError += "- Apellidos del transportista.\n";
                if (string.IsNullOrWhiteSpace(TxtCedula.Text)) mensajeError += "- Cedula del transportista.\n";
                if (string.IsNullOrWhiteSpace(TxtTelefono.Text)) mensajeError += "- Telefono del transportista.\n";
                if (string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text)) mensajeError += "- Correo electrónico del transportista.\n";
                if (string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text)) mensajeError += "- Correo electrónico del transportista.\n";
                if (FotoTransportista.Image == null) mensajeError += "- Foto del transportista.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Transportista agregarTransportista = new Transportista()
                {
                    IdTransportista = Convert.ToInt32(TxtId.Text),
                    Codigo = TxtCodigo.Text,
                    Nombres = TxtNombres.Text,
                    Apellidos = TxtApellidos.Text,
                    Cedula = TxtCedula.Text,
                    Telefono = TxtTelefono.Text,
                    CorreoElectronico = TxtCorreoElectronico.Text,
                    Estado = valorCmb1 == 1
                };
                int idTransportistaIngresado = new CN_Transportista().Registrar(agregarTransportista, imagen, out mensaje);
                if (idTransportistaIngresado != 0)
                {
                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null)
                    {
                        tablaTransportista.Rows.Add(new object[] { "", idTransportistaIngresado, TxtCodigo.Text, TxtNombres.Text, TxtApellidos.Text, TxtCedula.Text, TxtTelefono.Text, TxtCorreoElectronico.Text, ImageToByteArray(FotoTransportista.Image), valorCmb1, textoCmb1 });
                        MessageBox.Show("El transportista fue agregado correctamente.", "Agregar transportista", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Transportista");
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

            Transportista transportistaModificado = new Transportista()
            {
                IdTransportista = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Nombres = TxtNombres.Text,
                Apellidos = TxtApellidos.Text,
                Cedula = TxtCedula.Text,
                Telefono = TxtTelefono.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
                Estado = valorCmb1 == 1
            };
            if (FotoTransportista.Image != null)
            {
                imagen = ImageToByteArray(FotoTransportista.Image);
            }
            bool modificar = new CN_Transportista().Editar(transportistaModificado, imagen, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El transportista fue modificado correctamente.", "Modificar transportista", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaTransportista.Rows[indice].Cells["Codigo"].Value = transportistaModificado.Codigo;
                tablaTransportista.Rows[indice].Cells["Nombres"].Value = transportistaModificado.Nombres;
                tablaTransportista.Rows[indice].Cells["Apellidos"].Value = transportistaModificado.Apellidos;
                tablaTransportista.Rows[indice].Cells["Cedula"].Value = transportistaModificado.Cedula;
                tablaTransportista.Rows[indice].Cells["Telefono"].Value = transportistaModificado.Telefono;
                tablaTransportista.Rows[indice].Cells["CorreoElectronico"].Value = transportistaModificado.CorreoElectronico;
                tablaTransportista.Rows[indice].Cells["Image"].Value = imagen;
                tablaTransportista.Rows[indice].Cells["EstadoValor"].Value = transportistaModificado.Estado ? 1 : 0;
                tablaTransportista.Rows[indice].Cells["Estado"].Value = transportistaModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar el transportista: " + mensaje, "Modificar tranportista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) || string.IsNullOrWhiteSpace(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text) || string.IsNullOrWhiteSpace(TxtCedula.Text) || string.IsNullOrWhiteSpace(TxtTelefono.Text) || string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text) || FotoTransportista.Image == null)
            {
                MessageBox.Show("Primero debe selecionar un transportista en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(TxtId.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este transportista?", "Eliminar transportista", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Transportista transportistaEliminado = new Transportista()
                        {
                            IdTransportista = Convert.ToInt32(TxtId.Text),
                        };
                        bool respuesta = new CN_Transportista().Eliminar(transportistaEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaTransportista.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                            MessageBox.Show("El tansportista fue eliminado correctamente.", "Eliminar transportista", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar transportista", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void TablaTransportista_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.Graphics.DrawImage(Properties.Resources.visto, new System.Drawing.Rectangle(r, s, p, q));
                e.Handled = true;
            }
        }

        private void TablaTransportista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaTransportista.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaTransportista.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void TablaTransportista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaTransportista.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaTransportista.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaTransportista.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombres.Text = tablaTransportista.Rows[indice].Cells["Nombres"].Value.ToString();
                    TxtApellidos.Text = tablaTransportista.Rows[indice].Cells["Apellidos"].Value.ToString();
                    TxtCedula.Text = tablaTransportista.Rows[indice].Cells["Cedula"].Value.ToString();
                    TxtTelefono.Text = tablaTransportista.Rows[indice].Cells["Telefono"].Value.ToString();
                    TxtCorreoElectronico.Text = tablaTransportista.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    MemoryStream stream = new MemoryStream((byte[])tablaTransportista.Rows[indice].Cells["Image"].Value);
                    FotoTransportista.Image = System.Drawing.Image.FromStream(stream);
                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaTransportista.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = CmbEstado.Items.IndexOf(item);
                            CmbEstado.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            TxtCodigo.Text = GenerarCodigo(4);
            TxtNombres.Clear();
            TxtApellidos.Clear();
            TxtCedula.Clear();
            TxtTelefono.Clear();
            TxtCorreoElectronico.Clear();
            CmbEstado.SelectedIndex = 0;
            FotoTransportista.Image = null;
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

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
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
