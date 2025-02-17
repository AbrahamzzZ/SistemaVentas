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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBoxBuscar = new System.Windows.Forms.GroupBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtNumeroDocumentoVenta = new System.Windows.Forms.TextBox();
            this.LblNumeroDocumentoVenta = new System.Windows.Forms.Label();
            this.GroupBoxInformacionVenta = new System.Windows.Forms.GroupBox();
            this.TxtNombreCompletoUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.TxtTipoDocumento = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.TxtFechaVenta = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.GroupBoxCliente = new System.Windows.Forms.GroupBox();
            this.TxtCedulaCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.TxtNombresCliente = new System.Windows.Forms.TextBox();
            this.LblCedulaCliente = new System.Windows.Forms.Label();
            this.tablaDetallesVentas = new System.Windows.Forms.DataGridView();
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
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBoxSucursal = new System.Windows.Forms.GroupBox();
            this.TxtSucursal = new System.Windows.Forms.TextBox();
            this.LblSucursal = new System.Windows.Forms.Label();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBoxBuscar.SuspendLayout();
            this.GroupBoxInformacionVenta.SuspendLayout();
            this.GroupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetallesVentas)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.GroupBoxSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxBuscar
            // 
            this.GroupBoxBuscar.BackColor = System.Drawing.Color.White;
            this.GroupBoxBuscar.Controls.Add(this.BtnLimpiar);
            this.GroupBoxBuscar.Controls.Add(this.BtnBuscar);
            this.GroupBoxBuscar.Controls.Add(this.TxtNumeroDocumentoVenta);
            this.GroupBoxBuscar.Controls.Add(this.LblNumeroDocumentoVenta);
            this.GroupBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxBuscar.Location = new System.Drawing.Point(488, 61);
            this.GroupBoxBuscar.Name = "GroupBoxBuscar";
            this.GroupBoxBuscar.Size = new System.Drawing.Size(680, 95);
            this.GroupBoxBuscar.TabIndex = 123;
            this.GroupBoxBuscar.TabStop = false;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(537, 35);
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
            this.BtnBuscar.Location = new System.Drawing.Point(390, 35);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(123, 31);
            this.BtnBuscar.TabIndex = 100;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtNumeroDocumentoVenta
            // 
            this.TxtNumeroDocumentoVenta.BackColor = System.Drawing.Color.LightGray;
            this.TxtNumeroDocumentoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroDocumentoVenta.Location = new System.Drawing.Point(174, 38);
            this.TxtNumeroDocumentoVenta.Name = "TxtNumeroDocumentoVenta";
            this.TxtNumeroDocumentoVenta.Size = new System.Drawing.Size(184, 27);
            this.TxtNumeroDocumentoVenta.TabIndex = 2;
            this.TxtNumeroDocumentoVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigoVenta_KeyPress);
            // 
            // LblNumeroDocumentoVenta
            // 
            this.LblNumeroDocumentoVenta.AutoSize = true;
            this.LblNumeroDocumentoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroDocumentoVenta.Location = new System.Drawing.Point(37, 43);
            this.LblNumeroDocumentoVenta.Name = "LblNumeroDocumentoVenta";
            this.LblNumeroDocumentoVenta.Size = new System.Drawing.Size(109, 18);
            this.LblNumeroDocumentoVenta.TabIndex = 0;
            this.LblNumeroDocumentoVenta.Text = "N. Documento:";
            // 
            // GroupBoxInformacionVenta
            // 
            this.GroupBoxInformacionVenta.BackColor = System.Drawing.Color.White;
            this.GroupBoxInformacionVenta.Controls.Add(this.TxtNombreCompletoUsuario);
            this.GroupBoxInformacionVenta.Controls.Add(this.lblUsuario);
            this.GroupBoxInformacionVenta.Controls.Add(this.TxtTipoDocumento);
            this.GroupBoxInformacionVenta.Controls.Add(this.lblTipoDocumento);
            this.GroupBoxInformacionVenta.Controls.Add(this.TxtFechaVenta);
            this.GroupBoxInformacionVenta.Controls.Add(this.lblFecha);
            this.GroupBoxInformacionVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxInformacionVenta.Location = new System.Drawing.Point(41, 61);
            this.GroupBoxInformacionVenta.Name = "GroupBoxInformacionVenta";
            this.GroupBoxInformacionVenta.Size = new System.Drawing.Size(354, 239);
            this.GroupBoxInformacionVenta.TabIndex = 124;
            this.GroupBoxInformacionVenta.TabStop = false;
            this.GroupBoxInformacionVenta.Text = "Información Venta";
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
            // GroupBoxCliente
            // 
            this.GroupBoxCliente.BackColor = System.Drawing.Color.White;
            this.GroupBoxCliente.Controls.Add(this.TxtCedulaCliente);
            this.GroupBoxCliente.Controls.Add(this.lblNombreCliente);
            this.GroupBoxCliente.Controls.Add(this.TxtNombresCliente);
            this.GroupBoxCliente.Controls.Add(this.LblCedulaCliente);
            this.GroupBoxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxCliente.Location = new System.Drawing.Point(488, 180);
            this.GroupBoxCliente.Name = "GroupBoxCliente";
            this.GroupBoxCliente.Size = new System.Drawing.Size(680, 108);
            this.GroupBoxCliente.TabIndex = 125;
            this.GroupBoxCliente.TabStop = false;
            this.GroupBoxCliente.Text = "Información Cliente";
            // 
            // TxtCedulaCliente
            // 
            this.TxtCedulaCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaCliente.Location = new System.Drawing.Point(61, 56);
            this.TxtCedulaCliente.Name = "TxtCedulaCliente";
            this.TxtCedulaCliente.ReadOnly = true;
            this.TxtCedulaCliente.Size = new System.Drawing.Size(210, 27);
            this.TxtCedulaCliente.TabIndex = 110;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(371, 34);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(135, 18);
            this.lblNombreCliente.TabIndex = 105;
            this.lblNombreCliente.Text = "Nombre del cliente:";
            // 
            // TxtNombresCliente
            // 
            this.TxtNombresCliente.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresCliente.Location = new System.Drawing.Point(372, 56);
            this.TxtNombresCliente.Name = "TxtNombresCliente";
            this.TxtNombresCliente.ReadOnly = true;
            this.TxtNombresCliente.Size = new System.Drawing.Size(210, 27);
            this.TxtNombresCliente.TabIndex = 2;
            // 
            // LblCedulaCliente
            // 
            this.LblCedulaCliente.AutoSize = true;
            this.LblCedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedulaCliente.Location = new System.Drawing.Point(60, 34);
            this.LblCedulaCliente.Name = "LblCedulaCliente";
            this.LblCedulaCliente.Size = new System.Drawing.Size(107, 18);
            this.LblCedulaCliente.TabIndex = 0;
            this.LblCedulaCliente.Text = "Cédula Cliente:";
            // 
            // tablaDetallesVentas
            // 
            this.tablaDetallesVentas.AllowUserToAddRows = false;
            this.tablaDetallesVentas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaDetallesVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.tablaDetallesVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDetallesVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal,
            this.Descuento});
            this.tablaDetallesVentas.Location = new System.Drawing.Point(41, 453);
            this.tablaDetallesVentas.MultiSelect = false;
            this.tablaDetallesVentas.Name = "tablaDetallesVentas";
            this.tablaDetallesVentas.ReadOnly = true;
            this.tablaDetallesVentas.RowHeadersWidth = 51;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaDetallesVentas.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.tablaDetallesVentas.RowTemplate.Height = 28;
            this.tablaDetallesVentas.Size = new System.Drawing.Size(1127, 200);
            this.tablaDetallesVentas.TabIndex = 127;
            // 
            // TxtMontoCambio
            // 
            this.TxtMontoCambio.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoCambio.Location = new System.Drawing.Point(420, 56);
            this.TxtMontoCambio.Name = "TxtMontoCambio";
            this.TxtMontoCambio.ReadOnly = true;
            this.TxtMontoCambio.Size = new System.Drawing.Size(90, 27);
            this.TxtMontoCambio.TabIndex = 119;
            // 
            // TxtMontoPago
            // 
            this.TxtMontoPago.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoPago.Location = new System.Drawing.Point(282, 56);
            this.TxtMontoPago.Name = "TxtMontoPago";
            this.TxtMontoPago.ReadOnly = true;
            this.TxtMontoPago.Size = new System.Drawing.Size(90, 27);
            this.TxtMontoPago.TabIndex = 118;
            // 
            // lblMontoCambio
            // 
            this.lblMontoCambio.AutoSize = true;
            this.lblMontoCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoCambio.Location = new System.Drawing.Point(406, 32);
            this.lblMontoCambio.Name = "lblMontoCambio";
            this.lblMontoCambio.Size = new System.Drawing.Size(122, 20);
            this.lblMontoCambio.TabIndex = 117;
            this.lblMontoCambio.Text = "Monto Cambio:";
            // 
            // lblMontoPago
            // 
            this.lblMontoPago.AutoSize = true;
            this.lblMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoPago.Location = new System.Drawing.Point(278, 32);
            this.lblMontoPago.Name = "lblMontoPago";
            this.lblMontoPago.Size = new System.Drawing.Size(103, 20);
            this.lblMontoPago.TabIndex = 116;
            this.lblMontoPago.Text = "Monto Pago:";
            // 
            // btnDescargarPdf
            // 
            this.btnDescargarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarPdf.Location = new System.Drawing.Point(540, 25);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(121, 67);
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
            this.groupBox4.Location = new System.Drawing.Point(488, 316);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 108);
            this.groupBox4.TabIndex = 126;
            this.groupBox4.TabStop = false;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(22, 32);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(95, 20);
            this.lblDescuento.TabIndex = 121;
            this.lblDescuento.Text = "Descuento:";
            // 
            // TxtDescuento
            // 
            this.TxtDescuento.BackColor = System.Drawing.Color.LightGray;
            this.TxtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescuento.Location = new System.Drawing.Point(23, 56);
            this.TxtDescuento.Name = "TxtDescuento";
            this.TxtDescuento.ReadOnly = true;
            this.TxtDescuento.Size = new System.Drawing.Size(90, 27);
            this.TxtDescuento.TabIndex = 120;
            // 
            // TxtMontoTotal
            // 
            this.TxtMontoTotal.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoTotal.Location = new System.Drawing.Point(149, 56);
            this.TxtMontoTotal.Name = "TxtMontoTotal";
            this.TxtMontoTotal.ReadOnly = true;
            this.TxtMontoTotal.Size = new System.Drawing.Size(90, 27);
            this.TxtMontoTotal.TabIndex = 115;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(144, 34);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(102, 20);
            this.lblMontoTotal.TabIndex = 114;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.AutoScroll = true;
            this.PanelPrincipal.BackColor = System.Drawing.Color.White;
            this.PanelPrincipal.Controls.Add(this.GroupBoxSucursal);
            this.PanelPrincipal.Controls.Add(this.label1);
            this.PanelPrincipal.Controls.Add(this.groupBox4);
            this.PanelPrincipal.Controls.Add(this.GroupBoxCliente);
            this.PanelPrincipal.Controls.Add(this.GroupBoxBuscar);
            this.PanelPrincipal.Controls.Add(this.GroupBoxInformacionVenta);
            this.PanelPrincipal.Controls.Add(this.tablaDetallesVentas);
            this.PanelPrincipal.Location = new System.Drawing.Point(131, 23);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1212, 540);
            this.PanelPrincipal.TabIndex = 129;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 38);
            this.label1.TabIndex = 129;
            this.label1.Text = "Detalles ventas";
            // 
            // GroupBoxSucursal
            // 
            this.GroupBoxSucursal.BackColor = System.Drawing.Color.White;
            this.GroupBoxSucursal.Controls.Add(this.TxtSucursal);
            this.GroupBoxSucursal.Controls.Add(this.LblSucursal);
            this.GroupBoxSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxSucursal.Location = new System.Drawing.Point(41, 316);
            this.GroupBoxSucursal.Name = "GroupBoxSucursal";
            this.GroupBoxSucursal.Size = new System.Drawing.Size(354, 108);
            this.GroupBoxSucursal.TabIndex = 131;
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
            this.LblSucursal.Location = new System.Drawing.Point(23, 34);
            this.LblSucursal.Name = "LblSucursal";
            this.LblSucursal.Size = new System.Drawing.Size(70, 18);
            this.LblSucursal.TabIndex = 115;
            this.LblSucursal.Text = "Sucursal:";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 140;
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
            // VtnVerDetalleVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.PanelPrincipal);
            this.Name = "VtnVerDetalleVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver los detalles de las ventas realizadas";
            this.Load += new System.EventHandler(this.VtnVerDetalleVentas_Load);
            this.GroupBoxBuscar.ResumeLayout(false);
            this.GroupBoxBuscar.PerformLayout();
            this.GroupBoxInformacionVenta.ResumeLayout(false);
            this.GroupBoxInformacionVenta.PerformLayout();
            this.GroupBoxCliente.ResumeLayout(false);
            this.GroupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetallesVentas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.GroupBoxSucursal.ResumeLayout(false);
            this.GroupBoxSucursal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxBuscar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtNumeroDocumentoVenta;
        private System.Windows.Forms.Label LblNumeroDocumentoVenta;
        private System.Windows.Forms.GroupBox GroupBoxInformacionVenta;
        private System.Windows.Forms.TextBox TxtNombreCompletoUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox TxtTipoDocumento;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox TxtFechaVenta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox GroupBoxCliente;
        private System.Windows.Forms.TextBox TxtCedulaCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox TxtNombresCliente;
        private System.Windows.Forms.Label LblCedulaCliente;
        private System.Windows.Forms.DataGridView tablaDetallesVentas;
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
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GroupBoxSucursal;
        private System.Windows.Forms.TextBox TxtSucursal;
        private System.Windows.Forms.Label LblSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
    }
}