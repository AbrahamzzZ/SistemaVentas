using System;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario base de la aplicación: aplica el <see cref="Tema"/> antes de mostrar la ventana.
    /// </summary>
    public class FormularioBase : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            Tema.Aplicar(this);
            base.OnLoad(e);
        }
    }
}
