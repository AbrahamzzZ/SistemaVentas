using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;

namespace Datos
{
    public class CD_Usuario
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que permite ingresar al Usuario al sistema.
        /// </summary>
        /// <param name="codigo">Código del usuario.</param>
        /// <returns>Un objeto de tipo Usuario.</returns>
        public Usuario IngresarUsuarioLogin(string codigo)
        {
            Usuario usuario = null;
            try
            {
                string consulta = "SELECT ID_USUARIO, CODIGO, NOMBRE_COMPLETO, CLAVE, CLAVE_SALT, ESTADO FROM USUARIO WHERE CODIGO = @codigo";
                SqlCommand cmd = new SqlCommand(consulta, Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(leer["ID_USUARIO"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        ClaveEncriptada = leer["CLAVE"].ToString(), // Recuperar la clave encriptada
                        Salt = leer["CLAVE_SALT"].ToString(), // Recuperar el *salt*
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    };
                }
            }
            catch (Exception)
            {
                usuario = null;
            }
            return usuario;
        }

        public bool GenerarTokenRecuperacion(string correoElectronico, ref string tokenGenerado)
        {
            try
            {
                string consulta = "UPDATE USUARIO SET TOKEN_RECUPERACION = @token WHERE CORREO_ELECTRONICO = @correo";

                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.ConexionBD()))
                {
                    cmd.Parameters.AddWithValue("@token", tokenGenerado);
                    cmd.Parameters.AddWithValue("@correo", correoElectronico);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar token: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Método que permite mostrar la información de un usuario mediante su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Un objeto Usuario que contiene la informacion de ese usuario.</returns>
        public Usuario UsuarioID(int id)
        {
            Usuario usuario = null;
            try
            {
                string consulta = "SELECT ID_USUARIO, CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, ESTADO, ID_ROL FROM USUARIO WHERE ID_USUARIO = @id";
                SqlCommand cmd = new SqlCommand(consulta, Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(leer["ID_USUARIO"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        ClaveEncriptada = leer["CLAVE"].ToString(), // Ahora devuelve la clave encriptada real
                        Salt = leer["CLAVE_SALT"].ToString(), // También obtiene el salt del usuario
                        Estado = Convert.ToBoolean(leer["ESTADO"]),
                        oRol = new Rol() { IdRol = Convert.ToInt32(leer["ID_ROL"]) }
                    };
                }
            }
            catch (Exception us)
            {
                Console.WriteLine($"Error al mostrar el ID del usuario: {us.Message}");// Se registra el error
                throw;// Permite que el error se propague si es necesario.
            }
            return usuario;
        }

        /// <summary>
        /// Metodo que muestra una lista de todos los Usuarios que existen con su respectivo rol.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene la información de todos los usuarios y sus respectivos roles.</returns>
        public List<Usuario> MostrarUsuarios()
        {
            List<Usuario> listaMostrarUsuario = new List<Usuario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT u.ID_USUARIO, u.CODIGO, u.NOMBRE_COMPLETO, u.CORREO_ELECTRONICO, u.ESTADO, r.ID_ROL, r.DESCRIPCION FROM USUARIO u");
                mostrar.AppendLine("inner join ROL r on r.ID_ROL = u.ID_ROL");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarUsuario.Add(new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(leer["ID_USUARIO"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"]),
                        oRol = new Rol() { IdRol = Convert.ToInt32(leer["ID_ROL"]), Descripcion = leer["DESCRIPCION"].ToString() },
                    });
                }
            }
            catch (Exception us)
            {
                Console.WriteLine($"Error al mostrar usuarios: {us.Message}");
                throw;
            }
            return listaMostrarUsuario;
        }

        /// <summary>
        /// Método que permite registrar un nuevo Usuario
        /// </summary>
        /// <param name="obj">Objeto de tipo Usuario que contiene los datos del nuevo usuario</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del usuario generado, o 0 si hubo un error</returns>
        public int RegistrarUsuario(Usuario obj, out string Mensaje)
        {
            int IdUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_USUARIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Completo", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Clave_Hash", obj.ClaveEncriptada);
                cmd.Parameters.AddWithValue("Salt", obj.Salt);
                cmd.Parameters.AddWithValue("Id_Rol", obj.oRol.IdRol);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Id_Usuario_Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdUsuarioGenerado = Convert.ToInt32(cmd.Parameters["Id_Usuario_Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                IdUsuarioGenerado = 0;
                Mensaje = us.Message;
            }
            return IdUsuarioGenerado;
        }

        /// <summary>
        /// Método que permite editar la información de un Usuario ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Usuario que contiene los datos actualizados del usuario</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarUsuario(Usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_EDITAR_USUARIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.IdUsuario);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Completo", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Clave_Hash", obj.ClaveEncriptada);
                cmd.Parameters.AddWithValue("Salt", obj.Salt);
                cmd.Parameters.AddWithValue("Id_Rol", obj.oRol.IdRol);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                Respuesta = false;
                Mensaje = us.Message;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite eliminar a un Usuario
        /// </summary>
        /// <param name="obj">Objeto de tipo Usuario que contiene el ID del usuario a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarUsuario(Usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_USUARIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.IdUsuario);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                Respuesta = false;
                Mensaje = us.Message;
            }
            return Respuesta;
        }
    }
}
