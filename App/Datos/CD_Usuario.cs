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
        /// Método que permite ingresar el Usuario al sistema
        /// </summary>
        /// <returns>Una lista de objetos de tipo Usuario</returns>
        public List<Usuario> IngresarUsuarioLogin()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            try
            {
                string registrar = "SELECT ID_USUARIO, CODIGO, NOMBRE_COMPLETO, CLAVE, ESTADO FROM USUARIO";
                SqlCommand cmd = new SqlCommand(registrar, Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaUsuario.Add(new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(leer["ID_USUARIO"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        Clave = leer["CLAVE"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception)
            {
                listaUsuario = new List<Usuario>();
            }
            return listaUsuario;
        }

        /// <summary>
        /// Metodo que permite recuperar la clave del Usuario
        /// </summary>
        /// <param name="correoElectronico">Correo electrónico del usuario cuya clave se desea recuperar.</param>
        /// <returns>Un objeto Usuario que contiene la clave del usuario si se encuentra; de lo contrario, null.</returns>
        public Usuario RecuperarClave(string correoElectronico)
        {
            Usuario usuario = null;
            try
            {
                string consulta = "SELECT SALT FROM USUARIO WHERE CORREO_ELECTRONICO = @correoElectronico";
                SqlCommand cmd = new SqlCommand(consulta, Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    usuario = new Usuario()
                    {
                        Clave = leer["CLAVE"].ToString()
                    };
                }
            }
            catch (Exception us)
            {
                Console.WriteLine($"Error al mostrar la clave: {us.Message}");// Se registra el error
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
                mostrar.AppendLine("SELECT u.ID_USUARIO, u.CODIGO, u.NOMBRE_COMPLETO, u.CORREO_ELECTRONICO, u.CLAVE, u.ESTADO, r.ID_ROL, r.DESCRIPCION FROM USUARIO u");
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
                        Clave = leer["CLAVE"].ToString(),
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
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                /*cmd.Parameters.AddWithValue("Clave_Hash", obj.Clave);
                cmd.Parameters.AddWithValue("Salt", obj.Salt);*/
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
                /*cmd.Parameters.AddWithValue("Clave_Hash", obj.Clave);
                cmd.Parameters.AddWithValue("Salt", obj.Salt);*/
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
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
