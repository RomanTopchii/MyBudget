using FluentValidation;

namespace MyBudget.Application.Commands.Account.SaveAccount;

public class SaveAccountValidator : AbstractValidator<SaveAccount>
{
    public SaveAccountValidator()
    {
        const int minNameLength = 1;
        const int maxNameLength = 255;

        this.RuleFor(x => x.Name)
            .Length(minNameLength, maxNameLength)
            .WithMessage($"AccountType name length should be between {minNameLength} and {maxNameLength}");

    }
}
