using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Venta"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Venta
    {
        /// <summary>
        /// Método que muestra el correlativo de cada Venta
        /// </summary>
        /// <returns>El número correlativo de la venta</returns>
        int ObtenerCorrelativoVenta();

        /// <summary>
        /// Método que suma el stock del Producto después de cancelar la Venta
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="cantidad">Cantidad a sumar al stock</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool SumarSotck(int idProducto, int cantidad);

        /// <summary>
        /// Método que resta el stock del Producto después de la Venta
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <param name="cantidad">Cantidad a restar del stock</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool RestarStock(int idProducto, int cantidad);

        /// <summary>
        /// Método que permite registrar la Venta
        /// </summary>
        /// <param name="obj">Objeto de tipo Venta que contiene los datos de la nueva venta</param>
        /// <param name="DetalleVenta">DataTable que contiene los detalles de la venta</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool RegistrarVenta(Venta obj, DataTable DetalleVenta, out string Mensaje);

        /// <summary>
        /// Método que muestra la información de la Venta
        /// </summary>
        /// <param name="numero">Número del documento de la venta</param>
        /// <returns>Un objeto de tipo Venta con la información de la venta</returns>
        Venta ObtenerVenta(string numero);

        /// <summary>
        /// Método que muestra el detalle de la Venta
        /// </summary>
        /// <param name="idVenta">ID de la venta</param>
        /// <returns>Una lista de objetos de tipo Detalle_Venta con los detalles de la venta</returns>
        List<Detalle_Venta> ObtenerDetalleVenta(int idVenta);

        /// <summary>
        /// Método que muestra los productos más vendidos
        /// </summary>
        /// <returns>Un DataTable con los productos más vendidos</returns>
        DataTable GraficaProductosVendidos();

        /// <summary>
        /// Método que muestra a los clientes que más han comprado
        /// </summary>
        /// <returns>Un DataTable con el top de los clientes</returns>
        DataTable GraficaTopClientes();

        /// <summary>
        /// Método que muestra las ventas realizadas de cada empleado
        /// </summary>
        /// <returns>Un DataTable con las ventas de los empleados</returns>
        DataTable GraficaVentaCadaEmpleado();

        /// <summary>
        /// Método que muestra las sucursales donde mas han vendido productos
        /// </summary>
        /// <returns>Un DataTable con las ventas de cada sucursal</returns>
        DataTable GraficaSucursalesVentas();
    }
}
