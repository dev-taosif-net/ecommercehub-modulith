using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        // Primary key
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever(); // ID is assigned by the Create factory method

        // Core properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.ImageFile)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        // Primitive collection mapped to a PostgreSQL text[] column
        builder.Property(p => p.Category)
            .IsRequired();

        // Audit fields (inherited from Entity<Guid>)
        builder.Property(p => p.CreatedAt);
        builder.Property(p => p.CreatedBy)
            .HasMaxLength(100);
        builder.Property(p => p.LastModifiedAt);
        builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(100);

        // Domain events are transient – must not be persisted
        builder.Ignore(p => p.DomainEvents);
    }
}

