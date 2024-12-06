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
    public partial class vtnVenta : Form
    {
        private Usuario usuario;
        public vtnVenta(Usuario oUsuario = null)
        {
            usuario = oUsuario;
            InitializeComponent();
        }

        private void vtnVenta_Load(object sender, EventArgs e)
        {
            cmb1.Items.Add(new { Valor = "Boleta", Texto = "Boleta" });
            cmb1.Items.Add(new { Valor = "Factura", Texto = "Factura" });
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;

            txt1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt4.Text = "0";
            txt5.Text = "0";
            txt10.Text = "";
            txt11.Text = "0";
            txt12.Text = "";
            txt13.Text = "";
            txt14.Text = "";
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesClientes())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txt4.Text = modal.Cliente.IdCliente.ToString();
                    txt2.Text = modal.Cliente.Documento.ToString();
                    txt3.Text = modal.Cliente.Nombres.ToString();
                }
                else
                {
                    txt4.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesProductos())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txt5.Text = modal.Producto.IdProducto.ToString();
                    txt6.Text = modal.Producto.Codigo.ToString();
                    txt7.Text = modal.Producto.Nombre.ToString();
                    txt8.Text = modal.Producto.PrecioVenta.ToString("0.00");
                    txt9.Text = modal.Producto.Stock.ToString();
                    numericUpDown1.Select();
                }
            }
        }
        private void btnBuscarOfertas_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesOfertas())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtOferta.Text = modal.oferta.NombreOferta.ToString();
                    txt10.Text = modal.oferta.Descuento.ToString();
                }
                else
                {
                    txtOferta.Clear();
                    txt10.Clear();
                    txt13.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExistente = false;

            if (int.Parse(txt5.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txt8.Text, out precio))
            {
                MessageBox.Show("Formato moneda incorrecta.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt8.Select();
                return;
            }
            if (Convert.ToInt32(txt9.Text) < Convert.ToInt32(numericUpDown1.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("No puedes realizar una venta con 0 productos.", "Agregar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Select(); 
                return;
            }
            foreach (DataGridViewRow fila in tablaVentas.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null && fila.Cells["IdProducto"].Value.ToString() == txt5.Text)
                {
                    productoExistente = true;
                    break;
                }
            }
            if (!productoExistente)
            {
                List<Oferta> listaOferta = new CN_Oferta().ListarOferta();
                bool respuesta = new CN_Venta().RestarSotckProducto(Convert.ToInt32(txt5.Text), Convert.ToInt32(numericUpDown1.Value.ToString()));
                if (respuesta)
                {
                    decimal subTotal = numericUpDown1.Value * precio;
                    decimal descuento = 0;
                    if (!string.IsNullOrEmpty(txt10.Text))
                    {
                        descuento = Convert.ToDecimal(txt10.Text);
                    }
                    decimal totalConDescuento = subTotal - (subTotal * descuento / 100);
                    tablaVentas.Rows.Add(new object[]{
                        txt5.Text,
                        txt7.Text,
                        precio.ToString("0.00"),
                        numericUpDown1.Value.ToString(),
                        (numericUpDown1.Value * precio).ToString("0.00"),
                        totalConDescuento.ToString("0.00")
                    }) ;
                    calcularTotal();
                    Limpiar();
                }
            }
        }
      
        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            string tipoDocumento = ((dynamic)cmb1.SelectedItem).Texto;
            if (txt2.Text == "")
            {
                MessageBox.Show("Debe ingresar el documento del cliente.", "Realizar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt3.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente.", "Realizar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tablaVentas.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar un producto a la venta", "Realizar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt13.Text == "")
            {
                MessageBox.Show("Debe ingresar el valor a pagar.", "Editar Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt13.Select();
            }
            else
            {
                DataTable detalleVenta = new DataTable();
                detalleVenta.Columns.Add("IdProducto", typeof(int));
                detalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
                detalleVenta.Columns.Add("Cantidad", typeof(int));
                detalleVenta.Columns.Add("SubTotal", typeof(decimal));
                detalleVenta.Columns.Add("Descuento", typeof(decimal));
                foreach (DataGridViewRow row in tablaVentas.Rows)
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
                calcularCambio();
                Venta oVenta = new Venta()
                {
                    oUsuario = new Usuario() { IdUsuario = usuario.IdUsuario },
                    TipoDocumento = tipoDocumento,
                    NumeroDocumento = numeroDocumento,
                    DocumentoCliente = txt2.Text,
                    NombreCliente = txt3.Text,
                    MontoTotal = Convert.ToDecimal(txt11.Text),
                    Descuento = Convert.ToDecimal(txt12.Text),
                    MontoPago = Convert.ToDecimal(txt13.Text),
                    MontoCambio = Convert.ToDecimal(txt14.Text),
                };

                string mensaje = string.Empty;
                bool respuesta = new CN_Venta().Registrar(oVenta, detalleVenta, out mensaje);
                if (respuesta)
                {
                    MessageBox.Show("Venta realizada exitosamente.", "Editar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var result = MessageBox.Show("Numero de venta generado:\n" + numeroDocumento + "\n\n ¿Dsea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        System.Windows.Forms.Clipboard.SetText(numeroDocumento);
                    }
                    txt2.Text = "";
                    txt3.Text = "";
                    txt11.Text = "";
                    txt12.Text = "";
                    txt13.Text = "";
                    txt14.Text = "";
                    tablaVentas.Rows.Clear();
                    calcularTotal();
                }
                else
                {
                    MessageBox.Show(mensaje, "Realizar venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void tablaVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaVentas.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    bool respuesta = new CN_Venta().SumarSotckProducto(
                    Convert.ToInt32(tablaVentas.Rows[indice].Cells["IdProducto"].Value.ToString()),
                    Convert.ToInt32(tablaVentas.Rows[indice].Cells["Cantidad"].Value.ToString()));
                    if (respuesta)
                    {
                        tablaVentas.Rows.RemoveAt(indice);
                        calcularTotal();
                    }
                }
            }
        }
        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().ListarProducto().Where(p => p.Codigo == txt6.Text && p.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txt6.BackColor = Color.Honeydew;
                    txt5.Text = oProducto.IdProducto.ToString();
                    txt7.Text = oProducto.Nombre;
                    txt8.Text = oProducto.PrecioVenta.ToString("0.00");
                    txt9.Text = oProducto.Stock.ToString();
                    numericUpDown1.Select();
                }
                else
                {
                    txt6.BackColor = Color.MistyRose;
                    txt5.Text = "0";
                    txt7.Text = "";
                    txt8.Text = "";
                    txt9.Text = "";
                    numericUpDown1.Value = 0;
                }
            }
        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt8.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txt9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt9.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txt13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularCambio();
            }
        }

        private void txt13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt13.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void calcularTotal()
        {
            decimal total = 0;
            decimal totalDescuento = 0;
            if (tablaVentas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaVentas.Rows)
                {
                    var subTotalCellValue = row.Cells["SubTotal"].Value;
                    var subTotalDescuentoCellValue = row.Cells["Descuento"].Value;
                    if (subTotalCellValue != null)
                    {
                        total += Convert.ToDecimal(subTotalCellValue.ToString());
                        totalDescuento += Convert.ToDecimal(subTotalDescuentoCellValue.ToString());
                    }
                }
                txt11.Text = total.ToString("0.00");
                txt12.Text = totalDescuento.ToString("0.00");
            }
        }
        private void calcularCambio()
        {
            if (txt12.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal pagacon;
            decimal total = Convert.ToDecimal(txt12.Text);

            if (txt13.Text.Trim() == "")
            {
                txt13.Text = "0";
            }
            if (decimal.TryParse(txt13.Text.Trim(), out pagacon))
            {
                if (pagacon < total)
                {
                    txt14.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txt14.Text = cambio.ToString("0.00");
                }
            }
        }
        private void Limpiar()
        {
            txt5.Text = "0";
            txt6.Text = "";
            txt6.BackColor = Color.White;
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            numericUpDown1.Value = 0;
        }
    }
}
