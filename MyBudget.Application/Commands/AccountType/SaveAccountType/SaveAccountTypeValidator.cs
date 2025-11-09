using FluentValidation;

namespace MyBudget.Application.Commands.AccountType.SaveAccountType;

public class SaveAccountTypeValidator : AbstractValidator<SaveAccountType>
{
    public SaveAccountTypeValidator()
    {
        const int minNameLength = 1;
        const int maxNameLength = 255;

        this.RuleFor(x => x.Name)
            .Length(minNameLength, maxNameLength)
            .WithMessage($"AccountType name length should be between {minNameLength} and {maxNameLength}");

        this.RuleFor(x => x.Classification)
            .IsInEnum();
        
        this.RuleFor(x => x.KeeperGroup)
            .IsInEnum();
    }
}
