namespace Test
{
    /// <summary>
    /// Entidades con datos que cumplen todas las validaciones de la capa de negocio.
    /// Cada prueba parte de una de ellas y modifica solo el dato que quiere probar.
    /// </summary>
    internal static class EntidadesDePrueba
    {
        public static Categoria Categoria() => new Categoria { IdCategoria = 1, Codigo = "6564", Descripcion = "Frutas y Verduras", Estado = true };

        public static Cliente Cliente() => new Cliente
        {
            IdCliente = 1,
            Codigo = "0001",
            Nombres = "Ariel Edison",
            Apellidos = "Macías Villafuerte",
            Cedula = "0934567891",
            Telefono = "0987654321",
            CorreoElectronico = "ariel03@gmail.com",
            Estado = true
        };

        public static Proveedor Proveedor() => new Proveedor
        {
            IdProveedor = 1,
            Codigo = "3239",
            Nombres = "Carlos José",
            Apellidos = "López Murillo",
            Cedula = "0965432104",
            Telefono = "0987654321",
            CorreoElectronico = "carlitos@gmail.com",
            Estado = true
        };

        public static Transportista Transportista() => new Transportista
        {
            IdTransportista = 1,
            Codigo = "4512",
            Nombres = "Luis Alberto",
            Apellidos = "Pérez Torres",
            Cedula = "0912345678",
            Telefono = "0991234567",
            CorreoElectronico = "luis.perez@gmail.com",
            Estado = true
        };

        public static byte[] Imagen() => new byte[] { 0x89, 0x50, 0x4E, 0x47 };

        public static Usuario Usuario()
        {
            string salt = Seguridad.GenerarSalt();
            return new Usuario
            {
                IdUsuario = 2,
                Codigo = "00004",
                NombreCompleto = "José María Velazco Torres",
                ClaveEncriptada = Seguridad.HashClave("clave123", salt),
                Salt = salt,
                CorreoElectronico = "jose@gmail.com",
                Estado = true
            };
        }

        public static Producto Producto() => new Producto
        {
            IdProducto = 1,
            Codigo = "1001",
            Nombre = "Manzana Roja",
            Descripcion = "Manzana importada por kilo",
            PaisOrigen = "Chile",
            Estado = true
        };

        public static Unidad_Medida UnidadMedida() => new Unidad_Medida { IdUnidadMedida = 1, Codigo = "01", Descripcion = "Kilogramo", Simbolo = "kg", Estado = true };

        public static Sucursal Sucursal() => new Sucursal
        {
            IdSucursal = 1,
            Codigo = "7247",
            Nombre = "Sucursal Centro",
            Direccion = "Av. 9 de Octubre 803 y Los Ríos",
            Latitud = -2.187746,
            Longitud = -79.894365,
            Ciudad = "Guayaquil",
            Estado = true
        };

        public static Oferta Oferta() => new Oferta
        {
            IdOferta = 1,
            Codigo = "OF01",
            NombreOferta = "Oferta de Verano",
            Descripcion = "Descuento en frutas de temporada",
            FechaInicio = DateTime.Today,
            FechaFin = DateTime.Today.AddDays(7),
            Descuento = 15,
            Estado = true
        };

        public static Inventario Inventario() => new Inventario { IdInventario = 1, Cantidad = 10 };

        public static Negocio Negocio() => new Negocio
        {
            IdNegocio = 1,
            Nombre = "Supermercado Gran Aki",
            Telefono = "0987654321",
            Ruc = "0991234567001",
            Direccion = "Av. Carlos Julio Arosemena",
            CorreoElectronico = "contacto@granaki.com"
        };

        /// <summary>
        /// Asigna un valor a una propiedad por su nombre; permite reutilizar los mismos casos
        /// de datos inválidos en las pruebas de Registrar y Editar.
        /// </summary>
        public static T Con<T>(this T entidad, string propiedad, object? valor)
        {
            var info = typeof(T).GetProperty(propiedad)
                ?? throw new ArgumentException($"{typeof(T).Name} no tiene la propiedad {propiedad}.");
            info.SetValue(entidad, valor);
            return entidad;
        }
    }
}
