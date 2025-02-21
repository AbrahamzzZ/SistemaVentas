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
    /// <summary>
    /// Clase que representa la ventana de usuario.
    /// </summary>
    public partial class VtnUsuarios : Form
    {
        /// <summary>
        /// Constructor de la clase VtnUsuario.
        /// Inicializa los componentes de la ventana.
        /// </summary>
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
            TxtCodigo.Text = GenerarCodigo(4);
            List<Usuario> mostrarUsuario = new CN_Usuario().ListarUsuario();
            foreach (Usuario rol in mostrarUsuario)
            {
                tablaUsuarios.Rows.Add(new object[] { "", rol.IdUsuario, rol.Codigo, rol.NombreCompleto, rol.CorreoElectronico,rol.oRol.IdRol, rol.oRol.Descripcion, rol.Estado == true ? 1 : 0, rol.Estado == true ? "Activo" : "No Activo" });
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
            string mensaje = string.Empty;
            string saltGenerado = Seguridad.GenerarSalt();

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Rol del Usuario.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Estado del Usuario.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            // Crear el objeto Usuario
            Usuario agregarUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                NombreCompleto = TxtNombreCompleto.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
                ClaveEncriptada = Seguridad.HashClave(TxtClave.Text, saltGenerado),
                Salt = saltGenerado,
                oRol = new Rol { IdRol = selectedItemCmb1.Valor },
                Estado = selectedItemCmb2.Valor == 1
            };

            // Delegar la validación y registro a la lógica de negocio
            int idUsuarioIngresado = new CN_Usuario().Registrar(agregarUsuario, out mensaje);
            if (idUsuarioIngresado != 0)
            {
                // Agregar a la tabla y mostrar mensaje de éxito
                tablaUsuarios.Rows.Add(new object[] { "", idUsuarioIngresado, TxtCodigo.Text, TxtNombreCompleto.Text, TxtCorreoElectronico.Text, selectedItemCmb1.Valor,selectedItemCmb1.Texto, selectedItemCmb2.Valor, selectedItemCmb2.Texto });

                MessageBox.Show("El usuario fue registrado correctamente.", "Registrar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                // Mostrar mensaje de error proveniente de la capa de negocio
                MessageBox.Show($"No se pudo registrar el usuario: {mensaje}", "Error al Registrar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string mensaje;

            // Verificar si los ComboBoxes tienen valores seleccionados
            if (selectedItemCmb1 == null || selectedItemCmb2 == null)
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (selectedItemCmb1 == null) mensajeError += "- Rol del Usuario.\n";
                if (selectedItemCmb2 == null) mensajeError += "- Estado del Usuario.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si hay errores
            }

            Usuario usuarioOriginal = new CN_Usuario().ObtenerPorId(Convert.ToInt32(TxtId.Text));
            string claveEncriptada;
            string salt;

            if (!string.IsNullOrWhiteSpace(TxtClave.Text))
            {
                salt = Seguridad.GenerarSalt(); // Se genera un nuevo salt
                claveEncriptada = Seguridad.HashClave(TxtClave.Text, salt); // Se encripta la nueva clave
            }
            else
            {
                salt = usuarioOriginal.Salt; // Mantener el salt original
                claveEncriptada = usuarioOriginal.ClaveEncriptada; // Mantener la clave encriptada original
            }

            // Crear el objeto Usuario
            Usuario usuarioModificado = new Usuario()
            {
                IdUsuario = Convert.ToInt32(TxtId.Text),
                Codigo = TxtCodigo.Text,
                NombreCompleto = TxtNombreCompleto.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
                ClaveEncriptada = claveEncriptada,
                Salt = salt,

                oRol = new Rol { IdRol = selectedItemCmb1.Valor },
                Estado = selectedItemCmb2.Valor == 1
            };

            // Delegar la validación y edición a la lógica de negocio
            bool modificar = new CN_Usuario().Editar(usuarioModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("La información del usuario fue modificado correctamente.", "Modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la tabla con los datos modificados
                int indice = Convert.ToInt32(TxtIndice.Text);
                tablaUsuarios.Rows[indice].Cells["Codigo"].Value = usuarioModificado.Codigo;
                tablaUsuarios.Rows[indice].Cells["NombresCompleto"].Value = usuarioModificado.NombreCompleto;
                tablaUsuarios.Rows[indice].Cells["CorreoElectronico"].Value = usuarioModificado.CorreoElectronico;
                tablaUsuarios.Rows[indice].Cells["IdRol"].Value = usuarioModificado.oRol.IdRol;
                tablaUsuarios.Rows[indice].Cells["Rol"].Value = selectedItemCmb1.Texto;
                tablaUsuarios.Rows[indice].Cells["EstadoValor"].Value = usuarioModificado.Estado ? 1 : 0;
                tablaUsuarios.Rows[indice].Cells["Estado"].Value = usuarioModificado.Estado ? "Activo" : "No Activo";

                Limpiar();
            }
            else
            {
                MessageBox.Show($"No se pudo modificar la información del usuario: {mensaje}", "Error al Modificar el usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que halla un usuario seleccionado
            if (string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MessageBox.Show("Primero debe seleccionar un Usuario en la tabla para poder eliminarlo.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea eliminar este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                Usuario usuarioEliminado = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(TxtId.Text),
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
                    TxtCodigo.Text = tablaUsuarios.Rows[indice].Cells["Codigo"].Value.ToString();
                    TxtNombreCompleto.Text = tablaUsuarios.Rows[indice].Cells["NombresCompleto"].Value.ToString();
                    TxtCorreoElectronico.Text = tablaUsuarios.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    TxtClave.Enabled = false;

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

        /// <summary>
        /// Metodo que me limpia los campos de texto.
        /// </summary>
        public void Limpiar()
        {
            TxtIndice.Text = "-1";
            TxtId.Text = "0";
            TxtCodigo.Text = GenerarCodigo(4);
            TxtNombreCompleto.Clear();
            TxtCorreoElectronico.Clear();
            TxtClave.Clear();
            TxtClave.Enabled = true;
            CmbRol.SelectedIndex = 0;
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
