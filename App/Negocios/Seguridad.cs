using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Seguridad
    {
        private const string PrefijoHashClave = "PBKDF2-SHA256";
        private const int IteracionesHashClave = 600000;
        private const int BytesSalt = 16;
        private const int BytesHashClave = 32;

        public static string GenerarSalt()
        {
            byte[] saltBytes = new byte[BytesSalt];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return $"{PrefijoHashClave}${IteracionesHashClave}${Convert.ToBase64String(saltBytes)}";
        }

        public static string HashClave(string clave, string salt)
        {
            ParsearSalt(salt, out byte[] saltBytes, out int iteraciones);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                clave,
                saltBytes,
                iteraciones,
                HashAlgorithmName.SHA256,
                BytesHashClave);
            return Convert.ToBase64String(hash);
        }

        public static bool VerificarClave(string clave, string hashAlmacenado, string salt)
        {
            if (string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(hashAlmacenado) || string.IsNullOrEmpty(salt))
            {
                return false;
            }

            try
            {
                byte[] hashEsperado = new byte[BytesHashClave];
                if (!Convert.TryFromBase64String(hashAlmacenado, hashEsperado, out int bytesEscritos) ||
                    bytesEscritos != BytesHashClave)
                {
                    return false;
                }

                byte[] hashIngresado = Convert.FromBase64String(HashClave(clave, salt));
                return CryptographicOperations.FixedTimeEquals(hashIngresado, hashEsperado);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        private static void ParsearSalt(string saltCodificada, out byte[] saltBytes, out int iteraciones)
        {
            string[] partes = saltCodificada.Split('$');
            if (partes.Length != 3 ||
                !string.Equals(partes[0], PrefijoHashClave, StringComparison.Ordinal) ||
                !int.TryParse(partes[1], out iteraciones) ||
                iteraciones < 100000 ||
                iteraciones > 2000000)
            {
                throw new FormatException("El formato del salt PBKDF2 no es válido.");
            }

            saltBytes = Convert.FromBase64String(partes[2]);
            if (saltBytes.Length < BytesSalt)
            {
                throw new FormatException("El salt PBKDF2 debe tener al menos 16 bytes.");
            }
        }

        public static string GenerarToken()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] token = new byte[16];
                rng.GetBytes(token);
                return Convert.ToHexString(token);
            }
        }

        public static string HashToken(string token)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(token.Trim().ToUpperInvariant()));
            return Convert.ToBase64String(hash);
        }

    }
}
