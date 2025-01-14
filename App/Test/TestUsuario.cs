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

            string Codigo = "00009";
            string NombreCompleto = "Roberto Perez";
            string CorreoElectronico = "roberto@gmail.com";
            string clave = "0123";
            string mensaje = "";
            Rol rol = new Rol();
            rol.IdRol = 2;
            bool estado = true;

            Usuario registrarUsuario = new Usuario();
            registrarUsuario.Codigo = Codigo;
            registrarUsuario.NombreCompleto = NombreCompleto;
            registrarUsuario.CorreoElectronico = CorreoElectronico;
            registrarUsuario.Clave = clave;
            registrarUsuario.oRol = rol;
            registrarUsuario.Estado = estado;

            Assert.IsTrue(ObjetoUsuario.RegistrarUsuario(registrarUsuario, out mensaje) > 0);

        }

        [TestMethod]
        public void EditarUsuario()
        {
            CD_Usuario ObjetoUsuario = new CD_Usuario();

            Usuario editarUsuario = new Usuario();
            editarUsuario.IdUsuario = 8;
            editarUsuario.Codigo = "8984";
            editarUsuario.NombreCompleto = "Andrea Noely Gago";
            editarUsuario.CorreoElectronico = "noelio@gmail.com";
            editarUsuario.Clave = "343434343";
            editarUsuario.oRol.IdRol = 1;
            editarUsuario.Estado = false;
            string mensaje = "";

            Assert.IsTrue(ObjetoUsuario.EditarUsuario(editarUsuario, out mensaje));
        }

        [TestMethod]
        public void EliminarUsuario()
        {
            CD_Usuario ObjetoUsuario = new CD_Usuario();

            int idUsuario = 8;
            string mensaje = "";

            Usuario eliminarUsuario = new Usuario();
            eliminarUsuario.IdUsuario = idUsuario;

            Assert.IsTrue(ObjetoUsuario.EliminarUsuario(eliminarUsuario, out mensaje));
        }
    }
}
