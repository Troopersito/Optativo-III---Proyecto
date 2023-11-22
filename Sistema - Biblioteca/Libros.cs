using MySql.Data.MySqlClient;
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
            // Cargar las categorías en el Guna2ComboBox
            List<string> categorias = new List<string>
            {
                "Novela histórica",
                "Ciencia ficción",
                "Fantasía",
                "Novela romántica",
                "Misterio",
                "Thriller",
                "Poesía",
                "Drama",
                "Aventura",
                "Ciencia",
                "Autoayuda",
                "Biografía",
                "Ensayo",
                "Humor",
                "Ficción histórica",
                "Terror",
                "Realismo mágico",
                "Distopía",
                "Cuento corto",
                "Epistolar"
            };

            guna2ComboBox1.DataSource = categorias;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario actual (Libros)
            this.Hide();

            // Mostrar el formulario AgregarLibro
            AgregarLibro agregarLibroForm = new AgregarLibro();
            agregarLibroForm.FormClosed += (s, args) => this.Close(); // Cierra la aplicación cuando se cierra el formulario AgregarLibro
            agregarLibroForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Obtener el valor ingresado por el usuario para buscar
            string tituloBusqueda = guna2TextBox1.Text;

            // Realizar la búsqueda en la base de datos
            BuscarLibro(tituloBusqueda);
        }

        private void BuscarLibro(string titulo)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "SELECT * FROM Libros WHERE Titulo LIKE @Titulo";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        // Usar parámetros para evitar SQL Injection
                        comando.Parameters.AddWithValue("@Titulo", "%" + titulo + "%");

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            // Limpiar el DataGridView antes de agregar los resultados
                            dataGridView1.Rows.Clear();

                            // Verificar si hay filas en el resultado
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Verificar si los campos no son nulos antes de asignar al DataGridView
                                    string nroacceso = reader["Nroacceso"] is DBNull ? string.Empty : reader.GetString("Nroacceso");
                                    string tituloLibro = reader["Titulo"] is DBNull ? string.Empty : reader.GetString("Titulo");
                                    string autorLibro = reader["Autor"] is DBNull ? string.Empty : reader.GetString("Autor");
                                    string categoriaLibro = reader["Categoria"] is DBNull ? string.Empty : reader.GetString("Categoria");

                                    dataGridView1.Rows.Add(tituloLibro, autorLibro, categoriaLibro, nroacceso);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron libros con el título especificado.", "Búsqueda de Libros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar en la base de datos: {ex.Message}");
                // Puedes manejar el error de acuerdo a tus necesidades
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}