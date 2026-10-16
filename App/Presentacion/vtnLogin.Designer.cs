namespace Presentacion
{
    partial class VtnLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VtnLogin));
            this.PanelMarca = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblMarcaSubtitulo = new System.Windows.Forms.Label();
            this.lblMarcaTitulo = new System.Windows.Forms.Label();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.PanelFormulario = new System.Windows.Forms.Panel();
            this.lnkOlvidoClave = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.PanelClave = new System.Windows.Forms.Panel();
            this.btnVerClave = new System.Windows.Forms.Button();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.PanelCodigo = new System.Windows.Forms.Panel();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.PanelMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.PanelFormulario.SuspendLayout();
            this.PanelClave.SuspendLayout();
            this.PanelCodigo.SuspendLayout();
            this.SuspendLayout();
            //
            // PanelMarca
            //
            this.PanelMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.PanelMarca.Controls.Add(this.lblVersion);
            this.PanelMarca.Controls.Add(this.lblMarcaSubtitulo);
            this.PanelMarca.Controls.Add(this.lblMarcaTitulo);
            this.PanelMarca.Controls.Add(this.PictureBoxLogo);
            this.PanelMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMarca.Location = new System.Drawing.Point(0, 0);
            this.PanelMarca.Name = "PanelMarca";
            this.PanelMarca.Size = new System.Drawing.Size(340, 500);
            this.PanelMarca.TabIndex = 0;
            this.PanelMarca.Tag = "SinTema";
            this.PanelMarca.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMarca_Paint);
            this.PanelMarca.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // lblVersion
            //
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.lblVersion.Location = new System.Drawing.Point(20, 462);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(300, 20);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Versión";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // lblMarcaSubtitulo
            //
            this.lblMarcaSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcaSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMarcaSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.lblMarcaSubtitulo.Location = new System.Drawing.Point(30, 334);
            this.lblMarcaSubtitulo.Name = "lblMarcaSubtitulo";
            this.lblMarcaSubtitulo.Size = new System.Drawing.Size(280, 48);
            this.lblMarcaSubtitulo.TabIndex = 2;
            this.lblMarcaSubtitulo.Text = "Ventas, compras e inventario de tu minimarket en un solo lugar.";
            this.lblMarcaSubtitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMarcaSubtitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // lblMarcaTitulo
            //
            this.lblMarcaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblMarcaTitulo.ForeColor = System.Drawing.Color.White;
            this.lblMarcaTitulo.Location = new System.Drawing.Point(20, 288);
            this.lblMarcaTitulo.Name = "lblMarcaTitulo";
            this.lblMarcaTitulo.Size = new System.Drawing.Size(300, 42);
            this.lblMarcaTitulo.TabIndex = 1;
            this.lblMarcaTitulo.Text = "Sistema de Ventas";
            this.lblMarcaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarcaTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // PictureBoxLogo
            //
            this.PictureBoxLogo.BackColor = System.Drawing.Color.White;
            this.PictureBoxLogo.Image = global::Presentacion.Properties.Resources.Logo1;
            this.PictureBoxLogo.Location = new System.Drawing.Point(100, 82);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(140, 130);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxLogo.TabIndex = 0;
            this.PictureBoxLogo.TabStop = false;
            this.PictureBoxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // PanelFormulario
            //
            this.PanelFormulario.BackColor = System.Drawing.Color.White;
            this.PanelFormulario.Controls.Add(this.lnkOlvidoClave);
            this.PanelFormulario.Controls.Add(this.btnIngresar);
            this.PanelFormulario.Controls.Add(this.lblAviso);
            this.PanelFormulario.Controls.Add(this.PanelClave);
            this.PanelFormulario.Controls.Add(this.lblClave);
            this.PanelFormulario.Controls.Add(this.PanelCodigo);
            this.PanelFormulario.Controls.Add(this.lblCodigo);
            this.PanelFormulario.Controls.Add(this.lblSubtitulo);
            this.PanelFormulario.Controls.Add(this.lblTitulo);
            this.PanelFormulario.Controls.Add(this.btnCerrar);
            this.PanelFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFormulario.Location = new System.Drawing.Point(340, 0);
            this.PanelFormulario.Name = "PanelFormulario";
            this.PanelFormulario.Size = new System.Drawing.Size(480, 500);
            this.PanelFormulario.TabIndex = 1;
            this.PanelFormulario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // lnkOlvidoClave
            //
            this.lnkOlvidoClave.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lnkOlvidoClave.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lnkOlvidoClave.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOlvidoClave.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lnkOlvidoClave.Location = new System.Drawing.Point(63, 418);
            this.lnkOlvidoClave.Name = "lnkOlvidoClave";
            this.lnkOlvidoClave.Size = new System.Drawing.Size(354, 24);
            this.lnkOlvidoClave.TabIndex = 5;
            this.lnkOlvidoClave.TabStop = true;
            this.lnkOlvidoClave.Text = "¿Olvidaste tu contraseña?";
            this.lnkOlvidoClave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkOlvidoClave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkOlvidoClave_LinkClicked);
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(63, 358);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(354, 46);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Iniciar sesión";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            //
            // lblAviso
            //
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblAviso.Location = new System.Drawing.Point(63, 322);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(354, 32);
            this.lblAviso.TabIndex = 9;
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            //
            // PanelClave
            //
            this.PanelClave.BackColor = System.Drawing.Color.White;
            this.PanelClave.Controls.Add(this.btnVerClave);
            this.PanelClave.Controls.Add(this.TxtClave);
            this.PanelClave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PanelClave.Location = new System.Drawing.Point(63, 276);
            this.PanelClave.Name = "PanelClave";
            this.PanelClave.Size = new System.Drawing.Size(354, 44);
            this.PanelClave.TabIndex = 3;
            this.PanelClave.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCampo_Paint);
            this.PanelClave.Click += new System.EventHandler(this.PanelClave_Click);
            //
            // btnVerClave
            //
            this.btnVerClave.BackColor = System.Drawing.Color.White;
            this.btnVerClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerClave.FlatAppearance.BorderSize = 0;
            this.btnVerClave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.btnVerClave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.btnVerClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerClave.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnVerClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnVerClave.Location = new System.Drawing.Point(312, 6);
            this.btnVerClave.Name = "btnVerClave";
            this.btnVerClave.Size = new System.Drawing.Size(36, 32);
            this.btnVerClave.TabIndex = 1;
            this.btnVerClave.TabStop = false;
            this.btnVerClave.Tag = "SinTema";
            this.btnVerClave.Text = "";
            this.btnVerClave.UseVisualStyleBackColor = false;
            this.btnVerClave.Click += new System.EventHandler(this.BtnVerClave_Click);
            //
            // TxtClave
            //
            this.TxtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtClave.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.TxtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.TxtClave.Location = new System.Drawing.Point(14, 11);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PlaceholderText = "Ingresa tu contraseña";
            this.TxtClave.Size = new System.Drawing.Size(290, 20);
            this.TxtClave.TabIndex = 0;
            this.TxtClave.UseSystemPasswordChar = true;
            this.TxtClave.TextChanged += new System.EventHandler(this.Campo_TextChanged);
            this.TxtClave.Enter += new System.EventHandler(this.Campo_FocoCambiado);
            this.TxtClave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtClave_KeyUp);
            this.TxtClave.Leave += new System.EventHandler(this.Campo_FocoCambiado);
            //
            // lblClave
            //
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblClave.Location = new System.Drawing.Point(61, 252);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(72, 17);
            this.lblClave.TabIndex = 8;
            this.lblClave.Text = "Contraseña";
            //
            // PanelCodigo
            //
            this.PanelCodigo.BackColor = System.Drawing.Color.White;
            this.PanelCodigo.Controls.Add(this.TxtCodigo);
            this.PanelCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PanelCodigo.Location = new System.Drawing.Point(63, 194);
            this.PanelCodigo.Name = "PanelCodigo";
            this.PanelCodigo.Size = new System.Drawing.Size(354, 44);
            this.PanelCodigo.TabIndex = 2;
            this.PanelCodigo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCampo_Paint);
            this.PanelCodigo.Click += new System.EventHandler(this.PanelCodigo_Click);
            //
            // TxtCodigo
            //
            this.TxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCodigo.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.TxtCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.TxtCodigo.Location = new System.Drawing.Point(14, 11);
            this.TxtCodigo.MaxLength = 10;
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.PlaceholderText = "Ej. 00001";
            this.TxtCodigo.Size = new System.Drawing.Size(326, 20);
            this.TxtCodigo.TabIndex = 0;
            this.TxtCodigo.TextChanged += new System.EventHandler(this.Campo_TextChanged);
            this.TxtCodigo.Enter += new System.EventHandler(this.Campo_FocoCambiado);
            this.TxtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            this.TxtCodigo.Leave += new System.EventHandler(this.Campo_FocoCambiado);
            //
            // lblCodigo
            //
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCodigo.Location = new System.Drawing.Point(61, 170);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(117, 17);
            this.lblCodigo.TabIndex = 7;
            this.lblCodigo.Text = "Código de usuario";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(62, 116);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(258, 19);
            this.lblSubtitulo.TabIndex = 6;
            this.lblSubtitulo.Text = "Ingresa tus credenciales para continuar.";
            this.lblSubtitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(57, 70);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(165, 41);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Bienvenido";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrastrarVentana);
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btnCerrar.Location = new System.Drawing.Point(434, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(46, 34);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Tag = "SinTema";
            this.btnCerrar.Text = "";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.BtnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.BtnCerrar_MouseLeave);
            //
            // VtnLogin
            //
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 500);
            this.Controls.Add(this.PanelFormulario);
            this.Controls.Add(this.PanelMarca);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "VtnLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.Load += new System.EventHandler(this.VtnLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VtnLogin_KeyDown);
            this.PanelMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.PanelFormulario.ResumeLayout(false);
            this.PanelFormulario.PerformLayout();
            this.PanelClave.ResumeLayout(false);
            this.PanelClave.PerformLayout();
            this.PanelCodigo.ResumeLayout(false);
            this.PanelCodigo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMarca;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
        private System.Windows.Forms.Label lblMarcaTitulo;
        private System.Windows.Forms.Label lblMarcaSubtitulo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel PanelFormulario;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel PanelCodigo;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Panel PanelClave;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.Button btnVerClave;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.LinkLabel lnkOlvidoClave;
    }
}
