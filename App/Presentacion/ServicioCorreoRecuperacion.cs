using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Presentacion
{
    internal static class ServicioCorreoRecuperacion
    {
        public static async Task EnviarAsync(string destinatario, string token)
        {
            string servidor = ObtenerVariableRequerida("SISTEMA_VENTAS_SMTP_HOST");
            string remitente = ObtenerVariableRequerida("SISTEMA_VENTAS_SMTP_FROM");
            string usuario = Environment.GetEnvironmentVariable("SISTEMA_VENTAS_SMTP_USER");
            string clave = Environment.GetEnvironmentVariable("SISTEMA_VENTAS_SMTP_PASSWORD");
            string puertoConfig = Environment.GetEnvironmentVariable("SISTEMA_VENTAS_SMTP_PORT");
            string sslConfig = Environment.GetEnvironmentVariable("SISTEMA_VENTAS_SMTP_ENABLE_SSL");

            if (!int.TryParse(string.IsNullOrWhiteSpace(puertoConfig) ? "587" : puertoConfig, out int puerto) ||
                puerto < 1 || puerto > 65535)
            {
                throw new InvalidOperationException("SISTEMA_VENTAS_SMTP_PORT debe ser un puerto válido.");
            }

            if (string.IsNullOrWhiteSpace(usuario) != string.IsNullOrWhiteSpace(clave))
            {
                throw new InvalidOperationException("Configure juntas las variables SMTP_USER y SMTP_PASSWORD, o deje ambas vacías.");
            }

            if (!bool.TryParse(string.IsNullOrWhiteSpace(sslConfig) ? "true" : sslConfig, out bool usarSsl))
            {
                throw new InvalidOperationException("SISTEMA_VENTAS_SMTP_ENABLE_SSL debe ser true o false.");
            }

            using (MailMessage mensaje = new MailMessage())
            using (SmtpClient cliente = new SmtpClient(servidor, puerto))
            {
                try
                {
                    mensaje.From = new MailAddress(remitente);
                    mensaje.To.Add(new MailAddress(destinatario));
                }
                catch (FormatException ex)
                {
                    throw new InvalidOperationException("La dirección de correo SMTP configurada no es válida.", ex);
                }

                mensaje.Subject = "Código para restablecer tu contraseña";
                mensaje.Body = $"Tu código de recuperación es: {token}\r\nVence en 15 minutos. Si no solicitaste este cambio, ignora este mensaje.";
                cliente.EnableSsl = usarSsl;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (!string.IsNullOrWhiteSpace(usuario))
                {
                    cliente.Credentials = new NetworkCredential(usuario, clave);
                }

                await cliente.SendMailAsync(mensaje);
            }
        }

        private static string ObtenerVariableRequerida(string nombre)
        {
            string valor = Environment.GetEnvironmentVariable(nombre);
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new InvalidOperationException($"Debe configurar la variable de entorno {nombre} para enviar correos de recuperación.");
            }

            return valor.Trim();
        }
    }
}
