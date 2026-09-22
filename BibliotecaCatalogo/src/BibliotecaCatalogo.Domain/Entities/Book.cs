using BibliotecaCatalogo.Domain.Common;

namespace BibliotecaCatalogo.Domain.Entities;

/// <summary>
/// Raíz de agregado que representa un libro del catálogo de la biblioteca.
/// Contiene una referencia a su Autor y a su Categoría.
/// </summary>
public class Book : BaseEntity
{
    private Book() { }

    public Book(string title, string isbn, int publicationYear, int authorId, int categoryId)
    {
        Title = title;
        Isbn = isbn;
        PublicationYear = publicationYear;
        AuthorId = authorId;
        CategoryId = categoryId;
    }

    /// <summary>Título del libro.</summary>
    public string Title { get; private set; } = string.Empty;

    /// <summary>Código ISBN.</summary>
    public string Isbn { get; private set; } = string.Empty;

    /// <summary>Año de publicación.</summary>
    public int PublicationYear { get; private set; }

    // --- Relación con Autor ---
    public int AuthorId { get; private set; }
    public Author? Author { get; private set; }

    // --- Relación con Categoría ---
    public int CategoryId { get; private set; }
    public Category? Category { get; private set; }
}
