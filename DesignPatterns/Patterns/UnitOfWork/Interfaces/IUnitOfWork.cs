using DesignPatterns.Domain.Entities;
using DesignPatterns.Patterns.Repository.Interfaces;

namespace DesignPatterns.Patterns.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public IRepository<Product> Products { get; }
    public IRepository<User> Users { get; }
    public void Save();
}
