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
    public partial class vtnVerDetalleVentas : Form
    {
        public vtnVerDetalleVentas()
        {
            InitializeComponent();
        }
        private void vtnVerDetalleVentas_Load(object sender, EventArgs e)
        {
            txt1.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CapaNegocios().obtvSQL(txt1.Text);
            if (oVenta.IdVenta != 0)
            {
                txt2.Text = oVenta.FechaVenta;
                txt3.Text = oVenta.TipoDocumento;
                txt4.Text = oVenta.oUsuario.NombreCompleto;
                txt5.Text = oVenta.DocumentoCliente;
                txt6.Text = oVenta.NombreCliente;
                txt7.Text = oVenta.NumeroDocumento;
                tablaDetallesVentas.Rows.Clear();
                foreach (Detalle_Venta dv in oVenta.oDetalle_Venta)
                {
                    tablaDetallesVentas.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.CantidadProducto, dv.SubTotal, dv.Descuento });
                }

                txt8.Text = oVenta.MontoTotal.ToString("0.00");
                txt10.Text = oVenta.MontoPago.ToString("0.00");
                txt11.Text = oVenta.MontoCambio.ToString("0.00");
                txt9.Text = oVenta.Descuento.ToString("0.00");
            }
            else
            {
                MessageBox.Show("El número de documento ingresado no existe.", "Detalles de los productos vendidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            tablaDetallesVentas.Rows.Clear();
            txt8.Text = "0.00";
            txt10.Text = "0.00";
            txt11.Text = "0.00";
            txt9.Text = "0.00";
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (txt7.Text == "")
            {
                MessageBox.Show("No hay datos para generar el PDF.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string texto_html = Properties.Resources.ArchivoVenta.ToString();
            Negocio oDatos = new CapaDatos().obtenerDatos();

            texto_html = texto_html.Replace("@nombrenegocio", oDatos.Nombre.ToUpper());
            texto_html = texto_html.Replace("@telefono", oDatos.Telefono);
            texto_html = texto_html.Replace("@docnegocio", oDatos.Ruc);
            texto_html = texto_html.Replace("@direcnegocio", oDatos.Direccion);
            texto_html = texto_html.Replace("@correoElectronico", oDatos.CorreoElectronico);

            texto_html = texto_html.Replace("@tipodocumento", txt3.Text.ToUpper());
            texto_html = texto_html.Replace("@numerodocumento", txt1.Text);

            texto_html = texto_html.Replace("@doccliente", txt5.Text);
            texto_html = texto_html.Replace("@nombrecliente", txt6.Text);
            texto_html = texto_html.Replace("@fecharegistro", txt2.Text);
            texto_html = texto_html.Replace("@usuarioregistro", txt4.Text);

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
            texto_html = texto_html.Replace("@montototal", txt8.Text);
            texto_html = texto_html.Replace("@descuento", txt9.Text);
            texto_html = texto_html.Replace("@pagocon", txt10.Text);
            texto_html = texto_html.Replace("@cambio", txt11.Text);

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = string.Format("DetallesVentas.pdf", txt1.Text);
            guardar.Filter = "Pdf files |*.pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CapaNegocios().obtlSQL(out obtenido);
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

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Número Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
