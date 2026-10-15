using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_NegocioTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Negocio.Nombre), "", "Es necesario el nombre del negocio." },
            new object[] { nameof(Negocio.Nombre), "Tienda 24/7", "El nombre del negocio solo puede contener letras y no números." },
            new object[] { nameof(Negocio.Telefono), "", "Es necesario el telefóno del negocio." },
            new object[] { nameof(Negocio.Telefono), "042345678", "El teléfono del negocio solo pueden contener exactamente 10 números" },
            new object[] { nameof(Negocio.Ruc), "", "Es necesario el RUC del negocio." },
            new object[] { nameof(Negocio.Ruc), "09912345670", "El RUC del negocio solo pueden contener exactamente 13 números" },
            new object[] { nameof(Negocio.Ruc), "099123456700", "El RUC del negocio solo pueden contener exactamente 13 números" },
            new object[] { nameof(Negocio.Ruc), "099123456700A", "El RUC del negocio solo pueden contener exactamente 13 números" },
            new object[] { nameof(Negocio.Direccion), "", "Es necesario la dirección del negocio." },
            new object[] { nameof(Negocio.CorreoElectronico), "", "Es necesario el correo electrónico del negocio." },
            new object[] { nameof(Negocio.CorreoElectronico), "contacto.granaki.com", "El correo electrónico no tiene un formato válido." },
        };

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Negocio>();
            var negocio = EntidadesDePrueba.Negocio();
            string mensajeDatos = "Información del negocio actualizada.";
            datos.Setup(d => d.EditarNegocio(negocio, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Negocio(datos.Object).Editar(negocio, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Negocio>(MockBehavior.Strict);
            var negocio = EntidadesDePrueba.Negocio().Con(propiedad, valor);

            bool resultado = new CN_Negocio(datos.Object).Editar(negocio, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void ActualizarLogo_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Negocio>();
            byte[] logo = EntidadesDePrueba.Imagen();
            string mensajeDatos = "Logo actualizado.";
            datos.Setup(d => d.ActualizarLogoNegocio(logo, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Negocio(datos.Object).ActualizarLogo(logo, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
