using ClosedXML.Excel;
using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class vtnTransportista : Form
    {
        byte[] imagen = null;
        public vtnTransportista()
        {
            InitializeComponent();
        }

        private void vtnTransportista_Load(object sender, EventArgs e)
        {
            cmb1.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmb1.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaTransportista.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb2.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb2.DisplayMember = "Texto";
            cmb2.ValueMember = "Valor";
            cmb2.SelectedIndex = 0;
            //Mostrar todos los transportistas existentes en la tabla
            List<Transportista> mostrarTransportista = new CapaNegocios().mostrSQL();
            foreach (Transportista transportista in mostrarTransportista)
            {
                tablaTransportista.Rows.Add(new object[] { "", transportista.IdTransportista, transportista.Documento, transportista.Nombres, transportista.Apellidos, transportista.Cedula, transportista.Telefono, transportista.CorreoElectronico, transportista.Imagen, transportista.Estado == true ? 1 : 0, transportista.Estado == true ? "Activo" : "No Activo" });
            }
            txt3.Select();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.Jpg; *.png; *.Gif) |*.Jpg; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                using (MemoryStream stream = new MemoryStream())
                {
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imagen = stream.ToArray();
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaTransportista.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaTransportista.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaTransportista.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[10].Value.ToString()
                        });
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaTransportista.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt9.Text.Trim().ToUpper()))
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt9.Text = "";
                foreach (DataGridViewRow row in tablaTransportista.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;

            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text) || string.IsNullOrWhiteSpace(txt6.Text) || string.IsNullOrWhiteSpace(txt7.Text) || string.IsNullOrWhiteSpace(txt8.Text) || pictureBox1.Image == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(txt3.Text)) mensajeError += "- Número del documento del transportista.\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Nombres del transportista.\n";
                if (string.IsNullOrWhiteSpace(txt5.Text)) mensajeError += "- Apellidos del transportista.\n";
                if (string.IsNullOrWhiteSpace(txt6.Text)) mensajeError += "- Cedula del transportista.\n";
                if (string.IsNullOrWhiteSpace(txt7.Text)) mensajeError += "- Telefono del transportista.\n";
                if (string.IsNullOrWhiteSpace(txt8.Text)) mensajeError += "- Correo electrónico del transportista.\n";
                if (string.IsNullOrWhiteSpace(txt8.Text)) mensajeError += "- Correo electrónico del transportista.\n";
                if (pictureBox1.Image == null) mensajeError += "- Foto del transportista.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Transportista agregarTransportista = new Transportista()
                {
                    IdTransportista = Convert.ToInt32(txt2.Text),
                    Documento = txt3.Text,
                    Nombres = txt4.Text,
                    Apellidos = txt5.Text,
                    Cedula = txt6.Text,
                    Telefono = txt7.Text,
                    CorreoElectronico = txt8.Text,
                    Estado = valorCmb1 == 1
                };
                int idTransportistaIngresado = new CapaNegocios().restrSQL(agregarTransportista, imagen, out mensaje);
                if (idTransportistaIngresado != 0)
                {
                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null)
                    {
                        tablaTransportista.Rows.Add(new object[] { "", idTransportistaIngresado, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, txt8.Text, ImageToByteArray(pictureBox1.Image), valorCmb1, textoCmb1 });
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje;

            Transportista transportistaModificado = new Transportista()
            {
                IdTransportista = Convert.ToInt32(txt2.Text),
                Documento = txt3.Text,
                Nombres = txt4.Text,
                Apellidos = txt5.Text,
                Cedula = txt6.Text,
                Telefono = txt7.Text,
                CorreoElectronico = txt8.Text,
                Estado = valorCmb1 == 1
            };
            if (pictureBox1.Image != null)
            {
                imagen = ImageToByteArray(pictureBox1.Image);
            }
            bool modificar = new CapaNegocios().editrSQL(transportistaModificado, imagen, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El transportista fue modificado correctamente.", "Modificar transportista", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txt1.Text);
                tablaTransportista.Rows[indice].Cells["Documento"].Value = transportistaModificado.Documento;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text) || string.IsNullOrWhiteSpace(txt6.Text) || string.IsNullOrWhiteSpace(txt7.Text) || string.IsNullOrWhiteSpace(txt8.Text) || pictureBox1.Image == null)
            {
                MessageBox.Show("Primero debe selecionar un transportista en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txt2.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este transportista?", "Eliminar transportista", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Transportista transportistaEliminado = new Transportista()
                        {
                            IdTransportista = Convert.ToInt32(txt2.Text),
                        };
                        bool respuesta = new CapaNegocios().elitrSQL(transportistaEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaTransportista.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
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

        private void tablaTransportista_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaTransportista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void tablaTransportista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaTransportista.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaTransportista.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaTransportista.Rows[indice].Cells["Documento"].Value.ToString();
                    txt4.Text = tablaTransportista.Rows[indice].Cells["Nombres"].Value.ToString();
                    txt5.Text = tablaTransportista.Rows[indice].Cells["Apellidos"].Value.ToString();
                    txt6.Text = tablaTransportista.Rows[indice].Cells["Cedula"].Value.ToString();
                    txt7.Text = tablaTransportista.Rows[indice].Cells["Telefono"].Value.ToString();
                    txt8.Text = tablaTransportista.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    MemoryStream stream = new MemoryStream((byte[])tablaTransportista.Rows[indice].Cells["Image"].Value);
                    pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaTransportista.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = cmb1.Items.IndexOf(item);
                            cmb1.SelectedIndex = indice_cmb;
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
            txt1.Text = "-1";
            txt2.Text = "0";
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            txt6.Clear();
            txt7.Clear();
            txt8.Clear();
            cmb1.SelectedIndex = 0;
            pictureBox1.Image = null;
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Número Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Apellidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Cédula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
