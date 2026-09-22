using BibliotecaCatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaCatalogo.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new { Id = 1, Name = "Novela" },
            new { Id = 2, Name = "Fantasía" },
            new { Id = 3, Name = "Ingeniería de Software" },
            new { Id = 4, Name = "Historia" }
        );
    }
}
