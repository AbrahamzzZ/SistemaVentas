namespace Test
{
    [TestClass]
    public sealed class ValidacionesTests
    {
        [TestMethod]
        [DataRow("Clave123!", true)]
        [DataRow("Cl4ve.", false)]       // menos de 8 caracteres
        [DataRow("ClaveSegura!", false)] // sin números
        [DataRow("12345678!", false)]    // sin letras
        [DataRow("Clave1234", false)]    // sin caracter especial
        public void EsClaveValida(string clave, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsClaveValida(clave));

        [TestMethod]
        [DataRow("00004", true)]
        [DataRow("00A04", false)]
        [DataRow("12 34", false)]
        public void EsCodigoValido(string codigo, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsCodigoValido(codigo));

        [TestMethod]
        [DataRow("José María", true)]
        [DataRow("Ñandú Pérez", true)]
        [DataRow("Ana2", false)]
        [DataRow("Ana-Lucía", false)]
        public void EsSoloLetras(string texto, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsSoloLetras(texto));

        [TestMethod]
        [DataRow(null, true)]
        [DataRow("", true)]
        [DataRow("   ", true)]
        [DataRow("a", false)]
        public void EsTextoVacio(string? texto, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsTextoVacio(texto));

        [TestMethod]
        [DataRow("0934567891", true)]
        [DataRow("093456789", false)]
        [DataRow("09345678912", false)]
        [DataRow("09345678A1", false)]
        public void EsCedulaValida(string cedula, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsCedulaValida(cedula));

        [TestMethod]
        [DataRow("0987654321", true)]
        [DataRow("0287654321", false)] // debe empezar con 09
        [DataRow("098765432", false)]
        [DataRow("09876543A1", false)]
        public void EsTelefonoValido(string telefono, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsTelefonoValido(telefono));

        [TestMethod]
        [DataRow("ariel03@gmail.com", true)]
        [DataRow("a.b@empresa.com.ec", true)]
        [DataRow("arielgmail.com", false)]
        [DataRow("ariel@gmail", false)]
        [DataRow("ariel @gmail.com", false)]
        public void EsCorreoValido(string correo, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsCorreoValido(correo));

        [TestMethod]
        [DataRow("0991234567001", true)]
        [DataRow("09912345670", false)]   // 11 dígitos: el RUC de Ecuador tiene 13
        [DataRow("099123456700", false)]
        [DataRow("09912345670011", false)]
        [DataRow("099123456700A", false)]
        public void EsRucValido(string ruc, bool esperado) =>
            Assert.AreEqual(esperado, Validaciones.EsRucValido(ruc));
    }
}
