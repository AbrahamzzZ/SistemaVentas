using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Rol"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Rol
    {
        /// <summary>
        /// Método que muestra una lista de todos los Roles que existen
        /// </summary>
        /// <returns>Una lista de objetos de tipo Rol</returns>
        List<Rol> RolesUsuarios();
    }
}
