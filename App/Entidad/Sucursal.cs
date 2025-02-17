using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public Negocio oNegocio { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string Ciudad { get; set; }
        public bool Estado { get; set; }
    }
}
