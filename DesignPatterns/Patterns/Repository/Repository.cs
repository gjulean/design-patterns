using DesignPatterns.DataAccess;
using DesignPatterns.Patterns.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Patterns.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DesignPatternsContext _context;
    private DbSet<TEntity> _dbSet;

    public Repository(DesignPatternsContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(int id)
    {
        _dbSet.Remove(Get(id));
    }

    public TEntity Get(int id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
