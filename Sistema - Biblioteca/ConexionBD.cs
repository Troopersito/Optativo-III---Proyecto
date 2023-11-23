using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema___Biblioteca
{
    internal class ConexionBD
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=Biblioteca;User=root;Password=1234;";


        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(connectionString);

            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                throw; // Lanzar la excepción para que el llamador la maneje
            }

            return conexion;
        }

        public static void CerrarConexion(MySqlConnection conexion)
        {
            try
            {
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
            }
        }
    }
}


