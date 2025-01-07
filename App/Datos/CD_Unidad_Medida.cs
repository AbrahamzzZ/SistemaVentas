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
    public class CD_Unidad_Medida
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todas las Unidades de Medida que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Unidad_Medida</returns>
        public List<Unidad_Medida> MostrarUnidadesMedidas()
        {
            List<Unidad_Medida> listaMostrarUnidadesMedidas = new List<Unidad_Medida>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_UNIDAD_MEDIDA, CODIGO, DESCRIPCION, SIMBOLO, ESTADO FROM UNIDAD_MEDIDA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarUnidadesMedidas.Add(new Unidad_Medida()
                    {
                        IdUnidadMedida = Convert.ToInt32(leer["ID_UNIDAD_MEDIDA"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Simbolo = leer["SIMBOLO"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception un)
            {
                Console.WriteLine($"Error al mostrar unidades de medidas: {un.Message}");
                throw;
            }
            return listaMostrarUnidadesMedidas;
        }

        /// <summary>
        /// Método que permite registrar una nueva Unidad de Medida
        /// </summary>
        /// <param name="obj">Objeto de tipo Unidad_Medida que contiene los datos de la nueva unidad de medida</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID de la unidad de medida generada, o 0 si hubo un error</returns>
        public int RegistrarUnidadMedida(Unidad_Medida obj, out string Mensaje)
        {
            int IdUnidadMedidaGenerada = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_UNIDAD_MEDIDA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Simbolo", obj.Simbolo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdUnidadMedidaGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception un)
            {
                IdUnidadMedidaGenerada = 0;
                Mensaje = un.Message;

            }
            return IdUnidadMedidaGenerada;
        }

        /// <summary>
        /// Método que permite editar la información de una Unidad de Medida ya registrada
        /// </summary>
        /// <param name="obj">Objeto de tipo Unidad_Medida que contiene los datos actualizados de la unidad de medida</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarUnidadMedida(Unidad_Medida obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_UNIDAD_MEDIDA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.IdUnidadMedida);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Simbolo", obj.Simbolo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception un)
            {
                Respuesta = false;
                Mensaje = un.Message;            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite eliminar una Unidad de Medida
        /// </summary>
        /// <param name="obj">Objeto de tipo Unidad_Medida que contiene el ID de la unidad de medida a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarUnidadMedida(Unidad_Medida obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_UNIDAD_MEDIDA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.IdUnidadMedida);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception un)
            {
                Respuesta = false;
                Mensaje = un.Message;
            }
            return Respuesta;
        }
    }
}
