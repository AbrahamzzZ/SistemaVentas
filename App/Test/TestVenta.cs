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

            venta.TipoDocumento = "01";
            venta.NumeroDocumento = "123456789";
            venta.DocumentoCliente = "123456789";
            venta.NombreCliente = "Roberto Perez";
            venta.MontoPago = 100;
            venta.MontoCambio = 100;
            venta.MontoTotal = 100;
            venta.Descuento = 100;
            venta.FechaVenta = "2024-11-22";

            // Detalle de venta
            //venta.oDetalle_Venta = new List<Detalle_Venta>();
            //Detalle_Venta detalleVenta = new Detalle_Venta();

            CapaDatos datos = new CapaDatos();
            string mensaje = "";
            Assert.IsTrue(datos.registrarVenta(venta, null, out mensaje));

        }
    }
}
