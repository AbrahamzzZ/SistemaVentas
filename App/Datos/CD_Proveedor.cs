using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Datos
{
    public class CD_Proveedor
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todos los Proveedores que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Proveedor</returns>
        public List<Proveedor> MostrarProveedores()
        {
            List<Proveedor> listaMostrarProveedor = new List<Proveedor>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_PROVEEDOR, CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO FROM PROVEEDOR;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProveedor.Add(new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(leer["ID_PROVEEDOR"]),
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
            catch (Exception pr)
            {
                Console.WriteLine($"Error al mostrar proveedores: {pr.Message}");
                throw;
            }
            return listaMostrarProveedor;
        }

        /// <summary>
        /// Método que permite registrar un nuevo Proveedor
        /// </summary>
        /// <param name="obj">Objeto de tipo Proveedor que contiene los datos del nuevo proveedor</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del proveedor generado, o 0 si hubo un error</returns>
        public int RegistrarProveedor(Proveedor obj, out string Mensaje)
        {
            int IdProveedorGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PROVEEDOR", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombres_Proveedor", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos_Proveedor", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdProveedorGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                IdProveedorGenerado = 0;
                Mensaje = pr.Message;
            }
            return IdProveedorGenerado;
        }

        /// <summary>
        /// Método que permite editar la información de un Proveedor ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Proveedor que contiene los datos actualizados del proveedor</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarProveedor(Proveedor obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PROVEEDOR", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Proveedor", obj.IdProveedor);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombres_Proveedor", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellidos_Proveedor", obj.Apellidos);
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
            catch (Exception pr)
            {
                Respuesta = false;
                Mensaje = pr.Message;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite eliminar a un Proveedor
        /// </summary>
        /// <param name="obj">Objeto de tipo Proveedor que contiene el ID del proveedor a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarProveedor(Proveedor obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PROVEEDOR", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Proveedor", obj.IdProveedor);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                Respuesta = false;
                Mensaje = pr.Message;
            }
            return Respuesta;
        }
    }
}
