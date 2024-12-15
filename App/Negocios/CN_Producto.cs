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
            mensaje = string.Empty;

            // Validar Nombre Completo
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre completo del producto.";
            }
            else if (!EsNombreValido(obj.Nombre))
            {
                mensaje += "\n- El nombre del producto solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción del producto.";
            }

            // Validar Pais de Origen
            if (string.IsNullOrWhiteSpace(obj.PaisOrigen))
            {
                mensaje += "\n- Es necesario el pais de origen del producto.";
            }
            else if (!EsNombreValido(obj.PaisOrigen))
            {
                mensaje += "\n- El pais de origen del producto solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoProducto.RegistrarProducto(obj, out mensaje);
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre Completo
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre completo del producto.";
            }
            else if (!EsNombreValido(obj.Nombre))
            {
                mensaje += "\n- El nombre del producto solo puede contener letras y no números.";
            }

            // Validar Descripcion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje += "\n- Es necesario la descripción del producto.";
            }

            // Validar Pais de Origen
            if (string.IsNullOrWhiteSpace(obj.PaisOrigen))
            {
                mensaje += "\n- Es necesario el pais de origen del producto.";
            }
            else if (!EsNombreValido(obj.PaisOrigen))
            {
                mensaje += "\n- El pais de origen del producto solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoProducto.EditarProducto(obj, out mensaje);
        }

        public bool Eliminar(Producto obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdProducto == 0)
            {
                mensaje = "Debe seleccionar un Producto válido para eliminar.";
                return false;
            }

            return ObjetoProducto.EliminarProducto(obj, out mensaje);
        }

        public int ObtenerStockId(int IdProducto)
        {
            return ObjetoProducto.MostrarProductoStock(IdProducto);
        }

        private bool EsNombreValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }
    }
}
