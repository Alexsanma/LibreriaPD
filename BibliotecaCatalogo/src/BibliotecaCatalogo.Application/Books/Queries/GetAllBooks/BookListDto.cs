namespace BibliotecaCatalogo.Application.Books.Queries.GetAllBooks;

/// <summary>
/// DTO de lectura para el listado de libros (Query 1 y Query 3).
/// Aplana Autor y Categoría a sus nombres para no exponer las entidades del dominio.
/// </summary>
public class BookListDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}
