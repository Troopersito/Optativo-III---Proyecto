namespace Sistema___Biblioteca
{
    partial class factura
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
            this.atrasbutton = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridViewfactura = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfactura)).BeginInit();
            this.SuspendLayout();
            // 
            // atrasbutton
            // 
            this.atrasbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.atrasbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.atrasbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.atrasbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.atrasbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atrasbutton.ForeColor = System.Drawing.Color.White;
            this.atrasbutton.Location = new System.Drawing.Point(25, 10);
            this.atrasbutton.Name = "atrasbutton";
            this.atrasbutton.Size = new System.Drawing.Size(93, 60);
            this.atrasbutton.TabIndex = 1;
            this.atrasbutton.Text = "guna2Button1";
            this.atrasbutton.Click += new System.EventHandler(this.atrasbutton_Click);
            // 
            // dataGridViewfactura
            // 
            this.dataGridViewfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewfactura.Location = new System.Drawing.Point(80, 108);
            this.dataGridViewfactura.Name = "dataGridViewfactura";
            this.dataGridViewfactura.Size = new System.Drawing.Size(645, 294);
            this.dataGridViewfactura.TabIndex = 2;
            this.dataGridViewfactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewfactura_CellContentClick);
            // 
            // factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewfactura);
            this.Controls.Add(this.atrasbutton);
            this.Name = "factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "factura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfactura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button atrasbutton;
        private System.Windows.Forms.DataGridView dataGridViewfactura;
    }
}