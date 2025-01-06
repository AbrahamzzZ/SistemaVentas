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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.tablaOfertas = new System.Windows.Forms.DataGridView();
            this.IdOFERTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oferta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaOfertas)).BeginInit();
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
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = global::Presentacion.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(530, 76);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 31);
            this.btnBuscar.TabIndex = 101;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.Location = new System.Drawing.Point(338, 80);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(180, 27);
            this.txt1.TabIndex = 100;
            // 
            // cmb1
            // 
            this.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb1.FormattingEnabled = true;
            this.cmb1.Location = new System.Drawing.Point(141, 80);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(178, 28);
            this.cmb1.TabIndex = 99;
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
            // tablaOfertas
            // 
            this.tablaOfertas.AllowUserToAddRows = false;
            this.tablaOfertas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaOfertas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaOfertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOFERTA,
            this.Oferta,
            this.Producto,
            this.Descuento,
            this.Estado});
            this.tablaOfertas.Location = new System.Drawing.Point(12, 123);
            this.tablaOfertas.MultiSelect = false;
            this.tablaOfertas.Name = "tablaOfertas";
            this.tablaOfertas.ReadOnly = true;
            this.tablaOfertas.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaOfertas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaOfertas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tablaOfertas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaOfertas.RowTemplate.Height = 28;
            this.tablaOfertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaOfertas.Size = new System.Drawing.Size(553, 324);
            this.tablaOfertas.TabIndex = 97;
            this.tablaOfertas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaOfertas_CellDoubleClick);
            this.tablaOfertas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaOfertas_CellFormatting);
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
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.cmb1);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.tablaOfertas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "vtnModalesOfertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados de las ofertas";
            this.Load += new System.EventHandler(this.VtnModalesOfertas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaOfertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListaOfertas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.ComboBox cmb1;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView tablaOfertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOFERTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oferta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}