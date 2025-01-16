using Datos;
using Entidad;
using System.Data;

namespace Test
{
    [TestClass]
    public sealed class TestNegocio
    {
        [TestMethod]
        public void EditarNegocio()
        {
            CD_Negocio ObjetoNegocio = new CD_Negocio();
            Negocio negocio = new Negocio
            {
                IdNegocio = 1,
                Nombre = "Supermercado Paradisia",
                Telefono = "0987654321",
                Ruc = "0102030405785",
                Direccion = "Mucho Lote, 3 etapa",
                CorreoElectronico = "supermercadoParadisia@gmail.com"
            };

            string mensaje;
            bool resultado = ObjetoNegocio.EditarNegocio(negocio, out mensaje);

            Assert.AreEqual("La información del negocio fue actualizada exitosamente.", mensaje, "El mensaje de salida no es el esperado.");
            Console.WriteLine($"Mensaje devuelto: {mensaje}");
        }
    }
}
