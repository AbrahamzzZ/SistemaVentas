using Datos;
using Entidad;
using System.Data;
using static System.Net.Mime.MediaTypeNames;


namespace Test
{
    [TestClass]
    public sealed class TestTransportista
    {
        [TestMethod]
        public void RegistrarTransportista()
        {
            CD_Transportista ObjetoTransportista = new CD_Transportista();
            byte[]? imagen = null;
            Transportista transportista = new Transportista
            {
                Codigo = "3412",
                Nombres = "Judai Samuel",
                Apellidos = "Kurayami Zambrano",
                Cedula = "1234567890",
                Telefono = "0987654321",
                CorreoElectronico = "judaiskz@gmail.com",
                Imagen = imagen,
                Estado = true,
                FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd")
            };

            string mensaje;
            int resultado = ObjetoTransportista.RegistrarTransportista(transportista, imagen, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Transportista registrado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarTransportista()
        {
            CD_Transportista ObjetoTransportista = new CD_Transportista();
            byte[]? imagen = null;
            Transportista transportista = new Transportista
            {
                IdTransportista = 5,
                Codigo = "3412",
                Nombres = "Judai Samuel",
                Apellidos = "Kurayami Zambrano",
                Cedula = "0934567890",
                Telefono = "0987654321",
                CorreoElectronico = "judaiskz@gmail.com",
                Imagen = imagen,
                Estado = false
            };

            string mensaje;
            bool resultado = ObjetoTransportista.EditarTransportista(transportista, imagen, out mensaje);

            Assert.AreEqual("Transportista actualizado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarTransportista()
        {
            CD_Transportista ObjetoTransportista = new CD_Transportista();
            Transportista transportista = new Transportista
            {
                IdTransportista = 5
            };

            string mensaje;
            bool resultado = ObjetoTransportista.EliminarTransportista(transportista, out mensaje);

            Assert.AreEqual("Transportista eliminado exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
