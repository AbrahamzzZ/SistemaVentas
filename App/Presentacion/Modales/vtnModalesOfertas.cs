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
    public partial class vtnModalesOfertas : Form
    {
        public Oferta oferta { get; set; }
        public vtnModalesOfertas()
        {
            InitializeComponent();
            tablaOfertas.CellFormatting += TablaOfertas_CellFormatting;
        }

        private void VtnModalesOfertas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaOfertas.Columns)
            {
                if (columna.Visible == true)
                {
                    cmb1.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;
            List<Oferta> mostrarOferta = new CN_Oferta().ListarOferta();
            foreach (Oferta ofertas in mostrarOferta)
            {
                tablaOfertas.Rows.Add(new object[] { ofertas.IdOferta, ofertas.NombreOferta, ofertas.oProducto.Nombre, ofertas.Descuento, ofertas.Estado });
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaOfertas.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt1.Text.Trim().ToUpper()))
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
                    IdOferta = Convert.ToInt32(tablaOfertas.Rows[iRow].Cells["IdOferta"].Value.ToString()),
                    NombreOferta = tablaOfertas.Rows[iRow].Cells["Oferta"].Value.ToString(),
                    Descuento = Convert.ToDecimal(tablaOfertas.Rows[iRow].Cells["Descuento"].Value.ToString()),
                    Estado = Convert.ToBoolean(tablaOfertas.Rows[iRow].Cells["Estado"].Value.ToString())
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TablaOfertas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaOfertas.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(tablaOfertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Activo" : "No Activo";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }
        }
    }
}
