using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class factura : Form
    {
        public factura()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Configurar propiedades del DataGridView
            dataGridViewfactura.AllowUserToAddRows = false;
            dataGridViewfactura.AllowUserToDeleteRows = false;
            dataGridViewfactura.ReadOnly = true;
            dataGridViewfactura.RowHeadersVisible = false;
            dataGridViewfactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Llamar al método LoadData para llenar el DataGridView cuando se carga el formulario
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    // Obtener el ID del usuario actual
                    int currentUserId = GetLoggedInUserId();

                    // Consulta SQL para obtener facturas del usuario actual
                    string query = "SELECT Id,IdLibro, Titulo, Nroacceso, Monto FROM facturacionmora " +
                                   $"WHERE Id = {currentUserId}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al DataGridView
                            dataGridViewfactura.DataSource = dataTable;
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
            // Reemplaza esto con la lógica real para obtener el ID del usuario actual
            Login loginForm = Application.OpenForms.OfType<Login>().FirstOrDefault();

            if (loginForm != null)
            {
                return loginForm.LoggedInUserId;
            }

            // Si el ID del usuario no es accesible, devuelve un valor predeterminado o maneja según sea necesario
            return -1;
        }

        private void CalcularMontoPorMora(int prestamoId, DateTime fechaLimiteDevolucion)
        {
            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    // Obtener la fecha actual
                    DateTime fechaActual = DateTime.Now;

                    // Calcular la diferencia en días
                    int diasDeRetraso = (int)(fechaActual - fechaLimiteDevolucion).TotalDays;

                    // Calcular el monto por mora (15,000 gs por día de retraso)
                    int montoPorMora = diasDeRetraso * 15000;

                    // Actualizar el monto por mora en la tabla facturacionmora
                    string updateQuery = "UPDATE facturacionmora SET Monto = @Monto WHERE Id = @PrestamoId";

                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Monto", montoPorMora);
                        updateCommand.Parameters.AddWithValue("@PrestamoId", prestamoId);

                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular el monto por mora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void factura_Load(object sender, EventArgs e)
        {
            // Obtener el ID del usuario actual
            int currentUserId = GetLoggedInUserId();

            // Consulta SQL para obtener préstamos del usuario actual
            string prestamosQuery = $"SELECT Id, FechaLimiteDevolucion FROM prestamos WHERE IdUsuario = {currentUserId}";

            try
            {
                using (MySqlConnection connection = ConexionBD.ObtenerConexion())
                {
                    using (MySqlCommand prestamosCommand = new MySqlCommand(prestamosQuery, connection))
                    {
                        using (MySqlDataAdapter prestamosAdapter = new MySqlDataAdapter(prestamosCommand))
                        {
                            DataTable prestamosTable = new DataTable();
                            prestamosAdapter.Fill(prestamosTable);

                            foreach (DataRow row in prestamosTable.Rows)
                            {
                                // Obtener el ID del préstamo y la fecha límite de devolución
                                int prestamoId = Convert.ToInt32(row["Id"]);
                                DateTime fechaLimiteDevolucion = Convert.ToDateTime(row["FechaLimiteDevolucion"]);

                                // Calcular y actualizar el monto por mora
                                CalcularMontoPorMora(prestamoId, fechaLimiteDevolucion);
                            }
                        }
                    }

                    // Cargar las facturas después de actualizar los montos por mora
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atrasbutton_Click(object sender, EventArgs e)
        {
            this.Close();

            // Mostrar el formulario accionesclientes
            accionesclientes accionesClientesForm = new accionesclientes();
            accionesClientesForm.Show();
        }

        private void dataGridViewfactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejar el clic en el contenido de la celda si es necesario
        }

        private void factura_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Manejar el evento FormClosed, por ejemplo, mostrar el formulario anterior
            if (Owner != null)
            {
                Owner.Show();
            }
        }
    }
}
