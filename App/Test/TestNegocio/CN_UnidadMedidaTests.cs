using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_UnidadMedidaTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Unidad_Medida.Descripcion), "", "Es necesario la descripción de la unidad de medida." },
            new object[] { nameof(Unidad_Medida.Descripcion), "Kilo 1000", "La descripción de la unidad de medida solo puede contener letras" },
            new object[] { nameof(Unidad_Medida.Simbolo), "", "Es necesario el simbolo de la unidad de medida." },
            new object[] { nameof(Unidad_Medida.Simbolo), "m2", "El simbolo de la unidad de medida solo puede contener letras" },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Unidad_Medida>();
            var unidad = EntidadesDePrueba.UnidadMedida();
            string mensajeDatos = "Unidad de medida registrada exitosamente.";
            datos.Setup(d => d.RegistrarUnidadMedida(unidad, out mensajeDatos)).Returns(2);

            int id = new CN_Unidad_Medida(datos.Object).Registrar(unidad, out string mensaje);

            Assert.AreEqual(2, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Unidad_Medida>(MockBehavior.Strict);
            var unidad = EntidadesDePrueba.UnidadMedida().Con(propiedad, valor);

            int id = new CN_Unidad_Medida(datos.Object).Registrar(unidad, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Unidad_Medida>();
            var unidad = EntidadesDePrueba.UnidadMedida();
            string mensajeDatos = "Unidad de medida actualizada exitosamente.";
            datos.Setup(d => d.EditarUnidadMedida(unidad, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Unidad_Medida(datos.Object).Editar(unidad, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Unidad_Medida>(MockBehavior.Strict);
            var unidad = EntidadesDePrueba.UnidadMedida().Con(propiedad, valor);

            bool resultado = new CN_Unidad_Medida(datos.Object).Editar(unidad, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Unidad_Medida>(MockBehavior.Strict);

            bool resultado = new CN_Unidad_Medida(datos.Object).Eliminar(new Unidad_Medida(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar una Unidad de Medida válida para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Unidad_Medida>();
            var unidad = EntidadesDePrueba.UnidadMedida();
            string mensajeDatos = "Unidad de medida eliminada exitosamente.";
            datos.Setup(d => d.EliminarUnidadMedida(unidad, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Unidad_Medida(datos.Object).Eliminar(unidad, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
