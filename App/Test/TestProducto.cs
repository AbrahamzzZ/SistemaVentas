using Datos;
using Entidad;

namespace Test
{
    [TestClass]
    public sealed class TestProducto
    {
        [TestMethod]
        public void RegistrarProducto()
        {
            CD_Producto objetoProducto = new CD_Producto();
            Producto registrarProducto = new Producto();
            Categoria categoria = new Categoria();
            Unidad_Medida unidadMedida = new Unidad_Medida();

            registrarProducto.Codigo = "4243";
            registrarProducto.Nombre = "Paracetamol";
            registrarProducto.Descripcion = "12 unidades";
            categoria.IdCategoria = 6;
            registrarProducto.oCategoria = categoria;
            unidadMedida.IdUnidadMedida = 3;
            registrarProducto.oUnidadMedida = unidadMedida;
            registrarProducto.PaisOrigen = "China";
            registrarProducto.Stock = 0;
            registrarProducto.PrecioCompra = 0.0m;
            registrarProducto.PrecioVenta = 0.0m;
            registrarProducto.Estado = true;

            Assert.IsTrue(objetoProducto.RegistrarProducto(registrarProducto, out string mensaje) > 0);
        }

        [TestMethod]
        public void ActualizarProducto()
        {

            CD_Producto objetoProducto = new CD_Producto();
            Producto editarProducto = new Producto();
            Categoria categoria = new Categoria();
            Unidad_Medida unidadMedida = new Unidad_Medida();

            editarProducto.IdProducto = 15;
            editarProducto.Codigo = "00001";
            editarProducto.Nombre = "Papel Higienico";
            editarProducto.Descripcion = "8 unidades";
            categoria.IdCategoria = 6;
            editarProducto.oCategoria = categoria;
            unidadMedida.IdUnidadMedida = 3;
            editarProducto.oUnidadMedida = unidadMedida;
            editarProducto.PaisOrigen = "Ecuador";
            editarProducto.Stock = 0;
            editarProducto.PrecioCompra = 0.00m;
            editarProducto.PrecioVenta = 0.00m;
            editarProducto.Estado = false;

            Assert.IsTrue(objetoProducto.EditarProducto(editarProducto, out string mensaje));
        }

        [TestMethod]
        public void EliminarProducto()
        {
            CD_Producto ObjetoProducto = new CD_Producto();
            Producto eliminarProducto = new Producto();

            eliminarProducto.IdProducto = 15;

            Assert.IsTrue(ObjetoProducto.EliminarProducto(eliminarProducto, out string mensaje));
        }
    }
}
