using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocios
{
    public class CN_Usuario
    {
        private CD_Usuario ObjetoUsuario = new CD_Usuario();
        public List<Usuario> Ingresar()
        {
            return ObjetoUsuario.IngresarUsuarioLogin();
        }

        public Usuario MostrarClave(string correo)
        {
            return ObjetoUsuario.RecuperarClave(correo);
        }

        public List<Usuario> ListarUsuario()
        {
            return ObjetoUsuario.MostrarUsuarios();
        }

        public int Registrar(Usuario obj, out string mensaje)
        {
            return ObjetoUsuario.RegistrarUsuario(obj, out mensaje);

        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del usuario.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrónico del usuario.\n";
            }
            if (obj.Clave == "")
            {
                mensaje += "Es necesario la clave del usuario.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return ObjetoUsuario.EditarUsuario(obj, out mensaje);
            }
        }

        public bool Eliminar(Usuario obj, out string mensaje)
        {
            return ObjetoUsuario.EliminarUsuario(obj, out mensaje);
        }  
    }
}
