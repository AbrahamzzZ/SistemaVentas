using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_OfertaTests
    {
        public static IEnumerable<object?[]> DatosInvalidos => new[]
        {
            new object?[] { nameof(Oferta.NombreOferta), "", "Es necesario el nombre de la oferta." },
            new object?[] { nameof(Oferta.Descripcion), "", "Es necesario la descripción de la oferta." },
            new object?[] { nameof(Oferta.FechaFin), null, "Es necesario especificar la fecha fin de la oferta." },
            new object?[] { nameof(Oferta.FechaFin), DateTime.Today.AddDays(-1), "La fecha fin de la oferta no puede ser una fecha pasada." },
            new object?[] { nameof(Oferta.Descuento), null, "Es necesario el descuento de la oferta." },
            new object?[] { nameof(Oferta.Descuento), 0m, "El descuento debe ser un número válido." },
            new object?[] { nameof(Oferta.Descuento), 100.5m, "El descuento debe ser un número válido." },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Oferta>();
            var oferta = EntidadesDePrueba.Oferta();
            string mensajeDatos = "Oferta registrada exitosamente.";
            datos.Setup(d => d.RegistrarOferta(oferta, out mensajeDatos)).Returns(8);

            int id = new CN_Oferta(datos.Object).Registrar(oferta, out string mensaje);

            Assert.AreEqual(8, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DataRow("2x1 en Bebidas")]
        [DataRow("Black Friday -50%")]
        [DataRow("Combo #3")]
        public void Registrar_NombreConNumerosYSimbolos_EsValido(string nombreOferta)
        {
            var datos = new Mock<ICD_Oferta>();
            var oferta = EntidadesDePrueba.Oferta();
            oferta.NombreOferta = nombreOferta;
            string mensajeDatos = "Oferta registrada exitosamente.";
            datos.Setup(d => d.RegistrarOferta(oferta, out mensajeDatos)).Returns(8);

            int id = new CN_Oferta(datos.Object).Registrar(oferta, out string mensaje);

            Assert.AreEqual(8, id, mensaje);
        }

        [TestMethod]
        public void Editar_NombreConNumerosYSimbolos_EsValido()
        {
            var datos = new Mock<ICD_Oferta>();
            var oferta = EntidadesDePrueba.Oferta();
            oferta.NombreOferta = "3x2 en Lácteos";
            string mensajeDatos = "Oferta actualizada exitosamente.";
            datos.Setup(d => d.EditarOferta(oferta, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Oferta(datos.Object).Editar(oferta, out string mensaje);

            Assert.IsTrue(resultado, mensaje);
        }

        [TestMethod]
        public void Registrar_FechaFinHoyYDescuentoCien_SonValidos()
        {
            var datos = new Mock<ICD_Oferta>();
            var oferta = EntidadesDePrueba.Oferta();
            oferta.FechaFin = DateTime.Today;
            oferta.Descuento = 100;
            string mensajeDatos = "Oferta registrada exitosamente.";
            datos.Setup(d => d.RegistrarOferta(oferta, out mensajeDatos)).Returns(8);

            int id = new CN_Oferta(datos.Object).Registrar(oferta, out string mensaje);

            Assert.AreEqual(8, id, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, object? valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Oferta>(MockBehavior.Strict);
            var oferta = EntidadesDePrueba.Oferta().Con(propiedad, valor);

            int id = new CN_Oferta(datos.Object).Registrar(oferta, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Oferta>();
            var oferta = EntidadesDePrueba.Oferta();
            string mensajeDatos = "Oferta actualizada exitosamente.";
            datos.Setup(d => d.EditarOferta(oferta, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Oferta(datos.Object).Editar(oferta, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, object? valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Oferta>(MockBehavior.Strict);
            var oferta = EntidadesDePrueba.Oferta().Con(propiedad, valor);

            bool resultado = new CN_Oferta(datos.Object).Editar(oferta, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Oferta>(MockBehavior.Strict);

            bool resultado = new CN_Oferta(datos.Object).Eliminar(new Oferta(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar una Oferta válida para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Oferta>();
            var oferta = EntidadesDePrueba.Oferta();
            string mensajeDatos = "Oferta eliminada exitosamente.";
            datos.Setup(d => d.EliminarOferta(oferta, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Oferta(datos.Object).Eliminar(oferta, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
