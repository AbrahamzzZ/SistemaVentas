namespace Presentacion
{
    partial class vtnReportesCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnBuscar2 = new System.Windows.Forms.Button();
            this.btnBuscar3 = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.cmb3 = new System.Windows.Forms.ComboBox();
            this.tablaReporteCompras = new System.Windows.Forms.DataGridView();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoTransportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTransportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.txtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.txtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.lblReporteCompra = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporteCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.Location = new System.Drawing.Point(829, 182);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(197, 27);
            this.txt1.TabIndex = 143;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.White;
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.Location = new System.Drawing.Point(190, 177);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(187, 33);
            this.btnExportarExcel.TabIndex = 141;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnBuscar2
            // 
            this.btnBuscar2.BackColor = System.Drawing.Color.White;
            this.btnBuscar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar2.Image = global::Presentacion.Properties.Resources.buscar;
            this.btnBuscar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar2.Location = new System.Drawing.Point(1172, 66);
            this.btnBuscar2.Name = "btnBuscar2";
            this.btnBuscar2.Size = new System.Drawing.Size(110, 31);
            this.btnBuscar2.TabIndex = 140;
            this.btnBuscar2.Text = "Buscar";
            this.btnBuscar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar2.UseVisualStyleBackColor = false;
            this.btnBuscar2.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBuscar3
            // 
            this.btnBuscar3.BackColor = System.Drawing.Color.White;
            this.btnBuscar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar3.Image = global::Presentacion.Properties.Resources.buscar;
            this.btnBuscar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar3.Location = new System.Drawing.Point(1046, 180);
            this.btnBuscar3.Name = "btnBuscar3";
            this.btnBuscar3.Size = new System.Drawing.Size(110, 31);
            this.btnBuscar3.TabIndex = 139;
            this.btnBuscar3.Text = "Buscar";
            this.btnBuscar3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar3.UseVisualStyleBackColor = false;
            this.btnBuscar3.Click += new System.EventHandler(this.btnBuscar3_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(1172, 180);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 31);
            this.btnLimpiar.TabIndex = 138;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cmb1
            // 
            this.cmb1.BackColor = System.Drawing.Color.White;
            this.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb1.FormattingEnabled = true;
            this.cmb1.Location = new System.Drawing.Point(973, 49);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(183, 28);
            this.cmb1.TabIndex = 137;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.BackColor = System.Drawing.Color.White;
            this.lblBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPor.Location = new System.Drawing.Point(462, 182);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(97, 20);
            this.lblBuscarPor.TabIndex = 136;
            this.lblBuscarPor.Text = "Buscar por:";
            // 
            // cmb3
            // 
            this.cmb3.BackColor = System.Drawing.Color.White;
            this.cmb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb3.FormattingEnabled = true;
            this.cmb3.Location = new System.Drawing.Point(576, 178);
            this.cmb3.Name = "cmb3";
            this.cmb3.Size = new System.Drawing.Size(226, 28);
            this.cmb3.TabIndex = 142;
            // 
            // tablaReporteCompras
            // 
            this.tablaReporteCompras.AllowUserToAddRows = false;
            this.tablaReporteCompras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaReporteCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaReporteCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaReporteCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaRegistro,
            this.TipoDocumento,
            this.NumeroDocumento,
            this.MontoTotal,
            this.UsuarioRegistro,
            this.DocumentoProveedor,
            this.NombreProveedor,
            this.DocumentoTransportista,
            this.NombreTransportista,
            this.CodigoProducto,
            this.NombreProducto,
            this.Categoria,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal});
            this.tablaReporteCompras.Location = new System.Drawing.Point(191, 240);
            this.tablaReporteCompras.MultiSelect = false;
            this.tablaReporteCompras.Name = "tablaReporteCompras";
            this.tablaReporteCompras.ReadOnly = true;
            this.tablaReporteCompras.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaReporteCompras.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tablaReporteCompras.RowTemplate.Height = 28;
            this.tablaReporteCompras.Size = new System.Drawing.Size(1092, 300);
            this.tablaReporteCompras.TabIndex = 135;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha registro";
            this.FechaRegistro.MinimumWidth = 6;
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 125;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.HeaderText = "Tipo documento";
            this.TipoDocumento.MinimumWidth = 6;
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Width = 135;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.HeaderText = "Numero documento";
            this.NumeroDocumento.MinimumWidth = 6;
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            this.NumeroDocumento.Width = 125;
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "Monto total";
            this.MontoTotal.MinimumWidth = 6;
            this.MontoTotal.Name = "MontoTotal";
            this.MontoTotal.ReadOnly = true;
            this.MontoTotal.Width = 125;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.HeaderText = "Usuario registro";
            this.UsuarioRegistro.MinimumWidth = 6;
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            this.UsuarioRegistro.Width = 125;
            // 
            // DocumentoProveedor
            // 
            this.DocumentoProveedor.HeaderText = "Codigo Proveedor";
            this.DocumentoProveedor.MinimumWidth = 6;
            this.DocumentoProveedor.Name = "DocumentoProveedor";
            this.DocumentoProveedor.ReadOnly = true;
            this.DocumentoProveedor.Width = 125;
            // 
            // NombreProveedor
            // 
            this.NombreProveedor.HeaderText = "Nombre Proveedor";
            this.NombreProveedor.MinimumWidth = 6;
            this.NombreProveedor.Name = "NombreProveedor";
            this.NombreProveedor.ReadOnly = true;
            this.NombreProveedor.Width = 125;
            // 
            // DocumentoTransportista
            // 
            this.DocumentoTransportista.HeaderText = "Codigo Transportista";
            this.DocumentoTransportista.MinimumWidth = 6;
            this.DocumentoTransportista.Name = "DocumentoTransportista";
            this.DocumentoTransportista.ReadOnly = true;
            this.DocumentoTransportista.Width = 125;
            // 
            // NombreTransportista
            // 
            this.NombreTransportista.HeaderText = "Nombre Transportista";
            this.NombreTransportista.MinimumWidth = 6;
            this.NombreTransportista.Name = "NombreTransportista";
            this.NombreTransportista.ReadOnly = true;
            this.NombreTransportista.Width = 125;
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "Codigo Producto";
            this.CodigoProducto.MinimumWidth = 6;
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.ReadOnly = true;
            this.CodigoProducto.Width = 125;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Nombre Producto";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            this.NombreProducto.Width = 125;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 125;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.MinimumWidth = 6;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            this.PrecioCompra.Width = 125;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Width = 125;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 125;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 125;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1138, 408);
            this.label1.TabIndex = 134;
            // 
            // lblTransportista
            // 
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.BackColor = System.Drawing.Color.White;
            this.lblTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportista.Location = new System.Drawing.Point(854, 92);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(113, 20);
            this.lblTransportista.TabIndex = 133;
            this.lblTransportista.Text = "Transportista:";
            // 
            // txtFecha2
            // 
            this.txtFecha2.CustomFormat = "dd/MM/yyyy";
            this.txtFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha2.Location = new System.Drawing.Point(639, 90);
            this.txtFecha2.Name = "txtFecha2";
            this.txtFecha2.Size = new System.Drawing.Size(200, 27);
            this.txtFecha2.TabIndex = 132;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.White;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(542, 93);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(83, 20);
            this.lblFechaFin.TabIndex = 131;
            this.lblFechaFin.Text = "Fecha fin:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.BackColor = System.Drawing.Color.White;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(190, 93);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(104, 20);
            this.lblFechaInicio.TabIndex = 130;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // txtFecha1
            // 
            this.txtFecha1.CustomFormat = "dd/MM/yyyy";
            this.txtFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha1.Location = new System.Drawing.Point(306, 90);
            this.txtFecha1.Name = "txtFecha1";
            this.txtFecha1.Size = new System.Drawing.Size(200, 27);
            this.txtFecha1.TabIndex = 128;
            // 
            // lblReporteCompra
            // 
            this.lblReporteCompra.BackColor = System.Drawing.Color.White;
            this.lblReporteCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporteCompra.Location = new System.Drawing.Point(168, 23);
            this.lblReporteCompra.Name = "lblReporteCompra";
            this.lblReporteCompra.Size = new System.Drawing.Size(1138, 111);
            this.lblReporteCompra.TabIndex = 129;
            this.lblReporteCompra.Text = "Reportes Compras";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.BackColor = System.Drawing.Color.White;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(854, 52);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(90, 20);
            this.lblProveedor.TabIndex = 144;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // cmb2
            // 
            this.cmb2.BackColor = System.Drawing.Color.White;
            this.cmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(973, 90);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(183, 28);
            this.cmb2.TabIndex = 145;
            // 
            // vtnReportesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.cmb2);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnBuscar2);
            this.Controls.Add(this.btnBuscar3);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmb1);
            this.Controls.Add(this.lblBuscarPor);
            this.Controls.Add(this.cmb3);
            this.Controls.Add(this.tablaReporteCompras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTransportista);
            this.Controls.Add(this.txtFecha2);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.txtFecha1);
            this.Controls.Add(this.lblReporteCompra);
            this.Name = "vtnReportesCompras";
            this.Text = "Ver los reportes de productos comprados";
            this.Load += new System.EventHandler(this.vtnReportesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporteCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnBuscar2;
        private System.Windows.Forms.Button btnBuscar3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cmb1;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.ComboBox cmb3;
        private System.Windows.Forms.DataGridView tablaReporteCompras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.DateTimePicker txtFecha2;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker txtFecha1;
        private System.Windows.Forms.Label lblReporteCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoTransportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreTransportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmb2;
    }
}