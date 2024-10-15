using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public Producto oProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public string UbicacionAlmacen { get; set; }
        public bool Estado { get; set; }
        public string FechaIngreso { get; set; }
    }
}
