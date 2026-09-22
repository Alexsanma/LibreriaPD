using BibliotecaCatalogo.Domain.Common;

namespace BibliotecaCatalogo.Domain.Entities;

/// <summary>
/// Autor de uno o varios libros del catálogo.
/// </summary>
public class Author : BaseEntity
{
    // EF Core necesita un constructor sin parámetros (puede ser privado).
    private Author() { }

    public Author(string fullName)
    {
        FullName = fullName;
    }

    /// <summary>Nombre completo del autor.</summary>
    public string FullName { get; private set; } = string.Empty;

    /// <summary>Libros escritos por el autor (propiedad de navegación).</summary>
    public ICollection<Book> Books { get; private set; } = new List<Book>();
}
