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
    public class CN_Oferta
    {
        private CD_Oferta ObjetoOferta = new CD_Oferta();

        public List<Oferta> ListarOferta()
        {
            return ObjetoOferta.MostrarOfertas();
        }

        public int Registrar(Oferta obj, out string mensaje)
        {
            return ObjetoOferta.RegistrarOferta(obj, out mensaje);
        }

        public bool Editar(Oferta obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.NombreOferta == "")
            {
                mensaje += "Es necesario el nombre de la oferta.\n";
            }
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario el descripción de la oferta.\n";
            }
            if (obj.Descuento == 0)
            {
                mensaje += "Es necesario el descuento para la oferta.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoOferta.EditarOferta(obj, out mensaje);
            }
        }

        public bool Eliminar(Oferta obj, out string mensaje)
        {
            return ObjetoOferta.EliminarOferta(obj, out mensaje);
        }
    }
}
