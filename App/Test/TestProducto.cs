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
            CapaDatos datos = new CapaDatos();

            string Codigo = "1009";
            string Descripcion = "12 unidades";
            string Nombre = "Paracetamol";
            Categoria categoria = new Categoria();
            categoria.IdCategoria = 12;
            Unidad_Medida unidadMedida = new Unidad_Medida();
            unidadMedida.IdUnidadMedida = 5;
            string PaisOrigen = "China";
            int stock = 0;
            decimal precioCompra = 0.0m;
            decimal precioVenta = 0.0m;
            bool estado = true;
            string mensaje = "";

            Producto productoNuevo = new Producto();
            productoNuevo.Codigo = Codigo;
            productoNuevo.Descripcion = Descripcion;
            productoNuevo.Nombre = Nombre;
            productoNuevo.oCategoria = categoria;
            productoNuevo.oUnidadMedida = unidadMedida;
            productoNuevo.PaisOrigen = PaisOrigen;
            productoNuevo.Stock = stock;
            productoNuevo.PrecioCompra = precioCompra;
            productoNuevo.PrecioVenta = precioVenta;
            productoNuevo.Estado = estado;

            Assert.IsTrue(datos.registrarProducto(productoNuevo, out mensaje) > 0);
        }

        [TestMethod]
        public void EliminarProducto()
        {
            CapaDatos datos = new CapaDatos();
            int idProducto = 12;
            string mensaje = "";

            Producto productoEliminado = new Producto();
            productoEliminado.IdProducto = idProducto;

            Assert.IsTrue(datos.eliminarProducto(productoEliminado, out mensaje));
        }
    }

}
