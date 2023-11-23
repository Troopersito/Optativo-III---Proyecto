using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Login : Form
    {
        // Add a property to store the logged-in user's ID
        

        public Login()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void textPass_IconRightClick(object sender, EventArgs e)
        {
            if (textPass.UseSystemPasswordChar)
            {
                textPass.IconRight = Properties.Resources.view;
                textPass.UseSystemPasswordChar = false;
            }
            else
            {
                textPass.IconRight = Properties.Resources.hide;
                textPass.UseSystemPasswordChar = true;
            }
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            textPass.UseSystemPasswordChar = true;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Registro registroForm = new Registro();
            registroForm.Show();

            this.Hide();
        }
        public int LoggedInUserId { get; private set; }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textUsername.Text;
            string contraseña = textPass.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la contraseña.");
                return;
            }

            // Verificar las credenciales en la base de datos
            if (VerificarCredenciales(nombreUsuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                // Crear una instancia del formulario MenuP
                MenuP menuPrincipalForm = new MenuP();

                // Set the logged-in user's ID in the MenuP form
                menuPrincipalForm.LoggedInUserId = GetLoggedInUserId(nombreUsuario);

                // Mostrar el formulario MenuP
                menuPrincipalForm.Show();

                // Ocultar el formulario de inicio de sesión
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }

        private bool VerificarCredenciales(string usuario, string contraseña)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "SELECT COUNT(*) FROM USUARIOS WHERE user = @usuario AND password = @contraseña";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@contraseña", contraseña);

                        int resultado = Convert.ToInt32(comando.ExecuteScalar());
                        return resultado > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al verificar credenciales: {ex.Message}");
                return false;
            }
        }

        private int GetLoggedInUserId(string usuario)
        {
            try
            {
                using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    string consulta = "SELECT Id FROM USUARIOS WHERE user = @usuario";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);

                        object result = comando.ExecuteScalar();

                        if (result != null)
                        {
                            LoggedInUserId = Convert.ToInt32(result);
                            return LoggedInUserId;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al obtener el ID del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1; // Return -1 if the ID is not found or an error occurs
        }
    }
}