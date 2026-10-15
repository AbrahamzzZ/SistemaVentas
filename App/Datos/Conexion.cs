using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Datos
{
    public static class Conexion
    {
        public const string VariableEntorno = "SISTEMA_VENTAS_DB";
        public const string NombreCadenaConfig = "ConexionBD";

        private static readonly Lazy<string> cadenaConexion = new Lazy<string>(ObtenerCadenaConexion);

        /// <summary>
        /// Crea y abre una nueva conexión a la base de datos.
        /// </summary>
        /// <returns>Una conexión SQL abierta que el llamador debe liberar con <c>using</c>.</returns>
        public static SqlConnection Abrir()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion.Value);
            try
            {
                conexion.Open();
            }
            catch
            {
                conexion.Dispose();
                throw;
            }
            return conexion;
        }

        private static string ObtenerCadenaConexion()
        {
            string cadena = Environment.GetEnvironmentVariable(VariableEntorno);
            if (string.IsNullOrWhiteSpace(cadena))
            {
                cadena = LeerCadenaAppConfig();
            }
            if (string.IsNullOrWhiteSpace(cadena))
            {
                throw new InvalidOperationException(
                    $"No se encontró la cadena de conexión. Defina la variable de entorno '{VariableEntorno}' " +
                    $"o la entrada '{NombreCadenaConfig}' en la sección connectionStrings de App.config.");
            }
            return cadena;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string LeerCadenaAppConfig()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[NombreCadenaConfig]?.ConnectionString;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
