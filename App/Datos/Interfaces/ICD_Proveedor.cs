using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Proveedor"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Proveedor
    {
        /// <summary>
        /// Método que muestra una lista de todos los Proveedores que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Proveedor</returns>
        List<Proveedor> MostrarProveedores();

        /// <summary>
        /// Método que permite registrar un nuevo Proveedor
        /// </summary>
        /// <param name="obj">Objeto de tipo Proveedor que contiene los datos del nuevo proveedor</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del proveedor generado, o 0 si hubo un error</returns>
        int RegistrarProveedor(Proveedor obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de un Proveedor ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Proveedor que contiene los datos actualizados del proveedor</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarProveedor(Proveedor obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar a un Proveedor
        /// </summary>
        /// <param name="obj">Objeto de tipo Proveedor que contiene el ID del proveedor a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarProveedor(Proveedor obj, out string Mensaje);
    }
}
