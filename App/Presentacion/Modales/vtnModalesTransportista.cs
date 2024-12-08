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
    public partial class vtnModalesTransportista : Form
    {
        public Transportista Transportista { get; set; }
        public vtnModalesTransportista()
        {
            InitializeComponent();
        }
        private void vtnModalesTransportista_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaTransportista.Columns)
            {
                if (columna.Visible == true)
                {
                    cmb1.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;
            List<Transportista> mostrarTransportista = new CN_Transportista().ListarTransportista();
            foreach (Transportista transportistas in mostrarTransportista)
            {
                tablaTransportista.Rows.Add(new object[] { transportistas.IdTransportista, transportistas.Codigo, transportistas.Nombres, transportistas.Estado });
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();

            int filasVisibles = 0;
            foreach (DataGridViewRow row in tablaTransportista.Rows)
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

        private void tablaTransportista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                Transportista = new Transportista()
                {
                    IdTransportista = Convert.ToInt32(tablaTransportista.Rows[iRow].Cells["IdTransportista"].Value.ToString()),
                    Codigo = tablaTransportista.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombres = tablaTransportista.Rows[iRow].Cells["Nombres"].Value.ToString(),
                    Estado = Convert.ToBoolean(tablaTransportista.Rows[iRow].Cells["Estado"].Value.ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tablaTransportista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaTransportista.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(tablaTransportista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Activo" : "No Activo";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }
        }
    }
}
