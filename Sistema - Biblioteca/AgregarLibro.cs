// AgregarLibro.cs
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class AgregarLibro : Form
    {
        private List<Libro> libros = new List<Libro>();

        public class Libro
        {
            public int Id { get; set; } // Asegúrate de tener un atributo Id para identificar de manera única cada libro
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string Categoria { get; set; }
            public string Nroacceso { get; set; }
        }

        public AgregarLibro()
        {
            InitializeComponent();
            // Configurar el ComboBox con las categorías
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

        public DataGridView DataGridViewLibros
        {
            get { return dataGridView1; }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            // Agregar el libro a la lista
            Libro nuevoLibro = new Libro
            {
                Titulo = guna2TextBox2.Text,
                Autor = guna2TextBox4.Text,
                Categoria = guna2ComboBox1.Text,
                Nroacceso = guna2TextBox1.Text
            };

            // Agregar la fila al DataGridView
            dataGridView1.Rows.Add(nuevoLibro.Titulo, nuevoLibro.Autor, nuevoLibro.Categoria, nuevoLibro.Nroacceso);

            // Guardar los datos en la base de datos
            GuardarEnBaseDeDatos(nuevoLibro);

            // Agregar el nuevo libro a la lista
            libros.Add(nuevoLibro);

            // Limpia los campos después de agregar el libro
            LimpiarCampos();
        }

        private void GuardarEnBaseDeDatos(Libro libro)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "INSERT INTO Libros (Titulo, Autor, Categoria, Nroacceso) VALUES (@Titulo, @Autor, @Categoria, @Nroacceso)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Titulo", libro.Titulo);
                        comando.Parameters.AddWithValue("@Autor", libro.Autor);
                        comando.Parameters.AddWithValue("@Categoria", libro.Categoria);
                        comando.Parameters.AddWithValue("@Nroacceso", libro.Nroacceso);
                        comando.ExecuteNonQuery();

                        // Recuperar el Id asignado al libro
                        libro.Id = (int)comando.LastInsertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
                // Puedes manejar el error de acuerdo a tus necesidades
            }
        }

        private void LimpiarCampos()
        {
            guna2TextBox2.Text = string.Empty;
            guna2TextBox4.Text = string.Empty;
            guna2ComboBox1.Text = string.Empty;
            guna2TextBox1.Text = string.Empty;
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indiceFila = dataGridView1.SelectedRows[0].Index;
                Libro libroSeleccionado = libros[indiceFila];

                using (EditarLibro editarLibroForm = new EditarLibro(libroSeleccionado))
                {
                    // Establecer el formulario padre como AgregarLibro
                    editarLibroForm.Owner = this;

                    // Establecer el DataGridView en EditarLibro
                    editarLibroForm.DataGridViewLibro = dataGridView1;

                    DialogResult resultado = editarLibroForm.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        libros[indiceFila] = editarLibroForm.LibroEditado;

                        dataGridView1.Rows[indiceFila].SetValues(
                            editarLibroForm.LibroEditado.Titulo,
                            editarLibroForm.LibroEditado.Autor,
                            editarLibroForm.LibroEditado.Categoria,
                            editarLibroForm.LibroEditado.Nroacceso
                        );

                        // Actualizar los datos en la base de datos
                        ActualizarEnBaseDeDatos(editarLibroForm.LibroEditado);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para editar.", "Editar Libro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indiceFila = dataGridView1.SelectedRows[0].Index;

                // Obtener el libro seleccionado desde la lista
                Libro libroSeleccionado = libros[indiceFila];

                // Eliminar la fila del DataGridView
                dataGridView1.Rows.RemoveAt(indiceFila);

                // Eliminar el libro de la lista
                libros.RemoveAt(indiceFila);

                // Eliminar los datos en la base de datos
                EliminarEnBaseDeDatos(libroSeleccionado);
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.", "Eliminar Libro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void EliminarEnBaseDeDatos(Libro libro)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "DELETE FROM Libros WHERE Id = @Id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", libro.Id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar en la base de datos: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes realizar acciones adicionales al cambiar la selección del ComboBox si es necesario.
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual (AgregarLibro)
            this.Close();

            // Muestra el formulario de "Libros" (reemplaza "LibrosForm" con el nombre de tu formulario de "Libros")
            Libros librosForm = new Libros();
            librosForm.Show();
        }

        private void AgregarLibro_Load(object sender, EventArgs e)
        {

        }
    }
}
