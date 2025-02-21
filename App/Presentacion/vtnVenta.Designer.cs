namespace Presentacion
{
    partial class VtnVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VtnVenta));
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TablaVentas = new System.Windows.Forms.DataGridView();
            this.LblCedula = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.TxtCedulaCliente = new System.Windows.Forms.TextBox();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.TxtNombresCliente = new System.Windows.Forms.TextBox();
            this.TxtIdCliente = new System.Windows.Forms.TextBox();
            this.GroupBoxCliente = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.TxtFecha = new System.Windows.Forms.TextBox();
            this.CmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.GroupBoxInformacionVenta = new System.Windows.Forms.GroupBox();
            this.GroupBoxProducto = new System.Windows.Forms.GroupBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.BtnBuscarProducto = new System.Windows.Forms.Button();
            this.TxtIdProducto = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.BtnCrearVenta = new System.Windows.Forms.Button();
            this.lblPagaCon = new System.Windows.Forms.Label();
            this.TxtPagaCon = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.TxtCambio = new System.Windows.Forms.TextBox();
            this.TxtTotalPagar = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.TxtTotalDescuento = new System.Windows.Forms.TextBox();
            this.lblOferta = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblPorcentaje = new System.Windows.Forms.Label();
            this.lblImportante = new System.Windows.Forms.Label();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.GroupBoxOferta = new System.Windows.Forms.GroupBox();
            this.TxtDescuentoOferta = new System.Windows.Forms.TextBox();
            this.BtnModalOferta = new System.Windows.Forms.Button();
            this.TxtNombreOferta = new System.Windows.Forms.TextBox();
            this.LblRegistrarVenta = new System.Windows.Forms.Label();
            this.GroupBoxSucursal = new System.Windows.Forms.GroupBox();
            this.TxtIdSucursal = new System.Windows.Forms.TextBox();
            this.BtnModalSucursal = new System.Windows.Forms.Button();
            this.TxtSucursal = new System.Windows.Forms.TextBox();
            this.LblSucursal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaVentas)).BeginInit();
            this.GroupBoxCliente.SuspendLayout();
            this.GroupBoxInformacionVenta.SuspendLayout();
            this.GroupBoxProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.GroupBoxOferta.SuspendLayout();
            this.GroupBoxSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.MinimumWidth = 6;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 30;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 125;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.MinimumWidth = 6;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 125;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 80;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 80;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 125;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "Id Producto";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 125;
            // 
            // TablaVentas
            // 
            this.TablaVentas.AllowUserToAddRows = false;
            this.TablaVentas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.SubTotal,
            this.Descuento,
            this.btnEliminar});
            this.TablaVentas.Location = new System.Drawing.Point(35, 484);
            this.TablaVentas.MultiSelect = false;
            this.TablaVentas.Name = "TablaVentas";
            this.TablaVentas.ReadOnly = true;
            this.TablaVentas.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TablaVentas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaVentas.RowTemplate.Height = 28;
            this.TablaVentas.Size = new System.Drawing.Size(797, 196);
            this.TablaVentas.TabIndex = 123;
            this.TablaVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaVentas_CellContentClick);
            this.TablaVentas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TablaVentas_CellPainting);
            // 
            // LblCedula
            // 
            this.LblCedula.AutoSize = true;
            this.LblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedula.Location = new System.Drawing.Point(17, 35);
            this.LblCedula.Name = "LblCedula";
            this.LblCedula.Size = new System.Drawing.Size(107, 18);
            this.LblCedula.TabIndex = 0;
            this.LblCedula.Text = "Cedúla Cliente:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(17, 73);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(115, 18);
            this.lblNombreCliente.TabIndex = 1;
            this.lblNombreCliente.Text = "Nombre Cliente:";
            // 
            // TxtCedulaCliente
            // 
            this.TxtCedulaCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaCliente.Location = new System.Drawing.Point(185, 31);
            this.TxtCedulaCliente.Name = "TxtCedulaCliente";
            this.TxtCedulaCliente.ReadOnly = true;
            this.TxtCedulaCliente.Size = new System.Drawing.Size(220, 27);
            this.TxtCedulaCliente.TabIndex = 2;
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscarCliente.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscarCliente.Location = new System.Drawing.Point(440, 31);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(38, 30);
            this.BtnBuscarCliente.TabIndex = 100;
            this.BtnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscarCliente.UseVisualStyleBackColor = true;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // TxtNombresCliente
            // 
            this.TxtNombresCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresCliente.Location = new System.Drawing.Point(185, 68);
            this.TxtNombresCliente.Name = "TxtNombresCliente";
            this.TxtNombresCliente.ReadOnly = true;
            this.TxtNombresCliente.Size = new System.Drawing.Size(220, 27);
            this.TxtNombresCliente.TabIndex = 101;
            // 
            // TxtIdCliente
            // 
            this.TxtIdCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdCliente.Location = new System.Drawing.Point(440, 68);
            this.TxtIdCliente.Name = "TxtIdCliente";
            this.TxtIdCliente.ReadOnly = true;
            this.TxtIdCliente.Size = new System.Drawing.Size(37, 27);
            this.TxtIdCliente.TabIndex = 102;
            // 
            // GroupBoxCliente
            // 
            this.GroupBoxCliente.BackColor = System.Drawing.Color.White;
            this.GroupBoxCliente.Controls.Add(this.TxtIdCliente);
            this.GroupBoxCliente.Controls.Add(this.TxtNombresCliente);
            this.GroupBoxCliente.Controls.Add(this.BtnBuscarCliente);
            this.GroupBoxCliente.Controls.Add(this.TxtCedulaCliente);
            this.GroupBoxCliente.Controls.Add(this.lblNombreCliente);
            this.GroupBoxCliente.Controls.Add(this.LblCedula);
            this.GroupBoxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxCliente.Location = new System.Drawing.Point(650, 72);
            this.GroupBoxCliente.Name = "GroupBoxCliente";
            this.GroupBoxCliente.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxCliente.TabIndex = 122;
            this.GroupBoxCliente.TabStop = false;
            this.GroupBoxCliente.Text = "Información Cliente";
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
            // GroupBoxInformacionVenta
            // 
            this.GroupBoxInformacionVenta.BackColor = System.Drawing.Color.White;
            this.GroupBoxInformacionVenta.Controls.Add(this.CmbTipoDocumento);
            this.GroupBoxInformacionVenta.Controls.Add(this.TxtFecha);
            this.GroupBoxInformacionVenta.Controls.Add(this.lblTipoDocumento);
            this.GroupBoxInformacionVenta.Controls.Add(this.lblFecha);
            this.GroupBoxInformacionVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxInformacionVenta.Location = new System.Drawing.Point(35, 72);
            this.GroupBoxInformacionVenta.Name = "GroupBoxInformacionVenta";
            this.GroupBoxInformacionVenta.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxInformacionVenta.TabIndex = 121;
            this.GroupBoxInformacionVenta.TabStop = false;
            this.GroupBoxInformacionVenta.Text = "Información Venta";
            // 
            // GroupBoxProducto
            // 
            this.GroupBoxProducto.BackColor = System.Drawing.Color.White;
            this.GroupBoxProducto.Controls.Add(this.BtnLimpiar);
            this.GroupBoxProducto.Controls.Add(this.NudCantidad);
            this.GroupBoxProducto.Controls.Add(this.TxtStock);
            this.GroupBoxProducto.Controls.Add(this.TxtPrecioCompra);
            this.GroupBoxProducto.Controls.Add(this.lblCantidad);
            this.GroupBoxProducto.Controls.Add(this.lblStock);
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
            this.GroupBoxProducto.TabIndex = 124;
            this.GroupBoxProducto.TabStop = false;
            this.GroupBoxProducto.Text = "Información Producto";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.BtnLimpiar.Location = new System.Drawing.Point(1068, 62);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(38, 30);
            this.BtnLimpiar.TabIndex = 113;
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // NudCantidad
            // 
            this.NudCantidad.Location = new System.Drawing.Point(932, 65);
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(101, 27);
            this.NudCantidad.TabIndex = 112;
            // 
            // TxtStock
            // 
            this.TxtStock.BackColor = System.Drawing.Color.LightGray;
            this.TxtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStock.Location = new System.Drawing.Point(785, 65);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.ReadOnly = true;
            this.TxtStock.Size = new System.Drawing.Size(96, 27);
            this.TxtStock.TabIndex = 111;
            this.TxtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStock_KeyPress);
            // 
            // TxtPrecioCompra
            // 
            this.TxtPrecioCompra.BackColor = System.Drawing.Color.LightGray;
            this.TxtPrecioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecioCompra.Location = new System.Drawing.Point(615, 65);
            this.TxtPrecioCompra.Name = "TxtPrecioCompra";
            this.TxtPrecioCompra.ReadOnly = true;
            this.TxtPrecioCompra.Size = new System.Drawing.Size(114, 27);
            this.TxtPrecioCompra.TabIndex = 110;
            this.TxtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioCompra_KeyPress);
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
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(785, 40);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(51, 18);
            this.lblStock.TabIndex = 108;
            this.lblStock.Text = "Stock:";
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
            // TxtProducto
            // 
            this.TxtProducto.BackColor = System.Drawing.Color.LightGray;
            this.TxtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProducto.Location = new System.Drawing.Point(340, 65);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.ReadOnly = true;
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
            this.TxtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigo_KeyDown);
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
            // BtnAgregar
            // 
            this.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregar.Image")));
            this.BtnAgregar.Location = new System.Drawing.Point(157, 74);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(138, 74);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(23, 18);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(98, 18);
            this.lblTotalPagar.TabIndex = 106;
            this.lblTotalPagar.Text = "Total a pagar:";
            // 
            // BtnCrearVenta
            // 
            this.BtnCrearVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCrearVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearVenta.Location = new System.Drawing.Point(157, 154);
            this.BtnCrearVenta.Name = "BtnCrearVenta";
            this.BtnCrearVenta.Size = new System.Drawing.Size(138, 36);
            this.BtnCrearVenta.TabIndex = 112;
            this.BtnCrearVenta.Text = "Crear Venta";
            this.BtnCrearVenta.UseVisualStyleBackColor = true;
            this.BtnCrearVenta.Click += new System.EventHandler(this.BtnCrearVenta_Click);
            // 
            // lblPagaCon
            // 
            this.lblPagaCon.AutoSize = true;
            this.lblPagaCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagaCon.Location = new System.Drawing.Point(23, 77);
            this.lblPagaCon.Name = "lblPagaCon";
            this.lblPagaCon.Size = new System.Drawing.Size(75, 18);
            this.lblPagaCon.TabIndex = 113;
            this.lblPagaCon.Text = "Paga con:";
            // 
            // TxtPagaCon
            // 
            this.TxtPagaCon.BackColor = System.Drawing.Color.LightGray;
            this.TxtPagaCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPagaCon.Location = new System.Drawing.Point(26, 99);
            this.TxtPagaCon.Name = "TxtPagaCon";
            this.TxtPagaCon.Size = new System.Drawing.Size(115, 27);
            this.TxtPagaCon.TabIndex = 114;
            this.TxtPagaCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPagaCon_KeyDown);
            this.TxtPagaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPagaCon_KeyPress);
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(154, 18);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(64, 18);
            this.lblCambio.TabIndex = 115;
            this.lblCambio.Text = "Cambio:";
            // 
            // TxtCambio
            // 
            this.TxtCambio.BackColor = System.Drawing.Color.LightGray;
            this.TxtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCambio.Location = new System.Drawing.Point(157, 39);
            this.TxtCambio.Name = "TxtCambio";
            this.TxtCambio.ReadOnly = true;
            this.TxtCambio.Size = new System.Drawing.Size(137, 27);
            this.TxtCambio.TabIndex = 116;
            // 
            // TxtTotalPagar
            // 
            this.TxtTotalPagar.BackColor = System.Drawing.Color.LightGray;
            this.TxtTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalPagar.Location = new System.Drawing.Point(26, 39);
            this.TxtTotalPagar.Name = "TxtTotalPagar";
            this.TxtTotalPagar.ReadOnly = true;
            this.TxtTotalPagar.Size = new System.Drawing.Size(115, 27);
            this.TxtTotalPagar.TabIndex = 117;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(23, 136);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(113, 18);
            this.lblDescuento.TabIndex = 118;
            this.lblDescuento.Text = "Con descuento:";
            // 
            // TxtTotalDescuento
            // 
            this.TxtTotalDescuento.BackColor = System.Drawing.Color.LightGray;
            this.TxtTotalDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalDescuento.Location = new System.Drawing.Point(26, 159);
            this.TxtTotalDescuento.Name = "TxtTotalDescuento";
            this.TxtTotalDescuento.ReadOnly = true;
            this.TxtTotalDescuento.Size = new System.Drawing.Size(115, 27);
            this.TxtTotalDescuento.TabIndex = 120;
            // 
            // lblOferta
            // 
            this.lblOferta.AutoSize = true;
            this.lblOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOferta.Location = new System.Drawing.Point(21, 34);
            this.lblOferta.Name = "lblOferta";
            this.lblOferta.Size = new System.Drawing.Size(61, 20);
            this.lblOferta.TabIndex = 122;
            this.lblOferta.Text = "Oferta:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.TxtTotalDescuento);
            this.groupBox4.Controls.Add(this.lblDescuento);
            this.groupBox4.Controls.Add(this.TxtTotalPagar);
            this.groupBox4.Controls.Add(this.TxtCambio);
            this.groupBox4.Controls.Add(this.lblCambio);
            this.groupBox4.Controls.Add(this.TxtPagaCon);
            this.groupBox4.Controls.Add(this.lblPagaCon);
            this.groupBox4.Controls.Add(this.BtnCrearVenta);
            this.groupBox4.Controls.Add(this.lblTotalPagar);
            this.groupBox4.Controls.Add(this.BtnAgregar);
            this.groupBox4.Location = new System.Drawing.Point(847, 475);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 205);
            this.groupBox4.TabIndex = 125;
            this.groupBox4.TabStop = false;
            // 
            // LblPorcentaje
            // 
            this.LblPorcentaje.AutoSize = true;
            this.LblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPorcentaje.Location = new System.Drawing.Point(411, 59);
            this.LblPorcentaje.Name = "LblPorcentaje";
            this.LblPorcentaje.Size = new System.Drawing.Size(24, 20);
            this.LblPorcentaje.TabIndex = 124;
            this.LblPorcentaje.Text = "%";
            // 
            // lblImportante
            // 
            this.lblImportante.BackColor = System.Drawing.Color.White;
            this.lblImportante.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportante.Location = new System.Drawing.Point(322, 8);
            this.lblImportante.Name = "lblImportante";
            this.lblImportante.Size = new System.Drawing.Size(863, 42);
            this.lblImportante.TabIndex = 126;
            this.lblImportante.Text = "IMPORTANTE Antes de ir a otro menú por favor verifique que la tabla Venta se encu" +
    "entre totalmente vacía.";
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.AutoScroll = true;
            this.PanelPrincipal.BackColor = System.Drawing.Color.White;
            this.PanelPrincipal.Controls.Add(this.GroupBoxOferta);
            this.PanelPrincipal.Controls.Add(this.LblRegistrarVenta);
            this.PanelPrincipal.Controls.Add(this.GroupBoxSucursal);
            this.PanelPrincipal.Controls.Add(this.TablaVentas);
            this.PanelPrincipal.Controls.Add(this.GroupBoxProducto);
            this.PanelPrincipal.Controls.Add(this.lblImportante);
            this.PanelPrincipal.Controls.Add(this.groupBox4);
            this.PanelPrincipal.Controls.Add(this.GroupBoxInformacionVenta);
            this.PanelPrincipal.Controls.Add(this.GroupBoxCliente);
            this.PanelPrincipal.Location = new System.Drawing.Point(131, 23);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1212, 540);
            this.PanelPrincipal.TabIndex = 127;
            // 
            // GroupBoxOferta
            // 
            this.GroupBoxOferta.BackColor = System.Drawing.Color.White;
            this.GroupBoxOferta.Controls.Add(this.LblPorcentaje);
            this.GroupBoxOferta.Controls.Add(this.TxtDescuentoOferta);
            this.GroupBoxOferta.Controls.Add(this.BtnModalOferta);
            this.GroupBoxOferta.Controls.Add(this.lblOferta);
            this.GroupBoxOferta.Controls.Add(this.TxtNombreOferta);
            this.GroupBoxOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxOferta.Location = new System.Drawing.Point(650, 210);
            this.GroupBoxOferta.Name = "GroupBoxOferta";
            this.GroupBoxOferta.Size = new System.Drawing.Size(510, 115);
            this.GroupBoxOferta.TabIndex = 134;
            this.GroupBoxOferta.TabStop = false;
            this.GroupBoxOferta.Text = "Información Oferta";
            // 
            // TxtDescuentoOferta
            // 
            this.TxtDescuentoOferta.BackColor = System.Drawing.Color.LightGray;
            this.TxtDescuentoOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescuentoOferta.Location = new System.Drawing.Point(354, 56);
            this.TxtDescuentoOferta.Name = "TxtDescuentoOferta";
            this.TxtDescuentoOferta.ReadOnly = true;
            this.TxtDescuentoOferta.Size = new System.Drawing.Size(51, 27);
            this.TxtDescuentoOferta.TabIndex = 119;
            // 
            // BtnModalOferta
            // 
            this.BtnModalOferta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnModalOferta.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnModalOferta.Location = new System.Drawing.Point(453, 56);
            this.BtnModalOferta.Name = "BtnModalOferta";
            this.BtnModalOferta.Size = new System.Drawing.Size(38, 31);
            this.BtnModalOferta.TabIndex = 116;
            this.BtnModalOferta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnModalOferta.UseVisualStyleBackColor = true;
            this.BtnModalOferta.Click += new System.EventHandler(this.BtnModalOferta_Click);
            // 
            // TxtNombreOferta
            // 
            this.TxtNombreOferta.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombreOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreOferta.Location = new System.Drawing.Point(20, 56);
            this.TxtNombreOferta.Name = "TxtNombreOferta";
            this.TxtNombreOferta.ReadOnly = true;
            this.TxtNombreOferta.Size = new System.Drawing.Size(310, 27);
            this.TxtNombreOferta.TabIndex = 113;
            // 
            // LblRegistrarVenta
            // 
            this.LblRegistrarVenta.AutoSize = true;
            this.LblRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistrarVenta.Location = new System.Drawing.Point(3, 2);
            this.LblRegistrarVenta.Name = "LblRegistrarVenta";
            this.LblRegistrarVenta.Size = new System.Drawing.Size(226, 32);
            this.LblRegistrarVenta.TabIndex = 134;
            this.LblRegistrarVenta.Text = "Registrar Venta";
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
            this.GroupBoxSucursal.TabIndex = 133;
            this.GroupBoxSucursal.TabStop = false;
            this.GroupBoxSucursal.Text = "Información Sucursal";
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
            // VtnVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.PanelPrincipal);
            this.Name = "VtnVenta";
            this.Text = "Realizar ventas";
            this.Load += new System.EventHandler(this.VtnVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaVentas)).EndInit();
            this.GroupBoxCliente.ResumeLayout(false);
            this.GroupBoxCliente.PerformLayout();
            this.GroupBoxInformacionVenta.ResumeLayout(false);
            this.GroupBoxInformacionVenta.PerformLayout();
            this.GroupBoxProducto.ResumeLayout(false);
            this.GroupBoxProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.GroupBoxOferta.ResumeLayout(false);
            this.GroupBoxOferta.PerformLayout();
            this.GroupBoxSucursal.ResumeLayout(false);
            this.GroupBoxSucursal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridView TablaVentas;
        private System.Windows.Forms.Label LblCedula;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox TxtCedulaCliente;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.TextBox TxtNombresCliente;
        private System.Windows.Forms.TextBox TxtIdCliente;
        private System.Windows.Forms.GroupBox GroupBoxCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox TxtFecha;
        private System.Windows.Forms.ComboBox CmbTipoDocumento;
        private System.Windows.Forms.GroupBox GroupBoxInformacionVenta;
        private System.Windows.Forms.GroupBox GroupBoxProducto;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.TextBox TxtPrecioCompra;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button BtnBuscarProducto;
        private System.Windows.Forms.TextBox TxtIdProducto;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Button BtnCrearVenta;
        private System.Windows.Forms.Label lblPagaCon;
        private System.Windows.Forms.TextBox TxtPagaCon;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox TxtCambio;
        private System.Windows.Forms.TextBox TxtTotalPagar;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox TxtTotalDescuento;
        private System.Windows.Forms.Label lblOferta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblImportante;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Label LblPorcentaje;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.GroupBox GroupBoxSucursal;
        private System.Windows.Forms.TextBox TxtIdSucursal;
        private System.Windows.Forms.Button BtnModalSucursal;
        private System.Windows.Forms.TextBox TxtSucursal;
        private System.Windows.Forms.Label LblSucursal;
        private System.Windows.Forms.Label LblRegistrarVenta;
        private System.Windows.Forms.GroupBox GroupBoxOferta;
        private System.Windows.Forms.TextBox TxtDescuentoOferta;
        private System.Windows.Forms.Button BtnModalOferta;
        private System.Windows.Forms.TextBox TxtNombreOferta;
    }
}