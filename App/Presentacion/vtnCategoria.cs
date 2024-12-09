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
    public partial class VtnCategoria : Form
    {
        public VtnCategoria()
        {
            InitializeComponent();
        }

        private void VtnCategoria_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaCategoria.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            TxtCodigo.Text = GenerarCodigo(4);
            List<Categoria> lista = new CN_Categoria().ListarCategoria();
            foreach (Categoria item in lista)
            {
                tablaCategoria.Rows.Add(new object[] { "", item.IdCategoria, item.Codigo, item.Descripcion, item.Estado == true ? 1 : 0, item.Estado == true ? "Activo" : "No Activo" });
            }
            TxtDescripcion.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb2 = CmbBuscar.SelectedItem;
            string valorCmb2 = selectedItemCmb2.Valor;
            string columnaFiltro = valorCmb2.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaCategoria.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar categoría", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaCategoria.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                string mensajeError = "Por favor, complete el siguiente campo:\n";
                if (string.IsNullOrWhiteSpace(TxtDescripcion.Text)) mensajeError += "- Descripción de la categoría.\n";

                MessageBox.Show(mensajeError, "Falta el campo por completar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Categoria agregarCategoria = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(TxtId.Text),
                    Codigo = TxtCodigo.Text,
                    Descripcion = TxtDescripcion.Text,
                    Estado = valorCmb1 == 1
                };
                if (agregarCategoria.IdCategoria == 0)
                {
                    int idCategoriaIngresado = new CN_Categoria().Registrar(agregarCategoria, out mensaje);
                    if (idCategoriaIngresado != 0)
                    {
                        // Verificar si los elementos seleccionados no son nulos
                        if (selectedItemCmb1 != null)
                        {
                            tablaCategoria.Rows.Add(new object[] { "", idCategoriaIngresado, TxtCodigo.Text,TxtDescripcion.Text, valorCmb1, textoCmb1 });
                            MessageBox.Show("La categoría fue agregada correctamente.", "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un valor en el combobox.", "Tabla Categorias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbEstado.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            string mensaje;

            Categoria categoriaModificado = new Categoria()
            {
                IdCategoria = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                Descripcion = TxtDescripcion.Text,
                Estado = valorCmb1 == 1
            };
            bool modificar = new CN_Categoria().Editar(categoriaModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La categoría fue modificada correctamente.", "Modificar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaCategoria.Rows[indice].Cells["ID"].Value = categoriaModificado.IdCategoria;
                tablaCategoria.Rows[indice].Cells["Codigo"].Value = categoriaModificado.Codigo;
                tablaCategoria.Rows[indice].Cells["Descripcion"].Value = categoriaModificado.Descripcion;
                tablaCategoria.Rows[indice].Cells["EstadoValor"].Value = categoriaModificado.Estado ? 1 : 0;
                tablaCategoria.Rows[indice].Cells["Estado"].Value = categoriaModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar la información de la categoría: " + mensaje, "Modificar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("Primero debe selecionar una categoría en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (Convert.ToInt32(TxtId.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar está categoria?", "Eliminar categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Categoria categoriaEliminada = new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(TxtId.Text),
                        };
                        bool respuesta = new CN_Categoria().Eliminar(categoriaEliminada, out mensaje);
                        if (respuesta)
                        {
                            tablaCategoria.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                            MessageBox.Show("La categoría fue eliminada correctamente.", "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void TablaCategoria_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaCategoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaCategoria.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaCategoria.Rows[e.RowIndex];
                    e.CellStyle.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void TablaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCategoria.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaCategoria.Rows[indice].Cells["ID"].Value.ToString();
                    TxtCodigo.Text = tablaCategoria.Rows[indice].Cells["CODIGO"].Value.ToString();
                    TxtDescripcion.Text = tablaCategoria.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaCategoria.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = CmbEstado.Items.IndexOf(item);
                            CmbEstado.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }

        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            TxtCodigo.Text = GenerarCodigo(4);
            TxtDescripcion.Clear();
            CmbEstado.SelectedIndex = 0;
        }

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
