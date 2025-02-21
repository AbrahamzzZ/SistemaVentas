namespace Presentacion
{
    partial class VtnRestablecerClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VtnRestablecerClave));
            this.LblRestablecerClave = new System.Windows.Forms.Label();
            this.LblCorreoElectronico = new System.Windows.Forms.Label();
            this.TxtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.BtnEnviarCorreoElectronico = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtToken = new System.Windows.Forms.TextBox();
            this.BtnEnviarToken = new System.Windows.Forms.Button();
            this.LblNuevaClave = new System.Windows.Forms.Label();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.BtnCambiarClave = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblRestablecerClave
            // 
            this.LblRestablecerClave.AutoSize = true;
            this.LblRestablecerClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRestablecerClave.Location = new System.Drawing.Point(133, 44);
            this.LblRestablecerClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRestablecerClave.Name = "LblRestablecerClave";
            this.LblRestablecerClave.Size = new System.Drawing.Size(280, 29);
            this.LblRestablecerClave.TabIndex = 9;
            this.LblRestablecerClave.Text = "Recuperación de clave";
            // 
            // LblCorreoElectronico
            // 
            this.LblCorreoElectronico.AutoSize = true;
            this.LblCorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCorreoElectronico.Location = new System.Drawing.Point(27, 196);
            this.LblCorreoElectronico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCorreoElectronico.Name = "LblCorreoElectronico";
            this.LblCorreoElectronico.Size = new System.Drawing.Size(265, 20);
            this.LblCorreoElectronico.TabIndex = 12;
            this.LblCorreoElectronico.Text = "Ingrese su Correo electrónico:";
            // 
            // TxtCorreoElectronico
            // 
            this.TxtCorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorreoElectronico.Location = new System.Drawing.Point(30, 223);
            this.TxtCorreoElectronico.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCorreoElectronico.Name = "TxtCorreoElectronico";
            this.TxtCorreoElectronico.Size = new System.Drawing.Size(300, 26);
            this.TxtCorreoElectronico.TabIndex = 13;
            // 
            // BtnEnviarCorreoElectronico
            // 
            this.BtnEnviarCorreoElectronico.BackColor = System.Drawing.Color.Wheat;
            this.BtnEnviarCorreoElectronico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnviarCorreoElectronico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviarCorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarCorreoElectronico.Location = new System.Drawing.Point(385, 216);
            this.BtnEnviarCorreoElectronico.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEnviarCorreoElectronico.Name = "BtnEnviarCorreoElectronico";
            this.BtnEnviarCorreoElectronico.Size = new System.Drawing.Size(135, 35);
            this.BtnEnviarCorreoElectronico.TabIndex = 14;
            this.BtnEnviarCorreoElectronico.Text = "Enviar";
            this.BtnEnviarCorreoElectronico.UseVisualStyleBackColor = false;
            this.BtnEnviarCorreoElectronico.Click += new System.EventHandler(this.BtnEnviarCorreoElectronico_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 283);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ingresar Token:";
            // 
            // TxtToken
            // 
            this.TxtToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtToken.Location = new System.Drawing.Point(30, 308);
            this.TxtToken.Margin = new System.Windows.Forms.Padding(4);
            this.TxtToken.Name = "TxtToken";
            this.TxtToken.Size = new System.Drawing.Size(300, 26);
            this.TxtToken.TabIndex = 16;
            // 
            // BtnEnviarToken
            // 
            this.BtnEnviarToken.BackColor = System.Drawing.Color.Wheat;
            this.BtnEnviarToken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnviarToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviarToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarToken.Location = new System.Drawing.Point(385, 303);
            this.BtnEnviarToken.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEnviarToken.Name = "BtnEnviarToken";
            this.BtnEnviarToken.Size = new System.Drawing.Size(135, 35);
            this.BtnEnviarToken.TabIndex = 17;
            this.BtnEnviarToken.Text = "Enviar";
            this.BtnEnviarToken.UseVisualStyleBackColor = false;
            this.BtnEnviarToken.Click += new System.EventHandler(this.BtnEnviarToken_Click);
            // 
            // LblNuevaClave
            // 
            this.LblNuevaClave.AutoSize = true;
            this.LblNuevaClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNuevaClave.Location = new System.Drawing.Point(27, 375);
            this.LblNuevaClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNuevaClave.Name = "LblNuevaClave";
            this.LblNuevaClave.Size = new System.Drawing.Size(211, 20);
            this.LblNuevaClave.TabIndex = 18;
            this.LblNuevaClave.Text = "Ingrese su nueva Clave:";
            // 
            // TxtClave
            // 
            this.TxtClave.Enabled = false;
            this.TxtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClave.Location = new System.Drawing.Point(30, 401);
            this.TxtClave.Margin = new System.Windows.Forms.Padding(4);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(300, 26);
            this.TxtClave.TabIndex = 19;
            // 
            // BtnCambiarClave
            // 
            this.BtnCambiarClave.BackColor = System.Drawing.Color.Wheat;
            this.BtnCambiarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCambiarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarClave.Location = new System.Drawing.Point(385, 395);
            this.BtnCambiarClave.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCambiarClave.Name = "BtnCambiarClave";
            this.BtnCambiarClave.Size = new System.Drawing.Size(135, 35);
            this.BtnCambiarClave.TabIndex = 20;
            this.BtnCambiarClave.Text = "Cambiar";
            this.BtnCambiarClave.UseVisualStyleBackColor = false;
            this.BtnCambiarClave.Click += new System.EventHandler(this.BtnCambiarClave_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(27, 105);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(451, 60);
            this.lblMensaje.TabIndex = 21;
            this.lblMensaje.Text = "Si ha olvidado su clave, puede restablecerla ingresando su \r\ncorreo electrónico. " +
    "Recibirá un token que podrá utilizar \r\npara cambiar su clave.";
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.BackColor = System.Drawing.Color.Wheat;
            this.BtnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegresar.Location = new System.Drawing.Point(205, 487);
            this.BtnRegresar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(135, 35);
            this.BtnRegresar.TabIndex = 22;
            this.BtnRegresar.Text = "Regresar";
            this.BtnRegresar.UseVisualStyleBackColor = false;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            // 
            // VtnRestablecerClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Controls.Add(this.BtnRegresar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.BtnCambiarClave);
            this.Controls.Add(this.TxtClave);
            this.Controls.Add(this.LblNuevaClave);
            this.Controls.Add(this.BtnEnviarToken);
            this.Controls.Add(this.TxtToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnEnviarCorreoElectronico);
            this.Controls.Add(this.TxtCorreoElectronico);
            this.Controls.Add(this.LblCorreoElectronico);
            this.Controls.Add(this.LblRestablecerClave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VtnRestablecerClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restablecer ClaveEncriptada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblRestablecerClave;
        private System.Windows.Forms.Label LblCorreoElectronico;
        private System.Windows.Forms.TextBox TxtCorreoElectronico;
        private System.Windows.Forms.Button BtnEnviarCorreoElectronico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtToken;
        private System.Windows.Forms.Button BtnEnviarToken;
        private System.Windows.Forms.Label LblNuevaClave;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.Button BtnCambiarClave;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button BtnRegresar;
    }
}