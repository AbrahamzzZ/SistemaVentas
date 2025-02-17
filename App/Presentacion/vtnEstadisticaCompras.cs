using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Presentacion
{
    /// <summary>
    /// Clase que representa la ventana de las estadistica de las compras.
    /// </summary>
    public partial class VtnEstadisticaCompras : Form
    {
        /// <summary>
        /// Constructor de la clase VtnGraficaCompras.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnEstadisticaCompras()
        {
            InitializeComponent();
        }

        private void BtnCargarDatos_Click(object sender, EventArgs e)
        {
            LimpiarGrafica();
            DataTable dt = new CN_Compra().GraficaCompra();
            graficaCompra.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            graficaCompra.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            if (dt.Rows.Count > 0)
            {
                graficaCompra.Titles.Add("Productos Comprados");
                foreach (DataRow row in dt.Rows)
                {
                    Series serie = graficaCompra.Series.Add(row["Nombre_Producto"].ToString());
                    serie.Points.Add(Convert.ToInt32(row["Cantidad_Comprada"].ToString()));
                    serie.Label = row["Cantidad_Comprada"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos para generar la gráfica.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargarDatos2_Click(object sender, EventArgs e)
        {
            LimpiarGrafica();
            DataTable dt = new CN_Compra().GraficaCompra2();
            if (dt.Rows.Count > 0)
            {
                graficaCompra.Titles.Add("Proveedores de preferencia");
                foreach (DataRow row in dt.Rows)
                {
                    Series serie = graficaCompra.Series.Add(row["Nombres"].ToString());
                    serie.Points.Add(Convert.ToInt32(row["Compras_Totales"].ToString()));
                    serie.Label = row["Compras_Totales"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos para generar la gráfica.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargarDatos3_Click(object sender, EventArgs e)
        {
            LimpiarGrafica();
            DataTable dt = new CN_Compra().GraficaCompra3();
            if (dt.Rows.Count > 0)
            {
                graficaCompra.Titles.Add("Viajes Transportista");
                foreach (DataRow row in dt.Rows)
                {
                    Series serie = graficaCompra.Series.Add(row["Nombres"].ToString());
                    serie.Points.Add(Convert.ToInt32(row["Viajes_Realizados"].ToString()));
                    serie.Label = row["Viajes_Realizados"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos para generar la gráfica.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string logoRuta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Logo.png");

                using (MemoryStream ms = new MemoryStream())
                {
                    graficaCompra.SaveImage(ms, ChartImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);

                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Guardar gráfico de ventas como PDF";
                        saveFileDialog.FileName = "Detalles_Grafica_Compras.pdf";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document documento = new iTextSharp.text.Document();
                                iTextSharp.text.pdf.PdfWriter.GetInstance(documento, fs);

                                documento.Open();

                                PdfPTable tablaEncabezado = new PdfPTable(2);
                                tablaEncabezado.WidthPercentage = 100;
                                tablaEncabezado.SetWidths(new float[] { 1f, 3f });

                                if (System.IO.File.Exists(logoRuta))
                                {
                                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoRuta);
                                    logo.ScaleToFit(60f, 60f);
                                    PdfPCell celdaLogo = new PdfPCell(logo);
                                    celdaLogo.Border = PdfPCell.NO_BORDER;
                                    celdaLogo.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                    celdaLogo.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                                    tablaEncabezado.AddCell(celdaLogo);
                                }
                                else
                                {
                                    tablaEncabezado.AddCell("");
                                }

                                var fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                                var fontTexto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);

                                PdfPCell celdaInfo = new PdfPCell();
                                celdaInfo.Border = PdfPCell.NO_BORDER;
                                celdaInfo.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                celdaInfo.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                                celdaInfo.AddElement(new Phrase("SUPERMERCADO PARADISIA\n", fontTitulo));
                                celdaInfo.AddElement(new Phrase(
                                    "Teléfono: 0969810812\n" +
                                    "RUC: 0102030405123\n" +
                                    "Dirección: Mucho Lote 3 etapa\n" +
                                    "Correo Electrónico: SupermercadoParadisia@gmail.com", fontTexto
                                ));

                                tablaEncabezado.AddCell(celdaInfo);
                                documento.Add(tablaEncabezado);

                                iTextSharp.text.pdf.draw.LineSeparator linea = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
                                documento.Add(new Chunk(linea));

                                documento.Add(new iTextSharp.text.Paragraph("\n"));

                                iTextSharp.text.Paragraph titulo = new iTextSharp.text.Paragraph(
                                    "Gráfico de Compras\n",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD)
                                );
                                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                                documento.Add(titulo);

                                iTextSharp.text.Paragraph fecha = new iTextSharp.text.Paragraph(
                                    $"Generado el: {DateTime.Now.ToString("g")}\n\n",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)
                                );
                                fecha.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                                documento.Add(fecha);

                                iTextSharp.text.Image imagenGrafica = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                imagenGrafica.ScaleToFit(500f, 300f);
                                imagenGrafica.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                                documento.Add(imagenGrafica);

                                documento.Close();
                            }

                            MessageBox.Show("PDF generado con éxito.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que sirve para limpiar el chart
        /// </summary>
        private void LimpiarGrafica()
        {
            graficaCompra.Series.Clear();
            graficaCompra.Titles.Clear();
        }
    }
}
