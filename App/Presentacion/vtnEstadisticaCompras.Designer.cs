namespace Presentacion
{
    partial class VtnEstadisticaCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.graficaCompra = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnCargarDatos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnGenerarPDF = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.LblVerProductosVendidos = new System.Windows.Forms.Label();
            this.BtnCargarDatos2 = new System.Windows.Forms.Button();
            this.BtnCargarDatos3 = new System.Windows.Forms.Button();
            this.LblVerViajeTransportista = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCargarDatos4 = new System.Windows.Forms.Button();
            this.LblComprasSucursales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graficaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // graficaCompra
            // 
            chartArea1.Name = "ChartArea1";
            this.graficaCompra.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graficaCompra.Legends.Add(legend1);
            this.graficaCompra.Location = new System.Drawing.Point(404, 49);
            this.graficaCompra.Name = "graficaCompra";
            this.graficaCompra.Size = new System.Drawing.Size(977, 507);
            this.graficaCompra.TabIndex = 65;
            this.graficaCompra.Text = "chart1";
            // 
            // BtnCargarDatos
            // 
            this.BtnCargarDatos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCargarDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarDatos.Location = new System.Drawing.Point(25, 216);
            this.BtnCargarDatos.Name = "BtnCargarDatos";
            this.BtnCargarDatos.Size = new System.Drawing.Size(279, 41);
            this.BtnCargarDatos.TabIndex = 64;
            this.BtnCargarDatos.Text = "Cargar datos";
            this.BtnCargarDatos.UseVisualStyleBackColor = false;
            this.BtnCargarDatos.Click += new System.EventHandler(this.BtnCargarDatos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Wheat;
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.grafica;
            this.pictureBox1.Location = new System.Drawing.Point(91, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 587);
            this.label2.TabIndex = 62;
            this.label2.Text = "Estadística de las compras";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnGenerarPDF
            // 
            this.BtnGenerarPDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnGenerarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGenerarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarPDF.Location = new System.Drawing.Point(25, 522);
            this.BtnGenerarPDF.Name = "BtnGenerarPDF";
            this.BtnGenerarPDF.Size = new System.Drawing.Size(279, 41);
            this.BtnGenerarPDF.TabIndex = 66;
            this.BtnGenerarPDF.Text = "Generar PDF";
            this.BtnGenerarPDF.UseVisualStyleBackColor = false;
            this.BtnGenerarPDF.Click += new System.EventHandler(this.BtnGenerarPDF_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(401, 26);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(510, 20);
            this.lblMensaje.TabIndex = 74;
            this.lblMensaje.Text = "Antes de generar el pdf primero tiene que cargas los datos.\r\n";
            // 
            // LblVerProductosVendidos
            // 
            this.LblVerProductosVendidos.AutoSize = true;
            this.LblVerProductosVendidos.BackColor = System.Drawing.Color.Wheat;
            this.LblVerProductosVendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVerProductosVendidos.Location = new System.Drawing.Point(21, 184);
            this.LblVerProductosVendidos.Name = "LblVerProductosVendidos";
            this.LblVerProductosVendidos.Size = new System.Drawing.Size(244, 20);
            this.LblVerProductosVendidos.TabIndex = 75;
            this.LblVerProductosVendidos.Text = "Ver productos mas comprados:";
            // 
            // BtnCargarDatos2
            // 
            this.BtnCargarDatos2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCargarDatos2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarDatos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarDatos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarDatos2.Location = new System.Drawing.Point(25, 301);
            this.BtnCargarDatos2.Name = "BtnCargarDatos2";
            this.BtnCargarDatos2.Size = new System.Drawing.Size(279, 41);
            this.BtnCargarDatos2.TabIndex = 76;
            this.BtnCargarDatos2.Text = "Cargar datos";
            this.BtnCargarDatos2.UseVisualStyleBackColor = false;
            this.BtnCargarDatos2.Click += new System.EventHandler(this.BtnCargarDatos2_Click);
            // 
            // BtnCargarDatos3
            // 
            this.BtnCargarDatos3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCargarDatos3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarDatos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarDatos3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarDatos3.Location = new System.Drawing.Point(25, 385);
            this.BtnCargarDatos3.Name = "BtnCargarDatos3";
            this.BtnCargarDatos3.Size = new System.Drawing.Size(279, 41);
            this.BtnCargarDatos3.TabIndex = 77;
            this.BtnCargarDatos3.Text = "Cargar datos";
            this.BtnCargarDatos3.UseVisualStyleBackColor = false;
            this.BtnCargarDatos3.Click += new System.EventHandler(this.BtnCargarDatos3_Click);
            // 
            // LblVerViajeTransportista
            // 
            this.LblVerViajeTransportista.AutoSize = true;
            this.LblVerViajeTransportista.BackColor = System.Drawing.Color.Wheat;
            this.LblVerViajeTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVerViajeTransportista.Location = new System.Drawing.Point(21, 360);
            this.LblVerViajeTransportista.Name = "LblVerViajeTransportista";
            this.LblVerViajeTransportista.Size = new System.Drawing.Size(251, 20);
            this.LblVerViajeTransportista.TabIndex = 78;
            this.LblVerViajeTransportista.Text = "Ver viajes de cada transportista:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Wheat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "Ver proveedores de preferencia:";
            // 
            // BtnCargarDatos4
            // 
            this.BtnCargarDatos4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCargarDatos4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarDatos4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarDatos4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarDatos4.Location = new System.Drawing.Point(25, 463);
            this.BtnCargarDatos4.Name = "BtnCargarDatos4";
            this.BtnCargarDatos4.Size = new System.Drawing.Size(279, 41);
            this.BtnCargarDatos4.TabIndex = 80;
            this.BtnCargarDatos4.Text = "Cargar datos";
            this.BtnCargarDatos4.UseVisualStyleBackColor = false;
            this.BtnCargarDatos4.Click += new System.EventHandler(this.BtnCargarDatos4_Click);
            // 
            // LblComprasSucursales
            // 
            this.LblComprasSucursales.AutoSize = true;
            this.LblComprasSucursales.BackColor = System.Drawing.Color.Wheat;
            this.LblComprasSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblComprasSucursales.Location = new System.Drawing.Point(21, 439);
            this.LblComprasSucursales.Name = "LblComprasSucursales";
            this.LblComprasSucursales.Size = new System.Drawing.Size(221, 20);
            this.LblComprasSucursales.TabIndex = 81;
            this.LblComprasSucursales.Text = "Ver compras por sucursales";
            // 
            // VtnEstadisticaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1383, 587);
            this.Controls.Add(this.LblComprasSucursales);
            this.Controls.Add(this.BtnCargarDatos4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblVerViajeTransportista);
            this.Controls.Add(this.BtnCargarDatos3);
            this.Controls.Add(this.BtnCargarDatos2);
            this.Controls.Add(this.LblVerProductosVendidos);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.BtnGenerarPDF);
            this.Controls.Add(this.graficaCompra);
            this.Controls.Add(this.BtnCargarDatos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "VtnEstadisticaCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.graficaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graficaCompra;
        private System.Windows.Forms.Button BtnCargarDatos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnGenerarPDF;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label LblVerProductosVendidos;
        private System.Windows.Forms.Button BtnCargarDatos2;
        private System.Windows.Forms.Button BtnCargarDatos3;
        private System.Windows.Forms.Label LblVerViajeTransportista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCargarDatos4;
        private System.Windows.Forms.Label LblComprasSucursales;
    }
}