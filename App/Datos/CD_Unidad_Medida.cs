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

        //Metodo que permite registrar un nueva Unidad de Medidas
        public List<Unidad_Medida> MostrarUnidadesMedidas()
        {
            List<Unidad_Medida> listaMostrarUnidadesMedidas = new List<Unidad_Medida>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_UNIDAD_MEDIDA, DESCRIPCION, SIMBOLO, ESTADO FROM UNIDAD_MEDIDA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarUnidadesMedidas.Add(new Unidad_Medida()
                    {
                        IdUnidadMedida = Convert.ToInt32(leer["ID_UNIDAD_MEDIDA"]),
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

        //Metodo que permite editar la informacion de una Unidad de Medida ya registrado
        public int RegistrarUnidadMedida(Unidad_Medida obj, out string Mensaje)
        {
            int IdUnidadMedidaGenerada = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_UNIDAD_MEDIDA", Conexion.ConexionBD());
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

        //Metodo que permite editar la informacion de una Unidad de Medida ya registrado
        public bool EditarUnidadMedida(Unidad_Medida obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_UNIDAD_MEDIDA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.IdUnidadMedida);
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

        //Metodo que permite eliminar una Unidad de Medida
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
