using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Formnularioparadevolucion : Form
    {
        public Formnularioparadevolucion()
        {
            InitializeComponent();
        }

        private void ATRASButton1_Click(object sender, EventArgs e)
        {
            // Hide the current form (Formnularioparadevolucion)
            this.Hide();

            // Show the accionesprestamos form
            accionesprestamos accionesPrestamosForm = new accionesprestamos();
            accionesPrestamosForm.FormClosed += (s, args) => this.Close(); // Close the application when accionesprestamos form is closed
            accionesPrestamosForm.Show();
        }

        private void CONFIRMARDEVOLUCIONButton2_Click(object sender, EventArgs e)
        {
            string idLibro = IDLIBROTextBox1.Text;
            string titulo = TITULOTextBox2.Text;

            // Validate that both IDLIBRO and Titulo are not empty
            if (string.IsNullOrEmpty(idLibro) || string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("Por favor, complete los campos IDLIBRO y Titulo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert data into the libros_devueltos table
            InsertarLibroDevuelto(idLibro, titulo);

            // Clear the textboxes after confirming the devolution
            IDLIBROTextBox1.Clear();
            TITULOTextBox2.Clear();

            MessageBox.Show("Devolución confirmada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void InsertarLibroDevuelto(string idLibro, string titulo)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "INSERT INTO libros_devueltos (IdLibro, Titulo, fecha_devolucion) VALUES (@IdLibro, @Titulo, CURDATE())";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdLibro", idLibro);
                        comando.Parameters.AddWithValue("@Titulo", titulo);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar la devolución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

private void IDLIBROTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TITULOTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
