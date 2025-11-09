using FluentValidation;

namespace MyBudget.Application.Commands.Holder.SaveHolder;

public class SaveHolderValidator : AbstractValidator<SaveHolder>
{
    public SaveHolderValidator()
    {
        const int minNameLength = 1;
        const int maxNameLength = 255;

        this.RuleFor(x => x.Name)
            .Length(minNameLength, maxNameLength)
            .WithMessage($"Holder name length should be between {minNameLength} and {maxNameLength}");
    }
}
