using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocios
{
    public class CN_Oferta
    {
        private readonly CD_Oferta ObjetoOferta = new CD_Oferta();

        /// <summary>
        /// Lista todos las ofertas.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Oferta.</returns>
        public List<Oferta> ListarOferta()
        {
            return ObjetoOferta.MostrarOfertas();
        }

        /// <summary>
        /// Método que valida el registro de una nueva oferta.
        /// </summary>
        /// <param name="obj">El objeto Oferta a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Oferta obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre
            if (Validaciones.EsTextoVacio(obj.NombreOferta))
            {
                mensaje += "\n- Es necesario el nombre de la oferta.";
            }
            else if (!Validaciones.EsSoloLetras(obj.NombreOferta))
            {
                mensaje += "\n- El nombre de la oferta solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (Validaciones.EsTextoVacio(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la oferta.";
            }

            // Validar Fecha Fin
            if (obj.FechaFin.HasValue)
            {
                if (obj.FechaFin.Value < DateTime.Now.Date)
                {
                    mensaje += "\n- La fecha fin de la oferta no puede ser una fecha pasada.";
                }
            }
            else
            {
                mensaje += "\n- Es necesario especificar la fecha fin de la oferta.";
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
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return 0;
            }

            return ObjetoOferta.RegistrarOferta(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de una oferta existente.
        /// </summary>
        /// <param name="obj">El objeto Oferta a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Oferta obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre
            if (Validaciones.EsTextoVacio(obj.NombreOferta))
            {
                mensaje += "\n- Es necesario el nombre de la oferta.";
            }
            else if (!Validaciones.EsSoloLetras(obj.NombreOferta))
            {
                mensaje += "\n- El nombre de la oferta solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (Validaciones.EsTextoVacio(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción de la oferta.";
            }

            // Validar Fecha Fin
            if (obj.FechaFin.HasValue)
            {
                if (obj.FechaFin.Value < DateTime.Now.Date)
                {
                    mensaje += "\n- La fecha fin de la oferta no puede ser una fecha pasada.";
                }
            }
            else
            {
                mensaje += "\n- Es necesario especificar la fecha fin de la oferta.";
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
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return false;
            }

            return ObjetoOferta.EditarOferta(obj, out mensaje);
        }

        /// <summary>
        ///  Método que valida la eliminación de una oferta existente.
        /// </summary>
        /// <param name="obj">El objeto Oferta a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
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
    }
}
