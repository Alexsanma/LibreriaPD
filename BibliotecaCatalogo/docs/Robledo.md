# Robledo — Query 2: Consultar un libro por ID

**Endpoint (ya listo):** `GET /api/books/{id}`
**Archivo a completar:** `src/BibliotecaCatalogo.Application/Books/Queries/GetBookById/GetBookByIdQueryHandler.cs`

## Objetivo
Devolver el **detalle** de un libro a partir de su `Id` (con autor y categoría) como `BookDetailDto`.
Si el libro no existe, devolver `null` — el `BooksController` lo traduce a **404 Not Found**.

## Qué ya está hecho por ti
- `GetBookByIdQuery(int Id)`.
- `BookDetailDto` (Id, Title, Isbn, PublicationYear, AuthorId, Author, CategoryId, Category).
- El endpoint en `BooksController.GetById` (incluye el manejo de 404).

## Pasos
1. Parte de `_context.Books` con `.AsNoTracking()`.
2. Filtra por `Id`: `.Where(b => b.Id == request.Id)`.
3. Proyecta a `BookDetailDto` con `.Select(...)`.
4. Devuelve `.FirstOrDefaultAsync(cancellationToken)` (será `null` si no existe).

## Solución de referencia
```csharp
public async Task<BookDetailDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
{
    return await _context.Books
        .AsNoTracking()
        .Where(b => b.Id == request.Id)
        .Select(b => new BookDetailDto
        {
            Id = b.Id,
            Title = b.Title,
            Isbn = b.Isbn,
            PublicationYear = b.PublicationYear,
            AuthorId = b.AuthorId,
            Author = b.Author!.FullName,
            CategoryId = b.CategoryId,
            Category = b.Category!.Name
        })
        .FirstOrDefaultAsync(cancellationToken);
}
```

## Cómo probar
1. `git checkout -b feature/query2-robledo`
2. Implementa y ejecuta la API.
3. En Swagger: `GET /api/books/5` → *Clean Code*; `GET /api/books/999` → **404**.
4. Commit y push:
   ```bash
   git commit -am "feat(books): Query 2 - consultar libro por ID"
   git push -u origin feature/query2-robledo
   ```
