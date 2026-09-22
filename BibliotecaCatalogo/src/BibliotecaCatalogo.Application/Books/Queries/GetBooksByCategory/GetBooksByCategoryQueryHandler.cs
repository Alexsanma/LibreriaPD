using BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;
using BibliotecaCatalogo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Application.Books.Queries.GetBooksByCategory;

// ============================================================================
//  PARTE DE: TOBÓN
//  Query 3 – Consultar libros por categoría
// ============================================================================
//
//  OBJETIVO: devolver los libros que pertenecen a una categoría concreta
//            (identificada por request.CategoryId), en formato BookListDto.
//
//  PASOS (implementar dentro de Handle):
//    1. Partir de _context.Books con .AsNoTracking().
//    2. Filtrar por categoría: .Where(b => b.CategoryId == request.CategoryId).
//    3. Proyectar a BookListDto (igual que la Query 1: Author = b.Author!.FullName,
//       Category = b.Category!.Name).
//    4. Devolver .ToListAsync(cancellationToken) (lista vacía si no hay coincidencias).
//
//  SUGERENCIA (consulta recomendada):
//    return await _context.Books
//        .AsNoTracking()
//        .Where(b => b.CategoryId == request.CategoryId)
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
//  La solución de referencia completa está en docs/Tobon.md
// ============================================================================

public class GetBooksByCategoryQueryHandler : IRequestHandler<GetBooksByCategoryQuery, List<BookListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetBooksByCategoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookListDto>> Handle(GetBooksByCategoryQuery request, CancellationToken cancellationToken)
    {
        // TODO (Tobón): implementar la consulta por categoría descrita arriba.
        await Task.CompletedTask;
        throw new NotImplementedException("TODO Tobón: implementar Query 3 - Consultar libros por categoría.");
    }
}
