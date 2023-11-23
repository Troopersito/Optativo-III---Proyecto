
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            InitializeDataGridView();
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
        private void InitializeDataGridView()
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersVisible = true; // Ocultar encabezados de columna

            // Agregar columna de botón "Seleccionar"
            DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
            btnSeleccionar.Name = "Seleccionar";
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnSeleccionar);

            // Agregar columna de botón de eliminación
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEliminar);

            // Manejar los eventos CellContentClick
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en el botón "Eliminar"
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Preguntar al usuario si realmente desea eliminar la fila
                DialogResult resultado = MessageBox.Show("¿Seguro que quieres eliminar este libro?", "Eliminar Libro",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Eliminar la fila del DataGridView
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    // Verificar si el índice está dentro del rango de la lista libros
                    if (e.RowIndex < libros.Count)
                    {
                        // Obtener el libro seleccionado desde la lista
                        Libro libroSeleccionado = libros[e.RowIndex];

                        // Eliminar el libro de la lista
                        libros.RemoveAt(e.RowIndex);

                        // Eliminar los datos en la base de datos
                        EliminarEnBaseDeDatos(libroSeleccionado);
                    }
                }
            }
        }

        public DataGridView DataGridViewLibros
        {
            get { return dataGridView1; }
        }
        private bool librosCargados = false;
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

            // Guardar los datos en la base de datos
            GuardarEnBaseDeDatos(nuevoLibro);

            // Agregar el nuevo libro a la lista
            libros.Add(nuevoLibro);

            // Cargar los datos en el DataGridView solo si es la primera vez
            if (!librosCargados)
            {
                CargarDatosDataGridView();
                librosCargados = true;
            }

            // Limpia los campos después de agregar el libro
            LimpiarCampos();
        }
        private void AgregarLibro_Load(object sender, EventArgs e)
        {
            // Cargar los datos en el DataGridView al cargar el formulario
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

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el libro seleccionado desde la lista
                Libro libroSeleccionado = libros[dataGridView1.SelectedRows[0].Index];

                // Eliminar la fila del DataGridView
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                // Eliminar el libro de la lista
                libros.Remove(libroSeleccionado);

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

        


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
