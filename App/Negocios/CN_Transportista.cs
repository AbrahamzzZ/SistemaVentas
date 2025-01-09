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
    public class CN_Transportista
    {
        private CD_Transportista ObjetoTransportista = new CD_Transportista();

        /// <summary>
        /// Lista todos los transportistas.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Transportista.</returns>
        public List<Transportista> ListarTransportista()
        {
            return ObjetoTransportista.MostrarTransportistas();
        }

        /// <summary>
        /// Método que valida el registro de un nuevo transportista.
        /// </summary>
        /// <param name="obj">El objeto Transportista a registrar.</param>
        /// <param name="imagen">La imagen del transportista.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Transportista obj, byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombres
            if (string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje += "\n- Es necesario los nombres del proveedor.";
            }
            else if (!EsNombreApellidoValido(obj.Nombres))
            {
                mensaje += "\n- Los nombres del proveedor solo pueden contener letras y no números.";
            }

            // Validar Apellidos
            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje += "\n- Es necesario los apellidos del proveedor.";
            }
            else if (!EsNombreApellidoValido(obj.Apellidos))
            {
                mensaje += "\n- Los apellidos del proveedor solo pueden contener letras y no números.";
            }

            //Validar Cedula
            if (string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje += "\n- Es necesario la cédula del proveedor.";
            }
            else if (!EsCedulaTelefonoValido(obj.Cedula))
            {
                mensaje += "\n- La cédula del proveedor solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar Telefono
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del proveedor.";
            }
            else if (!EsCedulaTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del proveedor solo pueden contener exactamente 10 números y no letras.";
            }

            // Validar Correo Electrónico
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del proveedor.";
            }
            else if (!EsCorreoValido(obj.CorreoElectronico))
            {
                mensaje += "\n- El correo electrónico no tiene un formato válido.";
            }

            // Validar imagen
            if (imagen == null || imagen.Length == 0)
            {
                mensaje += "\n- Es obligatorio cargar una imagen del transportista.";
                return 0;
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoTransportista.RegistrarTransportista(obj, imagen, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de un transportista existente.
        /// </summary>
        /// <param name="obj">El objeto Transportista a editar.</param>
        /// <param name="imagen">La imagen del transportista.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Transportista obj, byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombres
            if (string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje += "\n- Es necesario los nombres del proveedor.";
            }
            else if (!EsNombreApellidoValido(obj.Nombres))
            {
                mensaje += "\n- Los nombres del proveedor solo pueden contener letras y no números.";
            }

            // Validar Apellidos
            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje += "\n- Es necesario los apellidos del proveedor.";
            }
            else if (!EsNombreApellidoValido(obj.Apellidos))
            {
                mensaje += "\n- Los apellidos del proveedor solo pueden contener letras y no números.";
            }

            //Validar Cedula
            if (string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje += "\n- Es necesario la cédula del proveedor.";
            }
            else if (!EsCedulaTelefonoValido(obj.Cedula))
            {
                mensaje += "\n- La cédula del proveedor solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar Telefono
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del proveedor.";
            }
            else if (!EsCedulaTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del proveedor solo pueden contener exactamente 10 números y no letras.";
            }

            // Validar Correo Electrónico
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del proveedor.";
            }
            else if (!EsCorreoValido(obj.CorreoElectronico))
            {
                mensaje += "\n- El correo electrónico no tiene un formato válido.";
            }

            // Validar imagen
            if (imagen == null || imagen.Length == 0)
            {
                mensaje += "\n- Es obligatorio cargar una imagen del transportista.";
                return false;
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoTransportista.EditarTransportista(obj, imagen, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de un transportista existente.
        /// </summary>
        /// <param name="obj">El objeto Transportista a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Transportista obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdTransportista == 0)
            {
                mensaje = "Debe seleccionar un Transportista válido para eliminar.";
                return false;
            }
            return ObjetoTransportista.EliminarTransportista(obj, out mensaje);
        }

        private bool EsCedulaTelefonoValido(string cedulaTelefono)
        {
            // Verificar que tenga exactamente 10 caracteres
            if (cedulaTelefono.Length != 10)
            {
                return false;
            }

            return cedulaTelefono.All(char.IsDigit); // Verifica que todos los caracteres sean dígitos
        }

        /// <summary>
        /// Verifica si los nombres y apellidos del transportista son válidos.
        /// </summary>
        /// <param name="nombresApellidos">Los nombres y apellidos del transportista.</param>
        /// <returns>Un booleano que indica si los nombres y apellidos son válidos.</returns>
        private bool EsNombreApellidoValido(string nombresApellidos)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombresApellidos, patron);
        }

        /// <summary>
        /// Verifica si el correo electrónico del transportista es válido.
        /// </summary>
        /// <param name="correo">Correo electrónico del transportista.</param>
        /// <returns>Un booleano que indica si el coreo electrónico es válido.</returns>
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón de correo válido
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }
    }
}
