using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datos
{
    public class CD_Compra
    {
        Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra el correlativo de cada Compra
        /// </summary>
        /// <returns>El número correlativo de la compra</returns>
        public int ObtenerCorrelativoCompra()
        {
            int IdCorrelativo = 0;
            try
            {
                StringBuilder obtenerCorrelatico = new StringBuilder();
                obtenerCorrelatico.AppendLine("SELECT count (*) + 1 FROM COMPRA;");

                SqlCommand cmd = new SqlCommand(obtenerCorrelatico.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                IdCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception co)
            {
                Console.WriteLine($"Error al tener el correlativo de la compra realizada: {co.Message}");
                IdCorrelativo = 0;
            }
            return IdCorrelativo;
        }

        /// <summary>
        /// Método que permite registrar una nueva Compra
        /// </summary>
        /// <param name="obj">Objeto de tipo Compra que contiene los datos de la nueva compra</param>
        /// <param name="DetalleCompra">DataTable que contiene los detalles de la compra</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        public bool RegistrarCompra(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_COMPRA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("Id_Proveedor", obj.oProveedor.IdProveedor);
                cmd.Parameters.AddWithValue("Id_Transportista", obj.oTransportista.IdTransportista);
                cmd.Parameters.AddWithValue("Tipo_Documento", obj.TipoDocumento);
                cmd.Parameters.AddWithValue("Numero_Documento", obj.NumeroDocumento);
                cmd.Parameters.AddWithValue("Monto_Total", obj.MontoTotal);
                cmd.Parameters.AddWithValue("Detalle_Compra", DetalleCompra);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

            }
            catch (Exception co)
            {
                Console.WriteLine($"Error al registrar la compra: {co.Message}");
                Respuesta = false;
                Mensaje = co.Message;
            }
            return Respuesta;
        }

        /// <summary>
        /// Método que muestra la información de la Compra
        /// </summary>
        /// <param name="numero">Número del documento de la compra</param>
        /// <returns>Un objeto de tipo Compra con la información de la compra</returns>
        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("select c.ID_COMPRA, u.NOMBRE_COMPLETO, pr.CEDULA, pr.NOMBRES, t.CEDULA[CEDULA_TRANSPORTISTA], t.NOMBRES[NOMBRE_TRANSPORTISTA], c.TIPO_DOCUMENTO, c.NUMERO_DOCUMENTO, c.MONTO_TOTAL, convert(char(10),c.FECHA_COMPRA,103)[FECHA_COMPRA]");
                mostrar.AppendLine("from COMPRA c inner join USUARIO u on u.ID_USUARIO = c.ID_USUARIO");
                mostrar.AppendLine("inner join PROVEEDOR pr on pr.ID_PROVEEDOR = c.ID_PROVEEDOR");
                mostrar.AppendLine("inner join TRANSPORTISTA t on t.ID_TRANSPORTISTA = c.ID_TRANSPORTISTA");
                mostrar.AppendLine("where c.NUMERO_DOCUMENTO = @numero");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.CommandType = CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    obj = new Compra()
                    {
                        IdCompra = Convert.ToInt32(leer["ID_COMPRA"]),
                        oUsuario = new Usuario() { NombreCompleto = leer["NOMBRE_COMPLETO"].ToString() },
                        oProveedor = new Proveedor() { Cedula = leer["CEDULA"].ToString(), Nombres = leer["NOMBRES"].ToString() },
                        oTransportista = new Transportista() { Cedula = leer["CEDULA_TRANSPORTISTA"].ToString(), Nombres = leer["NOMBRE_TRANSPORTISTA"].ToString() },
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        MontoTotal = Convert.ToDecimal(leer["MONTO_TOTAL"]),
                        FechaCompra = leer["FECHA_COMPRA"].ToString()
                    };
                }
            }
            catch (Exception co)
            {
                Console.WriteLine($"Error al obtener la compra: {co.Message}");
            }
            return obj;
        }

        /// <summary>
        /// Método que muestra el detalle de la Compra
        /// </summary>
        /// <param name="idCompra">ID de la compra</param>
        /// <returns>Una lista de objetos de tipo Detalle_Compra con los detalles de la compra</returns>
        public List<Detalle_Compra> ObtenerDetalleCompra(int idCompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("select p.NOMBRE_PRODUCTO, dc.PRECIO_COMPRA, dc.CANTIDAD, dc.MONTO_TOTAL from DETALLE_COMPRA dc");
                mostrar.AppendLine("inner join PRODUCTO p on p.ID_PRODUCTO = dc.ID_PRODUCTO");
                mostrar.AppendLine("where dc.ID_COMPRA = @idCompra");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.CommandType = CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    oLista.Add(new Detalle_Compra()
                    {
                        oProducto = new Producto() { Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        PrecioCompra = Convert.ToDecimal(leer["PRECIO_COMPRA"].ToString()),
                        Cantidad = Convert.ToInt32(leer["CANTIDAD"].ToString()),
                        MontoTotal = Convert.ToDecimal(leer["MONTO_TOTAL"].ToString()),
                    });
                }
            }
            catch (Exception dec)
            {
                Console.WriteLine($"Error al obtener el detalle de la compra: {dec.Message}");
            }
            return oLista;
        }

        /// <summary>
        /// Método que muestra los productos más comprados
        /// </summary>
        /// <returns>Un DataTable con los productos más comprados</returns>
        public DataTable GraficaProductosComprados()
        {
            DataTable tabla = new DataTable();
            try
            {
                StringBuilder grafica = new StringBuilder();
                grafica.AppendLine("SELECT P.NOMBRE_PRODUCTO, COUNT(DC.ID_PRODUCTO) AS CANTIDAD_COMPRADA FROM DETALLE_COMPRA DC");
                grafica.AppendLine("JOIN PRODUCTO P ON DC.ID_PRODUCTO = P.ID_PRODUCTO GROUP BY P.NOMBRE_PRODUCTO;");

                SqlCommand cmd = new SqlCommand(grafica.ToString(), Conexion.ConexionBD());
                SqlDataAdapter data = new SqlDataAdapter(cmd);

                data.Fill(tabla);
            }
            catch (Exception co)
            {
                Console.WriteLine("Error al generar la gráfica de compras: " + co.Message);
            }
            return tabla;
        }
    }
}
