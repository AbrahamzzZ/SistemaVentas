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
    /// <summary>
    /// Clase que representa la ventana del login.
    /// </summary>
    public partial class VtnLogin : Form
    {
        /// <summary>
        /// Constructor de la clase VtnLogin.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnLogin()
        {
            InitializeComponent();
        }

        private void VtnLogin_Load(object sender, EventArgs e)
        {
            TxtTiempo.Enabled = true;
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
                List<Usuario> usuarioLogin = new CN_Usuario().Ingresar();
                Usuario_Catched usuario = Usuario_Catched.GetInstance();
                Usuario usuarioEncontrado = usuarioLogin.FirstOrDefault(u => u.Codigo == TxtCodigo.Text && u.Clave == TxtClave.Text);
                usuario.IdUsuario = usuarioEncontrado.IdUsuario;
                usuario.Codigo = usuarioEncontrado.Codigo;
                usuario.NombreCompleto = usuarioEncontrado.NombreCompleto;
                usuario.Clave = usuarioEncontrado.Clave;
                usuario.Estado = usuarioEncontrado.Estado;

                MessageBox.Show("Bienvenido al sistema " + usuario.NombreCompleto + ".", "Inicio de sesión exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VtnMenu menu = new VtnMenu(usuario);
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

        private void LblHagaClicAqui_Click(object sender, EventArgs e)
        {
            VtnRecuperarClave recuperacion = new VtnRecuperarClave();
            this.Hide();
            recuperacion.ShowDialog();
            this.Show();
        }

        private void TxtTiempo_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
