using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Reporte"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Reporte
    {
        /// <summary>
        /// Método que muestra un reporte de las Compras realizadas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte</param>
        /// <param name="fechaFin">Fecha de fin del reporte</param>
        /// <param name="idProveedor">ID del proveedor</param>
        /// <param name="idTransportista">ID del transportista</param>
        /// <returns>Una lista de objetos de tipo Reporte_Compra</returns>
        List<Reporte_Compra> ReporteCompra(string fechaInicio, string fechaFin, int idProveedor, int idTransportista);

        /// <summary>
        /// Método que muestra un reporte de las Ventas realizadas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte</param>
        /// <param name="fechaFin">Fecha de fin del reporte</param>
        /// <returns>Una lista de objetos de tipo Reporte_Venta</returns>
        List<Reporte_Venta> ReporteVenta(string fechaInicio, string fechaFin);
    }
}
