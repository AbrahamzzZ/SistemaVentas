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
    public class CN_Rol
    {
        private readonly CD_Rol ObjetoRol = new CD_Rol();

        /// <summary>
        /// Método que obtiene la lista de roles de usuarios.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Rol.</returns>
        public List<Rol> Rol()
        {
            return ObjetoRol.RolesUsuarios();
        }
    }
}
