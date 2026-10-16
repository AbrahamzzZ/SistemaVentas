using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class CN_Permiso
    {
        private readonly ICD_Permiso ObjetoPermiso;

        /// <summary>
        /// Constructor usado por la aplicación.
        /// </summary>
        public CN_Permiso() : this(new CD_Permiso())
        {
        }

        /// <summary>
        /// Constructor usado para inyectar un mock en las pruebas unitarias.
        /// </summary>
        /// <param name="datos">Implementación de la capa de datos.</param>
        public CN_Permiso(ICD_Permiso datos)
        {
            ObjetoPermiso = datos ?? throw new ArgumentNullException(nameof(datos));
        }

        /// <summary>
        /// Método que obtiene la lista de permisos de un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <returns>Una lista de objetos de tipo Permiso.</returns>
        public List<Permiso> Permisos(int idUsuario)
        {
            return ObjetoPermiso.PermisosUsuarios(idUsuario);
        }
    }
}
