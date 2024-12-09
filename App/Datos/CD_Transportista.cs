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

        //Metodo que muestra una lista de todos los Transportistas que existen
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

        //Metodo que permite registrar un nuevo Transportista
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

        //Metodo que permite editar la informacion de un Transportista ya registrado
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

        //Metodo que permite eliminar a un Transportista
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
