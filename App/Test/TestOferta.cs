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
            producto.IdProducto = 3;
            registrarOferta.oProducto = producto;
            registrarOferta.Codigo = "00009";
            registrarOferta.Descripcion = "Oferta de 2x1";
            registrarOferta.FechaInicio = "2021-06-01";
            registrarOferta.FechaFin = "2021-06-30";
            registrarOferta.Estado = true;
            registradaOferta.Descuento = 0.5;

            Assert.IsTrue(ObjetoOferta.RegistrarOferta(registrarOferta, out string mensaje) > 0);
        }

        [TestMethod]
        public void EditarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta editarOferta = new Oferta();
            Producto producto = new Producto();
            producto.IdProducto = 3;
            editarOferta.oProducto = producto;
            editarOferta.IdOferta = 1;
            editarOferta.Codigo = "00009";
            editarOferta.Descripcion = "Oferta de 3x1";
            editarOferta.FechaInicio = "2021-06-01";
            editarOferta.FechaFin = "2021-06-30";
            editarOferta.Estado = true;
            editarOferta.Descuento = 0.5;

            Assert.IsTrue(ObjetoOferta.EditarOferta(editarOferta, out string mensaje));
        }

        [TestMethod]
        public void EliminarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta eliminarOferta = new Oferta();
            eliminarOferta.IdOferta = 1;

            Assert.IsTrue(ObjetoOferta.EliminarOferta(eliminarOferta, out string mensaje));
        }
    }
}