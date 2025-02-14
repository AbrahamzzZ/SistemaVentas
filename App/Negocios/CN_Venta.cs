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

        /// <summary>
        /// Método que obtiene el correlativo de venta.
        /// </summary>
        /// <returns>Un entero que indica el correlativo de venta.</returns>
        public int MostrarCorrelativoVenta()
        {
            return ObjetoVenta.ObtenerCorrelativoVenta();
        }

        /// <summary>
        /// Método que registra una nueva venta.
        /// </summary>
        /// <param name="obj">El objeto Venta a registrar.</param>
        /// <param name="DetalleVenta">Los detalles de la venta en formato DataTable.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string mensaje)
        {
            return ObjetoVenta.RegistrarVenta(obj, DetalleVenta, out mensaje);
        }

        /// <summary>
        /// Método que suma el stock de un producto.
        /// </summary>
        /// <param name="idProducto">El ID del producto.</param>
        /// <param name="cantidad">La cantidad a sumar.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool RestarSotckProducto(int idProducto, int cantidad)
        {
            return ObjetoVenta.RestarStock(idProducto, cantidad);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public bool SumarSotckProducto(int idProducto, int cantidad)
        {
            return ObjetoVenta.SumarSotck(idProducto, cantidad);
        }

        /// <summary>
        /// Método que obtiene los detalles de una venta específica.
        /// </summary>
        /// <param name="numero">El número de la venta.</param>
        /// <returns>Un objeto Venta con los detalles de la venta.</returns>
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

        /// <summary>
        /// Método que obtiene los datos para la gráfica de productos vendidos.
        /// </summary>
        /// <returns>Un DataTable con los datos de la gráfica.</returns>
        public DataTable GraficoVenta()
        {
            return ObjetoVenta.GraficaProductosVendidos();
        }

        /// <summary>
        /// Método que obtiene los datos para la gráfica de los clientes que mas han comprado.
        /// </summary>
        /// <returns>Un DataTable con los datos de la gráfica.</returns>
        public DataTable GraficoVenta2()
        {
            return ObjetoVenta.GraficaTopClientes();
        }

        /// <summary>
        /// Método que obtiene los datos para la gráfica de las ventas de cada usuario.
        /// </summary>
        /// <returns>Un DataTable con los datos de la gráfica.</returns>
        public DataTable GraficoVenta3()
        {
            return ObjetoVenta.GraficaVentaCadaEmpleado();
        }
    }
}
