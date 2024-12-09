using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class VtnAutor : Form
    {
        public VtnAutor()
        {
            InitializeComponent();
        }

        private void LinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/AbrahamzzZ?tab=repositories";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("No se pudo abrir el enlace. Verifica que tienes un navegador predeterminado configurado.", "Error al abrir el enlace", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
