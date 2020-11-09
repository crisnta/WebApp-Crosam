# Proyecto crosam

Para crear el proyecto desde inicio ejecuta los siguientes comandos:

Crear un nuevo proyecto mvc con autenticación Individual e ingresar al directorio
```bash
dotnet new mvc -n crosam --auth Individual 
cd crosam
```
Agregar un archivo gitignore al proyecto
```bash
dotnet new gitignore 
```
Inicializar el repositorio y hacer commit
```bash
git init 
git add add .
git commit -m "Versión Inicial"
```
Eliminar la base de datos
```bash
dotnet ef database drop
```
Eliminar las Migraciones
```bash
dotnet ef migrations remove
```
Agregar nueva migración
```bash
dotnet ef migrations add "nueva migración" -o Data/Migrations
```
Crear la base de datos
```bash
dotnet ef database update
```

## Herramientas instaladas
Listar las herramientas instaladas en el sistema extendida de dotnet de manera global
```bash
dotnet tool list --global
```

a