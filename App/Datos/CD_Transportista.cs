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
    public class CD_Transportista
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todos los Transportistas que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Transportista</returns>
        public List<Transportista> MostrarTransportistas()
        {
            List<Transportista> listaTransportista = new List<Transportista>();
            try
            {
                string mostrar = "SELECT ID_TRANSPORTISTA, CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, IMAGEN, ESTADO FROM TRANSPORTISTA";
                SqlCommand cmd = new SqlCommand(mostrar, Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaTransportista.Add(new Transportista()
                    {
                        IdTransportista = Convert.ToInt32(leer["ID_TRANSPORTISTA"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombres = leer["NOMBRES"].ToString(),
                        Apellidos = leer["APELLIDOS"].ToString(),
                        Cedula = leer["CEDULA"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Imagen = (byte[])leer["IMAGEN"],
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception tr)
            {
                Console.WriteLine($"Error al mostrar transportista: {tr.Message}");
                throw;
            }
            return listaTransportista;
        }

        /// <summary>
        /// Método que permite registrar un nuevo Transportista
        /// </summary>
        /// <param name="obj">Objeto de tipo Transportista que contiene los datos del nuevo transportista</param>
        /// <param name="imagen">Arreglo de bytes que representa la imagen del transportista</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del transportista generado, o 0 si hubo un error</returns>
        public int RegistrarTransportista(Transportista obj, byte[] imagen, out string Mensaje)
        {
            int IdTransportistaGenerada = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_TRANSPORTISTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Imagen", imagen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdTransportistaGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception tr)
            {
                IdTransportistaGenerada = 0;
                Mensaje = tr.Message;
            }
            return IdTransportistaGenerada;
        }

        /// <summary>
        /// Método que permite editar la información de un Transportista ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Transportista que contiene los datos actualizados del transportista</param>
        /// <param name="imagen">Arreglo de bytes que representa la imagen del transportista</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarTransportista(Transportista obj, byte[] imagen, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_TRANSPORTISTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Transportista", obj.IdTransportista);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Imagen", imagen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception tr)
            {
                Respuesta = false;
                Mensaje = tr.Message;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite eliminar a un Transportista
        /// </summary>
        /// <param name="obj">Objeto de tipo Transportista que contiene el ID del transportista a eliminar</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarTransportista(Transportista obj, out string mensaje)
        {
            bool Respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_TRANSPORTISTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Transportista", obj.IdTransportista);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception tr)
            {
                Respuesta = false;
                mensaje = tr.Message;
            }
            return Respuesta;
        }
    }
}
