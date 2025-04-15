using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocios
{
    public class CN_Cliente
    {

        private readonly CD_Cliente ObjetoCliente = new CD_Cliente();

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
            if (Validaciones.EsTextoVacio(obj.Nombres))
            {
                mensaje += "\n- Es necesario los nombres del cliente.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Nombres))
            {
                mensaje += "\n- Los nombres del cliente solo pueden contener letras y no números.";
            }

            // Validar Apellidos
            if (Validaciones.EsTextoVacio(obj.Apellidos))
            {
                mensaje += "\n- Es necesario los apellidos del cliente.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Apellidos))
            {
                mensaje += "\n- Los apellidos del cliente solo pueden contener letras y no números.";
            }

            //Validar Cedula
            if (Validaciones.EsTextoVacio(obj.Cedula))
            {
                mensaje += "\n- Es necesario la cédula del cliente.";
            }
            else if (!Validaciones.EsCedulaValida(obj.Cedula))
            {
                mensaje += "\n- La cédula del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar Telefono
            if (Validaciones.EsTextoVacio(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del cliente.";
            }
            else if (!Validaciones.EsTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            // Validar Correo Electrónico
            if (Validaciones.EsTextoVacio(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del usuario.";
            }
            else if (!Validaciones.EsCorreoValido(obj.CorreoElectronico))
            {
                mensaje += "\n- El correo electrónico no tiene un formato válido.";
            }

            // Retornar false si hay mensajes de error
            if (!Validaciones.EsTextoVacio(mensaje))
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
            if (Validaciones.EsTextoVacio(obj.Nombres))
            {
                mensaje += "\n- Es necesario los nombres del cliente.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Nombres))
            {
                mensaje += "\n- Los nombres del cliente solo pueden contener letras y no números.";
            }

            // Validar Apellidos
            if (Validaciones.EsTextoVacio(obj.Apellidos))
            {
                mensaje += "\n- Es necesario los apellidos del cliente.";
            }
            else if (!Validaciones.EsSoloLetras(obj.Apellidos))
            {
                mensaje += "\n- Los apellidos del cliente solo pueden contener letras y no números.";
            }

            //Validar Cedula
            if (Validaciones.EsTextoVacio(obj.Cedula))
            {
                mensaje += "\n- Es necesario la cédula del cliente.";
            }
            else if (!Validaciones.EsCedulaValida(obj.Cedula))
            {
                mensaje += "\n- La cédula del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar Telefono
            if (Validaciones.EsTextoVacio(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del cliente.";
            }
            else if (!Validaciones.EsTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del cliente solo pueden contener exactamente 10 números y no letras.";
            }

            // Validar Correo Electrónico
            if (Validaciones.EsTextoVacio(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del cliente.";
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
    }
}
