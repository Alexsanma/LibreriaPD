namespace BibliotecaCatalogo.Application.Books.Queries.GetBookById;

/// <summary>
/// DTO de lectura con el detalle de un libro (Query 2).
/// Incluye los identificadores y nombres de Autor y Categoría.
/// </summary>
public class BookDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }

    public int AuthorId { get; set; }
    public string Author { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public string Category { get; set; } = string.Empty;
}
