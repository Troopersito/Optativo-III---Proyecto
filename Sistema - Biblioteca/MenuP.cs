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
    public partial class MenuP : Form
    {
        public MenuP()
        {
            InitializeComponent();
        }

        private void MenuP_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario MenuP
            this.Hide();

            // Crear e mostrar el formulario Libros
            Libros librosForm = new Libros();
            librosForm.FormClosed += (s, args) => this.Close(); // Cierra la aplicación cuando se cierra el formulario Libros
            librosForm.Show();
        }
    }
}
