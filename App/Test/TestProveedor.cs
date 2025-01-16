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
            Proveedor proveedor = new Proveedor
            {
                Codigo = "3239",
                Nombres = "Carlos Jose",
                Apellidos = "López Murrillo",
                Cedula = "0965432104",
                Telefono = "0987654321",
                CorreoElectronico = "carlitos@gmail.com",
                Estado = true,
                FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd")
            };

            string mensaje;
            int resultado = ObjetoProveedor.RegistrarProveedor(proveedor, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Proveedor registrado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarProveedor()
        {
            CD_Proveedor ObjetoProveedor = new CD_Proveedor();
            Proveedor proveedor = new Proveedor
            {
                IdProveedor = 8,
                Codigo = "3239",
                Nombres = "Carlos Jose",
                Apellidos = "López Murrillo",
                Cedula = "0965432642",
                Telefono = "0987124321",
                CorreoElectronico = "carlitos@gmail.com",
                Estado = true
            };

            string mensaje;
            bool resultado = ObjetoProveedor.EditarProveedor(proveedor, out mensaje);

            Assert.AreEqual("Proveedor actualizado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarProveedor()
        {
            CD_Proveedor ObjetoProveedor = new CD_Proveedor();
            Proveedor proveedor = new Proveedor
            {
                IdProveedor = 8
            };

            string mensaje;
            bool resultado = ObjetoProveedor.EliminarProveedor(proveedor, out mensaje);

            Assert.AreEqual("Proveedor eliminado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}