using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocios
{
    public class CN_Inventario
    {

        private readonly CD_Inventario ObjetoProductoInventario = new CD_Inventario();

        /// <summary>
        /// Método que lista todos los productos en el inventario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Inventario.</returns>
        public List<Inventario> ListarProductoInventario()
        {
            return ObjetoProductoInventario.MostrarProductoInventario();
        }

        /// <summary>
        /// Método que registra un nuevo producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Inventario obj, out string mensaje)
        {
            mensaje = string.Empty;

            //Validar cantidad
            if (obj.Cantidad <= 0)
            {
                mensaje = "\n- No se puede registrar un producto al inventario con una cantidad de 0 unidades.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return 0;
            }

            return ObjetoProductoInventario.AgregarProductoInventario(obj, out mensaje);
        }

        /// <summary>
        /// Método que edita la información de un producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Inventario obj, out string mensaje)
        {
            mensaje = string.Empty;

            //Validar cantidad
            if (obj.Cantidad <= 0)
            {
                mensaje = "\n- No se puede editar un producto al inventario con una cantidad de 0 unidades.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return false;
            }

            return ObjetoProductoInventario.EditarProductoInventario(obj, out mensaje);
        }

        /// <summary>
        /// Método que elimina un producto del inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Inventario obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdInventario == 0)
            {
                mensaje = "Debe seleccionar un producto dentro del Inventario para eliminarlo.";
                return false;
            }

            return ObjetoProductoInventario.EliminarProductoInventario(obj, out mensaje);
        }
    }
}
