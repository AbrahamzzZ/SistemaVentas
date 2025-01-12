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
    /// Clase que representa la ventana de oferta.
    /// </summary>
    public partial class VtnOferta : Form
    {
        /// <summary>
        /// Constructor de la clase VtnOferta.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnOferta()
        {
            InitializeComponent();
        }

        private void VtnOferta_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            List<Producto> listaProducto = new CN_Producto().ListarProducto();
            foreach (Producto productos in listaProducto)
            {
                CmbProducto.Items.Add(new { Valor = productos.IdProducto, Texto = productos.Nombre });
            }
            CmbProducto.DisplayMember = "Texto";
            CmbProducto.ValueMember = "Valor";
            if (CmbProducto.Items.Count > 0){
                CmbProducto.SelectedIndex = 0;
            }else{
                CmbProducto.Enabled = false;
            }

            foreach (DataGridViewColumn columna in tablaOferta.Columns)
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
            List<Oferta> lista = new CN_Oferta().ListarOferta();
            foreach (Oferta item in lista)
            {
                tablaOferta.Rows.Add(new object[] { "", item.IdOferta, item.Codigo, item.NombreOferta, item.oProducto.IdProducto, item.oProducto.Nombre, item.Descripcion, item.FechaInicio, item.FechaFin, item.Descuento, item.Estado == true ? 1 : 0, item.Estado == true ? "Activo" : "No Activo" });
            }
            TxtNombre.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb3 = CmbBuscar.SelectedItem;
            string valorCmb3 = selectedItemCmb3.Valor;
            string columnaFiltro = valorCmb3.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaOferta.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar oferta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaOferta.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbProducto.SelectedItem;
            dynamic selectedItemCmb2 = CmbEstado.SelectedItem;
            string mensaje = string.Empty;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Producto de la oferta.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Estado de la oferta.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            decimal? descuento = null;
            if (!string.IsNullOrWhiteSpace(TxtDescuento.Text) && decimal.TryParse(TxtDescuento.Text, out decimal tempDescuento))
            {
                descuento = tempDescuento;
            }

            // Crear el objeto Oferta
            Oferta agregarOferta = new Oferta()
            {
                IdOferta = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                NombreOferta = TxtNombre.Text,
                Descripcion = RtextDescripcion.Text,
                FechaInicio = txtFechaInicio.Text,
                FechaFin = txtFechaFin.Text,
                Descuento = descuento,
                oProducto = new Producto { IdProducto = selectedItemCmb1.Valor },
                Estado = selectedItemCmb2.Valor == 1
            };


            List<Producto> listaProducto = new CN_Producto().ListarProducto();
            Producto productoSeleccionado = listaProducto.FirstOrDefault(c => c.IdProducto == selectedItemCmb1.Valor);
            if (productoSeleccionado != null && !productoSeleccionado.Estado)
            {
                MessageBox.Show("El producto seleccionado no está habilitado. Por favor, seleccione un producto activo.", "Producto no habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                return;
            }
            else
            {
                // Delegar la validación y registro a la lógica de negocio
                int idOfertaIngresado = new CN_Oferta().Registrar(agregarOferta, out mensaje);
                if (idOfertaIngresado != 0)
                {
                    tablaOferta.Rows.Add(new object[] { "", idOfertaIngresado, TxtCodigo.Text, TxtNombre.Text, selectedItemCmb1.Valor, selectedItemCmb1.Texto, RtextDescripcion.Text, txtFechaInicio.Text, txtFechaFin.Text, TxtDescuento.Text, selectedItemCmb2.Valor, selectedItemCmb2.Texto });
                    MessageBox.Show("La oferta fue registrada correctamente.", "Registrar oferta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    // Mostrar mensaje de error proveniente de la capa de negocio
                    MessageBox.Show($"No se pudo registrar la oferta: {mensaje}", "Error al Registrar oferta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbProducto.SelectedItem;
            dynamic selectedItemCmb2 = CmbEstado.SelectedItem;
            string mensaje;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Producto de la oferta.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Estado de la oferta.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            decimal? descuento = null;
            if (!string.IsNullOrWhiteSpace(TxtDescuento.Text) && decimal.TryParse(TxtDescuento.Text, out decimal tempDescuento))
            {
                descuento = tempDescuento;
            }

            // Crear el objeto Oferta
            Oferta ofertaModificado = new Oferta()
            {
                IdOferta = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                oProducto = new Producto { IdProducto = selectedItemCmb1.Valor },
                NombreOferta = TxtNombre.Text,
                Descripcion = RtextDescripcion.Text,
                FechaInicio = txtFechaInicio.Text,
                FechaFin = txtFechaFin.Text,
                Descuento = descuento,
                Estado = selectedItemCmb2.Valor == 1
            };

            List<Producto> listaProducto = new CN_Producto().ListarProducto();
            Producto productoSeleccionado = listaProducto.FirstOrDefault(c => c.IdProducto == selectedItemCmb1.Valor);
            if (productoSeleccionado != null && !productoSeleccionado.Estado)
            {
                MessageBox.Show("El producto seleccionado no está habilitado. Por favor, seleccione un producto activo.", "Producto no habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                return;
            }
            else
            {
                // Delegar la validación y edición a la lógica de negocio
                bool modificar = new CN_Oferta().Editar(ofertaModificado, out mensaje);
                if (modificar)
                {
                    MessageBox.Show("La información de la oferta fue modificada correctamente.", "Modificar oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int indice = Convert.ToInt32(TxtIndice.Text);
                    tablaOferta.Rows[indice].Cells["Codigo"].Value = ofertaModificado.Codigo;
                    tablaOferta.Rows[indice].Cells["Oferta"].Value = ofertaModificado.NombreOferta;
                    tablaOferta.Rows[indice].Cells["IDPRODUCTO"].Value = ofertaModificado.oProducto.IdProducto;
                    tablaOferta.Rows[indice].Cells["Producto"].Value = selectedItemCmb1.Texto;
                    tablaOferta.Rows[indice].Cells["Descripcion"].Value = ofertaModificado.Descripcion;
                    tablaOferta.Rows[indice].Cells["FechaInicio"].Value = ofertaModificado.FechaInicio;
                    tablaOferta.Rows[indice].Cells["FechaFin"].Value = ofertaModificado.FechaFin;
                    tablaOferta.Rows[indice].Cells["Descuento"].Value = ofertaModificado.Descuento;
                    tablaOferta.Rows[indice].Cells["EstadoValor"].Value = ofertaModificado.Estado ? 1 : 0;
                    tablaOferta.Rows[indice].Cells["Estado"].Value = ofertaModificado.Estado ? "Activo" : "No Activo";

                    Limpiar();
                }
                else
                {
                    MessageBox.Show($"No se pudo modificar la información de la oferta: {mensaje}", "Modificar oferta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla una oferta seleccionada
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar un Proveedor en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea eliminar está oferta?", "Eliminar oferta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                Oferta ofertaEliminada = new Oferta()
                {
                    IdOferta = Convert.ToInt32(TxtId.Text),
                };
                bool respuesta = new CN_Oferta().Eliminar(ofertaEliminada, out mensaje);
                if (respuesta)
                {
                    tablaOferta.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                    MessageBox.Show("La oferta fue eliminada correctamente.", "Eliminar oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Eliminar oferta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TablaOferta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaOferta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaOferta.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaOferta.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void TablaOferta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaOferta.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaOferta.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaOferta.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombre.Text = tablaOferta.Rows[indice].Cells["Oferta"].Value.ToString();
                    RtextDescripcion.Text = tablaOferta.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtFechaInicio.Text = tablaOferta.Rows[indice].Cells["FechaInicio"].Value.ToString();
                    txtFechaFin.Text = tablaOferta.Rows[indice].Cells["FechaFin"].Value.ToString();
                    TxtDescuento.Text = tablaOferta.Rows[indice].Cells["Descuento"].Value.ToString();

                    foreach (dynamic item in CmbProducto.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaOferta.Rows[indice].Cells["IdProducto"].Value))
                        {
                            int indice_cmb = CmbProducto.Items.IndexOf(item);
                            CmbProducto.SelectedIndex = indice_cmb;
                            break;
                        }
                    }

                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaOferta.Rows[indice].Cells["EstadoValor"].Value))
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
            RtextDescripcion.Clear();
            txtFechaInicio.Value = DateTime.Now;
            txtFechaFin.Value = DateTime.Now;
            TxtDescuento.Clear();
            CmbProducto.SelectedIndex = 0;
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
