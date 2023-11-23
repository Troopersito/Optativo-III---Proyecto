using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class registrolibrosdevueltos : Form
    {
        public registrolibrosdevueltos()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            

            // Set other properties as needed
            registrolibrosdevueltosdataGridView1.AllowUserToAddRows = false;
            registrolibrosdevueltosdataGridView1.AllowUserToDeleteRows = false;
            registrolibrosdevueltosdataGridView1.ReadOnly = true;
            registrolibrosdevueltosdataGridView1.RowHeadersVisible = false;
            registrolibrosdevueltosdataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Call the LoadData method to populate the DataGridView when the form is loaded
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdLibro, Titulo, fecha_devolucion FROM libros_devueltos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            registrolibrosdevueltosdataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atrasbutton_Click(object sender, EventArgs e)
        {
            // Hide the current form (MenuP)
            this.Hide();

            // Show the accionesprestamos form
            accionesprestamos accionesPrestamosForm = new accionesprestamos();
            accionesPrestamosForm.FormClosed += (s, args) => this.Close(); // Close the application when accionesprestamos form is closed
            accionesPrestamosForm.Show();
        }

        private void registrolibrosdevueltosdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can remove this event handler if not needed
        }
    }
}
