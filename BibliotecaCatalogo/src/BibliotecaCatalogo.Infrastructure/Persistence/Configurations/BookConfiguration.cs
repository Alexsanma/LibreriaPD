using BibliotecaCatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaCatalogo.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(b => b.Isbn)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.PublicationYear)
            .IsRequired();

        // Relación Book -> Author (muchos libros por autor).
        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Book -> Category (muchos libros por categoría).
        builder.HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índice por ISBN (facilita búsquedas / evita duplicados).
        builder.HasIndex(b => b.Isbn).IsUnique();

        // Datos de ejemplo (semilla).
        builder.HasData(
            new { Id = 1, Title = "Cien años de soledad", Isbn = "978-0307474728", PublicationYear = 1967, AuthorId = 1, CategoryId = 1 },
            new { Id = 2, Title = "El amor en los tiempos del cólera", Isbn = "978-0307389732", PublicationYear = 1985, AuthorId = 1, CategoryId = 1 },
            new { Id = 3, Title = "El Hobbit", Isbn = "978-0261102217", PublicationYear = 1937, AuthorId = 2, CategoryId = 2 },
            new { Id = 4, Title = "El Señor de los Anillos", Isbn = "978-0618640157", PublicationYear = 1954, AuthorId = 2, CategoryId = 2 },
            new { Id = 5, Title = "Clean Code", Isbn = "978-0132350884", PublicationYear = 2008, AuthorId = 3, CategoryId = 3 },
            new { Id = 6, Title = "Clean Architecture", Isbn = "978-0134494166", PublicationYear = 2017, AuthorId = 3, CategoryId = 3 },
            new { Id = 7, Title = "Sapiens: De animales a dioses", Isbn = "978-0062316097", PublicationYear = 2011, AuthorId = 4, CategoryId = 4 }
        );
    }
}
