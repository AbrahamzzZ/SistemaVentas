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

        //Metodo que muestra el correlativo de cada Compra
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

        //Metodo que permite registrar un nueva Compra
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

        //Metodo que muestra la cantidad de la Compra de cada Producto
        public int ObtenerCantidadComprada(int idProducto)
        {
            int cantidadComprada = 0;
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT SUM(Cantidad) AS CantidadComprada FROM DETALLE_COMPRA WHERE ID_PRODUCTO = @IdProducto");

                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cantidadComprada = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                }
            }
            catch (Exception inv)
            {
                cantidadComprada = 0;
            }
            return cantidadComprada;
        }

        //Metodo que muestra la informacion de la Compra
        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("select c.ID_COMPRA, u.NOMBRE_COMPLETO, pr.DOCUMENTO, pr.NOMBRES, t.DOCUMENTO[DOCUMENTO_TRANSPORTISTA], t.NOMBRES[NOMBRE_TRANSPORTISTA], c.TIPO_DOCUMENTO, c.NUMERO_DOCUMENTO, c.MONTO_TOTAL, convert(char(10),c.FECHA_COMPRA,103)[FECHA_COMPRA]");
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
                        oProveedor = new Proveedor() { Documento = leer["DOCUMENTO"].ToString(), Nombres = leer["NOMBRES"].ToString() },
                        oTransportista = new Transportista() { Documento = leer["DOCUMENTO_TRANSPORTISTA"].ToString(), Nombres = leer["NOMBRE_TRANSPORTISTA"].ToString() },
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

        //Metodo que muestra el detalle de la Compra
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

        //Metodo que me muestra los productos mas Comprados
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
