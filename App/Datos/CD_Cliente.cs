using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Cliente
    {
        Conexion conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todos los Clientes que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Cliente</returns>
        public List<Cliente> MostrarClientes()
        {
            List<Cliente> listaMostrarCliente = new List<Cliente>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_CLIENTE, CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO FROM CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarCliente.Add(new Cliente()
                    {
                        IdCliente = Convert.ToInt32(leer["ID_CLIENTE"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombres = leer["NOMBRES"].ToString(),
                        Apellidos = leer["APELLIDOS"].ToString(),
                        Cedula = leer["CEDULA"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception cl)
            {
                Console.WriteLine($"Error al mostrar clientes: {cl.Message}");
                throw;
            }
            return listaMostrarCliente;
        }

        /// <summary>
        /// Método que permite registrar un nuevo Cliente
        /// </summary>
        /// <param name="obj">Objeto de tipo Cliente que contiene los datos del nuevo cliente</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del cliente generado, o 0 si hubo un error</returns>
        public int RegistrarCliente(Cliente obj, out string Mensaje)
        {
            int IdClienteGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_CLIENTE", conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Cliente", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdClienteGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                IdClienteGenerado = 0;
                Mensaje = cl.Message;
            }
            return IdClienteGenerado;
        }

        /// <summary>
        /// Método que permite editar la información de un Cliente ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Cliente que contiene los datos actualizados del cliente</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarCliente(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_EDITAR_CLIENTE", conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Cliente", obj.IdCliente);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Cliente", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                Respuesta = false;
                Mensaje = cl.Message;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite eliminar a un Cliente
        /// </summary>
        /// <param name="obj">Objeto de tipo Cliente que contiene el ID del cliente a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarCliente(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_CLIENTE", conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Cliente", obj.IdCliente);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                Respuesta = false;
                Mensaje = cl.Message;
            }
            return Respuesta;
        }
    }
}
