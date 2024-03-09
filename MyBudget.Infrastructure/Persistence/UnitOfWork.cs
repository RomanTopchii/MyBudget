using MyBudget.Application.Interfaces.Persistence;
using MyBudget.Domain;
using MyBudget.Application.Interfaces.Persistence.Repositories;

namespace MyBudget.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        this._context = context;
    }

    public int Complete()
    {
        return this._context.SaveChanges();
    }
}
