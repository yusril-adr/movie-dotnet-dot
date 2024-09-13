using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class MovieV1BackListValidator : AbstractValidator<MovieV1ListDto>
{
    public MovieV1BackListValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("page is required");
            
        RuleFor(x => x.PerPage)
            .NotEmpty().WithMessage("per_page is required");
    }
}
