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
        private readonly ICD_Rol ObjetoRol;

        /// <summary>
        /// Constructor usado por la aplicación.
        /// </summary>
        public CN_Rol() : this(new CD_Rol())
        {
        }

        /// <summary>
        /// Constructor usado para inyectar un mock en las pruebas unitarias.
        /// </summary>
        /// <param name="datos">Implementación de la capa de datos.</param>
        public CN_Rol(ICD_Rol datos)
        {
            ObjetoRol = datos ?? throw new ArgumentNullException(nameof(datos));
        }

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
