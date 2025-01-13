using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestCliente
    {
        [TestMethod]
        public void RegistrarCliente()
        {
            CD_Cliente ObjetoCliente = new CD_Cliente();
            Cliente registrarCliente = new Cliente();
            registrarCliente.Codigo = "00009";
            registrarCliente.Nombres = "Roberto";
            registrarCliente.Apellidos = "Perez";
            registrarCliente.Cedula = "1234567890";
            registrarCliente.Telefono = "0987654321";
            registrarCliente.CorreoElectronico = "pablopincay@ug.edu.ec";
            registrarCliente.Estado = true;

            Assert.IsTrue(ObjetoCliente.RegistrarCliente(registrarCliente, out string mensaje) > 0);
            

        }

        [TestMethod]
        public void EditarCliente()
        {
            CD_Cliente ObjetoCliente = new CD_Cliente();
            Cliente editarCliente = new Cliente();
            editarCliente.IdCliente = 1;
            editarCliente.Codigo = "00009";
            editarCliente.Nombres = "Roberto";
            editarCliente.Apellidos = "Perez";
            editarCliente.Cedula = "1234567890";
            editarCliente.Telefono = "0987654321";
            editarCliente.CorreoElectronico = "pabloagurto@ug.edu.ec";
            editarCliente.Estado = true;

            Assert.IsTrue(ObjetoCliente.EditarCliente(editarCliente, out string mensaje));
        }

        [TestMethod]
        public void EliminarCliente()
        {
            CD_Cliente ObjetoCliente = new CD_Cliente();
            Cliente eliminarCliente = new Cliente();
            eliminarCliente.IdCliente = 1;

            Assert.IsTrue(ObjetoCliente.EliminarCliente(eliminarCliente, out string mensaje));
        }
    }
}
