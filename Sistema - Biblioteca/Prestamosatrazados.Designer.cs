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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prestamosatrazados));
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
            this.atrasButton1.FillColor = System.Drawing.Color.Transparent;
            this.atrasButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atrasButton1.ForeColor = System.Drawing.Color.White;
            this.atrasButton1.Image = ((System.Drawing.Image)(resources.GetObject("atrasButton1.Image")));
            this.atrasButton1.Location = new System.Drawing.Point(11, 14);
            this.atrasButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.atrasButton1.Name = "atrasButton1";
            this.atrasButton1.Size = new System.Drawing.Size(101, 75);
            this.atrasButton1.TabIndex = 0;
            this.atrasButton1.Click += new System.EventHandler(this.atrasButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(153, 103);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(763, 336);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Prestamosatrazados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.atrasButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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