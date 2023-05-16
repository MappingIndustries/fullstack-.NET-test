using FluentValidation;
using VocabularyVault.Dtos;

namespace VocabularyVault.Validations;

public class AddFavouriteWordValidation : AbstractValidator<AddFavouriteWordRequestDto>
{
    public AddFavouriteWordValidation()
    {
        RuleFor(property => property.Word)
            .NotEmpty()
            .Matches("^[a-zA-Z]+$")
            .WithMessage("word cannot be empty and must contains only alphabets");
        RuleFor(property => property.Defination).NotEmpty().WithMessage("Defination cannot be empty");
        RuleFor(property => property.UsageType).NotEmpty().WithMessage("Usage type cannot be empty");
    }
}