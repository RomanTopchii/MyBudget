using MyBudget.Application.Interfaces.Persistence.Repositories;
using MyBudget.Domain;

namespace MyBudget.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    int Complete();
}
