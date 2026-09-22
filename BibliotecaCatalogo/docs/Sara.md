# Sara — Query 1: Consultar todos los libros

**Endpoint (ya listo):** `GET /api/books`
**Archivo a completar:** `src/BibliotecaCatalogo.Application/Books/Queries/GetAllBooks/GetAllBooksQueryHandler.cs`

## Objetivo
Devolver **todos** los libros del catálogo como `List<BookListDto>`, incluyendo el nombre del
autor y de la categoría.

## Qué ya está hecho por ti
- `GetAllBooksQuery` (la query, sin parámetros).
- `BookListDto` (Id, Title, Isbn, PublicationYear, Author, Category).
- El endpoint en `BooksController.GetAll`.

Solo tienes que implementar el método `Handle` del handler.

## Pasos
1. Usa `_context.Books` (viene de `IApplicationDbContext`).
2. Como es solo lectura, agrega `.AsNoTracking()`.
3. Proyecta con `.Select(...)` a `BookListDto` (así EF trae solo las columnas necesarias y resuelve el autor/categoría con un JOIN, sin `.Include`).
4. Materializa con `.ToListAsync(cancellationToken)`.

## Solución de referencia
```csharp
public async Task<List<BookListDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
{
    return await _context.Books
        .AsNoTracking()
        .Select(b => new BookListDto
        {
            Id = b.Id,
            Title = b.Title,
            Isbn = b.Isbn,
            PublicationYear = b.PublicationYear,
            Author = b.Author!.FullName,
            Category = b.Category!.Name
        })
        .ToListAsync(cancellationToken);
}
```
(Recuerda que arriba del archivo ya están los `using` de `Microsoft.EntityFrameworkCore` e `IApplicationDbContext`.)

## Cómo probar
1. `git checkout -b feature/query1-sara`
2. Implementa el método y ejecuta `dotnet run --project src/BibliotecaCatalogo.WebApi`.
3. En Swagger, ejecuta `GET /api/books` → deben salir los 7 libros de ejemplo.
4. Commit y push:
   ```bash
   git commit -am "feat(books): Query 1 - consultar todos los libros"
   git push -u origin feature/query1-sara
   ```
