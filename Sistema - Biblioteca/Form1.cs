using Guna.UI2.WinForms;
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
    public partial class Login : Form
    {
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

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

            MenuP menuPrincipalForm = new MenuP();
            menuPrincipalForm.SetLoginForm(this);  // Pasa la referencia correcta del formulario de inicio de sesión
            menuPrincipalForm.Show();
            this.Hide();
        }



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
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string consulta = "SELECT COUNT(*) FROM USUARIOS WHERE user = @usuario AND password = @contraseña";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    try
                    {
                        int resultado = Convert.ToInt32(comando.ExecuteScalar());
                        return resultado > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Error al verificar credenciales: {ex.Message}");
                        return false;
                    }
                }
            }
        }

    }
}

