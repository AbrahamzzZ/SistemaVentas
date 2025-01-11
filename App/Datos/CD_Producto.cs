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
    public class CD_Producto
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Metodo que muestra una lista de todos los Productos que existen
        /// </summary>
        /// <returns></returns>
        public List<Producto> MostrarProductos()
        {
            List<Producto> listaMostrarProducto = new List<Producto>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID_PRODUCTO, p.CODIGO, NOMBRE_PRODUCTO, p.DESCRIPCION, c.ID_CATEGORIA, c.DESCRIPCION[DESCRIPCION_CATEGORIA], u.ID_UNIDAD_MEDIDA, u.DESCRIPCION[DESCRIPCION_UNIDAD_MEDIDA], PAIS_ORIGEN, STOCK, PRECIO_COMPRA, PRECIO_VENTA, p.ESTADO FROM PRODUCTO P");
                mostrar.AppendLine("inner join CATEGORIA c on c.ID_CATEGORIA = p.ID_CATEGORIA");
                mostrar.AppendLine("inner join UNIDAD_MEDIDA u on u.ID_UNIDAD_MEDIDA = p.ID_UNIDAD_MEDIDA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProducto.Add(new Producto()
                    {
                        IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombre = leer["NOMBRE_PRODUCTO"].ToString(),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                        oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(leer["ID_CATEGORIA"]), Descripcion = leer["DESCRIPCION_CATEGORIA"].ToString() },
                        oUnidadMedida = new Unidad_Medida() { IdUnidadMedida = Convert.ToInt32(leer["ID_UNIDAD_MEDIDA"]), Descripcion = leer["DESCRIPCION_UNIDAD_MEDIDA"].ToString() },
                        PaisOrigen = leer["PAIS_ORIGEN"].ToString(),
                        Stock = Convert.ToInt32(leer["STOCK"]),
                        PrecioCompra = Convert.ToDecimal(leer["PRECIO_COMPRA"]),
                        PrecioVenta = Convert.ToDecimal(leer["PRECIO_VENTA"]),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception pr)
            {
                Console.WriteLine($"Error al mostrar productos: {pr.Message}");
                throw;
            }
            return listaMostrarProducto;
        }

        /// <summary>
        /// Método que permite registrar un nuevo Producto
        /// </summary>
        /// <param name="obj">Objeto de tipo Producto que contiene los datos del nuevo producto</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del producto generado, o 0 si hubo un error</returns>
        public int RegistrarProducto(Producto obj, out string Mensaje)
        {
            int IdProductoGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PRODUCTO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Id_Categoria", obj.oCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.oUnidadMedida.IdUnidadMedida);
                cmd.Parameters.AddWithValue("Pais_Origen", obj.PaisOrigen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                IdProductoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                IdProductoGenerado = 0;
                Mensaje = pr.Message;

            }
            return IdProductoGenerado;
        }

        /// <summary>
        /// Método que permite editar la información de un Producto ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Producto que contiene los datos actualizados del producto</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EditarProducto(Producto obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PRODUCTO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Producto", obj.IdProducto);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("Id_Categoria", obj.oCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("Id_Unidad_Medida", obj.oUnidadMedida.IdUnidadMedida);
                cmd.Parameters.AddWithValue("Pais_Origen", obj.PaisOrigen);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                Respuesta = false;
                Mensaje = pr.Message;

            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite eliminar a un Producto
        /// </summary>
        /// <param name="obj">Objeto de tipo Producto que contiene el ID del producto a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool EliminarProducto(Producto obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PRODUCTO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Producto", obj.IdProducto);
                cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                Respuesta = false;
                Mensaje = pr.Message;

            }
            return Respuesta;
        }

        /// <summary>
        /// Método que muestra el stock de un producto específico, esto sirve para el inventario.
        /// </summary>
        /// <param name="IdProducto">El ID del producto.</param>
        /// <returns>Un entero que indica el stock del producto.</returns>
        public int MostrarProductoStock(int IdProducto)
        {
            int stock = 0;
            try
            {
                string query = "SELECT STOCK FROM PRODUCTO WHERE ID_PRODUCTO = @idProducto";
                using (SqlConnection connection = Conexion.ConexionBD())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProducto", IdProducto);
                        stock = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener stock del producto: {ex.Message}");
                throw;
            }
            return stock;
        }

        /// <summary>
        /// Método que lista todos los productos que tienen stock disponible, esto es para el inventario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Producto.</returns>
        public List<Producto> ListarProductosConStock()
        {
            List<Producto> listaProductos = new List<Producto>();
            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT * FROM PRODUCTO");
                query.AppendLine("WHERE Estado = 1 AND Stock > 0");

                SqlCommand cmd = new SqlCommand(query.ToString(), Conexion.ConexionBD());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto obj = new Producto();
                    obj.IdProducto = Convert.ToInt32(reader["Id_Producto"]);
                    obj.Nombre = reader["Nombre_Producto"].ToString();
                    obj.Stock = Convert.ToInt32(reader["Stock"]);
                    obj.Estado = Convert.ToBoolean(reader["Estado"]);
                    listaProductos.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar productos con stock: {ex.Message}");
            }
            return listaProductos;
        }
    }
}
