using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestProveedor
    {
        [TestMethod]
        public void RegistrarProveedor()
        {
            CD_Proveedor ObjetoProveedor = new CD_Proveedor();
            Proveedor registrarProveedor = new Proveedor();

            registrarProveedor.Codigo = "00009";
            registrarProveedor.Nombres = "Farfan";
            registrarProveedor.Apellidos = "Perez";
            registrarProveedor.Cedula = "1234567890";
            registrarProveedor.Telefono = "0987654321";
            registrarProveedor.CorreoElectronico = "farfanagurto_perez@ug.edu.ec";
            registrarProveedor.Estado = true;
            registrarProveedor.FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd");

            Assert.IsTrue(ObjetoProveedor.RegistrarProveedor(registrarProveedor, out string mensaje) > 0);   
        }

        [TestMethod]
        public void EditarProveedor()
        {
            CD_Proveedor ObjetoProveedor = new CD_Proveedor();
            Proveedor editarProveedor = new Proveedor();

            editarProveedor.IdProveedor = 1;
            editarProveedor.Codigo = "00009";
            editarProveedor.Nombres = "Farfan";
            editarProveedor.Apellidos = "Perez";
            editarProveedor.Cedula = "1234567890";
            editarProveedor.Telefono = "0987654321";
            editarProveedor.CorreoElectronico = "farfanagurto_perez@ug.edu.ec";
            editarProveedor.Estado = true;

            Assert.IsTrue(ObjetoProveedor.EditarProveedor(editarProveedor, out string mensaje));

        }

        [TestMethod]
        public void EliminarProveedor()
        {
            CD_Proveedor ObjetoProveedor = new CD_Proveedor();
            Proveedor eliminarProveedor = new Proveedor();
            eliminarProveedor.IdProveedor = 1;

            Assert.IsTrue(ObjetoProveedor.EliminarProveedor(eliminarProveedor, out string mensaje));
        }
    }
}