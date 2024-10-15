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
    public partial class vtnUsuarios : Form
    {
        public vtnUsuarios()
        {
            InitializeComponent();
        }

        private void vtnUsuarios_Load(object sender, EventArgs e)
        {
            cmb2.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmb2.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmb2.DisplayMember = "Texto";
            cmb2.ValueMember = "Valor";
            cmb2.SelectedIndex = 0;
            List<Rol> listaRol = new CapaNegocios().mosSQL();
            foreach (Rol rol in listaRol)
            {
                cmb1.Items.Add(new { Valor = rol.IdRol, Texto = rol.Descripcion });
            }
            cmb1.DisplayMember = "Texto";
            cmb1.ValueMember = "Valor";
            cmb1.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in tablaUsuarios.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmb3.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            cmb3.DisplayMember = "Texto";
            cmb3.ValueMember = "Valor";
            cmb3.SelectedIndex = 0;
            //Mostrar todos los usuarios existentes en la tabla
            List<Usuario> mostrarUsuario = new CapaNegocios().mosuSQL();
            foreach (Usuario rol in mostrarUsuario)
            {
                tablaUsuarios.Rows.Add(new object[] { "", rol.IdUsuario, rol.Documento, rol.NombreCompleto, rol.CorreoElectronico, rol.Clave, rol.oRol.IdRol, rol.oRol.Descripcion, rol.Estado == true ? 1 : 0, rol.Estado == true ? "Activo" : "No Activo" });
            }
            txt3.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb3 = cmb3.SelectedItem;
            string valorCmb3 = selectedItemCmb3.Valor;
            string columnaFiltro = valorCmb3.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaUsuarios.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt7.Text = "";
                foreach (DataGridViewRow row in tablaUsuarios.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = cmb1.SelectedItem;
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text) || string.IsNullOrWhiteSpace(txt6.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(txt3.Text)) mensajeError += "- Número del documento del usuario.\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Nombre completo del usuario.\n";
                if (string.IsNullOrWhiteSpace(txt5.Text)) mensajeError += "- Correo electrónico del usuario.\n";
                if (string.IsNullOrWhiteSpace(txt6.Text)) mensajeError += "- Clave del usuario.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Usuario agregarUsuario = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(txt2.Text),
                    Documento = txt3.Text,
                    NombreCompleto = txt4.Text,
                    CorreoElectronico = txt5.Text,
                    Clave = txt6.Text,
                    oRol = new Rol { IdRol = valorCmb1 },
                    Estado = valorCmb2 == 1
                };
                int idUsuarioIngresado = new CapaNegocios().resuSQL(agregarUsuario, out mensaje);
                if (idUsuarioIngresado != 0)
                {

                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null && selectedItemCmb2 != null)
                    {
                        tablaUsuarios.Rows.Add(new object[] { "", idUsuarioIngresado, txt3.Text, txt4.Text, txt5.Text, txt6.Text, valorCmb1, textoCmb1, valorCmb2, textoCmb2 });
                        MessageBox.Show("El usuario fue agregado correctamente.", "Agregar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Usuario");
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
            dynamic selectedItemCmb2 = cmb2.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            string mensaje;

            Usuario usuarioModificado = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txt2.Text),
                Documento = txt3.Text,
                NombreCompleto = txt4.Text,
                CorreoElectronico = txt5.Text,
                Clave = txt6.Text,
                oRol = new Rol { IdRol = valorCmb1 },
                Estado = valorCmb2 == 1
            };
            bool modificar = new CapaNegocios().ediuSQL(usuarioModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El usuario fue modificado correctamente.", "Modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(txt1.Text);
                tablaUsuarios.Rows[indice].Cells["Documento"].Value = usuarioModificado.Documento;
                tablaUsuarios.Rows[indice].Cells["NombresCompleto"].Value = usuarioModificado.NombreCompleto;
                tablaUsuarios.Rows[indice].Cells["CorreoElectronico"].Value = usuarioModificado.CorreoElectronico;
                tablaUsuarios.Rows[indice].Cells["Clave"].Value = usuarioModificado.Clave;
                tablaUsuarios.Rows[indice].Cells["IdRol"].Value = usuarioModificado.oRol.IdRol;
                tablaUsuarios.Rows[indice].Cells["Rol"].Value = textoCmb1;
                tablaUsuarios.Rows[indice].Cells["EstadoValor"].Value = usuarioModificado.Estado ? 1 : 0;
                tablaUsuarios.Rows[indice].Cells["Estado"].Value = usuarioModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar la información del usuario: " + mensaje, "Modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text) || string.IsNullOrWhiteSpace(txt6.Text))
            {
                MessageBox.Show("Primero debe selecionar un usuario en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int idUsuario = Convert.ToInt32(txt2.Text);
                if (idUsuario == 1)
                {
                    MessageBox.Show("No se puede eliminar el primer usuario porque es necesario para el acceso al sistema.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar este usuario?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Usuario usuarioEliminado = new Usuario()
                        {
                            IdUsuario = idUsuario,
                        };
                        bool respuesta = new CapaNegocios().eliuSQL(usuarioEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaUsuarios.Rows.RemoveAt(Convert.ToInt32(txt1.Text));
                            MessageBox.Show("El usuario fue eliminado correctamente.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void tablaUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaUsuarios.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaUsuarios.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaUsuarios.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txt1.Text = indice.ToString();
                    txt2.Text = tablaUsuarios.Rows[indice].Cells["ID"].Value.ToString();
                    txt3.Text = tablaUsuarios.Rows[indice].Cells["Documento"].Value.ToString();
                    txt4.Text = tablaUsuarios.Rows[indice].Cells["NombresCompleto"].Value.ToString();
                    txt5.Text = tablaUsuarios.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    txt6.Text = tablaUsuarios.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (dynamic item in cmb1.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUsuarios.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_cmb = cmb1.Items.IndexOf(item);
                            cmb1.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in cmb2.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUsuarios.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = cmb2.Items.IndexOf(item);
                            cmb2.SelectedIndex = indice_cmb;
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
            cmb2.SelectedIndex = 0;
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Número Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombre Completo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
