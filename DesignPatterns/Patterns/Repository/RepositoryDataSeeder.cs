using Bogus;
using DesignPatterns.DataAccess;
using DesignPatterns.Domain.Entities;

namespace DesignPatterns.Patterns.Repository;

public class RepositoryDataSeeder
{
    private DesignPatternsContext _context;
    private Repository<Product> _products { get { return _products ?? new Repository<Product>(_context); } }
    private Repository<User> _users { get { return _users ?? new Repository<User>(_context);  }}

    private Faker _faker;

    public RepositoryDataSeeder(DesignPatternsContext context)
    {
        _context = context;
        _faker = new Faker("es");
    }

    public void SeedData()
    {
        SeedProducts();
        SeedUsers();
    }

    private void SeedProducts()
    {

        _products.Add(new Product
        {
            Name = _faker.Commerce.ProductName(),
            Price = _faker.Random.Number()
        });

        _products.Save();
    }

    private void SeedUsers()
    {
        _users.Add(new User
        {
            Name = _faker.Name.FirstName(),
            Email = $"{_faker.Name.JobTitle()}@gmail.com"
        });

        _users.Save();
    }

    public void DisplayData()
    {
        Console.WriteLine("Products: ");
        foreach (var product in _products.GetAll())
        {
            Console.WriteLine($"{product.Id} {product.Name}");
        }

        Console.WriteLine();
        Console.WriteLine("Users: ");
        foreach (var user in _users.GetAll())
        {
            Console.WriteLine($"{user.Id} {user.Name}");
        }
    }
}
