using ClosedXML.Excel;
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
    public partial class vtnReportesVentas : Form
    {
        public vtnReportesVentas()
        {
            InitializeComponent();
        }
        private void vtnReportesVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaReporteVentas.Columns)
            {
                cmb1.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });

            }
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;
        }
        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            List<Reporte_Venta> lista = new List<Reporte_Venta>();
            lista = new CapaNegocios().revSQL(txtFecha1.Value.ToString("yyyy-MM-dd"), txtFecha2.Value.ToString("yyyy-MM-dd"));

            tablaReporteVentas.Rows.Clear();
            if (lista.Count > 0) {
                foreach (Reporte_Venta row in lista)
                {
                    tablaReporteVentas.Rows.Add(new object[]
                    {
                        row.FechaRegistro, row.TipoDocumento, row.NumeroDocumento, row.MontoTotal, row.UsuarioRegistro, row.DocumentoCliente, row.NombreCliente, row.CodigoProducto, row.NombreProducto, row.Categoria, row.PrecioVenta, row.Cantidad, row.SubTotal, row.Descuento
                    });
                }
            }
            else
            {
                MessageBox.Show("No hay ventas en las fechas especificadas.", "Tabla Reporte Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaReporteVentas.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaReporteVentas.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in tablaReporteVentas.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Reporte_Ventas.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Reportes");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(guardar.FileName);
                        MessageBox.Show("Reporte generado exitosamente.", "Excel generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el Excel.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();
            int filasVisibles = 0;

            if (tablaReporteVentas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaReporteVentas.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().ToUpper().Contains(txt1.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            // Verificar si hay filas visibles y mostrar un mensaje si no hay
            if (filasVisibles == 0)
            {
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt1.Clear();
            foreach (DataGridViewRow row in tablaReporteVentas.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
