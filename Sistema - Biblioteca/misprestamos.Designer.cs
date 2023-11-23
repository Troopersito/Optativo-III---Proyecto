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
            this.dataGridView2.Location = new System.Drawing.Point(88, 92);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(997, 449);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
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
            this.atrasButton1.Location = new System.Drawing.Point(33, 26);
            this.atrasButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.atrasButton1.Name = "atrasButton1";
            this.atrasButton1.Size = new System.Drawing.Size(79, 59);
            this.atrasButton1.TabIndex = 2;
            this.atrasButton1.Click += new System.EventHandler(this.atrasButton1_Click_1);
            // 
            // misprestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 612);
            this.Controls.Add(this.atrasButton1);
            this.Controls.Add(this.dataGridView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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