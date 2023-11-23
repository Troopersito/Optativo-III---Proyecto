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
    public partial class accionesprestamos : Form
    {
        public accionesprestamos()
        {
            InitializeComponent();
        }

        private void registrodelibrosdevueltosbutton_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesprestamos)
            this.Hide();

            // Show the RegistroLibrosDevueltos form
            registrolibrosdevueltos registroLibrosDevueltosForm = new registrolibrosdevueltos();
            registroLibrosDevueltosForm.FormClosed += (s, args) => this.Close(); // Close the application when RegistroLibrosDevueltos form is closed
            registroLibrosDevueltosForm.Show();
        }

        private void Prestamosatrazados_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesprestamos)
            this.Hide();

            // Show the PrestamosAtrazados form
            Prestamosatrazados prestamosAtrazadosForm = new Prestamosatrazados();
            prestamosAtrazadosForm.FormClosed += (s, args) => this.Close(); // Close the application when PrestamosAtrazados form is closed
            prestamosAtrazadosForm.Show();
        }

        private void realizarprestamobutton_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesprestamos)
            this.Hide();

            // Show the FormularioPrestamo form
            formularioprestamo formularioPrestamoForm = new formularioprestamo();
            formularioPrestamoForm.FormClosed += (s, args) => this.Close(); // Close the application when FormularioPrestamo form is closed
            formularioPrestamoForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesprestamos)
            this.Hide();

            // Show the main menu form (MenuP)
            MenuP menuPForm = new MenuP();
            menuPForm.FormClosed += (s, args) => this.Close(); // Close the application when MenuP form is closed
            menuPForm.Show();
        }

        private void DevolverButton2_Click(object sender, EventArgs e)
        {
            // Hide the current form (actionsprestamos)
            this.Hide();

            // Show the Formnularioparadevolucion form
            Formnularioparadevolucion formDevolucion = new Formnularioparadevolucion();
            formDevolucion.FormClosed += (s, args) => this.Close(); // Close the application when Formnularioparadevolucion form is closed
            formDevolucion.Show();
        }
    }
}
