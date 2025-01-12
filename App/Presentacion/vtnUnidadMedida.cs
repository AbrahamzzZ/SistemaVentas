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
    public partial class VtnUnidadMedida : Form
    {
        /// <summary>
        /// Constructor de la clase VtnUnidadMedida.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnUnidadMedida()
        {
            InitializeComponent();
        }

        private void VtnUnidadMedida_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaUnidadMedida.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CmBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmBuscar.DisplayMember = "Texto";
            CmBuscar.ValueMember = "Valor";
            CmBuscar.SelectedIndex = 0;
            TxtCodigo.Text = GenerarCodigo(4);
            List<Unidad_Medida> lista = new CN_Unidad_Medida().ListarUnidadesMedida();
            foreach (Unidad_Medida item in lista)
            {
                tablaUnidadMedida.Rows.Add(new object[] { "", item.IdUnidadMedida, item.Codigo ,item.Descripcion, item.Simbolo, item.Estado == true ? 1 : 0, item.Estado == true ? "Activo" : "No Activo" });
            }
            TxtDescripcion.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = CmBuscar.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaUnidadMedida.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtSimbolo.Text = "";
                foreach (DataGridViewRow row in tablaUnidadMedida.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            string mensaje = string.Empty;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Estado de la unidad de medida.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto UnidadMedida
            Unidad_Medida agregarUnidadMedida = new Unidad_Medida()
            {
                IdUnidadMedida = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Descripcion = TxtDescripcion.Text,
                Simbolo = TxtSimbolo.Text,
                Estado = selectedItemCmb1.Valor == 1
            };

            // Delegar la validación y registro a la lógica de negocio
            int idUnidadMedidaIngresada = new CN_Unidad_Medida().Registrar(agregarUnidadMedida, out mensaje);
            if (idUnidadMedidaIngresada != 0)
            {
                // Agregar a la tabla y mostrar mensaje de éxito
                tablaUnidadMedida.Rows.Add(new object[] { "", idUnidadMedidaIngresada, TxtCodigo.Text, TxtDescripcion.Text, TxtSimbolo.Text, selectedItemCmb1.Valor, selectedItemCmb1.Texto });

                MessageBox.Show("La unidad de medida fue registrada correctamente.", "Registrar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo registrar la unidad de medida: {mensaje}", "Tabla Unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            string mensaje;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Estado de la unidad de medida.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto UnidadMedida
            Unidad_Medida categoriaModificado = new Unidad_Medida()
            {
                IdUnidadMedida = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Descripcion = TxtDescripcion.Text,
                Simbolo = TxtSimbolo.Text,
                Estado = selectedItemCmb1.Valor == 1
            };

            // Delegar la validación y edición a la lógica de negocio
            bool modificar = new CN_Unidad_Medida().Editar(categoriaModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La información de la unidad de medida fue modificada correctamente.", "Modificar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaUnidadMedida.Rows[indice].Cells["ID"].Value = categoriaModificado.IdUnidadMedida;
                tablaUnidadMedida.Rows[indice].Cells["Codigo"].Value = categoriaModificado.Codigo;
                tablaUnidadMedida.Rows[indice].Cells["Descripcion"].Value = categoriaModificado.Descripcion;
                tablaUnidadMedida.Rows[indice].Cells["Simbolo"].Value = categoriaModificado.Simbolo;
                tablaUnidadMedida.Rows[indice].Cells["EstadoValor"].Value = categoriaModificado.Estado ? 1 : 0;
                tablaUnidadMedida.Rows[indice].Cells["Estado"].Value = categoriaModificado.Estado ? "Activo" : "No Activo";
                
                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo modificar la información de la unidad de medida: {mensaje}", "Modificar undidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla una categoría seleccionada
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar una Unidad de Medida en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea eliminar está unidad de medida?", "Eliminar unidad de medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                Unidad_Medida unidadMedidaEliminada = new Unidad_Medida()
                {
                    IdUnidadMedida = Convert.ToInt32(TxtId.Text),
                };
                bool respuesta = new CN_Unidad_Medida().Eliminar(unidadMedidaEliminada, out mensaje);
                if (respuesta)
                {
                    tablaUnidadMedida.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                    MessageBox.Show("La unidad de medida fue eliminada correctamente.", "Eliminar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Eliminar unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TablaUnidadMedida_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaUnidadMedida_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void TablaUnidadMedida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaUnidadMedida.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaUnidadMedida.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaUnidadMedida.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtDescripcion.Text = tablaUnidadMedida.Rows[indice].Cells["Descripcion"].Value.ToString();
                    TxtSimbolo.Text = tablaUnidadMedida.Rows[indice].Cells["Simbolo"].Value.ToString();

                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUnidadMedida.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = CmbEstado.Items.IndexOf(item);
                            CmbEstado.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método que limpia los campos del formulario.
        /// </summary>
        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            TxtCodigo.Text = GenerarCodigo(4);
            TxtDescripcion.Clear();
            TxtSimbolo.Clear();
            CmbEstado.SelectedIndex = 0;
        }

        /// <summary>
        /// Método que genera un código aleatorio de una longitud específica.
        /// </summary>
        /// <param name="longitud">La longitud del código a generar.</param>
        /// <returns>Un string con el código generado.</returns>
        private string GenerarCodigo(int longitud)
        {
            const string caracteres = "0123456789";
            Random randon = new Random();
            char[] resultado = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                resultado[i] = caracteres[randon.Next(caracteres.Length)];
            }
            return new string(resultado);
        }
    }
}
