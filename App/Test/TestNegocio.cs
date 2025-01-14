using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestNegocio
    {
        [TestMethod]
        public void ObtenerInformacionNegocio()
        {
            CD_Negocio ObjetoNegocio = new CD_Negocio();
            Assert.IsNotNull(ObjetoNegocio.ObtenerInformacionNegocio());
        }

        [TestMethod]
        public void EditarNegocio()
        {
            CD_Negocio ObjetoNegocio = new CD_Negocio();
            Negocio negocio = new Negocio();
            negocio.IdNegocio = 1;
            negocio.Nombre = "Tienda de ropa";
            negocio.Ruc = "1234567890";
            negocio.Direccion = "Av. 9 de Octubre";
            negocio.Telefono = "0987654321";
            negocio.CorreoElectronico = "camioncitosSA.ug.edu.ec";

            Assert.IsTrue(ObjetoNegocio.EditarNegocio(negocio, out string mensaje));
        }


    }

}


