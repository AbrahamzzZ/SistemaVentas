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
        private CD_Reporte ObjetoReporte = new CD_Reporte();

        public List<Reporte_Compra> ReporteProductosComprados(string fechaInicio, string fechaFin, int idProveedor, int idTransportista)
        {
            return ObjetoReporte.ReporteCompra(fechaInicio, fechaFin, idProveedor, idTransportista);
        }

        public List<Reporte_Venta> ReporteProductosVendidos(string fechaInicio, string fechaFin)
        {
            return ObjetoReporte.ReporteVenta(fechaInicio, fechaFin);
        }
    }
}
