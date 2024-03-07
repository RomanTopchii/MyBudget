using FluentValidation;

namespace MyBudget.Application.Commands.Currency.SaveCurrency;

public class SaveCurrencyCommandValidator : AbstractValidator<SaveCurrencyCommand>
{
    public SaveCurrencyCommandValidator()
    {
        const int minNameLength = 1;
        const int maxNameLength = 255;

        this.RuleFor(x => x.Name)
            .Length(minNameLength, maxNameLength)
            .WithMessage($"Currency name length should be between {minNameLength} and {maxNameLength}");

        this.RuleFor(x => x.Code)
            .Length(3)
            .WithMessage($"Currency code should contain 3 symbols");

        const int minIso4217 = 1;
        const int maxIso4217 = 999;
        
        this.RuleFor(x => x.Iso4217)
            .InclusiveBetween(minIso4217,maxIso4217)
            .WithMessage($"Currency Iso4217 should be between {minIso4217} and {maxIso4217}");
    }
}
