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
    public class CN_Negocio
    {
        private CD_Negocio ObjetoNegocio = new CD_Negocio();

        public Negocio ListarNegocio()
        {
            return ObjetoNegocio.ObtenerInformacionNegocio();
        }
  
        public bool Editar(Negocio obj, out string mensaje)
        {
            return ObjetoNegocio.EditarInformacionNegocio(obj, out mensaje);
        }

        public byte[] MostrarLogo(out bool obtenido)
        {
            return ObjetoNegocio.ObtenerLogoNegocio(out obtenido);
        }

        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            return ObjetoNegocio.ActualizarLogoNegocio(image, out mensaje);
        }
    }
}
