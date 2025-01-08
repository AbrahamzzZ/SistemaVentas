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
    public partial class VtnInformacionNegocio : Form
    {
        public VtnInformacionNegocio()
        {
            InitializeComponent();
        }

        private void VtnNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteImage = new CN_Negocio().MostrarLogo(out obtenido);
            if (obtenido)
            {
                PbFotoLogo.Image = ByteImage(byteImage);
            }
            Negocio datos = new CN_Negocio().ListarNegocio();
            TxtId.Text = datos.IdNegocio.ToString();
            TxtNombre.Text = datos.Nombre;
            TxtTelefono.Text = datos.Telefono;
            TxtRuc.Text = datos.Ruc;
            TxtDireccion.Text = datos.Direccion;
            TxtCorreoElectronico.Text = datos.CorreoElectronico;
        }

        private void BtnSubirImagen_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(byteImage, out mensaje);
                if (respuesta)
                {
                    PbFotoLogo.Image = ByteImage(byteImage);
                }
                else
                {
                    MessageBox.Show(mensaje, "Cargar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio negocioActualizado = new Negocio()
            {
                IdNegocio = Convert.ToInt32(TxtId.Text),
                Nombre = TxtNombre.Text,
                Telefono = TxtTelefono.Text,
                Ruc = TxtRuc.Text,
                Direccion = TxtDireccion.Text,
                CorreoElectronico = TxtCorreoElectronico.Text,
            };
            bool respuesta = new CN_Negocio().Editar(negocioActualizado, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("El negocio fue modificado correctamente.", "Modificar negocio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se pudo modificar la información del negocio: {mensaje}", "Modificar negocio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
