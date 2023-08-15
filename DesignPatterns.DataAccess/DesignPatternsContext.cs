using DesignPatterns.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.DataAccess;

public class DesignPatternsContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=DesignPatterns;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesignPatternsContext).Assembly);
    }
}
