using BibliotecaCatalogo.Domain.Common;

namespace BibliotecaCatalogo.Domain.Entities;

/// <summary>
/// Categoría o género al que pertenece un libro.
/// </summary>
public class Category : BaseEntity
{
    private Category() { }

    public Category(string name)
    {
        Name = name;
    }

    /// <summary>Nombre de la categoría (p. ej. "Novela", "Ciencia").</summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>Libros que pertenecen a esta categoría.</summary>
    public ICollection<Book> Books { get; private set; } = new List<Book>();
}
