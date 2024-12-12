namespace Presentacion
{
    partial class vtnOferta
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
            this.CmbProducto = new System.Windows.Forms.ComboBox();
            this.RtextDescripcion = new System.Windows.Forms.RichTextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.TxtDescuento = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.lblNombreOferta = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.lblOferta = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.CmbBuscar = new System.Windows.Forms.ComboBox();
            this.TxtIndice = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblDetallesOferta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.tablaOferta = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oferta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaOferta)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbProducto
            // 
            this.CmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProducto.FormattingEnabled = true;
            this.CmbProducto.Location = new System.Drawing.Point(30, 175);
            this.CmbProducto.Name = "CmbProducto";
            this.CmbProducto.Size = new System.Drawing.Size(280, 28);
            this.CmbProducto.TabIndex = 168;
            // 
            // RtextDescripcion
            // 
            this.RtextDescripcion.Location = new System.Drawing.Point(32, 282);
            this.RtextDescripcion.Name = "RtextDescripcion";
            this.RtextDescripcion.Size = new System.Drawing.Size(280, 70);
            this.RtextDescripcion.TabIndex = 167;
            this.RtextDescripcion.Text = "";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(30, 229);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(280, 27);
            this.TxtNombre.TabIndex = 166;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.txtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaFin.Location = new System.Drawing.Point(30, 431);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(280, 27);
            this.txtFechaFin.TabIndex = 165;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.Wheat;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(28, 408);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(98, 20);
            this.lblFechaFin.TabIndex = 164;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.BackColor = System.Drawing.Color.Wheat;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(28, 355);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(117, 20);
            this.lblFechaInicio.TabIndex = 163;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.txtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaInicio.Location = new System.Drawing.Point(30, 378);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(280, 27);
            this.txtFechaInicio.TabIndex = 162;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.BackColor = System.Drawing.Color.Wheat;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(28, 461);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(105, 20);
            this.lblDescuento.TabIndex = 161;
            this.lblDescuento.Text = "Descuento:";
            // 
            // TxtDescuento
            // 
            this.TxtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescuento.Location = new System.Drawing.Point(30, 484);
            this.TxtDescuento.Name = "TxtDescuento";
            this.TxtDescuento.Size = new System.Drawing.Size(280, 27);
            this.TxtDescuento.TabIndex = 160;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.Wheat;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscar.Location = new System.Drawing.Point(1355, 137);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(38, 30);
            this.BtnBuscar.TabIndex = 150;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.Wheat;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(26, 152);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(90, 20);
            this.lblProducto.TabIndex = 169;
            this.lblProducto.Text = "Producto:";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.Wheat;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(690, 490);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(164, 40);
            this.BtnLimpiar.TabIndex = 159;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(30, 537);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(280, 28);
            this.CmbEstado.TabIndex = 158;
            // 
            // lblNombreOferta
            // 
            this.lblNombreOferta.AutoSize = true;
            this.lblNombreOferta.BackColor = System.Drawing.Color.Wheat;
            this.lblNombreOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreOferta.Location = new System.Drawing.Point(28, 206);
            this.lblNombreOferta.Name = "lblNombreOferta";
            this.lblNombreOferta.Size = new System.Drawing.Size(182, 20);
            this.lblNombreOferta.TabIndex = 154;
            this.lblNombreOferta.Text = "Nombre de la oferta:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Wheat;
            this.BtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(1238, 490);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(164, 41);
            this.BtnEliminar.TabIndex = 145;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.Wheat;
            this.BtnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(971, 490);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(164, 41);
            this.BtnModificar.TabIndex = 144;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.Wheat;
            this.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(417, 490);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(164, 41);
            this.BtnAgregar.TabIndex = 143;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // lblOferta
            // 
            this.lblOferta.AutoSize = true;
            this.lblOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOferta.Location = new System.Drawing.Point(769, 43);
            this.lblOferta.Name = "lblOferta";
            this.lblOferta.Size = new System.Drawing.Size(365, 32);
            this.lblOferta.TabIndex = 142;
            this.lblOferta.Text = "Ofertas del supermercado";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(751, 140);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(108, 20);
            this.lblBuscar.TabIndex = 148;
            this.lblBuscar.Text = "Buscar por:";
            // 
            // CmbBuscar
            // 
            this.CmbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBuscar.FormattingEnabled = true;
            this.CmbBuscar.Location = new System.Drawing.Point(876, 137);
            this.CmbBuscar.Name = "CmbBuscar";
            this.CmbBuscar.Size = new System.Drawing.Size(221, 28);
            this.CmbBuscar.TabIndex = 147;
            // 
            // TxtIndice
            // 
            this.TxtIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIndice.Location = new System.Drawing.Point(224, 77);
            this.TxtIndice.Name = "TxtIndice";
            this.TxtIndice.Size = new System.Drawing.Size(36, 27);
            this.TxtIndice.TabIndex = 157;
            this.TxtIndice.Text = "-1";
            this.TxtIndice.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Wheat;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(28, 514);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(73, 20);
            this.lblEstado.TabIndex = 155;
            this.lblEstado.Text = "Estado:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Wheat;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(28, 259);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(116, 20);
            this.lblDescripcion.TabIndex = 153;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblDetallesOferta
            // 
            this.lblDetallesOferta.AutoSize = true;
            this.lblDetallesOferta.BackColor = System.Drawing.Color.Wheat;
            this.lblDetallesOferta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallesOferta.Location = new System.Drawing.Point(65, 27);
            this.lblDetallesOferta.Name = "lblDetallesOferta";
            this.lblDetallesOferta.Size = new System.Drawing.Size(219, 32);
            this.lblDetallesOferta.TabIndex = 152;
            this.lblDetallesOferta.Text = "Detalles Oferta";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 587);
            this.label2.TabIndex = 151;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(1114, 138);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(221, 27);
            this.TxtBuscar.TabIndex = 149;
            // 
            // tablaOferta
            // 
            this.tablaOferta.AllowUserToAddRows = false;
            this.tablaOferta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaOferta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaOferta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaOferta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.ID,
            this.Codigo,
            this.Oferta,
            this.IDPRODUCTO,
            this.Producto,
            this.Descripcion,
            this.FechaInicio,
            this.FechaFin,
            this.Descuento,
            this.EstadoValor,
            this.Estado});
            this.tablaOferta.Location = new System.Drawing.Point(417, 187);
            this.tablaOferta.MultiSelect = false;
            this.tablaOferta.Name = "tablaOferta";
            this.tablaOferta.ReadOnly = true;
            this.tablaOferta.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaOferta.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tablaOferta.RowTemplate.Height = 28;
            this.tablaOferta.Size = new System.Drawing.Size(978, 248);
            this.tablaOferta.TabIndex = 146;
            this.tablaOferta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaOferta_CellContentClick);
            this.tablaOferta.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaOferta_CellFormatting);
            this.tablaOferta.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TablaOferta_CellPainting);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.MinimumWidth = 6;
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Width = 30;
            // 
            // ID
            // 
            this.ID.HeaderText = "Id Oferta";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 50;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // Oferta
            // 
            this.Oferta.HeaderText = "Oferta";
            this.Oferta.MinimumWidth = 6;
            this.Oferta.Name = "Oferta";
            this.Oferta.ReadOnly = true;
            this.Oferta.Width = 180;
            // 
            // IDPRODUCTO
            // 
            this.IDPRODUCTO.HeaderText = "Id Producto";
            this.IDPRODUCTO.MinimumWidth = 6;
            this.IDPRODUCTO.Name = "IDPRODUCTO";
            this.IDPRODUCTO.ReadOnly = true;
            this.IDPRODUCTO.Visible = false;
            this.IDPRODUCTO.Width = 110;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 120;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 400;
            // 
            // FechaInicio
            // 
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.MinimumWidth = 6;
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 125;
            // 
            // FechaFin
            // 
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.MinimumWidth = 6;
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 90;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 90;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "Estado valor";
            this.EstadoValor.MinimumWidth = 6;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 87;
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(276, 77);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(34, 27);
            this.TxtId.TabIndex = 171;
            this.TxtId.Text = "0";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.Location = new System.Drawing.Point(30, 122);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(280, 27);
            this.TxtCodigo.TabIndex = 172;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.BackColor = System.Drawing.Color.Wheat;
            this.LblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigo.Location = new System.Drawing.Point(26, 99);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(73, 20);
            this.LblCodigo.TabIndex = 173;
            this.LblCodigo.Text = "Código:";
            // 
            // vtnOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.LblCodigo);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.CmbProducto);
            this.Controls.Add(this.RtextDescripcion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.txtFechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.TxtDescuento);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.lblNombreOferta);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.lblOferta);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.CmbBuscar);
            this.Controls.Add(this.TxtIndice);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblDetallesOferta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.tablaOferta);
            this.Name = "vtnOferta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver ofertas disponibles de los productos";
            this.Load += new System.EventHandler(this.vtnOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaOferta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.RichTextBox RtextDescripcion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker txtFechaInicio;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox TxtDescuento;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Label lblNombreOferta;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label lblOferta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox CmbBuscar;
        private System.Windows.Forms.TextBox TxtIndice;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblDetallesOferta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView tablaOferta;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oferta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}