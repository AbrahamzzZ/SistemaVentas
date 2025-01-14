using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestCompra
    {
        [TestMethod]
        public void RegistrarCompra()
        {
            CD_Compra ObjetoCompra = new CD_Compra();
            Compra compra = new Compra();

            compra.oUsuario = new Usuario();
            compra.oUsuario.IdUsuario = 1;
            compra.oProveedor = new Proveedor();
            compra.oProveedor.IdProveedor = 1;
            compra.oTransportista = new Transportista();
            compra.oTransportista.IdTransportista = 1;
            compra.TipoDocumento = "boleta";
            compra.NumeroDocumento = "00001";
            compra.MontoTotal = 120.00m;
            compra.FechaCompra = "2024-11-22 12:00:00";

            // Detalle de compra
            compra.oDetalle_Compra = new List<Detalle_Compra>();
            Detalle_Compra detalleCompra = new Detalle_Compra();
            string mensaje = "";

            Assert.IsTrue(ObjetoCompra.RegistrarCompra(compra, null, out mensaje));

        }
    }
}
