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
            Venta venta = new Venta
            {
                oUsuario = new Usuario { IdUsuario = 1 },
                TipoDocumento = "Factura",
                oCliente = new Cliente { IdCliente = 3 },
                NumeroDocumento = "00003",
                MontoPago = 120.00m,     
                MontoCambio = 1.00m,                   
                MontoTotal = 85.00m,                   
                Descuento = 84.00m,
                FechaVenta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
            };

            // Crear el DataTable para los detalles de la venta
            DataTable DetalleVenta = new DataTable();
            DetalleVenta.Columns.Add("IdProducto", typeof(int));
            DetalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
            DetalleVenta.Columns.Add("Cantidad", typeof(int));
            DetalleVenta.Columns.Add("SubTotal", typeof(decimal));
            DetalleVenta.Columns.Add("Descuento", typeof(decimal));

            // Agregar un producto al detalle de la venta
            DetalleVenta.Rows.Add(2, 60.00m, 2, 120.00m, 84.00m);
            string mensaje;
            bool resultado = ObjetoVenta.RegistrarVenta(venta, DetalleVenta, out mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual("Venta registrada con éxito", mensaje);
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
