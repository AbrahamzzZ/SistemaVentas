using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Oferta"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Oferta
    {
        /// <summary>
        /// Método que muestra una lista de todas las Ofertas que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Oferta</returns>
        List<Oferta> MostrarOfertas();

        /// <summary>
        /// Método que permite registrar una nueva Oferta
        /// </summary>
        /// <param name="obj">Objeto de tipo Oferta que contiene los datos de la nueva oferta</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID de la oferta generada, o 0 si hubo un error</returns>
        int RegistrarOferta(Oferta obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de una Oferta ya registrada
        /// </summary>
        /// <param name="obj">Objeto de tipo Oferta que contiene los datos actualizados de la oferta</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarOferta(Oferta obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar una Oferta
        /// </summary>
        /// <param name="obj">Objeto de tipo Oferta que contiene el ID de la oferta a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarOferta(Oferta obj, out string Mensaje);
    }
}
