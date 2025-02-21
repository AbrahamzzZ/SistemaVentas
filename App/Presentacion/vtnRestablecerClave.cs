using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// 
    /// </summary>
    public partial class VtnRestablecerClave: Form
    {
        /// <summary>
        /// 
        /// </summary>
        public VtnRestablecerClave()
        {
            InitializeComponent();
        }

        private void BtnEnviarCorreoElectronico_Click(object sender, EventArgs e)
        {
            string token = Seguridad.GenerarToken();

            string correoElectronico = TxtCorreoElectronico.Text;
            if (string.IsNullOrWhiteSpace(correoElectronico))
            {
                MessageBox.Show("Ingrese un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CN_Usuario usuarioNegocio = new CN_Usuario();
            if (usuarioNegocio.Token(correoElectronico, ref token))
            {
                // Enviar el token por correo electrónico
                if (EnviarCorreo(correoElectronico, token))
                {
                    MessageBox.Show("Se ha enviado el token a su correo electrónico.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo enviar el correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontró un usuario con ese correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEnviarToken_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCambiarClave_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool EnviarCorreo(string destinatario, string token)
        {
            /*try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(TxtCorreoElectronico.Text); 
                correo.To.Add(destinatario);
                correo.Subject = "Recuperación de Contraseña - Supermercado Paradisia";
                correo.Body = $"Su código de recuperación es: <b>{token}</b>. Este código es válido por 15 minutos.";
                correo.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(TxtCorreoElectronico.Text, "tu_contraseña"); 
                smtp.EnableSsl = true;

                smtp.Send(correo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
                return false;
            }*/
            return false;
        }
            
    }
}
