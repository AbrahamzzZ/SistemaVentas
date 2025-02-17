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
    /// Clase que representa la ventana modal sucursal.
    /// </summary>
    public partial class VtnModalesSucursal: Form
    {
        /// <summary>
        /// Variable donde se va a guardar la sucursal seleccionada.
        /// </summary>
        public Sucursal Sucursal { get; set; }

        /// <summary> 
        /// Constructor de la clase vtnModalesSucursales. 
        /// Inicializa una nueva instancia de vtnModalesSucursales.
        /// </summary>
        public VtnModalesSucursal()
        {
            InitializeComponent();
        }

        private void VtnModalesSucursal_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in TablaSucursales.Columns)
            {
                if (columna.Visible == true)
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            List<Sucursal> mostrarSucursal = new CN_Sucursal().ListarSucusal();
            foreach (Sucursal sucursal in mostrarSucursal)
            {
                TablaSucursales.Rows.Add(new object[] { sucursal.IdSucursal, sucursal.Nombre, sucursal.Estado });
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbBuscar.SelectedItem;
            string valorCmb1 = selectedItemCmb1.Valor;
            string columnaFiltro = valorCmb1.ToString();

            int filasVisibles = 0;
            foreach (DataGridViewRow row in TablaSucursales.Rows)
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

        private void TablaSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;
            if (iRow >= 0 && iColumn > 0)
            {
                Sucursal = new Sucursal()
                {
                    IdSucursal = Convert.ToInt32(TablaSucursales.Rows[iRow].Cells["IdSucursal"].Value.ToString()),
                    Nombre = TablaSucursales.Rows[iRow].Cells["NombreSucursal"].Value.ToString(),
                    Estado = Convert.ToBoolean(TablaSucursales.Rows[iRow].Cells["Estado"].Value.ToString())
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TablaSucursales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (TablaSucursales.Columns[e.ColumnIndex].Name == "Estado")
            {
                bool valorEstado = Convert.ToBoolean(TablaSucursales.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                e.Value = valorEstado ? "Abierto" : "Cerrado";

                e.CellStyle.BackColor = valorEstado ? Color.Green : Color.Red;
            }
        }
    }
}
