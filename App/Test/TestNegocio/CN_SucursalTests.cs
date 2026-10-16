using Test;

namespace Test.CapaNegocio
{
    [TestClass]
    public sealed class CN_SucursalTests
    {
        public static IEnumerable<object?[]> DatosInvalidos => new[]
        {
            new object?[] { nameof(Sucursal.Nombre), "", "Es necesario el nombre de la sucursal." },
            new object?[] { nameof(Sucursal.Direccion), "", "Es necesario la direccion de la sucursal." },
            new object?[] { nameof(Sucursal.Latitud), null, "Es necesario la coordenada de la latitud para la sucursal." },
            new object?[] { nameof(Sucursal.Latitud), -90.5, "La latitud debe estar entre -90 y 90 grados." },
            new object?[] { nameof(Sucursal.Latitud), 91.0, "La latitud debe estar entre -90 y 90 grados." },
            new object?[] { nameof(Sucursal.Longitud), null, "Es necesario la coordenada de la longitud para la sucursal." },
            new object?[] { nameof(Sucursal.Longitud), 180.1, "La longitud debe estar entre -180 y 180 grados." },
            new object?[] { nameof(Sucursal.Ciudad), "", "Es necesario la ciudad donde esta la sucursal." },
            new object?[] { nameof(Sucursal.Ciudad), "Quito2", "La ciudad donde queda la sucursal solo puede contener letras" },
        };

        [TestMethod]
        [DataRow(-90.0, -180.0)]
        [DataRow(90.0, 180.0)]
        public void Registrar_CoordenadasEnElLimite_SonValidas(double latitud, double longitud)
        {
            var datos = new Mock<ICD_Sucursal>();
            var sucursal = EntidadesDePrueba.Sucursal();
            sucursal.Latitud = latitud;
            sucursal.Longitud = longitud;
            string mensajeDatos = "Sucursal registrada exitosamente.";
            datos.Setup(d => d.RegistrarSucursal(sucursal, out mensajeDatos)).Returns(6);

            int id = new CN_Sucursal(datos.Object).Registrar(sucursal, out string mensaje);

            Assert.AreEqual(6, id);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Registrar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, object? valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Sucursal>(MockBehavior.Strict);
            var sucursal = EntidadesDePrueba.Sucursal().Con(propiedad, valor);

            int id = new CN_Sucursal(datos.Object).Registrar(sucursal, out string mensaje);

            Assert.AreEqual(0, id);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Editar_DatosValidos_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Sucursal>();
            var sucursal = EntidadesDePrueba.Sucursal();
            string mensajeDatos = "Sucursal actualizada exitosamente.";
            datos.Setup(d => d.EditarSucursal(sucursal, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Sucursal(datos.Object).Editar(sucursal, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }

        [TestMethod]
        [DynamicData(nameof(DatosInvalidos))]
        public void Editar_DatoInvalido_NoLlegaALaCapaDeDatos(string propiedad, object? valor, string mensajeEsperado)
        {
            var datos = new Mock<ICD_Sucursal>(MockBehavior.Strict);
            var sucursal = EntidadesDePrueba.Sucursal().Con(propiedad, valor);

            bool resultado = new CN_Sucursal(datos.Object).Editar(sucursal, out string mensaje);

            Assert.IsFalse(resultado);
            StringAssert.Contains(mensaje, mensajeEsperado);
        }

        [TestMethod]
        public void Eliminar_SinId_NoLlegaALaCapaDeDatos()
        {
            var datos = new Mock<ICD_Sucursal>(MockBehavior.Strict);

            bool resultado = new CN_Sucursal(datos.Object).Eliminar(new Sucursal(), out string mensaje);

            Assert.IsFalse(resultado);
            Assert.AreEqual("Debe seleccionar una Sucursal válida para eliminar.", mensaje);
        }

        [TestMethod]
        public void Eliminar_ConId_DelegaEnLaCapaDeDatos()
        {
            var datos = new Mock<ICD_Sucursal>();
            var sucursal = EntidadesDePrueba.Sucursal();
            string mensajeDatos = "Sucursal eliminada exitosamente.";
            datos.Setup(d => d.EliminarSucursal(sucursal, out mensajeDatos)).Returns(true);

            bool resultado = new CN_Sucursal(datos.Object).Eliminar(sucursal, out string mensaje);

            Assert.IsTrue(resultado);
            Assert.AreEqual(mensajeDatos, mensaje);
        }
    }
}
