using System;
using Entidad;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datos
{
    public class Conexion
    {
        //Metodo para la conexión de la base de datos
        public SqlConnection ConexionBD()
        {
            SqlConnection Conexion = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
                Conexion = new SqlConnection(connectionString);
                Conexion.Open();
            }
            catch (Exception con)
            {
                Console.WriteLine($"Error al crear la conexión: {con.Message}");
                throw;
            }
            return Conexion;
        }

        //Inventario
        public List<Inventario> mostrarInventario()
        {
            List<Inventario> listaMostrarProductoInventario = new List<Inventario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT i.ID_INVENTARIO,p.ID_PRODUCTO,p.CODIGO AS CODIGO_PRODUCTO, p.NOMBRE_PRODUCTO AS NOMBRE_PRODUCTO, i.CANTIDAD, i.UBICACION_ALMACEN, p.ESTADO, i.FECHA_INGRESO FROM INVENTARIO i");
                mostrar.AppendLine("INNER JOIN PRODUCTO p ON p.ID_PRODUCTO = i.ID_PRODUCTO");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProductoInventario.Add(new Inventario()
                    {
                        IdInventario = Convert.ToInt32(leer["ID_INVENTARIO"]),
                        oProducto = new Producto() { IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]), Codigo = leer["CODIGO_PRODUCTO"].ToString(), Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        Cantidad = Convert.ToInt32(leer["CANTIDAD"]),
                        UbicacionAlmacen = leer["UBICACION_ALMACEN"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception inv)
            {
                listaMostrarProductoInventario = new List<Inventario>();
            }
            return listaMostrarProductoInventario;
        }
        public int agregarProductoInventario(Inventario obj, out string mensaje)
        {
            int idInventarioGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PRODUCTO_INVENTARIO", ConexionBD());
                cmd.Parameters.AddWithValue("ID_PRODUCTO", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("CODIGO_PRODUCTO", obj.oProducto.Codigo);
                cmd.Parameters.AddWithValue("NOMBRE_PRODUCTO", obj.oProducto.Nombre);
                cmd.Parameters.AddWithValue("CANTIDAD", obj.Cantidad);
                cmd.Parameters.AddWithValue("UBICACION_ALMACEN", obj.UbicacionAlmacen);
                cmd.Parameters.AddWithValue("ESTADO", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idInventarioGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                idInventarioGenerado = 0;
                mensaje = inv.Message;
            }
            return idInventarioGenerado;
        }
        public bool editarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PRODUCTO_INVENTARIO", ConexionBD());
                cmd.Parameters.AddWithValue("Id_Inventario", obj.IdInventario);
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Codigo_Producto", obj.oProducto.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Producto ", obj.oProducto.Nombre);
                cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                cmd.Parameters.AddWithValue("Ubicacion_Almacen", obj.UbicacionAlmacen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                respuesta = false;
                mensaje = inv.Message;
            }
            return respuesta;
        }
        public bool eliminarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PRODUCTO_INVENTARIO", ConexionBD());
                cmd.Parameters.AddWithValue("Id_Inventario", obj.IdInventario);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                respuesta = false;
                mensaje = inv.Message;

            }
            return respuesta;
        }
       
        //Reclamo
        public List<Reclamo> mostrarReclamo()
        {
            List<Reclamo> listaMostrarReclamo = new List<Reclamo>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_RECLAMO, c.ID_CLIENTE, c.DOCUMENTO, c.NOMBRES, c.CORREO_ELECTRONICO, DESCRIPCION, r.ESTADO FROM RECLAMO r");
                mostrar.AppendLine("INNER JOIN CLIENTE c ON c.ID_CLIENTE = r.ID_CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarReclamo.Add(new Reclamo()
                    {
                        IdReclamo = Convert.ToInt32(leer["ID_RECLAMO"]),
                        oCliente = new Cliente() { IdCliente = Convert.ToInt32(leer["ID_CLIENTE"]), Documento = leer["DOCUMENTO"].ToString(), Nombres = leer["NOMBRES"].ToString(), CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString() },
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception of)
            {
                listaMostrarReclamo = new List<Reclamo>();
            }
            return listaMostrarReclamo;
        }
        public bool editarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_RECLAMO", ConexionBD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
        public bool eliminarReclamo(Reclamo obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_RECLAMO", ConexionBD());
                cmd.Parameters.AddWithValue("Id_Reclamo", obj.IdReclamo);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;

            }
            return respuesta;
        }
    }
}
