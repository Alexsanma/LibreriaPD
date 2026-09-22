using BibliotecaCatalogo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;

// ============================================================================
//  PARTE DE: SARA
//  Query 1 – Consultar todos los libros
// ============================================================================
//
//  OBJETIVO: devolver la lista completa de libros con su autor y categoría.
//
//  PASOS (implementar dentro de Handle):
//    1. Partir de _context.Books.
//    2. Usar .Include(b => b.Author) y .Include(b => b.Category) para traer
//       las relaciones (o proyectar directamente con Select, que es más eficiente).
//    3. Proyectar cada Book a un BookListDto (Id, Title, Isbn, PublicationYear,
//       Author = b.Author!.FullName, Category = b.Category!.Name).
//    4. Usar .AsNoTracking() (es solo lectura) y .ToListAsync(cancellationToken).
//
//  SUGERENCIA (consulta recomendada):
//    return await _context.Books
//        .AsNoTracking()
//        .Select(b => new BookListDto
//        {
//            Id = b.Id,
//            Title = b.Title,
//            Isbn = b.Isbn,
//            PublicationYear = b.PublicationYear,
//            Author = b.Author!.FullName,
//            Category = b.Category!.Name
//        })
//        .ToListAsync(cancellationToken);
//
//  La solución de referencia completa está en docs/Sara.md
// ============================================================================

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllBooksQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookListDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        // TODO (Sara): implementar la consulta descrita arriba y devolver la lista de BookListDto.
        await Task.CompletedTask;
        throw new NotImplementedException("TODO Sara: implementar Query 1 - Consultar todos los libros.");
    }
}
