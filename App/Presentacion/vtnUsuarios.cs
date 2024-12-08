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
    public partial class VtnUsuarios : Form
    {
        public VtnUsuarios()
        {
            InitializeComponent();
        }

        private void VtnUsuarios_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            CmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            CmbEstado.DisplayMember = "Texto";
            CmbEstado.ValueMember = "Valor";
            CmbEstado.SelectedIndex = 0;
            List<Rol> listaRol = new CN_Rol().Rol();
            foreach (Rol rol in listaRol)
            {
                CmbRol.Items.Add(new { Valor = rol.IdRol, Texto = rol.Descripcion });
            }
            CmbRol.DisplayMember = "Texto";
            CmbRol.ValueMember = "Valor";
            CmbRol.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in tablaUsuarios.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            CmbBuscar.DisplayMember = "Texto";
            CmbBuscar.ValueMember = "Valor";
            CmbBuscar.SelectedIndex = 0;
            TxtNoDocumento.Text = GenerarCodigo(4);
            List<Usuario> mostrarUsuario = new CN_Usuario().ListarUsuario();
            foreach (Usuario rol in mostrarUsuario)
            {
                tablaUsuarios.Rows.Add(new object[] { "", rol.IdUsuario, rol.Codigo, rol.NombreCompleto, rol.CorreoElectronico, rol.Clave, rol.oRol.IdRol, rol.oRol.Descripcion, rol.Estado == true ? 1 : 0, rol.Estado == true ? "Activo" : "No Activo" });
            }
            TxtNombreCompleto.Select();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb3 = CmbBuscar.SelectedItem;
            string valorCmb3 = selectedItemCmb3.Valor;
            string columnaFiltro = valorCmb3.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow row in tablaUsuarios.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtBuscar.Text = "";
                foreach (DataGridViewRow row in tablaUsuarios.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmb1 = CmbRol.SelectedItem;
            dynamic selectedItemCmb2 = CmbEstado.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(TxtNoDocumento.Text) || string.IsNullOrWhiteSpace(TxtNombreCompleto.Text) || string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text) || string.IsNullOrWhiteSpace(TxtClave.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(TxtNoDocumento.Text)) mensajeError += "- Número del documento del Usuario.\n";
                if (string.IsNullOrWhiteSpace(TxtNombreCompleto.Text)) mensajeError += "- Nombre completo del Usuario.\n";
                if (string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text)) mensajeError += "- Correo electrónico del Usuario.\n";
                if (string.IsNullOrWhiteSpace(TxtClave.Text)) mensajeError += "- Clave del Usuario.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Usuario agregarUsuario = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(TxtId.Text),
                    Codigo = TxtNoDocumento.Text,
                    NombreCompleto = TxtNombreCompleto.Text,
                    CorreoElectronico = TxtCorreoElectronico.Text,
                    Clave = TxtClave.Text,
                    oRol = new Rol { IdRol = valorCmb1 },
                    Estado = valorCmb2 == 1
                };
                int idUsuarioIngresado = new CN_Usuario().Registrar(agregarUsuario, out mensaje);
                if (idUsuarioIngresado != 0)
                {

                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmb1 != null && selectedItemCmb2 != null)
                    {
                        tablaUsuarios.Rows.Add(new object[] { "", idUsuarioIngresado, TxtNoDocumento.Text, TxtNombreCompleto.Text, TxtCorreoElectronico.Text, TxtClave.Text, valorCmb1, textoCmb1, valorCmb2, textoCmb2 });
                        MessageBox.Show("El Usuario fue agregado correctamente.", "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Usuario");
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
            dynamic selectedItemCmb1 = CmbRol.SelectedItem;
            dynamic selectedItemCmb2 = CmbEstado.SelectedItem;
            int valorCmb1 = selectedItemCmb1.Valor;
            string textoCmb1 = selectedItemCmb1.Texto;
            int valorCmb2 = selectedItemCmb2.Valor;
            string textoCmb2 = selectedItemCmb2.Texto;
            string mensaje;

            Usuario usuarioModificado = new Usuario()
            {
                IdUsuario = Convert.ToInt32(TxtId.Text),
                Codigo = TxtNoDocumento.Text,
                NombreCompleto = TxtNombreCompleto.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
                Clave = TxtClave.Text,
                oRol = new Rol { IdRol = valorCmb1 },
                Estado = valorCmb2 == 1
            };
            bool modificar = new CN_Usuario().Editar(usuarioModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El Usuario fue modificado correctamente.", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaUsuarios.Rows[indice].Cells["Codigo"].Value = usuarioModificado.Codigo;
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
                MessageBox.Show("Error al modificar la información del Usuario: " + mensaje, "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNoDocumento.Text) || string.IsNullOrWhiteSpace(TxtNombreCompleto.Text) || string.IsNullOrWhiteSpace(TxtCorreoElectronico.Text) || string.IsNullOrWhiteSpace(TxtClave.Text))
            {
                MessageBox.Show("Primero debe selecionar un Usuario en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int idUsuario = Convert.ToInt32(TxtId.Text);
                if (idUsuario == 1)
                {
                    MessageBox.Show("No se puede eliminar el primer Usuario porque es necesario para el acceso al sistema.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Usuario usuarioEliminado = new Usuario()
                        {
                            IdUsuario = idUsuario,
                        };
                        bool respuesta = new CN_Usuario().Eliminar(usuarioEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaUsuarios.Rows.RemoveAt(Convert.ToInt32(TxtIndice.Text));
                            MessageBox.Show("El Usuario fue eliminado correctamente.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void TablaUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void TablaUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void TablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaUsuarios.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    TxtIndice.Text = indice.ToString();
                    TxtId.Text = tablaUsuarios.Rows[indice].Cells["ID"].Value.ToString();
                    TxtNoDocumento.Text = tablaUsuarios.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombreCompleto.Text = tablaUsuarios.Rows[indice].Cells["NombresCompleto"].Value.ToString();
                    TxtCorreoElectronico.Text = tablaUsuarios.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    TxtClave.Text = tablaUsuarios.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (dynamic item in CmbRol.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUsuarios.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_cmb = CmbRol.Items.IndexOf(item);
                            CmbRol.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in CmbEstado.Items)
                    {
                        // Accede a las propiedades Valor y Texto directamente
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUsuarios.Rows[indice].Cells["EstadoValor"].Value))
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
            TxtNoDocumento.Text = GenerarCodigo(4);
            TxtNombreCompleto.Clear();
            TxtCorreoElectronico.Clear();
            TxtClave.Clear();
            CmbRol.SelectedIndex = 0;
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

        private void TxtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombre Completo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
