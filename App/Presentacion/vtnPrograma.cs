using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class vtnPrograma : Form
    {
        public vtnPrograma()
        {
            InitializeComponent();
        }

        private void btnDescargarDocumentacion_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Guardar Documentación";
                saveFileDialog.FileName = "Documentación.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                { 
                    string sourcePath = Path.Combine(Application.StartupPath, "Resources", "Documentación.pdf");
                    string destinationPath = saveFileDialog.FileName;
                    File.Copy(sourcePath, destinationPath, true);
                    MessageBox.Show("La documentación ha sido descargada con éxito.", "Información del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(destinationPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descargar la documentación: " + ex.Message, "Información del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
