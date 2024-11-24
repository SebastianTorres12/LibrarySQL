# SOAP Server and Client

Este proyecto consiste en un servicio WCF para la gestión de una base de datos SQL, acompañado de un cliente en consola para interactuar con el servicio. El proyecto está desarrollado en Visual Studio 2022 y utiliza Docker para la base de datos.

## Prerrequisitos

- Visual Studio 2022
- Docker

## Configuración del Proyecto

Para configurar y ejecutar el proyecto correctamente, sigue estos pasos:

1. **Clonar el repositorio**

   Clona el repositorio a tu máquina local.

   ```bash
   git clone https://github.com/tu_usuario/tu_repositorio.git
   cd tu_repositorio
2. **Configurar Docker**
   Asegúrate de que Docker esté instalado y en funcionamiento. Utiliza el siguiente comando para iniciar la base de datos en Docker:
   ```bash
   docker run --name sqlserver -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=tu_contraseña_segura' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
3. **Abrir la solución en Visual Studio 2022**
   Abre LibrarySQL.sln en Visual Studio 2022.
4. **Configurar múltiples proyectos de inicio**
   Para ejecutar tanto el servicio WCF como el cliente en consola al mismo tiempo, sigue estos pasos:
   - Haz clic derecho en la solución LibrarySQL en el Explorador de Soluciones y selecciona Propiedades.
   - En la ventana de propiedades, selecciona Página de propiedades comunes > Proyectos de inicio.
   - Selecciona la opción Varios proyectos de inicio.
   - Establece las acciones en Iniciar tanto para ClientSQLService como para LibrarySQL.
5. **Actualizar cadenas de conexion**
   Asegúrate de que las cadenas de conexión en los archivos de configuración de LibrarySQL apunten a la instancia de SQL Server en Docker. La cadena de conexión debería ser algo como:
    ```bash
    <connectionStrings>
    <add name="LibrarySQLDb" connectionString="Server=localhost,1433;Database=LibrarySQLDb;User Id=sa;Password=tu_contraseña_segura;" providerName="System.Data.SqlClient" />
    </connectionStrings>
6. **Ejecutar el proyecto**
   Una vez configurado, puedes ejecutar el proyecto siguiendo estos pasos:
- En Visual Studio, selecciona Debug > Iniciar sin depuración o presiona Ctrl + F5. Esto iniciará tanto el servicio WCF (LibrarySQL) como el cliente en consola (ClientSQLService).
- El cliente en consola (ClientSQLService) te permitirá interactuar con el servicio WCF (LibrarySQL). Sigue las instrucciones en consola para realizar operaciones en la base de datos.

### ¡Gracias por utilizar LibrarySQL!

