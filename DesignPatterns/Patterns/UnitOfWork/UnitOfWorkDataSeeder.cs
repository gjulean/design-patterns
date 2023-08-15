using Bogus;
using DesignPatterns.DataAccess;
using DesignPatterns.Domain.Entities;
using DesignPatterns.Patterns.Repository.Interfaces;

namespace DesignPatterns.Patterns.UnitOfWork
{
    public class UnitOfWorkDataSeeder
    {
        private UnitOfWork _unitOfWork;
        private IRepository<Product> _products;
        private IRepository<User> _users;
        private Faker _faker;

        public UnitOfWorkDataSeeder(DesignPatternsContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _products = _unitOfWork.Products;
            _users = _unitOfWork.Users;
            _faker = new Faker("es");
        }

        public void SeedData()
        {
            SeedProducts();
            SeedUsers();
            _unitOfWork.Save();
        }

        private void SeedProducts()
        {
            _products.Add(new Product
            {
                Name = _faker.Commerce.ProductName(),
                Price = _faker.Random.Number()
            });
        }

        private void SeedUsers()
        {
            _users.Add(new User
            {
                Name = _faker.Name.FirstName(),
                Email = $"{_faker.Name.JobTitle()}@gmail.com"
            });
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
}
