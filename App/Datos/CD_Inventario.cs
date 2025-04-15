﻿using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Inventario
    {

        private readonly Conexion Conexion = new Conexion();

        /// <summary>
        /// Método que muestra una lista de todos los productos que estan en el inventario.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Inventario.</returns>
        public List<Inventario> MostrarProductoInventario()
        {
            List<Inventario> listaMostrarProductoInventario = new List<Inventario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT i.ID_INVENTARIO, z.ID_ZONA, p.ID_PRODUCTO, p.NOMBRE_PRODUCTO, i.CANTIDAD, z.NOMBRE_ZONA FROM INVENTARIO i");
                mostrar.AppendLine("INNER JOIN PRODUCTO p ON p.ID_PRODUCTO = i.ID_PRODUCTO");
                mostrar.AppendLine("INNER JOIN ZONA_ALMACEN z ON z.ID_ZONA = i.ID_ZONA");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), Conexion.ConexionBD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarProductoInventario.Add(new Inventario()
                    {
                        IdInventario = Convert.ToInt32(leer["ID_INVENTARIO"]),
                        oProducto = new Producto() { IdProducto = Convert.ToInt32(leer["ID_PRODUCTO"]), Nombre = leer["NOMBRE_PRODUCTO"].ToString() },
                        oZonaAlmacen = new Zona_Almacen() { IdZona = Convert.ToInt32(leer["ID_ZONA"]), NombreZona = leer["NOMBRE_ZONA"].ToString() },
                        Cantidad = Convert.ToInt32(leer["CANTIDAD"])
                    });
                }
            }
            catch (Exception inv)
            {
                Console.WriteLine($"Error al mostrar el inventario: {inv.Message}");
                throw;
            }
            return listaMostrarProductoInventario;
        }

        /// <summary>
        /// Método que permite registrar un producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el ID del inventario generado.</returns>
        public int AgregarProductoInventario(Inventario obj, out string mensaje)
        {
            int idInventarioGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_PRODUCTO_INVENTARIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("ID_PRODUCTO", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("ID_ZONA", obj.oZonaAlmacen.IdZona);
                cmd.Parameters.AddWithValue("CANTIDAD", obj.Cantidad);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idInventarioGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                idInventarioGenerado = 0;
                mensaje = inv.Message;
            }
            return idInventarioGenerado;
        }

        /// <summary>
        /// Método que permite editar la información del producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool EditarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_PRODUCTO_INVENTARIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Inventario", obj.IdInventario);
                cmd.Parameters.AddWithValue("Id_Producto", obj.oProducto.IdProducto);
                cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                cmd.Parameters.AddWithValue("Id_Zona", obj.oZonaAlmacen.IdZona);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                respuesta = false;
                mensaje = inv.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Método que permite eliminar un producto en el inventario.
        /// </summary>
        /// <param name="obj">El objeto Inventario a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool EliminarProductoInventario(Inventario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_PRODUCTO_INVENTARIO", Conexion.ConexionBD());
                cmd.Parameters.AddWithValue("Id_Inventario", obj.IdInventario);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception inv)
            {
                respuesta = false;
                mensaje = inv.Message;

            }
            return respuesta;
        }
    }
}
