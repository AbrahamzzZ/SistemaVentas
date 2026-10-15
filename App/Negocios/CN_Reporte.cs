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
        private readonly ICD_Reporte ObjetoReporte;

        /// <summary>
        /// Constructor usado por la aplicación.
        /// </summary>
        public CN_Reporte() : this(new CD_Reporte())
        {
        }

        /// <summary>
        /// Constructor usado para inyectar un mock en las pruebas unitarias.
        /// </summary>
        /// <param name="datos">Implementación de la capa de datos.</param>
        public CN_Reporte(ICD_Reporte datos)
        {
            ObjetoReporte = datos ?? throw new ArgumentNullException(nameof(datos));
        }

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
