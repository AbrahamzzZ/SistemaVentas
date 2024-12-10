using ClosedXML.Excel;
using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class vtnReportesCompras : Form
    {
        public vtnReportesCompras()
        {
            InitializeComponent();
        }

        private void vtnReportesCompras_Load(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbProveedor.SelectedItem;
            int valorCmb1 = 0;
            string textoCmb1 = string.Empty;
            if (selectedItemCmb1 != null)
            {
                valorCmb1 = selectedItemCmb1.Valor;
                textoCmb1 = selectedItemCmb1.Texto;
            }
            List<Proveedor> mostrarProveedor = new CN_Proveedor().ListarProveedores();
            CmbProveedor.Items.Add(new { Valor = 0, Texto = "Todos" });
            foreach (Proveedor proveedor in mostrarProveedor)
            {
                // Crear un objeto anónimo con las propiedades Valor y Texto
                CmbProveedor.Items.Add(new { Valor = proveedor.IdProveedor, Texto = proveedor.Nombres });
            }
            CmbProveedor.DisplayMember = "Texto";
            CmbProveedor.ValueMember = "Valor";
            CmbProveedor.SelectedIndex = 0;
            List<Transportista> mostrarTransportista = new CN_Transportista().ListarTransportista();
            CmbTransportista.Items.Add(new { Valor = 0, Texto = "Todos" });
            foreach (Transportista transportista in mostrarTransportista)
            {
                // Crear un objeto anónimo con las propiedades Valor y Texto
                CmbTransportista.Items.Add(new { Valor = transportista.IdTransportista, Texto = transportista.Nombres });
            }
            CmbTransportista.DisplayMember = "Texto";
            CmbTransportista.ValueMember = "Valor";
            CmbTransportista.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in tablaReporteCompras.Columns)
            {
                CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32((CmbProveedor.SelectedItem as dynamic).Valor.ToString());
            int idTransportista = Convert.ToInt32((CmbTransportista.SelectedItem as dynamic).Valor.ToString());
            List<Reporte_Compra> lista = new List<Reporte_Compra>();
            lista = new CN_Reporte().ReporteProductosComprados(TxtFechaInicio.Value.ToString("yyyy-MM-dd"), TxtFechaFin.Value.ToString("yyyy-MM-dd"), idProveedor, idTransportista);

            tablaReporteCompras.Rows.Clear();
            if (lista.Count > 0) {
                foreach (Reporte_Compra row in lista)
                {
                    tablaReporteCompras.Rows.Add(new object[]
                    {
                        row.FechaRegistro, row.TipoDocumento, row.NumeroDocumento, row.MontoTotal, row.UsuarioRegistro, row.DocumentoProveedor, row.NombreProveedor, row.DocumentoTranportista, row.NombreTransportista ,row.CodigoProducto, row.NombreProducto, row.Categoria, row.PrecioCompra, row.PrecioVenta, row.Cantidad, row.SubTotal
                    });
                }
            }
            else
            {
                MessageBox.Show("No hay compras en las fechas especificadas.", "Tabla Reporte Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaReporteCompras.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaReporteCompras.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in tablaReporteCompras.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString(), row.Cells[14].Value.ToString(), row.Cells[15].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Reporte_Compras.xlsx");
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


        private void btnBuscar3_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb3 = CmbBuscar.SelectedItem;
            string valorCmb3 = selectedItemCmb3.Valor;
            string columnaFiltro = valorCmb3.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaReporteCompras.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TxtBuscar.Text.Trim().ToUpper()))
                {
                    row.Visible = true;
                    filasVisibles++;
                }
                else
                {
                    row.Visible = false;
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
            TxtBuscar.Clear();
            foreach (DataGridViewRow row in tablaReporteCompras.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
