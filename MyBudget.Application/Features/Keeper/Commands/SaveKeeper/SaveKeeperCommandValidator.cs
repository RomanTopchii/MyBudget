using FluentValidation;

namespace MyBudget.Application.Features.Keeper.Commands.SaveKeeper;

public class SaveKeeperCommandValidator : AbstractValidator<SaveKeeperCommand>
{
    public SaveKeeperCommandValidator()
    {
        const int minNameLength = 1;
        const int maxNameLength = 255;

        this.RuleFor(x => x.Name)
            .Length(minNameLength, maxNameLength)
            .WithMessage($"Keeper name length should be between {minNameLength} and {maxNameLength}");

        this.RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Keeper type out of enumeration");
    }
}
