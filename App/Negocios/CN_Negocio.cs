using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocios
{
    public class CN_Negocio
    {
        private CD_Negocio ObjetoNegocio = new CD_Negocio();

        public Negocio ListarNegocio()
        {
            return ObjetoNegocio.ObtenerInformacionNegocio();
        }
  
        public bool Editar(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;

            //Validad Nombre
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje += "\n- Es necesario el nombre del negocio.";
            }
            else if (!EsNombreValido(obj.Nombre))
            {
                mensaje += "\n- El nombre del negocio solo puede contener letras y no números.";
            }

            //Validar Telefono
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                mensaje += "\n- Es necesario el telefóno del negocio.";
            }
            else if (!EsTelefonoValido(obj.Telefono))
            {
                mensaje += "\n- El telefóno del negocio solo pueden contener exactamente 10 números y no letras.";
            }

            //Validar RUC
            if (string.IsNullOrWhiteSpace(obj.Ruc))
            {
                mensaje += "\n- Es necesario el RUC del negocio.";
            }
            else if (!EsRucValido(obj.Ruc))
            {
                mensaje += "\n- El RUC del negocio solo pueden contener exactamente 13 números y no letras.";
            }

            //Validar Direccion
            if (string.IsNullOrWhiteSpace(obj.Direccion))
            {
                mensaje += "\n- Es necesario la dirección del negocio.";
            }

            //Validar Correo Electronico
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                mensaje += "\n- Es necesario el correo electrónico del negocio.";
            }
            else if (!EsCorreoValido(obj.CorreoElectronico))
            {
                mensaje += "\n- El correo electrónico no tiene un formato válido.";
            }

            // Retornar false si hay mensajes de error
            if (!string.IsNullOrWhiteSpace(mensaje))
            {
                return false;
            }

            return ObjetoNegocio.EditarNegocio(obj, out mensaje);
        }

        public byte[] MostrarLogo(out bool obtenido)
        {
            return ObjetoNegocio.ObtenerLogoNegocio(out obtenido);
        }

        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            return ObjetoNegocio.ActualizarLogoNegocio(image, out mensaje);
        }

        private bool EsNombreValido(string nombre)
        {
            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"; // Permite letras, espacios y caracteres con tilde
            return System.Text.RegularExpressions.Regex.IsMatch(nombre, patron);
        }

        private bool EsRucValido(string ruc)
        {
            // Verificar que tenga exactamente 13 digitos (Ecuador)
            if ((ruc.Length != 11 && ruc.Length != 13) || !ruc.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }

        private bool EsTelefonoValido(string telefono)
        {
            // Verificar que tenga exactamente 10 caracteres
            if (telefono.Length != 10)
            {
                return false;
            }

            return telefono.All(char.IsDigit); // Verifica que todos los caracteres sean dígitos
        }

        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Patrón de correo válido
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }
    }
}
