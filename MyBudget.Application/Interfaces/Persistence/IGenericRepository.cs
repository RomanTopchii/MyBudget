using System.Linq.Expressions;

namespace MyBudget.Application.Interfaces.Persistence;

public interface IGenericRepository<T> 
    where T : class
{
    T? GetById(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> expression);
    
    bool Any(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);

    T Add(T entity);
    Task<T> AddAsync(T entity);

    IEnumerable<T> AddRange(IEnumerable<T> entities);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    void Remove(T entity);
    Task RemoveAsync(T entity);

    void RemoveRange(IEnumerable<T> entities);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}