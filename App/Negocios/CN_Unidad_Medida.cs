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
    public class CN_Unidad_Medida
    {
        private CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();
        public List<Unidad_Medida> ListarUnidadesMedida()
        {
            return ObjetoUnidadMedida.MostrarUnidadesMedidas();
        }

        public int Registrar(Unidad_Medida obj, out string mensaje)
        {
            return ObjetoUnidadMedida.RegistrarUnidadMedida(obj, out mensaje);
        }

        public bool Editar(Unidad_Medida obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripción de la unidad de la medida.";
            }
            if (obj.Simbolo == "")
            {
                mensaje += "Es necesario la simbología de la unidad de la medida.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoUnidadMedida.EditarUnidadMedida(obj, out mensaje);
            }
        }

        public bool Eliminar(Unidad_Medida obj, out string mensaje)
        {
            return ObjetoUnidadMedida.EliminarUnidadMedida(obj, out mensaje);
        }
    }
}
