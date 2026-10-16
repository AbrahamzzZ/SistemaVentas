namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_InventarioTests
    {
        [TestMethod]
        public void Registrar_CantidadPositiva_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Inventario>();
            var inventario = EntidadesDePrueba.Inventario();
            string mensajeDatos = "Producto agregado al inventario exitosamente.";
            datos.Setup(d => d.AgregarProductoInventario(inventario, out mensajeDatos)).Returns(12);

            int id = new CN_Inventario(datos.Object).Registrar(inventario, out string mensaje);

            Assert.AreEqual(12, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        public void Registrar_CantidadCeroONegativa_NoLlegaALaCapaDeDatos(int cantidad)
        {
            var datos = new Mock<ICD_Inventario>(MockBehavior.Strict);
            var inventario = EntidadesDePrueba.Inventario();
            inventario.Cantidad = cantidad;

            int id = new CN_Inventario(datos.Object).Registrar(inventario, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, "No se puede registrar un producto al inventario con una cantidad de 0 unidades.");
        }

        [TestMethod]
        public void Editar_CantidadPositiva_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Inventario>();
            var inventario = EntidadesDePrueba.Inventario();
            string mensajeDatos = "Producto actualizado exitosamente en el inventario.";
            datos.Setup(d => d.EditarProductoInventario(inventario, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Inventario(datos.Object).Editar(inventario, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Editar_CantidadCeroONegativa_NoLlegaALaCapaDeDatos(int cantidad)
        {
            var datos = new Mock<ICD_Inventario>(MockBehavior.Strict);
            var inventario = EntidadesDePrueba.Inventario();
            inventario.Cantidad = cantidad;

            bool resultado = new CN_Inventario(datos.Object).Editar(inventario, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, "No se puede editar un producto al inventario con una cantidad de 0 unidades.");
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Inventario>(MockBehavior.Strict);

            bool resultado = new CN_Inventario(datos.Object).Eliminar(new Inventario(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar un producto dentro del Inventario para eliminarlo.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Inventario>();
            var inventario = EntidadesDePrueba.Inventario();
            string mensajeDatos = "Producto eliminado del inventario exitosamente.";
            datos.Setup(d => d.EliminarProductoInventario(inventario, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Inventario(datos.Object).Eliminar(inventario, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
