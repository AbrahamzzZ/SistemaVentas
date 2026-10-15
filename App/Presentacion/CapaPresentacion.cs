using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class CapaPresentacion
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary> 
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            // Mismo comportamiento que en .NET Framework: sin escalado por DPI y con la fuente por defecto
            // anterior (en .NET moderno cambió a Segoe UI 9pt y agrandaría los controles de los formularios).
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetDefaultFont(new System.Drawing.Font("Microsoft Sans Serif", 8.25f));
            Application.Run(new VtnLogin());
        }
    }
}
 