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
    public class CN_Cliente
    {

        private CD_Cliente ObjetoCliente = new CD_Cliente();

        /// <summary>
        /// Lista todos los clientes.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Cliente.</returns>
        public List<Cliente> ListarCliente()
        {
            return ObjetoCliente.MostrarClientes();
        }

        /// <summary>
        /// Método que valida el registro de un nuevo cliente.
        /// </summary>
        /// <param name="obj">El objeto Cliente a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombres
            if (string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje += "\n- Es necesario los nombres del cliente.";
            }
            else if (!EsNombreApellidoValido(obj.Nombres))
            {
                mensaje += "\n- Los nombres del cliente solo pueden contener letras y no números.";
            }

            // Validar Apellidos
            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje += "\n- Es necesario los apellidos del cliente.";
            }
            else if (!EsNombreApellidoValido(obj.Apellidos))
            {
                mensaje += "\n- Los apellidos del cliente solo pueden contener letras y no números.";
            }

            //Validar Cedula
            if (string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje += "\n- Es necesario la cédula del cliente.";
            }
            else if (!EsCedulaTelefonoValido(obj.Cedula))
            {
                mensaje += "\n- La cédula del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar Telefono
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del cliente.";
            }
            else if (!EsCedulaTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            // Validar Correo Electrónico
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del usuario.";
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

            // Pasar a la capa de datos si todas las validaciones se cumplen
            return ObjetoCliente.RegistrarCliente(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de un cliente existente.
        /// </summary>
        /// <param name="obj">El objeto Cliente a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombres
            if (string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje += "\n- Es necesario los nombres del cliente.";
            }
            else if (!EsNombreApellidoValido(obj.Nombres))
            {
                mensaje += "\n- Los nombres del cliente solo pueden contener letras y no números.";
            }

            // Validar Apellidos
            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje += "\n- Es necesario los apellidos del cliente.";
            }
            else if (!EsNombreApellidoValido(obj.Apellidos))
            {
                mensaje += "\n- Los apellidos del cliente solo pueden contener letras y no números.";
            }

            //Validar Cedula
            if (string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje += "\n- Es necesario la cédula del cliente.";
            }
            else if (!EsCedulaTelefonoValido(obj.Cedula))
            {
                mensaje += "\n- La cédula del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar Telefono
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del cliente.";
            }
            else if (!EsCedulaTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            // Validar Correo Electrónico
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del cliente.";
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

            // Pasar a la capa de datos si todas las validaciones se cumplen
            return ObjetoCliente.EditarCliente(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de un cliente existente.
        /// </summary>
        /// <param name="obj">El objeto Cliente a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Cliente obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdCliente == 0)
            {
                mensaje = "Debe seleccionar un Cliente válido para eliminar.";
                return false;
            }

            return ObjetoCliente.EliminarCliente(obj, out mensaje);
        }

        /// <summary>
        /// Verifica si la cédula y el telefóno del cliente son válidos.
        /// </summary>
        /// <param name="cedulaTelefono">La cédula y el telefóno del cliente.</param>
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
        /// Verifica si los nombres y apellidos del cliente son válidos.
        /// </summary>
        /// <param name="nombresApellidos">Los nombres y apellidos del cliente.</param>
        /// <returns>Un booleano que indica si los nombres y apellidos son válidos.</returns>
        private bool EsNombreApellidoValido(string nombresApellidos)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombresApellidos, patron);
        }

        /// <summary>
        /// Verifica si el correo electrónico del cliente es válido.
        /// </summary>
        /// <param name="correo">Correo electrónico del cliente.</param>
        /// <returns>Un booleano que indica si el coreo electrónico es válido.</returns>
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón de correo válido
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }
    }
}
