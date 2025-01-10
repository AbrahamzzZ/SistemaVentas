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
        private CD_Permiso ObjetoPermiso = new CD_Permiso();

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
