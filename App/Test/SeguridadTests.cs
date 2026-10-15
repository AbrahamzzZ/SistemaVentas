namespace Test
{
    [TestClass]
    public sealed class SeguridadTests
    {
        [TestMethod]
        public void HashClave_MismaClaveYSalt_ProduceElMismoHash()
        {
            string salt = Seguridad.GenerarSalt();

            Assert.AreEqual(Seguridad.HashClave("Clave123!", salt), Seguridad.HashClave("Clave123!", salt));
        }

        [TestMethod]
        public void HashClave_SaltDistinto_ProduceHashDistinto()
        {
            Assert.AreNotEqual(
                Seguridad.HashClave("Clave123!", Seguridad.GenerarSalt()),
                Seguridad.HashClave("Clave123!", Seguridad.GenerarSalt()));
        }

        [TestMethod]
        public void HashClave_NoContieneLaClaveEnTextoPlano()
        {
            string hash = Seguridad.HashClave("Clave123!", Seguridad.GenerarSalt());

            Assert.IsFalse(hash.Contains("Clave123!"));
            Assert.AreEqual(44, hash.Length); // SHA-256 (32 bytes) en Base64
        }

        [TestMethod]
        public void GenerarSalt_Produce16BytesAleatorios()
        {
            string salt = Seguridad.GenerarSalt();

            Assert.AreEqual(16, Convert.FromBase64String(salt).Length);
            Assert.AreNotEqual(salt, Seguridad.GenerarSalt());
        }

        [TestMethod]
        public void GenerarToken_Produce10CaracteresHexadecimales()
        {
            string token = Seguridad.GenerarToken();

            Assert.AreEqual(10, token.Length);
            StringAssert.Matches(token, new System.Text.RegularExpressions.Regex("^[0-9A-F]{10}$"));
        }
    }
}
