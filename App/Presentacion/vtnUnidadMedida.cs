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
    public partial class vtnUnidadMedida : Form
    {
        public vtnUnidadMedida()
        {
            InitializeComponent();
        }

        private void vtnUnidadMedida_Load(object sender, EventArgs e)
        {
            cmb1.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmb1.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaUnidadMedida.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb2.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb2.DisplayMember = "Texto";
            cmb2.ValueMember = "Valor";
            cmb2.SelectedIndex = 0;
            //Mostrar todos las unidades de medidas existentes en la tabla
            List<Unidad_Medida> lista = new CapaNegocios().ListarUnidadesMedida();
            foreach (Unidad_Medida item in lista)
            {
                tablaUnidadMedida.Rows.Add(new object[] { "", item.IdUnidadMedida, item.Descripcion, item.Simbolo, item.Estado == true ? 1 : 0, item.Estado == true ? "Activo" : "No Activo" });
            }
            txt3.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaUnidadMedida.Rows)
            {
                if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt5.Text.Trim().ToUpper()))
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt4.Text = "";
                foreach (DataGridViewRow row in tablaUnidadMedida.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text))
            {
                string mensajeError = "Por favor, complete el siguiente campo:\n";
                if (string.IsNullOrWhiteSpace(txt3.Text)) mensajeError += "- Descripción de la unidad de medida.\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Simbología de la unidad de medida.\n";

                MessageBox.Show(mensajeError, "Falta el campo por completar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Unidad_Medida agregarUnidadMedida = new Unidad_Medida()
                {
                    IdUnidadMedida = Convert.ToInt32(txt2.Text),
                    Descripcion = txt3.Text,
                    Simbolo = txt4.Text,
                    Estado = valorCmb1 == 1
                };
                if (agregarUnidadMedida.IdUnidadMedida == 0)
                {
                    int idUnidadMedidaIngresada = new CapaNegocios().resumSQL(agregarUnidadMedida, out mensaje);
                    if (idUnidadMedidaIngresada != 0)
                    {
                        // Verificar si los elementos seleccionados no son nulos
                        if (selectedItemCmb1 != null)
                        {
                            tablaUnidadMedida.Rows.Add(new object[] { "", idUnidadMedidaIngresada, txt3.Text, txt4.Text, valorCmb1, textoCmb1 });
                            MessageBox.Show("La unidad de medida fue agregada correctamente.", "Agregar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un valor en el combobox.", "Tabla Unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
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

            Unidad_Medida categoriaModificado = new Unidad_Medida()
            {
                IdUnidadMedida = Convert.ToInt32(txt2.Text),
                Descripcion = txt3.Text,
                Simbolo = txt4.Text,
                Estado = valorCmb1 == 1
            };
            bool modificar = new CapaNegocios().ediumSQL(categoriaModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La unidad de medida fue modificada correctamente.", "Modificar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txt1.Text);
                tablaUnidadMedida.Rows[indice].Cells["ID"].Value = categoriaModificado.IdUnidadMedida;
                tablaUnidadMedida.Rows[indice].Cells["Descripcion"].Value = categoriaModificado.Descripcion;
                tablaUnidadMedida.Rows[indice].Cells["Simbolo"].Value = categoriaModificado.Simbolo;
                tablaUnidadMedida.Rows[indice].Cells["EstadoValor"].Value = categoriaModificado.Estado ? 1 : 0;
                tablaUnidadMedida.Rows[indice].Cells["Estado"].Value = categoriaModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar la información de la unidad de medida: " + mensaje, "Modificar undidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text))
            {
                MessageBox.Show("Primero debe selecionar una unidad de medida en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txt2.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar está categoria?", "Eliminar categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Unidad_Medida unidadMedidaEliminada = new Unidad_Medida()
                        {
                            IdUnidadMedida = Convert.ToInt32(txt2.Text),
                        };
                        bool respuesta = new CapaNegocios().eliumSQL(unidadMedidaEliminada, out mensaje);
                        if (respuesta)
                        {
                            tablaUnidadMedida.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
                            MessageBox.Show("La unidad de medida fue eliminada correctamente.", "Eliminar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void tablaUnidadMedida_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaUnidadMedida_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaUnidadMedida.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaUnidadMedida.Rows[e.RowIndex];
                    e.CellStyle.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void tablaUnidadMedida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaUnidadMedida.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaUnidadMedida.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaUnidadMedida.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txt4.Text = tablaUnidadMedida.Rows[indice].Cells["Simbolo"].Value.ToString();

                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUnidadMedida.Rows[indice].Cells["EstadoValor"].Value))
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
            cmb1.SelectedIndex = 0;
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
