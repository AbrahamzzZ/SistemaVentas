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
    public partial class vtnLogin : Form
    {
        private int intentos = 0;
        public vtnLogin()
        {
            InitializeComponent();
        }

        private void vtnLogin_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            txt1.Select();
        }

        private void btnVerContrasenia_Click(object sender, EventArgs e)
        {
            if (txt2.PasswordChar != '\0')
            {
                txt2.UseSystemPasswordChar = false;
                txt2.PasswordChar = '\0';
            }
            else
            {
                txt2.UseSystemPasswordChar = true;
            }
        }

        private void lblHagaClicAqui_Click(object sender, EventArgs e)
        {
            vtnRecuperarClave recuperacion = new vtnRecuperarClave();
            this.Hide();
            recuperacion.ShowDialog();
            this.Show();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt1.Text) || string.IsNullOrWhiteSpace(txt2.Text))
            {
                MessageBox.Show("Por favor llene todos los campos para iniciar sesión.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<Usuario> listaUsuarios = new CapaNegocios().ListarUsuarios();
                Usuario usuario = listaUsuarios.FirstOrDefault(u => u.Documento == txt1.Text && u.Clave == txt2.Text);
                if (usuario != null)
                {
                    if (usuario.Estado)
                    {
                        MessageBox.Show("Bienvenido al sistema " + usuario.NombreCompleto + ".", "Inicio de sesión exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vtnMenu menu = new vtnMenu(usuario);
                        menu.Show();
                        this.Hide();
                        menu.FormClosing += cerrar;
                    }
                    else
                    {
                        MessageBox.Show("El usuario no está habilitado. Por favor, contacte al administrador.", "Usuario no habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    intentos++;
                    if (intentos >= 4)
                    {
                        MessageBox.Show("Se ha alcanzado el límite de intentos de inicio de sesión. Por favor, intente de nuevo más tarde.", "Maximo intentos fallidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Las credenciales ingresadas son incorrectas.", "Inicio de sesión fallido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void cerrar(object sender, FormClosingEventArgs e)
        {
            txt1.Clear();
            txt2.Clear();
            this.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Número Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
