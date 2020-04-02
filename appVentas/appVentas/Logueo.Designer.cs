namespace appVentas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.USUARIO = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.CONTRASEÑA = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.ENTRAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // USUARIO
            // 
            this.USUARIO.AutoSize = true;
            this.USUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USUARIO.Location = new System.Drawing.Point(96, 36);
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.Size = new System.Drawing.Size(106, 25);
            this.USUARIO.TabIndex = 0;
            this.USUARIO.Text = "USUARIO";
            this.USUARIO.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(99, 63);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(323, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // CONTRASEÑA
            // 
            this.CONTRASEÑA.AutoSize = true;
            this.CONTRASEÑA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTRASEÑA.Location = new System.Drawing.Point(99, 133);
            this.CONTRASEÑA.Name = "CONTRASEÑA";
            this.CONTRASEÑA.Size = new System.Drawing.Size(157, 25);
            this.CONTRASEÑA.TabIndex = 2;
            this.CONTRASEÑA.Text = "CONTRASEÑA";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(99, 166);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(323, 20);
            this.txtContrasena.TabIndex = 3;
            // 
            // ENTRAR
            // 
            this.ENTRAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRAR.Location = new System.Drawing.Point(150, 225);
            this.ENTRAR.Name = "ENTRAR";
            this.ENTRAR.Size = new System.Drawing.Size(157, 50);
            this.ENTRAR.TabIndex = 4;
            this.ENTRAR.Text = "ENTRAR";
            this.ENTRAR.UseVisualStyleBackColor = true;
            this.ENTRAR.Click += new System.EventHandler(this.ENTRAR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(456, 316);
            this.Controls.Add(this.ENTRAR);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.CONTRASEÑA);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.USUARIO);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label USUARIO;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label CONTRASEÑA;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button ENTRAR;
    }
}

