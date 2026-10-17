using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Paleta de colores de la aplicación y reglas para aplicarla a los controles.
    /// </summary>
    /// <remarks>
    /// Los formularios conservan los colores originales en sus archivos .Designer.cs; este tema los
    /// reemplaza al abrir cada ventana (ver <see cref="FormularioBase"/>). Para cambiar la apariencia
    /// de toda la aplicación basta con modificar los colores de esta clase.
    /// </remarks>
    public static class Tema
    {
        // Paleta "verde fresco": verde para la identidad y las acciones, naranja como acento.
        public static readonly Color Primario = ColorTranslator.FromHtml("#2E7D32");
        public static readonly Color PrimarioOscuro = ColorTranslator.FromHtml("#1B5E20");
        public static readonly Color PrimarioClaro = ColorTranslator.FromHtml("#E8F5E9");
        public static readonly Color Seleccion = ColorTranslator.FromHtml("#C8E6C9");
        public static readonly Color Acento = ColorTranslator.FromHtml("#F57C00");
        public static readonly Color Fondo = ColorTranslator.FromHtml("#F1F4F1");
        public static readonly Color Superficie = Color.White;
        public static readonly Color FilaAlterna = ColorTranslator.FromHtml("#F7FAF7");
        public static readonly Color Texto = ColorTranslator.FromHtml("#212121");
        public static readonly Color TextoSecundario = ColorTranslator.FromHtml("#616161");
        public static readonly Color Borde = ColorTranslator.FromHtml("#D5DBD5");
        public static readonly Color Neutro = ColorTranslator.FromHtml("#ECEFF1");
        public static readonly Color NeutroHover = ColorTranslator.FromHtml("#DDE3E6");
        public static readonly Color Peligro = ColorTranslator.FromHtml("#C62828");
        public static readonly Color PeligroHover = ColorTranslator.FromHtml("#A31F1F");
        public static readonly Color PeligroClaro = ColorTranslator.FromHtml("#FFEBEE");

        // Colores con los que se diseñaron los formularios originalmente
        private static readonly Color FondoOriginal = SystemColors.GradientActiveCaption;
        private static readonly Color DestacadoOriginal = Color.Wheat;
        private static readonly Color SoloLecturaOriginal = Color.LightGray;

        /// <summary>
        /// Valor de <see cref="Control.Tag"/> para que el tema no modifique un control (ni sus hijos)
        /// que ya tiene un estilo propio.
        /// </summary>
        public const string SinTema = "SinTema";

        /// <summary>
        /// Aplica el tema a un control y a todos sus controles hijos.
        /// </summary>
        public static void Aplicar(Control control)
        {
            if (SinTema.Equals(control.Tag))
            {
                return;
            }

            if (control is Form)
            {
                DesactivarAutoescalado(control);
            }

            ModernizarFuente(control);

            switch (control)
            {
                case Button boton:
                    EstiloBoton(boton);
                    break;
                case DataGridView tabla:
                    EstiloTabla(tabla);
                    break;
                case MenuStrip menu:
                    EstiloMenu(menu);
                    break;
                case TextBox texto when texto.BackColor == SoloLecturaOriginal:
                    texto.BackColor = Neutro;
                    break;
                default:
                    ReemplazarFondo(control);
                    break;
            }

            AjustarColorTexto(control);

            foreach (Control hijo in control.Controls)
            {
                Aplicar(hijo);
            }
        }

        /// <summary>
        /// Colorea la celda de la columna Estado: verde si está activo, rojo si no.
        /// </summary>
        public static void EstiloEstado(DataGridViewCellStyle estilo, bool activo)
        {
            estilo.BackColor = activo ? PrimarioClaro : PeligroClaro;
            estilo.ForeColor = activo ? PrimarioOscuro : Peligro;
            estilo.SelectionBackColor = activo ? Seleccion : PeligroClaro;
            estilo.SelectionForeColor = estilo.ForeColor;
        }

        /// <summary>
        /// Estilo para un botón de solo ícono ubicado sobre la barra del menú principal.
        /// </summary>
        public static void EstiloBotonBarra(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor = Primario;
            boton.FlatAppearance.MouseDownBackColor = Primario;
            boton.BackColor = PrimarioOscuro;
            if (boton.Image != null)
            {
                boton.Image = Recolorear(boton.Image, Color.White);
            }
        }

        private static void ReemplazarFondo(Control control)
        {
            if (control.BackColor == FondoOriginal)
            {
                // Área de trabajo: blanca, como el panel del formulario del login
                control.BackColor = Superficie;
            }
            else if (control.BackColor == DestacadoOriginal)
            {
                // Paneles laterales de "Detalles" y sus etiquetas: verdes, como el panel de marca del login
                control.BackColor = Primario;
            }
        }

        /// <summary>
        /// Texto blanco sobre los paneles verdes y gris carbón en el resto.
        /// </summary>
        private static void AjustarColorTexto(Control control)
        {
            if (!(control is Label || control is CheckBox || control is RadioButton || control is GroupBox))
            {
                return;
            }

            if (control.BackColor == Primario)
            {
                control.ForeColor = Color.White;
            }
            else if (control.ForeColor == SystemColors.ControlText || control.ForeColor == Color.Black)
            {
                control.ForeColor = Texto;
            }
        }

        /// <summary>
        /// Cambia Microsoft Sans Serif por Segoe UI (Semibold para las negritas), la fuente del login.
        /// </summary>
        /// <remarks>
        /// No se cambia la fuente del formulario: con AutoScaleMode.Font eso reescalaría todos los controles.
        /// </remarks>
        private static void ModernizarFuente(Control control)
        {
            if (control is Form)
            {
                return;
            }
            Font moderna = FuenteModerna(control.Font);
            if (moderna != null)
            {
                control.Font = moderna;
            }
        }

        /// <summary>
        /// Los contenedores internos (como NumericUpDown) se reescalan, y se mueven, cuando cambia su
        /// fuente o la de su control padre. Se desactiva antes de cambiar cualquier fuente.
        /// </summary>
        private static void DesactivarAutoescalado(Control raiz)
        {
            foreach (Control hijo in raiz.Controls)
            {
                if (hijo is ContainerControl contenedor)
                {
                    contenedor.AutoScaleMode = AutoScaleMode.None;
                }
                DesactivarAutoescalado(hijo);
            }
        }

        /// <summary>
        /// Indica si el control está sobre un panel verde: dentro de él o encima de él (los paneles
        /// laterales son etiquetas grandes con los controles superpuestos, no contenidos).
        /// </summary>
        private static bool EstaSobrePanelVerde(Control control)
        {
            bool EsVerde(Control c) => c.BackColor == Primario || c.BackColor == DestacadoOriginal;

            Control padre = control.Parent;
            if (padre == null)
            {
                return false;
            }
            if (!(padre is Form) && EsVerde(padre))
            {
                return true;
            }
            int miOrden = padre.Controls.GetChildIndex(control);
            foreach (Control hermano in padre.Controls)
            {
                if (hermano != control && EsVerde(hermano) && hermano.Bounds.Contains(control.Bounds)
                    && padre.Controls.GetChildIndex(hermano) > miOrden)
                {
                    return true;
                }
            }
            return false;
        }

        private static Font FuenteModerna(Font fuente)
        {
            if (fuente == null || fuente.Name != "Microsoft Sans Serif")
            {
                return null;
            }
            // Segoe UI es más alta que Microsoft Sans Serif: el texto normal (10.2) baja a 9.75 para no
            // invadir el control de abajo; se ve del mismo tamaño
            float tamanio = fuente.Size >= 10f && fuente.Size <= 10.5f ? 9.75f : fuente.Size;
            return fuente.Bold
                ? new Font("Segoe UI Semibold", tamanio, fuente.Style & ~FontStyle.Bold, fuente.Unit)
                : new Font("Segoe UI", tamanio, fuente.Style, fuente.Unit);
        }

        private static void ModernizarFuente(DataGridViewCellStyle estilo)
        {
            Font moderna = FuenteModerna(estilo.Font);
            if (moderna != null)
            {
                estilo.Font = moderna;
            }
        }

        private static void EstiloBoton(Button boton)
        {
            string nombre = (boton.Name + " " + boton.Text).ToLowerInvariant();
            // Los íconos son de colores o negros: sobre verde no se distinguen, por eso van en fondo claro
            bool conIcono = boton.Image != null || string.IsNullOrWhiteSpace(boton.Text);

            Color fondo, hover, texto;
            if (nombre.Contains("eliminar") && !conIcono)
            {
                (fondo, hover, texto) = (Peligro, PeligroHover, Color.White);
            }
            else if (conIcono || nombre.Contains("limpiar") || nombre.Contains("salir")
                     || nombre.Contains("cancelar") || nombre.Contains("cerrar") || nombre.Contains("regresar"))
            {
                (fondo, hover, texto) = (Neutro, NeutroHover, Texto);
            }
            else
            {
                (fondo, hover, texto) = (Primario, PrimarioOscuro, Color.White);
            }

            // Sobre un panel verde el botón verde no se distingue: se invierte a blanco con texto verde
            if (fondo == Primario && EstaSobrePanelVerde(boton))
            {
                (fondo, hover, texto) = (Superficie, PrimarioClaro, PrimarioOscuro);
            }

            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = fondo == Neutro ? 1 : 0;
            boton.FlatAppearance.BorderColor = Borde;
            boton.FlatAppearance.MouseOverBackColor = hover;
            boton.FlatAppearance.MouseDownBackColor = hover;
            boton.BackColor = fondo;
            boton.ForeColor = texto;
            boton.Cursor = Cursors.Hand;
        }

        private static void EstiloTabla(DataGridView tabla)
        {
            tabla.EnableHeadersVisualStyles = false;
            tabla.BackgroundColor = Superficie;
            tabla.GridColor = Borde;

            DataGridViewCellStyle encabezado = tabla.ColumnHeadersDefaultCellStyle;
            encabezado.BackColor = PrimarioOscuro;
            encabezado.ForeColor = Color.White;
            encabezado.SelectionBackColor = PrimarioOscuro;
            encabezado.SelectionForeColor = Color.White;
            Font fuenteBase = encabezado.Font ?? tabla.Font;
            encabezado.Font = new Font("Segoe UI Semibold", fuenteBase.Size, FontStyle.Regular, fuenteBase.Unit);
            encabezado.Padding = new Padding(6, 0, 6, 0);

            // Aspecto moderno: sin borde exterior, sin columna de flechas y solo líneas horizontales
            tabla.BorderStyle = BorderStyle.None;
            tabla.RowHeadersVisible = false;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tabla.ColumnHeadersHeight = 42;
            tabla.RowTemplate.Height = Math.Max(tabla.RowTemplate.Height, 32);

            ModernizarFuente(tabla.DefaultCellStyle);
            ModernizarFuente(tabla.RowsDefaultCellStyle);
            ModernizarFuente(tabla.RowTemplate.DefaultCellStyle);
            tabla.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            tabla.DefaultCellStyle.ForeColor = Texto;

            tabla.DefaultCellStyle.SelectionBackColor = Seleccion;
            tabla.DefaultCellStyle.SelectionForeColor = Texto;
            tabla.RowsDefaultCellStyle.SelectionBackColor = Seleccion;
            tabla.RowsDefaultCellStyle.SelectionForeColor = Texto;
            tabla.RowTemplate.DefaultCellStyle.SelectionBackColor = Seleccion;
            tabla.RowTemplate.DefaultCellStyle.SelectionForeColor = Texto;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = FilaAlterna;

            // Algunas columnas traen su propio color de selección desde el diseñador
            foreach (DataGridViewColumn columna in tabla.Columns)
            {
                if (columna.HasDefaultCellStyle)
                {
                    columna.DefaultCellStyle.SelectionBackColor = Seleccion;
                    columna.DefaultCellStyle.SelectionForeColor = Texto;
                    ModernizarFuente(columna.DefaultCellStyle);
                }
            }
        }

        private static void EstiloMenu(MenuStrip menu)
        {
            // La barra de títulos del menú principal es blanca y se deja así
            if (menu.BackColor != DestacadoOriginal)
            {
                return;
            }

            menu.BackColor = PrimarioOscuro;
            menu.RenderMode = ToolStripRenderMode.Professional;
            menu.Renderer = new ToolStripProfessionalRenderer(new ColoresMenu());

            foreach (ToolStripItem item in menu.Items)
            {
                item.BackColor = PrimarioOscuro;
                item.ForeColor = Color.White;
                if (item.Image != null)
                {
                    item.Image = Recolorear(item.Image, Color.White);
                }
                if (item is ToolStripMenuItem opcion)
                {
                    foreach (ToolStripItem subItem in opcion.DropDownItems)
                    {
                        subItem.BackColor = Superficie;
                        subItem.ForeColor = Texto;
                    }
                }
            }
        }

        /// <summary>
        /// Devuelve una copia del ícono con todos sus píxeles visibles pintados de un solo color.
        /// </summary>
        private static Image Recolorear(Image imagen, Color color)
        {
            var resultado = new Bitmap(imagen.Width, imagen.Height);
            var matriz = new ColorMatrix(new[]
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { color.R / 255f, color.G / 255f, color.B / 255f, 0, 1 },
            });
            using (var atributos = new ImageAttributes())
            using (Graphics g = Graphics.FromImage(resultado))
            {
                atributos.SetColorMatrix(matriz);
                g.DrawImage(imagen, new Rectangle(0, 0, imagen.Width, imagen.Height),
                    0, 0, imagen.Width, imagen.Height, GraphicsUnit.Pixel, atributos);
            }
            return resultado;
        }

        /// <summary>
        /// Colores del menú principal al pasar el mouse y en las listas desplegables.
        /// </summary>
        private sealed class ColoresMenu : ProfessionalColorTable
        {
            // Opciones de la barra (texto blanco): verde
            public override Color MenuItemSelectedGradientBegin => Primario;
            public override Color MenuItemSelectedGradientEnd => Primario;
            public override Color MenuItemPressedGradientBegin => Primario;
            public override Color MenuItemPressedGradientMiddle => Primario;
            public override Color MenuItemPressedGradientEnd => Primario;
            // Opciones de las listas desplegables (texto oscuro): verde claro
            public override Color MenuItemSelected => PrimarioClaro;
            public override Color MenuItemBorder => Seleccion;
            public override Color MenuBorder => Borde;
            public override Color ToolStripDropDownBackground => Superficie;
            public override Color ImageMarginGradientBegin => Superficie;
            public override Color ImageMarginGradientMiddle => Superficie;
            public override Color ImageMarginGradientEnd => Superficie;
            public override Color SeparatorDark => Borde;
            public override Color SeparatorLight => Superficie;
        }
    }
}
