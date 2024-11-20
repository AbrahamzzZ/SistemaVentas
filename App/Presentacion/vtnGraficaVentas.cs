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

namespace Presentacion
{
    public partial class vtnGraficaVentas : Form
    {
        public vtnGraficaVentas()
        {
            InitializeComponent();
        }

        private void btnCargarDatosVentas_Click(object sender, EventArgs e)
        {
            DataTable dt = new CapaNegocios().gravSQL();
            if (dt.Rows.Count > 0)
            {
                graficaVenta.Titles.Add("Productos Vendidos");
                foreach (DataRow row in dt.Rows)
                {
                    Series serie = graficaVenta.Series.Add(row["Nombre_Producto"].ToString());
                    serie.Points.Add(Convert.ToInt32(row["Cantidad_Vendida"].ToString()));
                    serie.Label = row["Cantidad_Vendida"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontraron ventas registradas para generar la gráfica.", "Grafica de los productos vendidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
