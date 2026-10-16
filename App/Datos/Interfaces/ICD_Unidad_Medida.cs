using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Unidad_Medida"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Unidad_Medida
    {
        /// <summary>
        /// Método que muestra una lista de todas las Unidades de Medida que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Unidad_Medida</returns>
        List<Unidad_Medida> MostrarUnidadesMedidas();

        /// <summary>
        /// Método que permite registrar una nueva Unidad de Medida
        /// </summary>
        /// <param name="obj">Objeto de tipo Unidad_Medida que contiene los datos de la nueva unidad de medida</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID de la unidad de medida generada, o 0 si hubo un error</returns>
        int RegistrarUnidadMedida(Unidad_Medida obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de una Unidad de Medida ya registrada
        /// </summary>
        /// <param name="obj">Objeto de tipo Unidad_Medida que contiene los datos actualizados de la unidad de medida</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarUnidadMedida(Unidad_Medida obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar una Unidad de Medida
        /// </summary>
        /// <param name="obj">Objeto de tipo Unidad_Medida que contiene el ID de la unidad de medida a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarUnidadMedida(Unidad_Medida obj, out string Mensaje);
    }
}
