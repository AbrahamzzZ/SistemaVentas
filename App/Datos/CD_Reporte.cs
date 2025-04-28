﻿using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Reporte
    {
        private readonly Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra un reporte de las Compras realizadas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte</param>
        /// <param name="fechaFin">Fecha de fin del reporte</param>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <param name="idTransportista">ID del transportista</param>
        /// <returns>Una lista de objetos de tipo Reporte_Compra</returns>
        public List<Reporte_Compra> ReporteCompra(string fechaInicio, string fechaFin, int idProveedor, int idTransportista)
        {
            List<Reporte_Compra> lista = new List<Reporte_Compra>();
            try
            {
                StringBuilder reporte = new StringBuilder();
                SqlCommand cmd = new SqlCommand("PA_REPORTE_COMPRA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Fecha_Inicio", fechaInicio);
                cmd.Parameters.AddWithValue("Fecha_Fin", fechaFin);
                cmd.Parameters.AddWithValue("Id_Proveedor", idProveedor);
                cmd.Parameters.AddWithValue("Id_Transportista", idTransportista);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    lista.Add(new Reporte_Compra()
                    {
                        FechaRegistro = leer["FECHA_COMPRA"].ToString(),
                        Sucursal = leer["NOMBRE_SUCURSAL"].ToString(),
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        MontoTotal = leer["MONTO_TOTAL"].ToString(),
                        UsuarioRegistro = leer["NOMBRE_USUARIO"].ToString(),
                        DocumentoProveedor = leer["CODIGO"].ToString(),
                        NombreProveedor = leer["NOMBRE_PROVEEDOR"].ToString(),
                        DocumentoTranportista = leer["CODIGO_TRANSPORTISTA"].ToString(),
                        NombreTransportista = leer["NOMBRE_TRANSPORTISTA"].ToString(),
                        CodigoProducto = leer["CODIGO_PRODUCTO"].ToString(),
                        NombreProducto = leer["NOMBRE_PRODUCTO"].ToString(),
                        Categoria = leer["CATEGORIA"].ToString(),
                        PrecioCompra = leer["PRECIO_COMPRA"].ToString(),
                        PrecioVenta = leer["PRECIO_VENTA"].ToString(),
                        Cantidad = leer["CANTIDAD"].ToString(),
                        SubTotal = leer["SUBTOTAL"].ToString()
                    });
                }
            }
            catch (Exception rep)
            {
                Console.WriteLine($"Error al generar el reporte de compra: {rep.Message}");
            }
            return lista;
        }

        /// <summary>
        /// Método que muestra un reporte de las Ventas realizadas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte</param>
        /// <param name="fechaFin">Fecha de fin del reporte</param>
        /// <returns>Una lista de objetos de tipo Reporte_Venta</returns>
        public List<Reporte_Venta> ReporteVenta(string fechaInicio, string fechaFin)
        {
            List<Reporte_Venta> lista = new List<Reporte_Venta>();
            try
            {
                StringBuilder reporte = new StringBuilder();
                SqlCommand cmd = new SqlCommand("PA_REPORTE_VENTA", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("fecha_Inicio", fechaInicio);
                cmd.Parameters.AddWithValue("fecha_Fin", fechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    lista.Add(new Reporte_Venta()
                    {
                        FechaRegistro = leer["FECHA_VENTA"].ToString(),
                        Sucursal = leer["NOMBRE_SUCURSAL"].ToString(),
                        TipoDocumento = leer["TIPO_DOCUMENTO"].ToString(),
                        NumeroDocumento = leer["NUMERO_DOCUMENTO"].ToString(),
                        MontoTotal = leer["MONTO_TOTAL"].ToString(),
                        UsuarioRegistro = leer["NOMBRE_USUARIO"].ToString(),
                        CedulaCliente = leer["CEDULA"].ToString(),
                        NombreCliente = leer["NOMBRES"].ToString(),
                        CodigoProducto = leer["CODIGO_PRODUCTO"].ToString(),
                        NombreProducto = leer["NOMBRE_PRODUCTO"].ToString(),
                        Categoria = leer["CATEGORIA"].ToString(),
                        PrecioVenta = leer["PRECIO_VENTA"].ToString(),
                        Cantidad = leer["CANTIDAD"].ToString(),
                        SubTotal = leer["SUBTOTAL"].ToString(),
                        Descuento = leer["DESCUENTO"].ToString()
                    });
                }
            }
            catch (Exception rep)
            {
                Console.WriteLine($"Error al generar el reporte de venta: {rep.Message}");
            }
            return lista;
        }
    }
}
