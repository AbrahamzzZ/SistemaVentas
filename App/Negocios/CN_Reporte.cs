using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocios
{
    public class CN_Reporte
    {
        private readonly CD_Reporte ObjetoReporte = new CD_Reporte();

        /// <summary>
        /// Método que genera un reporte de productos comprados.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte.</param>
        /// <param name="fechaFin">Fecha de fin del reporte.</param>
        /// <param name="idProveedor">ID del proveedor.</param>
        /// <param name="idTransportista">ID del transportista.</param>
        /// <returns>Una lista de objetos de tipo Reporte_Compra.</returns>
        public List<Reporte_Compra> ReporteProductosComprados(string fechaInicio, string fechaFin, int idProveedor, int idTransportista)
        {
            return ObjetoReporte.ReporteCompra(fechaInicio, fechaFin, idProveedor, idTransportista);
        }

        /// <summary>
        /// Método que genera un reporte de productos vendidos.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte.</param>
        /// <param name="fechaFin">Fecha de fin del reporte.</param>
        /// <returns>Una lista de objetos de tipo Reporte_Venta.</returns>
        public List<Reporte_Venta> ReporteProductosVendidos(string fechaInicio, string fechaFin)
        {
            return ObjetoReporte.ReporteVenta(fechaInicio, fechaFin);
        }
    }
}
