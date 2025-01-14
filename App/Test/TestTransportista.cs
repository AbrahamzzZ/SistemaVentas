using Datos;
using Entidad;
using System.Data;


namespace Test
{
    [TestClass]
    public sealed class TestTransportista
    {
        [TestMethod]
        public void RegistrarTransportista()
        {
            CD_Transportista ObjetoTransportista = new CD_Transportista();

            byte[] imagen = null;

            Transportista transportista = new Transportista();
            transportista.Nombres = "Judai Yuki";
            transportista.Apellidos = "Kurayami";
            transportista.Cedula = "1234567890";
            transportista.Telefono = "0987654321";
            transportista.CorreoElectronico = "judaiyami@gx.com";
            transportista.Estado = true;
            transportista.Imagen  = imagen;

            Assert.IsTrue(ObjetoTransportista.RegistrarTransportista(transportista, null, out string mensaje) > 0);
        }

        [TestMethod]
        public void EditarTransportista()
        {
            CD_Transportista ObjetoTransportista = new CD_Transportista();

            byte[] imagen = null;

            Transportista transportista = new Transportista();
            transportista.IdTransportista = 1;
            transportista.Nombres = "Judai Yuki";
            transportista.Apellidos = "Kurayami";
            transportista.Cedula = "1234567890";
            transportista.Telefono = "0987654321";
            transportista.CorreoElectronico = "judaiyami@gx.com";
            transportista.Estado = true;

            Assert.IsTrue(ObjetoTransportista.EditarTransportista(transportista, null,out string mensaje));
        }

        [TestMethod]
        public void EliminarTransportista()
        {
            CD_Transportista ObjetoTransportista = new CD_Transportista();
            Transportista transportista = new Transportista();
            transportista.IdTransportista = 1;

            Assert.IsTrue(ObjetoTransportista.EliminarTransportista(transportista, out string mensaje));
        }
    }
}
