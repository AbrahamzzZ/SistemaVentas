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
    public class CN_Sucursal
    {
        private CD_Sucursal ObjetoSucursal = new CD_Sucursal();

        public List<Sucursal> ListarSucusal()
        {
            return ObjetoSucursal.MostrarSucursales();
        }

        public int Registrar(Sucursal obj, out string mensaje)
        {
            return ObjetoSucursal.RegistrarSucursal(obj, out mensaje);
        }

        public bool Editar(Sucursal obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el nombre de la sucursal.\n";
            }
            if (obj.Direccion == "")
            {
                mensaje += "Es necesario la dirección de la sucursal.\n";
            }
            if (obj.Latitud == 0)
            {
                mensaje += "Es necesario la latitud de la sucursal.";
            }
            if (obj.Longitud == 0)
            {
                mensaje += "Es necesario la longitud de la sucursal.";
            }
            if (obj.Ciudad == "")
            {
                mensaje += "Es necesario la ciudad de la sucursal.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoSucursal.EditarSucursal(obj, out mensaje);
            }
        }
        public bool Eliminar(Sucursal obj, out string mensaje)
        {
            return ObjetoSucursal.EliminarSucursal(obj, out mensaje);
        }
    }
}
