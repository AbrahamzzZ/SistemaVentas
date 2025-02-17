using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Datos
{
    public class CD_Venta
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra el correlativo de cada Venta
        /// </summary>
        /// <returns>El número correlativo de la venta</returns>
        public int ObtenerCorrelativoVenta()
        {
            int IdCorrelativo = 0;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("SELECT count (*) + 1 FROM VENTA;");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                IdCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception co)
            {
                Console.WriteLine($"Error al tener el correlativo de la venta realizada: {co.Message}");
                IdCorrelativo = 0;
            }
            return IdCorrelativo;
        }

        /// <summary>
        /// Método que suma el stock del Producto después de cancelar la Venta
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="cantidad">Cantidad a sumar al stock</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool SumarSotck(int idProducto, int cantidad)
        {
            bool Respuesta = true;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("UPDATE PRODUCTO SET STOCK = STOCK + @Cantidad WHERE Id_Producto = @idProducto");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.CommandType = CommandType.Text;

                Respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ve)
            {
                Console.WriteLine($"Error al actualizar el stock: {ve.Message}");
                Respuesta = false;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que resta el stock del Producto después de la Venta
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="cantidad">Cantidad a restar del stock</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool RestarStock(int idProducto, int cantidad)
        {
            bool Respuesta = true;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("UPDATE PRODUCTO SET STOCK = STOCK - @Cantidad WHERE Id_Producto = @idProducto");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.CommandType = CommandType.Text;

                Respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (SqlException ve)
            {
                Console.WriteLine($"Error al actualizar el stock: {ve.Message}");
                Respuesta = false;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que permite registrar la Venta
        /// </summary>
        /// <param name="obj">Objeto de tipo Venta que contiene los datos de la nueva venta</param>
        /// <param name="DetalleVenta">DataTable que contiene los detalles de la venta</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool RegistrarVenta(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_VENTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("Tipo_Documento", obj.TipoDocumento);
                cmd.Parameters.AddWithValue("Numero_Documento", obj.NumeroDocumento);
                cmd.Parameters.AddWithValue("Id_Sucursal", obj.oSucursal.IdSucursal);
                cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.IdCliente);
                cmd.Parameters.AddWithValue("Monto_Pago", obj.MontoPago);
                cmd.Parameters.AddWithValue("Monto_Cambio", obj.MontoCambio);
                cmd.Parameters.AddWithValue("Monto_Total", obj.MontoTotal);
                cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                cmd.Parameters.AddWithValue("Detalle_Venta", DetalleVenta);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ve)
            {
                Respuesta = false;
                Console.WriteLine($"Error al registrar la venta: {ve.Message}");
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que muestra la información de la Venta
        /// </summary>
        /// <param name="numero">Número del documento de la venta</param>
        /// <returns>Un objeto de tipo Venta con la información de la venta</returns>
        public Venta ObtenerVenta(string numero)
        {
            Venta obj = new Venta();
            try
            {
                StringBuilder obtener = new StringBuilder();
                obtener.AppendLine("SELECT V.ID_VENTA, U.NOMBRE_COMPLETO, S.NOMBRE_SUCURSAL, V.TIPO_DOCUMENTO, V.NUMERO_DOCUMENTO, C.CEDULA, C.NOMBRES, V.MONTO_PAGO, V.MONTO_CAMBIO, V.MONTO_TOTAL, V.DESCUENTO, Convert(char(10),V.FECHA_VENTA,103)[FECHA_VENTA] from VENTA V");
                obtener.AppendLine("inner join USUARIO U on U.ID_USUARIO = V.ID_USUARIO");
                obtener.AppendLine("inner join CLIENTE C on C.ID_CLIENTE = V.ID_CLIENTE");
                obtener.AppendLine("inner join SUCURSAL S on S.ID_SUCURSAL = V.ID_SUCURSAL");
                obtener.AppendLine("WHERE V.NUMERO_DOCUMENTO = @numero");

                SqlCommand cmd = new SqlCommand(obtener.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    obj = new Venta()
                    {
                        IdVenta = int.Parse(leer["ID_VENTA"].ToString()),
                        oUsuario = new Usuario() { NombreCompleto = leer["NOMBRE_COMPLETO"].ToString() },
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        oSucursal = new Sucursal() { Nombre = leer["NOMBRE_SUCURSAL"].ToString() },
                        oCliente = new Cliente() { Cedula = leer["CEDULA"].ToString(), Nombres = leer["NOMBRES"].ToString() },
                        MontoPago = Convert.ToDecimal(leer["MONTO_PAGO"].ToString()),
                        MontoCambio = Convert.ToDecimal(leer["MONTO_CAMBIO"].ToString()),
                        MontoTotal = Convert.ToDecimal(leer["MONTO_TOTAL"].ToString()),
                        Descuento = Convert.ToDecimal(leer["DESCUENTO"].ToString()),
                        FechaVenta = leer["FECHA_VENTA"].ToString()
                    };
                }
            }
            catch (Exception ve)
            {
                obj = new Venta();
                Console.WriteLine($"Error al obtener la información de la venta: {ve.Message}");
            }
            return obj;
        }

        /// <summary>
        /// Método que muestra el detalle de la Venta
        /// </summary>
        /// <param name="idVenta">ID de la venta</param>
        /// <returns>Una lista de objetos de tipo Detalle_Venta con los detalles de la venta</returns>
        public List<Detalle_Venta> ObtenerDetalleVenta(int idVenta)
        {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();
            try
            {
                StringBuilder obtener = new StringBuilder();
                obtener.AppendLine("SELECT p.NOMBRE_PRODUCTO, dv.PRECIO_VENTA, dv.CANTIDAD_PRODUCTO, dv.SUBTOTAL, dv.DESCUENTO from DETALLE_VENTA dv");
                obtener.AppendLine("inner join PRODUCTO p on p.ID_PRODUCTO = dv.ID_PRODUCTO");
                obtener.AppendLine("WHERE dv.ID_VENTA = @idVenta");

                SqlCommand cmd = new SqlCommand(obtener.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.CommandType = CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    oLista.Add(new Detalle_Venta()
                    {
                        oProducto = new Producto() { Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        PrecioVenta = Convert.ToDecimal(leer["PRECIO_VENTA"].ToString()),
                        CantidadProducto = Convert.ToInt32(leer["CANTIDAD_PRODUCTO"].ToString()),
                        SubTotal = Convert.ToDecimal(leer["SUBTOTAL"].ToString()),
                        Descuento = Convert.ToDecimal(leer["DESCUENTO"].ToString())
                    });
                }
            }
            catch (Exception dev)
            {
                Console.WriteLine($"Error al obtener el detalle de la venta: {dev.Message}");
            }
            return oLista;
        }

        /// <summary>
        /// Método que muestra los productos más vendidos
        /// </summary>
        /// <returns>Un DataTable con los productos más vendidos</returns>
        public DataTable GraficaProductosVendidos()
        {
            DataTable tabla = new DataTable();
            try
            {
                StringBuilder grafica = new StringBuilder();
                grafica.AppendLine("SELECT P.NOMBRE_PRODUCTO, COUNT(DV.ID_PRODUCTO) AS CANTIDAD_VENDIDA FROM DETALLE_VENTA DV");
                grafica.AppendLine("INNER JOIN PRODUCTO P ON DV.ID_PRODUCTO = P.ID_PRODUCTO GROUP BY P.NOMBRE_PRODUCTO;");

                SqlCommand cmd = new SqlCommand(grafica.ToString(), Conexion.ConexionBD());
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(tabla);
            }
            catch (Exception gr)
            {
                Console.WriteLine("Error: " + gr.Message);
            }
            return tabla;
        }

        /// <summary>
        /// Método que muestra a los clientes que más han comprado
        /// </summary>
        /// <returns>Un DataTable con el top de los clientes</returns>
        public DataTable GraficaTopClientes()
        {
            DataTable tabla = new DataTable();
            try
            {
                StringBuilder grafica = new StringBuilder();
                grafica.AppendLine("SELECT CL.NOMBRES, COUNT(V.ID_CLIENTE) AS COMPRAS_TOTALES FROM VENTA V");
                grafica.AppendLine("INNER JOIN CLIENTE CL ON V.ID_CLIENTE = CL.ID_CLIENTE GROUP BY CL.NOMBRES;");

                SqlCommand cmd = new SqlCommand(grafica.ToString(), Conexion.ConexionBD());
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(tabla);
            }
            catch (Exception gr)
            {
                Console.WriteLine("Error: " + gr.Message);
            }
            return tabla;
        }

        /// <summary>
        /// Método que muestra las ventas realizadas de cada empleado
        /// </summary>
        /// <returns>Un DataTable con las ventas de los empleados</returns>
        public DataTable GraficaVentaCadaEmpleado()
        {
            DataTable tabla = new DataTable();
            try
            {
                StringBuilder grafica = new StringBuilder();
                grafica.AppendLine("SELECT U.NOMBRE_COMPLETO, COUNT(V.ID_USUARIO) AS VENTAS_EMPLEADO FROM VENTA V");
                grafica.AppendLine("INNER JOIN USUARIO U ON V.ID_USUARIO = U.ID_USUARIO GROUP BY U.NOMBRE_COMPLETO;");

                SqlCommand cmd = new SqlCommand(grafica.ToString(), Conexion.ConexionBD());
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(tabla);
            }
            catch (Exception gr)
            {
                Console.WriteLine("Error: " + gr.Message);
            }
            return tabla;
        }
    }
}
