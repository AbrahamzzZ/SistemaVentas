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
    public class CD_Negocio
    {
        Conexion Conexion = new Conexion();

        //Metodo que muestra la informacion del Negocio
        public Negocio ObtenerInformacionNegocio()
        {
            Negocio obtenerDatos = new Negocio();
            try
            {
                string obtener = "SELECT ID_NEGOCIO, NOMBRE, TELEFONO, RUC, DIRECCION, CORREO_ELECTRONICO FROM NEGOCIO WHERE ID_NEGOCIO = 1";
                SqlCommand cmd = new SqlCommand(obtener, Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    obtenerDatos = new Negocio()
                    {
                        IdNegocio = Convert.ToInt32(leer["ID_NEGOCIO"]),
                        Nombre = leer["NOMBRE"].ToString(),
                        Telefono = leer["TELEFONO"].ToString(),
                        Ruc = leer["RUC"].ToString(),
                        Direccion = leer["DIRECCION"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString()
                    };
                }
            }
            catch (Exception ne)
            {
                Console.WriteLine($"Error al mostrar informacion del negocio: {ne.Message}");
                throw;
            }
            return obtenerDatos;
        }

        //Metodo que permite registrar la informacion del Negocio
        public bool EditarNegocio(Negocio obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_NEGOCIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Negocio", obj.IdNegocio);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Ruc", obj.Ruc);
                cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ne)
            {
                Respuesta = false;
                Mensaje = ne.Message;
            }
            return Respuesta;
        }

        //Metodo que permite mostrar el logo del Negocio
        public byte[] ObtenerLogoNegocio(out bool obtenido)
        {
            obtenido = true;
            byte[] logoByte = new byte[0];
            try
            {
                string obtenerLogo = "SELECT LOGO FROM NEGOCIO WHERE ID_NEGOCIO = 1";
                SqlCommand cmd = new SqlCommand(obtenerLogo, Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    logoByte = (byte[])leer["LOGO"];
                }
            }
            catch (Exception ne)
            {
                obtenido = false;
                logoByte = new byte[0];
            }
            return logoByte;
        }

        //Metodo que permite actualizar el logo del Negocio
        public bool ActualizarLogoNegocio(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                StringBuilder actualizarLogo = new StringBuilder();
                actualizarLogo.AppendLine("UPDATE NEGOCIO SET LOGO = @Image");
                actualizarLogo.AppendLine("WHERE ID_NEGOCIO = 1");

                SqlCommand cmd = new SqlCommand(actualizarLogo.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    mensaje = "No se pudo actulizar el logo.";
                    respuesta = false;
                }
            }
            catch (Exception ne)
            {
                mensaje = ne.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
