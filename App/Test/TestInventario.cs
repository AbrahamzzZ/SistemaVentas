using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestInventario
    {
        [TestMethod]
        public void RegistrarProductoInventario()
        {
            CD_Inventario ObjetoInventario = new CD_Inventario();
            Inventario inventario = new Inventario();
            Producto producto = new Producto();
            Zona_Almacen zonaAlmacen = new Zona_Almacen();

            producto.IdProducto = 3;
            zonaAlmacen.IdZona = 1;
            inventario.Cantidad = 10;
            inventario.oProducto = producto;
            inventario.oZonaAlmacen = zonaAlmacen;
            
            Assert.IsTrue(ObjetoInventario.AgregarProductoInventario(inventario, out string mensaje) > 0);

        }

        [TestMethod]
        public void EditarProductoInventario()
        {
            CD_Inventario ObjetoInventario = new CD_Inventario();
            Inventario inventario = new Inventario();
            Producto producto = new Producto();
            Zona_Almacen zonaAlmacen = new Zona_Almacen();

            producto.IdProducto = 3;
            zonaAlmacen.IdZona = 1;
            inventario.Cantidad = 10;
            inventario.IdInventario = 1;
            inventario.oProducto = producto;
            inventario.oZonaAlmacen = zonaAlmacen;

            Assert.IsTrue(ObjetoInventario.EditarProductoInventario(inventario, out string mensaje));
        }

        [TestMethod]
        public void EliminarProductoInventario()
        {
            CD_Inventario ObjetoInventario = new CD_Inventario();
            Inventario inventario = new Inventario();
            inventario.IdInventario = 1;

            Assert.IsTrue(ObjetoInventario.EliminarProductoInventario(inventario, out string mensaje));
        }
    }
}