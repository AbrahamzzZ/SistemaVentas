using System;
using Negocios;
using Entidad;
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
    public partial class VtnLogin : Form
    {
        public VtnLogin()
        {
            InitializeComponent();
        }

        private void VtnLogin_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            TxtCodigo.Select();
        }

        private void BtnVerContrasenia_Click(object sender, EventArgs e)
        {
            if (TxtClave.PasswordChar != '\0')
            {
                TxtClave.UseSystemPasswordChar = false;
                TxtClave.PasswordChar = '\0';
            }
            else
            {
                TxtClave.UseSystemPasswordChar = true;
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Llamar al método de validación de login de la capa de negocios
            CN_Usuario cnUsuario = new CN_Usuario();
            string mensaje = cnUsuario.ValidarLogin(TxtCodigo.Text, TxtClave.Text);

            if (string.IsNullOrEmpty(mensaje))
            {
                // Si el mensaje está vacío, el login fue exitoso
                List<Usuario> listaUsuarios = new CN_Usuario().Ingresar();
                Usuario usuario = listaUsuarios.FirstOrDefault(u => u.Codigo == TxtCodigo.Text && u.Clave == TxtClave.Text);

                MessageBox.Show("Bienvenido al sistema " + usuario.NombreCompleto + ".", "Inicio de sesión exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vtnMenu menu = new vtnMenu(usuario);
                menu.Show();
                this.Hide();
                menu.FormClosing += Cerrar;
            }
            else
            {
                // Mostrar mensaje de error (ya contiene la validación de intentos)
                MessageBox.Show(mensaje, "Inicio de sesión fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Verificar si se excedió el límite de intentos
                if (mensaje.Contains("Se ha alcanzado el límite de intentos fallidos"))
                {
                    Application.Exit(); // Cierra la aplicación
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            TxtCodigo.Clear();
            TxtClave.Clear();
            this.Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void LblHagaClicAqui_Click(object sender, EventArgs e)
        {
            VtnRecuperarClave recuperacion = new VtnRecuperarClave();
            this.Hide();
            recuperacion.ShowDialog();
            this.Show();
        }
    }
}
