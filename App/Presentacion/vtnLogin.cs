using System;
using Negocios;
using Entidad;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Clase que representa la ventana del login.
    /// </summary>
    public partial class VtnLogin : FormularioBase
    {
        // Íconos de la fuente Segoe MDL2 Assets (incluida en Windows 10 y 11)
        private const string IconoCerrar = "";
        private const string IconoVer = "";
        private const string IconoOcultar = "";

        private const string MensajeLimiteIntentos = "Se ha alcanzado el límite de intentos fallidos";

        private string mensajeError;

        /// <summary>
        /// Constructor de la clase VtnLogin.
        /// Inicializa los componentes de la ventana.
        /// </summary>
        public VtnLogin()
        {
            InitializeComponent();
            btnCerrar.Text = IconoCerrar;
            btnVerClave.Text = IconoVer;
            lblVersion.Text = "Versión " + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        }

        /// <summary>
        /// Agrega la sombra de ventana, que el formulario no tiene por no usar el borde de Windows.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams parametros = base.CreateParams;
                parametros.ClassStyle |= CS_DROPSHADOW;
                return parametros;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Esquinas redondeadas en Windows 11 (en Windows 10 no tiene efecto)
            const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
            int redondeadas = 2;
            DwmSetWindowAttribute(Handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref redondeadas, sizeof(int));
        }

        private void VtnLogin_Load(object sender, EventArgs e)
        {
            TxtCodigo.Select();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Llamar al método de validación de login de la capa de negocios
            CN_Usuario cnUsuario = new CN_Usuario();
            string mensaje = cnUsuario.ValidarLogin(TxtCodigo.Text, TxtClave.Text);

            if (!string.IsNullOrEmpty(mensaje))
            {
                if (mensaje.Contains(MensajeLimiteIntentos))
                {
                    MessageBox.Show(mensaje, "Inicio de sesión bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                MostrarError(mensaje);
                TxtClave.SelectAll();
                TxtClave.Focus();
                return;
            }

            Usuario usuario = cnUsuario.Ingresar(TxtCodigo.Text);
            Usuario_Catched usuarioSesion = Usuario_Catched.GetInstance();

            usuarioSesion.IdUsuario = usuario.IdUsuario;
            usuarioSesion.Codigo = usuario.Codigo;
            usuarioSesion.NombreCompleto = usuario.NombreCompleto;
            usuarioSesion.ClaveEncriptada = usuario.ClaveEncriptada;
            usuarioSesion.Estado = usuario.Estado;

            VtnMenu menu = new VtnMenu(usuarioSesion);
            menu.FormClosing += Cerrar;
            menu.Show();
            this.Hide();
        }

        private void Cerrar(object sender, FormClosingEventArgs e)
        {
            TxtCodigo.Clear();
            TxtClave.Clear();
            MostrarError(null);
            this.Show();
            TxtCodigo.Select();
        }

        private void LnkOlvidoClave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VtnRestablecerClave restablecer = new VtnRestablecerClave();
            this.Hide();
            restablecer.ShowDialog();
            this.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VtnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void BtnVerClave_Click(object sender, EventArgs e)
        {
            TxtClave.UseSystemPasswordChar = !TxtClave.UseSystemPasswordChar;
            btnVerClave.Text = TxtClave.UseSystemPasswordChar ? IconoVer : IconoOcultar;
            TxtClave.Focus();
            TxtClave.SelectionStart = TxtClave.TextLength;
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // El código de usuario solo tiene números
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtClave_KeyUp(object sender, KeyEventArgs e)
        {
            ActualizarAviso();
        }

        private void Campo_TextChanged(object sender, EventArgs e)
        {
            if (mensajeError != null)
            {
                MostrarError(null);
            }
        }

        private void Campo_FocoCambiado(object sender, EventArgs e)
        {
            PanelCodigo.Invalidate();
            PanelClave.Invalidate();
            ActualizarAviso();
        }

        private void PanelCodigo_Click(object sender, EventArgs e) => TxtCodigo.Focus();

        private void PanelClave_Click(object sender, EventArgs e) => TxtClave.Focus();

        /// <summary>
        /// Muestra un error debajo de los campos; con null lo oculta.
        /// </summary>
        private void MostrarError(string mensaje)
        {
            mensajeError = mensaje;
            ActualizarAviso();
            PanelCodigo.Invalidate();
            PanelClave.Invalidate();
        }

        /// <summary>
        /// El aviso muestra el error del login o, si no hay error, si Bloq Mayús está activado.
        /// </summary>
        private void ActualizarAviso()
        {
            if (mensajeError != null)
            {
                lblAviso.ForeColor = Tema.Peligro;
                lblAviso.Text = mensajeError;
            }
            else if (TxtClave.Focused && Control.IsKeyLocked(Keys.CapsLock))
            {
                lblAviso.ForeColor = Tema.Acento;
                lblAviso.Text = "Bloq Mayús está activado.";
            }
            else
            {
                lblAviso.Text = string.Empty;
            }
        }

        /// <summary>
        /// Dibuja el borde redondeado de los campos: verde con foco, rojo si hay error y gris en reposo.
        /// </summary>
        private void PanelCampo_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Color color = panel.ContainsFocus ? Tema.Primario : mensajeError != null ? Tema.Peligro : Tema.Borde;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle area = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using (GraphicsPath borde = Redondeado(area, 8))
            using (Pen lapiz = new Pen(color, panel.ContainsFocus ? 2f : 1f))
            {
                e.Graphics.DrawPath(lapiz, borde);
            }
        }

        /// <summary>
        /// Fondo del panel de marca: degradado verde y círculo blanco detrás del logo.
        /// </summary>
        private void PanelMarca_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var degradado = new LinearGradientBrush(PanelMarca.ClientRectangle, Tema.Primario, Tema.PrimarioOscuro, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(degradado, PanelMarca.ClientRectangle);
            }

            Rectangle logo = PictureBoxLogo.Bounds;
            int diametro = 200; // cubre las esquinas del logo (140x130)
            Rectangle circulo = new Rectangle(logo.X + (logo.Width - diametro) / 2, logo.Y + (logo.Height - diametro) / 2, diametro, diametro);
            using (var sombra = new SolidBrush(Color.FromArgb(40, Color.Black)))
            {
                e.Graphics.FillEllipse(sombra, circulo.X, circulo.Y + 4, circulo.Width, circulo.Height);
            }
            e.Graphics.FillEllipse(Brushes.White, circulo);
        }

        private static GraphicsPath Redondeado(Rectangle r, int radio)
        {
            int d = radio * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void BtnCerrar_MouseEnter(object sender, EventArgs e) => btnCerrar.ForeColor = Color.White;

        private void BtnCerrar_MouseLeave(object sender, EventArgs e) => btnCerrar.ForeColor = Tema.TextoSecundario;

        /// <summary>
        /// Permite mover la ventana arrastrándola, ya que no tiene barra de título.
        /// </summary>
        private void ArrastrarVentana(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                const int WM_NCLBUTTONDOWN = 0xA1;
                const int HTCAPTION = 0x2;
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int value, int size);
    }
}
