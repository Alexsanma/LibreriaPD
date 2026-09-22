using MediatR;

namespace BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;

/// <summary>
/// Query 1 – Consultar todos los libros.
/// No lleva parámetros: devuelve el catálogo completo.
/// </summary>
public record GetAllBooksQuery : IRequest<List<BookListDto>>;
