using BibliotecaCatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaCatalogo.Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.FullName)
            .IsRequired()
            .HasMaxLength(200);

        // Datos de ejemplo (semilla) para poder consultar sin registrar.
        builder.HasData(
            new { Id = 1, FullName = "Gabriel García Márquez" },
            new { Id = 2, FullName = "J.R.R. Tolkien" },
            new { Id = 3, FullName = "Robert C. Martin" },
            new { Id = 4, FullName = "Yuval Noah Harari" }
        );
    }
}
