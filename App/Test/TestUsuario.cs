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
            CD_Usuario ObjetoUsuario = new CD_Usuario();
            Usuario registrarUsuario = new Usuario();
            Rol rol = new Rol();

            registrarUsuario.Codigo = "0009";
            registrarUsuario.NombreCompleto = "Roberto Perez";
            registrarUsuario.CorreoElectronico = "roberto@gmail.com";
            registrarUsuario.Clave = "0123";
            rol.IdRol = 2;
            registrarUsuario.oRol = rol;
            registrarUsuario.Estado = true;

            Assert.IsTrue(ObjetoUsuario.RegistrarUsuario(registrarUsuario, out string mensaje) > 0);
        }

        [TestMethod]
        public void EditarUsuario()
        {
            CD_Usuario ObjetoUsuario = new CD_Usuario();
            Usuario editarUsuario = new Usuario();
            Rol rol = new Rol();

            editarUsuario.IdUsuario = 8;
            editarUsuario.Codigo = "0009";
            editarUsuario.NombreCompleto = "Andrea Noely Gago";
            editarUsuario.CorreoElectronico = "noelio@gmail.com";
            editarUsuario.Clave = "343434343";
            rol.IdRol = 2;
            editarUsuario.oRol = rol;
            editarUsuario.Estado = false;

            Assert.IsTrue(ObjetoUsuario.EditarUsuario(editarUsuario, out string mensaje));
        }

        [TestMethod]
        public void EliminarUsuario()
        {
            CD_Usuario ObjetoUsuario = new CD_Usuario();
            Usuario eliminarUsuario = new Usuario();

            eliminarUsuario.IdUsuario = 8;

            Assert.IsTrue(ObjetoUsuario.EliminarUsuario(eliminarUsuario, out string mensaje));
        }
    }
}
