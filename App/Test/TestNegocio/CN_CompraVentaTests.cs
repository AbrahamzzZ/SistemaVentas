using System.Data;

namespace Test.CapaNegocio
{
    /// <summary>
    /// Compra y Venta solo tienen lógica propia al armar el detalle: el detalle se consulta
    /// únicamente cuando la cabecera existe (Id distinto de 0).
    /// </summary>
    [TestClass]
    public sealed class CN_CompraVentaTests
    {
        [TestMethod]
        public void DetalleCompra_CompraExistente_CargaSuDetalle()
        {
            var detalle = new List<Detalle_Compra> { new Detalle_Compra() };
            var datos = new Mock<ICD_Compra>();
            datos.Setup(d => d.ObtenerCompra("00001")).Returns(new Compra { IdCompra = 3, NumeroDocumento = "00001" });
            datos.Setup(d => d.ObtenerDetalleCompra(3)).Returns(detalle);

            Compra compra = new CN_Compra(datos.Object).DetalleCompra("00001");

            Assert.AreEqual(3, compra.IdCompra);
            Assert.AreSame(detalle, compra.oDetalle_Compra);
        }

        [TestMethod]
        public void DetalleCompra_CompraInexistente_NoConsultaElDetalle()
        {
            var datos = new Mock<ICD_Compra>();
            datos.Setup(d => d.ObtenerCompra("99999")).Returns(new Compra());

            Compra compra = new CN_Compra(datos.Object).DetalleCompra("99999");

            Assert.AreEqual(0, compra.IdCompra);
            datos.Verify(d => d.ObtenerDetalleCompra(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void RegistrarCompra_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Compra>();
            var compra = new Compra { NumeroDocumento = "00002" };
            var detalle = new DataTable();
            string mensajeDatos = "Compra registrada.";
            datos.Setup(d => d.RegistrarCompra(compra, detalle, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Compra(datos.Object).Registrar(compra, detalle, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        public void DetalleVenta_VentaExistente_CargaSuDetalle()
        {
            var detalle = new List<Detalle_Venta> { new Detalle_Venta() };
            var datos = new Mock<ICD_Venta>();
            datos.Setup(d => d.ObtenerVenta("00001")).Returns(new Venta { IdVenta = 5, NumeroDocumento = "00001" });
            datos.Setup(d => d.ObtenerDetalleVenta(5)).Returns(detalle);

            Venta venta = new CN_Venta(datos.Object).DetalleVenta("00001");

            Assert.AreEqual(5, venta.IdVenta);
            Assert.AreSame(detalle, venta.oDetalle_Venta);
        }

        [TestMethod]
        public void DetalleVenta_VentaInexistente_NoConsultaElDetalle()
        {
            var datos = new Mock<ICD_Venta>();
            datos.Setup(d => d.ObtenerVenta("99999")).Returns(new Venta());

            Venta venta = new CN_Venta(datos.Object).DetalleVenta("99999");

            Assert.AreEqual(0, venta.IdVenta);
            datos.Verify(d => d.ObtenerDetalleVenta(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void RestarYSumarStock_UsanLaOperacionCorrectaDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Venta>(MockBehavior.Strict);
            datos.Setup(d => d.RestarStock(7, 2)).Returns(true);
            datos.Setup(d => d.SumarSotck(7, 2)).Returns(true);
            var negocio = new CN_Venta(datos.Object);

            Assert.IsTrue(negocio.RestarSotckProducto(7, 2));
            Assert.IsTrue(negocio.SumarSotckProducto(7, 2));
            datos.Verify(d => d.RestarStock(7, 2), Times.Once);
            datos.Verify(d => d.SumarSotck(7, 2), Times.Once);
        }
    }
}
