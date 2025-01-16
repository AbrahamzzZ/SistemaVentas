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
            Categoria categoria = new Categoria
            {
                Codigo = "7820",
                Descripcion = "Medicamentos",
                Estado = true,
                FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
            };

            string mensaje;
            int resultado = ObjetoCategoria.RegistrarCategoria(categoria, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Categoría registrada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarCategoria()
        {
            CD_Categoria ObjetoCategoria = new CD_Categoria();
            Categoria categoria = new Categoria
            {
                IdCategoria = 21,
                Codigo = "7820",
                Descripcion = "Automoviles",
                Estado = false,
            };

            string mensaje;
            bool resultado = ObjetoCategoria.EditarCategoria(categoria, out mensaje);

            Assert.AreEqual("Categoría actualizada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarCategoria()
        {
            CD_Categoria ObjetoCategoria = new CD_Categoria();
            Categoria categoria = new Categoria
            {
                IdCategoria = 21
            };

            string mensaje;
            bool resultado = ObjetoCategoria.EliminarCategoria(categoria, out mensaje);

            Assert.AreEqual("Categoría eliminada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
