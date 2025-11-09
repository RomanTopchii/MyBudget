using MediatR;

namespace MyBudget.Application.Commands.Holder.SaveHolder;

public record SaveHolder(Guid? Id, bool Active, string Name) : IRequest;
