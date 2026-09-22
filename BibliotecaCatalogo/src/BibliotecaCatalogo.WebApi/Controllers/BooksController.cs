using BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;
using BibliotecaCatalogo.Application.Books.Queries.GetBookById;
using BibliotecaCatalogo.Application.Books.Queries.GetBooksByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaCatalogo.WebApi.Controllers;

/// <summary>
/// API de consulta del catálogo de libros.
/// Cada endpoint delega en MediatR el envío de la query correspondiente (CQRS);
/// el controlador no contiene lógica de negocio.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ISender _mediator;

    public BooksController(ISender mediator)
    {
        _mediator = mediator;
    }

    /// <summary>Query 1 (Sara) – Consultar todos los libros.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<BookListDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<BookListDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllBooksQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>Query 2 (Robledo) – Consultar un libro por ID.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BookDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDetailDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>Query 3 (Tobón) – Consultar libros por categoría.</summary>
    [HttpGet("category/{categoryId:int}")]
    [ProducesResponseType(typeof(List<BookListDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<BookListDto>>> GetByCategory(int categoryId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBooksByCategoryQuery(categoryId), cancellationToken);
        return Ok(result);
    }
}
