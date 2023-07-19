using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Infrastructure.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbSet<T> dbSet;
    
    public GenericRepository(DbContext context)
    {
        dbSet = context.Set<T>();
    }
    
    public T? GetById(Guid id)
    {
        return dbSet.Find(id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public IEnumerable<T> GetAll()
    {
        return dbSet.ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return dbSet.Where(expression);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await dbSet.Where(expression).ToListAsync();
    }

    public bool Any(Expression<Func<T, bool>> expression)
    {
        return dbSet.Any(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await dbSet.AnyAsync(expression);
    }

    public T Add(T entity)
    { 
        dbSet.Add(entity);
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        dbSet.AddRange(entities);
        return entities;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
        return entities;
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public Task RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }

    public Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }
}