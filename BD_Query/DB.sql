CREATE DATABASE Sistema_Ventas;

go
	ALTER DATABASE [Sistema_Ventas]
ADD
	FILE (
		NAME = Sistema_Ventas_File,
		FILENAME = 'C:\Sistema_Ventas.ndf',
		SIZE = 10MB,
		MAXSIZE = 500MB,
		FILEGROWTH = 1MB
	) USE Sistema_Ventas
go
	/*TABLAS*/
	CREATE TABLE ROL (
		ID_ROL int primary key identity,
		DESCRIPCION nvarchar(50),
		FECHA_CREACION datetime default getdate()
	);

go
	CREATE TABLE PERMISO (
		ID_PERMISO int primary key identity,
		ID_ROL int references ROL(ID_ROL),
		NOMBRE_MENU varchar(100),
		FECHA_CREACION datetime default getdate()
	);

go
	CREATE TABLE PROVEEDOR (
		ID_PROVEEDOR int primary key identity,
		DOCUMENTO varchar(30),
		NOMBRES varchar(30),
		APELLIDOS varchar(30),
		CEDULA varchar(10),
		TELEFONO varchar(10),
		CORREO_ELECTRONICO nvarchar(50),
		ESTADO bit,
		FECHA_REGISTRO datetime default getdate()
	);

go
	CREATE TABLE TRANSPORTISTA(
		ID_TRANSPORTISTA int primary key identity,
		DOCUMENTO varchar(30),
		NOMBRES varchar(30),
		APELLIDOS varchar(30),
		CEDULA varchar(10),
		TELEFONO varchar(10),
		CORREO_ELECTRONICO nvarchar(50),
		IMAGEN varbinary(max) NUll,
		ESTADO bit,
		FECHA_REGISTRO datetime default getdate()
	);

go
	CREATE TABLE CLIENTE (
		ID_CLIENTE int primary key identity,
		DOCUMENTO varchar(30),
		NOMBRES varchar(30),
		APELLIDOS varchar(30),
		CEDULA varchar(10),
		TELEFONO varchar(10),
		CORREO_ELECTRONICO nvarchar(50),
		ESTADO bit,
		FECHA_REGISTRO datetime default getdate()
	);

go
	CREATE TABLE USUARIO (
		ID_USUARIO int primary key identity,
		DOCUMENTO varchar(30),
		NOMBRE_COMPLETO varchar(50),
		CORREO_ELECTRONICO nvarchar(50),
		CLAVE varchar(30),
		ID_ROL int references ROL(ID_ROL),
		ESTADO bit,
		FECHA_CREACION datetime default getdate()
	);

go
	CREATE TABLE CATEGORIA(
		ID_CATEGORIA int primary key identity,
		DESCRIPCION nvarchar(50),
		ESTADO bit,
		FECHA_CREACION datetime default getdate()
	);

go
	CREATE TABLE UNIDAD_MEDIDA (
		ID_UNIDAD_MEDIDA int primary key identity,
		DESCRIPCION nvarchar(50) NOT NULL,
		SIMBOLO nvarchar(10) NOT NULL,
		ESTADO bit,
		FECHA_CREACION datetime default getdate()
	);

go
	CREATE TABLE PRODUCTO(
		ID_PRODUCTO int primary key identity,
		CODIGO varchar(30),
		DESCRIPCION nvarchar(50),
		NOMBRE_PRODUCTO nvarchar(30),
		ID_CATEGORIA int references CATEGORIA(ID_CATEGORIA),
		ID_UNIDAD_MEDIDA int references UNIDAD_MEDIDA(ID_UNIDAD_MEDIDA),
		PAIS_ORIGEN varchar(30),
		STOCK int not null default 0,
		PRECIO_COMPRA decimal (10, 2) default 0,
		PRECIO_VENTA decimal (10, 2) default 0,
		ESTADO bit,
	);

go
	CREATE TABLE INVENTARIO (
		ID_INVENTARIO int identity primary key not null,
		ID_PRODUCTO int references PRODUCTO (ID_PRODUCTO),
		CODIGO_PRODUCTO varchar(30),
		NOMBRE_PRODUCTO nvarchar(30),
		CANTIDAD int not null,
		UBICACION_ALMACEN varchar(30),
		ESTADO bit,
		FECHA_INGRESO datetime default getdate()
	);

go
	CREATE TABLE COMPRA (
		ID_COMPRA int identity primary key not null,
		ID_USUARIO int references USUARIO(ID_USUARIO),
		ID_PROVEEDOR int references PROVEEDOR(ID_PROVEEDOR),
		ID_TRANSPORTISTA int references TRANSPORTISTA(ID_TRANSPORTISTA),
		TIPO_DOCUMENTO varchar(50),
		NUMERO_DOCUMENTO varchar(50),
		MONTO_TOTAL decimal(10, 2),
		FECHA_COMPRA datetime default getdate()
	);

go
	CREATE TABLE DETALLE_COMPRA (
		ID_DETALLE_COMPRA int primary key identity,
		ID_COMPRA int references COMPRA (ID_COMPRA),
		ID_PRODUCTO int references PRODUCTO (ID_PRODUCTO),
		PRECIO_COMPRA decimal (10, 2) default 0,
		PRECIO_VENTA decimal (10, 2) default 0,
		CANTIDAD int,
		MONTO_TOTAL decimal (10, 2),
		FECHA_REGISTRO datetime default getdate()
	);

go
	CREATE TABLE VENTA (
		ID_VENTA int primary key identity,
		ID_USUARIO int references USUARIO (ID_USUARIO),
		TIPO_DOCUMENTO varchar(50),
		NUMERO_DOCUMENTO varchar(50),
		DOCUMENTO_CLIENTE varchar(30),
		NOMBRE_CLIENTE varchar(30),
		MONTO_PAGO decimal (10, 2),
		MONTO_CAMBIO decimal (10, 2),
		MONTO_TOTAL decimal (10, 2),
		DESCUENTO decimal (10, 2),
		FECHA_VENTA datetime default getdate()
	);

go
	CREATE TABLE DETALLE_VENTA (
		ID_DETALLE_VENTA int primary key identity,
		ID_VENTA int references VENTA (ID_VENTA),
		ID_PRODUCTO int references PRODUCTO (ID_PRODUCTO),
		PRECIO_VENTA decimal (10, 2),
		CANTIDAD_PRODUCTO int,
		SUBTOTAL decimal (10, 2),
		DESCUENTO decimal (10, 2),
		FECHA_REGISTRO datetime default getdate()
	);

go
	CREATE TABLE RECLAMO(
		ID_RECLAMO int primary key identity,
		ID_CLIENTE int references CLIENTE(ID_CLIENTE),
		NOMBRE_CLIENTE nvarchar(50),
		CORREO_ELECTRONICO_CLIENTE nvarchar(50),
		DESCRIPCION nvarchar(500),
		ESTADO bit,
		FECHA_REGISTRO datetime default getdate()
	);

go
	CREATE TABLE NEGOCIO (
		ID_NEGOCIO int primary key,
		NOMBRE varchar (60),
		TELEFONO varchar (10),
		RUC varchar(10),
		DIRECCION varchar(60),
		CORREO_ELECTRONICO varchar(40),
		LOGO varbinary(max) NUll
	);

go
	CREATE TABLE OFERTA (
		ID_OFERTA INT PRIMARY KEY IDENTITY,
		ID_PRODUCTO int references PRODUCTO(ID_PRODUCTO),
		NOMBRE_OFERTA VARCHAR(50),
		DESCRIPCION varchar(250),
		FECHA_INICIO varchar(20),
		FECHA_FIN varchar(20),
		DESCUENTO decimal(4) default 0,
		ESTADO bit,
		FECHA_CREACION datetime default getdate()
	);

go
	CREATE TABLE SUCURSAL(
		ID_SUCURSAL int primary key identity,
		NOMBRE_SUCURSAL varchar(30),
		DIRECCION_SUCURSAL varchar(250),
		LATITUD_SUCURSAL double precision,
		LONGITUD_SUCURSAL double precision,
		CIUDAD_SUCURSAL varchar(30),
		ESTADO bit
	);

go
	/*PROCEDIMIENTOS ALMACENADOS*/
go
	CREATE PROC PA_REGISTRAR_USUARIO(
		@Documento varchar(30),
		@Nombre_Completo varchar(50),
		@Correo_Electronico varchar(50),
		@Clave varchar(30),
		@Id_Rol int,
		@Estado bit,
		@Id_Usuario_Resultado int output,
		@Mensaje varchar(500) output
	) as begin
set
	@Id_Usuario_Resultado = 0
set
	@Mensaje = '' if not exists(
		SELECT
			*
		FROM
			USUARIO
		WHERE
			DOCUMENTO = @Documento
	) begin
INSERT INTO
	USUARIO (
		DOCUMENTO,
		NOMBRE_COMPLETO,
		CORREO_ELECTRONICO,
		CLAVE,
		ID_ROL,
		ESTADO
	)
VALUES
	(
		@Documento,
		@Nombre_Completo,
		@Correo_Electronico,
		@Clave,
		@Id_Rol,
		@Estado
	)
set
	@Id_Usuario_Resultado = SCOPE_IDENTITY()
end
else
set
	@Mensaje = 'No se puede repetir el documento para m�s de un usuario.'
end
go
	CREATE PROC PA_EDITAR_USUARIO(
		@Id_Usuario int,
		@Documento varchar(30),
		@Nombre_Completo varchar(50),
		@Correo_Electronico varchar(50),
		@Clave varchar(30),
		@Id_Rol int,
		@Estado bit,
		@Respuesta bit output,
		@Mensaje varchar(500) output
	) as begin
set
	@Respuesta = 0
set
	@Mensaje = '' if not exists(
		SELECT
			*
		FROM
			USUARIO
		WHERE
			DOCUMENTO = @Documento
			and ID_USUARIO != @Id_Usuario
	) begin
UPDATE
	USUARIO
SET
	DOCUMENTO = @Documento,
	NOMBRE_COMPLETO = @Nombre_Completo,
	CORREO_ELECTRONICO = @Correo_Electronico,
	CLAVE = @Clave,
	ID_ROL = @Id_Rol,
	ESTADO = @Estado
WHERE
	ID_USUARIO = @Id_Usuario
set
	@Respuesta = 1
end
else
set
	@Mensaje = 'No se puede repetir el documento para m�s de un usuario'
end
go
	CREATE PROC PA_ELIMINAR_USUARIO(
		@Id_Usuario int,
		@Respuesta bit output,
		@Mensaje varchar(500) output
	) as begin
set
	@Respuesta = 0
set
	@Mensaje = '' declare @paso_Reglas bit = 1 if exists (
		SELECT
			*
		FROM
			COMPRA c
			inner join USUARIO u on u.ID_USUARIO = c.ID_USUARIO
		WHERE
			u.ID_USUARIO = @Id_Usuario
	) begin
set
	@paso_Reglas = 0
set
	@Respuesta = 0
set
	@Mensaje = @Mensaje + 'No se puede eliminar este usuario porque se encuentra relacionado a una compra.\'
	end
	if exists (SELECT * FROM VENTA v inner join USUARIO u on u.ID_USUARIO = v.ID_USUARIO WHERE u.ID_USUARIO = @Id_Usuario)
	begin
		set @paso_Reglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje+' No se puede eliminar este usuario porque se encuentra relacionado a una venta.\ '
	end
	if(@paso_Reglas = 1)
	begin
		DELETE FROM USUARIO WHERE ID_USUARIO = @Id_Usuario
		set @Respuesta = 1
	end
end
go

CREATE PROC PA_REGISTRAR_CATEGORIA(
@Descripcion varchar (50),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 0
	if not exists (SELECT * FROM CATEGORIA WHERE DESCRIPCION = @Descripcion)
	begin
		INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (@Descripcion, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = ' No se puede repetir la descripci � n de una categor � a '
end
go

CREATE PROC PA_EDITAR_CATEGORIA(
@Id_Categoria int,
@Descripcion varchar (50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 1
	if not exists (SELECT * FROM CATEGORIA WHERE DESCRIPCION = @Descripcion and ID_CATEGORIA != @Id_Categoria )
		update CATEGORIA SET DESCRIPCION = @Descripcion, 
		ESTADO = @Estado
		WHERE ID_CATEGORIA = @Id_Categoria 
	else
		begin
			set @Resultado = 0
			set @Mensaje = ' No se puede repetir la descripci � n de una categor � a '
		end
end
go

CREATE PROC PA_ELIMINAR_CATEGORIA(
@Id_Categoria int,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 1
	if not exists (SELECT * FROM CATEGORIA c inner join PRODUCTO p  on p.ID_CATEGORIA = c.ID_CATEGORIA WHERE c.ID_CATEGORIA = @Id_Categoria)
		begin
			DELETE TOP(1) CATEGORIA WHERE ID_CATEGORIA = @Id_Categoria
		end
	else
		begin
			set @Resultado = 0
			set @Mensaje = ' La categor � a ya se encuentra relacionada a un producto.'
		end
end
go

CREATE PROC PA_REGISTRAR_PRODUCTO(
@Codigo varchar (30),
@Nombre_Producto varchar (30),
@Descripcion varchar(50),
@Id_Categoria int,
@Id_Unidad_Medida int,
@Pais_Origen varchar(30),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 0
	if not exists (SELECT * FROM PRODUCTO WHERE CODIGO = @Codigo)
	begin
		INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES 
		(@Codigo, @Nombre_Producto, @Descripcion, @Id_Categoria, @Id_Unidad_Medida, @Pais_Origen, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje =' Ya existe un producto con el mismo c � digo '
end
go

CREATE PROC PA_EDITAR_PRODUCTO(
@Id_Producto int,
@Codigo varchar(30),
@Nombre_Producto varchar(30),
@Descripcion varchar (50),
@Id_Categoria int,
@Id_Unidad_Medida int,
@Pais_Origen varchar(30),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin 
	set @Resultado = 1
	if not exists (SELECT * FROM PRODUCTO WHERE CODIGO = @Codigo and ID_PRODUCTO != @Id_Producto)
		update PRODUCTO set
		CODIGO = @Codigo,
		NOMBRE_PRODUCTO = @Nombre_Producto,
		DESCRIPCION = @Descripcion,
		ID_CATEGORIA = @Id_Categoria,
		ID_UNIDAD_MEDIDA = @Id_Unidad_Medida,
		PAIS_ORIGEN = @Pais_Origen,
		ESTADO = @Estado
		Where ID_PRODUCTO = @Id_Producto
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' No se puede repetir la descripci � n del mismo c � digo '
	end
end
go

CREATE PROC PA_ELIMINAR_PRODUCTO(
@Id_Producto int,
@Respuesta bit output,
@Mensaje varchar (500) output
)
as
begin 
	set @Respuesta = 0
	set @Mensaje = ' '
	declare @Paso_Reglas bit = 1
	if exists (SELECT * FROM DETALLE_COMPRA dc inner join PRODUCTO p ON p.ID_PRODUCTO = dc.ID_PRODUCTO Where p.ID_PRODUCTO = @Id_Producto)
	begin
		set @Paso_Reglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + ' No se puede eliminar porque se encuentra relacionado a una Compra \ n '
	end
	if exists (SELECT * FROM DETALLE_VENTA dv inner join PRODUCTO p ON p.ID_PRODUCTO = dv.ID_PRODUCTO Where p.ID_PRODUCTO = @Id_Producto)
	begin
		set @Paso_Reglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + ' No se puede eliminar porque se encuentra relacionado a una Venta \ n '
	end
	if exists (SELECT * FROM INVENTARIO i inner join PRODUCTO p ON p.ID_PRODUCTO = i.ID_PRODUCTO Where p.ID_PRODUCTO = @Id_Producto)
	begin
		set @Paso_Reglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + ' No se puede eliminar porque se encuentra relacionado en el Inventario \ n '
	end
	if exists (SELECT * FROM OFERTA o inner join PRODUCTO p ON p.ID_PRODUCTO = o.ID_PRODUCTO Where p.ID_PRODUCTO = @Id_Producto)
	begin
		set @Paso_Reglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + ' No se puede eliminar porque se encuentra relacionado a un Oferta \ n '
	end
	if(@Paso_Reglas = 1)
	begin 
		DELETE FROM PRODUCTO Where ID_PRODUCTO = @Id_Producto
		set @Respuesta = 1
	end
end
go

CREATE PROC PA_REGISTRAR_UNIDAD_MEDIDA(
@Descripcion varchar (50),
@Simbolo nvarchar (10),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 0
	if not exists (SELECT * FROM UNIDAD_MEDIDA WHERE DESCRIPCION = @Descripcion)
	begin
		INSERT INTO UNIDAD_MEDIDA(DESCRIPCION, SIMBOLO ,ESTADO) VALUES (@Descripcion, @Simbolo, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = ' No se puede repetir la descripci � n de una unidad de medida '
end
go

CREATE PROC PA_EDITAR_UNIDAD_MEDIDA(
@Id_Unidad_Medida int,
@Descripcion varchar (50),
@Simbolo nvarchar (10),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 1
	if not exists (SELECT * FROM UNIDAD_MEDIDA WHERE DESCRIPCION = @Descripcion and ID_UNIDAD_MEDIDA != @Id_Unidad_Medida)
		update UNIDAD_MEDIDA SET DESCRIPCION = @Descripcion, 
		ESTADO = @Estado
		WHERE ID_UNIDAD_MEDIDA = @Id_Unidad_Medida
	else
		begin
			set @Resultado = 0
			set @Mensaje = ' No se puede repetir la descripci � n de una unidad de medida '
		end
end
go

CREATE PROC PA_ELIMINAR_UNIDAD_MEDIDA(
@Id_Unidad_Medida int,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 1
	if not exists (SELECT * FROM UNIDAD_MEDIDA u inner join PRODUCTO p on p.ID_UNIDAD_MEDIDA = u.ID_UNIDAD_MEDIDA WHERE u.ID_UNIDAD_MEDIDA = @Id_Unidad_Medida)
		begin
			DELETE TOP(1) UNIDAD_MEDIDA WHERE ID_UNIDAD_MEDIDA = @Id_Unidad_Medida
		end
	else
		begin
			set @Resultado = 0
			set @Mensaje = ' La unidad de medida ya se encuentra relacionada a un producto.'
		end
end
go

CREATE PROCEDURE PA_REGISTRAR_PRODUCTO_INVENTARIO(
@Id_Producto int,
@Codigo_Producto varchar(30),
@Nombre_Producto varchar(30),
@Cantidad int,
@Ubicacion_Almacen varchar(30),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin
	declare @Cantidad_Comprada int;
	SELECT @Cantidad_Comprada = SUM(Cantidad) FROM DETALLE_COMPRA WHERE ID_PRODUCTO = @Id_Producto;
    if NOT EXISTS (SELECT * FROM INVENTARIO WHERE ID_PRODUCTO = @ID_PRODUCTO)
    begin
		if @cantidad <= @Cantidad_Comprada
		begin
			INSERT INTO INVENTARIO (ID_PRODUCTO, CODIGO_PRODUCTO, NOMBRE_PRODUCTO, CANTIDAD, UBICACION_ALMACEN, ESTADO)
			VALUES (@ID_PRODUCTO, @CODIGO_PRODUCTO, @NOMBRE_PRODUCTO, @CANTIDAD, @UBICACION_ALMACEN, @ESTADO)
			set @Resultado = SCOPE_IDENTITY()
			set @Mensaje = ' Producto registrado en el inventario exitosamente.'
		end
		else
		begin
			set @Mensaje = ' La cantidad ingresada de ese producto excede la cantidad comprada.';
		end
    end
    else
    begin
        set @Mensaje = ' El producto ya existe en el inventario.'
    end
end
go

CREATE PROCEDURE PA_EDITAR_PRODUCTO_INVENTARIO(
@Id_Inventario int,
@Id_Producto int,
@Codigo_Producto varchar(30),
@Nombre_Producto varchar(30),
@Cantidad int,
@Ubicacion_Almacen varchar(30),
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
    if NOT EXISTS (SELECT * FROM INVENTARIO WHERE CODIGO_PRODUCTO = @Codigo_Producto and ID_INVENTARIO != @Id_Inventario)
    begin
        update INVENTARIO set
		Id_Producto = @Id_Producto,
		CODIGO_PRODUCTO = @Codigo_Producto,
		NOMBRE_PRODUCTO = @Nombre_Producto,
		CANTIDAD = @Cantidad,
		UBICACION_ALMACEN = @Ubicacion_Almacen,
		ESTADO = @Estado
		Where ID_INVENTARIO = @Id_Inventario
    end
    else
    begin
        set @Resultado = 0
        set @Mensaje = ' No se puede repetir la descripci � n del mismo c � digo.'
    end
end
go

CREATE PROCEDURE PA_ELIMINAR_PRODUCTO_INVENTARIO(
@Id_Inventario int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	DELETE FROM INVENTARIO WHERE ID_INVENTARIO = @Id_Inventario;
    if @@ROWCOUNT > 0
    begin
        DELETE TOP(1) FROM INVENTARIO WHERE ID_INVENTARIO = @Id_Inventario
    end
    else
    begin
        set @Resultado = 0
        set @Mensaje = ' El producto se encuentra relacionado en el inventario '
    end
end
go

CREATE PROC PA_REGISTRAR_CLIENTE(
@Documento varchar(30),
@Nombre_Cliente varchar(30),
@Apellido_Cliente varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	set @Resultado=0
	declare @ID_Persona int
	if not exists (SELECT * FROM CLIENTE WHERE DOCUMENTO = @Documento)
	begin
		INSERT INTO CLIENTE(DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) 
		VALUES (@Documento, @Nombre_Cliente, @Apellido_Cliente, @Cedula, @Telefono, @Correo_Electronico, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Resultado = ' El n � mero de documento ya existe.'
end
go

CREATE PROC PA_EDITAR_CLIENTE(
@Id_Cliente int,
@Documento varchar(30),
@Nombre_Cliente varchar(30),
@Apellido_Cliente varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	set @Resultado = 1
	declare @ID_Persona int
	if not exists (SELECT * FROM CLIENTE WHERE DOCUMENTO = @Documento and ID_CLIENTE != @Id_Cliente)
	begin
		update CLIENTE set
		DOCUMENTO = @Documento,
		NOMBRES = @Nombre_Cliente,
		APELLIDOS = @Apellido_Cliente,
		CEDULA = @Cedula,
		TELEFONO = @Telefono,
		CORREO_ELECTRONICO = @Correo_Electronico,
		ESTADO = @Estado
		where ID_CLIENTE = @Id_Cliente
	end
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' El n � mero de documento ya existe.'
	end
end
go

CREATE PROC PA_REGISTRAR_PROVEEDOR(
@Documento varchar(30),
@Nombres_Proveedor varchar(30),
@Apellidos_Proveedor varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 0
	declare @Id_Persona int
	if not exists (SELECT * FROM PROVEEDOR WHERE DOCUMENTO = @Documento)
	begin
		INSERT INTO PROVEEDOR (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES
		(@Documento, @Nombres_Proveedor, @Apellidos_Proveedor, @Cedula, @Telefono, @Correo_Electronico, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = ' El n � mero de documento ya existe.'
end
go

CREATE PROC PA_EDITAR_PROVEEDOR(
@Id_Proveedor int,
@Documento varchar(30),
@Nombres_Proveedor varchar(30),
@Apellidos_Proveedor varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	declare @ID_Persona int
	if not exists (SELECT * FROM PROVEEDOR WHERE DOCUMENTO = @Documento and ID_PROVEEDOR != @Id_Proveedor)
	begin
		update PROVEEDOR set
		DOCUMENTO = @Documento,
		NOMBRES = @Nombres_Proveedor,
		APELLIDOS = @Apellidos_Proveedor,
		CEDULA = @Cedula,
		TELEFONO = @Telefono,
		CORREO_ELECTRONICO = @Correo_Electronico,
		ESTADO = @Estado
		where ID_PROVEEDOR = @Id_Proveedor
	end
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' El n � mero de documento ya existe.'
	end
end
go

CREATE PROC PA_ELIMINAR_PROVEEDOR(
@Id_Proveedor int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (SELECT * FROM PROVEEDOR p inner join COMPRA c on p.ID_PROVEEDOR = c.ID_PROVEEDOR where p.ID_PROVEEDOR = @Id_Proveedor)
	begin
		DELETE TOP(1) FROM PROVEEDOR WHERE ID_PROVEEDOR = @Id_Proveedor
	end
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' El proveedor se encuentra relacionado a una compra.'
	end
end
go

CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
[Id_Producto] int null,
[Precio_Compra] decimal(10,2) null,
[Precio_Venta] decimal (10,2) null,
[Cantidad] int null,
[Monto_Total] decimal (10,2) null
)
go

CREATE PROCEDURE PA_REGISTRAR_COMPRA(
@Id_Usuario int,
@Id_Proveedor int,
@Id_Transportista int,
@Tipo_Documento varchar(500),
@Numero_Documento varchar(500),
@Monto_Total decimal(10,2),
@Detalle_Compra [EDetalle_Compra] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	begin try
		declare @Id_Compra int = 0
		set @Resultado = 1
		set @Mensaje = ''
		begin transaction registro
		INSERT INTO COMPRA (ID_USUARIO, ID_PROVEEDOR, ID_TRANSPORTISTA, TIPO_DOCUMENTO, NUMERO_DOCUMENTO, MONTO_TOTAL) VALUES
		( @Id_Usuario, @Id_Proveedor, @Id_Transportista, @Tipo_Documento, @Numero_Documento, @Monto_Total);
		set @Id_Compra = SCOPE_IDENTITY()
		INSERT INTO DETALLE_COMPRA (ID_COMPRA, ID_PRODUCTO, PRECIO_COMPRA, PRECIO_VENTA, CANTIDAD, MONTO_TOTAL) 
		SELECT @Id_Compra, Id_Producto, Precio_Compra, Precio_Venta, Cantidad, Monto_Total FROM @Detalle_Compra
		update p set p.Stock = p.Stock + dc.Cantidad,
		p.Precio_Compra = dc.Precio_Compra,
		p.Precio_Venta = dc.Precio_Venta
		from PRODUCTO p inner join @Detalle_Compra dc on dc.Id_Producto = p.ID_PRODUCTO
		update i set i.CANTIDAD = i.CANTIDAD + dc.CANTIDAD from INVENTARIO i
		INNER JOIN @Detalle_Compra dc ON i.ID_PRODUCTO = dc.ID_PRODUCTO;
		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
[IdProducto] int NULL,
[PrecioVenta] decimal(18,2) NULL,
[Cantidad] int NULL,
[SubTotal] decimal(18,2) NULL,
[Descuento] decimal(18,2) NULL
)
go

CREATE PROCEDURE PA_REGISTRAR_VENTA(
@Id_Usuario int,
@Tipo_Documento varchar(500),
@Numero_Documento varchar(500),
@Documento_Cliente varchar(500),
@Nombre_Cliente varchar(500),
@Monto_Pago decimal(18,2),
@Monto_Cambio decimal(18,2),
@Monto_Total decimal(18,2),
@Descuento decimal (18,2),
@Detalle_Venta [EDetalle_Venta] READONLY,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin
	begin try
		declare @Id_Venta int = 0
		set @Resultado = 1
		set @Mensaje = ''
		begin transaction registro
		INSERT INTO VENTA(ID_USUARIO, TIPO_DOCUMENTO, NUMERO_DOCUMENTO, DOCUMENTO_CLIENTE, NOMBRE_CLIENTE, MONTO_PAGO, MONTO_CAMBIO, MONTO_TOTAL, DESCUENTO)
		VALUES (@Id_Usuario, @Tipo_Documento, @Numero_Documento, @Documento_Cliente, @Nombre_Cliente, @Monto_Pago, @Monto_Cambio, @Monto_Total, @Descuento)
		set @Id_Venta = SCOPE_IDENTITY()
		INSERT INTO DETALLE_VENTA(ID_VENTA, ID_PRODUCTO, PRECIO_VENTA, CANTIDAD_PRODUCTO, SUBTOTAL, DESCUENTO)
		SELECT @Id_Venta,IdProducto, PrecioVenta, Cantidad, SubTotal, Descuento FROM @Detalle_Venta
		update i set i.CANTIDAD = i.CANTIDAD - dv.CANTIDAD from INVENTARIO i
		INNER JOIN @Detalle_Venta dv ON i.ID_PRODUCTO = dv.IdProducto;
		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
	end catch
end
go

CREATE PROC PA_REPORTE_COMPRA(
@Fecha_Inicio varchar(10),
@Fecha_Fin varchar(10),
@Id_Proveedor int,
@Id_Transportista int
)
as
begin
	set dateformat dmy;
	select convert(char(10), c.FECHA_COMPRA, 103)[FECHA_COMPRA], c.TIPO_DOCUMENTO, C.NUMERO_DOCUMENTO, c.MONTO_TOTAL,
	u.NOMBRE_COMPLETO[NOMBRE_USUARIO],
	pr.DOCUMENTO[DOCUMENTO_PROVEEDOR], pr.NOMBRES[NOMBRE_PROVEEDOR],
	t.DOCUMENTO[DOCUMENTO_TRANSPORTISTA], t.NOMBRES[NOMBRE_TRANSPORTISTA],
	p.CODIGO[CODIGO_PRODUCTO], p.NOMBRE_PRODUCTO, ca.DESCRIPCION[CATEGORIA], dc.PRECIO_COMPRA, dc.PRECIO_VENTA, dc.CANTIDAD, dc.MONTO_TOTAL[SUBTOTAL]
	from COMPRA C inner join USUARIO u on u.ID_USUARIO = c.ID_USUARIO
	inner join PROVEEDOR pr on pr.ID_PROVEEDOR = c.ID_PROVEEDOR
	inner join TRANSPORTISTA t on t.ID_TRANSPORTISTA = c.ID_TRANSPORTISTA
	inner join DETALLE_COMPRA dc on dc.ID_COMPRA = c.ID_COMPRA
	inner join PRODUCTO p on p.ID_PRODUCTO = dc.ID_PRODUCTO
	inner join CATEGORIA ca on ca.ID_CATEGORIA = p.ID_CATEGORIA
	where convert(date, c.FECHA_COMPRA) between @Fecha_Inicio and @Fecha_Fin
	and pr.ID_PROVEEDOR = iif(@Id_Proveedor = 0, pr.ID_PROVEEDOR, @Id_Proveedor)
	and t.ID_TRANSPORTISTA = iif(@Id_Transportista = 0, t.ID_TRANSPORTISTA, @Id_Transportista)
end
go

CREATE PROC PA_REPORTE_VENTA(
@fecha_Inicio varchar(10),
@fecha_Fin varchar(10)
)
as
begin
	set dateformat dmy;
	select convert(char(10), v.FECHA_VENTA, 103)[FECHA_VENTA], v.TIPO_DOCUMENTO, v.NUMERO_DOCUMENTO, v.MONTO_TOTAL, v.DESCUENTO,
	u.NOMBRE_COMPLETO[NOMBRE_USUARIO],
	v.DOCUMENTO_CLIENTE, v.NOMBRE_CLIENTE,
	p.CODIGO[CODIGO_PRODUCTO], p.NOMBRE_PRODUCTO, ca.DESCRIPCION[CATEGORIA], dv.PRECIO_VENTA, dv.CANTIDAD_PRODUCTO, dv.SUBTOTAL
	from VENTA v inner join USUARIO u on u.ID_USUARIO = v.ID_USUARIO
	inner join DETALLE_VENTA dv on dv.ID_VENTA = v.ID_VENTA
	inner join PRODUCTO p on p.ID_PRODUCTO = dv.ID_PRODUCTO
	inner join CATEGORIA ca on ca.ID_CATEGORIA = p.ID_CATEGORIA
	where convert(date, v.FECHA_VENTA) between @fecha_Inicio and @fecha_Fin
end
go

CREATE PROC PA_REGISTRAR_OFERTA(
@Id_Producto int,
@Nombre_Oferta varchar(50),
@Descripcion varchar(250),
@Fecha_Inicio varchar(20),
@Fecha_Fin varchar(20),
@Descuento decimal(10,2),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 0
	if not exists (SELECT * FROM OFERTA WHERE NOMBRE_OFERTA = @Nombre_Oferta)
	begin
		INSERT INTO OFERTA (ID_PRODUCTO, NOMBRE_OFERTA, DESCRIPCION, FECHA_INICIO, FECHA_FIN, DESCUENTO, ESTADO) VALUES 
		(@Id_Producto, @Nombre_Oferta, @Descripcion, @Fecha_Inicio, @Fecha_Fin, @Descuento, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje =' Ya existe un producto con la misma oferta.'
end
go

CREATE PROC PA_EDITAR_OFERTA(
@Id_Oferta int,
@Id_Producto int,
@Nombre_Oferta varchar(50),
@Descripcion varchar(250),
@Fecha_Inicio varchar(20),
@Fecha_Fin varchar(20),
@Descuento decimal(10,2),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin 
	set @Resultado = 1
	if not exists (SELECT * FROM OFERTA WHERE NOMBRE_OFERTA = @Nombre_Oferta and ID_OFERTA != @Id_Oferta)
		update OFERTA set
		ID_PRODUCTO = @Id_Producto,
		NOMBRE_OFERTA = @Nombre_Oferta,
		DESCRIPCION = @Descripcion,
		FECHA_INICIO = @Fecha_Inicio,
		FECHA_FIN = @Fecha_Fin,
		DESCUENTO = @Descuento,
		ESTADO = @Estado
		Where ID_OFERTA = @Id_Oferta
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' No se puede repetir el nombre de la misma oferta.'
	end
end
go

CREATE PROC PA_ELIMINAR_OFERTA (
@Id_Oferta int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1;
    DELETE FROM OFERTA WHERE ID_OFERTA = @Id_Oferta;
    if @@ROWCOUNT > 0
    begin
        set @Mensaje = ' La oferta ha sido eliminada exitosamente.';
    end
    else
    begin
        set @Resultado = 0;
        set @Mensaje = ' No se encontr � ninguna oferta con el ID especificado.';
    end
end
go

CREATE PROC PA_EDITAR_RECLAMO(
@Id_Reclamo int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin 
    UPDATE RECLAMO SET ESTADO = @Estado
    WHERE ID_RECLAMO = @Id_Reclamo
    if @@ROWCOUNT = 1
    begin
        set @Resultado = 1
        set @Mensaje = ' El estado del reclamo ha sido actualizado exitosamente.'
    end
    else
    begin
        set @Resultado = 0
        set @Mensaje = ' No se puede repetir el mismo ID del reclamo.'
    end
end
go

CREATE PROC PA_ELIMINAR_RECLAMO (
@Id_Reclamo int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1;
    DELETE FROM RECLAMO WHERE ID_RECLAMO = @Id_Reclamo;
    if @@ROWCOUNT > 0
    begin
        SET @Mensaje = ' El reclamo del cliente ha sido eliminada exitosamente.';
    end
    else
    begin
        set @Resultado = 0;
        set @Mensaje = ' No se encontr � ningun reclamo con el ID especificado.';
    end
end
go

CREATE PROC PA_REGISTRAR_SUCURSAL(
@Nombre_Sucursal varchar(30),
@Direccion_Sucursal varchar(250),
@Latitud_Sucursal double precision,
@Longitud_Sucursal double precision,
@Ciudad_Sucursal varchar(30),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 0
	if not exists (SELECT * FROM SUCURSAL WHERE NOMBRE_SUCURSAL = @Nombre_Sucursal)
	begin
		insert into SUCURSAL(NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO) VALUES 
		(@Nombre_Sucursal, @Direccion_Sucursal, @Latitud_Sucursal, @Longitud_Sucursal, @Ciudad_Sucursal, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = ' Ya existe una sucursal con el mismo nombre.'
end
go

CREATE PROC PA_EDITAR_SUCURSAL(
@Id_Sucursal int,
@Nombre_Sucursal varchar(30),
@Direccion_Sucursal varchar(250),
@Latitud_Sucursal double precision,
@Longitud_Sucursal double precision,
@Ciudad_Sucursal varchar(30),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin 
	set @Resultado = 1
	if not exists (SELECT * FROM SUCURSAL WHERE NOMBRE_SUCURSAL = @Nombre_Sucursal and ID_SUCURSAL != @Id_Sucursal)
		update SUCURSAL set
		NOMBRE_SUCURSAL = @Nombre_Sucursal,
		DIRECCION_SUCURSAL = @Direccion_Sucursal,
		LATITUD_SUCURSAL = @Latitud_Sucursal,
		LONGITUD_SUCURSAL = @Longitud_Sucursal,
		CIUDAD_SUCURSAL = @Ciudad_Sucursal,
		ESTADO = @Estado
		Where ID_SUCURSAL = @Id_Sucursal
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' No se puede repetir el mismo nombre de la sucursal.'
	end 
end
go

CREATE PROC PA_ELIMINAR_SUCURSAL (
@Id_Sucursal int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1;
    DELETE FROM SUCURSAL WHERE ID_SUCURSAL = @Id_Sucursal;
    if @@ROWCOUNT > 0
    begin
        set @Mensaje = ' La sucursal ha sido eliminada exitosamente.';
    end
    else
    begin
        set @Resultado = 0;
        set @Mensaje = ' No se encontr � ninguna sucursal con el ID especificado.';
    end
end
go

CREATE PROC PA_REGISTRAR_TRANSPORTISTA(
@Documento varchar(30),
@Nombres varchar(30),
@Apellidos varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Imagen varbinary(max) = NULL,
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
as
begin
	set @Resultado = 0
	if not exists (SELECT * FROM TRANSPORTISTA WHERE DOCUMENTO = @Documento)
	begin
		insert into TRANSPORTISTA(DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, IMAGEN, ESTADO) VALUES 
		(@Documento, @Nombres, @Apellidos, @Cedula, @Telefono, @Correo_Electronico, @Imagen, @Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	else
		set @Mensaje = ' Ya existe un transportista con ese documento.'
end
go

CREATE PROC PA_EDITAR_TRANSPORTISTA(
@Id_Transportista int,
@Documento varchar(30),
@Nombres varchar(30),
@Apellidos varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Imagen varbinary(max) = NULL,
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
as
begin 
	set @Resultado = 1
	if not exists (SELECT * FROM TRANSPORTISTA WHERE DOCUMENTO = @Documento and ID_TRANSPORTISTA != @Id_Transportista)
		update TRANSPORTISTA set
		DOCUMENTO = @Documento,
		NOMBRES = @Nombres,
		APELLIDOS = @Apellidos,
		CEDULA = @Cedula,
		TELEFONO = @Telefono,
		CORREO_ELECTRONICO = @Correo_Electronico,
		IMAGEN = @Imagen,
		ESTADO = @Estado
		Where ID_TRANSPORTISTA = @Id_Transportista
	else
	begin
		set @Resultado = 0
		set @Mensaje = ' El n � mero de documento ya existe.'
	end 
end
go

CREATE PROC PA_ELIMINAR_TRANSPORTISTA (
@Id_Transportista int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
    set @Resultado = 1;
    DELETE FROM TRANSPORTISTA WHERE ID_TRANSPORTISTA = @Id_Transportista;
    if @@ROWCOUNT > 0
    begin
        set @Mensaje = ' El transportista ha sido eliminado exitosamente.';
    end
    else
    begin
        set @Resultado = 0;
        set @Mensaje = ' No se encontr � ninguna transportista con el ID especificado.';
    end
end
go

/*INSERCIONES*/
go
INSERT INTO ROL (DESCRIPCION) VALUES(' Administrador ');
go
INSERT INTO ROL (DESCRIPCION) VALUES (' Empleado ');
go
INSERT INTO USUARIO (DOCUMENTO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ID_ROL,ESTADO) VALUES (' 00001 ',' Abraham Andres Farfan Sanchez ',' hermanosfarfan @gmail.com ',' jawi2010 ',1,1);
go
INSERT INTO USUARIO (DOCUMENTO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ID_ROL,ESTADO) VALUES (' 00002 ',' Maria Belen Becerra Lopez ',' belencita @gmail.com ',' 1234 ',2,1);
go
INSERT INTO USUARIO (DOCUMENTO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ID_ROL,ESTADO) VALUES (' 00003 ',' Mateo Juan Alvarado Noboa ',' luispro @gmail.com ',' insano ',1,0);
go
INSERT INTO USUARIO (DOCUMENTO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ID_ROL,ESTADO) VALUES (' 00004 ',' Jose Maria Velazco Torres ',' jose @gmail.com ',' 12 ',2,1);
go
INSERT INTO USUARIO (DOCUMENTO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ID_ROL,ESTADO) VALUES (' 00005 ',' Esteban Leonardo Leon Marcillo ',' leonardo128 @gmail.com ',' freefire ',2,0);
go
INSERT INTO PERMISO (ID_ROL,NOMBRE_MENU) VALUES
(1,' menuUsuarios '),
(1,' menuMantenimiento '),
(1,' menuVentas '),
(1,' menuCompras '),
(1,' menuProveedores '),
(1,' menuTransportistas '),
(1,' menuSucursales '),
(1,' menuClientes '),
(1,' menuReportes '),
(1,' menuOfertas '),
(1,' menuReclamos '),
(1,' menuAcercaDe ');
go
INSERT INTO PERMISO (ID_ROL,NOMBRE_MENU) VALUES
(2,' menuVentas '),
(2,' menuCompras '),
(2,' menuProveedores '),
(2,' menuTransportistas '),
(2,' menuClientes '),
(2,' menuOfertas '),
(2,' menuReclamos '),
(2,' menuAcercaDe ');
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Frutas y Verduras ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Despensa ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Preparados ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Bebidas y Licores ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Refrigerados ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Congelados ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Carnes ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Embutidos ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Panaderia ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Mascotas ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Cuidado Personal ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Cuidado del Hogar ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Electrodom � sticos ',1);
go
INSERT INTO CATEGORIA(DESCRIPCION, ESTADO) VALUES (' Jarnideria y Plantas ',1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Tonelada ', ' t ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Quintal ', ' q ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Kilogramo ', ' kg ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Libra ', ' lb ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Gramo ', ' g ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Litro ', ' L ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Gal � n ', ' G ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Metro ', ' m ', 1);
go
INSERT INTO UNIDAD_MEDIDA (DESCRIPCION, SIMBOLO, ESTADO) VALUES(' Cent � metro ', ' cm ', 1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1000 ',' Papel Higienico ',' 8 unidades ',12,3,' Ecuador ',0);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1001 ',' Cocina Indurama ',' Color gris ',13,3,' China ',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1002 ',' Caja de Banano ',' 20 Kg ',1,3,' Ecuador ',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1003 ',' Sillas Plasticas ',' Fibra de carbono ',12,3,' Ecuador ',0);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1004 ',' Vino Blanco ',' Elaborado en 1978 ',4,6,' Espa � a ',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1005 ',' Television LG ',' Color negro ',13,8,' Jap � n ',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1006 ',' Caja de Cereza ',' Cerezas extra grandes ',1,3,' Chile ',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1007 ',' Clorox ',' 1 Litro ',12,6,' Ecuador ',0);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES(' 1008 ',' Semillas de Manzano ',' 8 unidades ',14,5,' Estados Unidos ',1);
go
INSERT INTO CLIENTE (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES (' 100 ',' Javier Mateo ',' Lopez Molina ',' 0987654321 ',' 0912345678 ',' javierito @gmail.com ',1);
go
INSERT INTO CLIENTE (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES (' 101 ',' Julio Andres ',' Mata Rodriguez ',' 0975312468 ',' 0986421357 ',' julito @gmail.com ',1);
go
INSERT INTO CLIENTE (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES (' 102 ',' Emily Sofia ',' Andrade Sanchez ',' 0914237898 ',' 0957143210 ',' emily @gmail.com ',1);
go
INSERT INTO PROVEEDOR (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES (' 100 ',' Manolo Sebastian ',' Pilligua Montalvo ',' 0981441455 ',' 0956262748 ',' manolito @gmail.com ',1);
go
INSERT INTO PROVEEDOR (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES (' 101 ',' Juan Manuel ',' Gago Perez ',' 0975462351 ',' 0981893637 ',' juanito @gmail.com ',1);
go
INSERT INTO PROVEEDOR (DOCUMENTO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES (' 102 ',' Sebastian Andres ',' Gonzales Lopez ',' 0951135233 ',' 0936472943 ',' sagl @gmail.com ',1);
go
INSERT INTO NEGOCIO (ID_NEGOCIO, NOMBRE, TELEFONO, RUC, DIRECCION, CORREO_ELECTRONICO) VALUES(1,' Supermercado Paradisia ',' 0969810812 ',' 0102030405 ',' Mucho Lote 3 etapa ',' SupermercadoParadisia @gmail.com ');
go
INSERT INTO RECLAMO (ID_CLIENTE, NOMBRE_CLIENTE, CORREO_ELECTRONICO_CLIENTE, DESCRIPCION, ESTADO) VALUES(1,' Javier Mateo ',' javierito @gmail.com ',' Compre unas cajas de bananos y algunas bananas me vinieron negras,
	exijo una devolucion.',1);
go
INSERT INTO RECLAMO (ID_CLIENTE, NOMBRE_CLIENTE, CORREO_ELECTRONICO_CLIENTE, DESCRIPCION, ESTADO) VALUES(2,' Julio Andres ',' julito @gmail.com ',' El televisor LG que compre no me vino con el soporte y los tornillos para ponerlo en la pared.',0);
go
INSERT INTO RECLAMO (ID_CLIENTE, NOMBRE_CLIENTE, CORREO_ELECTRONICO_CLIENTE, DESCRIPCION, ESTADO) VALUES(2,' Julio Andres ',' julito @gmail.com ',' Cuando compre la cocina decia que venia con un
set
	de ollas pero al momento de la entrega no me vino eso.',0);
go
INSERT INTO SUCURSAL (NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO) VALUES (' GUAYAQUIL_9 DE OCT y LOS RIOS ',' AV.9 DE OCTUBRE 803 Y LOS RIOS ',-2.187746,-79.894365,' Guayaquil ',1);
go
INSERT INTO SUCURSAL (NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO) VALUES (' GUAYAQUIL_ALBANBORJA ',' AV.CARLOS JULIO AROSEMENA S / N',-2.169321,-79.917047,' Guayaquil ',0);