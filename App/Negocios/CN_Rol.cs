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
        private CD_Rol ObjetoRol = new CD_Rol();
        public List<Rol> Rol()
        {
            return ObjetoRol.RolesUsuarios();
        }
    }
}
