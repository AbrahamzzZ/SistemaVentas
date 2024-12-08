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
    public class CN_Cliente
    {
        private CD_Cliente ObjetoCliente = new CD_Cliente();

        public List<Cliente> ListarCliente()
        {
            return ObjetoCliente.MostrarClientes();
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            return ObjetoCliente.RegistrarCliente(obj, out mensaje);
        }

        public bool Editar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombres == "")
            {
                mensaje += "Es necesario los dos nombres del cliente.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "Es necesario los dos apellidos del cliente.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "Es necesario la cédula del cliente.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "Es necesario el teléfono del cliente.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrónico del cliente.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoCliente.EditarCliente(obj, out mensaje);
            }
        }

        public bool Eliminar(Cliente obj, out string mensaje)
        {
            return ObjetoCliente.EliminarCliente(obj, out mensaje);
        }
    }
}
