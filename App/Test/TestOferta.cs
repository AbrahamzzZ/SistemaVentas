using Datos;
using Entidad;
using System.Data;
using System.Globalization;

namespace Test
{
    [TestClass]
    public sealed class TestOferta
    {
        [TestMethod]
        public void RegistrarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta oferta = new Oferta
            {
                NombreOferta = "Super Oferta",
                Codigo = "0982",
                oProducto = new Producto { IdProducto = 7},
                Descripcion = "Extra grandes",
                FechaInicio = DateTime.ParseExact("01/12/2024 12:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                FechaFin = DateTime.ParseExact("02/02/2025 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Descuento = (decimal?)30,
                Estado = false
            };

            string mensaje;
            int resultado = ObjetoOferta.RegistrarOferta(oferta, out mensaje);

            Assert.IsTrue(resultado > 0, "El ID generado debe ser mayor a 0.");
            Assert.AreEqual("Oferta registrada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EditarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta oferta = new Oferta
            {
                IdOferta = 1,
                NombreOferta = "Super Oferta",
                Codigo = "0982",
                oProducto = new Producto { IdProducto = 7 },
                Descripcion = "Extra grandes",
                FechaInicio = DateTime.ParseExact("01/12/2024 12:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                FechaFin = DateTime.ParseExact("27/02/2025 23:59:59", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Descuento = (decimal?)30,
                Estado = true
            };

            string mensaje;
            bool resultado = ObjetoOferta.EditarOferta(oferta, out mensaje);

            Assert.AreEqual("Oferta actualizada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }

        [TestMethod]
        public void EliminarOferta()
        {
            CD_Oferta ObjetoOferta = new CD_Oferta();
            Oferta oferta = new Oferta
            {
                IdOferta = 9,
            };

            string mensaje;
            bool resultado = ObjetoOferta.EliminarOferta(oferta, out mensaje);

            Assert.AreEqual("Oferta eliminada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}