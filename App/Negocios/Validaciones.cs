using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Validaciones
    {
        /// <summary>
        /// Verifica si la clave del usuario es válida.
        /// </summary>
        /// <param name="clave">ClaveEncriptada del usuario.</param>
        /// <returns>Un booleano que indica si la clave es válida.</returns>
        public static bool EsClaveValida(string clave)
        {
            if (clave.Length < 8)
                return false;

            bool tieneLetra = clave.Any(char.IsLetter);
            bool tieneNumero = clave.Any(char.IsDigit);
            bool tieneCaracterEspecial = clave.Any(c => !char.IsLetterOrDigit(c));

            return tieneLetra && tieneNumero && tieneCaracterEspecial;
        }

        /// <summary>
        /// Verifica si el código del usuario es válido.
        /// </summary>
        /// <param name="codigo">El código del usuario.</param>
        /// <returns>Un booleano que indica si el código es válido.</returns>
        public static bool EsCodigoValido(string codigo)
        {
            return codigo.All(char.IsDigit);
        }

        /// <summary>
        /// Verifica si el texto proporcionado contiene únicamente letras, espacios y caracteres con tilde.
        /// </summary>
        /// <param name="texto">El texto que se desea validar.</param>
        /// <returns>
        /// Un booleano que indica si el texto cumple con el patrón y contiene solo letras, espacios o caracteres válidos.
        /// </returns>

        public static bool EsSoloLetras(string texto)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(texto, patron);
        }

        /// <summary>
        /// Determina si el texto proporcionado está vacío o contiene solo espacios en blanco.
        /// </summary>
        /// <param name="texto">El texto que se desea verificar.</param>
        /// <returns>
        /// Un booleano que indica si el texto es nulo, está vacío o solo contiene espacios en blanco.
        /// </returns>
        public static bool EsTextoVacio(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);
        }

        /// <summary>
        /// Verifica si la cédula del cliente es válida.
        /// </summary>
        /// <param name="cedulaTelefono">La cédula del cliente.</param>
        /// <returns>Un booleano que indica si la cédula es válida.</returns>
        public static bool EsCedulaValida(string cedula)
        {
            // Verificar que tenga exactamente 10 caracteres
            if (cedula.Length != 10)
            {
                return false;
            }

            return cedula.All(char.IsDigit); // Verifica que todos los caracteres sean dígitos
        }

        /// <summary>
        /// Verifica si el telefóno del cliente es válido.
        /// </summary>
        /// <param name="cedulaTelefono">La telefóno del cliente.</param>
        /// <returns>Un booleano que indica si el telefóno es válido.</returns>
        public static bool EsTelefonoValido(string telefono)
        {
            // Verificar que tenga exactamente 10 caracteres
            if (telefono.Length != 10)
            {
                return false;
            }

            // Verificar que empiece con "09"
            if (!telefono.StartsWith("09"))
            {
                return false;
            }

            return telefono.All(char.IsDigit); // Verifica que todos los caracteres sean dígitos
        }

        /// <summary>
        /// Verifica si el correo electrónico del cliente es válido.
        /// </summary>
        /// <param name="correo">Correo electrónico del cliente.</param>
        /// <returns>Un booleano que indica si el coreo electrónico es válido.</returns>
        public static bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón de correo válido
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }

        /// <summary>
        /// Método que verifica si el RUC es válido.
        /// </summary>
        /// <param name="ruc">El RUC del negocio.</param>
        /// <returns>Un booleano que indica si el RUC es válido.</returns>
        public static bool EsRucValido(string ruc)
        {
            // Verificar que tenga exactamente 13 digitos (Ecuador)
            if ((ruc.Length != 11 && ruc.Length != 13) || !ruc.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }
    }
}
