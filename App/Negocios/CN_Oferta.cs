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
    public class CN_Oferta
    {
        private CD_Oferta ObjetoOferta = new CD_Oferta();

        public List<Oferta> ListarOferta()
        {
            return ObjetoOferta.MostrarOfertas();
        }

        public int Registrar(Oferta obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(obj.NombreOferta))
            {
                mensaje += "\n- Es necesario el nombre de la oferta.";
            }
            else if (!EsNombreDescripcionValido(obj.NombreOferta))
            {
                mensaje += "\n- El nombre de la oferta solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la oferta.";
            }

            // Validar Descuento
            if (!obj.Descuento.HasValue)
            {
                mensaje += "\n- Es necesario el descuento de la oferta.";
            }
            else if (obj.Descuento <= 0 || obj.Descuento > 100)
            {
                mensaje += "\n- El descuento debe ser un número válido.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoOferta.RegistrarOferta(obj, out mensaje);
        }

        public bool Editar(Oferta obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(obj.NombreOferta))
            {
                mensaje += "\n- Es necesario el nombre de la oferta.";
            }
            else if (!EsNombreDescripcionValido(obj.NombreOferta))
            {
                mensaje += "\n- El nombre de la oferta solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la oferta.";
            }

            //Validar Descuento
            if (!obj.Descuento.HasValue)
            {
                mensaje += "\n- Es necesario el descuento de la oferta.";
            }
            else if (obj.Descuento <= 0 || obj.Descuento > 100)
            {
                mensaje += "\n- El descuento debe ser un número válido.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoOferta.EditarOferta(obj, out mensaje);
        }

        public bool Eliminar(Oferta obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdOferta == 0)
            {
                mensaje = "Debe seleccionar un Proveedor válido para eliminar.";
                return false;
            }

            return ObjetoOferta.EliminarOferta(obj, out mensaje);
        }

        private bool EsNombreDescripcionValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }
    }
}
