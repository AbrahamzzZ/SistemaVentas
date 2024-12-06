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
        public List<Permiso> Permisos(int idUsuario)
        {
            return ObjetoPermiso.PermisosUsuarios(idUsuario);
        }
    }
}
