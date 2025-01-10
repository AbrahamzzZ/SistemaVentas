namespace Presentacion.Modales
{
    partial class vtnModalesOfertas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vtnModalesOfertas));
            this.lblListaOfertas = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.CmbBuscar = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.TablaOfertas = new System.Windows.Forms.DataGridView();
            this.IdOFERTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oferta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaOfertas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListaOfertas
            // 
            this.lblListaOfertas.AutoSize = true;
            this.lblListaOfertas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaOfertas.Location = new System.Drawing.Point(167, 16);
            this.lblListaOfertas.Name = "lblListaOfertas";
            this.lblListaOfertas.Size = new System.Drawing.Size(230, 32);
            this.lblListaOfertas.TabIndex = 102;
            this.lblListaOfertas.Text = "Lista de Ofertas";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.Image = global::Presentacion.Properties.Resources.buscar;
            this.BtnBuscar.Location = new System.Drawing.Point(530, 76);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(35, 31);
            this.BtnBuscar.TabIndex = 101;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(338, 80);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(180, 27);
            this.TxtBuscar.TabIndex = 100;
            // 
            // CmbBuscar
            // 
            this.CmbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBuscar.FormattingEnabled = true;
            this.CmbBuscar.Location = new System.Drawing.Point(141, 80);
            this.CmbBuscar.Name = "CmbBuscar";
            this.CmbBuscar.Size = new System.Drawing.Size(178, 28);
            this.CmbBuscar.TabIndex = 99;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(12, 82);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(108, 20);
            this.lblBuscar.TabIndex = 98;
            this.lblBuscar.Text = "Buscar por:";
            // 
            // TablaOfertas
            // 
            this.TablaOfertas.AllowUserToAddRows = false;
            this.TablaOfertas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaOfertas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaOfertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOFERTA,
            this.Oferta,
            this.Producto,
            this.Descuento,
            this.Estado});
            this.TablaOfertas.Location = new System.Drawing.Point(12, 123);
            this.TablaOfertas.MultiSelect = false;
            this.TablaOfertas.Name = "TablaOfertas";
            this.TablaOfertas.ReadOnly = true;
            this.TablaOfertas.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TablaOfertas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaOfertas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TablaOfertas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.TablaOfertas.RowTemplate.Height = 28;
            this.TablaOfertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaOfertas.Size = new System.Drawing.Size(553, 324);
            this.TablaOfertas.TabIndex = 97;
            this.TablaOfertas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaOfertas_CellDoubleClick);
            this.TablaOfertas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaOfertas_CellFormatting);
            // 
            // IdOFERTA
            // 
            this.IdOFERTA.HeaderText = "Id";
            this.IdOFERTA.MinimumWidth = 6;
            this.IdOFERTA.Name = "IdOFERTA";
            this.IdOFERTA.ReadOnly = true;
            this.IdOFERTA.Visible = false;
            this.IdOFERTA.Width = 120;
            // 
            // Oferta
            // 
            this.Oferta.HeaderText = "Oferta";
            this.Oferta.MinimumWidth = 6;
            this.Oferta.Name = "Oferta";
            this.Oferta.ReadOnly = true;
            this.Oferta.Width = 130;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 125;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 125;
            // 
            // vtnModalesOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(577, 463);
            this.Controls.Add(this.lblListaOfertas);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.CmbBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.TablaOfertas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "vtnModalesOfertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados de las ofertas";
            this.Load += new System.EventHandler(this.VtnModalesOfertas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaOfertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListaOfertas;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.ComboBox CmbBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView TablaOfertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOFERTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oferta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}