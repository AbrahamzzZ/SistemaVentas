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
    public partial class VtnSucursal : Form
    {
        GMarkerGoogle marcador;
        GMapOverlay moverlay;
        DataTable dt;
        int fila = 0;
        double latitud = -2.19616;
        double longitud = -79.88621;
        public VtnSucursal()
        {
            InitializeComponent();
            moverlay = new GMapOverlay("markers");
        }

        private void VtnSucursal_Load(object sender, EventArgs e)
        {
            mapa.DragButton = MouseButtons.Left;
            mapa.CanDragMap = true;
            mapa.MapProvider = GMapProviders.GoogleMap;
            mapa.Position = new PointLatLng(latitud, longitud);
            mapa.MinZoom = 0;
            mapa.MaxZoom = 30;
            mapa.Zoom = 15;
            mapa.AutoScroll = true;

            CmbEstado.Items.Add(new { Valor = 1, Texto = "Abierto" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "Cerrado" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(BtnAgregar, "Cuando ponga la latitud y la longitud no se olvide de cambiar el . por la , para asi poder registrar la sucursal.");

            foreach (DataGridViewColumn columna in tablaSucursal.Columns)
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
            List<Sucursal> mostrarSucursal = new CN_Sucursal().ListarSucusal();
            foreach (Sucursal sucursal in mostrarSucursal)
            {
                tablaSucursal.Rows.Add(new object[] { "", sucursal.IdSucursal, sucursal.Codigo, sucursal.Nombre, sucursal.Direccion, sucursal.Latitud, sucursal.Longitud, sucursal.Ciudad, sucursal.Estado == true ? 1 : 0, sucursal.Estado == true ? "Abierto" : "Cerrado" });
                GMarkerGoogle marcadorSucursal = new GMarkerGoogle(new PointLatLng((double)sucursal.Latitud, (double)sucursal.Longitud), GMarkerGoogleType.red_dot);
                moverlay.Markers.Add(marcadorSucursal);
            }
            mapa.Overlays.Add(moverlay);
            TxtNombre.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = CmbBuscar.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaSucursal.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaSucursal.Rows)
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
                if (selectedItemCmb1 == null) mensajeError += "- Estado de la Sucursal.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            double? latitud = null;
            if (!string.IsNullOrWhiteSpace(TxtLatitud.Text) && double.TryParse(TxtLatitud.Text, out double tempLatitud))
            {
                latitud = tempLatitud;
            }

            double? longitud = null;
            if (!string.IsNullOrWhiteSpace(TxtLatitud.Text) && double.TryParse(TxtLatitud.Text, out double tempLongitud))
            {
                longitud = tempLongitud;
            }

            // Crear el objeto Sucursal
            Sucursal agregarSucursal = new Sucursal()
            {
                IdSucursal = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Nombre = TxtNombre.Text,
                Direccion = RtxtDireccion.Text,
                Latitud = latitud,
                Longitud = longitud,
                Ciudad = TxtCiudad.Text,
                Estado = selectedItemCmb1.Valor == 1
            };

            // Delegar la validación y registro a la lógica de negocio
            int idSucursalIngresado = new CN_Sucursal().Registrar(agregarSucursal, out mensaje);
            if (idSucursalIngresado != 0)
            {
                // Agregar a la tabla y mostrar mensaje de éxito
                tablaSucursal.Rows.Add(new object[] { "", idSucursalIngresado, TxtCodigo.Text, TxtNombre.Text, RtxtDireccion.Text, TxtLatitud.Text, TxtLogintud.Text, TxtCiudad.Text, selectedItemCmb1.Valor, selectedItemCmb1.Texto });
                
                MessageBox.Show("La sucursal fue registrada correctamente.", "Registrar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GMarkerGoogle marcadorSucursal = new GMarkerGoogle(new PointLatLng((double)agregarSucursal.Latitud, (double)agregarSucursal.Longitud), GMarkerGoogleType.red_dot);
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
                // Mostrar mensaje de error proveniente de la capa de negocio
                MessageBox.Show($"No se pudo registrar la sucursal: {mensaje}", "Error al Registrar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (selectedItemCmb1 == null) mensajeError += "- Estado de la Sucursal.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            double? latitud = null;
            if (!string.IsNullOrWhiteSpace(TxtLatitud.Text) && double.TryParse(TxtLatitud.Text, out double tempLatitud))
            {
                latitud = tempLatitud;
            }

            double? longitud = null;
            if (!string.IsNullOrWhiteSpace(TxtLatitud.Text) && double.TryParse(TxtLatitud.Text, out double tempLongitud))
            {
                longitud = tempLongitud;
            }

            // Crear el objeto Sucursal
            Sucursal sucursalModificado = new Sucursal()
            {
                IdSucursal = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Nombre = TxtNombre.Text,
                Direccion = RtxtDireccion.Text,
                Latitud = latitud,
                Longitud = longitud,
                Ciudad = TxtCiudad.Text,
                Estado = selectedItemCmb1.Valor == 1
            };

            // Delegar la validación y edición a la lógica de negocio
            bool modificar = new CN_Sucursal().Editar(sucursalModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La información de la sucursal fue modificada correctamente.", "Modificar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla con los datos modificados
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaSucursal.Rows[indice].Cells["ID"].Value = sucursalModificado.IdSucursal;
                tablaSucursal.Rows[indice].Cells["Codigo"].Value = sucursalModificado.Codigo;
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
                MessageBox.Show($"No se pudo modificar la información de la surcusal: {mensaje}", "Modificar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla un usuario seleccionado
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar una Sucursal en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea eliminar está sucursal?", "Eliminar sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                Sucursal sucursalEliminado = new Sucursal()
                {
                    IdSucursal = Convert.ToInt32(TxtId.Text),
                };

                bool respuesta = new CN_Sucursal().Eliminar(sucursalEliminado, out mensaje);
                if (respuesta)
                {
                    tablaSucursal.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
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

        private void BtnExportarExcel_Click(object sender, EventArgs e)
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
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[9].Value.ToString()
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

        private void TablaSucursal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaSucursal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void TablaSucursal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaSucursal.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaSucursal.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaSucursal.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombre.Text = tablaSucursal.Rows[indice].Cells["NombreSucursal"].Value.ToString();
                    RtxtDireccion.Text = tablaSucursal.Rows[indice].Cells["Direccion"].Value.ToString();
                    TxtLatitud.Text = tablaSucursal.Rows[indice].Cells["Latitu"].Value.ToString();
                    TxtLogintud.Text = tablaSucursal.Rows[indice].Cells["Longitu"].Value.ToString();
                    TxtCiudad.Text = tablaSucursal.Rows[indice].Cells["Ciudad"].Value.ToString();

                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaSucursal.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = CmbEstado.Items.IndexOf(item);
                            CmbEstado.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    double latitudSucursal = Convert.ToDouble(TxtLatitud.Text);
                    double longitudSucursal = Convert.ToDouble(TxtLogintud.Text);
                    string nombreSucursal = TxtNombre.Text;
                    string direccionSucursal = RtxtDireccion.Text;

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
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            TxtCodigo.Text = GenerarCodigo(4);
            TxtNombre.Clear();
            RtxtDireccion.Clear();
            TxtLatitud.Clear();
            TxtLogintud.Clear();
            TxtCiudad.Clear();
            CmbEstado.SelectedIndex = 0;
            mapa.Position = new PointLatLng(latitud, longitud);
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
    }
}
