using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Zona_Almacen
    {
        public int IdZona { get; set; }
        public string NombreZona { get; set; }
        public int LimiteEspacios { get; set; }
        public bool Estado { get; set; }
    }
}
