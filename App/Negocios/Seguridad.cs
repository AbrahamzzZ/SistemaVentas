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
        public static string GenerarSalt()
        {
            byte[] saltBytes = new byte[16];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashClave(string clave, string salt)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(clave + salt);
                byte[] hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public static string GenerarToken()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] token = new byte[10];
                rng.GetBytes(token);
                return BitConverter.ToString(token).Replace("-", "").Substring(0, 10);
            }
        }


    }
}
