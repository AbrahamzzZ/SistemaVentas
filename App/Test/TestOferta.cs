using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestOferta
    {
        [TestMethod]
        public void RegistrarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta registrarOferta = new Oferta();
            Producto producto = new Producto();

            registrarOferta.NombreOferta = "Super Oferta";
            producto.IdProducto = 3;
            registrarOferta.oProducto = producto;
            registrarOferta.Codigo = "00009";
            registrarOferta.Descripcion = "Oferta de 2x1";
            registrarOferta.FechaInicio = "01/12/2024";
            registrarOferta.FechaFin = "02/02/2025";
            registrarOferta.Estado = true;
            registrarOferta.Descuento = (decimal?)0.5;

            Assert.IsTrue(ObjetoOferta.RegistrarOferta(registrarOferta, out string mensaje) > 0);
        }

        [TestMethod]
        public void EditarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta editarOferta = new Oferta();
            Producto producto = new Producto();

            editarOferta.IdOferta = 4;
            producto.IdProducto = 3;
            editarOferta.oProducto = producto;
            editarOferta.Codigo = "00009";
            editarOferta.Descripcion = "Oferta de 3x1";
            editarOferta.FechaInicio = "01/11/2024";
            editarOferta.FechaFin = "15/02/2025";
            editarOferta.Descuento = (decimal?)0.5;
            editarOferta.Estado = true;

            Assert.IsTrue(ObjetoOferta.EditarOferta(editarOferta, out string mensaje));
        }

        [TestMethod]
        public void EliminarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta eliminarOferta = new Oferta();
            eliminarOferta.IdOferta = 4;

            Assert.IsTrue(ObjetoOferta.EliminarOferta(eliminarOferta, out string mensaje));
        }
    }
}