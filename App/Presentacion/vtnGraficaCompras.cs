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
    public partial class vtnGraficaCompras : Form
    {
        public vtnGraficaCompras()
        {
            InitializeComponent();
        }

        private void btnCargarDatosVentas_Click(object sender, EventArgs e)
        {
            DataTable dt = new CapaNegocios().gracSQL();
            if (dt.Rows.Count > 0) {
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
                MessageBox.Show("No se encontraron compras registradas para generar la gráfica.", "Grafica de los productos comprados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
