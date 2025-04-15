using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocios
{
    public class CN_Categoria
    {
        private readonly CD_Categoria ObjetoCategoria = new CD_Categoria();

        /// <summary>
        /// Lista todas las categorías.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Categoria.</returns>
        public List<Categoria> ListarCategoria()
        {
            return ObjetoCategoria.MostrarCategorias();
        }

        /// <summary>
        /// Método que valida el registro de una nueva categoría.
        /// </summary>
        /// <param name="obj">El objeto Categoria a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Descripcion
            if (Validaciones.EsTextoVacio(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la categoría.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Descripcion))
            {
                mensaje += "\n- El nombre de la categoría solo puede contener letras y no números.";
            }

            // Retorna 0 si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return 0;
            }

            return ObjetoCategoria.RegistrarCategoria(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de una categoría existente.
        /// </summary>
        /// <param name="obj">El objeto Categoria a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Descripcion
            if (Validaciones.EsTextoVacio(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la categoría.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Descripcion))
            {
                mensaje += "\n- El nombre de la categoría solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return false;
            }

            return ObjetoCategoria.EditarCategoria(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de una categoría existente.
        /// </summary>
        /// <param name="obj">El objeto Categoria a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Categoria obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdCategoria == 0)
            {
                mensaje = "Debe seleccionar una Categoría válida para eliminar.";
                return false;
            }
            return ObjetoCategoria.EliminarCategoria(obj, out mensaje);
        }
    }
}
