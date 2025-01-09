using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Negocios
{
    public class CN_Proveedor
    {
        private CD_Proveedor ObjetoProveedor = new CD_Proveedor();

        /// <summary>
        /// Lista todos los proveedores.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Proveedor.</returns>
        public List<Proveedor> ListarProveedores()
        {
            return ObjetoProveedor.MostrarProveedores();
        }

        /// <summary>
        /// Método que valida el registro de un nuevo proveedor.
        /// </summary>
        /// <param name="obj">El objeto Proveedor a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Proveedor obj, out string mensaje)
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

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            } 

            return ObjetoProveedor.RegistrarProveedor(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de un proveedor existente.
        /// </summary>
        /// <param name="obj">El objeto Proveedor a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Proveedor obj, out string mensaje)
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

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoProveedor.EditarProveedor(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de un proveedor existente.
        /// </summary>
        /// <param name="obj">El objeto Proveedor a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Proveedor obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdProveedor == 0)
            {
                mensaje = "Debe seleccionar un Proveedor válido para eliminar.";
                return false;
            }

            return ObjetoProveedor.EliminarProveedor(obj, out mensaje);
        }

        /// <summary>
        /// Verifica si la cédula y el telefóno del proveedor son válidos.
        /// </summary>
        /// <param name="cedulaTelefono">La cédula y el telefóno del proveedor.</param>
        /// <returns>Un booleano que indica si la cédula y el telefóno son válidos.</returns>
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
        /// Verifica si los nombres y apellidos del proveedor son válidos.
        /// </summary>
        /// <param name="nombresApellidos">Los nombres y apellidos del proveedor.</param>
        /// <returns>Un booleano que indica si los nombres y apellidos son válidos.</returns>
        private bool EsNombreApellidoValido(string nombresApellidos)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombresApellidos, patron);
        }

        /// <summary>
        /// Verifica si el correo electrónico del proveedor es válido.
        /// </summary>
        /// <param name="correo">Correo electrónico del proveedor.</param>
        /// <returns>Un booleano que indica si el coreo electrónico es válido.</returns>
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón de correo válido
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }
    }
}
