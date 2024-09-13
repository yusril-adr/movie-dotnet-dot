using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class MovieBackOfficeUpdateValidator : AbstractValidator<MovieBackOfficeUpdateDto>
{
    public MovieBackOfficeUpdateValidator()
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
