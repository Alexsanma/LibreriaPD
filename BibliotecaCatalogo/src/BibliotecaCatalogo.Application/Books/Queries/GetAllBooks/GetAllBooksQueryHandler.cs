using BibliotecaCatalogo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;


public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookListDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllBooksQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

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
}
