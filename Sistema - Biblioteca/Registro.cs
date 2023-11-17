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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

      

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            textPass.UseSystemPasswordChar = true;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox3.UseSystemPasswordChar = true;
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

        private void guna2TextBox3_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBox3.UseSystemPasswordChar)
            {

                guna2TextBox3.IconRight = Properties.Resources.view;
                guna2TextBox3.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox3.IconRight = Properties.Resources.hide;
                guna2TextBox3.UseSystemPasswordChar = true;


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login LogintroForm = new Login();


            LogintroForm.Show();


            this.Hide();
        }
    }
}
