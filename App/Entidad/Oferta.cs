using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Oferta
    {
        public int IdOferta { get; set; }
        public string Codigo { get; set; }
        public Producto oProducto { get; set; }
        public string NombreOferta { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal? Descuento { get; set; }
        public bool Estado { get; set; }
    }
}
