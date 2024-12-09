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
    public class CD_Sucursal
    {
        Conexion Conexion = new Conexion();

        //Metodo que muestra una lista de todos las Sucursales que existen
        public List<Sucursal> MostrarSucursales()
        {
            List<Sucursal> listaSucursal = new List<Sucursal>();
            try
            {
                string mostrar = "SELECT ID_SUCURSAL, CODIGO, NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO FROM SUCURSAL";
                SqlCommand cmd = new SqlCommand(mostrar, Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaSucursal.Add(new Sucursal()
                    {
                        IdSucursal = Convert.ToInt32(leer["ID_SUCURSAL"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombre = leer["NOMBRE_SUCURSAL"].ToString(),
                        Direccion = leer["DIRECCION_SUCURSAL"].ToString(),
                        Latitud = Convert.ToDouble(leer["LATITUD_SUCURSAL"]),
                        Longitud = Convert.ToDouble(leer["LONGITUD_SUCURSAL"]),
                        Ciudad = leer["CIUDAD_SUCURSAL"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception su)
            {
                Console.WriteLine($"Error al mostrar sucursales: {su.Message}");
                throw;
            }
            return listaSucursal;
        }

        //Metodo que permite registrar un nueva Sucursal
        public int RegistrarSucursal(Sucursal obj, out string mensaje)
        {
            int idSucursaloGenerada = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_SUCURSAL", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Sucursal", obj.Nombre);
                cmd.Parameters.AddWithValue("Direccion_Sucursal", obj.Direccion);
                cmd.Parameters.AddWithValue("Latitud_Sucursal", obj.Latitud);
                cmd.Parameters.AddWithValue("Longitud_Sucursal", obj.Longitud);
                cmd.Parameters.AddWithValue("Ciudad_Sucursal", obj.Ciudad);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idSucursaloGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception su)
            {
                idSucursaloGenerada = 0;
                mensaje = su.Message;
            }
            return idSucursaloGenerada;
        }

        //Metodo que permite editar la informacion de una Sucursal ya registrada
        public bool EditarSucursal(Sucursal obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_SUCURSAL", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Sucursal", obj.IdSucursal);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Sucursal", obj.Nombre);
                cmd.Parameters.AddWithValue("Direccion_Sucursal", obj.Direccion);
                cmd.Parameters.AddWithValue("Latitud_Sucursal", obj.Latitud);
                cmd.Parameters.AddWithValue("Longitud_Sucursal", obj.Longitud);
                cmd.Parameters.AddWithValue("Ciudad_Sucursal", obj.Ciudad);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception su)
            {
                Respuesta = false;
                Mensaje = su.Message;
            }
            return Respuesta;
        }

        //Metodo que permite eliminar a una Sucursal
        public bool EliminarSucursal(Sucursal obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_SUCURSAL", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Sucursal", obj.IdSucursal);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception su)
            {
                respuesta = false;
                mensaje = su.Message;
            }
            return respuesta;
        }
    }
}
