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
        public void HashClave_DemoDeSql_CoincideConElHashPbkdf2Almacenado()
        {
            const string salt = "PBKDF2-SHA256$600000$aj238cKJRq+RLtUIc7wU4A==";
            const string hashEsperado = "+VWTNZCYEhesYhhqv5LLLavNfPvlENRT8/f2P7NIvcM=";

            Assert.AreEqual(hashEsperado, Seguridad.HashClave("jawi2010.", salt));
            Assert.IsTrue(Seguridad.VerificarClave("jawi2010.", hashEsperado, salt));
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
            string salt = Seguridad.GenerarSalt();
            string hash = Seguridad.HashClave("Clave123!", salt);

            Assert.IsFalse(hash.Contains("Clave123!"));
            Assert.AreEqual(44, hash.Length); // SHA-256 (32 bytes) en Base64
            StringAssert.StartsWith(salt, "PBKDF2-SHA256$600000$");
        }

        [TestMethod]
        public void VerificarClave_AceptaLaClaveCorrectaYRechazaLaIncorrecta()
        {
            string salt = Seguridad.GenerarSalt();
            string hash = Seguridad.HashClave("Clave123!", salt);

            Assert.IsTrue(Seguridad.VerificarClave("Clave123!", hash, salt));
            Assert.IsFalse(Seguridad.VerificarClave("OtraClave123!", hash, salt));
        }

        [TestMethod]
        [DataRow("hash SQL incompatible")]
        [DataRow("")]
        public void VerificarClave_HashAlmacenadoInvalido_RechazaSinLanzarExcepcion(string hashInvalido)
        {
            Assert.IsFalse(Seguridad.VerificarClave("Clave123!", hashInvalido, Seguridad.GenerarSalt()));
        }

        [TestMethod]
        public void VerificarClave_SaltDeAlgoritmoAntiguo_RechazaSinLanzarExcepcion()
        {
            Assert.IsFalse(Seguridad.VerificarClave("Clave123!", "hash-antiguo", "salt-antiguo"));
        }

        [TestMethod]
        public void GenerarSalt_Produce16BytesAleatorios()
        {
            string salt = Seguridad.GenerarSalt();

            string[] partes = salt.Split('$');
            Assert.AreEqual(3, partes.Length);
            Assert.AreEqual(16, Convert.FromBase64String(partes[2]).Length);
            Assert.AreNotEqual(salt, Seguridad.GenerarSalt());
        }

        [TestMethod]
        public void GenerarToken_Produce32CaracteresHexadecimales()
        {
            string token = Seguridad.GenerarToken();

            Assert.AreEqual(32, token.Length);
            StringAssert.Matches(token, new System.Text.RegularExpressions.Regex("^[0-9A-F]{32}$"));
        }

        [TestMethod]
        public void HashToken_MismoToken_ProduceElMismoHashSinIncluirElToken()
        {
            string token = Seguridad.GenerarToken();
            string hash = Seguridad.HashToken(token);

            Assert.AreEqual(hash, Seguridad.HashToken(token));
            Assert.AreEqual(44, hash.Length);
            Assert.IsFalse(hash.Contains(token));
        }
    }
}
