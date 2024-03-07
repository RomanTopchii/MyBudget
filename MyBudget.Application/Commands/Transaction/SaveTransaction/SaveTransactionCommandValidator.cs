using FluentValidation;

namespace MyBudget.Application.Commands.Transaction.SaveTransaction;

public class SaveTransactionCommandValidator : AbstractValidator<SaveTransactionCommand>
{
    public SaveTransactionCommandValidator()
    {
        this.RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Transaction type out of enumeration");
        
        this.RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Transaction status out of enumeration");
    }
}
