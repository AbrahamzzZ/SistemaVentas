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

namespace Presentacion.Modales
{
    /// <summary>
    /// Clase que representa el modal de las ofertas.
    /// </summary>
    public partial class vtnModalesOfertas : Form
    {
        /// <summary>
        /// Variable donde se va a guardar la oferta seleccionada.
        /// </summary>
        public Oferta oferta { get; set; }

        /// <summary>
        /// Constructor de la clase vtnModalesOfertas. 
        /// Inicializa una nueva instancia de vtnModalesOfertas y configura los eventos necesarios.
        /// </summary>
        public vtnModalesOfertas()
        {
            InitializeComponent();
            TablaOfertas.CellFormatting += TablaOfertas_CellFormatting;
        }

        private void VtnModalesOfertas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in TablaOfertas.Columns)
            {
                if (columna.Visible == true)
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            List<Oferta> mostrarOferta = new CN_Oferta().ListarOferta();
            foreach (Oferta ofertas in mostrarOferta)
            {
                TablaOfertas.Rows.Add(new object[] { ofertas.IdOferta, ofertas.NombreOferta, ofertas.oProducto.Nombre, ofertas.Descuento, ofertas.Estado });
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbBuscar.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in TablaOfertas.Rows)
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
        }

        private void TablaOfertas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                oferta = new Oferta()
                {
                    IdOferta = Convert.ToInt32(TablaOfertas.Rows[iRow].Cells["IdOferta"].Value.ToString()),
                    NombreOferta = TablaOfertas.Rows[iRow].Cells["Oferta"].Value.ToString(),
                    Descuento = Convert.ToDecimal(TablaOfertas.Rows[iRow].Cells["Descuento"].Value.ToString()),
                    Estado = Convert.ToBoolean(TablaOfertas.Rows[iRow].Cells["Estado"].Value.ToString())
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TablaOfertas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (TablaOfertas.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(TablaOfertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Activo" : "No Activo";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }

            if (this.TablaOfertas.Columns[e.ColumnIndex].Name == "Descuento" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal descuento))
                {
                    e.Value = descuento.ToString("0.##") + " %";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
