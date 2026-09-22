using MediatR;

namespace BibliotecaCatalogo.Application.Books.Queries.GetBookById;

/// <summary>
/// Query 2 – Consultar un libro por ID.
/// Devuelve el detalle del libro o null si no existe.
/// </summary>
public record GetBookByIdQuery(int Id) : IRequest<BookDetailDto?>;
