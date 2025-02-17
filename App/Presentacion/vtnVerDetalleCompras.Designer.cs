namespace Presentacion
{
    partial class VtnVerDetalleCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablaDetallesCompras = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtMontoTotal = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.GroupBoxCompra = new System.Windows.Forms.GroupBox();
            this.btnDescargarPdf = new System.Windows.Forms.Button();
            this.TxtCedulaProveedor = new System.Windows.Forms.TextBox();
            this.lblNombreProovedor = new System.Windows.Forms.Label();
            this.TxtNombresProveedor = new System.Windows.Forms.TextBox();
            this.LblCedulaProveedor = new System.Windows.Forms.Label();
            this.GroupBoxProveedor = new System.Windows.Forms.GroupBox();
            this.TxtNombreCompletoUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.TxtTipoDocumento = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.TxtFechaCompra = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.GroupBoxInformacionCompra = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.TxtNumeroDocumentoCompra = new System.Windows.Forms.TextBox();
            this.LblNumeroDocumentoCompra = new System.Windows.Forms.Label();
            this.GroupBoxBuscar = new System.Windows.Forms.GroupBox();
            this.GroupBoxTransportista = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCedulaTransportista = new System.Windows.Forms.TextBox();
            this.TxtNombresTransportista = new System.Windows.Forms.TextBox();
            this.LblCedulaTransportista = new System.Windows.Forms.Label();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.GroupBoxSucursal = new System.Windows.Forms.GroupBox();
            this.TxtSucursal = new System.Windows.Forms.TextBox();
            this.LblSucursal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetallesCompras)).BeginInit();
            this.GroupBoxCompra.SuspendLayout();
            this.GroupBoxProveedor.SuspendLayout();
            this.GroupBoxInformacionCompra.SuspendLayout();
            this.GroupBoxBuscar.SuspendLayout();
            this.GroupBoxTransportista.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.GroupBoxSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablaDetallesCompras
            // 
            this.tablaDetallesCompras.AllowUserToAddRows = false;
            this.tablaDetallesCompras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaDetallesCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.tablaDetallesCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDetallesCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioCompra,
            this.Cantidad,
            this.SubTotal});
            this.tablaDetallesCompras.Location = new System.Drawing.Point(41, 453);
            this.tablaDetallesCompras.MultiSelect = false;
            this.tablaDetallesCompras.Name = "tablaDetallesCompras";
            this.tablaDetallesCompras.ReadOnly = true;
            this.tablaDetallesCompras.RowHeadersWidth = 51;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaDetallesCompras.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.tablaDetallesCompras.RowTemplate.Height = 28;
            this.tablaDetallesCompras.Size = new System.Drawing.Size(925, 196);
            this.tablaDetallesCompras.TabIndex = 121;
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
            this.PrecioCompra.Width = 180;
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
            // TxtMontoTotal
            // 
            this.TxtMontoTotal.BackColor = System.Drawing.Color.LightGray;
            this.TxtMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoTotal.Location = new System.Drawing.Point(17, 41);
            this.TxtMontoTotal.Name = "TxtMontoTotal";
            this.TxtMontoTotal.ReadOnly = true;
            this.TxtMontoTotal.Size = new System.Drawing.Size(120, 27);
            this.TxtMontoTotal.TabIndex = 115;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(16, 18);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(102, 20);
            this.lblMontoTotal.TabIndex = 114;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // GroupBoxCompra
            // 
            this.GroupBoxCompra.BackColor = System.Drawing.Color.White;
            this.GroupBoxCompra.Controls.Add(this.TxtMontoTotal);
            this.GroupBoxCompra.Controls.Add(this.lblMontoTotal);
            this.GroupBoxCompra.Controls.Add(this.btnDescargarPdf);
            this.GroupBoxCompra.Location = new System.Drawing.Point(1003, 443);
            this.GroupBoxCompra.Name = "GroupBoxCompra";
            this.GroupBoxCompra.Size = new System.Drawing.Size(165, 205);
            this.GroupBoxCompra.TabIndex = 120;
            this.GroupBoxCompra.TabStop = false;
            // 
            // btnDescargarPdf
            // 
            this.btnDescargarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarPdf.Location = new System.Drawing.Point(20, 85);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(120, 99);
            this.btnDescargarPdf.TabIndex = 113;
            this.btnDescargarPdf.Text = "Descargar PDF";
            this.btnDescargarPdf.UseVisualStyleBackColor = true;
            this.btnDescargarPdf.Click += new System.EventHandler(this.BtnDescargarPdf_Click);
            // 
            // TxtCedulaProveedor
            // 
            this.TxtCedulaProveedor.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaProveedor.Location = new System.Drawing.Point(61, 56);
            this.TxtCedulaProveedor.Name = "TxtCedulaProveedor";
            this.TxtCedulaProveedor.ReadOnly = true;
            this.TxtCedulaProveedor.Size = new System.Drawing.Size(210, 27);
            this.TxtCedulaProveedor.TabIndex = 110;
            // 
            // lblNombreProovedor
            // 
            this.lblNombreProovedor.AutoSize = true;
            this.lblNombreProovedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProovedor.Location = new System.Drawing.Point(371, 34);
            this.lblNombreProovedor.Name = "lblNombreProovedor";
            this.lblNombreProovedor.Size = new System.Drawing.Size(160, 18);
            this.lblNombreProovedor.TabIndex = 105;
            this.lblNombreProovedor.Text = "Nombre del proveedor:";
            // 
            // TxtNombresProveedor
            // 
            this.TxtNombresProveedor.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresProveedor.Location = new System.Drawing.Point(372, 56);
            this.TxtNombresProveedor.Name = "TxtNombresProveedor";
            this.TxtNombresProveedor.ReadOnly = true;
            this.TxtNombresProveedor.Size = new System.Drawing.Size(210, 27);
            this.TxtNombresProveedor.TabIndex = 2;
            // 
            // LblCedulaProveedor
            // 
            this.LblCedulaProveedor.AutoSize = true;
            this.LblCedulaProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedulaProveedor.Location = new System.Drawing.Point(60, 34);
            this.LblCedulaProveedor.Name = "LblCedulaProveedor";
            this.LblCedulaProveedor.Size = new System.Drawing.Size(131, 18);
            this.LblCedulaProveedor.TabIndex = 0;
            this.LblCedulaProveedor.Text = "Cédula Proveedor:";
            // 
            // GroupBoxProveedor
            // 
            this.GroupBoxProveedor.BackColor = System.Drawing.Color.White;
            this.GroupBoxProveedor.Controls.Add(this.TxtCedulaProveedor);
            this.GroupBoxProveedor.Controls.Add(this.lblNombreProovedor);
            this.GroupBoxProveedor.Controls.Add(this.TxtNombresProveedor);
            this.GroupBoxProveedor.Controls.Add(this.LblCedulaProveedor);
            this.GroupBoxProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxProveedor.Location = new System.Drawing.Point(488, 180);
            this.GroupBoxProveedor.Name = "GroupBoxProveedor";
            this.GroupBoxProveedor.Size = new System.Drawing.Size(680, 108);
            this.GroupBoxProveedor.TabIndex = 119;
            this.GroupBoxProveedor.TabStop = false;
            this.GroupBoxProveedor.Text = "Información Proveedor";
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
            // TxtFechaCompra
            // 
            this.TxtFechaCompra.BackColor = System.Drawing.Color.LightGray;
            this.TxtFechaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaCompra.Location = new System.Drawing.Point(20, 56);
            this.TxtFechaCompra.Name = "TxtFechaCompra";
            this.TxtFechaCompra.ReadOnly = true;
            this.TxtFechaCompra.Size = new System.Drawing.Size(310, 27);
            this.TxtFechaCompra.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(17, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(108, 18);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha compra:";
            // 
            // GroupBoxInformacionCompra
            // 
            this.GroupBoxInformacionCompra.BackColor = System.Drawing.Color.White;
            this.GroupBoxInformacionCompra.Controls.Add(this.TxtNombreCompletoUsuario);
            this.GroupBoxInformacionCompra.Controls.Add(this.lblUsuario);
            this.GroupBoxInformacionCompra.Controls.Add(this.TxtTipoDocumento);
            this.GroupBoxInformacionCompra.Controls.Add(this.lblTipoDocumento);
            this.GroupBoxInformacionCompra.Controls.Add(this.TxtFechaCompra);
            this.GroupBoxInformacionCompra.Controls.Add(this.lblFecha);
            this.GroupBoxInformacionCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxInformacionCompra.Location = new System.Drawing.Point(41, 61);
            this.GroupBoxInformacionCompra.Name = "GroupBoxInformacionCompra";
            this.GroupBoxInformacionCompra.Size = new System.Drawing.Size(354, 239);
            this.GroupBoxInformacionCompra.TabIndex = 118;
            this.GroupBoxInformacionCompra.TabStop = false;
            this.GroupBoxInformacionCompra.Text = "Información Compra";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::Presentacion.Properties.Resources.limpiar;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(537, 36);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(123, 31);
            this.btnLimpiar.TabIndex = 101;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::Presentacion.Properties.Resources.buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(390, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(123, 31);
            this.btnBuscar.TabIndex = 100;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtNumeroDocumentoCompra
            // 
            this.TxtNumeroDocumentoCompra.BackColor = System.Drawing.Color.LightGray;
            this.TxtNumeroDocumentoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroDocumentoCompra.Location = new System.Drawing.Point(174, 38);
            this.TxtNumeroDocumentoCompra.Name = "TxtNumeroDocumentoCompra";
            this.TxtNumeroDocumentoCompra.Size = new System.Drawing.Size(184, 27);
            this.TxtNumeroDocumentoCompra.TabIndex = 2;
            this.TxtNumeroDocumentoCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumeroCodigoCompra_KeyPress);
            // 
            // LblNumeroDocumentoCompra
            // 
            this.LblNumeroDocumentoCompra.AutoSize = true;
            this.LblNumeroDocumentoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumeroDocumentoCompra.Location = new System.Drawing.Point(37, 43);
            this.LblNumeroDocumentoCompra.Name = "LblNumeroDocumentoCompra";
            this.LblNumeroDocumentoCompra.Size = new System.Drawing.Size(109, 18);
            this.LblNumeroDocumentoCompra.TabIndex = 0;
            this.LblNumeroDocumentoCompra.Text = "N. Documento:";
            // 
            // GroupBoxBuscar
            // 
            this.GroupBoxBuscar.BackColor = System.Drawing.Color.White;
            this.GroupBoxBuscar.Controls.Add(this.btnLimpiar);
            this.GroupBoxBuscar.Controls.Add(this.btnBuscar);
            this.GroupBoxBuscar.Controls.Add(this.TxtNumeroDocumentoCompra);
            this.GroupBoxBuscar.Controls.Add(this.LblNumeroDocumentoCompra);
            this.GroupBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxBuscar.Location = new System.Drawing.Point(488, 61);
            this.GroupBoxBuscar.Name = "GroupBoxBuscar";
            this.GroupBoxBuscar.Size = new System.Drawing.Size(680, 95);
            this.GroupBoxBuscar.TabIndex = 117;
            this.GroupBoxBuscar.TabStop = false;
            // 
            // GroupBoxTransportista
            // 
            this.GroupBoxTransportista.BackColor = System.Drawing.Color.White;
            this.GroupBoxTransportista.Controls.Add(this.label2);
            this.GroupBoxTransportista.Controls.Add(this.TxtCedulaTransportista);
            this.GroupBoxTransportista.Controls.Add(this.TxtNombresTransportista);
            this.GroupBoxTransportista.Controls.Add(this.LblCedulaTransportista);
            this.GroupBoxTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxTransportista.Location = new System.Drawing.Point(488, 316);
            this.GroupBoxTransportista.Name = "GroupBoxTransportista";
            this.GroupBoxTransportista.Size = new System.Drawing.Size(680, 108);
            this.GroupBoxTransportista.TabIndex = 129;
            this.GroupBoxTransportista.TabStop = false;
            this.GroupBoxTransportista.Text = "Información Transportista";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 18);
            this.label2.TabIndex = 116;
            this.label2.Text = "Nombre Transportista:";
            // 
            // TxtCedulaTransportista
            // 
            this.TxtCedulaTransportista.BackColor = System.Drawing.Color.LightGray;
            this.TxtCedulaTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCedulaTransportista.Location = new System.Drawing.Point(61, 56);
            this.TxtCedulaTransportista.Name = "TxtCedulaTransportista";
            this.TxtCedulaTransportista.ReadOnly = true;
            this.TxtCedulaTransportista.Size = new System.Drawing.Size(210, 27);
            this.TxtCedulaTransportista.TabIndex = 113;
            // 
            // TxtNombresTransportista
            // 
            this.TxtNombresTransportista.BackColor = System.Drawing.Color.LightGray;
            this.TxtNombresTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresTransportista.Location = new System.Drawing.Point(372, 56);
            this.TxtNombresTransportista.Name = "TxtNombresTransportista";
            this.TxtNombresTransportista.ReadOnly = true;
            this.TxtNombresTransportista.Size = new System.Drawing.Size(210, 27);
            this.TxtNombresTransportista.TabIndex = 114;
            // 
            // LblCedulaTransportista
            // 
            this.LblCedulaTransportista.AutoSize = true;
            this.LblCedulaTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCedulaTransportista.Location = new System.Drawing.Point(60, 34);
            this.LblCedulaTransportista.Name = "LblCedulaTransportista";
            this.LblCedulaTransportista.Size = new System.Drawing.Size(149, 18);
            this.LblCedulaTransportista.TabIndex = 115;
            this.LblCedulaTransportista.Text = "Cédula Transportista:";
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.AutoScroll = true;
            this.PanelPrincipal.BackColor = System.Drawing.Color.White;
            this.PanelPrincipal.Controls.Add(this.GroupBoxSucursal);
            this.PanelPrincipal.Controls.Add(this.label1);
            this.PanelPrincipal.Controls.Add(this.GroupBoxInformacionCompra);
            this.PanelPrincipal.Controls.Add(this.GroupBoxTransportista);
            this.PanelPrincipal.Controls.Add(this.tablaDetallesCompras);
            this.PanelPrincipal.Controls.Add(this.GroupBoxCompra);
            this.PanelPrincipal.Controls.Add(this.GroupBoxBuscar);
            this.PanelPrincipal.Controls.Add(this.GroupBoxProveedor);
            this.PanelPrincipal.Location = new System.Drawing.Point(131, 23);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1212, 540);
            this.PanelPrincipal.TabIndex = 129;
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
            this.GroupBoxSucursal.TabIndex = 130;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 38);
            this.label1.TabIndex = 130;
            this.label1.Text = "Detalles compras";
            // 
            // VtnVerDetalleCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.PanelPrincipal);
            this.Name = "VtnVerDetalleCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver los detalles de las compras";
            this.Load += new System.EventHandler(this.VtnVerDetalleCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetallesCompras)).EndInit();
            this.GroupBoxCompra.ResumeLayout(false);
            this.GroupBoxCompra.PerformLayout();
            this.GroupBoxProveedor.ResumeLayout(false);
            this.GroupBoxProveedor.PerformLayout();
            this.GroupBoxInformacionCompra.ResumeLayout(false);
            this.GroupBoxInformacionCompra.PerformLayout();
            this.GroupBoxBuscar.ResumeLayout(false);
            this.GroupBoxBuscar.PerformLayout();
            this.GroupBoxTransportista.ResumeLayout(false);
            this.GroupBoxTransportista.PerformLayout();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.GroupBoxSucursal.ResumeLayout(false);
            this.GroupBoxSucursal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView tablaDetallesCompras;
        private System.Windows.Forms.TextBox TxtMontoTotal;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.GroupBox GroupBoxCompra;
        private System.Windows.Forms.Button btnDescargarPdf;
        private System.Windows.Forms.TextBox TxtCedulaProveedor;
        private System.Windows.Forms.Label lblNombreProovedor;
        private System.Windows.Forms.TextBox TxtNombresProveedor;
        private System.Windows.Forms.Label LblCedulaProveedor;
        private System.Windows.Forms.GroupBox GroupBoxProveedor;
        private System.Windows.Forms.TextBox TxtNombreCompletoUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox TxtTipoDocumento;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox TxtFechaCompra;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox GroupBoxInformacionCompra;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox TxtNumeroDocumentoCompra;
        private System.Windows.Forms.Label LblNumeroDocumentoCompra;
        private System.Windows.Forms.GroupBox GroupBoxBuscar;
        private System.Windows.Forms.GroupBox GroupBoxTransportista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCedulaTransportista;
        private System.Windows.Forms.TextBox TxtNombresTransportista;
        private System.Windows.Forms.Label LblCedulaTransportista;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.GroupBox GroupBoxSucursal;
        private System.Windows.Forms.TextBox TxtSucursal;
        private System.Windows.Forms.Label LblSucursal;
    }
}