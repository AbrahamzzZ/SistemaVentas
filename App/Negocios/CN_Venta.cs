using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocios
{
    public class CN_Venta
    {
        private CD_Venta ObjetoVenta = new CD_Venta();

        public int MostrarCorrelativoVenta()
        {
            return ObjetoVenta.ObtenerCorrelativoVenta();
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string mensaje)
        {
            return ObjetoVenta.RegistrarVenta(obj, DetalleVenta, out mensaje);
        }

        public bool RestarSotckProducto(int idProducto, int cantidad)
        {
            return ObjetoVenta.RestarSotck(idProducto, cantidad);
        }

        public bool SumarSotckProducto(int idProducto, int cantidad)
        {
            return ObjetoVenta.SumarSotck(idProducto, cantidad);
        }

        public Venta DetalleVenta(string numero)
        {
            Venta oVenta = ObjetoVenta.ObtenerVenta(numero);
            if (oVenta.IdVenta != 0)
            {
                List<Detalle_Venta> oDetalleVenta = ObjetoVenta.ObtenerDetalleVenta(oVenta.IdVenta);
                oVenta.oDetalle_Venta = oDetalleVenta;

            }
            return oVenta;
        }
        
        public DataTable GraficoVenta()
        {
            return ObjetoVenta.GraficaProductosVendidos();
        }
    }
}
