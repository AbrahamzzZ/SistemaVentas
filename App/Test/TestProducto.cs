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
            Conexion datos = new Conexion();

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

            /*Assert.IsTrue(datos.registrarProducto(productoNuevo, out mensaje) > 0);*/
        }

        [TestMethod]
        public void ActualizarProducto()
        {

            Conexion datos = new Conexion();
            Producto productoActualizado = new Producto();
            productoActualizado.IdProducto = 1;
            productoActualizado.Codigo = "00001";
            productoActualizado.Nombre = "Papel Higienico";
            productoActualizado.Descripcion = "8 unidades";
            productoActualizado.oCategoria = new Categoria();
            productoActualizado.oCategoria.IdCategoria = 12;
            productoActualizado.oUnidadMedida = new Unidad_Medida();
            productoActualizado.oUnidadMedida.IdUnidadMedida = 3;
            productoActualizado.PaisOrigen = "Ecuador";
            productoActualizado.Stock = 0;
            productoActualizado.PrecioCompra = 12.00m;
            productoActualizado.PrecioVenta = 15.00m;
            productoActualizado.Estado = false;
            string mensaje = "";

            /*Assert.IsTrue(datos.editarProducto(productoActualizado, out mensaje));*/
        }

        [TestMethod]
        public void EliminarProducto()
        {
            Conexion datos = new Conexion();
            int idProducto = 15;
            string mensaje = "";

            Producto productoEliminado = new Producto();
            productoEliminado.IdProducto = idProducto;

            /*Assert.IsTrue(datos.eliminarProducto(productoEliminado, out mensaje));*/
        }
    }

}
