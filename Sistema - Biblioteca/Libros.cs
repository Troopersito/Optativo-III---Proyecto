using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Libros : Form
    {
        public Libros()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Configurar propiedades del DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersVisible = true; // Ocultar encabezados de columnas

           
        }

        private void Libros_Load(object sender, EventArgs e)
        {
            // Cargar las categorías en el Guna2ComboBox
            List<string> categorias = ObtenerCategorias();
            guna2ComboBox1.DataSource = categorias;

            // Llenar el DataGridView con datos al cargar el formulario
            CargarDatosDataGridView();
        }

        private void CargarDatosDataGridView()
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT Titulo, Autor, Categoria, Nroacceso FROM Libros";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<string> ObtenerCategorias()
        {
            return new List<string>
            {
                "Novela histórica", "Ciencia ficción", "Fantasía", "Novela romántica", "Misterio",
                "Thriller", "Poesía", "Drama", "Aventura", "Ciencia", "Autoayuda", "Biografía",
                "Ensayo", "Humor", "Ficción histórica", "Terror", "Realismo mágico", "Distopía",
                "Cuento corto", "Epistolar"
            };
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
            // Obtener los valores ingresados por el usuario para buscar
            string tituloBusqueda = guna2TextBox1.Text;
            string autorBusqueda = guna2TextBox2.Text;
            string categoriaBusqueda = guna2ComboBox1.Text;
            string nroaccesoBusqueda = guna2TextBox4.Text; // Asegúrate de que este sea el nombre correcto

            // Realizar la búsqueda en la base de datos y actualizar el DataGridView
            BuscarLibro(tituloBusqueda, autorBusqueda, categoriaBusqueda, nroaccesoBusqueda);
        }

        private void BuscarLibro(string titulo, string autor, string categoria, string nroacceso)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "SELECT * FROM Libros WHERE Titulo LIKE @Titulo AND Autor LIKE @Autor AND Categoria LIKE @Categoria AND Nroacceso LIKE @Nroacceso";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        // Usar parámetros para evitar SQL Injection
                        comando.Parameters.AddWithValue("@Titulo", "%" + titulo + "%");
                        comando.Parameters.AddWithValue("@Autor", "%" + autor + "%");
                        comando.Parameters.AddWithValue("@Categoria", "%" + categoria + "%");
                        comando.Parameters.AddWithValue("@Nroacceso", "%" + nroacceso + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Limpiar el DataGridView antes de agregar los resultados
                            dataGridView1.DataSource = null;

                            // Verificar si hay filas en el resultado
                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron libros con los criterios especificados.", "Búsqueda de Libros", MessageBoxButtons.OK, MessageBoxIcon.Information);
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




        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // Hacer algo cuando se hace clic en guna2HtmlLabel2
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
