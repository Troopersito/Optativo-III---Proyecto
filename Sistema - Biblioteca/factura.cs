using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void MostrarTicket()
        {
            // Crear una cadena para almacenar el contenido del ticket
            string ticketContent = "";

            // Construir el contenido del ticket a partir de los datos en el DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Verificar si la celda tiene un valor antes de intentar acceder a él
                    if (cell.Value != null)
                    {
                        ticketContent += cell.Value.ToString() + "\t";
                    }
                    else
                    {
                        ticketContent += "NULL\t";
                    }
                }

                ticketContent += Environment.NewLine;
            }

            // Mostrar el ticket en un cuadro de diálogo
            MessageBox.Show(ticketContent, "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            MostrarTicket();
        }
    }
}
