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
    public partial class Libros : Form
    {
        public Libros()
        {
            InitializeComponent();
        }

        private void Libros_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            // Ocultar el formulario actual (Libros)
            this.Hide();

            // Mostrar el formulario MenuP
            MenuP menuPForm = new MenuP();
            menuPForm.FormClosed += (s, args) => this.Close(); // Cierra la aplicación cuando se cierra el formulario MenuP
            menuPForm.Show();
        }
    }
}
