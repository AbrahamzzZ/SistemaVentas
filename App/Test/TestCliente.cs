using Datos;
using Entidad;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    [TestClass]
    public sealed class TestCliente
    {
        [TestMethod]
        public void RegistrarCliente()
        {
            CD_Cliente ObjetoCliente = new CD_Cliente();
            Cliente cliente = new Cliente
            {
                Codigo = "0001",
                Nombres = "Ariel Edison",
                Apellidos = "Macias Villafuerte",
                Cedula = "1234567890",
                Telefono = "0987654321",
                CorreoElectronico = "ariel03@gmail.com",
                Estado = true
            };

            int resultado = ObjetoCliente.RegistrarCliente(cliente, out string mensaje);

            Assert.AreEqual("Cliente registrado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarCliente()
        {
            CD_Cliente ObjetoCliente = new CD_Cliente();
            Cliente cliente = new Cliente
            {
                IdCliente = 12,
                Codigo = "00009",
                Nombres = "Ariel Edison",
                Apellidos = "Macias Villafuerte",
                Cedula = "0934567890",
                Telefono = "0987654321",
                CorreoElectronico = "areil03@gmail.com",
                Estado = true
            };

            string mensaje;
            bool resultado = ObjetoCliente.EditarCliente(cliente, out mensaje);

            Assert.AreEqual("Cliente actualizado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarCliente()
        {
            CD_Cliente ObjetoCliente = new CD_Cliente();
            Cliente cliente = new Cliente
            {
                IdCliente = 12
            };

            string mensaje;
            bool resultado = ObjetoCliente.EliminarCliente(cliente, out mensaje);

            Assert.AreEqual("Cliente eliminado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
