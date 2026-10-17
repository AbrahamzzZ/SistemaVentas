using Negocios;
using System;
using System.Data.Common;
using System.Net.Mail;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// 
    /// </summary>
    public partial class VtnRestablecerClave : FormularioBase
    {
        private readonly CN_Usuario _usuarioNegocio = new CN_Usuario();
        private string _correoVerificado;
        private string _tokenVerificado;
        private bool _tokenValido;

        /// <summary>
        /// 
        /// </summary>
        public VtnRestablecerClave()
        {
            InitializeComponent();
        }

        private async void BtnEnviarCorreoElectronico_Click(object sender, EventArgs e)
        {
            string correoElectronico = TxtCorreoElectronico.Text.Trim();
            if (!Validaciones.EsCorreoValido(correoElectronico))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _tokenValido = false;
            _correoVerificado = null;
            _tokenVerificado = null;
            TxtToken.Clear();
            TxtClave.Enabled = false;
            TxtConfirmarClave.Enabled = false;
            BtnCambiarClave.Enabled = false;
            BtnEnviarToken.Enabled = false;
            TxtToken.Enabled = false;
            BtnEnviarCorreoElectronico.Enabled = false;
            string token = string.Empty;

            try
            {
                if (_usuarioNegocio.GenerarTokenRecuperacion(correoElectronico, out token))
                {
                    try
                    {
                        await ServicioCorreoRecuperacion.EnviarAsync(correoElectronico, token);
                    }
                    catch (SmtpException)
                    {
                        _usuarioNegocio.InvalidarTokenRecuperacion(correoElectronico, token);
                        throw;
                    }
                    catch (InvalidOperationException)
                    {
                        _usuarioNegocio.InvalidarTokenRecuperacion(correoElectronico, token);
                        throw;
                    }

                    TxtToken.Enabled = true;
                    TxtCorreoElectronico.Enabled = false;
                    BtnEnviarToken.Enabled = true;
                    MessageBox.Show(
                        "Si el correo pertenece a un usuario activo, recibirás un código válido durante 15 minutos.",
                        "Solicitud procesada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Si el correo pertenece a un usuario activo, recibirás un código válido durante 15 minutos.",
                        "Solicitud procesada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show($"No se pudo enviar el correo de recuperación: {ex.Message}", "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Configuración de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DbException)
            {
                MessageBox.Show("No se pudo guardar la solicitud en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!_tokenValido)
                {
                    BtnEnviarCorreoElectronico.Enabled = true;
                }
            }
        }

        private void BtnEnviarToken_Click(object sender, EventArgs e)
        {
            string correoElectronico = TxtCorreoElectronico.Text.Trim();
            bool tokenValido;
            try
            {
                tokenValido = _usuarioNegocio.ValidarTokenRecuperacion(correoElectronico, TxtToken.Text);
            }
            catch (DbException)
            {
                MessageBox.Show("No se pudo verificar el código en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!tokenValido)
            {
                _tokenValido = false;
                TxtClave.Enabled = false;
                TxtConfirmarClave.Enabled = false;
                BtnCambiarClave.Enabled = false;
                MessageBox.Show("El código no es válido, venció o alcanzó el límite de intentos.", "Código no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _correoVerificado = correoElectronico;
            _tokenVerificado = TxtToken.Text.Trim();
            _tokenValido = true;
            TxtCorreoElectronico.Enabled = false;
            TxtToken.Enabled = false;
            BtnEnviarCorreoElectronico.Enabled = false;
            BtnEnviarToken.Enabled = false;
            TxtClave.Enabled = true;
            TxtConfirmarClave.Enabled = true;
            BtnCambiarClave.Enabled = true;
            TxtClave.Focus();
            MessageBox.Show("Código verificado. Ingrese y confirme su nueva contraseña.", "Código verificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCambiarClave_Click(object sender, EventArgs e)
        {
            if (!_tokenValido)
            {
                MessageBox.Show("Primero debe verificar el código enviado a su correo.", "Verificación requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Validaciones.EsClaveValida(TxtClave.Text))
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres, una letra, un número y un carácter especial.", "Contraseña no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(TxtClave.Text, TxtConfirmarClave.Text, StringComparison.Ordinal))
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!_usuarioNegocio.CambiarClaveRecuperacion(_correoVerificado, _tokenVerificado, TxtClave.Text))
                {
                    _tokenValido = false;
                    MessageBox.Show("El código venció o ya fue utilizado. Solicite uno nuevo.", "Código no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La contraseña se cambió correctamente. Ya puede iniciar sesión.", "Contraseña actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (DbException)
            {
                MessageBox.Show("No se pudo actualizar la contraseña en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
