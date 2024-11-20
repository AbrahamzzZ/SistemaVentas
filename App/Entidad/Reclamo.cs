using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Reclamo
    {
        public int IdReclamo { get; set; }
        public Cliente oCliente { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
