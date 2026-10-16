namespace Presentacion
{
    partial class VtnMapaSucursal
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
            this.PanelEncabezado = new System.Windows.Forms.Panel();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnUsarUbicacion = new System.Windows.Forms.Button();
            this.lblIndicacion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.mapa = new GMap.NET.WindowsForms.GMapControl();
            this.PanelEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // PanelEncabezado
            //
            this.PanelEncabezado.BackColor = System.Drawing.Color.White;
            this.PanelEncabezado.Controls.Add(this.lblCoordenadas);
            this.PanelEncabezado.Controls.Add(this.btnCancelar);
            this.PanelEncabezado.Controls.Add(this.btnUsarUbicacion);
            this.PanelEncabezado.Controls.Add(this.lblIndicacion);
            this.PanelEncabezado.Controls.Add(this.lblTitulo);
            this.PanelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.PanelEncabezado.Name = "PanelEncabezado";
            this.PanelEncabezado.Size = new System.Drawing.Size(1000, 84);
            this.PanelEncabezado.TabIndex = 0;
            //
            // lblCoordenadas
            //
            this.lblCoordenadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoordenadas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoordenadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblCoordenadas.Location = new System.Drawing.Point(690, 58);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(290, 20);
            this.lblCoordenadas.TabIndex = 4;
            this.lblCoordenadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnCancelar
            //
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancelar.Location = new System.Drawing.Point(674, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 38);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            //
            // btnUsarUbicacion
            //
            this.btnUsarUbicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsarUbicacion.Enabled = false;
            this.btnUsarUbicacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUsarUbicacion.Location = new System.Drawing.Point(806, 14);
            this.btnUsarUbicacion.Name = "btnUsarUbicacion";
            this.btnUsarUbicacion.Size = new System.Drawing.Size(174, 38);
            this.btnUsarUbicacion.TabIndex = 2;
            this.btnUsarUbicacion.Text = "Usar esta ubicación";
            this.btnUsarUbicacion.UseVisualStyleBackColor = true;
            this.btnUsarUbicacion.Click += new System.EventHandler(this.BtnUsarUbicacion_Click);
            //
            // lblIndicacion
            //
            this.lblIndicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndicacion.AutoEllipsis = true;
            this.lblIndicacion.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblIndicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblIndicacion.Location = new System.Drawing.Point(22, 50);
            this.lblIndicacion.Name = "lblIndicacion";
            this.lblIndicacion.Size = new System.Drawing.Size(650, 20);
            this.lblIndicacion.TabIndex = 1;
            this.lblIndicacion.Text = "Indicación";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(18, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mapa de sucursales";
            //
            // mapa
            //
            this.mapa.Bearing = 0F;
            this.mapa.CanDragMap = true;
            this.mapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapa.EmptyTileColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(241)))));
            this.mapa.GrayScaleMode = false;
            this.mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapa.Location = new System.Drawing.Point(0, 84);
            this.mapa.MarkersEnabled = true;
            this.mapa.MaxZoom = 20;
            this.mapa.MinZoom = 3;
            this.mapa.MouseWheelZoomEnabled = true;
            this.mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapa.Name = "mapa";
            this.mapa.NegativeMode = false;
            this.mapa.PolygonsEnabled = false;
            this.mapa.RetryLoadTile = 0;
            this.mapa.RoutesEnabled = false;
            this.mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapa.ShowCenter = false;
            this.mapa.ShowTileGridLines = false;
            this.mapa.Size = new System.Drawing.Size(1000, 566);
            this.mapa.TabIndex = 1;
            this.mapa.Zoom = 13D;
            this.mapa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mapa_MouseDown);
            this.mapa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mapa_MouseUp);
            //
            // VtnMapaSucursal
            //
            this.AcceptButton = this.btnUsarUbicacion;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.mapa);
            this.Controls.Add(this.PanelEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Icon = global::Presentacion.Properties.Resources.Logo;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "VtnMapaSucursal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mapa de sucursales";
            this.Shown += new System.EventHandler(this.VtnMapaSucursal_Shown);
            this.PanelEncabezado.ResumeLayout(false);
            this.PanelEncabezado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIndicacion;
        private System.Windows.Forms.Button btnUsarUbicacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCoordenadas;
        private GMap.NET.WindowsForms.GMapControl mapa;
    }
}
