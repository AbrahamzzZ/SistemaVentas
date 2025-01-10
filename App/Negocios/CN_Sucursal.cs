using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocios
{
    public class CN_Sucursal
    {
        private CD_Sucursal ObjetoSucursal = new CD_Sucursal();

        /// <summary>
        /// Lista todos las sucursales.
        /// </summary>
        /// <returns>Una lista de objetos de tipo Sucursal.</returns>
        public List<Sucursal> ListarSucusal()
        {
            return ObjetoSucursal.MostrarSucursales();
        }

        /// <summary>
        /// Método que valida el registro de un nueva sucursal.
        /// </summary>
        /// <param name="obj">El objeto Sucursal a registrar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un entero que indica el resultado de la operación.</returns>
        public int Registrar(Sucursal obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre de la sucursal.";
            }
            else if (!EsNombreValido(obj.Nombre))
            {
                mensaje += "\n- El nombre de la sucursal solo puede contener letras y no números.";
            }

            // Validar Direccion
            if (string.IsNullOrWhiteSpace(obj.Direccion))
            {
                mensaje += "\n- Es necesario la direccion de la sucursal.";
            }

            // Validar Latitud
            if (!obj.Latitud.HasValue)
            {
                mensaje += "\n- Es necesario la coordenada de la latitud para la sucursal.";
            }
            else if (obj.Latitud < -90 || obj.Latitud > 90)
            {
                mensaje += "\n- La latitud debe estar entre -90 y 90 grados. No olvide de cambiar la ( , ) por el ( . ) Ejemplo de una coordenada valida: -2.3442";
            }

            // Validar Longitud
            if (!obj.Longitud.HasValue)
            {
                mensaje += "\n- Es necesario la coordenada de la longitud para la sucursal.";
            }
            else if (obj.Longitud < -180 || obj.Longitud > 180)
            {
                mensaje += "\n- La longitud debe estar entre -180 y 180 grados. No olvide de cambiar la ( , ) por el ( . ) Ejemplo de una coordenada valida: 54.4545";
            }

            // Validar Ciudad
            if (string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                mensaje += "\n- Es necesario la ciudad donde esta la sucursal.";
            }
            else if (!EsNombreValido(obj.Ciudad))
            {
                mensaje += "\n- La ciudad donde queda la sucursal solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return 0;
            }

            return ObjetoSucursal.RegistrarSucursal(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la edición de una sucursal existente.
        /// </summary>
        /// <param name="obj">El objeto Sucursal a editar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Editar(Sucursal obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre de la sucursal.";
            }
            else if (!EsNombreValido(obj.Nombre))
            {
                mensaje += "\n- El nombre de la sucursal solo puede contener letras y no números.";
            }

            // Validar Direccion
            if (string.IsNullOrWhiteSpace(obj.Direccion))
            {
                mensaje += "\n- Es necesario la direccion de la sucursal.";
            }

            // Validar Latitud
            if (!obj.Latitud.HasValue)
            {
                mensaje += "\n- Es necesario la coordenada de la latitud para la sucursal.";
            }
            else if (obj.Latitud < -90 || obj.Latitud > 90)
            {
                mensaje += "\n- La latitud debe estar entre -90 y 90 grados. No olvide de cambiar la ( , ) por el ( . ) Ejemplo de una coordenada: -2.3442";
            }

            // Validar Longitud
            if (!obj.Longitud.HasValue)
            {
                mensaje += "\n- Es necesario la coordenada de la longitud para la sucursal.";
            }
            else if (obj.Longitud < -180 || obj.Longitud > 180)
            {
                mensaje += "\n- La longitud debe estar entre -180 y 180 grados. No olvide de cambiar la ( , ) por el ( . ) Ejemplo de una coordenada: 54.4545";
            }

            // Validar Ciudad
            if (string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                mensaje += "\n- Es necesario la ciudad donde esta la sucursal.";
            }
            else if (!EsNombreValido(obj.Ciudad))
            {
                mensaje += "\n- La ciudad donde queda la sucursal solo puede contener letras y no números.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoSucursal.EditarSucursal(obj, out mensaje);
        }

        /// <summary>
        /// Método que valida la eliminación de una sucursal existente.
        /// </summary>
        /// <param name="obj">El objeto Sucursal a eliminar.</param>
        /// <param name="mensaje">Mensaje de salida con el resultado de la operación.</param>
        /// <returns>Un booleano que indica si la operación fue exitosa.</returns>
        public bool Eliminar(Sucursal obj, out string mensaje)
        {
            // Validaciones de negocio
            if (obj.IdSucursal == 0)
            {
                mensaje = "Debe seleccionar un Usuario válido para eliminar.";
                return false;
            }

            return ObjetoSucursal.EliminarSucursal(obj, out mensaje);
        }

        /// <summary>
        /// Verifica si el nombre de la sucursal es válida.
        /// </summary>
        /// <param name="nombre">El nombre de la sucursal.</param>
        /// <returns>Un booleano que indica se el nombre es válida.</returns>
        private bool EsNombreValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ_\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }
    }
}
