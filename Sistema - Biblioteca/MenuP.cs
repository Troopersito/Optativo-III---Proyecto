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
        public int LoggedInUserId { get; set; }


        private Login loginForm;
        public MenuP()
        {
            InitializeComponent();
        }

        public void SetLoginForm(Login loginForm)
        {
            this.loginForm = loginForm;
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

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro que quieres cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // Crea una nueva instancia del formulario de login si no hay una referencia válida
                if (loginForm == null || loginForm.IsDisposed)
                {
                    loginForm = new Login();
                }

                // Muestra el formulario de login
                loginForm.Show();

                // Cierra el formulario actual
                this.Close();

                // Reinicia la aplicación
                Application.Restart();
            }
            // Si el usuario elige "No", no hacemos nada
        }


        private void Clientesbutton_Click(object sender, EventArgs e)
        {
            
                // Hide the current form (MenuP)
                this.Hide();

                // Create and show the accionesclientes form
                accionesclientes accionesClientesForm = new accionesclientes();
                accionesClientesForm.FormClosed += (s, args) => this.Close(); // Close the application when accionesclientes form is closed
                accionesClientesForm.Show();
            

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Hide the current form (MenuP)
            this.Hide();

            // Show the accionesprestamos form
            accionesprestamos accionesPrestamosForm = new accionesprestamos();
            accionesPrestamosForm.FormClosed += (s, args) => this.Close(); // Close the application when accionesprestamos form is closed
            accionesPrestamosForm.Show();
        }
    }
}
