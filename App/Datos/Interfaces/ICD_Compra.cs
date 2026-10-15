using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Contrato de la capa de datos implementado por <see cref="CD_Compra"/>.
    /// La capa de negocio depende de esta interfaz para poder reemplazarla por un mock en las pruebas unitarias.
    /// </summary>
    public interface ICD_Compra
    {
        /// <summary>
        /// Método que muestra el correlativo de cada Compra
        /// </summary>
        /// <returns>El número correlativo de la compra</returns>
        int ObtenerCorrelativoCompra();

        /// <summary>
        /// Método que permite registrar una nueva Compra
        /// </summary>
        /// <param name="obj">Objeto de tipo Compra que contiene los datos de la nueva compra</param>
        /// <param name="DetalleCompra">DataTable que contiene los detalles de la compra</param>
        /// <param name="Mensaje">Mensaje de salida que indica el resultado de la operación</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa</returns>
        bool RegistrarCompra(Compra obj, DataTable DetalleCompra, out string Mensaje);

        /// <summary>
        /// Método que muestra la información de la Compra
        /// </summary>
        /// <param name="numero">Número del documento de la compra</param>
        /// <returns>Un objeto de tipo Compra con la información de la compra</returns>
        Compra ObtenerCompra(string numero);

        /// <summary>
        /// Método que muestra el detalle de la Compra
        /// </summary>
        /// <param name="idCompra">ID de la compra</param>
        /// <returns>Una lista de objetos de tipo Detalle_Compra con los detalles de la compra</returns>
        List<Detalle_Compra> ObtenerDetalleCompra(int idCompra);

        /// <summary>
        /// Método que muestra los productos más comprados
        /// </summary>
        /// <returns>Un DataTable con los productos más comprados</returns>
        DataTable GraficaProductosComprados();

        /// <summary>
        /// Método que muestra a los provedores que mas compras le han realizado
        /// </summary>
        /// <returns>Un DataTable de los proveedores</returns>
        DataTable GraficaProveedorPreferencia();

        /// <summary>
        /// Método que muestra la cantidad de viajes que ha realizado cada transportista
        /// </summary>
        /// <returns>Un DataTable de los transportistas</returns>
        DataTable GraficaViajesRealizados();

        /// <summary>
        /// Método que muestra las sucursales donde mas han comprado productos
        /// </summary>
        /// <returns>Un DataTable con las compras de cada sucursal</returns>
        DataTable GraficaSucursalesCompras();
    }
}
