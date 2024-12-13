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

        public List<Sucursal> ListarSucusal()
        {
            return ObjetoSucursal.MostrarSucursales();
        }

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
            /*else if (obj.Latitud >= -90 && obj.Latitud <= 90)
            {
                mensaje += "\n- La latitud debe ser un número entre -90 y 90.";
            }*/

            // Validar Longitud
            if (!obj.Longitud.HasValue)
            {
                mensaje += "\n- Es necesario la coordenada de la longitut para la sucursal.";
            }
            /*else if (obj.Longitud >= -90 && obj.Longitud <= 90)
            {
                mensaje += "\n- La longitud debe ser un número entre -180 y 180.";
            }*/

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
            /*else if (obj.Latitud >= -90 && obj.Latitud<= 90)
            {
                mensaje += "\n- La latitud debe ser un número entre -90 y 90.";
            }*/

            // Validar Longitud
            if (!obj.Longitud.HasValue)
            {
                mensaje += "\n- Es necesario la coordenada de la longitut para la sucursal.";
            }
            /*else if (obj.Longitud >= -90 && obj.Longitud <= 90)
            {
                mensaje += "\n- La longitud debe ser un número entre -180 y 180.";
            }*/

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

        private bool EsNombreValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }

        private bool IsValidCoordinateFormat(string value)
        {
            return Regex.IsMatch(value, @"^-?\d{1,3}(,\d+)?$");
        }

        private double? ParseCoordinate(string value)
        {
            if (IsValidCoordinateFormat(value))
            {
                return double.Parse(value.Replace(',', '.'));
            }
            return null;
        }
    }
}
