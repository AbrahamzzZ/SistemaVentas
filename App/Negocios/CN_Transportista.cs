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
    public class CN_Transportista
    {
        private CD_Transportista ObjetoTransportista = new CD_Transportista();

        public List<Transportista> ListarTransportista()
        {
            return ObjetoTransportista.MostrarTransportistas();
        }

        public int Registrar(Transportista obj, byte[] imagen, out string mensaje)
        {
            return ObjetoTransportista.RegistrarTransportista(obj, imagen, out mensaje);
        }

        public bool Editar(Transportista obj, byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del transportista.\n";
            }
            if (obj.Nombres == "")
            {
                mensaje += "Es necesario los dos nombres del transportista.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "Es necesario los dos apellidos del transportista.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "Es necesario la cédula del transportista.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "Es necesario el teléfono del transportista.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrénico del transportista.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoTransportista.EditarTransportista(obj, imagen, out mensaje);
            }
        }

        public bool Eliminar(Transportista obj, out string mensaje)
        {
            return ObjetoTransportista.EliminarTransportista(obj, out mensaje);
        }
    }
}
