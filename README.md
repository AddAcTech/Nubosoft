## Pasos para ejecutar el proyecto

1. Abrir el archivo `Nubosoft.sln` en Visual Studio 2019 o superior.

2. Verificar que la cadena de conexión en `Web.config` apunte a tu servidor SQL Server ():

   Puedes usar el nombre del equipo o una dirección IP.

3. Compilar la solución.

4. Abrir la consola del Administrador de paquetes:
- Menú `Ver → Otras ventanas → Consola del Administrador de paquetes`.

5. Ejecutar los siguientes comandos para crear la base de datos:
  - Enable-Migrations # Solo la primera vez 
  - Add-Migration Start 
  - Update-Database
  
6. Ejecutar el proyecto (`F5`) y se abrirá directamente en la página de usuarios.

7. Puedes agregar, editar y eliminar usuarios desde la interfaz web.


