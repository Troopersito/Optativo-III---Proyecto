using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textPass_IconRightClick(object sender, EventArgs e)
        {
           

            if (textPass.UseSystemPasswordChar)
            {
                
                textPass.IconRight = Properties.Resources.view;
                textPass.UseSystemPasswordChar = false;
            }
            else
            {
                textPass.IconRight = Properties.Resources.hide;
                textPass.UseSystemPasswordChar = true;
                
                
            }
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            textPass.UseSystemPasswordChar = true;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Registro registroForm = new Registro();

            
            registroForm.Show();

            
            this.Hide();
        }
    }
}
