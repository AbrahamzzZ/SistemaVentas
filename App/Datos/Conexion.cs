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
        //Metodo para la conexión de la base de datos
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
       
        //Reclamo
        public List<Reclamo> mostrarReclamo()
        {
            List<Reclamo> listaMostrarReclamo = new List<Reclamo>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_RECLAMO, c.ID_CLIENTE, c.DOCUMENTO, c.NOMBRES, c.CORREO_ELECTRONICO, DESCRIPCION, r.ESTADO FROM RECLAMO r");
                mostrar.AppendLine("INNER JOIN CLIENTE c ON c.ID_CLIENTE = r.ID_CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarReclamo.Add(new Reclamo()
                    {
                        IdReclamo = Convert.ToInt32(leer["ID_RECLAMO"]),
                        oCliente = new Cliente() { IdCliente = Convert.ToInt32(leer["ID_CLIENTE"]), Codigo = leer["DOCUMENTO"].ToString(), Nombres = leer["NOMBRES"].ToString(), CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString() },
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception of)
            {
                listaMostrarReclamo = new List<Reclamo>();
            }
            return listaMostrarReclamo;
        }
        public bool editarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_RECLAMO", ConexionBD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        public bool eliminarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_RECLAMO", ConexionBD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
    }
}
