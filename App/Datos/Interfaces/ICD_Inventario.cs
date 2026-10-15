using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Inventario"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Inventario
    {
        /// <summary>
        /// Método que muestra una lista de todos los productos que estan en el inventario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Inventario.</returns>
        List<Inventario> MostrarProductoInventario();

        /// <summary>
        /// Método que permite registrar un producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el ID del inventario generado.</returns>
        int AgregarProductoInventario(Inventario obj, out string mensaje);

        /// <summary>
        /// Método que permite editar la información del producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        bool EditarProductoInventario(Inventario obj, out string mensaje);

        /// <summary>
        /// Método que permite eliminar un producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        bool EliminarProductoInventario(Inventario obj, out string mensaje);
    }
}
