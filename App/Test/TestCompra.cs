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
            Compra compra = new Compra
            {
                oUsuario = new Usuario { IdUsuario = 1 },
                oProveedor = new Proveedor { IdProveedor = 1 },
                oTransportista = new Transportista { IdTransportista = 1 },
                TipoDocumento = "Boleta",
                NumeroDocumento = "00006",
                MontoTotal = 500.00m,
                FechaCompra = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
            };

            // Crear el DataTable para los detalles de la compra
            DataTable DetalleCompra = new DataTable();
            DetalleCompra.Columns.Add("Id_Producto", typeof(int));
            DetalleCompra.Columns.Add("Precio_Compra", typeof(decimal));
            DetalleCompra.Columns.Add("Precio_Venta", typeof(decimal));
            DetalleCompra.Columns.Add("Cantidad", typeof(int));
            DetalleCompra.Columns.Add("Monto_Total", typeof(decimal));

            // Agregar un producto al detalle de la compra
            DetalleCompra.Rows.Add(2, 50.00m, 60.00m, 10, 500.00m); 
            string mensaje;
            bool resultado = ObjetoCompra.RegistrarCompra(compra, DetalleCompra, out mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual("Compra registrada con éxito", mensaje);
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
