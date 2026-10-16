using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Negocio"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Negocio
    {
        /// <summary>
        /// Método que muestra la información del Negocio
        /// </summary>
        /// <returns>Un objeto de tipo Negocio con la información del negocio</returns>
        Negocio ObtenerInformacionNegocio();

        /// <summary>
        /// Método que permite editar la información del Negocio
        /// </summary>
        /// <param name="obj">Objeto de tipo Negocio que contiene los datos actualizados del negocio</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarNegocio(Negocio obj, out string Mensaje);

        /// <summary>
        /// Método que permite mostrar el logo del Negocio
        /// </summary>
        /// <param name="obtenido">Indica si el logo fue obtenido correctamente</param>
        /// <returns>Un arreglo de bytes que representa el logo del negocio</returns>
        byte[] ObtenerLogoNegocio(out bool obtenido);

        /// <summary>
        /// Método que permite actualizar el logo del Negocio
        /// </summary>
        /// <param name="image">Arreglo de bytes que representa el nuevo logo del negocio</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool ActualizarLogoNegocio(byte[] image, out string mensaje);
    }
}
