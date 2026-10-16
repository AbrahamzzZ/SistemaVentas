using Entidad;
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
using ClosedXML.Excel;

namespace Presentacion
{
    /// <summary>
    /// Clase que representa la ventana de sucursal.
    /// </summary>
    public partial class VtnSucursal : FormularioBase
    {
        /// <summary>
        /// Constructor de la clase VtnSucursal.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnSucursal()
        {
            InitializeComponent();
        }

        private void VtnSucursal_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Abierto" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "Cerrado" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            ToolTip ayuda = new ToolTip();
            ayuda.SetToolTip(BtnElegirMapa, "Marque en el mapa dónde está la sucursal para llenar la latitud y la longitud.");
            ayuda.SetToolTip(TxtLatitud, "Puede escribirla con punto o coma decimal, o elegirla en el mapa.");
            ayuda.SetToolTip(TxtLogintud, "Puede escribirla con punto o coma decimal, o elegirla en el mapa.");

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
            Negocio mostrarNegocio = new CN_Negocio().ListarNegocio();
            TxtIdNegocio.Text = mostrarNegocio.IdNegocio.ToString();

            List<Sucursal> mostrarSucursal = new CN_Sucursal().ListarSucusal();
            foreach (Sucursal sucursal in mostrarSucursal)
            {
                tablaSucursal.Rows.Add(new object[] { "", sucursal.IdSucursal, sucursal.Codigo, sucursal.Nombre, sucursal.Direccion, FormatearCoordenada(sucursal.Latitud), FormatearCoordenada(sucursal.Longitud), sucursal.Ciudad, sucursal.Estado == true ? 1 : 0, sucursal.Estado == true ? "Abierto" : "Cerrado" });
            }
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

            if (!LeerCoordenadas(out double? latitud, out double? longitud))
            {
                return;
            }

            // Crear el objeto Sucursal
            Sucursal agregarSucursal = new Sucursal()
            {
                IdSucursal = Convert.ToInt32(TxtId.Text),
                oNegocio = new Negocio() { IdNegocio = Convert.ToInt32(TxtIdNegocio.Text)},
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
                tablaSucursal.Rows.Add(new object[] { "", idSucursalIngresado, TxtCodigo.Text, TxtNombre.Text, RtxtDireccion.Text, FormatearCoordenada(latitud), FormatearCoordenada(longitud), TxtCiudad.Text, selectedItemCmb1.Valor, selectedItemCmb1.Texto });

                MessageBox.Show("La sucursal fue registrada correctamente.", "Registrar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (!LeerCoordenadas(out double? latitud, out double? longitud))
            {
                return;
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
                tablaSucursal.Rows[indice].Cells["Latitu"].Value = FormatearCoordenada(sucursalModificado.Latitud);
                tablaSucursal.Rows[indice].Cells["Longitu"].Value = FormatearCoordenada(sucursalModificado.Longitud);
                tablaSucursal.Rows[indice].Cells["Ciudad"].Value = sucursalModificado.Ciudad;
                tablaSucursal.Rows[indice].Cells["EstadoValor"].Value = sucursalModificado.Estado ? 1 : 0;
                tablaSucursal.Rows[indice].Cells["Estado"].Value = sucursalModificado.Estado ? "Abierto" : "Cerrado";

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
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Eliminar sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BtnVerMapa_Click(object sender, EventArgs e)
        {
            List<Sucursal> sucursales = SucursalesDeLaTabla();
            int.TryParse(TxtId.Text, out int idSeleccionada);
            Sucursal seleccionada = sucursales.FirstOrDefault(s => s.IdSucursal == idSeleccionada);

            VtnMapaSucursal.Mostrar(TopLevelControl ?? this, sucursales, seleccionada);
        }

        private void BtnElegirMapa_Click(object sender, EventArgs e)
        {
            // Si ya hay coordenadas escritas, el mapa empieza ahí
            PointLatLng? actual = null;
            if (Coordenada.TryLeer(TxtLatitud.Text, out double lat) && Coordenada.TryLeer(TxtLogintud.Text, out double lng))
            {
                actual = new PointLatLng(lat, lng);
            }

            // Las demás sucursales se muestran como referencia
            int.TryParse(TxtId.Text, out int idActual);
            List<Sucursal> otras = SucursalesDeLaTabla().Where(s => s.IdSucursal != idActual).ToList();

            if (VtnMapaSucursal.ElegirUbicacion(TopLevelControl ?? this, otras, actual, out PointLatLng elegida))
            {
                TxtLatitud.Text = Coordenada.Formatear(elegida.Lat);
                TxtLogintud.Text = Coordenada.Formatear(elegida.Lng);
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
                    Tema.EstiloEstado(e.CellStyle, true);
                }
                else
                {
                    Tema.EstiloEstado(e.CellStyle, false);
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
                    TxtLatitud.Text = FormatearCoordenada(Coordenada.Leer(tablaSucursal.Rows[indice].Cells["Latitu"].Value));
                    TxtLogintud.Text = FormatearCoordenada(Coordenada.Leer(tablaSucursal.Rows[indice].Cells["Longitu"].Value));
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
            RtxtDireccion.Clear();
            TxtLatitud.Clear();
            TxtLogintud.Clear();
            TxtCiudad.Clear();
            CmbEstado.SelectedIndex = 0;
        }

        /// <summary>
        /// Lee la latitud y la longitud escritas; acepta punto o coma decimal.
        /// Los campos vacíos quedan en null para que la capa de negocio indique que faltan.
        /// </summary>
        /// <returns>false si alguna coordenada no es un número válido.</returns>
        private bool LeerCoordenadas(out double? latitud, out double? longitud)
        {
            latitud = null;
            longitud = null;
            if (!string.IsNullOrWhiteSpace(TxtLatitud.Text))
            {
                if (!Coordenada.TryLeer(TxtLatitud.Text, out double valor))
                {
                    MessageBox.Show("La latitud debe ser un número, por ejemplo -2.187746.", "Coordenada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                latitud = valor;
            }
            if (!string.IsNullOrWhiteSpace(TxtLogintud.Text))
            {
                if (!Coordenada.TryLeer(TxtLogintud.Text, out double valor))
                {
                    MessageBox.Show("La longitud debe ser un número, por ejemplo -79.894365.", "Coordenada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                longitud = valor;
            }
            return true;
        }

        private static string FormatearCoordenada(double? valor)
        {
            return valor.HasValue ? Coordenada.Formatear(valor.Value) : string.Empty;
        }

        /// <summary>
        /// Arma la lista de sucursales con los datos que muestra la tabla (incluye los cambios recientes).
        /// </summary>
        private List<Sucursal> SucursalesDeLaTabla()
        {
            var sucursales = new List<Sucursal>();
            foreach (DataGridViewRow fila in tablaSucursal.Rows)
            {
                sucursales.Add(new Sucursal
                {
                    IdSucursal = Convert.ToInt32(fila.Cells["ID"].Value),
                    Codigo = Convert.ToString(fila.Cells["Codigo"].Value),
                    Nombre = Convert.ToString(fila.Cells["NombreSucursal"].Value),
                    Direccion = Convert.ToString(fila.Cells["Direccion"].Value),
                    Latitud = Coordenada.Leer(fila.Cells["Latitu"].Value),
                    Longitud = Coordenada.Leer(fila.Cells["Longitu"].Value),
                    Ciudad = Convert.ToString(fila.Cells["Ciudad"].Value),
                    Estado = Convert.ToInt32(fila.Cells["EstadoValor"].Value) == 1
                });
            }
            return sucursales;
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
