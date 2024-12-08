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
    public class CD_Inventario
    {

        Conexion Conexion = new Conexion();

        //Metodo que muestra una lista de todos los Productos en el Inventario
        public List<Inventario> MostrarProductoInventario()
        {
            List<Inventario> listaMostrarProductoInventario = new List<Inventario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT i.ID_INVENTARIO,p.ID_PRODUCTO,p.CODIGO AS CODIGO_PRODUCTO, p.NOMBRE_PRODUCTO AS NOMBRE_PRODUCTO, i.CANTIDAD, i.UBICACION_ALMACEN, p.ESTADO, i.FECHA_INGRESO FROM INVENTARIO i");
                mostrar.AppendLine("INNER JOIN PRODUCTO p ON p.ID_PRODUCTO = i.ID_PRODUCTO");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
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

        //Metodo que permite registrar un Producto en el Inventario
        public int AgregarProductoInventario(Inventario obj, out string mensaje)
        {
            int idInventarioGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PRODUCTO_INVENTARIO", Conexion.ConexionBD());
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

        //Metodo que permite editar la informacion del Producto en el Inventario
        public bool EditarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PRODUCTO_INVENTARIO", Conexion.ConexionBD());
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

        //Metodo que permite eliminar un Producto en el Inventario
        public bool EliminarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PRODUCTO_INVENTARIO", Conexion.ConexionBD());
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
    }
}
