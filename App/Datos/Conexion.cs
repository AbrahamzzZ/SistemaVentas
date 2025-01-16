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
        /// Método para la conexión de la base de datos. 
        /// </summary> 
        /// <returns>Retorna una conexión SQL abierta.</returns>
        public SqlConnection ConexionBD()
        {
            SqlConnection ConexionBaseDatos = null;
            try
            {
                // Usar esta cadena de conexión para ocultarla dentro del código
                // Obtiene la cadena de conexión desde el archivo de configuración 
                // Inicializa la conexión con la cadena de conexión obtenida 
                /*string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString; 
                ConexionBaseDatos = new SqlConnection(connectionString);
                ConexionBaseDatos.Open();*/

                // Usar esta cadena de conexión para realizar los Test 
                // Inicializa la conexión con la cadena de conexión proporcionada
                ConexionBaseDatos = new SqlConnection("server=DESKTOP-8CQM9OG\\SQLSEXPRESS; database=Sistema_Ventas; integrated security=true;");
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
