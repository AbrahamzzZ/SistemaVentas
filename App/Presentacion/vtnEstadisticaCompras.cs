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
    public partial class VtnGraficaCompras : Form
    {
        /// <summary>
        /// Constructor de la clase VtnGraficaCompras.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnGraficaCompras()
        {
            InitializeComponent();
        }

        private void BtnCargarDatosVentas_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new CN_Compra().GraficaCompra();
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
                MessageBox.Show("No se encontraron compras registradas para generar la gráfica.", "Grafica de los productos comprados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta del logotipo en la carpeta Resources
                string logoRuta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Logo.png");

                // Capturar la gráfica como imagen
                using (MemoryStream ms = new MemoryStream())
                {
                    graficaCompra.SaveImage(ms, ChartImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);

                    // Crear un nuevo documento PDF
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

                                // Crear una tabla con dos columnas para el logotipo y la información
                                PdfPTable tablaEncabezado = new PdfPTable(2);
                                tablaEncabezado.WidthPercentage = 100; // Ajustar la tabla al 100% del ancho
                                tablaEncabezado.SetWidths(new float[] { 1f, 3f }); // Proporción entre columnas

                                // Columna del logotipo
                                if (System.IO.File.Exists(logoRuta))
                                {
                                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoRuta);
                                    logo.ScaleToFit(60f, 60f); // Ajustar tamaño del logotipo
                                    PdfPCell celdaLogo = new PdfPCell(logo);
                                    celdaLogo.Border = PdfPCell.NO_BORDER; // Sin bordes
                                    celdaLogo.VerticalAlignment = PdfPCell.ALIGN_MIDDLE; // Centrar verticalmente
                                    celdaLogo.HorizontalAlignment = PdfPCell.ALIGN_LEFT; // Alinear a la izquierda
                                    tablaEncabezado.AddCell(celdaLogo);
                                }
                                else
                                {
                                    tablaEncabezado.AddCell(""); // Espacio vacío si no hay logotipo
                                }

                                // Columna de la información
                                var fontTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                                var fontTexto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);

                                PdfPCell celdaInfo = new PdfPCell();
                                celdaInfo.Border = PdfPCell.NO_BORDER; // Sin bordes
                                celdaInfo.VerticalAlignment = PdfPCell.ALIGN_MIDDLE; // Centrar verticalmente
                                celdaInfo.HorizontalAlignment = PdfPCell.ALIGN_LEFT; // Alinear texto a la izquierda

                                // Construir el texto con título en negritas y resto en formato normal
                                celdaInfo.AddElement(new Phrase("SUPERMERCADO PARADISIA\n", fontTitulo));
                                celdaInfo.AddElement(new Phrase(
                                    "Teléfono: 0969810812\n" +
                                    "RUC: 0102030405123\n" +
                                    "Dirección: Mucho Lote 3 etapa\n" +
                                    "Correo Electrónico: SupermercadoParadisia@gmail.com", fontTexto
                                ));

                                tablaEncabezado.AddCell(celdaInfo);

                                // Añadir la tabla al documento
                                documento.Add(tablaEncabezado);

                                // Añadir una línea divisoria
                                iTextSharp.text.pdf.draw.LineSeparator linea = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
                                documento.Add(new Chunk(linea));

                                // Espacio después del encabezado
                                documento.Add(new iTextSharp.text.Paragraph("\n"));

                                // Añadir un título al PDF
                                iTextSharp.text.Paragraph titulo = new iTextSharp.text.Paragraph(
                                    "Gráfico de Compras\n",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD)
                                );
                                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                                documento.Add(titulo);

                                // Añadir la fecha de generación
                                iTextSharp.text.Paragraph fecha = new iTextSharp.text.Paragraph(
                                    $"Generado el: {DateTime.Now.ToString("g")}\n\n",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)
                                );
                                fecha.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                                documento.Add(fecha);

                                // Convertir la gráfica a iTextSharp Image
                                iTextSharp.text.Image imagenGrafica = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                imagenGrafica.ScaleToFit(500f, 300f); // Ajustar el tamaño de la imagen
                                imagenGrafica.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                                // Añadir la gráfica al PDF
                                documento.Add(imagenGrafica);

                                // Cerrar el documento
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
    }
}
