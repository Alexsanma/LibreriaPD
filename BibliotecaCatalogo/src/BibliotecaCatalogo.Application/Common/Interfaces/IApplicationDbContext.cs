using BibliotecaCatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Application.Common.Interfaces;

/// <summary>
/// Abstracción del contexto de datos usada por la capa de Aplicación.
/// Permite que los handlers consulten los datos sin depender de la
/// implementación concreta de EF Core / SQL Server (Regla de dependencias de Clean Architecture).
/// La implementación vive en la capa de Infraestructura (ApplicationDbContext).
/// </summary>
public interface IApplicationDbContext
{
    DbSet<Book> Books { get; }
    DbSet<Author> Authors { get; }
    DbSet<Category> Categories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
