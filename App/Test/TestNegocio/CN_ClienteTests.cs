using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_ClienteTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Cliente.Nombres), "", "Es necesario los nombres del cliente." },
            new object[] { nameof(Cliente.Nombres), "Ariel 2", "Los nombres del cliente solo pueden contener letras" },
            new object[] { nameof(Cliente.Apellidos), "   ", "Es necesario los apellidos del cliente." },
            new object[] { nameof(Cliente.Apellidos), "Macias_V", "Los apellidos del cliente solo pueden contener letras" },
            new object[] { nameof(Cliente.Cedula), "", "Es necesario la cédula del cliente." },
            new object[] { nameof(Cliente.Cedula), "09345678", "La cédula del cliente solo pueden contener exactamente 10 números" },
            new object[] { nameof(Cliente.Cedula), "09345678AB", "La cédula del cliente solo pueden contener exactamente 10 números" },
            new object[] { nameof(Cliente.Telefono), "", "Es necesario el telefóno del cliente." },
            new object[] { nameof(Cliente.Telefono), "0287654321", "El telefóno del cliente solo pueden contener exactamente 10 números" },
            new object[] { nameof(Cliente.CorreoElectronico), "", "Es necesario el correo electrónico" },
            new object[] { nameof(Cliente.CorreoElectronico), "ariel03gmail.com", "El correo electrónico no tiene un formato válido." },
        };

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Cliente>();
            var cliente = EntidadesDePrueba.Cliente();
            string mensajeDatos = "Cliente registrado exitosamente.";
            datos.Setup(d => d.RegistrarCliente(cliente, out mensajeDatos)).Returns(7);

            int id = new CN_Cliente(datos.Object).Registrar(cliente, out string mensaje);

            Assert.AreEqual(7, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            // Mock estricto: cualquier llamada a la capa de datos hace fallar la prueba
            var datos = new Mock<ICD_Cliente>(MockBehavior.Strict);
            var cliente = EntidadesDePrueba.Cliente().Con(propiedad, valor);

            int id = new CN_Cliente(datos.Object).Registrar(cliente, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Registrar_VariosDatosVacios_AcumulaTodosLosErrores()
        {
            var datos = new Mock<ICD_Cliente>(MockBehavior.Strict);

            new CN_Cliente(datos.Object).Registrar(new Cliente(), out string mensaje);

            StringAssert.Contains(mensaje, "Es necesario los nombres del cliente.");
            StringAssert.Contains(mensaje, "Es necesario los apellidos del cliente.");
            StringAssert.Contains(mensaje, "Es necesario la cédula del cliente.");
            StringAssert.Contains(mensaje, "Es necesario el telefóno del cliente.");
            StringAssert.Contains(mensaje, "Es necesario el correo electrónico");
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Cliente>();
            var cliente = EntidadesDePrueba.Cliente();
            string mensajeDatos = "Cliente actualizado exitosamente.";
            datos.Setup(d => d.EditarCliente(cliente, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Cliente(datos.Object).Editar(cliente, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Cliente>(MockBehavior.Strict);
            var cliente = EntidadesDePrueba.Cliente().Con(propiedad, valor);

            bool resultado = new CN_Cliente(datos.Object).Editar(cliente, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Cliente>(MockBehavior.Strict);

            bool resultado = new CN_Cliente(datos.Object).Eliminar(new Cliente { IdCliente = 0 }, out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar un Cliente válido para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Cliente>();
            var cliente = EntidadesDePrueba.Cliente();
            string mensajeDatos = "Cliente eliminado exitosamente.";
            datos.Setup(d => d.EliminarCliente(cliente, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Cliente(datos.Object).Eliminar(cliente, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        public void ListarCliente_DevuelveLaListaDeLaCapaDeDatos()
        {
            var lista = new List<Cliente> { EntidadesDePrueba.Cliente() };
            var datos = new Mock<ICD_Cliente>();
            datos.Setup(d => d.MostrarClientes()).Returns(lista);

            Assert.AreSame(lista, new CN_Cliente(datos.Object).ListarCliente());
        }
    }
}
