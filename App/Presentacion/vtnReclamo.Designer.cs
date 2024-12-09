namespace Presentacion
{
    partial class VtnReclamo
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
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.txt6 = new System.Windows.Forms.RichTextBox();
            this.lblCorreoElectronico = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.lblReclamos = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.CmbBuscar = new System.Windows.Forms.ComboBox();
            this.TxtIndice = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.tablaReclamo = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoElectronicoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.TxtNombresCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaReclamo)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.Location = new System.Drawing.Point(30, 127);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(280, 27);
            this.TxtCodigo.TabIndex = 129;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.BackColor = System.Drawing.Color.Wheat;
            this.LblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigo.Location = new System.Drawing.Point(26, 104);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(73, 20);
            this.LblCodigo.TabIndex = 128;
            this.LblCodigo.Text = "Código:";
            // 
            // txt6
            // 
            this.txt6.Location = new System.Drawing.Point(30, 332);
            this.txt6.Name = "txt6";
            this.txt6.ReadOnly = true;
            this.txt6.Size = new System.Drawing.Size(280, 106);
            this.txt6.TabIndex = 127;
            this.txt6.Text = "";
            // 
            // lblCorreoElectronico
            // 
            this.lblCorreoElectronico.AutoSize = true;
            this.lblCorreoElectronico.BackColor = System.Drawing.Color.Wheat;
            this.lblCorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoElectronico.Location = new System.Drawing.Point(26, 241);
            this.lblCorreoElectronico.Name = "lblCorreoElectronico";
            this.lblCorreoElectronico.Size = new System.Drawing.Size(171, 20);
            this.lblCorreoElectronico.TabIndex = 126;
            this.lblCorreoElectronico.Text = "Correo electrónico:";
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.Wheat;
            this.BtnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(835, 490);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(164, 41);
            this.BtnModificar.TabIndex = 111;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
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
            this.BtnBuscar.TabIndex = 117;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // TxtCorreoElectronico
            // 
            this.TxtCorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreoElectronico.Location = new System.Drawing.Point(30, 264);
            this.TxtCorreoElectronico.Name = "TxtCorreoElectronico";
            this.TxtCorreoElectronico.ReadOnly = true;
            this.TxtCorreoElectronico.Size = new System.Drawing.Size(280, 27);
            this.TxtCorreoElectronico.TabIndex = 130;
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(28, 472);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(271, 28);
            this.CmbEstado.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Wheat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 120;
            this.label3.Text = "Descripción:";
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
            this.BtnEliminar.TabIndex = 112;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // lblReclamos
            // 
            this.lblReclamos.AutoSize = true;
            this.lblReclamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReclamos.Location = new System.Drawing.Point(707, 43);
            this.lblReclamos.Name = "lblReclamos";
            this.lblReclamos.Size = new System.Drawing.Size(352, 32);
            this.lblReclamos.TabIndex = 110;
            this.lblReclamos.Text = "Reclamos de los clientes";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(751, 140);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(108, 20);
            this.lblBuscar.TabIndex = 115;
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
            this.CmbBuscar.TabIndex = 114;
            // 
            // TxtIndice
            // 
            this.TxtIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIndice.Location = new System.Drawing.Point(224, 77);
            this.TxtIndice.Name = "TxtIndice";
            this.TxtIndice.Size = new System.Drawing.Size(36, 27);
            this.TxtIndice.TabIndex = 123;
            this.TxtIndice.Text = "-1";
            this.TxtIndice.Visible = false;
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(276, 77);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(34, 27);
            this.TxtId.TabIndex = 122;
            this.TxtId.Text = "0";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Wheat;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(26, 450);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(73, 20);
            this.lblEstado.TabIndex = 121;
            this.lblEstado.Text = "Estado:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.BackColor = System.Drawing.Color.Wheat;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(26, 174);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(90, 20);
            this.lblNombreCliente.TabIndex = 119;
            this.lblNombreCliente.Text = "Nombres:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 587);
            this.label2.TabIndex = 118;
            this.label2.Text = "Detalles Reclamo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(1114, 138);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(221, 27);
            this.TxtBuscar.TabIndex = 116;
            // 
            // tablaReclamo
            // 
            this.tablaReclamo.AllowUserToAddRows = false;
            this.tablaReclamo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaReclamo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaReclamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaReclamo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.ID,
            this.IDCLIENTE,
            this.DocumentoCliente,
            this.NombreCliente,
            this.CorreoElectronicoCliente,
            this.Descripcion,
            this.EstadoValor,
            this.Estado});
            this.tablaReclamo.Location = new System.Drawing.Point(417, 187);
            this.tablaReclamo.MultiSelect = false;
            this.tablaReclamo.Name = "tablaReclamo";
            this.tablaReclamo.ReadOnly = true;
            this.tablaReclamo.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaReclamo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tablaReclamo.RowTemplate.Height = 28;
            this.tablaReclamo.Size = new System.Drawing.Size(978, 248);
            this.tablaReclamo.TabIndex = 113;
            this.tablaReclamo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaReclamo_CellContentClick);
            this.tablaReclamo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tablaReclamo_CellFormatting);
            this.tablaReclamo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tablaReclamo_CellPainting);
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
            this.ID.HeaderText = "Id Reclamo";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 50;
            // 
            // IDCLIENTE
            // 
            this.IDCLIENTE.HeaderText = "Id del cliente";
            this.IDCLIENTE.MinimumWidth = 6;
            this.IDCLIENTE.Name = "IDCLIENTE";
            this.IDCLIENTE.ReadOnly = true;
            this.IDCLIENTE.Visible = false;
            this.IDCLIENTE.Width = 125;
            // 
            // DocumentoCliente
            // 
            this.DocumentoCliente.HeaderText = "No.Codigo";
            this.DocumentoCliente.MinimumWidth = 6;
            this.DocumentoCliente.Name = "DocumentoCliente";
            this.DocumentoCliente.ReadOnly = true;
            this.DocumentoCliente.Width = 120;
            // 
            // NombreCliente
            // 
            this.NombreCliente.HeaderText = "Cliente";
            this.NombreCliente.MinimumWidth = 6;
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.ReadOnly = true;
            this.NombreCliente.Width = 180;
            // 
            // CorreoElectronicoCliente
            // 
            this.CorreoElectronicoCliente.HeaderText = "Correo Electrónico";
            this.CorreoElectronicoCliente.MinimumWidth = 6;
            this.CorreoElectronicoCliente.Name = "CorreoElectronicoCliente";
            this.CorreoElectronicoCliente.ReadOnly = true;
            this.CorreoElectronicoCliente.Width = 180;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 500;
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
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.Wheat;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(417, 490);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(164, 41);
            this.BtnLimpiar.TabIndex = 125;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // TxtNombresCliente
            // 
            this.TxtNombresCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombresCliente.Location = new System.Drawing.Point(28, 197);
            this.TxtNombresCliente.Name = "TxtNombresCliente";
            this.TxtNombresCliente.ReadOnly = true;
            this.TxtNombresCliente.Size = new System.Drawing.Size(280, 27);
            this.TxtNombresCliente.TabIndex = 131;
            // 
            // VtnReclamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1402, 587);
            this.Controls.Add(this.TxtNombresCliente);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.LblCodigo);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.lblCorreoElectronico);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtCorreoElectronico);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.lblReclamos);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.CmbBuscar);
            this.Controls.Add(this.TxtIndice);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.tablaReclamo);
            this.Controls.Add(this.BtnLimpiar);
            this.Name = "VtnReclamo";
            this.Text = "Ver los reclamos de los clientes";
            this.Load += new System.EventHandler(this.vtnReclamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaReclamo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.RichTextBox txt6;
        private System.Windows.Forms.Label lblCorreoElectronico;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtCorreoElectronico;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Label lblReclamos;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox CmbBuscar;
        private System.Windows.Forms.TextBox TxtIndice;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.DataGridView tablaReclamo;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoElectronicoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.TextBox TxtNombresCliente;
    }
}