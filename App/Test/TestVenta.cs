using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestVenta
    {
        [TestMethod]
        public void RegistrarVenta()
        {
            CD_Venta ObjetoVenta = new CD_Venta();
            Venta venta = new Venta();

            venta.oUsuario = new Usuario();
            venta.oUsuario.IdUsuario = 1;

            venta.TipoDocumento = "boleta";
            venta.NumeroDocumento = "00001";
            venta.oCliente = new Cliente();
            venta.oCliente.IdCliente = 2;
            venta.MontoPago = 16.00m;
            venta.MontoCambio = 1.00m;
            venta.MontoTotal = 15.00m;
            venta.Descuento = 0.00m;
            venta.FechaVenta = "2024-11-22 12:00:00";

            // Detalle de venta
            venta.oDetalle_Venta = new List<Detalle_Venta>();
            Detalle_Venta detalleVenta = new Detalle_Venta();
            string mensaje = "";

            Assert.IsTrue(ObjetoVenta.RegistrarVenta(venta, null, out mensaje));
        }
    }
}
