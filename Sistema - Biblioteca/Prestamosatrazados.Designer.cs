namespace Sistema___Biblioteca
{
    partial class Prestamosatrazados
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
            this.atrasButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // atrasButton1
            // 
            this.atrasButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.atrasButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.atrasButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.atrasButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.atrasButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atrasButton1.ForeColor = System.Drawing.Color.White;
            this.atrasButton1.Location = new System.Drawing.Point(8, 11);
            this.atrasButton1.Name = "atrasButton1";
            this.atrasButton1.Size = new System.Drawing.Size(76, 61);
            this.atrasButton1.TabIndex = 0;
            this.atrasButton1.Text = "AtrasButton1";
            this.atrasButton1.Click += new System.EventHandler(this.atrasButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(115, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(572, 273);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Prestamosatrazados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.atrasButton1);
            this.Name = "Prestamosatrazados";
            this.Text = "Prestamosatrazados";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button atrasButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}