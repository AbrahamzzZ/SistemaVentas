using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class CN_Zona_Almacen
    {
        private readonly ICD_Zona_Almacen ObjetoZonaAlmacen;

        /// <summary>
        /// Constructor usado por la aplicación.
        /// </summary>
        public CN_Zona_Almacen() : this(new CD_Zona_Almacen())
        {
        }

        /// <summary>
        /// Constructor usado para inyectar un mock en las pruebas unitarias.
        /// </summary>
        /// <param name="datos">Implementación de la capa de datos.</param>
        public CN_Zona_Almacen(ICD_Zona_Almacen datos)
        {
            ObjetoZonaAlmacen = datos ?? throw new ArgumentNullException(nameof(datos));
        }

        /// <summary>
        /// Lista todas las Zonas de Almacenamiento.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Zona_Almacen.</returns>
        public List<Zona_Almacen> ListarZonaAlmacen()
        {
            return ObjetoZonaAlmacen.MostrarZonasAlmacen();
        }
    }
}
