using Entidad;
using Negocios;
using Presentacion.Modales;
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
    public partial class vtnCompra : Form
    {
        private Usuario Usuario;
        public vtnCompra(Usuario oUsuario = null)
        {
            Usuario = oUsuario;
            InitializeComponent();
        }

        private void vtnCompra_Load(object sender, EventArgs e)
        {
            CmbTipoDocumento.Items.Add(new { Valor = "Boleta", Texto = "Boleta" });
            CmbTipoDocumento.Items.Add(new { Valor = "Factura", Texto = "Factura" });
            CmbTipoDocumento.DisplayMember = "Texto";
            CmbTipoDocumento.ValueMember = "Valor";
            CmbTipoDocumento.SelectedIndex = 0;
            TxtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TxtIdProveedor.Text = "0";
            TxtIdProducto.Text = "0";
            TxtIdTransportista.Text = "0";
        }

        private void BtnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesProveedores())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtIdProveedor.Text = modal.Proveedor.IdProveedor.ToString();
                    TxtCodigoProveedor.Text = modal.Proveedor.Codigo.ToString();
                    TxtNombresProveedor.Text = modal.Proveedor.Nombres.ToString();
                }
                else
                {
                    TxtIdProveedor.Select();
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
                    TxtCodigoProducto.Text = modal.Producto.Codigo.ToString();
                    TxtProducto.Text = modal.Producto.Nombre.ToString();
                    TxtPrecioCompra.Select();
                }
                else
                {
                    TxtCodigoProducto.Select();
                }
            }
        }

        private void BtnBuscarTransportista_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesTransportista())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtIdTransportista.Text = modal.Transportista.IdTransportista.ToString();
                    TxtCodigoTransportista.Text = modal.Transportista.Codigo.ToString();
                    TxtNombresTransportista.Text = modal.Transportista.Nombres.ToString();
                }
                else
                {
                    TxtIdTransportista.Select();
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExistente = false;

            if (int.Parse(TxtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(TxtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Formato moneda incorrecto.", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPrecioCompra.Select();
                return;
            }
            if (!decimal.TryParse(TxtPreciVenta.Text, out precioVenta))
            {
                MessageBox.Show("Formato moneda incorrecta", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPreciVenta.Select();
                return;
            }
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("No puedes realizar una compra con 0 productos.", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Select(); 
                return;
            }
            foreach (DataGridViewRow fila in tablaCompras.Rows)
            {
                if (fila.Cells["ID"].Value != null && fila.Cells["ID"].Value.ToString() == TxtIdProducto.Text)
                {
                    productoExistente = true;
                    break;
                }
            }
            if (!productoExistente)
            {
                tablaCompras.Rows.Add(new object[]{
                    TxtIdProducto.Text,
                    TxtProducto.Text,
                    precioCompra.ToString("0.00"),
                    precioVenta.ToString("0.00"),
                    numericUpDown1.Value.ToString(),
                    (numericUpDown1.Value * precioCompra).ToString("0.00")
                });
                CalcularTotal();
                Limpiar();
                TxtCodigoProducto.Select();
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string tipoDocumento = ((dynamic)CmbTipoDocumento.SelectedItem).Texto;
            if (Convert.ToInt32(TxtIdProveedor.Text) == 0 && Convert.ToInt32(TxtIdTransportista.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Realizar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(TxtIdTransportista.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un transportista.", "Realizar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tablaCompras.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar un producto en la compra.", "Realizar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable detalla_compra = new DataTable();
            detalla_compra.Columns.Add("Id_Producto", typeof(int));
            detalla_compra.Columns.Add("Precio_Compra", typeof(decimal));
            detalla_compra.Columns.Add("Precio_Venta", typeof(decimal));
            detalla_compra.Columns.Add("Cantidad", typeof(int));
            detalla_compra.Columns.Add("Monto_Total", typeof(decimal));
            foreach (DataGridViewRow row in tablaCompras.Rows)
            {
                detalla_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["ID"].Value.ToString()),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString()
                    });
            }
            int idCorrelativo = new CN_Compra().MostrarCorrelativoCompra();
            string numeroDocumento = string.Format("{0:00000}", idCorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(TxtIdProveedor.Text) },
                oTransportista = new Transportista() { IdTransportista = Convert.ToInt32(TxtIdTransportista.Text)},
                TipoDocumento = tipoDocumento,
                NumeroDocumento = numeroDocumento,
                MontoTotal = Convert.ToDecimal(TxtTotalPagar.Text)
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalla_compra, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("Compra realizada exitosamente.", "Editar Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var a = MessageBox.Show("Numero de compra generado:\n" + numeroDocumento + "\n¿Desea copiar al cortapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    System.Windows.Forms.Clipboard.SetText(numeroDocumento);
                }
                TxtIdProveedor.Clear();
                TxtCodigoProveedor.Clear();
                TxtNombresProveedor.Clear();
                TxtIdTransportista.Clear();
                TxtNombresTransportista.Clear();
                TxtCodigoTransportista.Clear();
                TxtTotalPagar.Clear();
                tablaCompras.Rows.Clear();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Realizar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TablaCompras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCompras.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    tablaCompras.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }

        private void Limpiar()
        {
            TxtIdProducto.Text = "0";
            TxtCodigoProducto.Text = "";
            TxtCodigoProducto.BackColor = Color.White;
            TxtProducto.Text = "";
            TxtPrecioCompra.Text = "";
            TxtPreciVenta.Text = "";
            numericUpDown1.Value = 0;
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            if (tablaCompras.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaCompras.Rows)
                {
                    var subTotalCellValue = row.Cells["SubTotal"].Value;
                    if (subTotalCellValue != null)
                    {
                        total += Convert.ToDecimal(subTotalCellValue.ToString());
                    }
                }
                TxtTotalPagar.Text = total.ToString("0.00");
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
                if (TxtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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

        private void TxtPreciVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtPreciVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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

        private void TxtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().ListarProducto().Where(p => p.Codigo == TxtCodigoProducto.Text && p.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    TxtCodigoProducto.BackColor = Color.Honeydew;
                    TxtIdProducto.Text = oProducto.IdProducto.ToString();
                    TxtProducto.Text = oProducto.Nombre;
                    TxtPrecioCompra.Select();
                }
                else
                {
                    TxtCodigoProducto.BackColor = Color.MistyRose;
                    TxtIdProducto.Text = "0";
                    TxtProducto.Text = "";
                }
            }
        }
    }
}
