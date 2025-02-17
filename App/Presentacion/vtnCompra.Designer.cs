namespace Presentacion
{
    partial class VtnCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VtnCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.TxtPreciVenta = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.GroupBoxPagarCompra = new System.Windows.Forms.GroupBox();
            this.BtnCrearCompra = new System.Windows.Forms.Button();
            this.TxtTotalPagar = new System.Windows.Forms.TextBox();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TablaCompras = new System.Windows.Forms.DataGridView();
            this.TxtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.GroupBoxInformacionCompra = new System.Windows.Forms.GroupBox();
            this.CmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.TxtFecha = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.GroupBoxProvedor = new System.Windows.Forms.GroupBox();
            this.TxtIdProveedor = new System.Windows.Forms.TextBox();
            this.BtnBuscarProveedor = new System.Windows.Forms.Button();
            this.TxtCedulaProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.LblCedula = new System.Windows.Forms.Label();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.BtnBuscarProducto = new System.Windows.Forms.Button();
            this.TxtIdProducto = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.GroupBoxProducto = new System.Windows.Forms.GroupBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.lblImportante = new System.Windows.Forms.Label();
            this.TxtCedulaTransportista = new System.Windows.Forms.TextBox();
            this.TxtNombresTransportista = new System.Windows.Forms.TextBox();
            this.LblCedulaTransportista = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBoxTransportista = new System.Windows.Forms.GroupBox();
            this.TxtIdTransportista = new System.Windows.Forms.TextBox();
            this.BtnBuscarTransportista = new System.Windows.Forms.Button();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.LblRegistrarCompra = new System.Windows.Forms.Label();
            this.TxtNombresProveedor = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GroupBoxSucursal = new System.Windows.Forms.GroupBox();
            this.TxtSucursal = new System.Windows.Forms.TextBox();
            this.LblSucursal = new System.Windows.Forms.Label();
            this.BtnModalSucursal = new System.Windows.Forms.Button();
            this.TxtIdSucursal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            this.GroupBoxPagarCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCompras)).BeginInit();
            this.GroupBoxInformacionCompra.SuspendLayout();
            this.GroupBoxProvedor.SuspendLayout();
            this.GroupBoxProducto.SuspendLayout();
            this.GroupBoxTransportista.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.GroupBoxSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // NudCantidad
            // 
            this.NudCantidad.Location = new System.Drawing.Point(932, 65);
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(101, 27);
            this.NudCantidad.TabIndex = 112;
            // 
            // TxtPreciVenta
            // 
            this.TxtPreciVenta.BackColor = System.Drawing.Color.LightGray;
            this.TxtPreciVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPreciVenta.Location = new System.Drawing.Point(785, 65);
            this.TxtPreciVenta.Name = "TxtPreciVenta";
            this.TxtPreciVenta.Size = new System.Drawing.Size(96, 27);
            this.TxtPreciVenta.TabIndex = 111;
            this.TxtPreciVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPreciVenta_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(932, 40);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(70, 18);
            this.lblCantidad.TabIndex = 109;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.Location = new System.Drawing.Point(785, 40);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(96, 18);
            this.lblPrecioVenta.TabIndex = 108;
            this.lblPrecioVenta.Text = "Precio Venta:";
            // 
            // GroupBoxPagarCompra
            // 
            this.GroupBoxPagarCompra.BackColor = System.Drawing.Color.White;
            this.GroupBoxPagarCompra.Controls.Add(this.BtnCrearCompra);
            this.GroupBoxPagarCompra.Controls.Add(this.TxtTotalPagar);
            this.GroupBoxPagarCompra.Controls.Add(this.lblTotalPagar);
            this.GroupBoxPagarCompra.Controls.Add(this.BtnAgregar);
            this.GroupBoxPagarCompra.Location = new System.Drawing.Point(974, 475);
            this.GroupBoxPagarCompra.Name = "GroupBoxPagarCompra";
            this.GroupBoxPagarCompra.Size = new System.Drawing.Size(186, 205);
            this.GroupBoxPagarCompra.TabIndex = 121;
            this.GroupBoxPagarCompra.TabStop = false;
            // 
            // BtnCrearCompra
            // 
            this.BtnCrearCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCrearCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearCompra.Location = new System.Drawing.Point(16, 152);
            this.BtnCrearCompra.Name = "BtnCrearCompra";
            this.BtnCrearCompra.Size = new System.Drawing.Size(154, 36);
            this.BtnCrearCompra.TabIndex = 112;
            this.BtnCrearCompra.Text = "Crear Compra";
            this.BtnCrearCompra.UseVisualStyleBackColor = true;
            this.BtnCrearCompra.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // TxtTotalPagar
            // 
            this.TxtTotalPagar.BackColor = System.Drawing.Color.LightGray;
            this.TxtTotalPagar.Location = new System.Drawing.Point(19, 120);
            this.TxtTotalPagar.Name = "TxtTotalPagar";
            this.TxtTotalPagar.ReadOnly = true;
            this.TxtTotalPagar.Size = new System.Drawing.Size(146, 22);
            this.TxtTotalPagar.TabIndex = 111;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(16, 99);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(98, 18);
            this.lblTotalPagar.TabIndex = 106;
            this.lblTotalPagar.Text = "Total a pagar:";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregar.Image")));
            this.BtnAgregar.Location = new System.Drawing.Point(19, 21);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(146, 70);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TablaCompras
            // 
            this.TablaCompras.AllowUserToAddRows = false;
            this.TablaCompras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.TablaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Producto,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal,
            this.btnEliminar});
            this.TablaCompras.Location = new System.Drawing.Point(35, 484);
            this.TablaCompras.MultiSelect = false;
            this.TablaCompras.Name = "TablaCompras";
            this.TablaCompras.ReadOnly = true;
            this.TablaCompras.RowHeadersWidth = 51;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.TablaCompras.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.TablaCompras.RowTemplate.Height = 28;
            this.TablaCompras.Size = new System.Drawing.Size(903, 196);
            this.TablaCompras.TabIndex = 122;
            this.TablaCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaCompras_CellContentClick);
            this.TablaCompras.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TablaCompras_CellPainting);
            // 
            // TxtPrecioCompra
            // 
            this.TxtPrecioCompra.BackColor = System.Drawing.Color.LightGray;
            this.TxtPrecioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioCompra.Location = new System.Drawing.Point(615, 65);
            this.TxtPrecioCompra.Name = "TxtPrecioCompra";
            this.TxtPrecioCompra.Size = new System.Drawing.Size(114, 27);
            this.TxtPrecioCompra.TabIndex = 110;
            this.TxtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioCompra_KeyPress);
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCompra.Location = new System.Drawing.Point(615, 40);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(113, 18);
            this.lblPrecioCompra.TabIndex = 107;
            this.lblPrecioCompra.Text = "Precio Compra:";
            // 
            // GroupBoxInformacionCompra
            // 
            this.GroupBoxInformacionCompra.BackColor = System.Drawing.Color.White;
            this.GroupBoxInformacionCompra.Controls.Add(this.CmbTipoDocumento);
            this.GroupBoxInformacionCompra.Controls.Add(this.TxtFecha);
            this.GroupBoxInformacionCompra.Controls.Add(this.lblTipoDocumento);
            this.GroupBoxInformacionCompra.Controls.Add(this.lblFecha);
            this.GroupBoxInformacionCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxInformacionCompra.Location = new System.Drawing.Point(35, 72);
            this.GroupBoxInformacionCompra.Name = "GroupBoxInformacionCompra";
            this.GroupBoxInformacionCompra.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxInformacionCompra.TabIndex = 118;
            this.GroupBoxInformacionCompra.TabStop = false;
            this.GroupBoxInformacionCompra.Text = "Información Compra";
            // 
            // CmbTipoDocumento
            // 
            this.CmbTipoDocumento.BackColor = System.Drawing.Color.White;
            this.CmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoDocumento.FormattingEnabled = true;
            this.CmbTipoDocumento.Location = new System.Drawing.Point(200, 68);
            this.CmbTipoDocumento.Name = "CmbTipoDocumento";
            this.CmbTipoDocumento.Size = new System.Drawing.Size(250, 28);
            this.CmbTipoDocumento.TabIndex = 99;
            // 
            // TxtFecha
            // 
            this.TxtFecha.BackColor = System.Drawing.Color.LightGray;
            this.TxtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFecha.Location = new System.Drawing.Point(200, 31);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.ReadOnly = true;
            this.TxtFecha.Size = new System.Drawing.Size(250, 27);
            this.TxtFecha.TabIndex = 2;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDocumento.Location = new System.Drawing.Point(17, 67);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(140, 18);
            this.lblTipoDocumento.TabIndex = 1;
            this.lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(17, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(53, 18);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // GroupBoxProvedor
            // 
            this.GroupBoxProvedor.BackColor = System.Drawing.Color.White;
            this.GroupBoxProvedor.Controls.Add(this.TxtIdProveedor);
            this.GroupBoxProvedor.Controls.Add(this.TxtNombresProveedor);
            this.GroupBoxProvedor.Controls.Add(this.BtnBuscarProveedor);
            this.GroupBoxProvedor.Controls.Add(this.TxtCedulaProveedor);
            this.GroupBoxProvedor.Controls.Add(this.lblNombreProveedor);
            this.GroupBoxProvedor.Controls.Add(this.LblCedula);
            this.GroupBoxProvedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProvedor.Location = new System.Drawing.Point(650, 72);
            this.GroupBoxProvedor.Name = "GroupBoxProvedor";
            this.GroupBoxProvedor.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxProvedor.TabIndex = 119;
            this.GroupBoxProvedor.TabStop = false;
            this.GroupBoxProvedor.Text = "Información Proveedor";
            // 
            // TxtIdProveedor
            // 
            this.TxtIdProveedor.BackColor = System.Drawing.Color.LightGray;
            this.TxtIdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdProveedor.Location = new System.Drawing.Point(440, 68);
            this.TxtIdProveedor.Name = "TxtIdProveedor";
            this.TxtIdProveedor.ReadOnly = true;
            this.TxtIdProveedor.Size = new System.Drawing.Size(37, 27);
            this.TxtIdProveedor.TabIndex = 102;
            // 
            // BtnBuscarProveedor
            // 
            this.BtnBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarProveedor.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscarProveedor.Location = new System.Drawing.Point(440, 31);
            this.BtnBuscarProveedor.Name = "BtnBuscarProveedor";
            this.BtnBuscarProveedor.Size = new System.Drawing.Size(38, 31);
            this.BtnBuscarProveedor.TabIndex = 100;
            this.BtnBuscarProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscarProveedor.UseVisualStyleBackColor = true;
            this.BtnBuscarProveedor.Click += new System.EventHandler(this.BtnBuscarProveedor_Click);
            // 
            // TxtCedulaProveedor
            // 
            this.TxtCedulaProveedor.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaProveedor.Location = new System.Drawing.Point(185, 31);
            this.TxtCedulaProveedor.Name = "TxtCedulaProveedor";
            this.TxtCedulaProveedor.ReadOnly = true;
            this.TxtCedulaProveedor.Size = new System.Drawing.Size(220, 27);
            this.TxtCedulaProveedor.TabIndex = 2;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProveedor.Location = new System.Drawing.Point(17, 73);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(139, 18);
            this.lblNombreProveedor.TabIndex = 1;
            this.lblNombreProveedor.Text = "Nombre Proveedor:";
            // 
            // LblCedula
            // 
            this.LblCedula.AutoSize = true;
            this.LblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedula.Location = new System.Drawing.Point(17, 35);
            this.LblCedula.Name = "LblCedula";
            this.LblCedula.Size = new System.Drawing.Size(131, 18);
            this.LblCedula.TabIndex = 0;
            this.LblCedula.Text = "Cédula Proveedor:";
            // 
            // TxtProducto
            // 
            this.TxtProducto.BackColor = System.Drawing.Color.LightGray;
            this.TxtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProducto.Location = new System.Drawing.Point(340, 65);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.Size = new System.Drawing.Size(227, 27);
            this.TxtProducto.TabIndex = 106;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(340, 40);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(73, 18);
            this.lblProducto.TabIndex = 105;
            this.lblProducto.Text = "Producto:";
            // 
            // BtnBuscarProducto
            // 
            this.BtnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarProducto.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscarProducto.Location = new System.Drawing.Point(270, 65);
            this.BtnBuscarProducto.Name = "BtnBuscarProducto";
            this.BtnBuscarProducto.Size = new System.Drawing.Size(38, 31);
            this.BtnBuscarProducto.TabIndex = 104;
            this.BtnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscarProducto.UseVisualStyleBackColor = true;
            this.BtnBuscarProducto.Click += new System.EventHandler(this.BtnBuscarProducto_Click);
            // 
            // TxtIdProducto
            // 
            this.TxtIdProducto.BackColor = System.Drawing.Color.LightGray;
            this.TxtIdProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdProducto.Location = new System.Drawing.Point(210, 31);
            this.TxtIdProducto.Name = "TxtIdProducto";
            this.TxtIdProducto.ReadOnly = true;
            this.TxtIdProducto.Size = new System.Drawing.Size(37, 27);
            this.TxtIdProducto.TabIndex = 103;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.TxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.Location = new System.Drawing.Point(20, 65);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(227, 27);
            this.TxtCodigo.TabIndex = 2;
            this.TxtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoProducto_KeyDown);
            // 
            // lblCodigoProducto
            // 
            this.lblCodigoProducto.AutoSize = true;
            this.lblCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProducto.Location = new System.Drawing.Point(17, 35);
            this.lblCodigoProducto.Name = "lblCodigoProducto";
            this.lblCodigoProducto.Size = new System.Drawing.Size(125, 18);
            this.lblCodigoProducto.TabIndex = 0;
            this.lblCodigoProducto.Text = "Código Producto:";
            // 
            // GroupBoxProducto
            // 
            this.GroupBoxProducto.BackColor = System.Drawing.Color.White;
            this.GroupBoxProducto.Controls.Add(this.BtnLimpiar);
            this.GroupBoxProducto.Controls.Add(this.NudCantidad);
            this.GroupBoxProducto.Controls.Add(this.TxtPreciVenta);
            this.GroupBoxProducto.Controls.Add(this.TxtPrecioCompra);
            this.GroupBoxProducto.Controls.Add(this.lblCantidad);
            this.GroupBoxProducto.Controls.Add(this.lblPrecioVenta);
            this.GroupBoxProducto.Controls.Add(this.lblPrecioCompra);
            this.GroupBoxProducto.Controls.Add(this.TxtProducto);
            this.GroupBoxProducto.Controls.Add(this.lblProducto);
            this.GroupBoxProducto.Controls.Add(this.BtnBuscarProducto);
            this.GroupBoxProducto.Controls.Add(this.TxtIdProducto);
            this.GroupBoxProducto.Controls.Add(this.TxtCodigo);
            this.GroupBoxProducto.Controls.Add(this.lblCodigoProducto);
            this.GroupBoxProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProducto.Location = new System.Drawing.Point(35, 344);
            this.GroupBoxProducto.Name = "GroupBoxProducto";
            this.GroupBoxProducto.Size = new System.Drawing.Size(1125, 115);
            this.GroupBoxProducto.TabIndex = 120;
            this.GroupBoxProducto.TabStop = false;
            this.GroupBoxProducto.Text = "Información Producto";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.BtnLimpiar.Location = new System.Drawing.Point(1067, 61);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(38, 30);
            this.BtnLimpiar.TabIndex = 114;
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // lblImportante
            // 
            this.lblImportante.BackColor = System.Drawing.Color.White;
            this.lblImportante.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportante.Location = new System.Drawing.Point(322, 8);
            this.lblImportante.Name = "lblImportante";
            this.lblImportante.Size = new System.Drawing.Size(867, 31);
            this.lblImportante.TabIndex = 127;
            this.lblImportante.Text = "IMPORTANTE Antes de ir a otro menú por favor verifique que la tabla Compra se enc" +
    "uentre totalmente vacía.\r\n\r\n";
            // 
            // TxtCedulaTransportista
            // 
            this.TxtCedulaTransportista.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaTransportista.Location = new System.Drawing.Point(185, 31);
            this.TxtCedulaTransportista.Name = "TxtCedulaTransportista";
            this.TxtCedulaTransportista.ReadOnly = true;
            this.TxtCedulaTransportista.Size = new System.Drawing.Size(220, 27);
            this.TxtCedulaTransportista.TabIndex = 113;
            // 
            // TxtNombresTransportista
            // 
            this.TxtNombresTransportista.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresTransportista.Location = new System.Drawing.Point(185, 68);
            this.TxtNombresTransportista.Name = "TxtNombresTransportista";
            this.TxtNombresTransportista.ReadOnly = true;
            this.TxtNombresTransportista.Size = new System.Drawing.Size(220, 27);
            this.TxtNombresTransportista.TabIndex = 114;
            // 
            // LblCedulaTransportista
            // 
            this.LblCedulaTransportista.AutoSize = true;
            this.LblCedulaTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedulaTransportista.Location = new System.Drawing.Point(17, 35);
            this.LblCedulaTransportista.Name = "LblCedulaTransportista";
            this.LblCedulaTransportista.Size = new System.Drawing.Size(149, 18);
            this.LblCedulaTransportista.TabIndex = 115;
            this.LblCedulaTransportista.Text = "Cédula Transportista:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 18);
            this.label2.TabIndex = 116;
            this.label2.Text = "Nombre Transportista:";
            // 
            // GroupBoxTransportista
            // 
            this.GroupBoxTransportista.BackColor = System.Drawing.Color.White;
            this.GroupBoxTransportista.Controls.Add(this.TxtIdTransportista);
            this.GroupBoxTransportista.Controls.Add(this.BtnBuscarTransportista);
            this.GroupBoxTransportista.Controls.Add(this.label2);
            this.GroupBoxTransportista.Controls.Add(this.TxtCedulaTransportista);
            this.GroupBoxTransportista.Controls.Add(this.TxtNombresTransportista);
            this.GroupBoxTransportista.Controls.Add(this.LblCedulaTransportista);
            this.GroupBoxTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxTransportista.Location = new System.Drawing.Point(650, 210);
            this.GroupBoxTransportista.Name = "GroupBoxTransportista";
            this.GroupBoxTransportista.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxTransportista.TabIndex = 128;
            this.GroupBoxTransportista.TabStop = false;
            this.GroupBoxTransportista.Text = "Información Transportista";
            // 
            // TxtIdTransportista
            // 
            this.TxtIdTransportista.BackColor = System.Drawing.Color.LightGray;
            this.TxtIdTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdTransportista.Location = new System.Drawing.Point(440, 68);
            this.TxtIdTransportista.Name = "TxtIdTransportista";
            this.TxtIdTransportista.ReadOnly = true;
            this.TxtIdTransportista.Size = new System.Drawing.Size(37, 27);
            this.TxtIdTransportista.TabIndex = 118;
            // 
            // BtnBuscarTransportista
            // 
            this.BtnBuscarTransportista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarTransportista.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscarTransportista.Location = new System.Drawing.Point(440, 31);
            this.BtnBuscarTransportista.Name = "BtnBuscarTransportista";
            this.BtnBuscarTransportista.Size = new System.Drawing.Size(38, 31);
            this.BtnBuscarTransportista.TabIndex = 117;
            this.BtnBuscarTransportista.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscarTransportista.UseVisualStyleBackColor = true;
            this.BtnBuscarTransportista.Click += new System.EventHandler(this.BtnBuscarTransportista_Click);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.AutoScroll = true;
            this.PanelPrincipal.BackColor = System.Drawing.Color.White;
            this.PanelPrincipal.Controls.Add(this.GroupBoxSucursal);
            this.PanelPrincipal.Controls.Add(this.LblRegistrarCompra);
            this.PanelPrincipal.Controls.Add(this.GroupBoxInformacionCompra);
            this.PanelPrincipal.Controls.Add(this.GroupBoxProducto);
            this.PanelPrincipal.Controls.Add(this.GroupBoxPagarCompra);
            this.PanelPrincipal.Controls.Add(this.GroupBoxTransportista);
            this.PanelPrincipal.Controls.Add(this.GroupBoxProvedor);
            this.PanelPrincipal.Controls.Add(this.lblImportante);
            this.PanelPrincipal.Controls.Add(this.TablaCompras);
            this.PanelPrincipal.Location = new System.Drawing.Point(131, 23);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1212, 540);
            this.PanelPrincipal.TabIndex = 129;
            // 
            // LblRegistrarCompra
            // 
            this.LblRegistrarCompra.AutoSize = true;
            this.LblRegistrarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistrarCompra.Location = new System.Drawing.Point(3, 2);
            this.LblRegistrarCompra.Name = "LblRegistrarCompra";
            this.LblRegistrarCompra.Size = new System.Drawing.Size(252, 32);
            this.LblRegistrarCompra.TabIndex = 131;
            this.LblRegistrarCompra.Text = "Registrar Compra";
            // 
            // TxtNombresProveedor
            // 
            this.TxtNombresProveedor.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresProveedor.Location = new System.Drawing.Point(185, 68);
            this.TxtNombresProveedor.Name = "TxtNombresProveedor";
            this.TxtNombresProveedor.ReadOnly = true;
            this.TxtNombresProveedor.Size = new System.Drawing.Size(220, 27);
            this.TxtNombresProveedor.TabIndex = 101;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 140;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.MinimumWidth = 6;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            this.PrecioCompra.Width = 135;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Visible = false;
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
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 125;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.MinimumWidth = 6;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 30;
            // 
            // GroupBoxSucursal
            // 
            this.GroupBoxSucursal.BackColor = System.Drawing.Color.White;
            this.GroupBoxSucursal.Controls.Add(this.TxtIdSucursal);
            this.GroupBoxSucursal.Controls.Add(this.BtnModalSucursal);
            this.GroupBoxSucursal.Controls.Add(this.TxtSucursal);
            this.GroupBoxSucursal.Controls.Add(this.LblSucursal);
            this.GroupBoxSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxSucursal.Location = new System.Drawing.Point(35, 210);
            this.GroupBoxSucursal.Name = "GroupBoxSucursal";
            this.GroupBoxSucursal.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxSucursal.TabIndex = 132;
            this.GroupBoxSucursal.TabStop = false;
            this.GroupBoxSucursal.Text = "Información Sucursal";
            // 
            // TxtSucursal
            // 
            this.TxtSucursal.BackColor = System.Drawing.Color.LightGray;
            this.TxtSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSucursal.Location = new System.Drawing.Point(20, 56);
            this.TxtSucursal.Name = "TxtSucursal";
            this.TxtSucursal.ReadOnly = true;
            this.TxtSucursal.Size = new System.Drawing.Size(310, 27);
            this.TxtSucursal.TabIndex = 113;
            // 
            // LblSucursal
            // 
            this.LblSucursal.AutoSize = true;
            this.LblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSucursal.Location = new System.Drawing.Point(22, 34);
            this.LblSucursal.Name = "LblSucursal";
            this.LblSucursal.Size = new System.Drawing.Size(70, 18);
            this.LblSucursal.TabIndex = 115;
            this.LblSucursal.Text = "Sucursal:";
            // 
            // BtnModalSucursal
            // 
            this.BtnModalSucursal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnModalSucursal.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnModalSucursal.Location = new System.Drawing.Point(441, 56);
            this.BtnModalSucursal.Name = "BtnModalSucursal";
            this.BtnModalSucursal.Size = new System.Drawing.Size(38, 31);
            this.BtnModalSucursal.TabIndex = 116;
            this.BtnModalSucursal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnModalSucursal.UseVisualStyleBackColor = true;
            this.BtnModalSucursal.Click += new System.EventHandler(this.BtnModalSucursal_Click);
            // 
            // TxtIdSucursal
            // 
            this.TxtIdSucursal.BackColor = System.Drawing.Color.LightGray;
            this.TxtIdSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdSucursal.Location = new System.Drawing.Point(373, 56);
            this.TxtIdSucursal.Name = "TxtIdSucursal";
            this.TxtIdSucursal.ReadOnly = true;
            this.TxtIdSucursal.Size = new System.Drawing.Size(37, 27);
            this.TxtIdSucursal.TabIndex = 119;
            // 
            // VtnCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.PanelPrincipal);
            this.Name = "VtnCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar compras";
            this.Load += new System.EventHandler(this.VtnCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            this.GroupBoxPagarCompra.ResumeLayout(false);
            this.GroupBoxPagarCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCompras)).EndInit();
            this.GroupBoxInformacionCompra.ResumeLayout(false);
            this.GroupBoxInformacionCompra.PerformLayout();
            this.GroupBoxProvedor.ResumeLayout(false);
            this.GroupBoxProvedor.PerformLayout();
            this.GroupBoxProducto.ResumeLayout(false);
            this.GroupBoxProducto.PerformLayout();
            this.GroupBoxTransportista.ResumeLayout(false);
            this.GroupBoxTransportista.PerformLayout();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.GroupBoxSucursal.ResumeLayout(false);
            this.GroupBoxSucursal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.TextBox TxtPreciVenta;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.GroupBox GroupBoxPagarCompra;
        private System.Windows.Forms.Button BtnCrearCompra;
        private System.Windows.Forms.TextBox TxtTotalPagar;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.DataGridView TablaCompras;
        private System.Windows.Forms.TextBox TxtPrecioCompra;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.GroupBox GroupBoxInformacionCompra;
        private System.Windows.Forms.ComboBox CmbTipoDocumento;
        private System.Windows.Forms.TextBox TxtFecha;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox GroupBoxProvedor;
        private System.Windows.Forms.TextBox TxtIdProveedor;
        private System.Windows.Forms.Button BtnBuscarProveedor;
        private System.Windows.Forms.TextBox TxtCedulaProveedor;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.Label LblCedula;
        private System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button BtnBuscarProducto;
        private System.Windows.Forms.TextBox TxtIdProducto;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.GroupBox GroupBoxProducto;
        private System.Windows.Forms.Label lblImportante;
        private System.Windows.Forms.TextBox TxtNombresTransportista;
        private System.Windows.Forms.TextBox TxtCedulaTransportista;
        private System.Windows.Forms.Label LblCedulaTransportista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GroupBoxTransportista;
        private System.Windows.Forms.Button BtnBuscarTransportista;
        private System.Windows.Forms.TextBox TxtIdTransportista;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Label LblRegistrarCompra;
        private System.Windows.Forms.TextBox TxtNombresProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.GroupBox GroupBoxSucursal;
        private System.Windows.Forms.Button BtnModalSucursal;
        private System.Windows.Forms.TextBox TxtSucursal;
        private System.Windows.Forms.Label LblSucursal;
        private System.Windows.Forms.TextBox TxtIdSucursal;
    }
}