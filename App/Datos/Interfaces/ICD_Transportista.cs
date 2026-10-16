using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Transportista"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Transportista
    {
        /// <summary>
        /// Método que muestra una lista de todos los Transportistas que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Transportista</returns>
        List<Transportista> MostrarTransportistas();

        /// <summary>
        /// Método que permite registrar un nuevo Transportista
        /// </summary>
        /// <param name="obj">Objeto de tipo Transportista que contiene los datos del nuevo transportista</param>
        /// <param name="imagen">Arreglo de bytes que representa la imagen del transportista</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del transportista generado, o 0 si hubo un error</returns>
        int RegistrarTransportista(Transportista obj, byte[] imagen, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de un Transportista ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Transportista que contiene los datos actualizados del transportista</param>
        /// <param name="imagen">Arreglo de bytes que representa la imagen del transportista</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarTransportista(Transportista obj, byte[] imagen, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar a un Transportista
        /// </summary>
        /// <param name="obj">Objeto de tipo Transportista que contiene el ID del transportista a eliminar</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarTransportista(Transportista obj, out string mensaje);
    }
}
