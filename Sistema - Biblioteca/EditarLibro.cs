// EditarLibro.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Sistema___Biblioteca.AgregarLibro;

namespace Sistema___Biblioteca
{
    public partial class EditarLibro : Form
    {
        public Libro LibroEditado { get; private set; }

        // Propiedad pública para acceder al DataGridView desde AgregarLibro
        public DataGridView DataGridViewLibro { get; set; }

        public EditarLibro(Libro libro)
        {
            InitializeComponent();

            // Cargar las categorías en el ComboBox
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

            // Inicializa los campos del formulario con los datos del libro
            guna2TextBox1.Text = libro.Titulo;
            guna2TextBox2.Text = libro.Autor;
            guna2ComboBox1.Text = libro.Categoria;
            guna2TextBox4.Text = libro.Nroacceso;

            // Inicializa LibroEditado
            LibroEditado = libro;
        }

        private void buttonGuardarCambios_Click(object sender, EventArgs e)
        {
            // Guarda los cambios en el libro
            LibroEditado = new Libro
            {
                Titulo = guna2TextBox1.Text,
                Autor = guna2TextBox2.Text,
                Categoria = guna2ComboBox1.Text,
                Nroacceso = guna2TextBox4.Text
            };

            // Cierra el formulario
            DialogResult = DialogResult.OK;
            Close();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes realizar acciones adicionales al cambiar la selección del ComboBox si es necesario.
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual (EditarLibro)
            this.Close();

            // Muestra el formulario de "AgregarLibro"
            AgregarLibro agregarLibroForm = new AgregarLibro();
            agregarLibroForm.Show();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            // Guardar los cambios en el DataGridView
            int indiceFila = ObtenerIndiceFilaEnDataGridView();

            if (DataGridViewLibro != null && indiceFila != -1)
            {
                DataGridViewLibro.Rows[indiceFila].SetValues(
                    LibroEditado.Titulo,
                    LibroEditado.Autor,
                    LibroEditado.Categoria,
                    LibroEditado.Nroacceso
                );

                // Guardar los cambios en la base de datos
                ActualizarEnBaseDeDatos(LibroEditado);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Los datos fueron guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int ObtenerIndiceFilaEnDataGridView()
        {
            // Obtener el índice de la fila seleccionada en el DataGridView
            if (DataGridViewLibro != null && DataGridViewLibro.SelectedRows.Count > 0)
            {
                return DataGridViewLibro.SelectedRows[0].Index;
            }
            return -1;
        }

        private void ActualizarEnBaseDeDatos(Libro libro)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, Categoria = @Categoria, Nroacceso = @Nroacceso WHERE Id = @Id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", libro.Id);
                        comando.Parameters.AddWithValue("@Titulo", libro.Titulo);
                        comando.Parameters.AddWithValue("@Autor", libro.Autor);
                        comando.Parameters.AddWithValue("@Categoria", libro.Categoria);
                        comando.Parameters.AddWithValue("@Nroacceso", libro.Nroacceso);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar en la base de datos: {ex.Message}");
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            // Cierra el formulario actual (EditarLibro)
            this.Close();

            // Muestra el formulario de "AgregarLibro"
            AgregarLibro agregarLibroForm = new AgregarLibro();
            agregarLibroForm.Show();
        }
    }
}
