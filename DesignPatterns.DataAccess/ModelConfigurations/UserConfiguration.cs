using DesignPatterns.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPatterns.DataAccess.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
               .HasColumnName("Name")
               .IsRequired(true)
               .ValueGeneratedOnAdd();

        builder.Property(user => user.Email)
               .HasColumnName("Email")
               .IsRequired(false);
    }
}
