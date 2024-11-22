using Datos;
using Entidad;

namespace Test
{
    [TestClass]
    public sealed class TestUsuario
    {
        [TestMethod]
        public void RegistrarUsuario()
        {
            CapaDatos datos = new CapaDatos();

            string Documento = "00009";
            string NombreCompleto = "Roberto Perez";
            string CorreoElectronico = "roberto@gmail.com";
            string clave = "0123";
            string mensaje="";
            Rol rol = new Rol();
            rol.IdRol = 2;
            bool estado = true;

            Usuario usuarioNuevo = new Usuario();
            usuarioNuevo.Documento = Documento;
            usuarioNuevo.NombreCompleto = NombreCompleto;
            usuarioNuevo.CorreoElectronico= CorreoElectronico;
            usuarioNuevo.Clave = clave;
            usuarioNuevo.oRol = rol;
            usuarioNuevo.Estado = estado;

            Assert.IsTrue(datos.registrarUsuario(usuarioNuevo, out mensaje) > 0);
            
        }

        [TestMethod]
        public void EliminarUsuario()
        {
            CapaDatos datos = new CapaDatos();
            int idUsuario = 12;
            string mensaje = "";

            Usuario usuarioEliminado = new Usuario();
            usuarioEliminado.IdUsuario = idUsuario;

            Assert.IsTrue(datos.eliminarUsuario(usuarioEliminado, out mensaje));
        }

    }
}
