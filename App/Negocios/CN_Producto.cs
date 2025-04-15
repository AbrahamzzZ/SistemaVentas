using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocios
{
    public class CN_Producto
    {
        private readonly CD_Producto ObjetoProducto = new CD_Producto();

        /// <summary>
        /// Método que lista todos los productos.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Producto.</returns>
        public List<Producto> ListarProducto()
        {
            return ObjetoProducto.MostrarProductos();
        }

        /// <summary>
        /// Método que lista todos los productos que tienen stock disponible, esto es para el inventario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Producto.</returns>
        public List<Producto> ListarProductosConStock()
        {
            return ObjetoProducto.ListarProductosConStock();
        }

        /// <summary>
        /// Método que registra un nuevo producto.
        /// </summary>
        /// <param name="obj">El objeto Producto a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre Completo
            if (Validaciones.EsTextoVacio(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre completo del producto.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Nombre))
            {
                mensaje += "\n- El nombre del producto solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (Validaciones.EsTextoVacio(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción del producto.";
            }

            // Validar Pais de Origen
            if (Validaciones.EsTextoVacio(obj.PaisOrigen))
            {
                mensaje += "\n- Es necesario el pais de origen del producto.";
            }
            else if (!Validaciones.EsSoloLetras(obj.PaisOrigen))
            {
                mensaje += "\n- El pais de origen del producto solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return 0;
            }

            return ObjetoProducto.RegistrarProducto(obj, out mensaje);
        }

        /// <summary>
        /// Método que edita un producto existente.
        /// </summary>
        /// <param name="obj">El objeto Producto a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre Completo
            if (Validaciones.EsTextoVacio(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre completo del producto.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Nombre))
            {
                mensaje += "\n- El nombre del producto solo puede contener letras y no números.";
            }

            // Validar Descripcion  
            if (Validaciones.EsTextoVacio(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción del producto.";
            }

            // Validar Pais de Origen
            if (Validaciones.EsTextoVacio(obj.PaisOrigen))
            {
                mensaje += "\n- Es necesario el pais de origen del producto.";
            }
            else if (!Validaciones.EsSoloLetras(obj.PaisOrigen))
            {
                mensaje += "\n- El pais de origen del producto solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return false;
            }

            return ObjetoProducto.EditarProducto(obj, out mensaje);
        }

        /// <summary>
        /// Método que elimina un producto existente.
        /// </summary>
        /// <param name="obj">El objeto Producto a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Producto obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdProducto == 0)
            {
                mensaje = "Debe seleccionar un Producto válido para eliminar.";
                return false;
            }

            return ObjetoProducto.EliminarProducto(obj, out mensaje);
        }

        /// <summary>
        /// Método que obtiene el stock de un producto específico, esto sirve para el inventario.
        /// </summary>
        /// <param name="IdProducto">El ID del producto.</param>
        /// <returns>Un entero que indica el stock del producto.</returns>
        public int ObtenerStockId(int IdProducto)
        {
            return ObjetoProducto.MostrarProductoStock(IdProducto);
        }
    }
}
