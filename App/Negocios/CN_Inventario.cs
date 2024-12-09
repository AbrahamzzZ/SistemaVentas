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
    public class CN_Inventario
    {

        private CD_Inventario ObjetoProductoInventario = new CD_Inventario();

        public List<Inventario> ListarProductoInventario()
        {
            return ObjetoProductoInventario.MostrarProductoInventario();
        }

        public int Registrar(Inventario obj, out string mensaje)
        {
            return ObjetoProductoInventario.AgregarProductoInventario(obj, out mensaje);
        }

        public bool Editar(Inventario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Cantidad == 0)
            {
                mensaje += "Es necesario la cantidad de productos.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoProductoInventario.EditarProductoInventario(obj, out mensaje);
            }
        }

        public bool Eliminar(Inventario obj, out string mensaje)
        {
            return ObjetoProductoInventario.EliminarProductoInventario(obj, out mensaje);
        }
    }
}
