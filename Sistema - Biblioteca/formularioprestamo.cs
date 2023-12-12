using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class formularioprestamo : Form
    {
        public formularioprestamo()
        {
            InitializeComponent();
            LoadCategoriaComboBox();
        }

        private void LoadCategoriaComboBox()
        {
            // Load categories into the ComboBox
            string[] categories = {
                "Novela histórica", "Ciencia ficción", "Fantasía", "Novela romántica",
                "Misterio", "Thriller", "Poesía", "Drama", "Aventura", "Ciencia",
                "Autoayuda", "Biografía", "Ensayo", "Humor", "Ficción histórica",
                "Terror", "Realismo mágico", "Distopía", "Cuento corto", "Epistolar"
            };

            categoriaComboBox1.Items.AddRange(categories);
        }

        private void RealizarPrestamo(string idUsuario, string idLibro, string titulo, string autor, string categoria, string nroAcceso)
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    string query = "INSERT INTO prestamos (Id, Idlibro, Titulo, Autor, Categoria, Nroacceso, fechadeprestamo) " +
                                   "VALUES (@IdUsuario, @IdLibro, @Titulo, @Autor, @Categoria, @NroAcceso, @FechaPrestamo)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Assuming IdUsuario is an INT, modify the data type accordingly
                        command.Parameters.AddWithValue("@IdUsuario", Convert.ToInt32(idUsuario));
                        command.Parameters.AddWithValue("@IdLibro", idLibro);
                        command.Parameters.AddWithValue("@Titulo", titulo);
                        command.Parameters.AddWithValue("@Autor", autor);
                        command.Parameters.AddWithValue("@Categoria", categoria);
                        command.Parameters.AddWithValue("@NroAcceso", nroAcceso);

                        // Obtain the current date and time for the loan
                        DateTime fechaPrestamo = DateTime.Now;
                        command.Parameters.AddWithValue("@FechaPrestamo", fechaPrestamo);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Préstamo realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void idusuarioTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void idlibroTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tituloTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void autorTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void categoriaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numeroaccesoTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void realizarprestamoButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a method to get the user ID
                string userId = GetUserId(); // Implement GetUserId() according to your application logic

                // Obtener los valores de los controles TextBox y ComboBox
                int idLibro = Convert.ToInt32(idlibroTextBox2.Text);
                string titulo = tituloTextBox3.Text;
                string autor = autorTextBox4.Text;
                string categoria = categoriaComboBox1.SelectedItem.ToString();
                string nroacceso = numeroaccesoTextBox6.Text;

                // Llamar a RealizarPrestamo con el ID de usuario
                RealizarPrestamo(userId, idLibro.ToString(), titulo, autor, categoria, nroacceso);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Hide the current form (Formnularioparadevolucion)
            this.Hide();

            // Show the accionesprestamos form
            accionesprestamos accionesPrestamosForm = new accionesprestamos();
            accionesPrestamosForm.FormClosed += (s, args) => this.Close(); // Close the application when accionesprestamos form is closed
            accionesPrestamosForm.Show();
        }

        // Implement the GetUserId() method according to your application logic
        private string GetUserId()
        {
            return idusuarioTextBox1.Text;
        }
    }
}

