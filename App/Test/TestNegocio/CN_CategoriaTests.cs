namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_CategoriaTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { "", "Es necesario la descripción de la categoría." },
            new object[] { "Bebidas 2x1", "El nombre de la categoría solo puede contener letras y no números." },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Categoria>();
            var categoria = EntidadesDePrueba.Categoria();
            string mensajeDatos = "Categoría registrada exitosamente.";
            datos.Setup(d => d.RegistrarCategoria(categoria, out mensajeDatos)).Returns(9);

            int id = new CN_Categoria(datos.Object).Registrar(categoria, out string mensaje);

            Assert.AreEqual(9, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DescripcionInvalida_NoLlegaALaCapaDeDatos(string descripcion, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Categoria>(MockBehavior.Strict);
            var categoria = EntidadesDePrueba.Categoria();
            categoria.Descripcion = descripcion;

            int id = new CN_Categoria(datos.Object).Registrar(categoria, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Categoria>();
            var categoria = EntidadesDePrueba.Categoria();
            string mensajeDatos = "Categoría actualizada exitosamente.";
            datos.Setup(d => d.EditarCategoria(categoria, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Categoria(datos.Object).Editar(categoria, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DescripcionInvalida_NoLlegaALaCapaDeDatos(string descripcion, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Categoria>(MockBehavior.Strict);
            var categoria = EntidadesDePrueba.Categoria();
            categoria.Descripcion = descripcion;

            bool resultado = new CN_Categoria(datos.Object).Editar(categoria, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Categoria>(MockBehavior.Strict);

            bool resultado = new CN_Categoria(datos.Object).Eliminar(new Categoria(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar una Categoría válida para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Categoria>();
            var categoria = EntidadesDePrueba.Categoria();
            string mensajeDatos = "Categoría eliminada exitosamente.";
            datos.Setup(d => d.EliminarCategoria(categoria, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Categoria(datos.Object).Eliminar(categoria, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
