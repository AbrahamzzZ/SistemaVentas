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
        private Conexion objecto = new Conexion();
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
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el documento del usuario.\n";

            }
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
        
        
        //Iventario
        public List<Inventario> mosiSQL()
        {
            return objecto.mostrarInventario();
        }
        public int resiSQL(Inventario obj, out string mensaje)
        {
            return objecto.agregarProductoInventario(obj, out mensaje);
        }
        public bool ediiSQL(Inventario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Cantidad == 0)
            {
                mensaje += "Es necesario la cantidad de productos.\n";
            }
            if (obj.UbicacionAlmacen == "")
            {
                mensaje += "Es necesario la ubicacion del almacen para el producto.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objecto.editarProductoInventario(obj, out mensaje);
            }
        }
        public bool eliiSQL(Inventario obj, out string mensaje)
        {
            return objecto.eliminarProductoInventario(obj, out mensaje);
        }

        //Reclamo
        public List<Reclamo> mosreSQL()
        {
            return objecto.mostrarReclamo();
        }
        public bool edireSQL(Reclamo obj, out string mensaje)
        {
            return objecto.editarReclamo(obj, out mensaje);

        }
        public bool elireSQL(Reclamo obj, out string mensaje)
        {
            return objecto.eliminarReclamo(obj, out mensaje);
        }
    }
}
