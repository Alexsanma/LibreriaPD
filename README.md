# Biblioteca – Catálogo

API REST para consultar el catálogo de una biblioteca (libros, autores y categorías).
Proyecto de la materia Programación Distribuida, hecho con **.NET 8** siguiendo
**Clean Architecture + CQRS** y usando **SQL Server (EF Core)** como base de datos.

Por ahora es solo de consulta: no se crea, edita ni elimina información.

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/books` | Lista todos los libros |
| GET | `/api/books/{id}` | Detalle de un libro por su Id |
| GET | `/api/books/category/{categoryId}` | Libros de una categoría |

## Estructura

El código está en `BibliotecaCatalogo/` y respeta la regla de dependencias
WebApi → Infrastructure → Application → Domain:

```
BibliotecaCatalogo/
└── src/
    ├── BibliotecaCatalogo.Domain          # Entidades del negocio (Book, Author, Category)
    ├── BibliotecaCatalogo.Application      # Casos de uso: queries y handlers con MediatR
    ├── BibliotecaCatalogo.Infrastructure   # EF Core + SQL Server y datos de ejemplo
    └── BibliotecaCatalogo.WebApi           # API REST y configuración (punto de entrada)
```

## Requisitos

- .NET SDK 8.0
- SQL Server LocalDB (viene con Visual Studio) o cualquier instancia de SQL Server
- Opcional, solo si vas a crear migraciones: `dotnet tool install --global dotnet-ef`

## Cómo ejecutar

1. Clona el repositorio.
2. Ejecuta la API:
   ```bash
   dotnet run --project BibliotecaCatalogo/src/BibliotecaCatalogo.WebApi --launch-profile https
   ```
   Al iniciar, la aplicación crea la base de datos y carga los datos de ejemplo automáticamente.
3. Abre Swagger en `https://localhost:7080/swagger`.

La cadena de conexión está en `BibliotecaCatalogo/src/BibliotecaCatalogo.WebApi/appsettings.json`
y por defecto usa LocalDB. Si trabajas con otra instancia, cámbiala ahí.

## Datos de ejemplo

Se siembran 4 autores, 4 categorías y 7 libros. Algunos ejemplos para probar:

- `GET /api/books` → los 7 libros
- `GET /api/books/5` → *Clean Code*
- `GET /api/books/category/2` → libros de Fantasía (*El Hobbit*, *El Señor de los Anillos*)
