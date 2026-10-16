using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Categoria"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Categoria
    {
        /// <summary>
        /// Método que muestra una lista de todas las Categorías que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Categoria</returns>
        List<Categoria> MostrarCategorias();

        /// <summary>
        /// Método que permite registrar una nueva Categoría
        /// </summary>
        /// <param name="obj">Objeto de tipo Categoria que contiene los datos de la nueva categoría</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID de la categoría generada, o 0 si hubo un error</returns>
        int RegistrarCategoria(Categoria obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de una Categoría ya registrada
        /// </summary>
        /// <param name="obj">Objeto de tipo Categoria que contiene los datos actualizados de la categoría</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarCategoria(Categoria obj, out string mensaje);

        /// <summary>
        /// Método que permite eliminar una Categoría
        /// </summary>
        /// <param name="obj">Objeto de tipo Categoria que contiene el ID de la categoría a eliminar</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarCategoria(Categoria obj, out string mensaje);
    }
}
