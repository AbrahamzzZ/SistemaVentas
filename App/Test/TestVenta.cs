using Datos;
using Entidad;

namespace Test
{
    [TestClass]
    public sealed class TestVenta
    {
        [TestMethod]
        public void RegistrarVenta()
        {
            Venta venta = new Venta();

            // usuario venta
            venta.oUsuario = new Usuario();
            venta.oUsuario.IdUsuario = 1;

            venta.TipoDocumento = "boleta";
            venta.NumeroDocumento = "00001";
            venta.DocumentoCliente = "102";
            venta.NombreCliente = "Emily Sofia";
            venta.MontoPago = 16.00m;
            venta.MontoCambio = 1.00m;
            venta.MontoTotal = 15.00m;
            venta.Descuento = 0.00m;
            venta.FechaVenta = "2024-11-22 12:00:00";

            // Detalle de venta
            //venta.oDetalle_Venta = new List<Detalle_Venta>();
            //Detalle_Venta detalleVenta = new Detalle_Venta();

            CapaDatos datos = new CapaDatos();
            string mensaje = "";
            Assert.IsTrue(datos.registrarVenta(venta, null, out mensaje));

        }
    }
}
