using System.Linq.Expressions;

namespace MyBudget.Application.Interfaces.Persistence.Repositories;

public interface IRepository<T> 
    where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> expression);
    
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);

    Task<T> AddAsync(T entity);

    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);
}