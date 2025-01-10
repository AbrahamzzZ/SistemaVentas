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
    public class CN_Unidad_Medida
    {
        private CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();

        /// <summary>
        /// Lista todas las unidades de medida
        /// </summary>
        /// <returns>Una lista de objetos de tipo Unidad_Medida.</returns>
        public List<Unidad_Medida> ListarUnidadesMedida()
        {
            return ObjetoUnidadMedida.MostrarUnidadesMedidas();
        }

        /// <summary>
        /// Método que valida el registro de un nueva unidad de medida.
        /// </summary>
        /// <param name="obj">El objeto Unidad_Medida a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Unidad_Medida obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la unidad de medida.";
            }
            else if (!EsDescripcionSimboloValido(obj.Descripcion))
            {
                mensaje += "\n La descripción de la unidad de medida solo puede contener letras y no números.";
            }

            // Validar Simbolo
            if (string.IsNullOrWhiteSpace(obj.Simbolo))
            {
                mensaje += "\n- Es necesario el simbolo de la unidad de medida.";
            }
            else if (!EsDescripcionSimboloValido(obj.Descripcion))
            {
                mensaje += "\n- El simbolo de la unidad de medida solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoUnidadMedida.RegistrarUnidadMedida(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de una undida de medida existente.
        /// </summary>
        /// <param name="obj">El objeto Unidad_Medida a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Unidad_Medida obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la unidad de medida.";
            }
            else if (!EsDescripcionSimboloValido(obj.Descripcion))
            {
                mensaje += "\n- La descripción de la unidad de medida solo puede contener letras y no números.";
            }

            // Validar Simbolo
            if (string.IsNullOrWhiteSpace(obj.Simbolo))
            {
                mensaje += "\n- Es necesario el simbolo de la unidad de medida.";
            }
            else if (!EsDescripcionSimboloValido(obj.Descripcion))
            {
                mensaje += "\n- El simbolo de la unidad de medida solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoUnidadMedida.EditarUnidadMedida(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de una unidad de medida existente.
        /// </summary>
        /// <param name="obj">El objeto Unidad_Medida a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Unidad_Medida obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdUnidadMedida == 0)
            {
                mensaje = "Debe seleccionar una Unidad de Medida válida para eliminar.";
                return false;
            }

            return ObjetoUnidadMedida.EliminarUnidadMedida(obj, out mensaje);
        }

        /// <summary>
        /// Verifica si la descripción y el simbolo de la undida de media son válidos.
        /// </summary>
        /// <param name="nombre">La descripción y el simbolo de la unidad de medida.</param>
        /// <returns>Un booleano que indica si la descripción y el simbolo son válidos.</returns>
        private bool EsDescripcionSimboloValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }
    }
}
