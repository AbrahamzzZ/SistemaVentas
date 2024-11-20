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
    public partial class vtnReclamo : Form
    {
        public vtnReclamo()
        {
            InitializeComponent();
        }

        private void vtnReclamo_Load(object sender, EventArgs e)
        {
            cmb1.Items.Add(new { Valor = 1, Texto = "Solucionado" });
            cmb1.Items.Add(new { Valor = 0, Texto = "No Solucionado" });
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaReclamo.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb2.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb2.DisplayMember = "Texto";
            cmb2.ValueMember = "Valor";
            cmb2.SelectedIndex = 0;
            //Mostrar todos los reclamis existentes en la tabla
            List<Reclamo> lista = new CapaNegocios().mosreSQL();
            foreach (Reclamo item in lista)
            {
                tablaReclamo.Rows.Add(new object[] { "", item.IdReclamo, item.oCliente.IdCliente, item.oCliente.Documento, item.oCliente.Nombres, item.oCliente.CorreoElectronico, item.Descripcion, item.Estado == true ? 1 : 0, item.Estado == true ? "Solucionado" : "No Solucionado" });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaReclamo.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt7.Text.Trim().ToUpper()))
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar reclamo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt7.Text = "";
                foreach (DataGridViewRow row in tablaReclamo.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje;

            Reclamo ReclamoModificado = new Reclamo()
            {
                IdReclamo = Convert.ToInt32(txt2.Text),
                Estado = valorCmb1 == 1
            };
            bool modificar = new CapaNegocios().edireSQL(ReclamoModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El reclamo fue modificado correctamente.", "Modificar reclamo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(txt1.Text);
                tablaReclamo.Rows[indice].Cells["EstadoValor"].Value = ReclamoModificado.Estado ? 1 : 0;
                tablaReclamo.Rows[indice].Cells["Estado"].Value = ReclamoModificado.Estado ? "Solucionado" : "No Solucionado";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar el estado del reclamo: " + mensaje, "Modificar reclamo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt2.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar esté reclamo?", "Eliminar reclamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Reclamo reclamoEliminada = new Reclamo()
                    {
                        IdReclamo = Convert.ToInt32(txt2.Text),
                    };

                    bool respuesta = new CapaNegocios().elireSQL(reclamoEliminada, out mensaje);
                    if (respuesta)
                    {
                        tablaReclamo.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
                        MessageBox.Show("El reclamo fue eliminado correctamente.", "Eliminar reclamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Eliminar reclamo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tablaReclamo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var p = Properties.Resources.visto.Width;
                var q = Properties.Resources.visto.Height;
                var r = e.CellBounds.Left + (e.CellBounds.Width - p) / 2;
                var s = e.CellBounds.Top + (e.CellBounds.Height - q) / 2;
                e.Graphics.DrawImage(Properties.Resources.visto, new Rectangle(r, s, p, q));
                e.Handled = true;
            }
        }

        private void tablaReclamo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaReclamo.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Solucionado")
                {
                    DataGridViewRow row = tablaReclamo.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaReclamo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaReclamo.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaReclamo.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaReclamo.Rows[indice].Cells["DocumentoCliente"].Value.ToString();
                    txt4.Text = tablaReclamo.Rows[indice].Cells["NombreCliente"].Value.ToString();
                    txt5.Text = tablaReclamo.Rows[indice].Cells["CorreoElectronicoCliente"].Value.ToString();
                    txt6.Text = tablaReclamo.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaReclamo.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = cmb1.Items.IndexOf(item);
                            cmb1.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }
        public void Limpiar()
        {
            txt1.Text = "-1";
            txt2.Text = "0";
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            txt6.Clear();
            cmb1.SelectedIndex = 0;
        }
    }
}
