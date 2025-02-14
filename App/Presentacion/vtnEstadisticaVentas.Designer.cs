namespace Presentacion
{
    partial class VtnEstadisticaVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCargarDatosVentas = new System.Windows.Forms.Button();
            this.graficaVenta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnGenerarPDF = new System.Windows.Forms.Button();
            this.btnCargarDatos2 = new System.Windows.Forms.Button();
            this.lblVerProductosVendidos = new System.Windows.Forms.Label();
            this.lblVerClientesComprado = new System.Windows.Forms.Label();
            this.lblVentasEmpleado = new System.Windows.Forms.Label();
            this.btnCargarDatos3 = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficaVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 587);
            this.label2.TabIndex = 58;
            this.label2.Text = "Estadística de las ventas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Wheat;
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.grafica;
            this.pictureBox1.Location = new System.Drawing.Point(63, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCargarDatosVentas
            // 
            this.BtnCargarDatosVentas.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnCargarDatosVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCargarDatosVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargarDatosVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarDatosVentas.Location = new System.Drawing.Point(25, 286);
            this.BtnCargarDatosVentas.Name = "BtnCargarDatosVentas";
            this.BtnCargarDatosVentas.Size = new System.Drawing.Size(279, 41);
            this.BtnCargarDatosVentas.TabIndex = 60;
            this.BtnCargarDatosVentas.Text = "Cargar datos";
            this.BtnCargarDatosVentas.UseVisualStyleBackColor = false;
            this.BtnCargarDatosVentas.Click += new System.EventHandler(this.BtnCargarDatosVentas_Click);
            // 
            // graficaVenta
            // 
            chartArea6.Name = "ChartArea1";
            this.graficaVenta.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.graficaVenta.Legends.Add(legend6);
            this.graficaVenta.Location = new System.Drawing.Point(404, 49);
            this.graficaVenta.Name = "graficaVenta";
            this.graficaVenta.Size = new System.Drawing.Size(977, 507);
            this.graficaVenta.TabIndex = 61;
            this.graficaVenta.Text = "chart1";
            // 
            // BtnGenerarPDF
            // 
            this.BtnGenerarPDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BtnGenerarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGenerarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarPDF.Location = new System.Drawing.Point(25, 518);
            this.BtnGenerarPDF.Name = "BtnGenerarPDF";
            this.BtnGenerarPDF.Size = new System.Drawing.Size(279, 41);
            this.BtnGenerarPDF.TabIndex = 67;
            this.BtnGenerarPDF.Text = "Generar PDF";
            this.BtnGenerarPDF.UseVisualStyleBackColor = false;
            this.BtnGenerarPDF.Click += new System.EventHandler(this.BtnGenerarPDF_Click);
            // 
            // btnCargarDatos2
            // 
            this.btnCargarDatos2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCargarDatos2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarDatos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDatos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarDatos2.Location = new System.Drawing.Point(25, 371);
            this.btnCargarDatos2.Name = "btnCargarDatos2";
            this.btnCargarDatos2.Size = new System.Drawing.Size(279, 41);
            this.btnCargarDatos2.TabIndex = 68;
            this.btnCargarDatos2.Text = "Cargar datos";
            this.btnCargarDatos2.UseVisualStyleBackColor = false;
            // 
            // lblVerProductosVendidos
            // 
            this.lblVerProductosVendidos.AutoSize = true;
            this.lblVerProductosVendidos.BackColor = System.Drawing.Color.Wheat;
            this.lblVerProductosVendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerProductosVendidos.Location = new System.Drawing.Point(21, 254);
            this.lblVerProductosVendidos.Name = "lblVerProductosVendidos";
            this.lblVerProductosVendidos.Size = new System.Drawing.Size(227, 20);
            this.lblVerProductosVendidos.TabIndex = 69;
            this.lblVerProductosVendidos.Text = "Ver productos mas vendidos:";
            // 
            // lblVerClientesComprado
            // 
            this.lblVerClientesComprado.AutoSize = true;
            this.lblVerClientesComprado.BackColor = System.Drawing.Color.Wheat;
            this.lblVerClientesComprado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerClientesComprado.Location = new System.Drawing.Point(21, 344);
            this.lblVerClientesComprado.Name = "lblVerClientesComprado";
            this.lblVerClientesComprado.Size = new System.Drawing.Size(224, 20);
            this.lblVerClientesComprado.TabIndex = 70;
            this.lblVerClientesComprado.Text = "Ver clientes top en compras:";
            // 
            // lblVentasEmpleado
            // 
            this.lblVentasEmpleado.AutoSize = true;
            this.lblVentasEmpleado.BackColor = System.Drawing.Color.Wheat;
            this.lblVentasEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasEmpleado.Location = new System.Drawing.Point(21, 431);
            this.lblVentasEmpleado.Name = "lblVentasEmpleado";
            this.lblVentasEmpleado.Size = new System.Drawing.Size(241, 20);
            this.lblVentasEmpleado.TabIndex = 71;
            this.lblVentasEmpleado.Text = "Ver ventas por cada empleado:";
            // 
            // btnCargarDatos3
            // 
            this.btnCargarDatos3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCargarDatos3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarDatos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDatos3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarDatos3.Location = new System.Drawing.Point(25, 457);
            this.btnCargarDatos3.Name = "btnCargarDatos3";
            this.btnCargarDatos3.Size = new System.Drawing.Size(279, 41);
            this.btnCargarDatos3.TabIndex = 72;
            this.btnCargarDatos3.Text = "Cargar datos";
            this.btnCargarDatos3.UseVisualStyleBackColor = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(401, 26);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(510, 20);
            this.lblMensaje.TabIndex = 73;
            this.lblMensaje.Text = "Antes de generar el pdf primero tiene que cargas los datos.\r\n";
            // 
            // VtnEstadisticaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1383, 587);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCargarDatos3);
            this.Controls.Add(this.lblVentasEmpleado);
            this.Controls.Add(this.lblVerClientesComprado);
            this.Controls.Add(this.lblVerProductosVendidos);
            this.Controls.Add(this.btnCargarDatos2);
            this.Controls.Add(this.BtnGenerarPDF);
            this.Controls.Add(this.graficaVenta);
            this.Controls.Add(this.BtnCargarDatosVentas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "VtnEstadisticaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver las estadísticas de los productos vendidos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficaVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCargarDatosVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficaVenta;
        private System.Windows.Forms.Button BtnGenerarPDF;
        private System.Windows.Forms.Button btnCargarDatos2;
        private System.Windows.Forms.Label lblVerProductosVendidos;
        private System.Windows.Forms.Label lblVerClientesComprado;
        private System.Windows.Forms.Label lblVentasEmpleado;
        private System.Windows.Forms.Button btnCargarDatos3;
        private System.Windows.Forms.Label lblMensaje;
    }
}