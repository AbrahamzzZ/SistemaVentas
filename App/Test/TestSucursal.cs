using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestSucursal
    {
        [TestMethod]
        public void RegistrarSucursal()
        {
            CD_Sucursal ObjetoSucursal = new CD_Sucursal();
            Sucursal sucursal = new Sucursal();

            sucursal.Codigo = "00001";
            sucursal.Nombre = "Sucursal 1";
            sucursal.Direccion = "Av. 9 de Octubre";
            sucursal.Latitud = 2.123456;
            sucursal.Longitud = -79.123456;
            sucursal.Ciudad = "Guayaquil";
            sucursal.Estado = true;

            Assert.IsTrue(ObjetoSucursal.RegistrarSucursal(sucursal, out string mensaje) > 0);
        }

        [TestMethod]
        public void EditarSucursal()
        {
            CD_Sucursal ObjetoSucursal = new CD_Sucursal();
            Sucursal sucursal = new Sucursal();

            sucursal.IdSucursal = 1;
            sucursal.Codigo = "00001";
            sucursal.Nombre = "Sucursal 1";
            sucursal.Direccion = "Av. 9 de Octubre";
            sucursal.Latitud = 2.123456;
            sucursal.Longitud = -79.123456;
            sucursal.Ciudad = "Guayaquil";
            sucursal.Estado = true;

            Assert.IsTrue(ObjetoSucursal.EditarSucursal(sucursal, out string mensaje));
        }

        [TestMethod]
        public void EliminarSucursal()
        {
            CD_Sucursal ObjetoSucursal = new CD_Sucursal();
            Sucursal sucursal = new Sucursal();
            sucursal.IdSucursal = 1;

            Assert.IsTrue(ObjetoSucursal.EliminarSucursal(sucursal, out string mensaje));
        }
    }
}