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
    public class CD_Reclamo
    {
        Conexion Conexion = new Conexion();

        //Posible implementacion del metodo mostrar reclamo que permitira ver todos los reclamos de los clientes
        public List<Reclamo> MostrarReclamos()
        {
            List<Reclamo> listaMostrarReclamo = new List<Reclamo>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_RECLAMO, c.ID_CLIENTE, c.DOCUMENTO, c.NOMBRES, c.CORREO_ELECTRONICO, DESCRIPCION, r.ESTADO FROM RECLAMO r");
                mostrar.AppendLine("INNER JOIN CLIENTE c ON c.ID_CLIENTE = r.ID_CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
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
            catch (Exception re)
            {
                Console.WriteLine($"Error al mostrar usuarios: {re.Message}");
                throw;
            }
            return listaMostrarReclamo;
        }

        //Posible implementacion del metodo editar reclamo que permitira editar el estado del reclamo de No Resuelto a Resuelto
        public bool EditarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_RECLAMO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception re)
            {
                respuesta = false;
                mensaje = re.Message;
            }
            return respuesta;
        }

        //Posible implementacion del metodo eliminar reclamo que permitira eliminar todos los reclamos de los clientes ya resueltos
        public bool EliminarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_RECLAMO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception re)
            {
                respuesta = false;
                mensaje = re.Message;
            }
            return respuesta;
        }
    }
}
