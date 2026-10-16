using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Zona_Almacen"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Zona_Almacen
    {
        /// <summary>
        /// Método que muestra una lista de todas las Zonas de almacenamiento que tiene el supermercado
        /// </summary>
        /// <returns>Una lista de objetos de tipo Zona_Almacen</returns>
        List<Zona_Almacen> MostrarZonasAlmacen();
    }
}
