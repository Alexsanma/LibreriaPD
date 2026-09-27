using BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;
using BibliotecaCatalogo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Application.Books.Queries.GetBooksByCategory;

public class GetBooksByCategoryQueryHandler : IRequestHandler<GetBooksByCategoryQuery, List<BookListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetBooksByCategoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

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
}
