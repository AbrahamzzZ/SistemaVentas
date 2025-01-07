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
    public class CD_Categoria
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todas las Categorías que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Categoria</returns>
        public List<Categoria> MostrarCategorias()
        {
            List<Categoria> listaMostrarCategoria = new List<Categoria>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_CATEGORIA, CODIGO, DESCRIPCION, ESTADO FROM CATEGORIA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarCategoria.Add(new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(leer["ID_CATEGORIA"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception ca)
            {
                Console.WriteLine($"Error al mostrar categorias: {ca.Message}");
                throw;
            }
            return listaMostrarCategoria;
        }

        /// <summary>
        /// Método que permite registrar una nueva Categoría
        /// </summary>
        /// <param name="obj">Objeto de tipo Categoria que contiene los datos de la nueva categoría</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID de la categoría generada, o 0 si hubo un error</returns>
        public int RegistrarCategoria(Categoria obj, out string Mensaje)
        {
            int IdCategoriaGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_CATEGORIA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdCategoriaGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                IdCategoriaGenerado = 0;
                Mensaje = ca.Message;

            }
            return IdCategoriaGenerado;
        }

        /// <summary>
        /// Método que permite editar la información de una Categoría ya registrada
        /// </summary>
        /// <param name="obj">Objeto de tipo Categoria que contiene los datos actualizados de la categoría</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarCategoria(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_CATEGORIA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Categoria", obj.IdCategoria);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                respuesta = false;
                mensaje = ca.Message;

            }
            return respuesta;
        }

        /// <summary>
        /// Método que permite eliminar una Categoría
        /// </summary>
        /// <param name="obj">Objeto de tipo Categoria que contiene el ID de la categoría a eliminar</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarCategoria(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_CATEGORIA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Categoria", obj.IdCategoria);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ca)
            {
                respuesta = false;
                mensaje = ca.Message;

            }
            return respuesta;
        }
    }
}
