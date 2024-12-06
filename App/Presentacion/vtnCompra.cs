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
            cmb1.Items.Add(new { Valor = "Boleta", Texto = "Boleta" });
            cmb1.Items.Add(new { Valor = "Factura", Texto = "Factura" });
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;
            txt1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt4.Text = "0";
            txt5.Text = "0";
            txt12.Text = "0";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesProveedores())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txt4.Text = modal.Proveedor.IdProveedor.ToString();
                    txt2.Text = modal.Proveedor.Documento.ToString();
                    txt3.Text = modal.Proveedor.Nombres.ToString();
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
                    txt8.Select();
                }
                else
                {
                    txt6.Select();
                }
            }
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {
            using (var modal = new vtnModalesTransportista())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txt12.Text = modal.Transportista.IdTransportista.ToString();
                    txt10.Text = modal.Transportista.Documento.ToString();
                    txt11.Text = modal.Transportista.Nombres.ToString();
                }
                else
                {
                    txt12.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExistente = false;

            if (int.Parse(txt5.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txt8.Text, out precioCompra))
            {
                MessageBox.Show("Formato moneda incorrecto.", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt8.Select();
                return;
            }
            if (!decimal.TryParse(txt9.Text, out precioVenta))
            {
                MessageBox.Show("Formato moneda incorrecta", "Agregar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt9.Select();
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
                if (fila.Cells["ID"].Value != null && fila.Cells["ID"].Value.ToString() == txt5.Text)
                {
                    productoExistente = true;
                    break;
                }
            }
            if (!productoExistente)
            {
                tablaCompras.Rows.Add(new object[]{
                    txt5.Text,
                    txt7.Text,
                    precioCompra.ToString("0.00"),
                    precioVenta.ToString("0.00"),
                    numericUpDown1.Value.ToString(),
                    (numericUpDown1.Value * precioCompra).ToString("0.00")
                });
                calcularTotal();
                Limpiar();
                txt6.Select();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string tipoDocumento = ((dynamic)cmb1.SelectedItem).Texto;
            if (Convert.ToInt32(txt4.Text) == 0 && Convert.ToInt32(txt12.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Realizar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(txt12.Text) == 0)
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
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txt4.Text) },
                oTransportista = new Transportista() { IdTransportista = Convert.ToInt32(txt12.Text)},
                TipoDocumento = tipoDocumento,
                NumeroDocumento = numeroDocumento,
                MontoTotal = Convert.ToDecimal(txt13.Text)
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
                txt4.Clear();
                txt2.Clear();
                txt3.Clear();
                txt12.Clear();
                txt11.Clear();
                txt10.Clear();
                txt13.Clear();
                tablaCompras.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Realizar compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tablaCompras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCompras.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    tablaCompras.Rows.RemoveAt(indice);
                    calcularTotal();
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
                    txt8.Select();
                }
                else
                {
                    txt6.BackColor = Color.MistyRose;
                    txt5.Text = "0";
                    txt7.Text = "";
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
        private void calcularTotal()
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
                txt13.Text = total.ToString("0.00");
            }
        }
    }
}
