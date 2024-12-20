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

        public int MostrarCorrelativoCompra()
        {
            return ObjetoCompra.ObtenerCorrelativoCompra();
        }

        public bool Registrar(Compra obj, DataTable DetalleCompra, out string mensaje)
        {
            return ObjetoCompra.RegistrarCompra(obj, DetalleCompra, out mensaje);
        }

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

        public DataTable GraficaCompra()
        {
            return ObjetoCompra.GraficaProductosComprados();
        }

    }
}
