using System.Reflection;
using BibliotecaCatalogo.Application.Common.Interfaces;
using BibliotecaCatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCatalogo.Infrastructure.Persistence;

/// <summary>
/// Contexto de EF Core. Implementa IApplicationDbContext para que la capa
/// de Aplicación pueda consultar los datos a través de la abstracción.
/// </summary>
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica todas las IEntityTypeConfiguration de este ensamblado
        // (BookConfiguration, AuthorConfiguration, CategoryConfiguration).
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
