using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class misprestamos : Form
    {
        public misprestamos()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Set other properties as needed
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Call the LoadData method to populate the DataGridView when the form is loaded
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    int currentUserId = GetLoggedInUserId();

                    string query = "SELECT Id, Idlibro, Titulo,Autor,Categoria,Nroacceso " +
                                   "FROM prestamos " +
                                   "WHERE Id = @UserId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", currentUserId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Log the number of rows retrieved
                            Console.WriteLine($"Rows retrieved: {dataTable.Rows.Count}");

                            dataGridView2.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetLoggedInUserId()
        {
            // Replace this with the actual logic to get the user ID
            // For example, you might have a property or method in your login form to retrieve the user ID.
            // If you have a property like LoggedInUserId in your login form, you can use it here.
            Login loginForm = Application.OpenForms.OfType<Login>().FirstOrDefault();

            if (loginForm != null)
            {
                return loginForm.LoggedInUserId;
            }

            // If the user ID is not accessible, return a default or handle accordingly.
            return -1;
        }

        private void misprestamos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void atrasButton1_Click_1(object sender, EventArgs e)
        {
            // Close the current form (misprestamos)
            this.Close();

            // Show the accionesclientes form
            accionesclientes accionesClientesForm = new accionesclientes();
            accionesClientesForm.Show();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }
    }
}

