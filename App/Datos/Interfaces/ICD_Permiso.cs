using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Permiso"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Permiso
    {
        /// <summary>
        /// Método que muestra una lista de todos los Permisos que tienen cada Usuario
        /// </summary>
        /// <param name="idusuario">ID del usuario</param>
        /// <returns>Una lista de objetos de tipo Permiso</returns>
        List<Permiso> PermisosUsuarios(int idusuario);
    }
}
