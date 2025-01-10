using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Negocios
{
    public class CN_Usuario
    {
        private CD_Usuario ObjetoUsuario = new CD_Usuario();
        private static int intentos = 0;

        /// <summary>
        /// Método que muestra al usuario logueado.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Usuario.</returns>
        public List<Usuario> Ingresar()
        {
            return ObjetoUsuario.IngresarUsuarioLogin();
        }

        /// <summary>
        /// Método que muestra la clave del usuario mediante el correo electrónico.
        /// </summary>
        /// <param name="correoElectronico">El correo electrónico del usuario.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un objeto Usuario con la clave del usuario.</returns>
        public Usuario MostrarClave(string correoElectronico, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(correoElectronico))
            {
                mensaje = "Por favor, ingrese un correo electrónico.";
                return null;
            }

            if (!EsCorreoValido(correoElectronico))
            {
                mensaje = "El correo electrónico ingresado no es válido.";
                return null;
            }

            // Si las validaciones pasan, buscar el usuario por correo electrónico
            return ObjetoUsuario.RecuperarClave(correoElectronico);
        }

        /// <summary>
        /// Método que enlista todos los usuarios para que aparezcan en la tabla de la ventana Usuario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Usuario.</returns>
        public List<Usuario> ListarUsuario()
        {
            return ObjetoUsuario.MostrarUsuarios();
        }

        /// <summary>
        /// Método que valida las credenciales para iniciar sesión.
        /// </summary>
        /// <param name="codigo">El código del usuario.</param>
        /// <param name="clave">La clave del usuario.</param>
        /// <returns>Un mensaje indicando el resultado de la validación.</returns>
        public string ValidarLogin(string codigo, string clave)
        {
            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(clave))
            {
                return "Por favor, llene todos los campos para iniciar sesión.";
            }
            else if (!EsCodigoValido(codigo))
            {
                return "Debe ingresar números y no letras en el campo código.";
            }

            // Buscar el usuario por código y clave
            List<Usuario> listaUsuarios = ObjetoUsuario.IngresarUsuarioLogin();
            Usuario usuario = listaUsuarios.FirstOrDefault(u => u.Codigo == codigo && u.Clave == clave);

            if (usuario == null)
            {
                intentos++;
                if (intentos >= 4)
                {
                    return "Se ha alcanzado el límite de intentos fallidos. Inténtelo más tarde.";
                }
                return "Las credenciales ingresadas son incorrectas.";
            }

            // Reiniciar el contador de intentos si el login fue exitoso
            intentos = 0;

            if (!usuario.Estado)
            {
                return "El usuario no está habilitado. Por favor, contacte al administrador.";
            }

            return string.Empty; 
        }

        /// <summary>
        /// Método que valida el registro de un nuevo usuario.
        /// </summary>
        /// <param name="obj">El objeto Usuario a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre Completo
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                mensaje += "\n- Es necesario el nombreCompleto completo del usuario.";
            }
            else if (!EsNombreValido(obj.NombreCompleto))
            {
                mensaje += "\n- El nombreCompleto del usuario solo puede contener letras y no números.";
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

            // Validar Clave
            if (string.IsNullOrWhiteSpace(obj.Clave))
            {
                mensaje += "\n- Es necesario la clave del usuario.";
            }
            else if (!EsClaveValida(obj.Clave))
            {
                mensaje += "\n- La clave debe tener al menos 8 caracteres, incluir una letra, un número y un carácter especial.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0; 
            }

            // Si las validaciones son exitosas, proceder al registro
            return ObjetoUsuario.RegistrarUsuario(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de un usuario existente.
        /// </summary>
        /// <param name="obj">El objeto Usuario a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre Completo
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                mensaje += "\n- Es necesario el nombreCompleto completo del usuario.";
            }
            else if (!EsNombreValido(obj.NombreCompleto))
            {
                mensaje += "\n- El nombreCompleto del usuario solo puede contener letras y no números.";
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

            // Validar Clave
            if (string.IsNullOrWhiteSpace(obj.Clave))
            {
                mensaje += "\n- Es necesario la clave del usuario.";
            }
            else if (!EsClaveValida(obj.Clave))
            {
                mensaje += "\n- La clave debe tener al menos 8 caracteres, incluir una letra, un número y un carácter especial.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            // Pasar a la capa de datos si todas las validaciones se cumplen
            return ObjetoUsuario.EditarUsuario(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de un usuario existente.
        /// </summary>
        /// <param name="obj">El objeto Usuario a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Usuario obj, out string mensaje)
        {

            // Validaciones de negocio
            if (obj.IdUsuario == 0)
            {
                mensaje = "Debe seleccionar un Usuario válido para eliminar.";
                return false;
            }

            if (obj.IdUsuario == 1)
            {
                mensaje = "No se puede eliminar el primer Usuario porque es necesario para el acceso al sistema.";
                return false;
            }

            // Llamar al método de la capa de datos si pasa las validaciones
            return ObjetoUsuario.EliminarUsuario(obj, out mensaje);
        }

        /// <summary>
        /// Verifica si el código del usuario es válido.
        /// </summary>
        /// <param name="codigo">El código del usuario.</param>
        /// <returns>Un booleano que indica si el código es válido.</returns>
        private bool EsCodigoValido(string codigo)
        {
            return codigo.All(char.IsDigit); 
        }

        /// <summary>
        /// Verifica si el nombreCompleto completo del usuario es válido.
        /// </summary>
        /// <param name="nombreCompleto">El nombreCompleto completo del usuario.</param>
        /// <returns>Un booleano que indica si el nombreCompleto completo es válido.</returns>
        private bool EsNombreValido(string nombreCompleto)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; 
            return System.Text.RegularExpressions.Regex.IsMatch(nombreCompleto, patron);
        }

        /// <summary>
        /// Verifica si el correo electrónico del usuario es válido.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <returns>Un booleano que indica si el coreo electrónico es válido.</returns>
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; 
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }

        /// <summary>
        /// Verifica si la clave del usuario es válida.
        /// </summary>
        /// <param name="clave">Clave del usuario.</param>
        /// <returns>Un booleano que indica si la clave es válida.</returns>
        private bool EsClaveValida(string clave)
        {
            if (clave.Length < 8)
                return false;

            bool tieneLetra = clave.Any(char.IsLetter);
            bool tieneNumero = clave.Any(char.IsDigit);
            bool tieneCaracterEspecial = clave.Any(c => !char.IsLetterOrDigit(c));

            return tieneLetra && tieneNumero && tieneCaracterEspecial;
        }
    }
}
