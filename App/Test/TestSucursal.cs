using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestSucursal
    {
        [TestMethod]
        public void RegistrarSucursal()
        {
            CD_Sucursal ObjetoSucursal = new CD_Sucursal();
            Sucursal sucursal = new Sucursal
            {
                Codigo = "1222",
                Nombre = "GUAYAQUIL_ANTENAS TV CABLE",
                Direccion = "AV.J.T.MARENGO S/N",
                Latitud = -2.148076,
                Longitud = -79.907386,
                Ciudad = "Guayaquil",
                Estado = true,
            };

            string mensaje;
            int resultado = ObjetoSucursal.RegistrarSucursal(sucursal, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Sucursal registrada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarSucursal()
        {
            CD_Sucursal ObjetoSucursal = new CD_Sucursal();
            Sucursal sucursal = new Sucursal
            {
                IdSucursal = 5,
                Codigo = "1222",
                Nombre = "GUAYAQUIL_ANTENAS TV CABLE",
                Direccion = "AV.J.T.MARENGO S/N",
                Latitud = -2.148076,
                Longitud = -79.907386,
                Ciudad = "Guayaquil",
                Estado = false,
            };

            string mensaje;
            bool resultado = ObjetoSucursal.EditarSucursal(sucursal, out mensaje);

            Assert.AreEqual("Sucursal actualizada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarSucursal()
        {
            CD_Sucursal ObjetoSucursal = new CD_Sucursal();
            Sucursal sucursal = new Sucursal
            {
                IdSucursal = 5
            };
 
            string mensaje;
            bool resultado = ObjetoSucursal.EliminarSucursal(sucursal, out mensaje);

            Assert.AreEqual("Sucursal eliminada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}