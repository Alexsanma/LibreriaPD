using BibliotecaCatalogo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Application.Books.Queries.GetBookById;

// ============================================================================
//  PARTE DE: ROBLEDO
//  Query 2 – Consultar un libro por ID
// ============================================================================
//
//  OBJETIVO: devolver el detalle de un libro a partir de su Id, incluyendo
//            autor y categoría. Si el libro no existe, devolver null
//            (el controlador lo traducirá a 404 Not Found).
//
//  PASOS (implementar dentro de Handle):
//    1. Partir de _context.Books con .AsNoTracking().
//    2. Filtrar por Id: .Where(b => b.Id == request.Id).
//    3. Proyectar a BookDetailDto (incluye AuthorId/Author y CategoryId/Category).
//    4. Devolver .FirstOrDefaultAsync(cancellationToken) -> null si no existe.
//
//  SUGERENCIA (consulta recomendada):
//    return await _context.Books
//        .AsNoTracking()
//        .Where(b => b.Id == request.Id)
//        .Select(b => new BookDetailDto
//        {
//            Id = b.Id,
//            Title = b.Title,
//            Isbn = b.Isbn,
//            PublicationYear = b.PublicationYear,
//            AuthorId = b.AuthorId,
//            Author = b.Author!.FullName,
//            CategoryId = b.CategoryId,
//            Category = b.Category!.Name
//        })
//        .FirstOrDefaultAsync(cancellationToken);
//
//  La solución de referencia completa está en docs/Robledo.md
// ============================================================================

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailDto?>
{
    private readonly IApplicationDbContext _context;

    public GetBookByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

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
}
