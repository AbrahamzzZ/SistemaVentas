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
    public class CN_Producto
    {
        private CD_Producto ObjetoProducto = new CD_Producto();
        public List<Producto> ListarProducto()
        {
            return ObjetoProducto.MostrarProductos();
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            return ObjetoProducto.RegistrarProducto(obj, out mensaje);
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                mensaje += "Es necesario el codigo del producto.\n";
            }
            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el nombre del producto.\n";
            }
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario el descripción del producto.\n";
            }
            if (obj.PaisOrigen == "")
            {
                mensaje += "Es necesario el país de origen del producto.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoProducto.EditarProducto(obj, out mensaje);
            }
        }
        public bool Eliminar(Producto obj, out string mensaje)
        {
            return ObjetoProducto.EliminarProducto(obj, out mensaje);
        }
    }
}
