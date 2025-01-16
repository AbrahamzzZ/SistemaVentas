using Datos;
using Entidad;

namespace Test
{
    [TestClass]
    public sealed class TestProducto
    {
        [TestMethod]
        public void RegistrarProducto()
        {
            CD_Producto ObjetoProducto = new CD_Producto();
            Producto producto = new Producto
            {
                Codigo = "4243",
                Nombre = "Paracetamol",
                Descripcion = "12 unidades",
                oCategoria = new Categoria { IdCategoria = 6 },
                oUnidadMedida = new Unidad_Medida { IdUnidadMedida = 5},
                PaisOrigen = "China",
                Stock = 0,
                PrecioCompra = 0.0m,
                PrecioVenta = 0.0m,
                Estado = true
            };

            string mensaje;
            int resultado = ObjetoProducto.RegistrarProducto(producto, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Producto registrado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void ActualizarProducto()
        {
            CD_Producto ObjetoProducto = new CD_Producto();
            Producto producto = new Producto
            {
                IdProducto = 12,
                Codigo = "4243",
                Nombre = "Paracetamol",
                Descripcion = "24 unidades",
                oCategoria = new Categoria { IdCategoria = 11 },
                oUnidadMedida = new Unidad_Medida { IdUnidadMedida = 4 },
                PaisOrigen = "China",
                Stock = 0,
                PrecioCompra = 0.0m,
                PrecioVenta = 0.0m,
                Estado = true
            };

            string mensaje;
            bool resultado = ObjetoProducto.EditarProducto(producto, out mensaje);

            Assert.AreEqual("Producto actualizado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarProducto()
        {
            CD_Producto ObjetoProducto = new CD_Producto();
            Producto producto = new Producto
            {
                IdProducto = 12
            };

            string mensaje;
            bool resultado = ObjetoProducto.EliminarProducto(producto, out mensaje);

            Assert.AreEqual("Producto eliminado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
