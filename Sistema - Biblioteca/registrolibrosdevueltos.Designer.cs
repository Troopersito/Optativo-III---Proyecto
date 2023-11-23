namespace Sistema___Biblioteca
{
    partial class registrolibrosdevueltos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registrolibrosdevueltos));
            this.atrasbutton = new Guna.UI2.WinForms.Guna2Button();
            this.registrolibrosdevueltosdataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.registrolibrosdevueltosdataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // atrasbutton
            // 
            this.atrasbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.atrasbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.atrasbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.atrasbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.atrasbutton.FillColor = System.Drawing.Color.Transparent;
            this.atrasbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atrasbutton.ForeColor = System.Drawing.Color.White;
            this.atrasbutton.Image = ((System.Drawing.Image)(resources.GetObject("atrasbutton.Image")));
            this.atrasbutton.Location = new System.Drawing.Point(3, 2);
            this.atrasbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.atrasbutton.Name = "atrasbutton";
            this.atrasbutton.Size = new System.Drawing.Size(101, 65);
            this.atrasbutton.TabIndex = 0;
            this.atrasbutton.Click += new System.EventHandler(this.atrasbutton_Click);
            // 
            // registrolibrosdevueltosdataGridView1
            // 
            this.registrolibrosdevueltosdataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registrolibrosdevueltosdataGridView1.Location = new System.Drawing.Point(152, 84);
            this.registrolibrosdevueltosdataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.registrolibrosdevueltosdataGridView1.Name = "registrolibrosdevueltosdataGridView1";
            this.registrolibrosdevueltosdataGridView1.RowHeadersWidth = 51;
            this.registrolibrosdevueltosdataGridView1.Size = new System.Drawing.Size(792, 228);
            this.registrolibrosdevueltosdataGridView1.TabIndex = 1;
            this.registrolibrosdevueltosdataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.registrolibrosdevueltosdataGridView1_CellContentClick);
            // 
            // registrolibrosdevueltos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.registrolibrosdevueltosdataGridView1);
            this.Controls.Add(this.atrasbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "registrolibrosdevueltos";
            this.Text = "registrolibrosdevueltos";
            ((System.ComponentModel.ISupportInitialize)(this.registrolibrosdevueltosdataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button atrasbutton;
        private System.Windows.Forms.DataGridView registrolibrosdevueltosdataGridView1;
    }
}