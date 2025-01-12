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
    /// Clase que representa la ventana de recuperar clave.
    /// </summary>
    public partial class VtnRecuperarClave : Form
    {
        /// <summary>
        /// Constructor de la clase VtnRecuperarClave.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnRecuperarClave()
        {
            InitializeComponent();
        }

        private void VtnRecuperarClave_Load(object sender, EventArgs e)
        {
            TxtRecuperarClave.Select();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string correoElectronico = TxtRecuperarClave.Text;
            Usuario usuario = new CN_Usuario().MostrarClave(correoElectronico, out string mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Recuperación de clave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (usuario != null)
            {
                MessageBox.Show("La contraseña del Usuario es: " + usuario.Clave, "Recuperación de clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se encontró un Usuario con el correo electrónico proporcionado.", "Recuperación de clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
