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
            Unidad_Medida unidadMedida = new Unidad_Medida();

            unidadMedida.Codigo = "7687";
            unidadMedida.Descripcion = "Mililitros";
            unidadMedida.Simbolo = "ml";
            unidadMedida.Estado = true;

            Assert.IsTrue(ObjetoUnidadMedida.RegistrarUnidadMedida(unidadMedida, out string mensaje) > 0);
        }

        [TestMethod]
        public void EditarUnidadMedida()
        {
            CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();
            Unidad_Medida unidadMedida = new Unidad_Medida();

            unidadMedida.IdUnidadMedida = 1;
            unidadMedida.Codigo = "7687";
            unidadMedida.Descripcion = "Mililitros";
            unidadMedida.Simbolo = "Ml";
            unidadMedida.Estado = true;

            Assert.IsTrue(ObjetoUnidadMedida.EditarUnidadMedida(unidadMedida, out string mensaje));
        }

        [TestMethod]
        public void EliminarUnidadMedida()
        {
            CD_Unidad_Medida ObjetoUnidadMedida = new CD_Unidad_Medida();

            Unidad_Medida unidadMedida = new Unidad_Medida();
            unidadMedida.IdUnidadMedida = 6;

            Assert.IsTrue(ObjetoUnidadMedida.EliminarUnidadMedida(unidadMedida, out string mensaje));
        }
    }
}
