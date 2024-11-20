using Entidad;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
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
using GMap.NET.WindowsForms;
using ClosedXML.Excel;

namespace Presentacion
{
    public partial class vtnSucursal : Form
    {
        GMarkerGoogle marcador;
        GMapOverlay moverlay;
        DataTable dt;
        int fila = 0;
        double latitud = -2.19616;
        double longitud = -79.88621;
        public vtnSucursal()
        {
            InitializeComponent();
            moverlay = new GMapOverlay("markers");
        }

        private void vtnSucursal_Load(object sender, EventArgs e)
        {
            mapa.DragButton = MouseButtons.Left;
            mapa.CanDragMap = true;
            mapa.MapProvider = GMapProviders.GoogleMap;
            mapa.Position = new PointLatLng(latitud, longitud);
            mapa.MinZoom = 0;
            mapa.MaxZoom = 30;
            mapa.Zoom = 15;
            mapa.AutoScroll = true;

            cmb1.Items.Add(new { Valor = 1, Texto = "Abierto" });
            cmb1.Items.Add(new { Valor = 0, Texto = "Cerrado" });
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnAgregar, "Cuando ponga la latitud y la longitud no se olvide de cambiar el . por la , para asi poder registrar la sucursal.");

            foreach (DataGridViewColumn columna in tablaSucursal.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb2.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmb2.DisplayMember = "Texto";
            cmb2.ValueMember = "Valor";
            cmb2.SelectedIndex = 0;
            //Mostrar todos las sucursales existentes en la tabla
            List<Sucursal> mostrarSucursal = new CapaNegocios().mossuSQL();
            foreach (Sucursal sucursal in mostrarSucursal)
            {
                tablaSucursal.Rows.Add(new object[] { "", sucursal.IdSucursal, sucursal.Nombre, sucursal.Direccion, sucursal.Latitud, sucursal.Longitud, sucursal.Ciudad, sucursal.Estado == true ? 1 : 0, sucursal.Estado == true ? "Abierto" : "Cerrado" });
                GMarkerGoogle marcadorSucursal = new GMarkerGoogle(new PointLatLng(sucursal.Latitud, sucursal.Longitud), GMarkerGoogleType.red_dot);
                moverlay.Markers.Add(marcadorSucursal);
            }
            mapa.Overlays.Add(moverlay);
            txt3.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaSucursal.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt9.Text = "";
                foreach (DataGridViewRow row in tablaSucursal.Rows)
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

            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text) || string.IsNullOrWhiteSpace(txt6.Text) || string.IsNullOrWhiteSpace(txt7.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(txt3.Text)) mensajeError += "- Nombre del sucursal.\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Dirección de la sucursal.\n";
                if (string.IsNullOrWhiteSpace(txt5.Text)) mensajeError += "- Latitud de la sucursal.\n";
                if (string.IsNullOrWhiteSpace(txt6.Text)) mensajeError += "- Longitud de la sucursal.\n";
                if (string.IsNullOrWhiteSpace(txt7.Text)) mensajeError += "- Ciudad de la sucursal.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
                Sucursal agregarSucursal = new Sucursal()
                {
                    IdSucursal = Convert.ToInt32(txt2.Text),
                    Nombre = txt3.Text,
                    Direccion = txt4.Text,
                    Latitud = Convert.ToDouble(txt5.Text),
                    Longitud = Convert.ToDouble(txt6.Text),
                    Ciudad = txt7.Text,
                    Estado = valorCmb1 == 1
                };
                int idSucursalIngresado = new CapaNegocios().ressuSQL(agregarSucursal, out mensaje);
                if (idSucursalIngresado != 0)
                {
                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null)
                    {
                        tablaSucursal.Rows.Add(new object[] { "", idSucursalIngresado, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, valorCmb1, textoCmb1 });
                        MessageBox.Show("La sucursal fue agregado correctamente.", "Agregar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GMarkerGoogle marcadorSucursal = new GMarkerGoogle(new PointLatLng(agregarSucursal.Latitud, agregarSucursal.Longitud), GMarkerGoogleType.red_dot);
                        marcadorSucursal.ToolTipText = $"{agregarSucursal.Nombre}\n{agregarSucursal.Direccion}";
                        marcadorSucursal.ToolTip.Fill = Brushes.Black;
                        marcadorSucursal.ToolTip.Foreground = Brushes.White;
                        marcadorSucursal.ToolTip.Stroke = Pens.Black;
                        marcadorSucursal.ToolTip.TextPadding = new Size(20, 20);
                        moverlay.Markers.Add(marcadorSucursal);
                        mapa.Refresh();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Sucursal");
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

            Sucursal sucursalModificado = new Sucursal()
            {
                IdSucursal = Convert.ToInt32(txt2.Text),
                Nombre = txt3.Text,
                Direccion = txt4.Text,
                Latitud = Convert.ToDouble(txt5.Text),
                Longitud = Convert.ToDouble(txt6.Text),
                Ciudad = txt7.Text,
                Estado = valorCmb1 == 1
            };
            bool modificar = new CapaNegocios().edisuSQL(sucursalModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La sucursal fue modificado correctamente.", "Modificar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(txt1.Text);
                tablaSucursal.Rows[indice].Cells["ID"].Value = sucursalModificado.IdSucursal;
                tablaSucursal.Rows[indice].Cells["NombreSucursal"].Value = sucursalModificado.Nombre;
                tablaSucursal.Rows[indice].Cells["Direccion"].Value = sucursalModificado.Direccion;
                tablaSucursal.Rows[indice].Cells["Latitu"].Value = sucursalModificado.Latitud;
                tablaSucursal.Rows[indice].Cells["Longitu"].Value = sucursalModificado.Longitud;
                tablaSucursal.Rows[indice].Cells["Ciudad"].Value = sucursalModificado.Ciudad;
                tablaSucursal.Rows[indice].Cells["EstadoValor"].Value = sucursalModificado.Estado ? 1 : 0;
                tablaSucursal.Rows[indice].Cells["Estado"].Value = sucursalModificado.Estado ? "Abierto" : "Cerrado";
                mapa.Refresh();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar la información de la sucursal: " + mensaje, "Modificar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text) || string.IsNullOrWhiteSpace(txt6.Text) || string.IsNullOrWhiteSpace(txt7.Text))
            {
                MessageBox.Show("Primero debe selecionar una sucursal en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txt2.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar está sucursal?", "Eliminar sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Sucursal sucursalEliminado = new Sucursal()
                        {
                            IdSucursal = Convert.ToInt32(txt2.Text),
                        };

                        bool respuesta = new CapaNegocios().elisuSQL(sucursalEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaSucursal.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
                            MessageBox.Show("La sucursal fue eliminada correctamente.", "Eliminar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            foreach (GMarkerGoogle marcador in moverlay.Markers)
                            {
                                if (marcador.Position.Lat == sucursalEliminado.Latitud && marcador.Position.Lng == sucursalEliminado.Longitud)
                                {
                                    moverlay.Markers.Remove(marcador);
                                    break;
                                }
                            }
                            mapa.Refresh();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaSucursal.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaSucursal.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in tablaSucursal.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[8].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Lista_Sucursales.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Sucursales");
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

        private void tablaSucursal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaSucursal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaSucursal.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Abierto")
                {
                    DataGridViewRow row = tablaSucursal.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaSucursal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaSucursal.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaSucursal.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaSucursal.Rows[indice].Cells["NombreSucursal"].Value.ToString();
                    txt4.Text = tablaSucursal.Rows[indice].Cells["Direccion"].Value.ToString();
                    txt5.Text = tablaSucursal.Rows[indice].Cells["Latitu"].Value.ToString();
                    txt6.Text = tablaSucursal.Rows[indice].Cells["Longitu"].Value.ToString();
                    txt7.Text = tablaSucursal.Rows[indice].Cells["Ciudad"].Value.ToString();

                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaSucursal.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = cmb1.Items.IndexOf(item);
                            cmb1.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    double latitudSucursal = Convert.ToDouble(txt5.Text);
                    double longitudSucursal = Convert.ToDouble(txt6.Text);
                    string nombreSucursal = txt3.Text;
                    string direccionSucursal = txt4.Text;

                    GMarkerGoogle marcadorSucursal = new GMarkerGoogle(new PointLatLng(latitudSucursal, longitudSucursal), GMarkerGoogleType.red_dot);
                    marcadorSucursal.ToolTipText = $"{nombreSucursal}\n{direccionSucursal}";
                    marcadorSucursal.ToolTip.Fill = Brushes.Black;
                    marcadorSucursal.ToolTip.Foreground = Brushes.White;
                    marcadorSucursal.ToolTip.Stroke = Pens.Black;
                    marcadorSucursal.ToolTip.TextPadding = new Size(20, 20);
                    moverlay.Markers.Add(marcadorSucursal);
                    mapa.Position = new PointLatLng(latitudSucursal, longitudSucursal);
                    mapa.Zoom = 15;
                    mapa.Refresh();
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
            txt7.Clear();
            cmb1.SelectedIndex = 0;
            mapa.Position = new PointLatLng(latitud, longitud);
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar !=',' && e.KeyChar != '-')
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Latitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '-') && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                MessageBox.Show("Para ingresar la latitud solo es necesario una , y un - .", "Campo Latitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).SelectionStart == 0)
            {
                MessageBox.Show("Debe ingresar un numero primero para despues usar la , .", "Campo Latitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar !=',' && e.KeyChar != '-')
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Longitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '-') && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                MessageBox.Show("Para ingresar la longitud solo es necesario una , y un - .", "Campo Longitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).SelectionStart == 0)
            {
                MessageBox.Show("Debe ingresar un numero primero para despues usar la , .", "Campo Longitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
