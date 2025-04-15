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
    public class CN_Negocio
    {
        private readonly CD_Negocio ObjetoNegocio = new CD_Negocio();

        /// <summary>
        /// Método que obtiene la información del negocio.
        /// </summary>
        /// <returns>Un objeto de tipo Negocio con la información del negocio.</returns>
        public Negocio ListarNegocio()
        {
            return ObjetoNegocio.ObtenerInformacionNegocio();
        }

        /// <summary>
        /// Método que valida la edición del negocio existente.
        /// </summary>
        /// <param name="obj">El objeto Negocio a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;

            //Validad Nombre
            if (Validaciones.EsTextoVacio(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre del negocio.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Nombre))
            {
                mensaje += "\n- El nombre del negocio solo puede contener letras y no números.";
            }

            //Validar Telefono
            if (Validaciones.EsTextoVacio(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del negocio.";
            }
            else if (!Validaciones.EsTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El teléfono del negocio solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar RUC
            if (Validaciones.EsTextoVacio(obj.Ruc))
            {
                mensaje += "\n- Es necesario el RUC del negocio.";
            }
            else if (!Validaciones.EsRucValido(obj.Ruc))
            {
                mensaje += "\n- El RUC del negocio solo pueden contener exactamente 13 números y no letras.";
            }

            //Validar Direccion
            if (Validaciones.EsTextoVacio(obj.Direccion))
            {
                mensaje += "\n- Es necesario la dirección del negocio.";
            }

            //Validar Correo Electronico
            if (Validaciones.EsTextoVacio(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del negocio.";
            }
            else if (!Validaciones.EsCorreoValido(obj.CorreoElectronico))
            {
                mensaje += "\n- El correo electrónico no tiene un formato válido.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
            {
                return false;
            }

            return ObjetoNegocio.EditarNegocio(obj, out mensaje);
        }

        /// <summary>
        /// Método que obtiene el logo del negocio.
        /// </summary>
        /// <param name="obtenido">Indica si el logo fue obtenido correctamente.</param>
        /// <returns>Un array de bytes que representa el logo del negocio.</returns
        public byte[] MostrarLogo(out bool obtenido)
        {
            return ObjetoNegocio.ObtenerLogoNegocio(out obtenido);
        }

        /// <summary>
        /// Método que actualiza el logo del negocio.
        /// </summary>
        /// <param name="image">La imagen del logo en formato byte array.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            return ObjetoNegocio.ActualizarLogoNegocio(image, out mensaje);
        }
    }
}
