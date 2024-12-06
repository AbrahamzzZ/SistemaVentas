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
    public class CN_Proveedor
    {
        private CD_Proveedor ObjetoProveedor = new CD_Proveedor();

        public List<Proveedor> ListarProveedores()
        {
            return ObjetoProveedor.MostrarProveedores();
        }

        public int Registrar(Proveedor obj, out string mensaje)
        {
            return ObjetoProveedor.RegistrarProveedor(obj, out mensaje);
        }

        public bool Editar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del proveedor.\n";
            }
            if (obj.Nombres == "")
            {
                mensaje += "Es necesario los dos nombres del proveedor.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "Es necesario los dos apellidos del proveedor.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "Es necesario la cédula del proveedor.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "Es necesario el teléfono del proveedor.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrénico del proveedor.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoProveedor.EditarProveedor(obj, out mensaje);
            }
        }

        public bool Eliminar(Proveedor obj, out string mensaje)
        {
            return ObjetoProveedor.EliminarProveedor(obj, out mensaje);
        }
    }
}
