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

        public List<Unidad_Medida> ListarUnidadesMedida()
        {
            return ObjetoUnidadMedida.MostrarUnidadesMedidas();
        }

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

        private bool EsDescripcionSimboloValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }
    }
}
