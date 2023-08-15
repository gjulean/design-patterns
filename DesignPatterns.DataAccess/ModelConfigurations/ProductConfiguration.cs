using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DesignPatterns.Domain.Entities;

namespace DesignPatterns.DataAccess.ModelConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Name)
               .HasColumnName("Name")
               .IsRequired(true)
               .ValueGeneratedOnAdd();

        builder.Property(user => user.Price)
               .HasColumnName("FixedPrice")
               .IsRequired(false);
    }
}
