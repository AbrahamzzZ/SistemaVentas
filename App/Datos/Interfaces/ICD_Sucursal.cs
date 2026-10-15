using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Sucursal"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Sucursal
    {
        /// <summary>
        /// Método que muestra una lista de todas las Sucursales que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Sucursal</returns>
        List<Sucursal> MostrarSucursales();

        /// <summary>
        /// Método que permite registrar una nueva Sucursal
        /// </summary>
        /// <param name="obj">Objeto de tipo Sucursal que contiene los datos de la nueva sucursal</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID de la sucursal generada, o 0 si hubo un error</returns>
        int RegistrarSucursal(Sucursal obj, out string mensaje);

        /// <summary>
        /// Método que permite editar la información de una Sucursal ya registrada
        /// </summary>
        /// <param name="obj">Objeto de tipo Sucursal que contiene los datos actualizados de la sucursal</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarSucursal(Sucursal obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar a una Sucursal
        /// </summary>
        /// <param name="obj">Objeto de tipo Sucursal que contiene el ID de la sucursal a eliminar</param>
        /// <param name="mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarSucursal(Sucursal obj, out string mensaje);
    }
}
