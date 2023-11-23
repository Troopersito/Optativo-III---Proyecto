namespace Sistema___Biblioteca
{
    partial class accionesclientes
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accionesclientes));
            this.misprestamosButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.facturasmoraButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.atrasbutton = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // misprestamosButton1
            // 
            this.misprestamosButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.misprestamosButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.misprestamosButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.misprestamosButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.misprestamosButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.misprestamosButton1.ForeColor = System.Drawing.Color.White;
            this.misprestamosButton1.Location = new System.Drawing.Point(169, 252);
            this.misprestamosButton1.Name = "misprestamosButton1";
            this.misprestamosButton1.Size = new System.Drawing.Size(221, 62);
            this.misprestamosButton1.TabIndex = 0;
            this.misprestamosButton1.Text = "Mis prestamos";
            this.misprestamosButton1.Click += new System.EventHandler(this.misprestamosButton1_Click);
            // 
            // facturasmoraButton1
            // 
            this.facturasmoraButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.facturasmoraButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.facturasmoraButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.facturasmoraButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.facturasmoraButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.facturasmoraButton1.ForeColor = System.Drawing.Color.White;
            this.facturasmoraButton1.Location = new System.Drawing.Point(480, 252);
            this.facturasmoraButton1.Name = "facturasmoraButton1";
            this.facturasmoraButton1.Size = new System.Drawing.Size(221, 62);
            this.facturasmoraButton1.TabIndex = 1;
            this.facturasmoraButton1.Text = "Facturas por mora";
            this.facturasmoraButton1.Click += new System.EventHandler(this.facturasmoraButton1_Click);
            // 
            // atrasbutton
            // 
            this.atrasbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.atrasbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.atrasbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.atrasbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.atrasbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atrasbutton.ForeColor = System.Drawing.Color.White;
            this.atrasbutton.Image = ((System.Drawing.Image)(resources.GetObject("atrasbutton.Image")));
            this.atrasbutton.Location = new System.Drawing.Point(10, 14);
            this.atrasbutton.Name = "atrasbutton";
            this.atrasbutton.Size = new System.Drawing.Size(68, 52);
            this.atrasbutton.TabIndex = 2;
            this.atrasbutton.Click += new System.EventHandler(this.atrasbutton_Click);
            // 
            // accionesclientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 532);
            this.Controls.Add(this.atrasbutton);
            this.Controls.Add(this.facturasmoraButton1);
            this.Controls.Add(this.misprestamosButton1);
            this.Name = "accionesclientes";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button misprestamosButton1;
        private Guna.UI2.WinForms.Guna2Button facturasmoraButton1;
        private Guna.UI2.WinForms.Guna2Button atrasbutton;
    }
}
