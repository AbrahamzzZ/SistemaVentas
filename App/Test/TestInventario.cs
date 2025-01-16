using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestInventario
    {
        [TestMethod]
        public void RegistrarProductoInventario()
        {
            CD_Inventario ObjetoInventario = new CD_Inventario();
            Inventario inventario = new Inventario
            {
                oProducto = new Producto { IdProducto = 5 },
                oZonaAlmacen = new Zona_Almacen { IdZona = 5},
                Cantidad = 20
            };

            string mensaje;
            int resultado = ObjetoInventario.AgregarProductoInventario(inventario, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Producto registrado en el inventario exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarProductoInventario()
        {
            CD_Inventario ObjetoInventario = new CD_Inventario();
            Inventario inventario = new Inventario
            {
                IdInventario = 25,
                oProducto = new Producto { IdProducto = 5 },
                oZonaAlmacen = new Zona_Almacen { IdZona = 3 },
                Cantidad = 20
            };

            string mensaje;
            bool resultado = ObjetoInventario.EditarProductoInventario(inventario, out mensaje);

            Assert.AreEqual("Producto actualizado exitosamente en el inventario.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarProductoInventario()
        {
            CD_Inventario ObjetoInventario = new CD_Inventario();
            Inventario inventario = new Inventario
            {
                IdInventario = 25
            };

            string mensaje;
            bool resultado = ObjetoInventario.EliminarProductoInventario(inventario, out mensaje);

            Assert.AreEqual("Producto eliminado del inventario exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}