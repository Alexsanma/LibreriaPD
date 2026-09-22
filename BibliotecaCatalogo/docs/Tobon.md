# Tobón — Query 3: Consultar libros por categoría

**Endpoint (ya listo):** `GET /api/books/category/{categoryId}`
**Archivo a completar:** `src/BibliotecaCatalogo.Application/Books/Queries/GetBooksByCategory/GetBooksByCategoryQueryHandler.cs`

## Objetivo
Devolver los libros que pertenecen a una categoría (`categoryId`) como `List<BookListDto>`
(mismo formato de listado que la Query 1 de Sara).

## Qué ya está hecho por ti
- `GetBooksByCategoryQuery(int CategoryId)`.
- Reutilizas `BookListDto` (definido en la carpeta `GetAllBooks`).
- El endpoint en `BooksController.GetByCategory`.

## Pasos
1. Parte de `_context.Books` con `.AsNoTracking()`.
2. Filtra por categoría: `.Where(b => b.CategoryId == request.CategoryId)`.
3. Proyecta a `BookListDto` con `.Select(...)` (igual que la Query 1).
4. Devuelve `.ToListAsync(cancellationToken)` (lista vacía si no hay libros en esa categoría).

## Solución de referencia
```csharp
public async Task<List<BookListDto>> Handle(GetBooksByCategoryQuery request, CancellationToken cancellationToken)
{
    return await _context.Books
        .AsNoTracking()
        .Where(b => b.CategoryId == request.CategoryId)
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
(El `using BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;` para `BookListDto` ya está en el archivo.)

## Cómo probar
1. `git checkout -b feature/query3-tobon`
2. Implementa y ejecuta la API.
3. En Swagger: `GET /api/books/category/2` → *El Hobbit* y *El Señor de los Anillos* (Fantasía).
4. Commit y push:
   ```bash
   git commit -am "feat(books): Query 3 - consultar libros por categoría"
   git push -u origin feature/query3-tobon
   ```
