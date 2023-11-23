namespace Sistema___Biblioteca
{
    partial class misprestamos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(misprestamos));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.atrasButton1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(66, 75);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(748, 365);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // atrasButton1
            // 
            this.atrasButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.atrasButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.atrasButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.atrasButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.atrasButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atrasButton1.ForeColor = System.Drawing.Color.White;
            this.atrasButton1.Image = ((System.Drawing.Image)(resources.GetObject("atrasButton1.Image")));
            this.atrasButton1.Location = new System.Drawing.Point(25, 21);
            this.atrasButton1.Name = "atrasButton1";
            this.atrasButton1.Size = new System.Drawing.Size(59, 48);
            this.atrasButton1.TabIndex = 2;
            this.atrasButton1.Click += new System.EventHandler(this.atrasButton1_Click_1);
            // 
            // misprestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 497);
            this.Controls.Add(this.atrasButton1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "misprestamos";
            this.Text = "misprestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private Guna.UI2.WinForms.Guna2Button atrasButton1;
    }
}