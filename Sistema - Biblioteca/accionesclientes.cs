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
    public partial class accionesclientes : Form
    {
        public accionesclientes()
        {
            InitializeComponent();
        }

        private void misprestamosButton1_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesclientes)
            this.Hide();

            // Create and show the MisPrestamos form
            misprestamos misPrestamosForm = new misprestamos();
            misPrestamosForm.FormClosed += (s, args) => this.Close(); // Close the application when MisPrestamos form is closed
            misPrestamosForm.Show();
        }

        private void facturasmoraButton1_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesclientes)
            this.Hide();

            // Create and show the Factura form
            Factura facturaForm = new Factura();
            facturaForm.FormClosed += (s, args) => this.Close(); // Close the application when Factura form is closed
            facturaForm.Show();
        }

        private void atrasbutton_Click(object sender, EventArgs e)
        {
            // Hide the current form (accionesclientes)
            this.Hide();

            // Show the main menu form (MenuP)
            MenuP menuPForm = new MenuP();
            menuPForm.FormClosed += (s, args) => this.Close(); // Close the application when MenuP form is closed
            menuPForm.Show();
        }
    }
}

