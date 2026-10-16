using System;
using System.Globalization;

namespace Presentacion
{
    /// <summary>
    /// Lectura y formato de coordenadas geográficas (latitud y longitud).
    /// </summary>
    /// <remarks>
    /// Las coordenadas siempre se muestran con punto decimal, sin importar la configuración regional
    /// de Windows, y se aceptan escritas tanto con punto como con coma.
    /// </remarks>
    internal static class Coordenada
    {
        /// <summary>
        /// Convierte una coordenada a texto con punto decimal y hasta 6 decimales (precisión de ~10 cm).
        /// </summary>
        public static string Formatear(double valor)
        {
            return Math.Round(valor, 6).ToString("0.######", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Lee una coordenada escrita con punto o coma decimal.
        /// </summary>
        public static bool TryLeer(string texto, out double valor)
        {
            string normalizado = (texto ?? string.Empty).Trim().Replace(',', '.');
            return double.TryParse(normalizado, NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
        }

        /// <summary>
        /// Lee el valor de una celda de tabla, que puede ser un número o un texto.
        /// </summary>
        public static double? Leer(object valor)
        {
            switch (valor)
            {
                case double d:
                    return d;
                case decimal m:
                    return (double)m;
                case float f:
                    return f;
                case string s when TryLeer(s, out double leido):
                    return leido;
                default:
                    return null;
            }
        }
    }
}
