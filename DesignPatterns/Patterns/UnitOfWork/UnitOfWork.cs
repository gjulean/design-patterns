using DesignPatterns.DataAccess;
using DesignPatterns.Domain.Entities;
using DesignPatterns.Patterns.Repository;
using DesignPatterns.Patterns.Repository.Interfaces;
using DesignPatterns.Patterns.UnitOfWork.Interfaces;

namespace DesignPatterns.Patterns.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private DesignPatternsContext _context;

    public IRepository<Product> _products;
    public IRepository<User> _users;

    public IRepository<Product> Products
    {
        get
        {
            return _products ?? new Repository<Product>(_context);
        }
    }

    public IRepository<User> Users
    {
        get
        {
            return _users ?? new Repository<User>(_context);
        }
    }

    public UnitOfWork(DesignPatternsContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
