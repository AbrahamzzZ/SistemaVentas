﻿namespace Presentacion
{
    partial class VtnInventario
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblPaisOrigen = new System.Windows.Forms.Label();
            this.CmbProducto = new System.Windows.Forms.ComboBox();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.LblProducto = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblInventario = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.CmbBuscar = new System.Windows.Forms.ComboBox();
            this.TxtIndice = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TablaInventario = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZonaAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbZonaAlmacen = new System.Windows.Forms.ComboBox();
            this.TbBarraCantidadProducto = new System.Windows.Forms.TrackBar();
            this.lblCantidadProducto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbBarraCantidadProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Wheat;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(690, 490);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(164, 41);
            this.btnLimpiar.TabIndex = 127;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.Wheat;
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.Location = new System.Drawing.Point(417, 128);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(155, 41);
            this.btnExportarExcel.TabIndex = 126;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.BtnExportarExcel_Click);
            // 
            // lblPaisOrigen
            // 
            this.lblPaisOrigen.AutoSize = true;
            this.lblPaisOrigen.BackColor = System.Drawing.Color.Wheat;
            this.lblPaisOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaisOrigen.Location = new System.Drawing.Point(26, 390);
            this.lblPaisOrigen.Name = "lblPaisOrigen";
            this.lblPaisOrigen.Size = new System.Drawing.Size(221, 20);
            this.lblPaisOrigen.TabIndex = 124;
            this.lblPaisOrigen.Text = "Ubicación en el almacen:";
            // 
            // CmbProducto
            // 
            this.CmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProducto.FormattingEnabled = true;
            this.CmbProducto.Location = new System.Drawing.Point(30, 197);
            this.CmbProducto.Name = "CmbProducto";
            this.CmbProducto.Size = new System.Drawing.Size(280, 28);
            this.CmbProducto.TabIndex = 122;
            this.CmbProducto.SelectedIndexChanged += new System.EventHandler(this.CmbProducto_SelectedIndexChanged);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.Location = new System.Drawing.Point(30, 298);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.ReadOnly = true;
            this.TxtCantidad.Size = new System.Drawing.Size(280, 27);
            this.TxtCantidad.TabIndex = 121;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Wheat;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(26, 275);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(89, 20);
            this.lblCantidad.TabIndex = 117;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // LblProducto
            // 
            this.LblProducto.AutoSize = true;
            this.LblProducto.BackColor = System.Drawing.Color.Wheat;
            this.LblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProducto.Location = new System.Drawing.Point(26, 174);
            this.LblProducto.Name = "LblProducto";
            this.LblProducto.Size = new System.Drawing.Size(90, 20);
            this.LblProducto.TabIndex = 116;
            this.LblProducto.Text = "Producto:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Wheat;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(1232, 490);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(164, 41);
            this.btnEliminar.TabIndex = 108;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Wheat;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(971, 490);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(164, 41);
            this.btnModificar.TabIndex = 107;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Wheat;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(417, 490);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(164, 41);
            this.btnAgregar.TabIndex = 106;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // lblInventario
            // 
            this.lblInventario.AutoSize = true;
            this.lblInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventario.Location = new System.Drawing.Point(756, 43);
            this.lblInventario.Name = "lblInventario";
            this.lblInventario.Size = new System.Drawing.Size(400, 32);
            this.lblInventario.TabIndex = 105;
            this.lblInventario.Text = "Inventario del supermercado";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(751, 140);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(108, 20);
            this.lblBuscar.TabIndex = 111;
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
            this.CmbBuscar.TabIndex = 110;
            // 
            // TxtIndice
            // 
            this.TxtIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIndice.Location = new System.Drawing.Point(224, 77);
            this.TxtIndice.Name = "TxtIndice";
            this.TxtIndice.Size = new System.Drawing.Size(36, 27);
            this.TxtIndice.TabIndex = 120;
            this.TxtIndice.Text = "-1";
            this.TxtIndice.Visible = false;
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(272, 77);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(38, 27);
            this.TxtId.TabIndex = 119;
            this.TxtId.Text = "0";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 587);
            this.label2.TabIndex = 114;
            this.label2.Text = "Detalles Inventario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(1114, 138);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(221, 27);
            this.TxtBuscar.TabIndex = 112;
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
            this.BtnBuscar.TabIndex = 113;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TablaInventario
            // 
            this.TablaInventario.AllowUserToAddRows = false;
            this.TablaInventario.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.ID,
            this.IDPRODUCTO,
            this.NombreProductos,
            this.Cantidad,
            this.IdZona,
            this.ZonaAlmacen});
            this.TablaInventario.Location = new System.Drawing.Point(417, 187);
            this.TablaInventario.MultiSelect = false;
            this.TablaInventario.Name = "TablaInventario";
            this.TablaInventario.ReadOnly = true;
            this.TablaInventario.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TablaInventario.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaInventario.RowTemplate.Height = 28;
            this.TablaInventario.Size = new System.Drawing.Size(978, 248);
            this.TablaInventario.TabIndex = 130;
            this.TablaInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaInventario_CellContentClick);
            this.TablaInventario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaInventario_CellFormatting);
            this.TablaInventario.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TablaInventario_CellPainting);
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
            this.ID.HeaderText = "Id Inventario";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 50;
            // 
            // IDPRODUCTO
            // 
            this.IDPRODUCTO.HeaderText = "Id Producto";
            this.IDPRODUCTO.MinimumWidth = 6;
            this.IDPRODUCTO.Name = "IDPRODUCTO";
            this.IDPRODUCTO.ReadOnly = true;
            this.IDPRODUCTO.Visible = false;
            this.IDPRODUCTO.Width = 125;
            // 
            // NombreProductos
            // 
            this.NombreProductos.HeaderText = "Producto";
            this.NombreProductos.MinimumWidth = 6;
            this.NombreProductos.Name = "NombreProductos";
            this.NombreProductos.ReadOnly = true;
            this.NombreProductos.Width = 180;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 155;
            // 
            // IdZona
            // 
            this.IdZona.HeaderText = "Id Zona";
            this.IdZona.MinimumWidth = 6;
            this.IdZona.Name = "IdZona";
            this.IdZona.ReadOnly = true;
            this.IdZona.Visible = false;
            this.IdZona.Width = 125;
            // 
            // ZonaAlmacen
            // 
            this.ZonaAlmacen.HeaderText = "Zona en el almacén";
            this.ZonaAlmacen.MinimumWidth = 6;
            this.ZonaAlmacen.Name = "ZonaAlmacen";
            this.ZonaAlmacen.ReadOnly = true;
            this.ZonaAlmacen.Width = 200;
            // 
            // CmbZonaAlmacen
            // 
            this.CmbZonaAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbZonaAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbZonaAlmacen.FormattingEnabled = true;
            this.CmbZonaAlmacen.Location = new System.Drawing.Point(30, 413);
            this.CmbZonaAlmacen.Name = "CmbZonaAlmacen";
            this.CmbZonaAlmacen.Size = new System.Drawing.Size(280, 28);
            this.CmbZonaAlmacen.TabIndex = 131;
            // 
            // TbBarraCantidadProducto
            // 
            this.TbBarraCantidadProducto.BackColor = System.Drawing.Color.Wheat;
            this.TbBarraCantidadProducto.Location = new System.Drawing.Point(30, 331);
            this.TbBarraCantidadProducto.Name = "TbBarraCantidadProducto";
            this.TbBarraCantidadProducto.Size = new System.Drawing.Size(280, 56);
            this.TbBarraCantidadProducto.TabIndex = 132;
            this.TbBarraCantidadProducto.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TbBarraCantidadProducto.Scroll += new System.EventHandler(this.TbBarraCantidadProducto_Scroll);
            // 
            // lblCantidadProducto
            // 
            this.lblCantidadProducto.AutoSize = true;
            this.lblCantidadProducto.BackColor = System.Drawing.Color.Wheat;
            this.lblCantidadProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadProducto.Location = new System.Drawing.Point(26, 242);
            this.lblCantidadProducto.Name = "lblCantidadProducto";
            this.lblCantidadProducto.Size = new System.Drawing.Size(14, 20);
            this.lblCantidadProducto.TabIndex = 133;
            this.lblCantidadProducto.Text = ".";
            // 
            // VtnInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.lblCantidadProducto);
            this.Controls.Add(this.TbBarraCantidadProducto);
            this.Controls.Add(this.CmbZonaAlmacen);
            this.Controls.Add(this.TablaInventario);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.lblPaisOrigen);
            this.Controls.Add(this.CmbProducto);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.LblProducto);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblInventario);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.CmbBuscar);
            this.Controls.Add(this.TxtIndice);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.BtnBuscar);
            this.Name = "VtnInventario";
            this.Text = "Inventario del supermercado";
            this.Load += new System.EventHandler(this.VtnInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbBarraCantidadProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label lblPaisOrigen;
        private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label LblProducto;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblInventario;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox CmbBuscar;
        private System.Windows.Forms.TextBox TxtIndice;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.DataGridView TablaInventario;
        private System.Windows.Forms.ComboBox CmbZonaAlmacen;
        private System.Windows.Forms.TrackBar TbBarraCantidadProducto;
        private System.Windows.Forms.Label lblCantidadProducto;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZonaAlmacen;
    }
}