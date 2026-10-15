using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_ProveedorTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Proveedor.Nombres), "", "Es necesario los nombres del proveedor." },
            new object[] { nameof(Proveedor.Nombres), "Carlos 3", "Los nombres del proveedor solo pueden contener letras" },
            new object[] { nameof(Proveedor.Apellidos), "", "Es necesario los apellidos del proveedor." },
            new object[] { nameof(Proveedor.Apellidos), "López#", "Los apellidos del proveedor solo pueden contener letras" },
            new object[] { nameof(Proveedor.Cedula), "", "Es necesario la cédula del proveedor." },
            new object[] { nameof(Proveedor.Cedula), "096543210", "La cédula del proveedor solo pueden contener exactamente 10 números" },
            new object[] { nameof(Proveedor.Telefono), "", "Es necesario el telefóno del proveedor." },
            new object[] { nameof(Proveedor.Telefono), "09876543", "El telefóno del proveedor solo pueden contener exactamente 10 números" },
            new object[] { nameof(Proveedor.CorreoElectronico), "", "Es necesario el correo electrónico del proveedor." },
            new object[] { nameof(Proveedor.CorreoElectronico), "carlitos@", "El correo electrónico no tiene un formato válido." },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Proveedor>();
            var proveedor = EntidadesDePrueba.Proveedor();
            string mensajeDatos = "Proveedor registrado exitosamente.";
            datos.Setup(d => d.RegistrarProveedor(proveedor, out mensajeDatos)).Returns(3);

            int id = new CN_Proveedor(datos.Object).Registrar(proveedor, out string mensaje);

            Assert.AreEqual(3, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Proveedor>(MockBehavior.Strict);
            var proveedor = EntidadesDePrueba.Proveedor().Con(propiedad, valor);

            int id = new CN_Proveedor(datos.Object).Registrar(proveedor, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Proveedor>();
            var proveedor = EntidadesDePrueba.Proveedor();
            string mensajeDatos = "Proveedor actualizado exitosamente.";
            datos.Setup(d => d.EditarProveedor(proveedor, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Proveedor(datos.Object).Editar(proveedor, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Proveedor>(MockBehavior.Strict);
            var proveedor = EntidadesDePrueba.Proveedor().Con(propiedad, valor);

            bool resultado = new CN_Proveedor(datos.Object).Editar(proveedor, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Proveedor>(MockBehavior.Strict);

            bool resultado = new CN_Proveedor(datos.Object).Eliminar(new Proveedor(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar un Proveedor válido para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Proveedor>();
            var proveedor = EntidadesDePrueba.Proveedor();
            string mensajeDatos = "Proveedor eliminado exitosamente.";
            datos.Setup(d => d.EliminarProveedor(proveedor, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Proveedor(datos.Object).Eliminar(proveedor, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
