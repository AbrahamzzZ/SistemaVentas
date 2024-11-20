using Entidad;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class vtnNegocio : Form
    {
        public vtnNegocio()
        {
            InitializeComponent();
        }

        private void vtnNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteImage = new CapaNegocios().obtlSQL(out obtenido);
            if (obtenido)
            {
                pictureBox1.Image = ByteImage(byteImage);
            }
            Negocio datos = new CapaNegocios().ListarNegocio();
            txt1.Text = datos.Nombre;
            txt2.Text = datos.Telefono;
            txt3.Text = datos.Ruc;
            txt4.Text = datos.Direccion;
            txt5.Text = datos.CorreoElectronico;
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new CapaNegocios().actlSQL(byteImage, out mensaje);
                if (respuesta)
                {
                    pictureBox1.Image = ByteImage(byteImage);
                }
                else
                {
                    MessageBox.Show(mensaje, "Cargar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txt1.Text) || string.IsNullOrWhiteSpace(txt2.Text) || string.IsNullOrWhiteSpace(txt3.Text) || string.IsNullOrWhiteSpace(txt4.Text) || string.IsNullOrWhiteSpace(txt5.Text))
            {
                string mensajeError = "Por favor, complete los siguientes campos:\n";
                if (string.IsNullOrWhiteSpace(txt1.Text)) mensajeError += "- Nombre del negocio.\n";
                if (string.IsNullOrWhiteSpace(txt2.Text)) mensajeError += "- Teléfono del negocio.\n";
                if (string.IsNullOrWhiteSpace(txt3.Text)) mensajeError += "- Ruc del negocio.\n";
                if (string.IsNullOrWhiteSpace(txt4.Text)) mensajeError += "- Direccion del negocio.\n";
                if (string.IsNullOrWhiteSpace(txt5.Text)) mensajeError += "- Correo Electrónico del negocio.\n";

                MessageBox.Show(mensajeError, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Negocio negocioActualizado = new Negocio()
                {
                    Nombre = txt1.Text,
                    Telefono = txt2.Text,
                    Ruc = txt3.Text,
                    Direccion = txt4.Text,
                    CorreoElectronico = txt5.Text,
                };
                bool respuesta = new CapaNegocios().resneSQL(negocioActualizado, out mensaje);
                if (respuesta)
                {
                    MessageBox.Show("El negocio fue modificado correctamente.", "Modificar negocio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al modificar la información del negocio.", "Modificar negocio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public Image ByteImage(byte[] imageBytes)
        {
            if(imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }
            using(MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombre del negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Teléfono del negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Ruc del negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
