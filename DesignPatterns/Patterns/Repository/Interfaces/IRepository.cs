﻿namespace DesignPatterns.Patterns.Repository.Interfaces;

public interface IRepository<TEntity> 
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
    void Save();
}
