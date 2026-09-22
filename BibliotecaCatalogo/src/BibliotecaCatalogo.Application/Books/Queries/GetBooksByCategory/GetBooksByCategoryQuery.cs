using BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;
using MediatR;

namespace BibliotecaCatalogo.Application.Books.Queries.GetBooksByCategory;

/// <summary>
/// Query 3 – Consultar libros por categoría.
/// Reutiliza BookListDto (mismo formato de listado que la Query 1).
/// </summary>
public record GetBooksByCategoryQuery(int CategoryId) : IRequest<List<BookListDto>>;
