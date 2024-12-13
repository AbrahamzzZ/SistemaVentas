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
    public class CN_Categoria
    {
        private CD_Categoria ObjetoCategoria = new CD_Categoria();

        public List<Categoria> ListarCategoria()
        {
            return ObjetoCategoria.MostrarCategorias();
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la categoría.";
            }
            else if (!EsDescripcionValido(obj.Descripcion))
            {
                mensaje += "\n- El nombre de la categoría solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoCategoria.RegistrarCategoria(obj, out mensaje);
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la categoría.";
            }
            else if (!EsDescripcionValido(obj.Descripcion))
            {
                mensaje += "\n- El nombre de la categoría solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoCategoria.EditarCategoria(obj, out mensaje);
        }

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

        private bool EsDescripcionValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }
    }
}
