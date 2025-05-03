using System;
using Presentacion.Modales;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Entidad;

namespace Presentacion
{
    /// <summary>
    /// Clase que representa la ventana de las ventas.
    /// </summary>
    public partial class VtnVenta : Form
    {
        private Usuario_Catched usuario;
        private Cliente cliente;

        /// <summary> 
        /// Constructor de la clase VtnVenta. 
        /// Inicializa la ventana de venta con un usuario específico. 
        /// </summary> 
        /// <param name="oUsuario">Usuario que realizará la venta. Puede ser nulo.</param>
        public VtnVenta(Usuario_Catched oUsuario = null)
        {
            usuario = oUsuario;
            InitializeComponent();
        }

        private void VtnVenta_Load(object sender, EventArgs e)
        {
            CmbTipoDocumento.Items.Add(new { Valor = "Boleta", Texto = "Boleta" });
            CmbTipoDocumento.Items.Add(new { Valor = "Factura", Texto = "Factura" });
            CmbTipoDocumento.DisplayMember = "Texto";
            CmbTipoDocumento.ValueMember = "Valor";
            CmbTipoDocumento.SelectedIndex = 0;

            TxtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TxtIdCliente.Text = "0";
            TxtIdProducto.Text = "0";
            TxtDescuentoOferta.Text = "";
            TxtTotalPagar.Text = "";
            TxtTotalDescuento.Text = "";
            TxtPagaCon.Text = "";
            TxtCambio.Text = "";
        }
        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesClientes())
            {
                cliente = modal.Cliente;
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtIdCliente.Text = modal.Cliente.IdCliente.ToString();
                    TxtCedulaCliente.Text = modal.Cliente.Cedula.ToString();
                    TxtNombresCliente.Text = modal.Cliente.Nombres.ToString();
                }
                else
                {
                    TxtIdCliente.Select();
                }
            }
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesProductos())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtIdProducto.Text = modal.Producto.IdProducto.ToString();
                    TxtCodigo.Text = modal.Producto.Codigo.ToString();
                    TxtProducto.Text = modal.Producto.Nombre.ToString();
                    TxtPrecioVenta.Text = modal.Producto.PrecioVenta.ToString("0.00");
                    TxtStock.Text = modal.Producto.Stock.ToString();
                    NudCantidad.Select();
                }
            }
        }

        private void BtnModalSucursal_Click(object sender, EventArgs e)
        {
            using (var modal = new VtnModalesSucursal())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtIdSucursal.Text = modal.Sucursal.IdSucursal.ToString();
                    TxtSucursal.Text = modal.Sucursal.Nombre.ToString();
                }
                else
                {
                    TxtIdSucursal.Select();
                }
            }
        }

        private void BtnModalOferta_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesOfertas())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtNombreOferta.Text = modal.oferta.NombreOferta.ToString();
                    TxtDescuentoOferta.Text = modal.oferta.Descuento.ToString();
                }
                else
                {
                    TxtNombreOferta.Clear();
                    TxtDescuentoOferta.Clear();
                    TxtPagaCon.Select();
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExistente = false;

            if (int.Parse(TxtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(TxtPrecioVenta.Text, out precio))
            {
                MessageBox.Show("Formato moneda incorrecta.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPrecioVenta.Select();
                return;
            }
            if (Convert.ToInt32(TxtStock.Text) < Convert.ToInt32(NudCantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NudCantidad.Value == 0)
            {
                MessageBox.Show("No puedes realizar una venta con 0 productos.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NudCantidad.Select(); 
                return;
            }
            foreach (DataGridViewRow fila in TablaVentas.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null && fila.Cells["IdProducto"].Value.ToString() == TxtIdProducto.Text)
                {
                    productoExistente = true;
                    break;
                }
            }
            if (!productoExistente)
            {
                List<Oferta> listaOferta = new CN_Oferta().ListarOferta();
                bool respuesta = new CN_Venta().RestarSotckProducto(Convert.ToInt32(TxtIdProducto.Text), Convert.ToInt32(NudCantidad.Value.ToString()));
                if (respuesta)
                {
                    decimal subTotal = NudCantidad.Value * precio;
                    decimal descuento = 0;
                    if (!string.IsNullOrEmpty(TxtDescuentoOferta.Text))
                    {
                        descuento = Convert.ToDecimal(TxtDescuentoOferta.Text);
                    }
                    decimal totalConDescuento = subTotal - (subTotal * descuento / 100);
                    TablaVentas.Rows.Add(new object[]{
                        TxtIdProducto.Text,
                        TxtProducto.Text,
                        precio.ToString("0.00"),
                        NudCantidad.Value.ToString(),
                        (NudCantidad.Value * precio).ToString("0.00"),
                        totalConDescuento.ToString("0.00")
                    });
                    CalcularTotal();
                    Limpiar();
                }
            }
        }
      
        private void BtnCrearVenta_Click(object sender, EventArgs e)
        {
            string tipoDocumento = ((dynamic)CmbTipoDocumento.SelectedItem).Texto;
            if (Convert.ToInt32(TxtIdCliente.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Realizar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TablaVentas.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar un producto a la venta", "Realizar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtPagaCon.Text == "")
            {
                MessageBox.Show("Debe ingresar el valor a pagar.", "Realizar Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPagaCon.Select();
            }
            else
            {
                DataTable detalleVenta = new DataTable();
                detalleVenta.Columns.Add("IdProducto", typeof(int));
                detalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
                detalleVenta.Columns.Add("Cantidad", typeof(int));
                detalleVenta.Columns.Add("SubTotal", typeof(decimal));
                detalleVenta.Columns.Add("Descuento", typeof(decimal));
                foreach (DataGridViewRow row in TablaVentas.Rows)
                {
                    detalleVenta.Rows.Add(new object[]{
                        row.Cells["IdProducto"].Value.ToString(),
                        row.Cells["Precio"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString(),
                        row.Cells["Descuento"].Value.ToString()
                    });
                }
                int idCorrelativo = new CN_Venta().MostrarCorrelativoVenta();
                string numeroDocumento = string.Format("{0:00000}", idCorrelativo);
                CalcularCambio();
                Venta oVenta = new Venta()
                {
                    oUsuario = new Usuario() { IdUsuario = usuario.IdUsuario },
                    TipoDocumento = tipoDocumento,
                    NumeroDocumento = numeroDocumento,
                    oCliente = new Cliente() { IdCliente = Convert.ToInt32(TxtIdCliente.Text) },
                    oSucursal = new Sucursal() { IdSucursal = Convert.ToInt32(TxtIdSucursal.Text)},
                    MontoTotal = Convert.ToDecimal(TxtTotalPagar.Text),
                    Descuento = Convert.ToDecimal(TxtTotalDescuento.Text),
                    MontoPago = Convert.ToDecimal(TxtPagaCon.Text),
                    MontoCambio = Convert.ToDecimal(TxtCambio.Text),
                };

                string mensaje = string.Empty;
                bool respuesta = new CN_Venta().Registrar(oVenta, detalleVenta, out mensaje);
                if (respuesta)
                {
                    MessageBox.Show("Venta realizada exitosamente.", "Registrar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var result = MessageBox.Show("Numero de venta generado:\n" + numeroDocumento + "\n\n ¿Dsea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        System.Windows.Forms.Clipboard.SetText(numeroDocumento);
                    }

                    TxtIdSucursal.Clear();
                    TxtSucursal.Clear();
                    TxtCedulaCliente.Clear();
                    TxtNombresCliente.Clear();
                    TxtTotalPagar.Clear();
                    TxtTotalDescuento.Clear();
                    TxtPagaCon.Clear();
                    TxtCambio.Clear();
                    TablaVentas.Rows.Clear();
                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show(mensaje, "Registrar venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TablaVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var p = Properties.Resources.eliminar.Width;
                var q = Properties.Resources.eliminar.Height;
                var r = e.CellBounds.Left + (e.CellBounds.Width - p) / 2;
                var s = e.CellBounds.Top + (e.CellBounds.Height - q) / 2;
                e.Graphics.DrawImage(Properties.Resources.eliminar, new Rectangle(r, s, p, q));
                e.Handled = true;
            }
        }

        private void TablaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaVentas.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    bool respuesta = new CN_Venta().SumarSotckProducto(
                    Convert.ToInt32(TablaVentas.Rows[indice].Cells["IdProducto"].Value.ToString()),
                    Convert.ToInt32(TablaVentas.Rows[indice].Cells["Cantidad"].Value.ToString()));
                    if (respuesta)
                    {
                        TablaVentas.Rows.RemoveAt(indice);
                        CalcularTotal();
                    }
                }
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            decimal totalDescuento = 0;
            if (TablaVentas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in TablaVentas.Rows)
                {
                    var subTotalCellValue = row.Cells["SubTotal"].Value;
                    var subTotalDescuentoCellValue = row.Cells["Descuento"].Value;
                    if (subTotalCellValue != null)
                    {
                        total += Convert.ToDecimal(subTotalCellValue.ToString());
                        totalDescuento += Convert.ToDecimal(subTotalDescuentoCellValue.ToString());
                    }
                }
                TxtTotalPagar.Text = total.ToString("0.00");
                TxtTotalDescuento.Text = totalDescuento.ToString("0.00");
            }
        }

        private void CalcularCambio()
        {
            if (TxtTotalDescuento.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal pagacon;
            decimal total = Convert.ToDecimal(TxtTotalDescuento.Text);

            if (TxtPagaCon.Text.Trim() == "")
            {
                TxtPagaCon.Text = "0";
            }
            if (decimal.TryParse(TxtPagaCon.Text.Trim(), out pagacon))
            {
                if (pagacon < total)
                {
                    TxtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    TxtCambio.Text = cambio.ToString("0.00");
                }
            }
        }
        private void Limpiar()
        {
            TxtIdProducto.Text = "0";
            TxtCodigo.Text = "";
            TxtCodigo.BackColor = Color.White;
            TxtProducto.Text = "";
            TxtPrecioVenta.Text = "";
            TxtStock.Text = "";
            NudCantidad.Value = 0;
            TxtNombreOferta.Text = "";
            TxtDescuentoOferta.Text = "";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtIdSucursal.Text = "0";
            TxtSucursal.Text = "";
            TxtIdProducto.Text = "0";
            TxtCodigo.Text = "";
            TxtProducto.Text = "";
            TxtPrecioVenta.Text = "";
            TxtStock.Text = "";
            NudCantidad.Value = 0;
            TxtIdCliente.Text = "0";
            TxtCedulaCliente.Text = "";
            TxtNombresCliente.Text = "";
            TxtNombreOferta.Text = "";
            TxtDescuentoOferta.Text = "";
            TxtTotalPagar.Text = "";
            TxtTotalDescuento.Text = "";
            TxtPagaCon.Text = "";
            TxtCambio.Text = "";
            TablaVentas.Rows.Clear();
        }

        private void TxtPagaCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void TxtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtPagaCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().ListarProducto().Where(p => p.Codigo == TxtCodigo.Text && p.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    TxtCodigo.BackColor = Color.Honeydew;
                    TxtIdProducto.Text = oProducto.IdProducto.ToString();
                    TxtProducto.Text = oProducto.Nombre;
                    TxtPrecioVenta.Text = oProducto.PrecioVenta.ToString("0.00");
                    TxtStock.Text = oProducto.Stock.ToString();
                    NudCantidad.Select();
                }
                else
                {
                    TxtCodigo.BackColor = Color.MistyRose;
                    TxtIdProducto.Text = "0";
                    TxtProducto.Text = "";
                    TxtPrecioVenta.Text = "";
                    TxtStock.Text = "";
                    NudCantidad.Value = 0;
                }
            }
        }

        private void TxtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtStock.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
