using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class CN_Usuario
    {
        private readonly CD_Usuario ObjetoUsuario = new CD_Usuario();
        private static int intentos = 0;

        /// <summary>
        /// Método que muestra al usuario logueado.
        /// </summary>
        /// <param name="codigo">Código del usuario a ingresar.</param>
        /// <returns>Un objeto de tipo Usuario.</returns>
        public Usuario Ingresar(string codigo)
        {
            return ObjetoUsuario.IngresarUsuarioLogin(codigo);
        }

        public bool Token(string correoElectronico, ref string tokenGenerado)
        {
            return ObjetoUsuario.GenerarTokenRecuperacion(correoElectronico, ref tokenGenerado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string ValidarLogin(string codigo, string clave)
        {
            if (Validaciones.EsTextoVacio(codigo) || Validaciones.EsTextoVacio(clave))
            {
                return "Por favor, llene todos los campos para iniciar sesión.";
            }
            else if (!Validaciones.EsCodigoValido(codigo))
            {
                return "Debe ingresar números y no letras en el campo código.";
            }

            // Buscar el usuario por código y clave
            Usuario usuario = ObjetoUsuario.IngresarUsuarioLogin(codigo);

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
        /// Método que enlista todos los usuarios para que aparezcan en la tabla de la ventana Usuario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Usuario.</returns>
        public List<Usuario> ListarUsuario()
        {
            return ObjetoUsuario.MostrarUsuarios();
        }

        /// <summary>
        /// Método que muestra la información de un usuario en especifico por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario.</param>
        /// <returns>Un objeto Usuario con el ID del usuario.</returns>
        public Usuario ObtenerPorId(int id)
        {
            return ObjetoUsuario.UsuarioID(id);
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
            if (Validaciones.EsTextoVacio(obj.NombreCompleto))
            {
                mensaje += "\n- Es necesario el nombreCompleto completo del usuario.";
            }
            else if (!Validaciones.EsSoloLetras(obj.NombreCompleto))
            {
                mensaje += "\n- El nombreCompleto del usuario solo puede contener letras y no números.";
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
            if (Validaciones.EsTextoVacio(obj.NombreCompleto))
            {
                mensaje += "\n- Es necesario el nombreCompleto completo del usuario.";
            }
            else if (!Validaciones.EsSoloLetras(obj.NombreCompleto))
            {
                mensaje += "\n- El nombreCompleto del usuario solo puede contener letras y no números.";
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
    }
}
