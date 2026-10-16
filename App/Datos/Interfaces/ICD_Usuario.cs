using System;
using System.Collections.Generic;
using System.Data;
using Entidad;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Usuario"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Usuario
    {
        /// <summary>
        /// Método que permite ingresar al Usuario al sistema.
        /// </summary>
        /// <param name="codigo">Código del usuario.</param>
        /// <returns>Un objeto de tipo Usuario.</returns>
        Usuario IngresarUsuarioLogin(string codigo);

        bool GenerarTokenRecuperacion(string correoElectronico, ref string tokenGenerado);

        /// <summary>
        /// Método que permite mostrar la información de un usuario mediante su ID.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Un objeto Usuario que contiene la informacion de ese usuario.</returns>
        Usuario UsuarioID(int id);

        /// <summary>
        /// Metodo que muestra una lista de todos los Usuarios que existen con su respectivo rol.
        /// </summary>
        /// <returns>Una lista de objetos Usuario que contiene la información de todos los usuarios y sus respectivos roles.</returns>
        List<Usuario> MostrarUsuarios();

        /// <summary>
        /// Método que permite registrar un nuevo Usuario
        /// </summary>
        /// <param name="obj">Objeto de tipo Usuario que contiene los datos del nuevo usuario</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>El ID del usuario generado, o 0 si hubo un error</returns>
        int RegistrarUsuario(Usuario obj, out string Mensaje);

        /// <summary>
        /// Método que permite editar la información de un Usuario ya registrado
        /// </summary>
        /// <param name="obj">Objeto de tipo Usuario que contiene los datos actualizados del usuario</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EditarUsuario(Usuario obj, out string Mensaje);

        /// <summary>
        /// Método que permite eliminar a un Usuario
        /// </summary>
        /// <param name="obj">Objeto de tipo Usuario que contiene el ID del usuario a eliminar</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool EliminarUsuario(Usuario obj, out string Mensaje);
    }
}
