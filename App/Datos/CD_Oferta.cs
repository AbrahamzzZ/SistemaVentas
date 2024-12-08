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
    public class CD_Oferta
    {
        Conexion Conexion = new Conexion();

        //Metodo que muestra una lista de todos las Ofertas que existen
        public List<Oferta> MostrarOfertas()
        {
            List<Oferta> listaMostrarOferta = new List<Oferta>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_OFERTA, o.CODIGO, NOMBRE_OFERTA, p.ID_PRODUCTO, p.NOMBRE_PRODUCTO, O.DESCRIPCION, FECHA_INICIO, FECHA_FIN, DESCUENTO, O.ESTADO FROM OFERTA O");
                mostrar.AppendLine("INNER JOIN PRODUCTO p ON p.ID_PRODUCTO = O.ID_PRODUCTO;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarOferta.Add(new Oferta()
                    {
                        IdOferta = Convert.ToInt32(leer["ID_OFERTA"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreOferta = leer["NOMBRE_OFERTA"].ToString(),
                        oProducto = new Producto() { IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]), Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        FechaInicio = leer["FECHA_INICIO"].ToString(),
                        FechaFin = leer["FECHA_FIN"].ToString(),
                        Descuento = Convert.ToDecimal(leer["DESCUENTO"]),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception of)
            {
                Console.WriteLine($"Error al mostrar ofertas: {of.Message}");
                throw;
            }
            return listaMostrarOferta;
        }

        //Metodo que permite registrar un nueva Oferta
        public int RegistrarOferta(Oferta obj, out string Mensaje)
        {
            int IdOfertaGenerada = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_OFERTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Oferta", obj.NombreOferta);
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Fecha_Inicio", obj.FechaInicio);
                cmd.Parameters.AddWithValue("Fecha_Fin", obj.FechaFin);
                cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdOfertaGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception of)
            {
                IdOfertaGenerada = 0;
                Mensaje = of.Message;
            }
            return IdOfertaGenerada;
        }

        //Metodo que permite editar la informacion de una Oferta ya registrada
        public bool EditarOferta(Oferta obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_OFERTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Oferta", obj.IdOferta);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Oferta", obj.NombreOferta);
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Fecha_Inicio", obj.FechaInicio);
                cmd.Parameters.AddWithValue("Fecha_Fin", obj.FechaFin);
                cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception of)
            {
                Respuesta = false;
                Mensaje = of.Message;
            }
            return Respuesta;
        }

        //Metodo que permite eliminar a una Oferta
        public bool EliminarOferta(Oferta obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_OFERTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Oferta", obj.IdOferta);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception of)
            {
                Respuesta = false;
                Mensaje = of.Message;
            }
            return Respuesta;
        }
    }
}
