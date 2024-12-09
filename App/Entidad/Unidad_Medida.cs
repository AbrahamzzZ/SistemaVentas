using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Unidad_Medida
    {
        public int IdUnidadMedida { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Simbolo { get; set; }
        public bool Estado { get; set; }
        public string FechaCreacion { get; set; }
    }
}
