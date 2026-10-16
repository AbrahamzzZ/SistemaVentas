using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_TransportistaTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Transportista.Nombres), "", "Es necesario los nombres" },
            new object[] { nameof(Transportista.Nombres), "Luis 4", "solo pueden contener letras" },
            new object[] { nameof(Transportista.Apellidos), "", "Es necesario los apellidos" },
            new object[] { nameof(Transportista.Cedula), "", "Es necesario la cédula" },
            new object[] { nameof(Transportista.Cedula), "ABC4567890", "exactamente 10 números" },
            new object[] { nameof(Transportista.Telefono), "", "Es necesario el telefóno" },
            new object[] { nameof(Transportista.Telefono), "1991234567", "exactamente 10 números" },
            new object[] { nameof(Transportista.CorreoElectronico), "", "Es necesario el correo electrónico" },
            new object[] { nameof(Transportista.CorreoElectronico), "luis perez@gmail.com", "El correo electrónico no tiene un formato válido." },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Transportista>();
            var transportista = EntidadesDePrueba.Transportista();
            byte[] imagen = EntidadesDePrueba.Imagen();
            string mensajeDatos = "Transportista registrado exitosamente.";
            datos.Setup(d => d.RegistrarTransportista(transportista, imagen, out mensajeDatos)).Returns(4);

            int id = new CN_Transportista(datos.Object).Registrar(transportista, imagen, out string mensaje);

            Assert.AreEqual(4, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Transportista>(MockBehavior.Strict);
            var transportista = EntidadesDePrueba.Transportista().Con(propiedad, valor);

            int id = new CN_Transportista(datos.Object).Registrar(transportista, EntidadesDePrueba.Imagen(), out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(new byte[0])]
        public void Registrar_SinImagen_NoLlegaALaCapaDeDatos(byte[]? imagen)
        {
            var datos = new Mock<ICD_Transportista>(MockBehavior.Strict);

            int id = new CN_Transportista(datos.Object).Registrar(EntidadesDePrueba.Transportista(), imagen, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, "Es obligatorio cargar una imagen del transportista.");
        }

        /// <summary>
        /// Regresión: Editar rechazaba cualquier nombre o apellido no vacío porque validaba
        /// con EsTextoVacio en lugar de EsSoloLetras, y nunca se podía editar un transportista.
        /// </summary>
        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Transportista>();
            var transportista = EntidadesDePrueba.Transportista();
            byte[] imagen = EntidadesDePrueba.Imagen();
            string mensajeDatos = "Transportista actualizado exitosamente.";
            datos.Setup(d => d.EditarTransportista(transportista, imagen, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Transportista(datos.Object).Editar(transportista, imagen, out string mensaje);

            Assert.IsTrue(resultado, mensaje);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Transportista>(MockBehavior.Strict);
            var transportista = EntidadesDePrueba.Transportista().Con(propiedad, valor);

            bool resultado = new CN_Transportista(datos.Object).Editar(transportista, EntidadesDePrueba.Imagen(), out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_SinImagen_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Transportista>(MockBehavior.Strict);

            bool resultado = new CN_Transportista(datos.Object).Editar(EntidadesDePrueba.Transportista(), null, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, "Es obligatorio cargar una imagen del transportista.");
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Transportista>(MockBehavior.Strict);

            bool resultado = new CN_Transportista(datos.Object).Eliminar(new Transportista(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar un Transportista válido para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Transportista>();
            var transportista = EntidadesDePrueba.Transportista();
            string mensajeDatos = "Transportista eliminado exitosamente.";
            datos.Setup(d => d.EliminarTransportista(transportista, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Transportista(datos.Object).Eliminar(transportista, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
