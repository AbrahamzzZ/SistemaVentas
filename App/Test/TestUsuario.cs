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
            Usuario usuario = new Usuario
            {
                Codigo = "0709",
                NombreCompleto = "Andrea Romina Martinez Zuñiga",
                Clave = "123armz/",
                CorreoElectronico = "andreita@gmail.com",
                oRol = new Rol { IdRol = 2},
                Estado = false
            };

            string mensaje;
            int resultado = ObjetoUsuario.RegistrarUsuario(usuario, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Usuario registrado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarUsuario()
        {
            CD_Usuario ObjetoUsuario = new CD_Usuario();
            Usuario usuario = new Usuario
            {
                IdUsuario = 8,
                Codigo = "0709",
                NombreCompleto = "Andrea Romina Martinez Zuñiga",
                Clave = "123armz/",
                CorreoElectronico = "andreita@gmail.com",
                oRol = new Rol { IdRol = 2 },
                Estado = true
            };

            string mensaje;
            bool resultado = ObjetoUsuario.EditarUsuario(usuario, out mensaje);

            Assert.AreEqual("Usuario actualizado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarUsuario()
        {
            CD_Usuario ObjetoUsuario = new CD_Usuario();
            Usuario usuario = new Usuario
            {
                IdUsuario = 8
            };

            string mensaje;
            bool resultado = ObjetoUsuario.EliminarUsuario(usuario, out mensaje);

            Assert.AreEqual("Usuario eliminado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
