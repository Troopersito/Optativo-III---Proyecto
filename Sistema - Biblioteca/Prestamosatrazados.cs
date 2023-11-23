using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Prestamosatrazados : Form
    {
        public Prestamosatrazados()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Manually define columns for the DataGridView
            dataGridView1.Columns.Add("Idlibro", "ID Libro");
            dataGridView1.Columns.Add("Titulo", "Título");
            dataGridView1.Columns.Add("Nroacceso", "Nro Acceso");
            dataGridView1.Columns.Add("Fechaentregacorrecta", "Fecha Entrega Correcta");
            dataGridView1.Columns.Add("Fechaentregaretazada", "Fecha Entrega Retrasada");
            dataGridView1.Columns.Add("Multa", "Multa");

            // Set other properties as needed
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    // Modificar la consulta para seleccionar préstamos que están fuera de un rango de 48 horas
                    string query = "SELECT Idlibro, Titulo, Nroacceso, Fechaentregacorrecta, Fechaentregaretazada, " +
                                   "TIMESTAMPDIFF(HOUR, fechadeprestamo, NOW()) AS HorasRetraso, " +
                                   "(TIMESTAMPDIFF(DAY, fechadeprestamo, NOW()) * 15000) AS Multa " +
                                   "FROM prestamos_retrasados " +
                                   "WHERE TIMESTAMPDIFF(HOUR, fechadeprestamo, NOW()) > 48";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Set AutoGenerateColumns to true
                            dataGridView1.AutoGenerateColumns = true;

                            // Bind the DataTable to the DataGridView
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
        private void atrasButton1_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the accionesprestamos form
            accionesprestamos accionesPrestamosForm = new accionesprestamos();
            accionesPrestamosForm.FormClosed += (s, args) => this.Close(); // Close the application when accionesprestamos form is closed
            accionesPrestamosForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }

        private void Prestamosatrazados_Load(object sender, EventArgs e)
        {
            // Call the LoadData method to populate the DataGridView when the form is loaded
            LoadData();
        }
    }
}

