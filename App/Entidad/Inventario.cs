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
        public Zona_Almacen oZonaAlmacen { get; set; }
        public int? Cantidad { get; set; }
        public string FechaIngreso { get; set; }

    }
}
