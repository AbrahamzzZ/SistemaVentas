using Datos;
using Entidad;
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
    public partial class vtnVerDetalleCompras : Form
    {
        public vtnVerDetalleCompras()
        {
            InitializeComponent();
        }

        private void vtnVerDetalleCompras_Load(object sender, EventArgs e)
        {
            TxtNumeroCodigoCompra.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().DetalleCompra(TxtNumeroCodigoCompra.Text);
            if (oCompra.IdCompra != 0)
            {
                TxtFechaCompra.Text = oCompra.FechaCompra;
                TxtTipoDocumento.Text = oCompra.TipoDocumento;
                TxtNombreCompletoUsuario.Text = oCompra.oUsuario.NombreCompleto;
                TxtCodigoProveedor.Text = oCompra.oProveedor.Codigo;
                TxtNombresProveedor.Text = oCompra.oProveedor.Nombres;
                TxtCodigoTransportista.Text = oCompra.oTransportista.Codigo;
                TxtNombresTransportista.Text = oCompra.oTransportista.Nombres;
 
                tablaDetallesCompras.Rows.Clear();
                foreach (Detalle_Compra dc in oCompra.oDetalle_Compra)
                {
                    tablaDetallesCompras.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                TxtMontoTotal.Text = oCompra.MontoTotal.ToString("0.00");
            }
            else
            {
                MessageBox.Show("El número de documento ingresado no existe.", "Detalles de los productos comprados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtNumeroCodigoCompra.Text = "";
            TxtFechaCompra.Text = "";
            TxtTipoDocumento.Text = "";
            TxtNombreCompletoUsuario.Text = "";
            TxtCodigoProveedor.Text = "";
            TxtNombresProveedor.Text = "";
            tablaDetallesCompras.Rows.Clear();
            TxtCodigoTransportista.Text = "";
            TxtNombresTransportista.Text = "";
            TxtMontoTotal.Text = "0.00";
        }

        private void BtnDescargarPdf_Click(object sender, EventArgs e)
        {
            string texto_html = Properties.Resources.ArchivoCompra.ToString();
            Negocio oDatos = new CN_Negocio().ListarNegocio();

            texto_html = texto_html.Replace("@nombrenegocio", oDatos.Nombre.ToUpper());
            texto_html = texto_html.Replace("@telefono", oDatos.Telefono);
            texto_html = texto_html.Replace("@docnegocio", oDatos.Ruc);
            texto_html = texto_html.Replace("@direcnegocio", oDatos.Direccion);
            texto_html = texto_html.Replace("@correoElectronico", oDatos.CorreoElectronico);

            texto_html = texto_html.Replace("@tipodocumento", TxtTipoDocumento.Text.ToUpper());
            texto_html = texto_html.Replace("@numerodocumento", TxtNumeroCodigoCompra.Text);

            texto_html = texto_html.Replace("@codigoproveedor", TxtCodigoProveedor.Text);
            texto_html = texto_html.Replace("@nombreproveedor", TxtNombresProveedor.Text);
            texto_html = texto_html.Replace("@codigotransportista", TxtCodigoTransportista.Text);
            texto_html = texto_html.Replace("@nombretransportista", TxtNombresTransportista.Text);
            texto_html = texto_html.Replace("@fecharegistro", TxtFechaCompra.Text);
            texto_html = texto_html.Replace("@usuarioregistro", TxtNombreCompletoUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in tablaDetallesCompras.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            texto_html = texto_html.Replace("@filas", filas);
            texto_html = texto_html.Replace("@montototal", TxtMontoTotal.Text);

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = string.Format("DetallesCompras.pdf", TxtNumeroCodigoCompra.Text);
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

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Número Codigo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
