namespace Presentacion
{
    partial class VtnVerDetalleVentas
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtCodigoVenta = new System.Windows.Forms.TextBox();
            this.LblCodigoVenta = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtNombreCompletoUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.TxtTipoDocumento = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.TxtFechaVenta = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCedulaCliente = new System.Windows.Forms.TextBox();
            this.TxtIdCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.TxtNombresCliente = new System.Windows.Forms.TextBox();
            this.LblCedulaCliente = new System.Windows.Forms.Label();
            this.tablaDetallesVentas = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDetallesVenta = new System.Windows.Forms.Label();
            this.TxtMontoCambio = new System.Windows.Forms.TextBox();
            this.TxtMontoPago = new System.Windows.Forms.TextBox();
            this.lblMontoCambio = new System.Windows.Forms.Label();
            this.lblMontoPago = new System.Windows.Forms.Label();
            this.btnDescargarPdf = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.TxtDescuento = new System.Windows.Forms.TextBox();
            this.TxtMontoTotal = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetallesVentas)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.BtnLimpiar);
            this.groupBox2.Controls.Add(this.BtnBuscar);
            this.groupBox2.Controls.Add(this.TxtCodigoVenta);
            this.groupBox2.Controls.Add(this.LblCodigoVenta);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(590, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 80);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(550, 33);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(123, 31);
            this.BtnLimpiar.TabIndex = 101;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(392, 33);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(123, 31);
            this.BtnBuscar.TabIndex = 100;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtCodigoVenta
            // 
            this.TxtCodigoVenta.BackColor = System.Drawing.Color.LightGray;
            this.TxtCodigoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoVenta.Location = new System.Drawing.Point(174, 35);
            this.TxtCodigoVenta.Name = "TxtCodigoVenta";
            this.TxtCodigoVenta.Size = new System.Drawing.Size(184, 27);
            this.TxtCodigoVenta.TabIndex = 2;
            this.TxtCodigoVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigoVenta_KeyPress);
            // 
            // LblCodigoVenta
            // 
            this.LblCodigoVenta.AutoSize = true;
            this.LblCodigoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigoVenta.Location = new System.Drawing.Point(40, 40);
            this.LblCodigoVenta.Name = "LblCodigoVenta";
            this.LblCodigoVenta.Size = new System.Drawing.Size(101, 18);
            this.LblCodigoVenta.TabIndex = 0;
            this.LblCodigoVenta.Text = "Código Venta:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.TxtNombreCompletoUsuario);
            this.groupBox3.Controls.Add(this.lblUsuario);
            this.groupBox3.Controls.Add(this.TxtTipoDocumento);
            this.groupBox3.Controls.Add(this.lblTipoDocumento);
            this.groupBox3.Controls.Add(this.TxtFechaVenta);
            this.groupBox3.Controls.Add(this.lblFecha);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(177, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 239);
            this.groupBox3.TabIndex = 124;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información Venta";
            // 
            // TxtNombreCompletoUsuario
            // 
            this.TxtNombreCompletoUsuario.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombreCompletoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreCompletoUsuario.Location = new System.Drawing.Point(20, 186);
            this.TxtNombreCompletoUsuario.Name = "TxtNombreCompletoUsuario";
            this.TxtNombreCompletoUsuario.ReadOnly = true;
            this.TxtNombreCompletoUsuario.Size = new System.Drawing.Size(310, 27);
            this.TxtNombreCompletoUsuario.TabIndex = 110;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(17, 165);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 18);
            this.lblUsuario.TabIndex = 107;
            this.lblUsuario.Text = "Usuario:";
            // 
            // TxtTipoDocumento
            // 
            this.TxtTipoDocumento.BackColor = System.Drawing.Color.LightGray;
            this.TxtTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTipoDocumento.Location = new System.Drawing.Point(20, 119);
            this.TxtTipoDocumento.Name = "TxtTipoDocumento";
            this.TxtTipoDocumento.ReadOnly = true;
            this.TxtTipoDocumento.Size = new System.Drawing.Size(310, 27);
            this.TxtTipoDocumento.TabIndex = 106;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDocumento.Location = new System.Drawing.Point(17, 98);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(120, 18);
            this.lblTipoDocumento.TabIndex = 105;
            this.lblTipoDocumento.Text = "Tipo documento:";
            // 
            // TxtFechaVenta
            // 
            this.TxtFechaVenta.BackColor = System.Drawing.Color.LightGray;
            this.TxtFechaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaVenta.Location = new System.Drawing.Point(20, 56);
            this.TxtFechaVenta.Name = "TxtFechaVenta";
            this.TxtFechaVenta.ReadOnly = true;
            this.TxtFechaVenta.Size = new System.Drawing.Size(310, 27);
            this.TxtFechaVenta.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(17, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(92, 18);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha venta:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.TxtCedulaCliente);
            this.groupBox1.Controls.Add(this.TxtIdCliente);
            this.groupBox1.Controls.Add(this.lblNombreCliente);
            this.groupBox1.Controls.Add(this.TxtNombresCliente);
            this.groupBox1.Controls.Add(this.LblCedulaCliente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(590, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 108);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Cliente";
            // 
            // TxtCedulaCliente
            // 
            this.TxtCedulaCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaCliente.Location = new System.Drawing.Point(40, 56);
            this.TxtCedulaCliente.Name = "TxtCedulaCliente";
            this.TxtCedulaCliente.ReadOnly = true;
            this.TxtCedulaCliente.Size = new System.Drawing.Size(172, 27);
            this.TxtCedulaCliente.TabIndex = 110;
            // 
            // TxtIdCliente
            // 
            this.TxtIdCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdCliente.Location = new System.Drawing.Point(550, 56);
            this.TxtIdCliente.Name = "TxtIdCliente";
            this.TxtIdCliente.ReadOnly = true;
            this.TxtIdCliente.Size = new System.Drawing.Size(89, 27);
            this.TxtIdCliente.TabIndex = 106;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(292, 35);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(135, 18);
            this.lblNombreCliente.TabIndex = 105;
            this.lblNombreCliente.Text = "Nombre del cliente:";
            // 
            // TxtNombresCliente
            // 
            this.TxtNombresCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresCliente.Location = new System.Drawing.Point(292, 56);
            this.TxtNombresCliente.Name = "TxtNombresCliente";
            this.TxtNombresCliente.ReadOnly = true;
            this.TxtNombresCliente.Size = new System.Drawing.Size(193, 27);
            this.TxtNombresCliente.TabIndex = 2;
            // 
            // LblCedulaCliente
            // 
            this.LblCedulaCliente.AutoSize = true;
            this.LblCedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedulaCliente.Location = new System.Drawing.Point(40, 35);
            this.LblCedulaCliente.Name = "LblCedulaCliente";
            this.LblCedulaCliente.Size = new System.Drawing.Size(107, 18);
            this.LblCedulaCliente.TabIndex = 0;
            this.LblCedulaCliente.Text = "Cedúla Cliente:";
            // 
            // tablaDetallesVentas
            // 
            this.tablaDetallesVentas.AllowUserToAddRows = false;
            this.tablaDetallesVentas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaDetallesVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaDetallesVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDetallesVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal,
            this.Descuento});
            this.tablaDetallesVentas.Location = new System.Drawing.Point(177, 348);
            this.tablaDetallesVentas.MultiSelect = false;
            this.tablaDetallesVentas.Name = "tablaDetallesVentas";
            this.tablaDetallesVentas.ReadOnly = true;
            this.tablaDetallesVentas.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaDetallesVentas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaDetallesVentas.RowTemplate.Height = 28;
            this.tablaDetallesVentas.Size = new System.Drawing.Size(771, 196);
            this.tablaDetallesVentas.TabIndex = 127;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 125;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.MinimumWidth = 6;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Width = 135;
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
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 125;
            // 
            // lblDetallesVenta
            // 
            this.lblDetallesVenta.BackColor = System.Drawing.Color.White;
            this.lblDetallesVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallesVenta.Location = new System.Drawing.Point(131, 23);
            this.lblDetallesVenta.Name = "lblDetallesVenta";
            this.lblDetallesVenta.Size = new System.Drawing.Size(1176, 540);
            this.lblDetallesVenta.TabIndex = 122;
            this.lblDetallesVenta.Text = "Detalles Ventas";
            // 
            // TxtMontoCambio
            // 
            this.TxtMontoCambio.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoCambio.Location = new System.Drawing.Point(19, 157);
            this.TxtMontoCambio.Name = "TxtMontoCambio";
            this.TxtMontoCambio.ReadOnly = true;
            this.TxtMontoCambio.Size = new System.Drawing.Size(118, 27);
            this.TxtMontoCambio.TabIndex = 119;
            // 
            // TxtMontoPago
            // 
            this.TxtMontoPago.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoPago.Location = new System.Drawing.Point(19, 100);
            this.TxtMontoPago.Name = "TxtMontoPago";
            this.TxtMontoPago.ReadOnly = true;
            this.TxtMontoPago.Size = new System.Drawing.Size(118, 27);
            this.TxtMontoPago.TabIndex = 118;
            // 
            // lblMontoCambio
            // 
            this.lblMontoCambio.AutoSize = true;
            this.lblMontoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoCambio.Location = new System.Drawing.Point(15, 134);
            this.lblMontoCambio.Name = "lblMontoCambio";
            this.lblMontoCambio.Size = new System.Drawing.Size(122, 20);
            this.lblMontoCambio.TabIndex = 117;
            this.lblMontoCambio.Text = "Monto Cambio:";
            // 
            // lblMontoPago
            // 
            this.lblMontoPago.AutoSize = true;
            this.lblMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoPago.Location = new System.Drawing.Point(16, 77);
            this.lblMontoPago.Name = "lblMontoPago";
            this.lblMontoPago.Size = new System.Drawing.Size(103, 20);
            this.lblMontoPago.TabIndex = 116;
            this.lblMontoPago.Text = "Monto Pago:";
            // 
            // btnDescargarPdf
            // 
            this.btnDescargarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarPdf.Location = new System.Drawing.Point(157, 85);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(120, 99);
            this.btnDescargarPdf.TabIndex = 113;
            this.btnDescargarPdf.Text = "Descargar PDF";
            this.btnDescargarPdf.UseVisualStyleBackColor = true;
            this.btnDescargarPdf.Click += new System.EventHandler(this.BtnDescargarPdf_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.lblDescuento);
            this.groupBox4.Controls.Add(this.TxtDescuento);
            this.groupBox4.Controls.Add(this.TxtMontoCambio);
            this.groupBox4.Controls.Add(this.TxtMontoPago);
            this.groupBox4.Controls.Add(this.lblMontoCambio);
            this.groupBox4.Controls.Add(this.lblMontoPago);
            this.groupBox4.Controls.Add(this.btnDescargarPdf);
            this.groupBox4.Controls.Add(this.TxtMontoTotal);
            this.groupBox4.Controls.Add(this.lblMontoTotal);
            this.groupBox4.Location = new System.Drawing.Point(973, 340);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 200);
            this.groupBox4.TabIndex = 126;
            this.groupBox4.TabStop = false;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(16, 18);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(95, 20);
            this.lblDescuento.TabIndex = 121;
            this.lblDescuento.Text = "Descuento:";
            // 
            // TxtDescuento
            // 
            this.TxtDescuento.BackColor = System.Drawing.Color.LightGray;
            this.TxtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescuento.Location = new System.Drawing.Point(19, 41);
            this.TxtDescuento.Name = "TxtDescuento";
            this.TxtDescuento.ReadOnly = true;
            this.TxtDescuento.Size = new System.Drawing.Size(118, 27);
            this.TxtDescuento.TabIndex = 120;
            // 
            // TxtMontoTotal
            // 
            this.TxtMontoTotal.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoTotal.Location = new System.Drawing.Point(157, 41);
            this.TxtMontoTotal.Name = "TxtMontoTotal";
            this.TxtMontoTotal.ReadOnly = true;
            this.TxtMontoTotal.Size = new System.Drawing.Size(118, 27);
            this.TxtMontoTotal.TabIndex = 115;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(154, 18);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(102, 20);
            this.lblMontoTotal.TabIndex = 114;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // vtnVerDetalleVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1383, 587);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tablaDetallesVentas);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblDetallesVenta);
            this.Name = "vtnVerDetalleVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver los detalles de las ventas realizadas";
            this.Load += new System.EventHandler(this.VtnVerDetalleVentas_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetallesVentas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtCodigoVenta;
        private System.Windows.Forms.Label LblCodigoVenta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtNombreCompletoUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox TxtTipoDocumento;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox TxtFechaVenta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtCedulaCliente;
        private System.Windows.Forms.TextBox TxtIdCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox TxtNombresCliente;
        private System.Windows.Forms.Label LblCedulaCliente;
        private System.Windows.Forms.DataGridView tablaDetallesVentas;
        private System.Windows.Forms.Label lblDetallesVenta;
        private System.Windows.Forms.TextBox TxtMontoCambio;
        private System.Windows.Forms.TextBox TxtMontoPago;
        private System.Windows.Forms.Label lblMontoCambio;
        private System.Windows.Forms.Label lblMontoPago;
        private System.Windows.Forms.Button btnDescargarPdf;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtMontoTotal;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox TxtDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
    }
}