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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

      

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            textPass.UseSystemPasswordChar = true;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox3.UseSystemPasswordChar = true;
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

        private void guna2TextBox3_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBox3.UseSystemPasswordChar)
            {

                guna2TextBox3.IconRight = Properties.Resources.view;
                guna2TextBox3.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox3.IconRight = Properties.Resources.hide;
                guna2TextBox3.UseSystemPasswordChar = true;


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login LogintroForm = new Login();


            LogintroForm.Show();


            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void InsertarUsuario(string usuario, string contraseña)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string consulta = "INSERT INTO USUARIOS (user, password) VALUES (@usuario, @contraseña)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    try
                    {
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Usuario registrado correctamente.");
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Error al insertar usuario: {ex.Message}");
                        throw; // Lanzar la excepción para que el llamador la maneje
                    }
                }
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Obtener los datos ingresados por el usuario
            // Obtener los datos ingresados por el usuario
            string nombreUsuario = guna2TextBox1.Text; // Reemplaza 'guna2TextBox1' con el nombre real de tu TextBox
            string contraseña = textPass.Text; // Reemplaza 'textPass' con el nombre real de tu TextBox

            // Validar que se hayan ingresado datos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese todos los campos.");
                return;
            }

            // Guardar los datos en la base de datos
            try
            {
                InsertarUsuario(nombreUsuario, contraseña); // Corregir el nombre del método
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}");
                return;
            }

            // Mostrar un mensaje de éxito
            MessageBox.Show("Datos guardados correctamente.");

            // Puedes agregar aquí cualquier otra lógica que desees después de guardar los datos
        }

    }
}
