using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.Validators;
public class MovieV1BackOfficeUpdateValidator : AbstractValidator<MovieV1BackOfficeUpdateDto>
{
    public MovieV1BackOfficeUpdateValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("title is required");
            
        RuleFor(x => x.Overview)
            .NotEmpty().WithMessage("overview is required");

        RuleFor(x => x.PlayUntil)
            .NotEmpty().WithMessage("play_until is required");

        RuleFor(x => x.Poster)
            .NotEmpty().WithMessage("poster is required");

        RuleFor(x => x.Tags)
            .NotEmpty().WithMessage("tags is required");
    }
}
