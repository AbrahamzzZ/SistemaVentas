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
    public class CN_Reclamo
    {
        private CD_Reclamo ObjetoUsuarioReclamo = new CD_Reclamo();

        public List<Reclamo> ListarReclamo()
        {
            return ObjetoUsuarioReclamo.MostrarReclamos();
        }
        public bool Editar(Reclamo obj, out string mensaje)
        {
            return ObjetoUsuarioReclamo.EditarReclamo(obj, out mensaje);

        }
        public bool Eliminar(Reclamo obj, out string mensaje)
        {
            return ObjetoUsuarioReclamo.EliminarReclamo(obj, out mensaje);
        }
    }
}
