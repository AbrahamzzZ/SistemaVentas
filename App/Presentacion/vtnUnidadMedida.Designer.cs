namespace Presentacion
{
    partial class VtnUnidadMedida
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
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.CmBuscar = new System.Windows.Forms.ComboBox();
            this.lblPanel = new System.Windows.Forms.Label();
            this.tablaUnidadMedida = new System.Windows.Forms.DataGridView();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.TxtIndice = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblSimbolo = new System.Windows.Forms.Label();
            this.TxtSimbolo = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaUnidadMedida)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(30, 307);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(280, 28);
            this.CmbEstado.TabIndex = 108;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(1114, 138);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(230, 27);
            this.TxtBuscar.TabIndex = 100;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(751, 140);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(108, 20);
            this.lblBuscar.TabIndex = 99;
            this.lblBuscar.Text = "Buscar por:";
            // 
            // CmBuscar
            // 
            this.CmBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmBuscar.FormattingEnabled = true;
            this.CmBuscar.Location = new System.Drawing.Point(876, 137);
            this.CmBuscar.Name = "CmBuscar";
            this.CmBuscar.Size = new System.Drawing.Size(230, 28);
            this.CmBuscar.TabIndex = 98;
            // 
            // lblPanel
            // 
            this.lblPanel.BackColor = System.Drawing.Color.Wheat;
            this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanel.Location = new System.Drawing.Point(0, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPanel.Size = new System.Drawing.Size(341, 587);
            this.lblPanel.TabIndex = 97;
            this.lblPanel.Text = "Detalles de la Unidad Medida";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tablaUnidadMedida
            // 
            this.tablaUnidadMedida.AllowUserToAddRows = false;
            this.tablaUnidadMedida.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaUnidadMedida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaUnidadMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaUnidadMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.ID,
            this.Codigo,
            this.Descripcion,
            this.Simbolo,
            this.EstadoValor,
            this.Estado});
            this.tablaUnidadMedida.Location = new System.Drawing.Point(417, 187);
            this.tablaUnidadMedida.MultiSelect = false;
            this.tablaUnidadMedida.Name = "tablaUnidadMedida";
            this.tablaUnidadMedida.ReadOnly = true;
            this.tablaUnidadMedida.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaUnidadMedida.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaUnidadMedida.RowTemplate.Height = 28;
            this.tablaUnidadMedida.Size = new System.Drawing.Size(978, 248);
            this.tablaUnidadMedida.TabIndex = 96;
            this.tablaUnidadMedida.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaUnidadMedida_CellContentClick);
            this.tablaUnidadMedida.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaUnidadMedida_CellFormatting);
            this.tablaUnidadMedida.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TablaUnidadMedida_CellPainting);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(-137, 488);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(73, 20);
            this.lblEstado.TabIndex = 91;
            this.lblEstado.Text = "Estado:";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(-137, 334);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(62, 20);
            this.lblClave.TabIndex = 89;
            this.lblClave.Text = "Clave:";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.Wheat;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(690, 490);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(164, 41);
            this.BtnLimpiar.TabIndex = 109;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // TxtIndice
            // 
            this.TxtIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIndice.Location = new System.Drawing.Point(224, 88);
            this.TxtIndice.Name = "TxtIndice";
            this.TxtIndice.Size = new System.Drawing.Size(36, 27);
            this.TxtIndice.TabIndex = 107;
            this.TxtIndice.Text = "-1";
            this.TxtIndice.Visible = false;
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(276, 88);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(34, 27);
            this.TxtId.TabIndex = 106;
            this.TxtId.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Wheat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "Estado: ";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Wheat;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(26, 178);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(122, 20);
            this.lblDescripcion.TabIndex = 104;
            this.lblDescripcion.Text = "Descripción: ";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(30, 201);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(280, 27);
            this.TxtDescripcion.TabIndex = 103;
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
            this.BtnBuscar.TabIndex = 101;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Wheat;
            this.BtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(1232, 490);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(164, 41);
            this.BtnEliminar.TabIndex = 95;
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
            this.BtnModificar.TabIndex = 94;
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
            this.BtnAgregar.TabIndex = 93;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(725, 43);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(540, 32);
            this.lblCategoria.TabIndex = 92;
            this.lblCategoria.Text = "Unidades de medidas de los productos";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(-135, 406);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(43, 20);
            this.lblRol.TabIndex = 90;
            this.lblRol.Text = "Rol:";
            // 
            // lblSimbolo
            // 
            this.lblSimbolo.AutoSize = true;
            this.lblSimbolo.BackColor = System.Drawing.Color.Wheat;
            this.lblSimbolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolo.Location = new System.Drawing.Point(26, 231);
            this.lblSimbolo.Name = "lblSimbolo";
            this.lblSimbolo.Size = new System.Drawing.Size(88, 20);
            this.lblSimbolo.TabIndex = 110;
            this.lblSimbolo.Text = "Símbolo: ";
            // 
            // TxtSimbolo
            // 
            this.TxtSimbolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSimbolo.Location = new System.Drawing.Point(30, 254);
            this.TxtSimbolo.Name = "TxtSimbolo";
            this.TxtSimbolo.Size = new System.Drawing.Size(280, 27);
            this.TxtSimbolo.TabIndex = 111;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.Location = new System.Drawing.Point(30, 148);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(280, 27);
            this.TxtCodigo.TabIndex = 112;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.BackColor = System.Drawing.Color.Wheat;
            this.LblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigo.Location = new System.Drawing.Point(33, 125);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(73, 20);
            this.LblCodigo.TabIndex = 113;
            this.LblCodigo.Text = "Código:";
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
            this.ID.HeaderText = "Id Unidad Medida";
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
            this.Codigo.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 155;
            // 
            // Simbolo
            // 
            this.Simbolo.HeaderText = "Símbolo";
            this.Simbolo.MinimumWidth = 6;
            this.Simbolo.Name = "Simbolo";
            this.Simbolo.ReadOnly = true;
            this.Simbolo.Width = 75;
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
            this.Estado.Width = 90;
            // 
            // VtnUnidadMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.LblCodigo);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.TxtSimbolo);
            this.Controls.Add(this.lblSimbolo);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.CmBuscar);
            this.Controls.Add(this.tablaUnidadMedida);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.TxtIndice);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblPanel);
            this.Name = "VtnUnidadMedida";
            this.Text = "vtnUnidadMedidas";
            this.Load += new System.EventHandler(this.VtnUnidadMedida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaUnidadMedida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox CmBuscar;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.DataGridView tablaUnidadMedida;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.TextBox TxtIndice;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblSimbolo;
        private System.Windows.Forms.TextBox TxtSimbolo;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}