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
    public class CN_Compra
    {
        private CD_Compra ObjetoCompra = new CD_Compra();

        /// <summary>
        /// Método que obtiene el correlativo de compra.
        /// </summary>
        /// <returns>Un entero que indica el correlativo de compra.</returns>
        public int MostrarCorrelativoCompra()
        {
            return ObjetoCompra.ObtenerCorrelativoCompra();
        }

        /// <summary>
        /// Método que registra una nueva compra.
        /// </summary>
        /// <param name="obj">El objeto Compra a registrar.</param>
        /// <param name="DetalleCompra">Los detalles de la compra en formato DataTable.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string mensaje)
        {
            return ObjetoCompra.RegistrarCompra(obj, DetalleCompra, out mensaje);
        }

        /// <summary>
        /// Método que obtiene los detalles de una compra específica.
        /// </summary>
        /// <param name="numero">El número de la compra.</param>
        /// <returns>Un objeto Compra con los detalles de la compra.</returns>
        public Compra DetalleCompra(string numero)
        {
            Compra oCompra = ObjetoCompra.ObtenerCompra(numero);
            if (oCompra.IdCompra != 0)
            {
                List<Detalle_Compra> oDetalleCompra = ObjetoCompra.ObtenerDetalleCompra(oCompra.IdCompra);

                oCompra.oDetalle_Compra = oDetalleCompra;
            }
            return oCompra;
        }

        /// <summary>
        /// Método que obtiene los datos para la gráfica de productos comprados.
        /// </summary>
        /// <returns>Un DataTable con los datos de la gráfica.</returns>
        public DataTable GraficaCompra()
        {
            return ObjetoCompra.GraficaProductosComprados();
        }
    }
}
