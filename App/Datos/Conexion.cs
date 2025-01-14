using System;
using Entidad;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datos
{
    public class Conexion
    {
        /// <summary>
        ///  Método para la conexión de la base de datos.
        /// </summary>
        public SqlConnection ConexionBD()
        {
            SqlConnection ConexionBaseDatos = null;
            try
            {
                //Cadena de recuerdo :( 
                /*string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
                ConexionBaseDatos = new SqlConnection(connectionString);
                ConexionBaseDatos.Open();*/
                ConexionBaseDatos = new SqlConnection("server= DESKTOP-8CQM9OG\\SQLSEXPRESS ; database= Sistema_Ventas ; integrated security=true;");
                ConexionBaseDatos.Open();

            }
            catch (Exception con)
            {
                Console.WriteLine($"Error al crear la conexión: {con.Message}");
                throw;
            }
            return ConexionBaseDatos;
        }
    }
}
