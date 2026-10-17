using Test;

namespace Test.CapaNegocio
{
    /// <remarks>
    /// CN_Usuario guarda los intentos fallidos de login en un campo estático, por eso las pruebas
    /// de login reinician el contador con un login exitoso antes de empezar.
    /// </remarks>
    [TestClass]
    public sealed class CN_UsuarioTests
    {
        public static IEnumerable<object[]> DatosInvalidos => new[]
        {
            new object[] { nameof(Usuario.NombreCompleto), "", "Es necesario el nombreCompleto completo del usuario." },
            new object[] { nameof(Usuario.NombreCompleto), "Jose123", "El nombreCompleto del usuario solo puede contener letras y no números." },
            new object[] { nameof(Usuario.CorreoElectronico), "", "Es necesario el correo electrónico del usuario." },
            new object[] { nameof(Usuario.CorreoElectronico), "jose@gmail", "El correo electrónico no tiene un formato válido." },
        };

        private static Mock<ICD_Usuario> MockLogin(Usuario? usuario)
        {
            var datos = new Mock<ICD_Usuario>();
            datos.Setup(d => d.IngresarUsuarioLogin(It.IsAny<string>())).Returns(usuario!);
            return datos;
        }

        private static void ReiniciarIntentos() =>
            new CN_Usuario(MockLogin(EntidadesDePrueba.Usuario()).Object).ValidarLogin("00004", "clave123");

        [TestMethod]
        [DataRow("", "clave123")]
        [DataRow("00004", "")]
        [DataRow("  ", "  ")]
        public void ValidarLogin_CamposVacios_NoConsultaLaCapaDeDatos(string codigo, string clave)
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);

            string resultado = new CN_Usuario(datos.Object).ValidarLogin(codigo, clave);

            Assert.AreEqual("Por favor, llene todos los campos para iniciar sesión.", resultado);
        }

        [TestMethod]
        public void ValidarLogin_CodigoConLetras_NoConsultaLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);

            string resultado = new CN_Usuario(datos.Object).ValidarLogin("00A4", "clave123");

            Assert.AreEqual("Debe ingresar números y no letras en el campo código.", resultado);
        }

        [TestMethod]
        public void ValidarLogin_UsuarioActivo_DevuelveCadenaVacia()
        {
            var datos = MockLogin(EntidadesDePrueba.Usuario());

            string resultado = new CN_Usuario(datos.Object).ValidarLogin("00004", "clave123");

            Assert.AreEqual(string.Empty, resultado);
            datos.Verify(d => d.IngresarUsuarioLogin("00004"), Times.Once);
        }

        [TestMethod]
        public void ValidarLogin_UsuarioInactivo_IndicaQueNoEstaHabilitado()
        {
            var usuario = EntidadesDePrueba.Usuario();
            usuario.Estado = false;

            string resultado = new CN_Usuario(MockLogin(usuario).Object).ValidarLogin("00004", "clave123");

            Assert.AreEqual("El usuario no está habilitado. Por favor, contacte al administrador.", resultado);
        }

        [TestMethod]
        public void ValidarLogin_UsuarioInexistente_IndicaCredencialesIncorrectas()
        {
            ReiniciarIntentos();

            string resultado = new CN_Usuario(MockLogin(null).Object).ValidarLogin("99999", "clave123");

            Assert.AreEqual("Las credenciales ingresadas son incorrectas.", resultado);
        }

        [TestMethod]
        public void ValidarLogin_ClaveIncorrecta_IndicaCredencialesIncorrectas()
        {
            ReiniciarIntentos();

            string resultado = new CN_Usuario(MockLogin(EntidadesDePrueba.Usuario()).Object)
                .ValidarLogin("00004", "clave-incorrecta");

            Assert.AreEqual("Las credenciales ingresadas son incorrectas.", resultado);
        }

        [TestMethod]
        public void ValidarLogin_CuartoIntentoFallido_BloqueaElAcceso()
        {
            ReiniciarIntentos();
            var negocio = new CN_Usuario(MockLogin(null).Object);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual("Las credenciales ingresadas son incorrectas.", negocio.ValidarLogin("99999", "clave123"));
            }

            Assert.AreEqual("Se ha alcanzado el límite de intentos fallidos. Inténtelo más tarde.", negocio.ValidarLogin("99999", "clave123"));
        }

        [TestMethod]
        public void Registrar_DatosValidos_DevuelveElIdDeLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Usuario>();
            var usuario = EntidadesDePrueba.Usuario();
            string mensajeDatos = "Usuario registrado exitosamente.";
            datos.Setup(d => d.RegistrarUsuario(usuario, out mensajeDatos)).Returns(6);

            int id = new CN_Usuario(datos.Object).Registrar(usuario, out string mensaje);

            Assert.AreEqual(6, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);
            var usuario = EntidadesDePrueba.Usuario().Con(propiedad, valor);

            int id = new CN_Usuario(datos.Object).Registrar(usuario, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Usuario>();
            var usuario = EntidadesDePrueba.Usuario();
            string mensajeDatos = "Usuario actualizado exitosamente.";
            datos.Setup(d => d.EditarUsuario(usuario, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Usuario(datos.Object).Editar(usuario, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, string valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);
            var usuario = EntidadesDePrueba.Usuario().Con(propiedad, valor);

            bool resultado = new CN_Usuario(datos.Object).Editar(usuario, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        [DataRow(0, "Debe seleccionar un Usuario válido para eliminar.")]
        [DataRow(1, "No se puede eliminar el primer Usuario porque es necesario para el acceso al sistema.")]
        public void Eliminar_UsuarioNoPermitido_NoLlegaALaCapaDeDatos(int idUsuario, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);

            bool resultado = new CN_Usuario(datos.Object).Eliminar(new Usuario { IdUsuario = idUsuario }, out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual(mensajeEsperado, mensaje);
        }

        [TestMethod]
        public void Eliminar_OtroUsuario_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Usuario>();
            var usuario = EntidadesDePrueba.Usuario();
            string mensajeDatos = "Usuario eliminado exitosamente.";
            datos.Setup(d => d.EliminarUsuario(usuario, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Usuario(datos.Object).Eliminar(usuario, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        public void GenerarTokenRecuperacion_CorreoValido_GuardaSoloElHashConVencimiento()
        {
            var datos = new Mock<ICD_Usuario>();
            datos.Setup(d => d.GuardarTokenRecuperacion(
                "usuario@ejemplo.com",
                It.IsAny<string>(),
                It.IsAny<DateTime>())).Returns(true);

            DateTime antes = DateTime.UtcNow;
            bool resultado = new CN_Usuario(datos.Object)
                .GenerarTokenRecuperacion("usuario@ejemplo.com", out string token);
            DateTime despues = DateTime.UtcNow;

            Assert.IsTrue(resultado);
            Assert.AreEqual(32, token.Length);
            datos.Verify(d => d.GuardarTokenRecuperacion(
                "usuario@ejemplo.com",
                Seguridad.HashToken(token),
                It.Is<DateTime>(expiracion => expiracion >= antes.AddMinutes(14) && expiracion <= despues.AddMinutes(16))),
                Times.Once);
        }

        [TestMethod]
        public void GenerarTokenRecuperacion_CorreoInvalido_NoConsultaLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);

            bool resultado = new CN_Usuario(datos.Object)
                .GenerarTokenRecuperacion("correo-invalido", out string token);

            Assert.IsFalse(resultado);
            Assert.AreEqual(string.Empty, token);
        }

        [TestMethod]
        public void ValidarTokenRecuperacion_HasheaElCodigoAntesDeConsultarDatos()
        {
            var datos = new Mock<ICD_Usuario>();
            const string codigo = "0123456789ABCDEF0123456789ABCDEF";
            datos.Setup(d => d.ValidarTokenRecuperacion("usuario@ejemplo.com", Seguridad.HashToken(codigo)))
                .Returns(true);

            bool resultado = new CN_Usuario(datos.Object)
                .ValidarTokenRecuperacion("usuario@ejemplo.com", codigo);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CambiarClaveRecuperacion_ClaveDebil_NoConsultaLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Usuario>(MockBehavior.Strict);

            bool resultado = new CN_Usuario(datos.Object)
                .CambiarClaveRecuperacion("usuario@ejemplo.com", "codigo", "debil");

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void CambiarClaveRecuperacion_ClaveValida_GuardaHashYSaltYTokenHasheado()
        {
            var datos = new Mock<ICD_Usuario>();
            const string codigo = "0123456789ABCDEF0123456789ABCDEF";
            string? saltGuardado = null;
            string? hashGuardado = null;
            datos.Setup(d => d.RestablecerClaveRecuperacion(
                    "usuario@ejemplo.com",
                    Seguridad.HashToken(codigo),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback<string, string, string, string>((_, _, hash, salt) =>
                {
                    hashGuardado = hash;
                    saltGuardado = salt;
                })
                .Returns(true);

            bool resultado = new CN_Usuario(datos.Object)
                .CambiarClaveRecuperacion("usuario@ejemplo.com", codigo, "ClaveNueva123!");

            Assert.IsTrue(resultado);
            Assert.IsNotNull(saltGuardado);
            Assert.AreNotEqual("ClaveNueva123!", hashGuardado);
            Assert.AreEqual(Seguridad.HashClave("ClaveNueva123!", saltGuardado), hashGuardado);
        }
    }
}
