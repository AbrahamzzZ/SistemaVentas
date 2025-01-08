using Entidad;
using Datos;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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
    public partial class VtnVerDetalleVentas : Form
    {
        public VtnVerDetalleVentas()
        {
            InitializeComponent();
        }
        private void VtnVerDetalleVentas_Load(object sender, EventArgs e)
        {
            TxtNumeroDocumentoVenta.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CN_Venta().DetalleVenta(TxtNumeroDocumentoVenta.Text);
            if (oVenta.IdVenta != 0)
            {
                TxtFechaVenta.Text = oVenta.FechaVenta;
                TxtTipoDocumento.Text = oVenta.TipoDocumento;
                TxtNombreCompletoUsuario.Text = oVenta.oUsuario.NombreCompleto;
                TxtCedulaCliente.Text = oVenta.oCliente.Cedula;
                TxtNombresCliente.Text = oVenta.oCliente.Nombres;
                tablaDetallesVentas.Rows.Clear();
                foreach (Detalle_Venta dv in oVenta.oDetalle_Venta)
                {
                    tablaDetallesVentas.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.CantidadProducto, dv.SubTotal, dv.Descuento });
                }

                TxtMontoTotal.Text = oVenta.MontoTotal.ToString("0.00");
                TxtMontoPago.Text = oVenta.MontoPago.ToString("0.00");
                TxtMontoCambio.Text = oVenta.MontoCambio.ToString("0.00");
                TxtDescuento.Text = oVenta.Descuento.ToString("0.00");
            }
            else
            {
                MessageBox.Show("El número de documento ingresado no existe.", "Detalles de los productos vendidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtNumeroDocumentoVenta.Text = "";
            TxtFechaVenta.Text = "";
            TxtTipoDocumento.Text = "";
            TxtNombreCompletoUsuario.Text = "";
            TxtCedulaCliente.Text = "";
            TxtNombresCliente.Text = "";
            tablaDetallesVentas.Rows.Clear();
            TxtMontoTotal.Text = "";
            TxtMontoPago.Text = "";
            TxtMontoCambio.Text = "";
            TxtDescuento.Text = "";
        }

        private void BtnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (TxtNumeroDocumentoVenta.Text == "")
            {
                MessageBox.Show("No hay datos para generar el PDF.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string texto_html = Properties.Resources.ArchivoVenta.ToString();
            Negocio oDatos = new CN_Negocio().ListarNegocio();

            texto_html = texto_html.Replace("@nombrenegocio", oDatos.Nombre.ToUpper());
            texto_html = texto_html.Replace("@telefono", oDatos.Telefono);
            texto_html = texto_html.Replace("@docnegocio", oDatos.Ruc);
            texto_html = texto_html.Replace("@direcnegocio", oDatos.Direccion);
            texto_html = texto_html.Replace("@correoElectronico", oDatos.CorreoElectronico);

            texto_html = texto_html.Replace("@tipodocumento", TxtTipoDocumento.Text.ToUpper());
            texto_html = texto_html.Replace("@numerodocumento", TxtNumeroDocumentoVenta.Text);

            texto_html = texto_html.Replace("@cedulacliente", TxtCedulaCliente.Text);
            texto_html = texto_html.Replace("@nombrecliente", TxtNombresCliente.Text);
            texto_html = texto_html.Replace("@fecharegistro", TxtFechaVenta.Text);
            texto_html = texto_html.Replace("@usuarioregistro", TxtNombreCompletoUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in tablaDetallesVentas.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            texto_html = texto_html.Replace("@filas", filas);
            texto_html = texto_html.Replace("@montototal", TxtMontoTotal.Text);
            texto_html = texto_html.Replace("@descuento", TxtDescuento.Text);
            texto_html = texto_html.Replace("@pagocon", TxtMontoPago.Text);
            texto_html = texto_html.Replace("@cambio", TxtMontoCambio.Text);

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = string.Format("Detalle_Ventas.pdf", TxtNumeroDocumentoVenta.Text);
            guardar.Filter = "Pdf files |*.pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().MostrarLogo(out obtenido);
                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(texto_html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("El PDF fue generado correctamente.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void TxtCodigoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Número Codigo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
