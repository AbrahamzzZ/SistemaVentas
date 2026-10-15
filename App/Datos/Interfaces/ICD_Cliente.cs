using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Cliente"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Cliente
    {
        /// <summary>
        /// Método que muestra una lista de todos los Clientes que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Cliente</returns>
        List<Cliente> MostrarClientes();

        /// <summary>
        /// Método que permite registrar un nuevo Cliente
        /// </summary>
        /// <param name="obj">Objeto de tipo Cliente que contiene los datos del nuevo cliente</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del cliente generado, o 0 si hubo un error</returns>
        int RegistrarCliente(Cliente obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de un Cliente ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Cliente que contiene los datos actualizados del cliente</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarCliente(Cliente obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar a un Cliente
        /// </summary>
        /// <param name="obj">Objeto de tipo Cliente que contiene el ID del cliente a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarCliente(Cliente obj, out string Mensaje);
    }
}
