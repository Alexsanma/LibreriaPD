# Distribución del trabajo — 4 integrantes

Equipo: **Sara, Robledo, Tobón, Alexander**

La idea es que cada integrante tenga una parte **independiente** (toca archivos distintos, sin
pisarse) pero que todos trabajen sobre la **misma base** de Clean Architecture + DDD + CQRS.

## Resumen

| Integrante | Parte | Archivos que le corresponden | Rama sugerida |
|-----------|-------|------------------------------|---------------|
| **Alexander** | Base compartida + integración | `Domain/*`, `Infrastructure/*`, `Application/Common/*`, `WebApi/*`, migración inicial | `main` / `chore/base` |
| **Sara** | Query 1 – Consultar todos los libros | `Application/Books/Queries/GetAllBooks/GetAllBooksQueryHandler.cs` | `feature/query1-sara` |
| **Robledo** | Query 2 – Consultar libro por ID | `Application/Books/Queries/GetBookById/GetBookByIdQueryHandler.cs` | `feature/query2-robledo` |
| **Tobón** | Query 3 – Consultar libros por categoría | `Application/Books/Queries/GetBooksByCategory/GetBooksByCategoryQueryHandler.cs` | `feature/query3-tobon` |

## Detalle por integrante

### Alexander — Base compartida (ya hecha)
Monta el esqueleto que usa todo el equipo, para que los demás solo implementen su consulta:
- Solución y 4 proyectos (Domain, Application, Infrastructure, WebApi) con la regla de dependencias correcta.
- **Domain**: entidades `Book`, `Author`, `Category` (estilo DDD, con `BaseEntity`).
- **Application (común)**: abstracción `IApplicationDbContext` y registro de MediatR.
- **Infrastructure**: `ApplicationDbContext`, configuraciones EF Core y **datos de ejemplo** (seed).
- **WebApi**: `Program.cs`, `BooksController` (los 3 endpoints ya cableados a MediatR) y Swagger.
- **Git/GitHub**: repositorio, `.gitignore`, ramas y la **migración inicial** (`InitialCreate`).
> Detalle en [`Alex.md`](Alex.md).

### Sara — Query 1: Consultar todos los libros
Implementar el método `Handle` de `GetAllBooksQueryHandler` para devolver **todos** los libros
(Id, Título, ISBN, Año, Autor, Categoría) como `List<BookListDto>`.
El endpoint `GET /api/books` y el DTO ya están listos; solo falta la consulta EF Core.
> Guía y solución en [`Sara.md`](Sara.md).

### Robledo — Query 2: Consultar un libro por ID
Implementar `GetBookByIdQueryHandler.Handle` para devolver el **detalle** de un libro por su `Id`
(incluyendo autor y categoría) como `BookDetailDto`, o `null` si no existe (el controlador responde 404).
El endpoint `GET /api/books/{id}` y el DTO ya están listos.
> Guía y solución en [`Robledo.md`](Robledo.md).

### Tobón — Query 3: Consultar libros por categoría
Implementar `GetBooksByCategoryQueryHandler.Handle` para devolver los libros de una categoría
(`categoryId`) como `List<BookListDto>`.
El endpoint `GET /api/books/category/{categoryId}` ya está listo.
> Guía y solución en [`Tobon.md`](Tobon.md).

## ¿Cómo encaja cada parte en la arquitectura?

Todos implementan lo mismo conceptualmente (un **handler CQRS** que consulta con EF Core a través
de `IApplicationDbContext` y proyecta a un **DTO**), así que cada quien practica el patrón completo:

```
HTTP  →  BooksController  →  MediatR (ISender.Send)  →  [TU Query]Handler  →  IApplicationDbContext (EF Core)  →  DTO  →  JSON
```

## Orden recomendado

1. **Alex** sube la base a GitHub y crea la migración inicial (`main` funcionando).
2. Cada quien hace `git pull`, crea su rama y implementa **su** handler.
3. Prueban su endpoint en Swagger.
4. Pull Request a `main` y revisión entre compañeros.
