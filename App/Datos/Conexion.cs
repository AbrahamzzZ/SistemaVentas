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
        /// Metodo para la conexión de la base de datos.
        /// </summary>
        public SqlConnection ConexionBD()
        {
            SqlConnection Conexion = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
                Conexion = new SqlConnection(connectionString);
                Conexion.Open();
            }
            catch (Exception con)
            {
                Console.WriteLine($"Error al crear la conexión: {con.Message}");
                throw;
            }
            return Conexion;
        }
    }
}
