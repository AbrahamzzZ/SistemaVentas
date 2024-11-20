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
    public partial class vtnRecuperarClave : Form
    {
        public vtnRecuperarClave()
        {
            InitializeComponent();
        }
        private void vtnRecuperarClave_Load(object sender, EventArgs e)
        {
            txt1.Select();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string correoElectronico = txt1.Text;
            Usuario usuario = new CapaNegocios().recSQL(correoElectronico);
            if (string.IsNullOrWhiteSpace(txt1.Text))
            {
                MessageBox.Show("Por favor llene el campo. ", "Recuperación de clave.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (usuario != null)
            {
                MessageBox.Show("La contraseña del usuario es: " + usuario.Clave, "Recupearación de clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se encontró un usuario con el correo electrónico proporcionado.", "Recuperación de clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
