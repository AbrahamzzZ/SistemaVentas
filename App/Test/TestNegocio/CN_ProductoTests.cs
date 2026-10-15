using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_ProductoTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Producto.Nombre), "", "Es necesario el nombre completo del producto." },
            new object[] { nameof(Producto.Nombre), "Coca Cola 3L", "El nombre del producto solo puede contener letras y no números." },
            new object[] { nameof(Producto.Descripcion), " ", "Es necesario la descripción del producto." },
            new object[] { nameof(Producto.PaisOrigen), "", "Es necesario el pais de origen del producto." },
            new object[] { nameof(Producto.PaisOrigen), "EE.UU.", "El pais de origen del producto solo puede contener letras y no números." },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Producto>();
            var producto = EntidadesDePrueba.Producto();
            string mensajeDatos = "Producto registrado exitosamente.";
            datos.Setup(d => d.RegistrarProducto(producto, out mensajeDatos)).Returns(11);

            int id = new CN_Producto(datos.Object).Registrar(producto, out string mensaje);

            Assert.AreEqual(11, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Producto>(MockBehavior.Strict);
            var producto = EntidadesDePrueba.Producto().Con(propiedad, valor);

            int id = new CN_Producto(datos.Object).Registrar(producto, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Producto>();
            var producto = EntidadesDePrueba.Producto();
            string mensajeDatos = "Producto actualizado exitosamente.";
            datos.Setup(d => d.EditarProducto(producto, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Producto(datos.Object).Editar(producto, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Producto>(MockBehavior.Strict);
            var producto = EntidadesDePrueba.Producto().Con(propiedad, valor);

            bool resultado = new CN_Producto(datos.Object).Editar(producto, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Producto>(MockBehavior.Strict);

            bool resultado = new CN_Producto(datos.Object).Eliminar(new Producto(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar un Producto válido para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Producto>();
            var producto = EntidadesDePrueba.Producto();
            string mensajeDatos = "Producto eliminado exitosamente.";
            datos.Setup(d => d.EliminarProducto(producto, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Producto(datos.Object).Eliminar(producto, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        public void ObtenerStockId_DevuelveElStockDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Producto>();
            datos.Setup(d => d.MostrarProductoStock(5)).Returns(42);

            Assert.AreEqual(42, new CN_Producto(datos.Object).ObtenerStockId(5));
        }
    }
}
