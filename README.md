# Mini API Clientes (Opción A)
Elección: Opción A — Mini API en ASP.NET Core (.NET 6)

## Descripción
API ligera para administrar una lista de clientes en memoria (sin base de datos). Implementa las funcionalidades mínimas solicitadas: registrar clientes, listar todos, buscar por RFC, filtrar por estatus y cambiar el estatus.

### Entidad Cliente
Cada cliente tiene las siguientes propiedades:

* Id (Guid)
* Nombre (string)
* RFC (string)
* Ejecutivo (string)
* Estatus (string)
* TipoCliente (string)

### Requisitos
* .NET 6 SDK: https://dotnet.microsoft.com/download/dotnet/6.0
* Visual Studio 2022 o Visual Studio Code (opcional).
* (Opcional) curl para pruebas desde la terminal.

### Funcionalidades mínimas implementadas
1. Registrar un cliente.
2. Consultar todos los clientes.
3. Buscar clientes por RFC.
4. Filtrar clientes por estatus.
5. Validar que no se registren clientes con RFC duplicado (retorna 409 Conflict).
6. Cambiar el estatus de un cliente.

## Endpoints (resumen y comportamiento esperado)

### GET /clientes
* Devuelve todos los clientes.
* Respuesta: 200 OK con array (puede ser []).

### GET /clientes/{rfc}
* Busca clientes por RFC (case-insensitive).
* Respuesta: 200 OK con lista de coincidencias o 404 Not Found si no hay.

### GET /clientes/estatus/{estatus}
* Filtra clientes por estatus (case-insensitive).
* Respuesta: 200 OK con array filtrado.

### POST /clientes
* Registra nuevo cliente. Body JSON:

```
{
  "nombre": "ACME",
  "rfc": "XAXX010101000",
  "ejecutivo": "Ana",
  "estatus": "Activo",
  "tipoCliente": "Corporativo"
}
```
### Respuestas:
* 201 Created con el recurso creado y cabecera Location.
* 409 Conflict si ya existe un cliente con el mismo RFC.

### PUT /clientes/{id}/estatus
* Cambia estatus de cliente por id. Body JSON:

```
{ "estatus": "Inactivo" }
```
* Respuestas:
  *  200 OK con cliente actualizado.
  *  404 Not Found si no existe el id.
 
## Ejecutar la aplicación

### Desde Visual Studio
1. Abre la solución/proyecto en Visual Studio.
2. Marca el proyecto como proyecto de inicio.
3. Presiona F5 (depurador) o Ctrl+F5 (sin depurador).
4. Abre Swagger en https://localhost:{PUERTO}/swagger.

Desde la línea de comandos (CLI)
En la carpeta donde está el .csproj:
```
dotnet restore
dotnet build
dotnet run
```
La salida mostrará la URL/puerto de escucha (ej. https://localhost:5001).

## Mejoras futuras sugeridas
* Persistencia real con EF Core y base de datos (SQL Server / SQLite).
* Validación avanzada con FluentValidation.
* Pruebas unitarias e integración (xUnit, WebApplicationFactory).
* Paginación, búsqueda parcial y ordenamiento en GET /clientes.
* Autenticación/Autorización (JWT).
* Logging estructurado (Serilog / Application Insights).
* Colección Postman/Insomnia y ejemplos ampliados.
