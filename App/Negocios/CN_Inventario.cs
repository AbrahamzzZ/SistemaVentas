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
            mensaje = string.Empty;

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoProductoInventario.AgregarProductoInventario(obj, out mensaje);
        }

        public bool Editar(Inventario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoProductoInventario.EditarProductoInventario(obj, out mensaje);
        }

        public bool Eliminar(Inventario obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdInventario == 0)
            {
                mensaje = "Debe seleccionar un Producto dentro del Inventario válida para eliminar.";
                return false;
            }

            return ObjetoProductoInventario.EliminarProductoInventario(obj, out mensaje);
        }
    }
}
