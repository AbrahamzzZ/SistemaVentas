# Sistema de Ventas

Aplicación de escritorio para administrar las operaciones de un negocio minorista. Permite gestionar ventas, compras, inventario, productos, clientes, proveedores, sucursales, usuarios y permisos desde una interfaz Windows Forms.

## Funcionalidades

- Registro y consulta de ventas y compras, con sus respectivos detalles.
- Administración de productos, categorías, unidades de medida, ofertas e inventario.
- Gestión de clientes, proveedores, transportistas y sucursales.
- Administración de usuarios, roles y permisos.
- Generación de reportes en PDF y Excel, y consulta de estadísticas.
- Configuración de la información del negocio.

## Tecnologías

- C# y Windows Forms sobre .NET 10.
- SQL Server para la persistencia de datos.
- MSTest y Moq para las pruebas automatizadas.

La solución está organizada en los siguientes proyectos:

| Proyecto | Responsabilidad |
| --- | --- |
| `Presentacion` | Interfaz de escritorio Windows Forms. |
| `Negocios` | Reglas de negocio y validaciones. |
| `Datos` | Acceso a SQL Server. |
| `Entidad` | Entidades y modelos de datos. |
| `Test` | Pruebas unitarias de la capa de negocio. |

## Requisitos

- Windows.
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- [Visual Studio 2026](https://visualstudio.microsoft.com/es/downloads/) con la carga de trabajo **Desarrollo de escritorio de .NET**, si se desea trabajar desde el IDE.
- SQL Server, por ejemplo SQL Server Express o LocalDB.
- `sqlcmd` para ejecutar el script de creación de la base de datos.
- Git para clonar el repositorio.

Para ejecutar una versión ya compilada, se necesita .NET 10 Desktop Runtime en lugar del SDK.

## Obtener el código

```powershell
git clone https://github.com/AbrahamzzZ/AppBuyWindows.git
cd AppBuyWindows
```

## Configurar la base de datos

El script [`App/Database/DB_SISTEMA_VENTAS.sql`](App/Database/DB_SISTEMA_VENTAS.sql) crea la base de datos `Sistema_Ventas`, sus tablas, procedimientos almacenados y datos de ejemplo.

Con autenticación de Windows, ejecute el siguiente comando desde la raíz del repositorio y reemplace el servidor por el nombre de su instancia:

```powershell
sqlcmd -S "localhost\SQLEXPRESS" -E -f 1252 -i "App/Database/DB_SISTEMA_VENTAS.sql"
```

El parámetro `-f 1252` permite conservar correctamente los caracteres acentuados del script. La cuenta de Windows que ejecuta `sqlcmd` debe tener permisos para crear la base de datos.

## Configurar la conexión

La aplicación busca la cadena de conexión en la variable de entorno `SISTEMA_VENTAS_DB`. Si la variable no está definida, utiliza la entrada `ConexionBD` de `App/Presentacion/App.config`.

Para una ejecución desde PowerShell, puede definir la variable en la sesión actual:

```powershell
$env:SISTEMA_VENTAS_DB = "Server=localhost\SQLEXPRESS;Database=Sistema_Ventas;Integrated Security=True;TrustServerCertificate=True"
```

Después, inicie la aplicación desde esa misma sesión. Para conservar la configuración entre sesiones, defina la variable de entorno desde la configuración de Windows.

Como alternativa, configure la cadena en la sección `connectionStrings` de `App/Presentacion/App.config`:

```xml
<connectionStrings>
  <add name="ConexionBD"
       connectionString="Server=localhost\SQLEXPRESS;Database=Sistema_Ventas;Integrated Security=True;TrustServerCertificate=True;"
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

Si usa autenticación de SQL Server, reemplace la autenticación integrada por las credenciales correspondientes. No publique contraseñas ni cadenas de conexión con credenciales en el repositorio.

## Recuperación de contraseña

La recuperación envía un código de un solo uso al correo registrado del usuario. El código vence en 15 minutos, se almacena como hash y se invalida al cambiar la contraseña. Se permiten como máximo cinco intentos de verificación por código.

Las contraseñas se almacenan con PBKDF2-HMAC-SHA-256, 600 000 iteraciones, una sal aleatoria de 16 bytes y un resultado de 32 bytes. El algoritmo y el número de iteraciones se guardan junto a la sal para identificar los parámetros de cada clave. Las cuentas de bases existentes creadas con el formato anterior deberán restablecer su contraseña para poder iniciar sesión.

Para una base existente, ejecute una sola vez en SQL Server:

```sql
IF COL_LENGTH('dbo.USUARIO', 'TOKEN_RECUPERACION_EXPIRA') IS NULL
    ALTER TABLE dbo.USUARIO ADD TOKEN_RECUPERACION_EXPIRA datetime2 NULL;

IF COL_LENGTH('dbo.USUARIO', 'INTENTOS_RECUPERACION') IS NULL
    ALTER TABLE dbo.USUARIO ADD INTENTOS_RECUPERACION tinyint NOT NULL
        CONSTRAINT DF_USUARIO_INTENTOS_RECUPERACION DEFAULT 0;
```

Configure el SMTP con variables de entorno antes de iniciar la aplicación:

| Variable | Uso |
| --- | --- |
| `SISTEMA_VENTAS_SMTP_HOST` | Servidor SMTP. |
| `SISTEMA_VENTAS_SMTP_FROM` | Dirección remitente autorizada por el servidor. |
| `SISTEMA_VENTAS_SMTP_USER` | Usuario SMTP; opcional si el servidor no requiere autenticación. |
| `SISTEMA_VENTAS_SMTP_PASSWORD` | Contraseña SMTP; debe configurarse junto con el usuario. |
| `SISTEMA_VENTAS_SMTP_PORT` | Puerto; por defecto `587`. |
| `SISTEMA_VENTAS_SMTP_ENABLE_SSL` | Habilita TLS; por defecto `true`. |

No agregue credenciales SMTP al repositorio. Como esta aplicación de escritorio necesita acceder a la configuración SMTP desde el equipo donde se ejecuta, este enfoque es apropiado para un entorno controlado o académico; para producción distribuida, el envío debe realizarlo un servicio backend que mantenga las credenciales fuera de los equipos cliente.

## Compilar y ejecutar

Desde la raíz del repositorio, restaure las dependencias y compile la solución:

```powershell
dotnet build App/SistemaVenta.sln
```

Para iniciar la aplicación:

```powershell
dotnet run --project App/Presentacion/Presentacion.csproj
```

También puede abrir `App/SistemaVenta.sln` en Visual Studio, establecer `Presentacion` como proyecto de inicio y ejecutar la solución.

## Pruebas

Las pruebas unitarias de la capa de negocio usan mocks para la capa de datos y no requieren conectarse a SQL Server:

```powershell
dotnet test App/Test/Test.csproj
```

## Documentación adicional

En [`Docs`](Docs/) se encuentran los manuales y documentos del proyecto, incluidos el [manual de usuario](<Docs/MANUAL DE USUARIO GRUPO-B.docx>), el [manual técnico](<Docs/MANUAL TECNICO GRUPO-B.docx>), el [documento de instalación](<Docs/DOCUMENTO DE INSTALACIÓN DEL SOFTWARE GRUPO-B.docx>), los requerimientos y el plan de pruebas.

## Licencia

Este proyecto se distribuye bajo la licencia MIT. Consulte [`LICENSE`](LICENSE) para ver sus términos.
