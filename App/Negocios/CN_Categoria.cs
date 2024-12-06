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
    public class CN_Categoria
    {
        private CD_Categoria ObjetoCategoria = new CD_Categoria();

        public List<Categoria> ListarCategoria()
        {
            return ObjetoCategoria.MostrarCategorias();
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            return ObjetoCategoria.RegistrarCategoria(obj, out mensaje);

        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripción de la categoría.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoCategoria.EditarCategoria(obj, out mensaje);
            }
        }

        public bool Eliminar(Categoria obj, out string mensaje)
        {
            return ObjetoCategoria.EliminarCategoria(obj, out mensaje);
        }
    }
}
