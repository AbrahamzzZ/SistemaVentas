using Datos;
using Entidad;

namespace Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Registrarusuario()
        {
            CapaDatos datos = new CapaDatos();

            string Documento = "00008";
            string NombreCompleto = "Roberto Perez";
            string CorreoElectronico = "roberto@gmail.com";
            string clave = "0";
            string mensaje="";
            Rol rol = new Rol();
            rol.IdRol = 1;
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
        public void RegistrarProducto()
        {

        }
    }
}
