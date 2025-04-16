/*Creacion de la Base de Datos*/
CREATE DATABASE Sistema_Ventas;
go

USE Sistema_Ventas;
go

/*Creacion de las Tablas*/
CREATE TABLE NEGOCIO (ID_NEGOCIO int primary key identity,
NOMBRE varchar (60),
TELEFONO varchar (10) unique,
RUC varchar(13) unique,
DIRECCION varchar(60),
CORREO_ELECTRONICO varchar(40),
LOGO varbinary(max)NUll
);
go

CREATE TABLE SUCURSAL(ID_SUCURSAL int primary key identity,
CODIGO varchar(10) unique,
ID_NEGOCIO int references NEGOCIO(ID_NEGOCIO),
NOMBRE_SUCURSAL varchar(30),
DIRECCION_SUCURSAL varchar(250),
LATITUD_SUCURSAL double precision,
LONGITUD_SUCURSAL double precision,
CIUDAD_SUCURSAL varchar(30),
ESTADO bit
);
go

CREATE TABLE ROL (ID_ROL int primary key identity,
DESCRIPCION nvarchar(50),
FECHA_CREACION datetime default getdate());
go

CREATE TABLE PERMISO (ID_PERMISO int primary key identity,
ID_ROL int references ROL(ID_ROL),
NOMBRE_MENU varchar(100),
FECHA_CREACION datetime default getdate());
go

CREATE TABLE PROVEEDOR (ID_PROVEEDOR int primary key identity,
CODIGO varchar(10) unique,
NOMBRES varchar(30),
APELLIDOS varchar(30),
CEDULA varchar(10) unique,
TELEFONO varchar(10) unique,
CORREO_ELECTRONICO nvarchar(50),
ESTADO bit,
FECHA_REGISTRO datetime default getdate()
);
go

CREATE TABLE TRANSPORTISTA(ID_TRANSPORTISTA int primary key identity,
CODIGO varchar(10) unique,
NOMBRES varchar(30),
APELLIDOS varchar(30),
CEDULA varchar(10) unique,
TELEFONO varchar(10) unique,
CORREO_ELECTRONICO nvarchar(50),
IMAGEN varbinary(max)NUll,
ESTADO bit,
FECHA_REGISTRO datetime default getdate()
);
go

CREATE TABLE CLIENTE (ID_CLIENTE int primary key identity,
CODIGO varchar(10) unique,
NOMBRES varchar(30),
APELLIDOS varchar(30),
CEDULA varchar(10) unique,
TELEFONO varchar(10) unique,
CORREO_ELECTRONICO nvarchar(50),
ESTADO bit,
FECHA_REGISTRO datetime default getdate()
);
go

CREATE TABLE USUARIO (ID_USUARIO int primary key identity,
CODIGO varchar(10) unique,
NOMBRE_COMPLETO varchar(70),
CORREO_ELECTRONICO nvarchar(50),
CLAVE nvarchar(300),
CLAVE_SALT nvarchar(100),
TOKEN_RECUPERACION NVARCHAR(100) NULL,
ID_ROL int references ROL(ID_ROL),
ESTADO bit,
FECHA_CREACION datetime default getdate()
);
go

CREATE TABLE CATEGORIA( ID_CATEGORIA int primary key identity,
CODIGO varchar(10) unique,
DESCRIPCION nvarchar(50),
ESTADO bit,
FECHA_CREACION datetime default getdate()
);
go

CREATE TABLE UNIDAD_MEDIDA (ID_UNIDAD_MEDIDA int primary key identity,
CODIGO varchar(10) unique,
DESCRIPCION nvarchar(50),
SIMBOLO nvarchar(10),
ESTADO bit,
FECHA_CREACION datetime default getdate()
);
go

CREATE TABLE PRODUCTO( ID_PRODUCTO int primary key identity,
CODIGO varchar(10) unique,
DESCRIPCION nvarchar(50),
NOMBRE_PRODUCTO nvarchar(30),
ID_CATEGORIA int references CATEGORIA(ID_CATEGORIA),
ID_UNIDAD_MEDIDA int references UNIDAD_MEDIDA(ID_UNIDAD_MEDIDA),
PAIS_ORIGEN varchar(30),
STOCK int NOT NULL default 0,
PRECIO_COMPRA decimal (10,2) default 0,
PRECIO_VENTA decimal (10,2) default 0,
ESTADO bit,
);
go

CREATE TABLE ZONA_ALMACEN (ID_ZONA int IDENTITY PRIMARY KEY,
NOMBRE_ZONA varchar(20), 
LIMITE_ESPACIOS int NOT NULL DEFAULT 200,
ESTADO bit,
FECHA_REGISTRO datetime default getdate()
);
go

CREATE TABLE INVENTARIO (ID_INVENTARIO int identity primary key not null,
ID_PRODUCTO int REFERENCES PRODUCTO(ID_PRODUCTO),
ID_ZONA int REFERENCES ZONA_ALMACEN(ID_ZONA),
CANTIDAD int NOT NULL CHECK (CANTIDAD >= 0),
FECHA_INGRESO datetime default getdate()
);
go

CREATE TABLE COMPRA (ID_COMPRA int identity primary key not null,
ID_USUARIO int references USUARIO(ID_USUARIO),
ID_PROVEEDOR int references PROVEEDOR(ID_PROVEEDOR),
ID_TRANSPORTISTA int references TRANSPORTISTA(ID_TRANSPORTISTA),
ID_SUCURSAL int references SUCURSAL(ID_SUCURSAL),
TIPO_DOCUMENTO varchar(50),
NUMERO_DOCUMENTO varchar(50) unique,
MONTO_TOTAL decimal(10,2),
FECHA_COMPRA datetime default getdate()
);
go

CREATE TABLE DETALLE_COMPRA ( ID_DETALLE_COMPRA int primary key identity,
ID_COMPRA int references COMPRA (ID_COMPRA),
ID_PRODUCTO int references PRODUCTO (ID_PRODUCTO),
PRECIO_COMPRA decimal (10,2) default 0,
PRECIO_VENTA decimal (10,2) default 0,
CANTIDAD int,
MONTO_TOTAL decimal (10,2),
FECHA_REGISTRO datetime default getdate()
);
go

CREATE TABLE VENTA ( ID_VENTA int primary key identity,
ID_USUARIO int references USUARIO (ID_USUARIO),
TIPO_DOCUMENTO varchar(50),
ID_SUCURSAL int references SUCURSAL (ID_SUCURSAL),
ID_CLIENTE int references CLIENTE (ID_CLIENTE),
NUMERO_DOCUMENTO varchar(50) unique,
MONTO_PAGO decimal (10,2),
MONTO_CAMBIO decimal (10,2),
MONTO_TOTAL decimal (10,2),
DESCUENTO decimal (10,2),
FECHA_VENTA datetime default getdate()
);
go

CREATE TABLE DETALLE_VENTA ( ID_DETALLE_VENTA int primary key identity,
ID_VENTA int references VENTA (ID_VENTA),
ID_PRODUCTO int references PRODUCTO (ID_PRODUCTO),
PRECIO_VENTA decimal (10,2),
CANTIDAD_PRODUCTO int,
SUBTOTAL decimal (10,2),
DESCUENTO decimal (10,2),
FECHA_REGISTRO datetime default getdate()
);
go

/*CREATE TABLE RECLAMO(ID_RECLAMO int primary key identity,
ID_CLIENTE int references CLIENTE(ID_CLIENTE),
NOMBRE_CLIENTE nvarchar(50),
CORREO_ELECTRONICO_CLIENTE nvarchar(50),
DESCRIPCION nvarchar(500),
ESTADO bit,
FECHA_REGISTRO datetime default getdate()
); 
go*/

CREATE TABLE OFERTA (ID_OFERTA INT PRIMARY KEY IDENTITY,
CODIGO varchar(10) unique,
NOMBRE_OFERTA varchar(50), 
ID_PRODUCTO int references PRODUCTO(ID_PRODUCTO),
DESCRIPCION varchar(250),
FECHA_INICIO date,
FECHA_FIN date,
DESCUENTO decimal(5,2) default 0,
ESTADO bit,
FECHA_CREACION datetime default getdate()
);
go

/*Creacion de los Procedimientos Almacenados*/
go
CREATE PROC PA_REGISTRAR_USUARIO(
@Codigo varchar(30),
@Nombre_Completo varchar(70),
@Correo_Electronico varchar(50),
@Clave_Hash nvarchar(300),
@Salt nvarchar(100),
@Id_Rol int,
@Estado bit,
@Id_Usuario_Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        SET @Id_Usuario_Resultado = 0;
        SET @Mensaje = '';

        IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE CODIGO = @Codigo)
        BEGIN

            INSERT INTO USUARIO (CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, TOKEN_RECUPERACION, ID_ROL, ESTADO)
            VALUES (@Codigo, @Nombre_Completo, @Correo_Electronico, @Clave_Hash, @Salt, NULL, @Id_Rol, @Estado);

            SET @Id_Usuario_Resultado = SCOPE_IDENTITY();
            SET @Mensaje = 'Usuario registrado exitosamente.';
        END
        ELSE
        BEGIN

            SET @Mensaje = 'No se puede repetir el c�digo para m�s de un usuario.';
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        ROLLBACK TRANSACTION;
        SET @Id_Usuario_Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

/*CREATE PROC PA_EDITAR_USUARIO(
@Id_Usuario int,
@Codigo varchar(10),
@Nombre_Completo varchar(70),
@Correo_Electronico varchar(50),
@Clave varchar(30),
@Id_Rol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Inicializar salidas
        SET @Respuesta = 0;
        SET @Mensaje = '';

        -- Verificar si el c�digo ya est� en uso por otro usuario
        IF EXISTS (SELECT 1 FROM USUARIO WHERE CODIGO = @Codigo AND ID_USUARIO != @Id_Usuario)
        BEGIN
            SET @Mensaje = 'El c�digo ingresado ya est� asociado a otro usuario.';
        END
        ELSE
        BEGIN
            -- Verificar si el usuario con el ID proporcionado existe
            IF EXISTS (SELECT 1 FROM USUARIO WHERE ID_USUARIO = @Id_Usuario)
            BEGIN
                -- Actualizar el usuario
                UPDATE USUARIO
                SET CODIGO = @Codigo,
                    NOMBRE_COMPLETO = @Nombre_Completo,
                    CORREO_ELECTRONICO = @Correo_Electronico,
                    CLAVE = @Clave,
                    ID_ROL = @Id_Rol,
                    ESTADO = @Estado
                WHERE ID_USUARIO = @Id_Usuario;

                SET @Respuesta = 1;
                SET @Mensaje = 'Usuario actualizado exitosamente.';
            END
            ELSE
            BEGIN
                -- Usuario no encontrado
                SET @Mensaje = 'El usuario especificado no existe.';
            END
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        ROLLBACK TRANSACTION;
        SET @Respuesta = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;*/
CREATE PROC PA_EDITAR_USUARIO(
    @Id_Usuario int,
    @Codigo varchar(10),
    @Nombre_Completo varchar(70),
    @Correo_Electronico varchar(50),
    @Clave_Hash NVARCHAR(300) = NULL, -- Clave encriptada opcional
    @Salt NVARCHAR(100) = NULL,       -- Salt opcional si se cambia la clave
	@TokenRecuperacion nvarchar(100) = NULL, 
    @Id_Rol int,
    @Estado bit,
    @Respuesta bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Inicializar salidas
        SET @Respuesta = 0;
        SET @Mensaje = '';

        -- Verificar si el c�digo ya est� en uso por otro usuario
        IF EXISTS (SELECT 1 FROM USUARIO WHERE CODIGO = @Codigo AND ID_USUARIO != @Id_Usuario)
        BEGIN
            SET @Mensaje = 'El c�digo ingresado ya est� asociado a otro usuario.';
        END
        ELSE
        BEGIN
            -- Verificar si el usuario con el ID proporcionado existe
            IF EXISTS (SELECT 1 FROM USUARIO WHERE ID_USUARIO = @Id_Usuario)
            BEGIN
                -- Si no se proporciona nueva clave, mantener la actual
                IF @Clave_Hash IS NULL AND @TokenRecuperacion IS NULL
				BEGIN
					UPDATE USUARIO
					SET CODIGO = @Codigo,
						NOMBRE_COMPLETO = @Nombre_Completo,
						CORREO_ELECTRONICO = @Correo_Electronico,
						ID_ROL = @Id_Rol,
						ESTADO = @Estado
					WHERE ID_USUARIO = @Id_Usuario;
				END
				ELSE IF @Clave_Hash IS NULL AND @TokenRecuperacion IS NOT NULL
				BEGIN
					UPDATE USUARIO
					SET CODIGO = @Codigo,
						NOMBRE_COMPLETO = @Nombre_Completo,
						CORREO_ELECTRONICO = @Correo_Electronico,
						TOKEN_RECUPERACION = @TokenRecuperacion,
						ID_ROL = @Id_Rol,
						ESTADO = @Estado
					WHERE ID_USUARIO = @Id_Usuario;
				END
				ELSE
				BEGIN
					UPDATE USUARIO
					SET CODIGO = @Codigo,
						NOMBRE_COMPLETO = @Nombre_Completo,
						CORREO_ELECTRONICO = @Correo_Electronico,
						CLAVE = @Clave_Hash,
						CLAVE_SALT = @Salt,
						TOKEN_RECUPERACION = NULL, -- Si cambia la clave, se invalida el token
						ID_ROL = @Id_Rol,
						ESTADO = @Estado
					WHERE ID_USUARIO = @Id_Usuario;
				END

                SET @Respuesta = 1;
                SET @Mensaje = 'Usuario actualizado exitosamente.';
            END
            ELSE
            BEGIN
                -- Usuario no encontrado
                SET @Mensaje = 'El usuario especificado no existe.';
            END
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        ROLLBACK TRANSACTION;
        SET @Respuesta = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_ELIMINAR_USUARIO(
@Id_Usuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Inicializar variables
        SET @Respuesta = 0;
        SET @Mensaje = '';
        DECLARE @paso_Reglas BIT = 1;

        -- Verificar relaci�n con compras
        IF EXISTS (
            SELECT 1 
            FROM COMPRA c
            INNER JOIN USUARIO u ON u.ID_USUARIO = c.ID_USUARIO
            WHERE u.ID_USUARIO = @Id_Usuario
        )
        BEGIN
            SET @paso_Reglas = 0;
            SET @Mensaje = @Mensaje + 'No se puede eliminar este usuario porque se encuentra relacionado a una compra. ';
        END

        -- Verificar relaci�n con ventas
        IF EXISTS (
            SELECT 1 
            FROM VENTA v
            INNER JOIN USUARIO u ON u.ID_USUARIO = v.ID_USUARIO
            WHERE u.ID_USUARIO = @Id_Usuario
        )
        BEGIN
            SET @paso_Reglas = 0;
            SET @Mensaje = @Mensaje + 'No se puede eliminar este usuario porque se encuentra relacionado a una venta. ';
        END

        -- Eliminar usuario si pas� las reglas
        IF @paso_Reglas = 1
        BEGIN
            DELETE FROM USUARIO WHERE ID_USUARIO = @Id_Usuario;
            SET @Respuesta = 1;
            SET @Mensaje = 'Usuario eliminado exitosamente.';
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        ROLLBACK TRANSACTION;
        SET @Respuesta = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_REGISTRAR_CATEGORIA(
@Codigo varchar (10),
@Descripcion varchar (50),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		IF NOT EXISTS (SELECT 1 FROM CATEGORIA WHERE CODIGO = @Codigo)
		BEGIN
			INSERT INTO CATEGORIA (CODIGO, DESCRIPCION, ESTADO) 
			VALUES (@Codigo, @Descripcion, @Estado);

			SET @Resultado = SCOPE_IDENTITY();
			SET @Mensaje = 'Categor�a registrada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'No se puede repetir el c�digo de una categor�a.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;
go

CREATE PROC PA_EDITAR_CATEGORIA(
@Id_Categoria int,
@Codigo varchar (10),
@Descripcion varchar (50),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		IF NOT EXISTS (SELECT 1 FROM CATEGORIA WHERE CODIGO = @Codigo AND ID_CATEGORIA != @Id_Categoria)
		BEGIN
			UPDATE CATEGORIA 
			SET CODIGO = @Codigo,
				DESCRIPCION = @Descripcion,
				ESTADO = @Estado
			WHERE ID_CATEGORIA = @Id_Categoria;

			SET @Resultado = 1;
			SET @Mensaje = 'Categor�a actualizada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'No se puede repetir el c�digo de una categor�a.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_CATEGORIA(
@Id_Categoria int,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		SET @Resultado = 0;
		SET @Mensaje = '';

		IF NOT EXISTS (
			SELECT 1 
			FROM CATEGORIA c 
			INNER JOIN PRODUCTO p ON p.ID_CATEGORIA = c.ID_CATEGORIA 
			WHERE c.ID_CATEGORIA = @Id_Categoria
		)
		BEGIN
			DELETE FROM CATEGORIA 
			WHERE ID_CATEGORIA = @Id_Categoria;

			SET @Resultado = 1;
			SET @Mensaje = 'Categor�a eliminada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'La categor�a ya se encuentra relacionada a un producto.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;
go

CREATE PROC PA_REGISTRAR_PRODUCTO(
@Codigo varchar (10),
@Nombre_Producto varchar (30),
@Descripcion varchar(50),
@Id_Categoria int,
@Id_Unidad_Medida int,
@Pais_Origen varchar(30),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
AS
BEGIN
    BEGIN TRY
		BEGIN TRANSACTION;

        SET @Resultado = 0;
		SET @Mensaje = '';

        IF NOT EXISTS (SELECT 1 FROM PRODUCTO WHERE CODIGO = @Codigo)
        BEGIN
            INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO)
            VALUES (@Codigo, @Nombre_Producto, @Descripcion, @Id_Categoria, @Id_Unidad_Medida, @Pais_Origen, @Estado);

            SET @Resultado = SCOPE_IDENTITY();
            SET @Mensaje = 'Producto registrado exitosamente.';
        END
        ELSE
        BEGIN
            SET @Mensaje = 'Ya existe un producto con el mismo c�digo.';
        END

		COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_EDITAR_PRODUCTO(
@Id_Producto int,
@Codigo varchar(10),
@Nombre_Producto varchar(30),
@Descripcion varchar (50),
@Id_Categoria int,
@Id_Unidad_Medida int,
@Pais_Origen varchar(30),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
    BEGIN TRY
		BEGIN TRANSACTION;

        SET @Resultado = 0;
		SET @Mensaje = '';

        IF NOT EXISTS (SELECT 1 FROM PRODUCTO WHERE CODIGO = @Codigo AND ID_PRODUCTO != @Id_Producto)
        BEGIN
            UPDATE PRODUCTO
            SET
                NOMBRE_PRODUCTO = @Nombre_Producto,
                DESCRIPCION = @Descripcion,
                ID_CATEGORIA = @Id_Categoria,
                ID_UNIDAD_MEDIDA = @Id_Unidad_Medida,
                PAIS_ORIGEN = @Pais_Origen,
                ESTADO = @Estado
            WHERE ID_PRODUCTO = @Id_Producto;

            SET @Mensaje = 'Producto actualizado exitosamente.';
        END
        ELSE
        BEGIN
            SET @Resultado = 1;
            SET @Mensaje = 'No se puede repetir el c�digo de un producto.';
        END

		COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_ELIMINAR_PRODUCTO(
@Id_Producto int,
@Respuesta bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
    BEGIN TRY
		BEGIN TRANSACTION;
        SET @Respuesta = 0;
        SET @Mensaje = '';

        -- Verificar relaciones
        IF EXISTS (SELECT 1 FROM DETALLE_COMPRA WHERE ID_PRODUCTO = @Id_Producto)
            SET @Mensaje = @Mensaje + 'No se puede eliminar porque est� relacionado con compras.\n';

        IF EXISTS (SELECT 1 FROM DETALLE_VENTA WHERE ID_PRODUCTO = @Id_Producto)
            SET @Mensaje = @Mensaje + 'No se puede eliminar porque est� relacionado con ventas.\n';

        IF EXISTS (SELECT 1 FROM INVENTARIO WHERE ID_PRODUCTO = @Id_Producto)
            SET @Mensaje = @Mensaje + 'No se puede eliminar porque est� en inventario.\n';

        IF EXISTS (SELECT 1 FROM OFERTA WHERE ID_PRODUCTO = @Id_Producto)
            SET @Mensaje = @Mensaje + 'No se puede eliminar porque est� en ofertas.\n';

        -- Si no hay dependencias, eliminar
        IF LEN(@Mensaje) = 0
        BEGIN
            DELETE FROM PRODUCTO WHERE ID_PRODUCTO = @Id_Producto;
            SET @Respuesta = 1;
            SET @Mensaje = 'Producto eliminado exitosamente.';
        END

		COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Respuesta = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_REGISTRAR_UNIDAD_MEDIDA(
@Codigo varchar(10),
@Descripcion varchar (50),
@Simbolo nvarchar (10),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		-- Verificar si ya existe la unidad de medida con el mismo c�digo
		IF NOT EXISTS (SELECT 1 FROM UNIDAD_MEDIDA WHERE CODIGO = @Codigo)
		BEGIN
			INSERT INTO UNIDAD_MEDIDA(CODIGO, DESCRIPCION, SIMBOLO, ESTADO)
			VALUES (@Codigo, @Descripcion, @Simbolo, @Estado);

			SET @Resultado = SCOPE_IDENTITY();
			SET @Mensaje = 'Unidad de medida registrada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'No se puede repetir el c�digo de una unidad de medida.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_EDITAR_UNIDAD_MEDIDA(
@Id_Unidad_Medida int,
@Codigo varchar(10),
@Descripcion varchar (50),
@Simbolo nvarchar (10),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		-- Verificar si el c�digo ya existe para otra unidad de medida
		IF NOT EXISTS (SELECT 1 FROM UNIDAD_MEDIDA WHERE CODIGO = @Codigo AND ID_UNIDAD_MEDIDA != @Id_Unidad_Medida)
		BEGIN
			UPDATE UNIDAD_MEDIDA
			SET 
				DESCRIPCION = @Descripcion,
				SIMBOLO = @Simbolo, 
				ESTADO = @Estado
			WHERE ID_UNIDAD_MEDIDA = @Id_Unidad_Medida;

			SET @Resultado = 1;
			SET @Mensaje = 'Unidad de medida actualizada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'No se puede repetir el c�digo de una unidad de medida.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_UNIDAD_MEDIDA(
@Id_Unidad_Medida int,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		-- Verificar si la unidad de medida est� asociada a alg�n producto
		IF NOT EXISTS (SELECT 1 FROM PRODUCTO WHERE ID_UNIDAD_MEDIDA = @Id_Unidad_Medida)
		BEGIN
			DELETE FROM UNIDAD_MEDIDA WHERE ID_UNIDAD_MEDIDA = @Id_Unidad_Medida;

			IF @@ROWCOUNT > 0
			BEGIN
				SET @Resultado = 1;
				SET @Mensaje = 'Unidad de medida eliminada exitosamente.';
			END
			ELSE
			BEGIN
				SET @Mensaje = 'No se encontr� ninguna unidad de medida con el ID especificado.';
			END
		END
		ELSE
		BEGIN
			SET @Mensaje = 'La unidad de medida ya se encuentra relacionada a un producto y no puede eliminarse.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_REGISTRAR_PRODUCTO_INVENTARIO(
@Id_Producto int,
@Id_Zona int,
@Cantidad int,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Declarar variables locales
    DECLARE @Cantidad_Comprada INT;
    DECLARE @Limite_Zona INT;

    -- Inicializamos las variables de salida
    SET @Resultado = 0;
    SET @Mensaje = '';

    -- Verificar si el producto ya est� registrado en el inventario
    IF EXISTS (
        SELECT 1
        FROM INVENTARIO
        WHERE ID_PRODUCTO = @Id_Producto
    )
    BEGIN
        SET @Mensaje = 'El producto ya est� registrado en el inventario.';
        RETURN;
    END

    -- Obtener la cantidad comprada del producto
    SELECT @Cantidad_Comprada = ISNULL(SUM(CANTIDAD), 0)
    FROM DETALLE_COMPRA
    WHERE ID_PRODUCTO = @Id_Producto;

    -- Obtener la capacidad total de la zona de almacenamiento
    SELECT @Limite_Zona = LIMITE_ESPACIOS
    FROM ZONA_ALMACEN
    WHERE ID_ZONA = @Id_Zona;

    -- Validar cantidad contra la cantidad comprada y el espacio disponible
    IF @Cantidad > @Cantidad_Comprada
    BEGIN
        SET @Mensaje = 'La cantidad ingresada excede la cantidad comprada del producto.';
        RETURN;
    END

    IF @Cantidad > @Limite_Zona
    BEGIN
        SET @Mensaje = 'No hay suficiente espacio en la zona del almac�n especificada.';
        RETURN;
    END

    -- Registrar el producto en el inventario y actualizar el espacio disponible
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO INVENTARIO (ID_PRODUCTO, ID_ZONA, CANTIDAD, FECHA_INGRESO)
        VALUES (@Id_Producto, @Id_Zona, @Cantidad, GETDATE());

        UPDATE ZONA_ALMACEN
        SET LIMITE_ESPACIOS = LIMITE_ESPACIOS - @Cantidad
        WHERE ID_ZONA = @Id_Zona;

        SET @Resultado = SCOPE_IDENTITY();
        SET @Mensaje = 'Producto registrado en el inventario exitosamente.';
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_EDITAR_PRODUCTO_INVENTARIO(
@Id_Inventario int,
@Id_Producto int,
@Id_Zona int,
@Cantidad int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Declarar variables locales
        DECLARE @CantidadActual INT;
        DECLARE @Id_Zona_Anterior INT;
        DECLARE @DiferenciaCantidad INT;

        -- Obtener la cantidad actual y la zona anterior
        SELECT @CantidadActual = CANTIDAD, 
               @Id_Zona_Anterior = ID_ZONA 
        FROM INVENTARIO 
        WHERE ID_INVENTARIO = @Id_Inventario;

        -- Calcular la diferencia de cantidad
        SET @DiferenciaCantidad = @Cantidad - @CantidadActual;

        -- Actualizar la capacidad de la zona anterior si es diferente de la nueva
        IF @Id_Zona_Anterior <> @Id_Zona
        BEGIN
            -- Devolver el espacio a la zona anterior
            UPDATE ZONA_ALMACEN
            SET LIMITE_ESPACIOS = LIMITE_ESPACIOS + @CantidadActual
            WHERE ID_ZONA = @Id_Zona_Anterior;

            -- Validar si hay espacio suficiente en la nueva zona
            DECLARE @EspacioDisponible INT;
            SELECT @EspacioDisponible = LIMITE_ESPACIOS 
            FROM ZONA_ALMACEN 
            WHERE ID_ZONA = @Id_Zona;

            IF @EspacioDisponible < @Cantidad
            BEGIN
                SET @Resultado = 0;
                SET @Mensaje = 'No hay suficiente espacio en la nueva zona del almac�n especificada.';
                ROLLBACK TRANSACTION;
                RETURN;
            END

            -- Restar espacio de la nueva zona
            UPDATE ZONA_ALMACEN
            SET LIMITE_ESPACIOS = LIMITE_ESPACIOS - @Cantidad
            WHERE ID_ZONA = @Id_Zona;
        END
        ELSE
        BEGIN
            -- Si la zona no cambia, solo ajusta la diferencia
            UPDATE ZONA_ALMACEN
            SET LIMITE_ESPACIOS = LIMITE_ESPACIOS - @DiferenciaCantidad
            WHERE ID_ZONA = @Id_Zona;
        END

        -- Actualizar el inventario
        UPDATE INVENTARIO
        SET ID_PRODUCTO = @Id_Producto,
            ID_ZONA = @Id_Zona,
            CANTIDAD = @Cantidad
        WHERE ID_INVENTARIO = @Id_Inventario;

        SET @Resultado = 1;
        SET @Mensaje = 'Producto actualizado exitosamente en el inventario.';

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        ROLLBACK TRANSACTION;

        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_ELIMINAR_PRODUCTO_INVENTARIO(
@Id_Inventario INT,
@Resultado BIT OUTPUT,
@Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Declarar variables locales
        DECLARE @Id_Zona INT;
        DECLARE @Cantidad INT;

        -- Obtener informaci�n de la zona y cantidad asociadas al inventario
        SELECT @Id_Zona = ID_ZONA, @Cantidad = CANTIDAD 
        FROM INVENTARIO 
        WHERE ID_INVENTARIO = @Id_Inventario;

        -- Eliminar el producto del inventario
        DELETE FROM INVENTARIO 
        WHERE ID_INVENTARIO = @Id_Inventario;

        -- Verificar si se elimin� una fila
        IF @@ROWCOUNT > 0
        BEGIN
            -- Actualizar la capacidad disponible en la zona correspondiente
            UPDATE ZONA_ALMACEN
            SET LIMITE_ESPACIOS = LIMITE_ESPACIOS + @Cantidad
            WHERE ID_ZONA = @Id_Zona;

            SET @Resultado = 1;
            SET @Mensaje = 'Producto eliminado del inventario exitosamente.';
        END
        ELSE
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'No se pudo eliminar el producto del inventario.';
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        ROLLBACK TRANSACTION;

        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

CREATE PROC PA_REGISTRAR_CLIENTE(
@Codigo varchar(10),
@Nombre_Cliente varchar(30),
@Apellido_Cliente varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		-- Validaci�n de duplicidad de C�digo y C�dula
		IF NOT EXISTS (SELECT 1 FROM CLIENTE WHERE CODIGO = @Codigo)
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM CLIENTE WHERE CEDULA = @Cedula)
			BEGIN
				INSERT INTO CLIENTE(CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO)
				VALUES (@Codigo, @Nombre_Cliente, @Apellido_Cliente, @Cedula, @Telefono, @Correo_Electronico, @Estado);

				SET @Resultado = SCOPE_IDENTITY();
				SET @Mensaje = 'Cliente registrado exitosamente.';
			END
			ELSE
			BEGIN
				SET @Mensaje = 'Ya existe un cliente con la misma c�dula.';
			END
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe un cliente con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_EDITAR_CLIENTE(
@Id_Cliente int,
@Codigo varchar(10),
@Nombre_Cliente varchar(30),
@Apellido_Cliente varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 1;
		SET @Mensaje = '';

		-- Validaci�n de duplicidad de C�digo y C�dula
		IF NOT EXISTS (SELECT 1 FROM CLIENTE WHERE CODIGO = @Codigo AND ID_CLIENTE != @Id_Cliente)
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM CLIENTE WHERE CEDULA = @Cedula AND ID_CLIENTE != @Id_Cliente)
			BEGIN
				UPDATE CLIENTE
				SET
					CODIGO = @Codigo,
					NOMBRES = @Nombre_Cliente,
					APELLIDOS = @Apellido_Cliente,
					CEDULA = @Cedula,
					TELEFONO = @Telefono,
					CORREO_ELECTRONICO = @Correo_Electronico,
					ESTADO = @Estado
				WHERE ID_CLIENTE = @Id_Cliente;

				SET @Mensaje = 'Cliente actualizado exitosamente.';
			END
			ELSE
			BEGIN
				SET @Resultado = 0;
				SET @Mensaje = 'Ya existe un cliente con la misma c�dula.';
			END
		END
		ELSE
		BEGIN
			SET @Resultado = 0;
			SET @Mensaje = 'Ya existe un cliente con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_CLIENTE(
@Id_Cliente int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 1;
		SET @Mensaje = '';

		DELETE FROM CLIENTE WHERE ID_CLIENTE = @Id_Cliente;

		IF @@ROWCOUNT > 0
		BEGIN
			SET @Mensaje = 'Cliente eliminado exitosamente.';
		END
		ELSE
		BEGIN
			SET @Resultado = 0;
			SET @Mensaje = 'No se encontr� ning�n cliente con el ID especificado.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_REGISTRAR_PROVEEDOR(
@Codigo varchar(10),
@Nombres_Proveedor varchar(30),
@Apellidos_Proveedor varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		IF NOT EXISTS (SELECT 1 FROM PROVEEDOR WHERE CODIGO = @Codigo)
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM PROVEEDOR WHERE CEDULA = @Cedula)
			BEGIN
				INSERT INTO PROVEEDOR (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) 
				VALUES (@Codigo, @Nombres_Proveedor, @Apellidos_Proveedor, @Cedula, @Telefono, @Correo_Electronico, @Estado);

				SET @Resultado = SCOPE_IDENTITY();
				SET @Mensaje = 'Proveedor registrado exitosamente.';
			END
			ELSE
			BEGIN
				SET @Mensaje = 'Ya existe un proveedor con la misma c�dula.';
			END
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe un proveedor con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_EDITAR_PROVEEDOR(
@Id_Proveedor int,
@Codigo varchar(10),
@Nombres_Proveedor varchar(30),
@Apellidos_Proveedor varchar(30),
@Cedula varchar(10),
@Telefono varchar(10),
@Correo_Electronico varchar(50),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 1;
		SET @Mensaje = '';

		IF NOT EXISTS (SELECT 1 FROM PROVEEDOR WHERE CODIGO = @Codigo AND ID_PROVEEDOR != @Id_Proveedor)
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM PROVEEDOR WHERE CEDULA = @Cedula AND ID_PROVEEDOR != @Id_Proveedor)
			BEGIN
				UPDATE PROVEEDOR 
				SET 
					CODIGO = @Codigo,
					NOMBRES = @Nombres_Proveedor,
					APELLIDOS = @Apellidos_Proveedor,
					CEDULA = @Cedula,
					TELEFONO = @Telefono,
					CORREO_ELECTRONICO = @Correo_Electronico,
					ESTADO = @Estado
				WHERE ID_PROVEEDOR = @Id_Proveedor;

				SET @Mensaje = 'Proveedor actualizado exitosamente.';
			END
			ELSE
			BEGIN
				SET @Resultado = 0;
				SET @Mensaje = 'Ya existe un proveedor con la misma c�dula.';
			END
		END
		ELSE
		BEGIN
			SET @Resultado = 0;
			SET @Mensaje = 'Ya existe un proveedor con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_PROVEEDOR(
@Id_Proveedor int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		IF NOT EXISTS (
			SELECT 1 
			FROM PROVEEDOR p 
			INNER JOIN COMPRA c ON p.ID_PROVEEDOR = c.ID_PROVEEDOR 
			WHERE p.ID_PROVEEDOR = @Id_Proveedor
		)
		BEGIN
			DELETE FROM PROVEEDOR WHERE ID_PROVEEDOR = @Id_Proveedor;
			SET @Mensaje = 'Proveedor eliminado exitosamente.';
		END
		ELSE
		BEGIN
			SET @Resultado = 1;
			SET @Mensaje = 'El proveedor se encuentra relacionado a una compra.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
[Id_Producto] int null,
[Precio_Compra] decimal(10,2) null,
[Precio_Venta] decimal (10,2) null,
[Cantidad] int null,
[Monto_Total] decimal (10,2) null
)
go

CREATE PROC PA_REGISTRAR_COMPRA(
@Id_Usuario int,
@Id_Proveedor int,
@Id_Transportista int,
@Id_Sucursal int,
@Tipo_Documento varchar(500),
@Numero_Documento varchar(500),
@Monto_Total decimal(10,2),
@Detalle_Compra [EDetalle_Compra] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
        DECLARE @Id_Compra INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION registro;

        INSERT INTO COMPRA (ID_USUARIO, ID_PROVEEDOR, ID_TRANSPORTISTA, ID_SUCURSAL, TIPO_DOCUMENTO, NUMERO_DOCUMENTO, MONTO_TOTAL)
        VALUES (@Id_Usuario, @Id_Proveedor, @Id_Transportista, @Id_Sucursal, @Tipo_Documento, @Numero_Documento, @Monto_Total);

        SET @Id_Compra = SCOPE_IDENTITY();

        INSERT INTO DETALLE_COMPRA (ID_COMPRA, ID_PRODUCTO, PRECIO_COMPRA, PRECIO_VENTA, CANTIDAD, MONTO_TOTAL)
        SELECT @Id_Compra, Id_Producto, Precio_Compra, Precio_Venta, Cantidad, Monto_Total
        FROM @Detalle_Compra;

        UPDATE p
        SET p.Stock = p.Stock + dc.Cantidad,
            p.Precio_Compra = dc.Precio_Compra,
            p.Precio_Venta = dc.Precio_Venta
        FROM PRODUCTO p
        INNER JOIN @Detalle_Compra dc ON dc.Id_Producto = p.ID_PRODUCTO;

        UPDATE i
        SET i.CANTIDAD = i.CANTIDAD + dc.CANTIDAD
        FROM INVENTARIO i
        INNER JOIN @Detalle_Compra dc ON i.ID_PRODUCTO = dc.ID_PRODUCTO;

        -- Asignar mensaje de �xito
        SET @Mensaje = 'Compra registrada con �xito';

        COMMIT TRANSACTION registro;
    END TRY
    BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION registro;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
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
@Id_Sucursal int,
@Id_Cliente int,
@Monto_Pago decimal(18,2),
@Monto_Cambio decimal(18,2),
@Monto_Total decimal(18,2),
@Descuento decimal (18,2),
@Detalle_Venta [EDetalle_Venta] READONLY,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		DECLARE @Id_Venta int = 0
		SET @Resultado = 1
		SET @Mensaje = ''

		BEGIN TRANSACTION registro;

		INSERT INTO VENTA(ID_USUARIO, TIPO_DOCUMENTO, NUMERO_DOCUMENTO, ID_SUCURSAL, ID_CLIENTE, MONTO_PAGO, MONTO_CAMBIO, MONTO_TOTAL, DESCUENTO)
		VALUES (@Id_Usuario, @Tipo_Documento, @Numero_Documento, @Id_Sucursal, @ID_Cliente, @Monto_Pago, @Monto_Cambio, @Monto_Total, @Descuento)

		SET @Id_Venta = SCOPE_IDENTITY()

		INSERT INTO DETALLE_VENTA(ID_VENTA, ID_PRODUCTO, PRECIO_VENTA, CANTIDAD_PRODUCTO, SUBTOTAL, DESCUENTO)
		SELECT @Id_Venta,IdProducto, PrecioVenta, Cantidad, SubTotal, Descuento FROM @Detalle_Venta

		update i set i.CANTIDAD = i.CANTIDAD - dv.CANTIDAD from INVENTARIO i
		INNER JOIN @Detalle_Venta dv ON i.ID_PRODUCTO = dv.IdProducto;

		-- Asignar mensaje de �xito
        SET @Mensaje = 'Venta registrada con �xito';

		COMMIT TRANSACTION registro;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION registro;
		SET @Resultado = 0
		SET @Mensaje = ERROR_MESSAGE()

	END CATCH
END;
go

CREATE PROC PA_REPORTE_COMPRA(
@Fecha_Inicio varchar(10),
@Fecha_Fin varchar(10),
@Id_Proveedor int,
@Id_Transportista int
)
AS
BEGIN
	SET DATEFORMAT dmy;
	SELECT convert(char(10), C.FECHA_COMPRA, 103)[FECHA_COMPRA], C.TIPO_DOCUMENTO, C.NUMERO_DOCUMENTO, C.MONTO_TOTAL,
	U.NOMBRE_COMPLETO[NOMBRE_USUARIO],
	PR.CODIGO[CODIGO], PR.NOMBRES[NOMBRE_PROVEEDOR],
	T.CODIGO[CODIGO_TRANSPORTISTA], T.NOMBRES[NOMBRE_TRANSPORTISTA],
	S.NOMBRE_SUCURSAL,
	P.CODIGO[CODIGO_PRODUCTO], P.NOMBRE_PRODUCTO, 
	CA.DESCRIPCION[CATEGORIA], 
	DC.PRECIO_COMPRA, DC.PRECIO_VENTA, DC.CANTIDAD, DC.MONTO_TOTAL[SUBTOTAL] FROM COMPRA C 
	inner join USUARIO U on U.ID_USUARIO = C.ID_USUARIO
	inner join PROVEEDOR PR on PR.ID_PROVEEDOR = C.ID_PROVEEDOR
	inner join TRANSPORTISTA T on T.ID_TRANSPORTISTA = C.ID_TRANSPORTISTA
	inner join SUCURSAL S on S.ID_SUCURSAL = C.ID_SUCURSAL
	inner join DETALLE_COMPRA DC on DC.ID_COMPRA = C.ID_COMPRA
	inner join PRODUCTO P on P.ID_PRODUCTO = DC.ID_PRODUCTO
	inner join CATEGORIA CA on CA.ID_CATEGORIA = P.ID_CATEGORIA
	WHERE convert(DATE, C.FECHA_COMPRA) between @Fecha_Inicio and @Fecha_Fin
	and PR.ID_PROVEEDOR = iif(@Id_Proveedor = 0, PR.ID_PROVEEDOR, @Id_Proveedor)
	and T.ID_TRANSPORTISTA = iif(@Id_Transportista = 0, T.ID_TRANSPORTISTA, @Id_Transportista)
END;
go

CREATE PROC PA_REPORTE_VENTA(
@fecha_Inicio varchar(10),
@fecha_Fin varchar(10)
)
AS
BEGIN
	SET DATEFORMAT dmy;
	SELECT convert(char(10), V.FECHA_VENTA, 103)[FECHA_VENTA], V.TIPO_DOCUMENTO, V.NUMERO_DOCUMENTO, V.MONTO_TOTAL, V.DESCUENTO,
	U.NOMBRE_COMPLETO[NOMBRE_USUARIO],
	S.NOMBRE_SUCURSAL,
	CL.CEDULA, CL.NOMBRES,
	P.CODIGO[CODIGO_PRODUCTO], P.NOMBRE_PRODUCTO, 
	CA.DESCRIPCION[CATEGORIA], 
	DV.PRECIO_VENTA, DV.CANTIDAD_PRODUCTO, DV.SUBTOTAL FROM VENTA V 
	inner join USUARIO U on U.ID_USUARIO = V.ID_USUARIO
	inner join DETALLE_VENTA DV on dv.ID_VENTA = v.ID_VENTA
	inner join PRODUCTO P on P.ID_PRODUCTO = DV.ID_PRODUCTO
	inner join CATEGORIA CA on CA.ID_CATEGORIA = P.ID_CATEGORIA
	inner join SUCURSAL S on S.ID_SUCURSAL = V.ID_SUCURSAL
	inner join CLIENTE CL on CL.ID_CLIENTE = V.ID_CLIENTE
	WHERE convert(date, v.FECHA_VENTA) between @fecha_Inicio and @fecha_Fin
END;
go

CREATE PROC PA_REGISTRAR_OFERTA(
@Codigo varchar(10),
@Nombre_Oferta varchar(50),
@Id_Producto int,
@Descripcion varchar(250),
@Fecha_Inicio datetime,
@Fecha_Fin datetime,
@Descuento decimal(5,2),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		-- Verificar si ya existe el c�digo
		IF NOT EXISTS (SELECT 1 FROM OFERTA WHERE CODIGO = @Codigo)
		BEGIN
			INSERT INTO OFERTA (CODIGO, NOMBRE_OFERTA, ID_PRODUCTO, DESCRIPCION, FECHA_INICIO, FECHA_FIN, DESCUENTO, ESTADO)
			VALUES (@Codigo, @Nombre_Oferta, @Id_Producto, @Descripcion, @Fecha_Inicio, @Fecha_Fin, @Descuento, @Estado);

			SET @Resultado = SCOPE_IDENTITY();
			SET @Mensaje = 'Oferta registrada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe una oferta con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
		SET @Resultado = 0
		SET @Mensaje = ERROR_MESSAGE()

	END CATCH
END;
go

CREATE PROC PA_EDITAR_OFERTA(
@Id_Oferta int,
@Codigo varchar(10),
@Nombre_Oferta varchar(50),
@Id_Producto int,
@Descripcion varchar(250),
@Fecha_Inicio datetime,
@Fecha_Fin datetime,
@Descuento decimal(5,2),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		-- Verificar si el c�digo ya existe para otra oferta
		IF NOT EXISTS (SELECT * FROM OFERTA WHERE CODIGO = @Codigo AND ID_OFERTA != @Id_Oferta)
		BEGIN
			UPDATE OFERTA
			SET 
				NOMBRE_OFERTA = @Nombre_Oferta,
				ID_PRODUCTO = @Id_Producto,
				DESCRIPCION = @Descripcion,
				FECHA_INICIO = @Fecha_Inicio,
				FECHA_FIN = @Fecha_Fin,
				DESCUENTO = @Descuento,
				ESTADO = @Estado
			WHERE ID_OFERTA = @Id_Oferta;

			SET @Resultado = 1;
			SET @Mensaje = 'Oferta actualizada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe una oferta con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
		SET @Resultado = 0
		SET @Mensaje = ERROR_MESSAGE()
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_OFERTA (
@Id_Oferta int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		SET @Resultado = 0;
		DELETE FROM OFERTA WHERE ID_OFERTA = @Id_Oferta;

		IF @@ROWCOUNT > 0
		BEGIN
			SET @Resultado = 1;
			SET @Mensaje = 'Oferta eliminada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'No se encontr� ninguna oferta con el ID especificado.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

/*CREATE PROC PA_EDITAR_RECLAMO(
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
        set @Mensaje = 'El estado del reclamo ha sido actualizado exitosamente.'
    end
    else
    begin
        set @Resultado = 0
        set @Mensaje = 'No se puede repetir el mismo ID del reclamo.'
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
        SET @Mensaje = 'El reclamo del cliente ha sido eliminada exitosamente.';
    end
    else
    begin
        set @Resultado = 0;
        set @Mensaje = 'No se encontr� ningun reclamo con el ID especificado.';
    end
end
go*/

CREATE PROC PA_REGISTRAR_SUCURSAL(
@Id_Negocio int,
@Codigo varchar(10),
@Nombre_Sucursal varchar(30),
@Direccion_Sucursal varchar(250),
@Latitud_Sucursal double precision,
@Longitud_Sucursal double precision,
@Ciudad_Sucursal varchar(30),
@Estado bit,
@Resultado int output,
@Mensaje varchar (500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		-- Verificar si ya existe una sucursal con el mismo c�digo
		IF NOT EXISTS (SELECT 1 FROM SUCURSAL WHERE CODIGO = @Codigo)
		BEGIN
			INSERT INTO SUCURSAL(ID_NEGOCIO, CODIGO, NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO)
			VALUES (@Id_Negocio, @Codigo, @Nombre_Sucursal, @Direccion_Sucursal, @Latitud_Sucursal, @Longitud_Sucursal, @Ciudad_Sucursal, @Estado);

			SET @Resultado = SCOPE_IDENTITY();
			SET @Mensaje = 'Sucursal registrada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe una sucursal con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_EDITAR_SUCURSAL(
@Id_Sucursal int,
@Codigo varchar(10),
@Nombre_Sucursal varchar(30),
@Direccion_Sucursal varchar(250),
@Latitud_Sucursal double precision,
@Longitud_Sucursal double precision,
@Ciudad_Sucursal varchar(30),
@Estado bit,
@Resultado bit output,
@Mensaje varchar (500) output
)
AS
BEGIN 
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		-- Verificar si el c�digo de la sucursal ya existe para otra sucursal
		IF NOT EXISTS (SELECT 1 FROM SUCURSAL WHERE CODIGO = @Codigo AND ID_SUCURSAL != @Id_Sucursal)
		BEGIN
			UPDATE SUCURSAL
			SET
				CODIGO = @Codigo,
				NOMBRE_SUCURSAL = @Nombre_Sucursal,
				DIRECCION_SUCURSAL = @Direccion_Sucursal,
				LATITUD_SUCURSAL = @Latitud_Sucursal,
				LONGITUD_SUCURSAL = @Longitud_Sucursal,
				CIUDAD_SUCURSAL = @Ciudad_Sucursal,
				ESTADO = @Estado
			WHERE ID_SUCURSAL = @Id_Sucursal;

			SET @Resultado = 1;
			SET @Mensaje = 'Sucursal actualizada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe una sucursal con el mismo c�digo.';
		END 

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_SUCURSAL (
@Id_Sucursal int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;

		DELETE FROM SUCURSAL WHERE ID_SUCURSAL = @Id_Sucursal;

		IF @@ROWCOUNT > 0
		BEGIN
			SET @Resultado = 1;
			SET @Mensaje = 'Sucursal eliminada exitosamente.';
		END
		ELSE
		BEGIN
			SET @Mensaje = 'No se encontr� ninguna sucursal con el ID especificado.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_REGISTRAR_TRANSPORTISTA(
@Codigo varchar(10),
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
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 0;
		SET @Mensaje = '';

		-- Validaci�n de duplicidad de C�digo y C�dula
		IF NOT EXISTS (SELECT 1 FROM TRANSPORTISTA WHERE CODIGO = @Codigo)
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM TRANSPORTISTA WHERE CEDULA = @Cedula)
			BEGIN
				INSERT INTO TRANSPORTISTA(CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, IMAGEN, ESTADO)
				VALUES (@Codigo, @Nombres, @Apellidos, @Cedula, @Telefono, @Correo_Electronico, @Imagen, @Estado);

				SET @Resultado = SCOPE_IDENTITY();
				SET @Mensaje = 'Transportista registrado exitosamente.';
			END
			ELSE
			BEGIN
				SET @Mensaje = 'Ya existe un transportista con la misma c�dula.';
			END
		END
		ELSE
		BEGIN
			SET @Mensaje = 'Ya existe un transportista con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_EDITAR_TRANSPORTISTA(
@Id_Transportista int,
@Codigo varchar(30),
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
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 1;
		SET @Mensaje = '';

		-- Validaci�n de duplicidad de C�digo y C�dula
		IF NOT EXISTS (SELECT 1 FROM TRANSPORTISTA WHERE CODIGO = @Codigo AND ID_TRANSPORTISTA != @Id_Transportista)
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM TRANSPORTISTA WHERE CEDULA = @Cedula AND ID_TRANSPORTISTA != @Id_Transportista)
			BEGIN
				UPDATE TRANSPORTISTA
				SET
					CODIGO = @Codigo,
					NOMBRES = @Nombres,
					APELLIDOS = @Apellidos,
					CEDULA = @Cedula,
					TELEFONO = @Telefono,
					CORREO_ELECTRONICO = @Correo_Electronico,
					IMAGEN = @Imagen,
					ESTADO = @Estado
				WHERE ID_TRANSPORTISTA = @Id_Transportista;

				SET @Mensaje = 'Transportista actualizado exitosamente.';
			END
			ELSE
			BEGIN
				SET @Resultado = 0;
				SET @Mensaje = 'Ya existe un transportista con la misma c�dula.';
			END
		END
		ELSE
		BEGIN
			SET @Resultado = 0;
			SET @Mensaje = 'Ya existe un transportista con el mismo c�digo.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_ELIMINAR_TRANSPORTISTA (
@Id_Transportista int,
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		SET @Resultado = 1;
		SET @Mensaje = '';

		DELETE FROM TRANSPORTISTA WHERE ID_TRANSPORTISTA = @Id_Transportista;

		IF @@ROWCOUNT > 0
		BEGIN
			SET @Mensaje = 'Transportista eliminado exitosamente.';
		END
		ELSE
		BEGIN
			SET @Resultado = 0;
			SET @Mensaje = 'No se encontr� ning�n transportista con el ID especificado.';
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		--Manejo de errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();		
	END CATCH
END;
go

CREATE PROC PA_EDITAR_NEGOCIO(
@Id_Negocio int,
@Nombre varchar(60),
@Telefono varchar(10),
@Ruc varchar(13),
@Direccion varchar(60),
@Correo_Electronico varchar(40),
@Resultado bit output,
@Mensaje varchar(500) output
)
AS
BEGIN
    BEGIN TRY
		BEGIN TRANSACTION;

        SET @Resultado = 0;
        SET @Mensaje = '';

        IF NOT EXISTS (SELECT 1 FROM NEGOCIO WHERE ID_NEGOCIO = @Id_Negocio)
        BEGIN
            SET @Mensaje = 'El negocio con el ID proporcionado no existe.';
            RETURN;
        END

        UPDATE NEGOCIO
        SET 
            NOMBRE = @Nombre,
            TELEFONO = @Telefono,
            RUC = @Ruc,
            DIRECCION = @Direccion,
            CORREO_ELECTRONICO = @Correo_Electronico
        WHERE 
            ID_NEGOCIO = @Id_Negocio;

        IF @@ROWCOUNT = 0
        BEGIN
            SET @Mensaje = 'No se realizaron cambios en la informaci�n del negocio.';
        END
        ELSE
        BEGIN
            SET @Resultado = 1;
            SET @Mensaje = 'La informaci�n del negocio fue actualizada exitosamente.';
        END

		COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Capturar errores
		ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;
go

/*Inserciones necesarias para que la aplicaci�n funcione*/
go
INSERT INTO ROL (DESCRIPCION) VALUES('Administrador');
go
INSERT INTO ROL (DESCRIPCION) VALUES ('Empleado');
go
INSERT INTO USUARIO (CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, ID_ROL, ESTADO) VALUES ('00001', 'Abraham Andres Farfan Sanchez', 'hermanosfarfan@gmail.com', HASHBYTES('SHA2_256', 'jawi2010.'), NEWID(), 1, 1);
go
INSERT INTO USUARIO (CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, ID_ROL, ESTADO) VALUES ('00002', 'Maria Belen Becerra Lopez', 'belencita@gmail.com', HASHBYTES('SHA2_256', '1234abcd-'), NEWID(), 2, 1);
go
INSERT INTO USUARIO (CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, ID_ROL, ESTADO) VALUES ('00003', 'Mateo Jose Alvarado Noboa', 'luispro@gmail.com', HASHBYTES('SHA2_256', 'tierra123/'), NEWID(), 1, 0);
go
INSERT INTO USUARIO (CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, ID_ROL, ESTADO) VALUES ('00004', 'Jose Maria Velazco Torres', 'jose@gmail.com', HASHBYTES('SHA2_256', '12_julio'), NEWID(), 2, 1);
go
INSERT INTO USUARIO (CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, CLAVE_SALT, ID_ROL, ESTADO) VALUES ('00005', 'Esteban Leonardo Leon Marcillo', 'leonardo128@gmail.com', HASHBYTES('SHA2_256', 'freefire_04'), NEWID(), 2, 0);
go
INSERT INTO PERMISO (ID_ROL,NOMBRE_MENU) VALUES
(1,'MenuUsuarios'),
(1,'MenuInventario'),
(1,'MenuVentas'),
(1,'MenuCompras'),
(1,'MenuProveedores'),
(1,'MenuTransportistas'),
(1,'MenuSucursales'),
(1,'MenuClientes'),
(1,'MenuReportes'),
(1,'MenuOfertas'),
(1,'MenuReclamos'),
(1,'MenuAcercaDe');
go
INSERT INTO PERMISO (ID_ROL,NOMBRE_MENU) VALUES
(2,'MenuVentas'),
(2,'MenuCompras'),
(2,'MenuProveedores'),
(2,'MenuTransportistas'),
(2,'MenuClientes'),
(2,'MenuOfertas'),
(2,'MenuReclamos'),
(2,'MenuAcercaDe');
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('6564', 'Frutas y Verduras',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('7845', 'Despensa',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('1247', 'Preparados',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('0786', 'Bebidas y Licores',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('3472', 'Refrigerados',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('1308', 'Congelados',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('6832', 'Carnes',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('1375', 'Embutidos',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('3529', 'Panaderia',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('4839', 'Mascotas',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('3098', 'Cuidado Personal',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('4802', 'Cuidado del Hogar',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('6796', 'Electrodom�sticos',1);
go
INSERT INTO CATEGORIA(CODIGO, DESCRIPCION, ESTADO) VALUES ('1378', 'Jarnideria y Plantas',1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('4542', 'Tonelada', 't', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('7676', 'Quintal', 'q', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('0865', 'Kilogramo', 'kg', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('1254', 'Libra', 'lb', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('2328', 'Gramo', 'g', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('9631', 'Litro', 'L', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('3484', 'Gal�n', 'G', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('8610', 'Metro', 'm', 1);
go
INSERT INTO UNIDAD_MEDIDA (CODIGO, DESCRIPCION, SIMBOLO, ESTADO) VALUES('8931', 'Cent�metro', 'cm', 1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('6634','Papel Higienico','8 unidades',12,3,'Ecuador',0);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('7874','Cocina Indurama','Color gris',13,3,'China',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('0784','Caja de Banano','20 Kg',1,3,'Ecuador',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('2256','Sillas Plasticas','Fibra de carbono',12,3,'Ecuador',0);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('4621','Vino Blanco','Elaborado en 1978',4,6,'Espa�a',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('0674','Television LG','Color negro',13,8,'Jap�n',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('7425','Caja de Cereza','Cerezas extra grandes',1,3,'Chile',1);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('7632','Clorox','1 Litro',12,6,'Ecuador',0);
go
INSERT INTO PRODUCTO (CODIGO, NOMBRE_PRODUCTO, DESCRIPCION, ID_CATEGORIA, ID_UNIDAD_MEDIDA, PAIS_ORIGEN, ESTADO) VALUES('1346','Semillas de Manzano','8 unidades',14,5,'Estados Unidos',1);
go
INSERT INTO CLIENTE (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES ('3621','Javier Mateo','Lopez Molina','0987654321','0912345678','javierito@gmail.com',1);
go
INSERT INTO CLIENTE (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES ('8952','Julio Andres','Mata Rodriguez','0975312468','0986421357','julito@gmail.com',1);
go
INSERT INTO CLIENTE (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES ('1098','Emily Sofia','Andrade Sanchez','0914237898','0957143210','emily@gmail.com',1);
go
INSERT INTO PROVEEDOR (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES ('0710','Manolo Sebastian','Pilligua Montalvo','0981441455','0956262748','manolito@gmail.com',1);
go
INSERT INTO PROVEEDOR (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES ('1012','Alonso Luis','Hincapie Zambrano','0975462351','0981893637','juanito@gmail.com',1);
go
INSERT INTO PROVEEDOR (CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO) VALUES ('1267','Sebastian Andres','Gonzales Lopez','0951135233','0936472943','sagl@gmail.com',1);
go
INSERT INTO NEGOCIO (NOMBRE, TELEFONO, RUC, DIRECCION, CORREO_ELECTRONICO) VALUES('Supermercado Paradisia','0969810812','0102030405785','Mucho Lote 3 etapa','SupermercadoParadisia@gmail.com');
go
INSERT INTO ZONA_ALMACEN(NOMBRE_ZONA, LIMITE_ESPACIOS, ESTADO) VALUES ('Zona-Norte', 200, 1);
go
INSERT INTO ZONA_ALMACEN(NOMBRE_ZONA, LIMITE_ESPACIOS, ESTADO) VALUES ('Zona-Sur', 200, 1);
go
INSERT INTO ZONA_ALMACEN(NOMBRE_ZONA, LIMITE_ESPACIOS, ESTADO) VALUES ('Zona-Este', 200, 1);
go
INSERT INTO ZONA_ALMACEN(NOMBRE_ZONA, LIMITE_ESPACIOS, ESTADO) VALUES ('Zona-Oeste', 200, 1);
go
INSERT INTO ZONA_ALMACEN(NOMBRE_ZONA, LIMITE_ESPACIOS, ESTADO) VALUES ('Zona-Central', 200, 1);
go
/*INSERT INTO RECLAMO (ID_CLIENTE, NOMBRE_CLIENTE, CORREO_ELECTRONICO_CLIENTE, DESCRIPCION, ESTADO) VALUES(1,'Javier Mateo','javierito@gmail.com','Compre unas cajas de bananos y algunas bananas me vinieron negras, exijo una devolucion.',1);
go
INSERT INTO RECLAMO (ID_CLIENTE, NOMBRE_CLIENTE, CORREO_ELECTRONICO_CLIENTE, DESCRIPCION, ESTADO) VALUES(2,'Julio Andres','julito@gmail.com','El televisor LG que compre no me vino con el soporte y los tornillos para ponerlo en la pared.',0);
go
INSERT INTO RECLAMO (ID_CLIENTE, NOMBRE_CLIENTE, CORREO_ELECTRONICO_CLIENTE, DESCRIPCION, ESTADO) VALUES(2,'Julio Andres','julito@gmail.com','Cuando compre la cocina decia que venia con un set de ollas pero al momento de la entrega no me vino eso.',0);
go*/
INSERT INTO SUCURSAL (ID_NEGOCIO, CODIGO, NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO) VALUES (1, '7247', 'SUCURSAL_9 DE OCT y LOS RIOS','AV. 9 DE OCTUBRE 803 Y LOS RIOS',-2.187746,-79.894365,'Guayaquil',1);
go
INSERT INTO SUCURSAL (ID_NEGOCIO, CODIGO, NOMBRE_SUCURSAL, DIRECCION_SUCURSAL, LATITUD_SUCURSAL, LONGITUD_SUCURSAL, CIUDAD_SUCURSAL, ESTADO) VALUES (1, '6584','SUCURSAL_ALBANBORJA','AV.CARLOS JULIO AROSEMENA S/N',-2.169321,-79.917047,'Guayaquil',0);