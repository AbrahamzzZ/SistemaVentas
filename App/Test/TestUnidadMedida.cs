using Datos;
using Entidad;
using System.Data;


namespace Test
{
    [TestClass]
    public sealed class TestUnidadMedida
    {
        [TestMethod]
        public void RegistrarUnidadMedida()
        {
            CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();
            Unidad_Medida unidadMedida = new Unidad_Medida
            {
                Codigo = "1687",
                Descripcion = "Mililitros",
                Simbolo = "ml",
                Estado = false
            };

            string mensaje;
            int resultado = ObjetoUnidadMedida.RegistrarUnidadMedida(unidadMedida, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Unidad de medida registrada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarUnidadMedida()
        {
            CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();
            Unidad_Medida unidadMedida = new Unidad_Medida
            {
                IdUnidadMedida = 12,
                Codigo = "1687",
                Descripcion = "Mililitros",
                Simbolo = "Ml",
                Estado = true
            };

            string mensaje;
            bool resultado = ObjetoUnidadMedida.EditarUnidadMedida(unidadMedida, out mensaje);

            Assert.AreEqual("Unidad de medida actualizada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarUnidadMedida()
        {
            CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();

            Unidad_Medida unidadMedida = new Unidad_Medida
            {
                IdUnidadMedida = 12
            };

            string mensaje;
            bool resultado = ObjetoUnidadMedida.EliminarUnidadMedida(unidadMedida, out mensaje);

            Assert.AreEqual("Unidad de medida eliminada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
