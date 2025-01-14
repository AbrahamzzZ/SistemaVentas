using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestCategoria
    {
        [TestMethod]
        public void RegistrarCategoria()
        {
            CD_Categoria ObjetoCategoria = new CD_Categoria();
            Categoria categoria = new Categoria();

            categoria.Codigo = "Electrodomesticos";
            categoria.Descripcion = "Electrodomesticos de todo tipo";
            categoria.Estado = true;

            Assert.IsTrue(ObjetoCategoria.RegistrarCategoria(categoria, out string mensaje) > 0);

        }

        [TestMethod]
        public void EditarCategoria()
        {
            CD_Categoria ObjetoCategoria = new CD_Categoria();
            Categoria categoria = new Categoria();

            categoria.IdCategoria = 17;
            categoria.Codigo = "Electrodomesticos";
            categoria.Descripcion = "Electrodomesticos de todo tipo";
            categoria.Estado = true;

            Assert.IsTrue(ObjetoCategoria.EditarCategoria(categoria, out string mensaje));
        }

        [TestMethod]
        public void EliminarCategoria()
        {
            CD_Categoria ObjetoCategoria = new CD_Categoria();
            Categoria categoria = new Categoria();
            categoria.IdCategoria = 17;

            Assert.IsTrue(ObjetoCategoria.EliminarCategoria(categoria, out string mensaje));
        }
    }
}
