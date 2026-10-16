using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Producto"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Producto
    {
        /// <summary>
        /// Metodo que muestra una lista de todos los Productos que existen
        /// </summary>
        /// <returns></returns>
        List<Producto> MostrarProductos();

        /// <summary>
        /// Método que permite registrar un nuevo Producto
        /// </summary>
        /// <param name="obj">Objeto de tipo Producto que contiene los datos del nuevo producto</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del producto generado, o 0 si hubo un error</returns>
        int RegistrarProducto(Producto obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de un Producto ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Producto que contiene los datos actualizados del producto</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarProducto(Producto obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar a un Producto
        /// </summary>
        /// <param name="obj">Objeto de tipo Producto que contiene el ID del producto a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarProducto(Producto obj, out string Mensaje);

        /// <summary>
        /// Método que muestra el stock de un producto específico, esto sirve para el inventario.
        /// </summary>
        /// <param name="IdProducto">El ID del producto.</param>
        /// <returns>Un entero que indica el stock del producto.</returns>
        int MostrarProductoStock(int IdProducto);

        /// <summary>
        /// Método que lista todos los productos que tienen stock disponible, esto es para el inventario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Producto.</returns>
        List<Producto> ListarProductosConStock();
    }
}
