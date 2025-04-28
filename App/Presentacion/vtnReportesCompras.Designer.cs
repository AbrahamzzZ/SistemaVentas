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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.BtnGenerarExcel = new System.Windows.Forms.Button();
            this.BtnBuscarProveedorTransportista = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.CmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.CmbBuscar = new System.Windows.Forms.ComboBox();
            this.tablaReporteCompras = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.TxtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.TxtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblReporteCompra = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.CmbTransportista = new System.Windows.Forms.ComboBox();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSurcusal = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporteCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(829, 182);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(197, 27);
            this.TxtBuscar.TabIndex = 143;
            // 
            // BtnGenerarExcel
            // 
            this.BtnGenerarExcel.BackColor = System.Drawing.Color.White;
            this.BtnGenerarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGenerarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarExcel.Location = new System.Drawing.Point(190, 177);
            this.BtnGenerarExcel.Name = "BtnGenerarExcel";
            this.BtnGenerarExcel.Size = new System.Drawing.Size(187, 33);
            this.BtnGenerarExcel.TabIndex = 141;
            this.BtnGenerarExcel.Text = "Generar Excel";
            this.BtnGenerarExcel.UseVisualStyleBackColor = false;
            this.BtnGenerarExcel.Click += new System.EventHandler(this.BtnGenerarExcel_Click);
            // 
            // BtnBuscarProveedorTransportista
            // 
            this.BtnBuscarProveedorTransportista.BackColor = System.Drawing.Color.White;
            this.BtnBuscarProveedorTransportista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarProveedorTransportista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarProveedorTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarProveedorTransportista.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscarProveedorTransportista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscarProveedorTransportista.Location = new System.Drawing.Point(1172, 66);
            this.BtnBuscarProveedorTransportista.Name = "BtnBuscarProveedorTransportista";
            this.BtnBuscarProveedorTransportista.Size = new System.Drawing.Size(110, 31);
            this.BtnBuscarProveedorTransportista.TabIndex = 140;
            this.BtnBuscarProveedorTransportista.Text = "Buscar";
            this.BtnBuscarProveedorTransportista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBuscarProveedorTransportista.UseVisualStyleBackColor = false;
            this.BtnBuscarProveedorTransportista.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.White;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(1046, 180);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(110, 31);
            this.BtnBuscar.TabIndex = 139;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click_1);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.White;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(1172, 180);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(110, 31);
            this.BtnLimpiar.TabIndex = 138;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // CmbProveedor
            // 
            this.CmbProveedor.BackColor = System.Drawing.Color.White;
            this.CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProveedor.FormattingEnabled = true;
            this.CmbProveedor.Location = new System.Drawing.Point(973, 49);
            this.CmbProveedor.Name = "CmbProveedor";
            this.CmbProveedor.Size = new System.Drawing.Size(183, 28);
            this.CmbProveedor.TabIndex = 137;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.BackColor = System.Drawing.Color.White;
            this.lblBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPor.Location = new System.Drawing.Point(462, 184);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(97, 20);
            this.lblBuscarPor.TabIndex = 136;
            this.lblBuscarPor.Text = "Buscar por:";
            // 
            // CmbBuscar
            // 
            this.CmbBuscar.BackColor = System.Drawing.Color.White;
            this.CmbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBuscar.FormattingEnabled = true;
            this.CmbBuscar.Location = new System.Drawing.Point(576, 181);
            this.CmbBuscar.Name = "CmbBuscar";
            this.CmbBuscar.Size = new System.Drawing.Size(226, 28);
            this.CmbBuscar.TabIndex = 142;
            // 
            // tablaReporteCompras
            // 
            this.tablaReporteCompras.AllowUserToAddRows = false;
            this.tablaReporteCompras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaReporteCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaReporteCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaReporteCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaRegistro,
            this.NumeroDocumento,
            this.TipoDocumento,
            this.MontoTotal,
            this.NombreSurcusal,
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaReporteCompras.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaReporteCompras.RowTemplate.Height = 28;
            this.tablaReporteCompras.Size = new System.Drawing.Size(1092, 300);
            this.tablaReporteCompras.TabIndex = 135;
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
            this.lblTransportista.Location = new System.Drawing.Point(842, 92);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(113, 20);
            this.lblTransportista.TabIndex = 133;
            this.lblTransportista.Text = "Transportista:";
            // 
            // TxtFechaFin
            // 
            this.TxtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.TxtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtFechaFin.Location = new System.Drawing.Point(620, 90);
            this.TxtFechaFin.Name = "TxtFechaFin";
            this.TxtFechaFin.Size = new System.Drawing.Size(200, 27);
            this.TxtFechaFin.TabIndex = 132;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.White;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(526, 93);
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
            // TxtFechaInicio
            // 
            this.TxtFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.TxtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TxtFechaInicio.Location = new System.Drawing.Point(306, 90);
            this.TxtFechaInicio.Name = "TxtFechaInicio";
            this.TxtFechaInicio.Size = new System.Drawing.Size(200, 27);
            this.TxtFechaInicio.TabIndex = 128;
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
            this.lblProveedor.Location = new System.Drawing.Point(842, 52);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(90, 20);
            this.lblProveedor.TabIndex = 144;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // CmbTransportista
            // 
            this.CmbTransportista.BackColor = System.Drawing.Color.White;
            this.CmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTransportista.FormattingEnabled = true;
            this.CmbTransportista.Location = new System.Drawing.Point(973, 90);
            this.CmbTransportista.Name = "CmbTransportista";
            this.CmbTransportista.Size = new System.Drawing.Size(183, 28);
            this.CmbTransportista.TabIndex = 145;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha registro";
            this.FechaRegistro.MinimumWidth = 6;
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Width = 125;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.HeaderText = "Numero documento";
            this.NumeroDocumento.MinimumWidth = 6;
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            this.NumeroDocumento.Width = 125;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.HeaderText = "Tipo documento";
            this.TipoDocumento.MinimumWidth = 6;
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Width = 135;
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "Monto total";
            this.MontoTotal.MinimumWidth = 6;
            this.MontoTotal.Name = "MontoTotal";
            this.MontoTotal.ReadOnly = true;
            this.MontoTotal.Width = 125;
            // 
            // NombreSurcusal
            // 
            this.NombreSurcusal.HeaderText = "Sucursal";
            this.NombreSurcusal.MinimumWidth = 6;
            this.NombreSurcusal.Name = "NombreSurcusal";
            this.NombreSurcusal.ReadOnly = true;
            this.NombreSurcusal.Width = 200;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.HeaderText = "Usuario registro";
            this.UsuarioRegistro.MinimumWidth = 6;
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            this.UsuarioRegistro.Width = 180;
            // 
            // DocumentoProveedor
            // 
            this.DocumentoProveedor.HeaderText = "Codigo Proveedor";
            this.DocumentoProveedor.MinimumWidth = 6;
            this.DocumentoProveedor.Name = "DocumentoProveedor";
            this.DocumentoProveedor.ReadOnly = true;
            this.DocumentoProveedor.Width = 140;
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
            this.DocumentoTransportista.Width = 140;
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
            // vtnReportesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.CmbTransportista);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.BtnGenerarExcel);
            this.Controls.Add(this.BtnBuscarProveedorTransportista);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.CmbProveedor);
            this.Controls.Add(this.lblBuscarPor);
            this.Controls.Add(this.CmbBuscar);
            this.Controls.Add(this.tablaReporteCompras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTransportista);
            this.Controls.Add(this.TxtFechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.TxtFechaInicio);
            this.Controls.Add(this.lblReporteCompra);
            this.Name = "vtnReportesCompras";
            this.Text = "Ver los reportes de productos comprados";
            this.Load += new System.EventHandler(this.VtnReportesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporteCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Button BtnGenerarExcel;
        private System.Windows.Forms.Button BtnBuscarProveedorTransportista;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.ComboBox CmbProveedor;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.ComboBox CmbBuscar;
        private System.Windows.Forms.DataGridView tablaReporteCompras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.DateTimePicker TxtFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker TxtFechaInicio;
        private System.Windows.Forms.Label lblReporteCompra;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox CmbTransportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSurcusal;
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
    }
}